using System;

namespace Communication
{
    #region WastingCaloricCalculatorOfDays
    /// <summary>
    /// 
    /// </summary>
    public class WastingCaloricCalculatorOfDays
    {
        #region Members
        private WccwnsCollection _wccwns = new WccwnsCollection();
        
        // [beginDate, endData]
        //
        private DateTime    _beginDate;
        private DateTime    _endDate;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public WastingCaloricCalculatorOfDays(DateTime beginDate, DateTime endDate)
        {
            DateTime b = beginDate.Date;
            DateTime e = endDate.Date;

            if( e < b )
                throw new ArgumentException("beginDate < endDate");

            _beginDate = b;
            _endDate = e;
        }
        #endregion //Constructor

        #region Properties

        #region EndDate
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate
        {
        	get { return _endDate; }
        }
        #endregion //EndDate

        #region BeginDate
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginDate
        {
        	get { return _beginDate; }
        }
        #endregion //BeginDate
        #endregion //Properties

        #region Method

        #region AddGrDataPoint
        /// <summary>
        /// 添加该grDataPoint 到集合中，并根据站名和时间自动分配到相关的Wccs中
        /// </summary>
        /// <param name="grDataPoint"></param>
        public void AddGrDataPoint( GrDataPoint grDataPoint )
        {
            if ( grDataPoint == null )
                throw new ArgumentNullException( "grDataPoint" );

            WastingCaloricCalculatorWithName wccwn = this._wccwns.FindWccwn( 
                grDataPoint.StationName, 
                true 
                );

            // 
            wccwn.AddGrDataPoint( grDataPoint );

            // grdataPoint 要求按照时间顺序依次加入
            //
            // 以站名称 和 时间区分
            //
            // 查找和grDataPoint同名的wcc, 如果没有则创建
            // 
            //      如果该grDataPoint能加入该wcc则加入
            //
            //      否则新建wcc并加入该grDataPoint
            //

        }

        #endregion //AddGrDataPoint

        #region CalcWccResultSet
        /// <summary>
        /// 计算耗热量并将结果集传回
        /// </summary>
        /// <returns></returns>
        public WccResultSet CalcWccResultSet()
        {
            WccResultSet wccrSet = new WccResultSet(); 
            for( int i=0; i<_wccwns.Count; i++ )
            {
                WastingCaloricCalculatorWithName wccwn = _wccwns[ i ];

                string stname = wccwn.StationName;
                WccResultsCollection wccrs = new WccResultsCollection( stname );

                WastingCaloricCalculatorsCollection wccs = wccwn.WastingCaloricCalculatorsCollection;
                for( int j=0; j<wccs.Count; j++ )
                {
                    WastingCaloricCalculator wcc = wccs[j];
                    int wc = wcc.Calc();
                    DateTime date = wcc.Date;

                    WccResult wccr = new WccResult( date, wc );
                    wccrs.Add( wccr );
                }

                wccrSet.Add( wccrs );
            }
            return wccrSet;
        }
        #endregion //CalcWccResultSet

        #endregion //Method
    }
    #endregion //WastingCaloricCalculatorOfDays
}
