using System;

namespace Communication
{
    #region WccResult
    /// <summary>
    /// WccResult 的摘要说明。
    /// </summary>
    public class WccResult
    {
        #region Members
        private DateTime _date;
        private int      _wastingCaloric;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public WccResult( DateTime date, int wastingCaloric )
        {
            _date = date.Date;
            _wastingCaloric = wastingCaloric;
        }
        #endregion //Constructor

        #region Properties

        #region WastingCaloric
        /// <summary>
        /// 
        /// </summary>
        public int WastingCaloric
        {
            get { return _wastingCaloric; }
        }
        #endregion //WastingCaloric

        #region Date
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get { return _date; }
        }
        #endregion //Date
        #endregion //Properties

        #region Method
        #endregion //Method
    }
    #endregion //WccResult
}
