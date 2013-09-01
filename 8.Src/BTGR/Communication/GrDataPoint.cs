using System;
using System.Collections;

namespace Communication
{
    #region GrDataPoint
    /// <summary>
    /// �����պ�����ʱʹ�õĹ���ʵʱ����
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
        /// �������ݵĲɼ�ʱ��
        /// </summary>
        public DateTime DateTime
        {
            get { return _dt; }
            set { _dt = value; }
        }
        #endregion //Dt

        #region OneSum
        /// <summary>
        /// һ���ۼ�����
        /// </summary>
        public int OneSum
        {
            get { return _oneSum; }
            set { _oneSum = value; }
        }
        #endregion //OneSum

        #region OneBackTemp
        /// <summary>
        /// һ�λ�ˮ�¶�
        /// </summary>
        public float OneBackTemp
        {
            get { return _oneBackTemp; }
            set { _oneBackTemp = value; }
        }
        #endregion //OneBackTemp

        #region OneGiveTemp
        /// <summary>
        /// һ�ι�ˮ�¶�
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
