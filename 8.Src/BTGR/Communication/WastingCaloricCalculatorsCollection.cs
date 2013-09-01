using System;
using System.Collections;

namespace Communication
{
    #region WastingCaloricCalculatorsCollection
    /// <summary>
    /// 
    /// </summary>
    public class WastingCaloricCalculatorsCollection
    {
        #region Members
        private const int CAPACITY = 31;        // 31 days per month
        private ArrayList _list = new ArrayList( CAPACITY );
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculatorsCollection()
        {
        }
        #endregion //Constructor

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculator this[ int index ]
        {
            get { return (WastingCaloricCalculator )_list[index]; }
        }
        #endregion //Properties

        #region Method
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wcc"></param>
        public void Add( WastingCaloricCalculator  wcc )
        {
            if ( wcc == null )
                throw new ArgumentNullException( "wcc" );

            _list.Add( wcc );
        }
        #endregion //Method
    }
    #endregion //WastingCaloricCalculatorsCollection

    #region WastingCaloricCalculatorWithName
    /// <summary>
    /// 
    /// </summary>
    public class WastingCaloricCalculatorWithName
    {
        #region Members
        private string _stationName;
        private WastingCaloricCalculatorsCollection _wccs = new WastingCaloricCalculatorsCollection();
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculatorWithName(string stationName)
        {
            _stationName = stationName;
        }
        #endregion //Constructor

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string StationName 
        {
            get { return _stationName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculatorsCollection WastingCaloricCalculatorsCollection
        {
            get { return _wccs; }
        }
        #endregion //Properties

        #region Method

        #region AddGrDataPoint
        /// <summary>
        /// 按照时间顺序自动加入相关的Wcc中，或自动创建Wcc并加入到wccs中
        /// </summary>
        /// <param name="grDataPoint"></param>
        public void AddGrDataPoint( GrDataPoint grDataPoint )
        {
            if ( _wccs.Count > 0 )
            {
                // 已包含数据
                WastingCaloricCalculator lastwcc = _wccs[ _wccs.Count - 1 ];
                if ( lastwcc.IsTodayGrDataPoint ( grDataPoint ) )
                {
                    lastwcc.AddGrDataPoint( grDataPoint );
                }
                else if( lastwcc.IsNextDayDataPoint( grDataPoint ) )
                {
                    if ( lastwcc.CanCalcZeroDataPoint( grDataPoint ) )
                    {
                        GrDataPoint zerogdp = lastwcc.CalcZeroDataPoint( grDataPoint );
                        lastwcc.AddGrDataPoint( zerogdp );
                        CreateAndAddNewWcc( zerogdp );
                    }
                    else
                    {
                        CreateAndAddNewWcc( grDataPoint );
                    }
                }
                else
                {
                    CreateAndAddNewWcc( grDataPoint );
                }
            }
            else
            {
                CreateAndAddNewWcc( grDataPoint );
            }
        }
        #endregion //AddGrDataPoint

        #region CreateAndAddNewWcc
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grDataPoint"></param>
        private void CreateAndAddNewWcc( GrDataPoint grDataPoint )
        {
            WastingCaloricCalculator newwcc = new WastingCaloricCalculator( grDataPoint.DateTime );
            newwcc.AddGrDataPoint( grDataPoint );
            _wccs.Add( newwcc );
        }
        #endregion //CreateAndAddNewWcc

        #endregion //Method
    }
    #endregion //WastingCaloricCalculatorWithName



    #region WccwnsCollection
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Wccwns - Wasting caoloric calculator with names
    /// </remarks>
    public class WccwnsCollection
    {
        #region Members
        private ArrayList _list = new ArrayList( 70 );
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public class WccwnsCollecion
        {
        }
        #endregion //Constructor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public int Count 
        { 
            get { return _list.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculatorWithName this[ int index ]
        {
            get { return (WastingCaloricCalculatorWithName)_list[ index ];}
        }
        #endregion //Properties

        #region Method

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wccwn"></param>
        public void Add( WastingCaloricCalculatorWithName wccwn )
        {
            if ( wccwn == null )
                throw new ArgumentNullException( "wccwn" );
            _list.Add( wccwn );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public WastingCaloricCalculatorWithName FindWccwn( string stationName )
        {
           return this.FindWccwn( stationName, true ); 
        }


        /// <summary>
        /// 查找名称为stationName的Wccwn
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="create">没有匹配时，是否创建新的。如创建则会把新对象加入本集合中</param>
        /// <returns></returns>
        public WastingCaloricCalculatorWithName FindWccwn( string stationName, bool create )
        {
            for( int i=0; i<this.Count; i++ )
            {
                WastingCaloricCalculatorWithName wccwn = this[ i ];
                if ( wccwn.StationName == stationName )
                    return wccwn;
            }

            if ( create )
            {
                WastingCaloricCalculatorWithName newwccwn = new WastingCaloricCalculatorWithName( stationName );
                this.Add( newwccwn );
                return newwccwn;
            }

            return null;
        }
        #endregion //Method
    }
    #endregion //WccwnsCollection
}
