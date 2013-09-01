using System;
using System.Collections;

namespace Communication
{
    #region GrDataPoint
    /// <summary>
    /// 计算日耗热量时使用的供热实时数据
    /// </summary>
    public class GrDataPoint
    {
        #region Members
        private float       _oneGiveTemp;
        private float       _oneBackTemp;
        private int         _oneSum;
        private DateTime    _dt;
        private string      _stationName;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="dateTime"></param>
        /// <param name="oneGiveTemp"></param>
        /// <param name="oneBackTemp"></param>
        /// <param name="oneSum"></param>
        public GrDataPoint(
            string stationName,
            DateTime dateTime,
            float oneGiveTemp,
            float oneBackTemp,
            int   oneSum
            )
        {
            this._stationName = stationName;
            this.DateTime = dateTime;
            this.OneGiveTemp = oneGiveTemp;
            this.OneBackTemp = oneBackTemp;
            this.OneSum = oneSum;
        }
        #endregion //Constructor

        #region Properties

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
        	get { return _stationName; }
        	set { _stationName = value; }
        }
        #endregion //StationName

        #region Dt
        /// <summary>
        /// 该条数据的采集时间
        /// </summary>
        public DateTime DateTime
        {
            get { return _dt; }
            set { _dt = value; }
        }
        #endregion //Dt

        #region OneSum
        /// <summary>
        /// 一次累计流量
        /// </summary>
        public int OneSum
        {
            get { return _oneSum; }
            set { _oneSum = value; }
        }
        #endregion //OneSum

        #region OneBackTemp
        /// <summary>
        /// 一次回水温度
        /// </summary>
        public float OneBackTemp
        {
            get { return _oneBackTemp; }
            set { _oneBackTemp = value; }
        }
        #endregion //OneBackTemp

        #region OneGiveTemp
        /// <summary>
        /// 一次供水温度
        /// </summary>
        public float OneGiveTemp
        {
            get { return _oneGiveTemp; }
            set { _oneGiveTemp = value; }
        }
        #endregion //OneGiveTemp
        #endregion //Properties

        #region Method
        #endregion //Method
    }
    #endregion //GrDataPoint
}
