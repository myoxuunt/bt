#define ENABLE_TEST
using System;
using System.Diagnostics;

#if ENABLE_TEST
using NUnit.Framework;
#endif

namespace Communication
{
	#region WastingCaloricCalculator
    /// <summary>
    /// ������������
    /// </summary>
    /// 
    [TestFixture]
    public class WastingCaloricCalculator
    {
        #region Members
        private static readonly TimeSpan TS_ONEDAY = TimeSpan.FromDays(1);
        private static readonly TimeSpan TS_SPLIT  = TimeSpan.Parse("12:00:00");

        /// <summary>
        /// 
        /// </summary>
        private TimeSpan _timeSpanOfWastingCaloric = TS_ONEDAY;
        private DateTime _dateOfWastingCaloric;
        private GrDataPointsCollection  _grDataPoints = new GrDataPointsCollection();
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public WastingCaloricCalculator( DateTime date )
        {
            this._dateOfWastingCaloric = date.Date;
        }
        #endregion //Constructor

        #region Properties

        #region Date
        /// <summary>
        /// �����������ĺ�����
        /// </summary>
        public DateTime Date
        {
        	get { return _dateOfWastingCaloric; }
        }
        #endregion //Date
        
        #region TimeSpanOfWastingCaloric
        /// <summary>
        /// ��������ʱ�η�Χ��һ��
        /// </summary>
        public TimeSpan TimeSpanOfWastingCaloric
        {
        	get { return _timeSpanOfWastingCaloric; }
        }
        #endregion //TimeSpanOfWastingCaloric

        #region LastGrDataPoint
        /// <summary>
        /// ��ȡ���һ�����ݵ㣬���û�з���null
        /// </summary>
        private GrDataPoint LastGrDataPoint
        {
            get 
            {
                if ( _grDataPoints.Count == 0 )
                    return null;
                else 
                    return _grDataPoints[ _grDataPoints.Count - 1 ];
            }
        }
        #endregion //LastGrDataPoint

        #endregion //Properties

        #region Method

        #region Calc
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Calc()
        {
            if ( this._grDataPoints.Count == 0 )
                return 0;

            // ? ֻ��һ������ʱ���޷���������
            //
            if ( this._grDataPoints.Count == 1 )
                return 1;

            float onegtSum = 0;
            float onebtSum = 0;
            int   onesum = 0;

            for( int i=0; i<this._grDataPoints.Count; i++ )
            {
                GrDataPoint gdp = _grDataPoints[ i ];
                onegtSum += gdp.OneGiveTemp;
                onebtSum += gdp.OneBackTemp;
               
                if ( i != 0 )
                {
                    GrDataPoint preGdp = _grDataPoints[ i - 1 ];
                    int thesumdiff = gdp.OneSum - preGdp.OneSum;
                    if ( thesumdiff > 0 )
                    {
                        onesum += thesumdiff;
                    }
                }
            }

            GrDataPoint firstGdp = _grDataPoints[0];
            GrDataPoint lastGdp  = _grDataPoints[ _grDataPoints.Count - 1 ];
            TimeSpan ts = lastGdp.DateTime - firstGdp.DateTime;

            float onegtAvg = onegtSum / _grDataPoints.Count;
            float onebtAvg = onebtSum / _grDataPoints.Count;

            return Calc( onegtAvg, onebtAvg, onesum, ts );
            //throw new NotImplementedException( "calc()" );
        }
        #endregion //Calc

        #region Calc
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oneGiveTemp"></param>
        /// <param name="oneBackTemp"></param>
        /// <param name="flux"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        private int Calc( float oneGiveTemp, float oneBackTemp, int flux, TimeSpan ts )
        {
            double d = TS_ONEDAY.TotalSeconds / ts.TotalSeconds;
            double ans = (oneGiveTemp - oneBackTemp) * flux * d * 4.1868 / 1000;
            return (int)ans;
        }
        #endregion //

