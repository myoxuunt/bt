using System; 
using System.Collections;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using System.IO;

namespace Communication
{
    public class SoapSerialize
    {
        string _filename = AppDomain.CurrentDomain.BaseDirectory +  "alul.xml";

        public void Serialize( object obj )
        {
            SoapFormatter aSoap = new SoapFormatter();
            FileStream fs = new FileStream(_filename, FileMode.Create );

            aSoap.Serialize (fs, obj);
            fs.Close();  
        }

        public object SoapDeserialize()
        {
            SoapFormatter aSoap = new SoapFormatter();
            FileStream fs = null;
            try
            {
                fs = new FileStream ( _filename, FileMode.Open);
            }
            catch(FileNotFoundException)
            {
//                MsgBox.Show( ex.ToString());
                return null;
            }
            object obj = aSoap.Deserialize (fs,null);   
            fs.Close();

            return obj;
        }
    }
	/// <summary>
	/// XGConfig ��ժҪ˵����
	/// </summary>
	public class XGConfig
	{
        #region Members
        /// <summary>
        /// Ĭ������ȴ�ʱ�䣬��λ����
        /// </summary>
        public const  int Default_xgCmdLatencyTime = 9000;
        public const  int Default_grCmdLatnecyTime = 9000;

        public static XGConfig Default = new XGConfig();

        private int     _xgCmdLatencyTime = XGConfig.Default_xgCmdLatencyTime;  
        private int     _grCmdLatnecyTime = XGConfig.Default_grCmdLatnecyTime;  

        // 2007.03.14 be disabled
        //
        private int     _clientAorB                 = 0;
        private string  _connectionString;

        private bool    _logCommFail                = true;
        private bool    _logCommIO                  = true;

        private bool    _showLogForm                = true;
        //private bool    _showFailForm               = true;

        private string  _collOSTStationName         = null;

        private int _commTaskSchedulerInterval      = 1000;

        private string  _serverIP;

        /// <summary>
        /// ���ȿ�����ʵʱ���ݲɼ�����(����)
        /// </summary>
        private int     _grRealDataCollCycle        = 6;    // 6 minute

        /// <summary>
        /// ��ȡѲ����������¼������(����)
        /// </summary>
        private int     _xgReadCountCycle           = 60 * 2;     // 2 hour
        
        private int     _listenPort                 = 9001;

        /// <summary>
        /// �Ƿ�����޸�ͨѶ���� app.MCS
        /// </summary>
        private bool    _modifyCommunicationSettings = false;

        private string  _alarmPopupWavFile = string.Empty;

        private bool    _isShowFontButton = false;


        public ALUL 
            a1gp = new ALUL(0.3F,0.7F),
            a1bp = new ALUL(0.3F,0.6F),
            a1gt = new ALUL(50F,90F),
            a1bt = new ALUL(35F,60F),
            a2gp = new ALUL(0.2F,0.7F),
            a2bp = new ALUL(0.2F,0.6F),
            a2gt = new ALUL(20F,60F),
            a2bt = new ALUL(20F,60F);

        private ArrayList alist = new ArrayList();

        public void deser()
        {
            object obj = new SoapSerialize().SoapDeserialize();
            if (obj != null )
            {
                ArrayList list = obj as ArrayList;
                if ( list != null )
                {
                    try
                    {
                        //todo:
                        this.a1gp =(ALUL) list[0];
                        a1bp=(ALUL)list[1];
                        a1gt=(ALUL)list[2];
                        a1bt=(ALUL)list[3];
                        a2gp =(ALUL) list[4];
                        a2bp =(ALUL) list[5];
                        a2gt =(ALUL) list[6];
                        a2bt =(ALUL) list[7];

                    }
                    catch(Exception ex )
                    {
                        MsgBox .Show(ex.ToString());
                    }
                }
            }
        }

        public void ser()
        {
            ArrayList list = new ArrayList();
            list.AddRange(new ALUL[]{a1gp, a1bp, a1gt, a1bt, a2gp, a2bp,a2gt, a2bt} );
            new SoapSerialize().Serialize( list );
        }

        #endregion //Members

        #region Constructor
        public XGConfig()
        {
            // this.deser();
        }
        #endregion //Constructor

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsShowFontButton
        {
            get { return _isShowFontButton; }
            set { _isShowFontButton = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string AlarmPopupWavFile
        {
            get { return _alarmPopupWavFile; }
            set { _alarmPopupWavFile = value; }
        }
        /// <summary>
        /// ��ȡ������һ��ֵ��ָʾ�Ƿ�����޸�GprsStationItem�����е��޸�ͨѶ����
        /// </summary>
        public bool IsEnableMCS
        {
            get { return _modifyCommunicationSettings; }
            set { _modifyCommunicationSettings = value; }
        }
        /// <summary>
        /// ���ȿ�����ʵʱ���ݲɼ�����(����)
        /// </summary>
        public int GrRealDataCollCycle
        {
            get { return _grRealDataCollCycle; }
            set { _grRealDataCollCycle = value; }
        }

        /// <summary>
        /// ��ȡѲ����������¼������(����)
        /// </summary>
        public int XgReadCountCycle
        {
            get { return _xgReadCountCycle ; }
            set { _xgReadCountCycle = value; }
        }

        /// <summary>
        /// ��ȡ�����ã��ɼ������¶ȵĿ��������ڵ�վ������
        /// </summary>
        public string OstCollStationName
        {
            get { return _collOSTStationName; }
            set { _collOSTStationName = value; }
        }

        // 2007.02.28 replace with ShowLogForm
//
//        public bool ShowFailForm
//        {
//            get { return _showFailForm; }
//            set { _showFailForm = value; }
//        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; } 
        }

        public bool LogCommIO
        {
            get { return _logCommIO; }
            set { _logCommIO = value; }
        }

        public bool ShowLogForm
        {
            get { return _showLogForm; }
            set { _showLogForm = value; }
        }
        public int ListenPort
        {
            get { return _listenPort; }
            set { _listenPort = value; }
        }
        // 2007.02.11
        //
//        private string _commPortSettings = "9600,n,8,1";
//        public string CommPortSettings
//        {
//            get { return _commPortSettings; }
//            set { _commPortSettings = value; }
//        }

       
        /// <summary>
        /// TaskScheduler������ɨ������
        /// </summary>
        public int TaskSchedulerInterval
        {
            get { return _commTaskSchedulerInterval; }
            set { _commTaskSchedulerInterval = value; }
        }

       
    
        public int ClientAorB
        {
            get { return _clientAorB; }
            set { _clientAorB = value; }
        }

        public int XgCmdLatencyTime
        {
            get { return _xgCmdLatencyTime; }
            set { _xgCmdLatencyTime = value; }
        }

        public int GrCmdLatencyTime
        {
            get { return _grCmdLatnecyTime; }
            set { _grCmdLatnecyTime = value; }
        }

        /// <summary>
        /// �Ƿ��¼ͨѶʧ�ܵ�����
        /// </summary>
        public bool LogCommFail
        {
            get { return _logCommFail; }
            set {_logCommFail = value; }
        }

        public string ServerIP 
        {
            get { return this._serverIP; }
            set { this._serverIP = value; }
        }
        #endregion //Properties
	}


    [Serializable]
    public struct ALUL
    {
        public bool Enabled;
        public float L;
        public float U;

        public ALUL( float l, float u, bool e )
        {
            if( l > u ) 
                throw new ArgumentException("l>u");
            L = l;
            U = u;
            Enabled = e;
        }

        public ALUL ( float l, float u )
            : this ( l,u,true)
        {
        }
    }
}
