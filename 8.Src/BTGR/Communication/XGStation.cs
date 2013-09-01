using System;
using CFW;

namespace Communication
{
    #region ...
//	/// <summary>
//	/// XGStation ��ժҪ˵����
//	/// </summary>
//	public class XGStation
//	{
//		public XGStation()
//		{
//			//
//			// TODO: �ڴ˴���ӹ��캯���߼�
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
        /// Ѳ��������������
        /// </summary>
        private DateTime _xgCtrlDate = DateTime.MinValue;
        /// <summary>
        /// Ѳ����������ʱ��
        /// </summary>
        private TimeSpan _xgCtrlTime = TimeSpan.MinValue;
        /// <summary>
        /// �ɼ�Ѳ��������ʱ��ļ����ʱ�䣬���ں�Ѳ��������ʱ����жԱ�
        /// </summary>
        private DateTime _dtCollXgCtrlTime = DateTime.MinValue;
        #endregion //Members

        #region Event
        /// <summary>
        /// ��XgCtrlDate���Է����ı��Ǵ������¼�
        /// </summary>
        public event EventHandler XgCtrlDateChanged;
        /// <summary>
        /// ��XgCtrlTime���Է����ı��Ǵ������¼�
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
        /// �ɼ�Ѳ������������ʱ��ļ����ʱ��
        /// </summary>
        public DateTime DtCollXgCtrlTime
        {
        	get { return _dtCollXgCtrlTime; }
        	set { _dtCollXgCtrlTime = value; }
        }
        #endregion //DtCollXgCtrlTime

        #region XgCtrlTime
        /// <summary>
        /// Ѳ������������ʱ��
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
        /// Ѳ����������������
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
