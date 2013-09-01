#define USEWINSOCK
#if USEWINSOCK

using System;
using MSWinsockLib;
using System.Runtime.Serialization;
//using System.Timers;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using Infragistics.Shared;
namespace CFW
{
    #region ILog
    public interface ILog
    {
        void AddLog ( string s );
    }
    #endregion //Ilog

    #region Winsock listen
    /// <summary>
    /// 
    /// </summary>
    public class WSListen
    {
        static public ILog _log = null;

//        static public Winsock[] s_sckarray = new Winsock[40];
//        static public CommPortProxy[] s_cppsckarray = new CommPortProxy[40];

        

        public Winsock _winsock = new WinsockClass();
//        public int _idx=44;
        private CommPortProxy _lastConnection = null;

        private object _lock = new object();

        public event System.EventHandler NewConnection = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listenPort"></param>
        public WSListen(int listenPort)
        {
            _winsock.ConnectionRequest +=new DMSWinsockControlEvents_ConnectionRequestEventHandler(_winsock_ConnectionRequest);
            _winsock.Protocol = ProtocolConstants.sckTCPProtocol;
            //_winsock.LocalPort = 9001;
            _winsock.LocalPort = listenPort;  //监听端口号为9001
            //_winsock.Listen();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Listen()
        {
            if ( ! IsListening )
                _winsock.Listen();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsListening
        {
            get { return (StateConstants)_winsock.State == StateConstants.sckListening; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            _winsock.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public CommPortProxy LastConnection
        {
            get { return _lastConnection; }
        }

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="requestID"></param>
        private void _winsock_ConnectionRequest(int requestID)
        {
            lock( _lock )
            {
                try
                {
                    Winsock sck = new  WinsockClass();
                    sck.Accept( requestID );
                    //s_sckarray[ _idx ] = sck;
            
                    CommPortProxy cppsck = new CommPortProxy( sck );
                    //s_cppsckarray[ _idx ] = cppsck;
                    //_idx++;
                    //MessageBox.Show( cppsck.ToString() );
            
                    if ( _log != null )
                        _log.AddLog( sck.RemoteHostIP );
                    _lastConnection = cppsck; 

                    if ( NewConnection != null )
                    {
                        NewConnection( this, System.EventArgs.Empty );
                    }
                }
                catch( Exception ex )
                {
                    Debug.Fail ( "At _winsock_ConnectionRequest",  ex.ToString());
                }
            }
        }
        #region ...
//        public void SendAll()
//        {
//            for ( int i=0; i<30; i++)
//            {
//                CommPortProxy cpp = s_cppsckarray[i];
//                if (  cpp != null )
//                {
//                    if ((StateConstants)cpp.Winsock.State == StateConstants.sckConnected )
//                    {
//                        cpp.Send( getcmd() , 9000 );
//                    }
//                }
//            }
//        }
//
//        private byte[] getcmd()
//        {
//            return new byte[] {0x21 ,0x58 ,0x44 ,0x00 ,0xA0 ,0x1E ,0x00 ,0xDE ,0x97 };
//        }
        #endregion 
    }
    #endregion //Winsock listen

    #region CommPortProxy with winsock
    /// <summary>
    /// 串口代理 use winsock
    /// </summary>
    /// <remarks>
    /// serialize data:
    /// 1. commport
    /// 2. settings
    /// </remarks>

    [Serializable]
    public class CommPortProxy //: ISerializable
        : Infragistics.Shared.SubObjectBase 
    {

        #region CommPortProxyState
        /// <summary>
        /// 
        /// </summary>
        private enum CommPortProxyState
        {
            /// <summary> 无动作 </summary>
            None = 0,

            /// <summary> 正在接收返回数据 </summary>
            Receiving,
        }
        #endregion //CommPortProxyState

        #region Member Variables
        private const int       MIN_LATENCY_TIME = 15;

        private const int       AUTO_REPORT_DATA_CAPACITY   = 10 * 1024;    // 10K


        private System.Windows.Forms.Timer 
            m_Timer      = new System.Windows.Forms.Timer();

        private CommPortProxyState      m_State         = CommPortProxyState.None;
        private byte[]                  m_ReceivedData  = null;
        
        private bool                    _IsEnableAutoReport;
        private byte[]                  _autoReportDatas = null;

        // on receive time fire the event
        //
        public event System.EventHandler ReceiveComplete;

        // 2007.01.10 Added auto report received data
        // if reveive data from commport when listening, fire the event.
        //
        public event System.EventHandler ReceiveAutoReport;

        // 2007.03.05 Added winsock error event
        //
        public event WinsockErrorHandler WinsockError;



        private Winsock _winsock; 
        
        // _type = vbArray + vbByte, use at winsock dataArrival event.
        // vbArray = 0x2000
        // vbByte  = 0x11
        private int _type = 0x2000 + 0x11;

        private DateTime          _createTime;

       

        
        #endregion //Member Variables

        #region Constructors

        public CommPortProxy ( Winsock sck )
        {
            if ( sck == null )
                throw new NullReferenceException("CommPortProxy ( Winsock sck ), sck == null");

            if ( (StateConstants)sck.State != StateConstants.sckConnected )
                throw new ArgumentException ("sck state != connected" );

            _winsock = sck;
            _winsock.DataArrival += new DMSWinsockControlEvents_DataArrivalEventHandler(_winsock_DataArrival);
            _winsock.Error += new DMSWinsockControlEvents_ErrorEventHandler(_winsock_Error);

            DMSWinsockControlEvents_Event winsockEvent = (DMSWinsockControlEvents_Event) _winsock;
            winsockEvent.Close += new DMSWinsockControlEvents_CloseEventHandler(_winsock_Close);

            _createTime = DateTime.Now;

            m_Timer.Tick += new EventHandler(m_Timer_Tick);
        }

        /// <summary>
        /// 处理数据winsock到达事件
        /// </summary>
        /// <param name="bytesTotal"></param>
        private void _winsock_DataArrival(int bytesTotal)
        {
            try
            {
                //byte[] bs = new byte[bytesTotal];
                object bs = new byte[bytesTotal];
                _winsock.GetData( ref bs, _type, bytesTotal );

                // 2007.03.05 ?? Replace with a user define DataArrival event
                //
                //MessageBox.Show
                if ( WSListen._log != null )
                {
                    WSListen._log.AddLog( "from :" + _winsock.RemoteHostIP );
                    WSListen._log.AddLog (Utilities.CT.BytesToString( (byte[])bs ) );
                }

                if( this.IsReceiving )
                {
                    m_ReceivedData = MergeBytes ( m_ReceivedData, (byte[])bs );
                }
                else
                {
                    if ( _IsEnableAutoReport )
                    {
                        _autoReportDatas = MergeBytes( _autoReportDatas, (byte[])bs );
                        if ( this.ReceiveAutoReport != null )
                        {
                            System.EventHandler temp = this.ReceiveAutoReport ;
                            temp( this, EventArgs.Empty );
                        }
                    }
                }
            }
            catch (Exception ex )
            {
                Debug.Fail( "At _winsock_DataArrival", ex.ToString());
            }
        }

        //=========================================================
        public CommPortProxy(short commPort, string settings)
        {
            //initialize( commPort, settings);
        }

        public CommPortProxy() //: this (DEFAULT_COMMPORT, DEFAULT_SETTINGS)
        {
        }

        protected CommPortProxy( SerializationInfo info, StreamingContext context )
        {
            //short   commPort = DEFAULT_COMMPORT;
            //string  settings = DEFAULT_SETTINGS;
            //
            //foreach (SerializationEntry entry in info)
            //{
            //    switch (entry.Name)
            //    {
            //        case "CommPort": 
            //            commPort = Convert.ToInt16( entry.Value );
            //            break;
            //
            //        case "Settings":
            //            settings = (string)entry.Value;
            //            break;
            //
            //        default:
            //            throw new SerializationException(entry.Name + " " + entry.Value);
            //    }
            //}

            //initialize( commPort, settings );
        }

        #endregion //Constructor

        #region Method
        

        private void OnReceiveEvent()
        {
        }

        private byte[] MergeBytes( byte[] bs1, byte[] bs2 )
        {
            if ( bs1 == null && bs2 == null )
                return null;

            int len1 = bs1 == null ? 0 : bs1.Length;
            int len2 = bs2 == null ? 0 : bs2.Length;

            byte[] bsr = new byte[len1 + len2];
            if ( bs1 != null )
                bs1.CopyTo( bsr, 0 );
            if ( bs2 != null )
                bs2.CopyTo( bsr, len1 );
            
            return bsr;

        }
        //#region /
        ///// <summary>
        ///// 
        ///// </summary>
        //private void RegisterOnCommEvent()
        //{
        //    this._autoReportDatas = null;
        //    // 2007.01.26 Removed 
        //    //
        //    //m_ComPort.RThreshold = 1;
        //    //m_ComPort.OnComm += new DMSCommEvents_OnCommEventHandler(m_ComPort_OnComm);
        //}
        //
        //private void UnregisterOnCommEvent()
        //{
        //    // 2007.01.26 Removed
        //    //
        //    //m_ComPort.RThreshold = 0;
        //    //m_ComPort.OnComm -= new DMSCommEvents_OnCommEventHandler(m_ComPort_OnComm);
        //}
//#endregion 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private byte[] getWinsockData()
        {
            object data = new byte[ _winsock.BytesReceived ];
            _winsock.GetData( ref data, _type, _winsock.BytesReceived );
            return (byte[])data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteCommand"></param>
        /// <param name="latencyTime"></param>
        public void Send(byte[] byteCommand, int latencyTime)
        {
            // 2006.11.03 Added byteCommand null check
            //
            if (byteCommand == null)
            {
                throw new ArgumentNullException ("byteCommand");
            }

            // 2006.09.15 Added 
            // 最小等待时间 15 毫秒
            //Debug.Assert (latencyTime >= 15, "latencyTime must >= 15 ");
            if (latencyTime < MIN_LATENCY_TIME)
                throw new ArgumentOutOfRangeException("latencyTime", latencyTime, SR.GetString("LE_LatencyTime_Min"));

            if (m_State != CommPortProxyState.None)
                throw new Exception(SR.GetString("LE_SendData"));

            if ( (StateConstants)_winsock.State == StateConstants.sckConnected )
            {
                m_State = CommPortProxyState.Receiving;

                // 发送前清空接收、发送缓冲区
                if ( _winsock.BytesReceived > 0 )
                {
                    object data = new byte[ _winsock.BytesReceived ];
                    _winsock.GetData( ref data, _type, _winsock.BytesReceived );
                }

                _winsock.SendData( byteCommand );

                m_Timer.Interval = latencyTime;
                m_Timer.Start();

                // for debug
                //
                WSListen._log.AddLog ( this.RemoteHostIP + " Timer start" );
            }
        }

        /// <summary>
        /// 接收到时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_Timer_Tick(object sender, EventArgs e)
        {
            m_Timer.Stop();
            
            if( _winsock.BytesReceived > 0 )
            {
                byte[] bs = new byte[ _winsock.BytesReceived ];
                object obj = bs;
                _winsock.GetData( ref obj, _type, _winsock.BytesReceived );
                //m_ReceivedData = (byte[]) bs.Clone();
                m_ReceivedData = MergeBytes( m_ReceivedData, bs );
            }

            if ( ReceiveComplete != null )
            {
                ReceiveComplete( this, EventArgs.Empty );
            }
            m_State = CommPortProxyState.None;
            
            // for debug
            //
            WSListen._log.AddLog( RemoteHostIP + " timer stop" );
        }

        //??DEL
        public void Open()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close ()
        {
            _winsock.Close();
        }
        

        #endregion //Method

        #region Properties

        #region Winsock Properties
        
        /// <summary>
        /// 
        /// </summary>
        public string RemoteHostIP
        {
            get { return _winsock.RemoteHostIP; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int RemotePort
        {
            get { return _winsock.RemotePort; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string RemoteHost
        {
            get { return _winsock.RemoteHost; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ProtocolConstants Protocol
        {
            get { return _winsock.Protocol;}
        }

        /// <summary>
        /// 
        /// </summary>
        public string LocalHostName
        {
            get { return _winsock.LocalHostName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string LocalHostIP
        {
            get { return _winsock.LocalIP; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LocalPort
        {
            get { return _winsock.LocalPort;}
        }

        /// <summary>
        /// 
        /// </summary>
        public short State
        {
            get { return _winsock.State; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsConnected
        {
            get 
            {
                return (StateConstants)_winsock.State == StateConstants.sckConnected;
            }
        }

        #endregion //Winsock Properties
        
        // 2007.01.10 Added Return auto report data, and clear history auto report data.
        //
        /// <summary>
        /// 
        /// </summary>
        public byte[] AutoReportData
        {
            get 
            {
                byte[] bs = _autoReportDatas;
                _autoReportDatas = null;
                return bs;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] ReceiveData
        {
            get 
            {
                //Debug.WriteLine ("ReceiveData: " + m_ReceivedData.Length);
                byte[] bs = m_ReceivedData;
                m_ReceivedData = null;
                return bs; 
            }
        }

        

        //??DEL
        /// <summary>
        /// 
        /// </summary>
        public short ComPort
        {
            get { return 0; }
            set { ; }
        }

        /// <summary>
        /// 获取该cpp的创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
        }

        public string RemoteIP
        {
            get { return _winsock.RemoteHostIP; }
        }

        //public string Settings
        //{
        //    get { return m_ComPort.Settings; }
        //    set { m_ComPort.Settings = value; }
        //}
            
        // 2007.01.10 Added
        //
        public bool IsEnableAutoReport
        {
            get { return _IsEnableAutoReport; }
            set
            {
                SetIsEnableAutoReport ( value );
            }
        }
        // 2007.01.26 Added
        //
        //??DEL
        public int RThreshold
        {
            get { return 0; }
            set 
            {
                //if ( value >= 0 && value <= 1024 )
                //    m_ComPort.RThreshold = (short) value; 
                //else
                //    throw new ArgumentOutOfRangeException( "RThreshold", "Must in 0 - 1024" );
            }
        }

        private void SetIsEnableAutoReport( bool val )
        {
            if ( val == _IsEnableAutoReport )
                return ;

            _IsEnableAutoReport = val; 
            //if (_IsEnableAutoReport)
            //{
            //    RegisterOnCommEvent();
            //}
            //else
            //{
            //    UnregisterOnCommEvent();
            //}
        }

        public Winsock Winsock
        {
            get { return _winsock; }
        }

        /// <summary>
        /// 串口是否已打开
        /// //??DEL
        /// </summary>
        public bool IsOpen
        {
            get { return true; }
        }

        /// <summary>
        /// 是否正在接收数据
        /// </summary>
        public bool IsReceiving
        {
            get { return this.m_State == CommPortProxyState.Receiving ; }
        }
        #endregion //Properties

        //#region ISerializable 成员
        //
        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    // TODO:  添加 Station.GetObjectData 实现
        //    info.AddValue ("CommPort", this.m_ComPort.CommPort);
        //    info.AddValue ("Settings", this.m_ComPort.Settings);
        //}
        //
        //#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Description"></param>
        /// <param name="Scode"></param>
        /// <param name="Source"></param>
        /// <param name="HelpFile"></param>
        /// <param name="HelpContext"></param>
        /// <param name="CancelDisplay"></param>
        private void _winsock_Error(short Number, ref string Description, int Scode, string Source, string HelpFile, 
            int HelpContext, ref bool CancelDisplay)
        {
            try
            {
                string s = string.Format(
                    "Number: {0}\r\nDescription: {1}\r\nScode: {2}\r\nSource: {3}\r\nHelpFile: {4}\r\nHelpContext: {5}\r\nCancelDisplay: {6}\r\n",
                    Number, Description, Scode, Source, HelpFile, HelpContext, CancelDisplay );

                // 2007.03.05 Modify 不能断言失败，会中断程序执行
                //
                //Debug.Fail ( s );
                OnWinsockError ( s );

                // 2007-12-12 added
                //
                this.Close();
            }
            catch ( Exception ex )          
            {
                Debug.Fail ( "At _winsock_Error", ex.ToString() );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMsg"></param>
        private void OnWinsockError( string errorMsg )
        {
            if ( this.WinsockError != null )
            {
                WinsockErrorHandler temp = WinsockError;
                WinsockErrorArgs args = new WinsockErrorArgs( errorMsg );
                temp( this, args );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void _winsock_Close()
        {
            this.Close();
        }
    }
    #endregion //CommPortProxy with winsock

    #region Receive event delegate
    public delegate  void ReceiveTimeOutEventHandler( object sender, ReceiveTimeOutEventArgs args );
    public delegate  void ReceiveARDHandler( object sender, ReceiveARDEventArgs args );
    public delegate  void CppsWinsockErrorEventHandler( object sender, CppsWinsockErrorArgs args );
    
    // 2007.03.05 Added winsockerror event handler and winsockErrorArgs
    //
    public delegate  void WinsockErrorHandler ( object sender, WinsockErrorArgs args );
    #endregion //Receive event delegate

    #region CppsWinsockErrorArgs
    /// <summary>
    /// 
    /// </summary>
    public class CppsWinsockErrorArgs : EventArgs 
    {
        private CommPortProxy _cpp;
        private string _errorMsg;

        public CppsWinsockErrorArgs ( CommPortProxy cpp, string errorMsg )
        {
            if( cpp == null )
                throw new ArgumentNullException( "cpp" );

            _cpp = cpp;
            _errorMsg = errorMsg;
        }

        public CommPortProxy Cpp
        {
            get { return _cpp; }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
        }
    }
    #endregion //CppsWinsockErrorArgs

    #region WinsockErrorArgs
    /// <summary>
    /// 
    /// </summary>
    public class WinsockErrorArgs : EventArgs
    {
        private string _errorMsg;

        public string ErrorMessage
        {
            get { return _errorMsg; }
        }

        public WinsockErrorArgs ( string errorMsg )
        {
            if ( errorMsg == null )
                errorMsg = string.Empty;
            _errorMsg = errorMsg ;
        }
    }
    #endregion //WinsockErrorArgs

    #region ReceiveTimeOutEventArgs 
    /// <summary>
    /// TimeOut
    /// </summary>
    public class ReceiveTimeOutEventArgs : EventArgs
    {
        private CommPortProxy _cpp ;
        private byte[] _datas;

        public ReceiveTimeOutEventArgs( CommPortProxy cpp, byte[] datas )
        {
            if ( cpp == null )
                throw new ArgumentNullException("cpp");
            _cpp = cpp;
            if ( datas == null )
                _datas = new byte[0];
            else
            {
                _datas = (byte[]) datas.Clone();
            }
        }

        public CommPortProxy Source
        {
            get { return _cpp; }
        }

        public byte[] Datas
        {
            get { return _datas; }
        }
    }
    #endregion //ReceiveTimeOutEventArgs 

    #region ReceiveARDEventArgs 
    /// <summary>
    /// Receive Auto Report Data Event args
    /// </summary>
    public class ReceiveARDEventArgs : EventArgs
    {
        private CommPortProxy _cpp ;
        private byte[] _datas;

        public ReceiveARDEventArgs( CommPortProxy cpp, byte[] datas )
        {
            if ( cpp == null )
                throw new ArgumentNullException("cpp");
            _cpp = cpp;
            if ( datas == null )
                _datas = new byte[0];
            else
            {
                _datas = (byte[]) datas.Clone();
            }
        }

        public CommPortProxy Source
        {
            get { return _cpp; }
        }

        public byte[] ARDDatas
        {
            get { return _datas; }
        }
    }
    #endregion //ReceiveARDEventArgs 

    #region CommPortProxysCollection 
    /// <summary>
    /// 
    /// </summary>
    public class CommPortProxysCollection 
        : Infragistics.Shared.SubObjectsCollectionBase 
    {


        public void RemoveNotConn()
        {
            for ( int i=0; i< this.List.Count; i++ )
            {
                CommPortProxy cpp = List[i] as CommPortProxy;
                if ( cpp.IsConnected == false )
                {
                    this.RemoveAt( i );
                }
            }
        }

        public event ReceiveTimeOutEventHandler ReceiveTimeOutEvent = null;
        public event ReceiveARDHandler          ReceiveARDEvent = null;
        public event CppsWinsockErrorEventHandler   CppsWinsockErrorEvent = null;
        
        /// <summary>
        /// 
        /// </summary>
        protected override int InitialCapacity
        {
            get { return 50; }      // 33 * 1.5 
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpp"></param>
        public void Add( CommPortProxy cpp )
        {
            if ( cpp == null )
                throw new ArgumentNullException ("cpp");
            this.InternalAdd( cpp );
            
            cpp.ReceiveAutoReport +=new EventHandler( cpp_ReceiveAutoReport );
            cpp.ReceiveComplete +=new EventHandler( cpp_ReceiveComplete );
            cpp.WinsockError += new WinsockErrorHandler(cpp_WinsockError);
            cpp.IsEnableAutoReport = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public CommPortProxy this[ int index ]
        {
            get 
            {
                return (CommPortProxy)this.GetItem( index );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt( int index )
        {
            CommPortProxy cpp =(CommPortProxy) GetItem( index );
            //TODO: unreg event
            //
            //if ( cpp.ReceiveAutoReport != null )
            cpp.ReceiveAutoReport -= new EventHandler( cpp_ReceiveAutoReport );
            //if ( cpp.ReceiveComplete != null )
            cpp.ReceiveComplete -= new EventHandler( cpp_ReceiveComplete );
            //if ( cpp.WinsockError != null )
            cpp.WinsockError -= new WinsockErrorHandler ( cpp_WinsockError );

            this.InternalRemove( index );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpp"></param>
        public void Remove( CommPortProxy cpp )
        {
            cpp.ReceiveAutoReport -= new EventHandler( cpp_ReceiveAutoReport );
            cpp.ReceiveComplete -= new EventHandler( cpp_ReceiveComplete );
            cpp.WinsockError -= new WinsockErrorHandler ( cpp_WinsockError );
            this.InternalRemove( cpp );
        }

        /// <summary>
        /// ARD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpp_ReceiveAutoReport(object sender, EventArgs e)
        {
            CommPortProxy cpp = (CommPortProxy) sender;
            if ( ReceiveARDEvent != null )
            {
                ReceiveARDEventArgs args = new ReceiveARDEventArgs( cpp, cpp.AutoReportData );
                //ReceiveARDEvent( this, args );
                ReceiveARDHandler temp = ReceiveARDEvent;
                temp( this, args );
            }
        }

        /// <summary>
        /// TimeOut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cpp_ReceiveComplete(object sender, EventArgs e)
        {
            CommPortProxy cpp = (CommPortProxy) sender;
            if ( ReceiveTimeOutEvent != null )
            {
                ReceiveTimeOutEventArgs args = new ReceiveTimeOutEventArgs ( cpp, cpp.ReceiveData );

                ReceiveTimeOutEventHandler temp = ReceiveTimeOutEvent ;
                temp ( this, args );
            }
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void cpp_WinsockError(object sender, WinsockErrorArgs args)
        {
            CommPortProxy cpp = (CommPortProxy) sender;
            if( this.CppsWinsockErrorEvent != null )
            {
                CppsWinsockErrorArgs e = new CppsWinsockErrorArgs( cpp, args.ErrorMessage );
                CppsWinsockErrorEvent( this, e );
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="remoteIP"></param>
		/// <returns></returns>
		public CommPortProxy GetCommPortProxy( string remoteIP )
		{
            foreach ( CommPortProxy c in this )
            {
                if ( c.RemoteHostIP == remoteIP &&
                    c.IsConnected )
                    return c;
            }
            return null;
		}
		/// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        public bool IsConnected( string remoteIP )
        {
//            CommPortProxysCollection  cpps = Singles.S.TaskScheduler.CppsCollection;
            foreach ( CommPortProxy c in this )
            {
                if ( c.RemoteHostIP == remoteIP &&
                    c.IsConnected )
                    return true;
            }
            return false;
        }
    }
    #endregion //CommPortProxysCollection
}

#endif