        #region AddGrDataPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        public void AddGrDataPoint( GrDataPoint grDataPoint )
        {
            Debug.Assert( 
                grDataPoint.DateTime.Date == this.Date ||
                    ( grDataPoint.DateTime.Date - this.Date == TS_ONEDAY && 
                      grDataPoint.DateTime.TimeOfDay == TimeSpan.Zero ) 
                );
            this._grDataPoints.Add( grDataPoint );
        }
        #endregion //AddGrDataPoint

        #region IsTodayGrDataPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        /// <returns></returns>
        public bool IsTodayGrDataPoint( GrDataPoint grDataPoint )
        {
            Debug.Assert( grDataPoint != null );
            return grDataPoint.DateTime.Date == this.Date;
        }
        #endregion //IsTodayGrDataPoint

        #region IsNextDayDataPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        /// <returns></returns>
        public bool IsNextDayDataPoint( GrDataPoint grDataPoint )
        {
            Debug.Assert( grDataPoint != null );
            return ( grDataPoint.DateTime.Date - this.Date 
                == TimeSpan.FromDays(1) );
        }
        #endregion //IsNextDayDataPoint

        #region CanCalcZeroDataPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        /// <returns></returns>
        public bool CanCalcZeroDataPoint( GrDataPoint grDataPoint )
        {
            if ( this.LastGrDataPoint == null )
                return false;

            if ( LastGrDataPoint.DateTime.TimeOfDay >= TS_SPLIT &&
                grDataPoint.DateTime.TimeOfDay < TS_SPLIT )
                return true;
            else
                return false;
        }
        #endregion //CanCalcZeroDataPoint

        #region CalcZeroDataPoint
        /// <summary>
        /// ��������GrDataPointֵ
        /// </summary>
        /// <param name="grDataPoint">��һ������ĵ�һ��ֵ</param>
        /// <returns></returns>
        public GrDataPoint CalcZeroDataPoint( GrDataPoint grDataPoint )
        {
            // �������ݵ�ʱ�����һ��
            //
            Debug.Assert( grDataPoint.DateTime.Date - this.Date == TimeSpan.FromDays(1) );

            // ��ͬһ��վ���
            //
            if ( this.LastGrDataPoint != null )
                Debug.Assert( grDataPoint.StationName == this.LastGrDataPoint.StationName );

            // timespan of zero to last data point 
            //
            TimeSpan tsZero2Ldp = this.Date - this.LastGrDataPoint.DateTime + TS_ONEDAY;

            // timespan of right data point to last data point
            //
            TimeSpan tsRdp2Ldp = grDataPoint.DateTime - this.LastGrDataPoint.DateTime;

            float k = (float)tsZero2Ldp.Ticks  / (float)tsRdp2Ldp.Ticks;

            float onegt = CalcLinearVal( this.LastGrDataPoint.OneGiveTemp, grDataPoint.OneGiveTemp, k );
            float onebt = CalcLinearVal( this.LastGrDataPoint.OneBackTemp, grDataPoint.OneBackTemp, k );
            int onesum = (int)CalcLinearVal( this.LastGrDataPoint.OneSum, grDataPoint.OneSum, k ); 

            GrDataPoint newdp = new GrDataPoint( 
                grDataPoint.StationName, 
                grDataPoint.DateTime.Date,
                onegt,
                onebt,
                onesum 
                );

            return newdp;
 
        }
        #endregion //CalcZeroDataPoint

        #region CalcLinearVal(float)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private float CalcLinearVal( float v1, float v2, float k )
        {
            return ( v2 - v1 ) * k + v1;
        }
        #endregion //

        #endregion //Method

        #region ENABLE_TEST 
#if ENABLE_TEST
        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculator()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Test]
        public void testCalcLinearVal()
        {
            float[] v1s = new float[]{0,    5,    10,   5,  5   };
            float[] v2s = new float[]{10,   15,   5,    10, 10  };
            float[] ks  = new float[]{0.5F, 0.5F, 0.5F, 0F, 1F  };
            float[] res = new float[]{5,    10,   7.5F, 5,  10F };

            for (int i=0; i<v1s.Length; i++ )
            {
                float r = CalcLinearVal( v1s[i], v2s[i], ks[i] );
                Assert.AreEqual( res[i], r );
            }
        }
#endif
        #endregion //
    }
    #endregion //WastingCaloricCalculator
}
