using System;
using CFW;

namespace Communication
{
    #region ...
//	/// <summary>
//	/// XGStation 的摘要说明。
//	/// </summary>
//	public class XGStation
//	{
//		public XGStation()
//		{
//			//
//			// TODO: 在此处添加构造函数逻辑
//			//
//		}
//	}
    #endregion //...

    #region XGStation
    /// <summary>
    /// XGStation
    /// </summary>
    public class XGStation : CFW.Station 
    {
        #region Members
        private string _serverIP = string.Empty;

        // 2007-11-2 11:25:01 Added XgController date and time filed
        //
        /// <summary>
        /// 巡更控制器的日期
        /// </summary>
        private DateTime _xgCtrlDate = DateTime.MinValue;
        /// <summary>
        /// 巡更控制器的时间
        /// </summary>
        private TimeSpan _xgCtrlTime = TimeSpan.MinValue;
        /// <summary>
        /// 采集巡更控制器时间的计算机时间，用于和巡更控制器时间进行对比
        /// </summary>
        private DateTime _dtCollXgCtrlTime = DateTime.MinValue;
        #endregion //Members

        #region Event
        /// <summary>
        /// 当XgCtrlDate属性发生改变是触发此事件
        /// </summary>
        public event EventHandler XgCtrlDateChanged;
        /// <summary>
        /// 当XgCtrlTime属性发生改变是触发此事件
        /// </summary>
        public event EventHandler XgCtrlTimeChanged;
        #endregion //Event

        #region XGStation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="address"></param>
        public XGStation(string name,  string ip, int address ) 
            : base(name, ip, address)
        {
        }
        #endregion //XGStation

        #region Properties

        #region DtCollXgCtrlTime
        /// <summary>
        /// 采集巡更控制器本地时间的计算机时间
        /// </summary>
        public DateTime DtCollXgCtrlTime
        {
        	get { return _dtCollXgCtrlTime; }
        	set { _dtCollXgCtrlTime = value; }
        }
        #endregion //DtCollXgCtrlTime

        #region XgCtrlTime
        /// <summary>
        /// 巡更控制器本地时间
        /// </summary>
        public TimeSpan XgCtrlTime
        {
        	get { return _xgCtrlTime; }
        	set 
            {
                _xgCtrlTime = value; 
                if( XgCtrlTimeChanged != null )
                    XgCtrlTimeChanged ( this, EventArgs.Empty );
            }
        }
        #endregion //XgCtrlTime

        #region XgCtrlDate
        /// <summary>
        /// 巡更控制器本地日期
        /// </summary>
        public DateTime XgCtrlDate
        {
        	get { return _xgCtrlDate; }
        	set 
            { 
                _xgCtrlDate = value; 
                if( XgCtrlDateChanged != null )
                    XgCtrlDateChanged( this, EventArgs.Empty );
            }
        }
        #endregion //XgCtrlDate

        #region ServerIP
        /// <summary>
        /// 
        /// </summary>
        public string ServerIP 
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }
        #endregion //ServerIP

        #region Logs
        /// <summary>
        /// 
        /// </summary>
        public CFW.OperationLogsCollection Logs
        {
            get { return base.OperationLogs; }
        }
        #endregion //Logs
        #endregion //Properties
    }
    #endregion // XGStation

}
