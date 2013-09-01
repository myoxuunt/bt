using System;
using System.Data;
using System.Diagnostics;
using CFW;
using System.Configuration;
using Communication.GRCtrl;
using btGRMain;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Communication
{
    /// <summary>
    /// MainClass program entry 
    /// </summary>
    public class MainClass
    {
        #region Construct
        public MainClass ()
        {
//            try
//            {
                if ( Utilities.Diagnostics.HasPreInstance() )
                {
                    MsgBox.Show ( GT.TEXT_PROGRAM_RUNNING, 
                        GT.TEXT_TIP,
                        System.Windows.Forms.MessageBoxIcon.Exclamation );

                    return;
                }

                if ( InitialGlobal() == false )
                    return ;


                XGDB.Resolve();
                if ( XGConfig.Default.ShowLogForm )
                    frmLogs.Default.Show();
                btGRMain.frmMain fMain = new btGRMain.frmMain();
                fMain.UIEventHandler += new UICOMM.BTGRUIEventHandler( UIEventProcessor.Default.Process );
                CollStateDisplay collStateDis = new CollStateDisplay( fMain.GprsCollStateSbr );
                Singles.S.CollStateDisPlay = collStateDis;

                // test entry point
                //
                new Test.T(); 
                System.Windows.Forms.Application.Run( fMain );
        
//            }
//            catch(Exception ex )
//            {
//                MessageBox.Show(ex.ToString());
//            }
        }
           
        #endregion //Construct

        #region ReadConfigFile
        private static void ReadConfigFile()
        {
            // TODO: try
            //
            System.Collections.Specialized.NameValueCollection nvc = ConfigurationSettings.AppSettings;
            string conn             = nvc["ConnectionString"];
            //int client              = Convert.ToInt32( nvc["Client"] );
            int client = 0;
            int latencyTime         = Convert.ToInt32( nvc["LatencyTime"]);
            bool logCommFail        = Convert.ToBoolean( nvc["LogCommFail"] );
            bool showLogForm        = Convert.ToBoolean( nvc["ShowLogForm"] );
            bool logCommIO          = Convert.ToBoolean( nvc["LogCommIO"] );
            string collOSTStationName = nvc["GrOSTCollStName"];
            int grRealdataCollCycle = Convert.ToInt32( nvc["GrRDCycle"] );
            // 2007.03.12 Added
            //
            int xgReadCountCycle    = Convert.ToInt32( nvc["XgRCCycle"] );
            int listenPort          = Convert.ToInt32( nvc["ListenPort"] );
            string serverIP         = nvc["ServerIP"];

            //Modify Communication Settings
            bool isEnableMcs        = Convert.ToBoolean( nvc["MCS"] );

            // 2007.03.30 Added
            //
            string alarmWavFile     = nvc["AlarmWaveFile"];

            //最小采集周期 10 分钟
            //if (grRealdataCollCycle <=10)
            //    grRealdataCollCycle = 10;
            XGConfig.Default.ConnectionString = conn ;
            XGConfig.Default.ClientAorB = client;
            XGConfig.Default.XgCmdLatencyTime = latencyTime;
            XGConfig.Default.GrCmdLatencyTime = latencyTime;
            XGConfig.Default.LogCommFail = logCommFail;
            XGConfig.Default.ShowLogForm = showLogForm;
            XGConfig.Default.GrRealDataCollCycle = grRealdataCollCycle ;
            XGConfig.Default.OstCollStationName = collOSTStationName;
            //GRCtrl.GRConfig.s_default.LatencyTime = XGConfig.Default.XgCmdLatencyTime;
            XGConfig.Default.ListenPort = listenPort;
            XGConfig.Default.ServerIP = serverIP;
            XGConfig.Default.IsEnableMCS = isEnableMcs;

            XGConfig.Default.AlarmPopupWavFile = alarmWavFile;

        }
        #endregion //ReadConfigFile

        #region AddTasks
        static private void AddTasks( TasksCollection dest, TasksCollection src )
        {
            ArgumentChecker.CheckNotNull ( dest );
            ArgumentChecker.CheckNotNull ( src );
            for ( int i=0; i<src.Count; i++)
            {
                Task t = src[i];
                dest.Add( t );
            }
        }
        #endregion //AddTasks

        #region ResolveGRRealDataTaskFromDB
        /// <summary>
        /// 解析采集供热实时数据命令, 
        /// parse xgdata read
        /// </summary>
        /// <returns></returns>
        private static TasksCollection  ResolveGRRealDataTaskFromDB()
        {
            string FailMsg = "Fail list:\r\n";
            //TODO: ResolveGRRealDataTaskFromDB
            //
            // 2007.03.10 Modify not use client flag, use serverIP diff local or remote gprs module, 
            //
            //            string sql = string.Format(
            //                "select * from v_gprs_gr_xg where client = {0}", 
            //                XGConfig.Default.ClientAorB  );
            string sql = "select * from v_gprs_gr_xg";

            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            TasksCollection tasks = new TasksCollection();

            foreach( DataRow r in tbl.Rows )
            {
                string name     = r["name"].ToString();
                int grAddr      = int.Parse( r["gr_address"].ToString() );
                int xgAddr      = int.Parse( r["xg_address"].ToString() );

                string ip       = r["ip"].ToString();
                string serverIP = r["serverIP"].ToString();
                string team     = r["team"].ToString().Trim();

                //GRStation grst = new GRStation(name, grAddr, ip);
                GRStation grst = CreateGrStation( name, grAddr, ip, team );
                grst.ServerIP = serverIP;

                if ( grst != null )
                {
                    // 2007.03.07 Added grstation to singles.grstationsCollection
                    //
                    Singles.S.GRStsCollection.Add( grst );

                    // 2007.03.01 Added gtstation last grRealdata
                    //
                    if ( Singles.S.GRStRds == null )
                        Singles.S.GRStRds = new GRStationLastRealDatasCollection();

                    // create and add a new grstation last read data object to Singles.GRStRds
                    //
                    GRStationLastRealData grstLastRd = new GRStationLastRealData( grst );
                    
                    Singles.S.GRStRds.Add( grstLastRd );

                    // 2007.03.10 Added check grstation(gprsstation).serverIP is the localhost ip
                    //
                    if ( serverIP == XGConfig.Default.ServerIP )
                    {
                        // create a new grrealdata task for grStation  
                        //
                        GRRealDataCommand cmd = new GRRealDataCommand( grst );
                        TimeSpan timeSp = new TimeSpan(0,0,XGConfig.Default.GrRealDataCollCycle,0,0 );
                        CycleTaskStrategy strategy = new CycleTaskStrategy( timeSp );
                        Task t = new Task( cmd, strategy );
                        tasks.Add( t );
                    }
                }
                else
                {
                    FailMsg += name + Environment.NewLine;
                }

                // 2007.03.12 Added xg data task
                //
                XGStation xgst = CreateXgStation( name, xgAddr, ip );
                //TODO: ? xgst.serverIP = serverip
                //
                xgst.ServerIP = serverIP;

                if ( xgst != null )
                {
                    Singles.S.XGStsCollection.Add( xgst );
                    if ( serverIP == XGConfig.Default.ServerIP )
                    {
                        ReadTotalCountCommand xgCountCmd = new ReadTotalCountCommand( xgst );
                        TimeSpan ts = new TimeSpan(0,0,XGConfig.Default.XgReadCountCycle,0,0 );
                        CycleTaskStrategy strategy = new CycleTaskStrategy( ts );
                        Task t = new Task( xgCountCmd, strategy );
                        tasks.Add( t );
                        //                        t.AfterProcessReceived +=new EventHandler(t_AfterProcessReceived);
                    }
                }
                else
                {
                }
            }

            if ( FailMsg.Length >= 13 )
                MsgBox.Show( FailMsg );
            return tasks;
        }
        

        #endregion //ResolveGRRealDataTaskFromDB

        #region CreateGrStation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static GRStation CreateGrStation( string name, int address, string ip, 
            string team )
        {
            Debug.Assert( name != null );

            Debug.Assert( ip != null && ip.Length >= 7 );

            if ( ip == null || ip.Length < 7 )
                return null;
            OutSideTempWorkMode ostwm;
            if( name == XGConfig.Default.OstCollStationName )
            {
                ostwm = OutSideTempWorkMode.CollByControllor;
            }
            else
            {
                ostwm = OutSideTempWorkMode.SetByComputer;
            }

            return new GRStation( name, address, ostwm, ip, team );
        }

        #endregion //CreateGrStation

        #region CreateXgStation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        private static XGStation CreateXgStation( string name, int address, string ip )
        {
            Debug.Assert( name != null );
            Debug.Assert( ip != null && ip.Length >= 7 );
            if ( ip == null || ip.Length < 7 )
                return null;

            return new XGStation( name, ip, address );
        }
        #endregion //CreateXgStation

        #region InitialGlobal
		/// <summary>
		/// 读取配置文件
		/// </summary>
		/// <returns></returns>
        public static bool InitialGlobal()
        {
            ReadConfigFile();

            XGDB.XGDBConnectionString = XGConfig.Default.ConnectionString;

            // 2007-10-12 Added process sql exception
            //
            try
            {
                XGDB.DbClient.Open();
            }
            catch(SqlException sqlex)
            {
                //MessageBox.Show( sqlex.Message );
                MsgBox.Show( sqlex.Message, GT.TEXT_TIP, MessageBoxIcon.Error );
                Environment.Exit(0);
            }

            // 生成并启动网络端口监听。
            //
            if ( !ListenPort() )
                return false;


            // 解析gprs_station表，生成gr real data command task
            //
            // 
            TasksCollection tasks = ResolveGRRealDataTaskFromDB();

            CommPortProxysCollection cpps = new CommPortProxysCollection();

            // 生成 TaskScheduler
            //
            TaskScheduler sch = new TaskScheduler(cpps, XGConfig.Default.TaskSchedulerInterval);
            sch.Executed += new EventHandler( CommTaskResultProcessor.Default.Process );
            sch.Executing += new EventHandler( TaskExecutingProcessor.Default.Process );
            sch.NotFindMatchCPPEvent += new EventHandler(NotFindMatchCppProcesser.Default.Process );

            //
            //
            AddTasks( sch.Tasks, tasks );

            //
            //
            sch.Enabled = true;

            //
            //
            Singles.S.TaskScheduler = sch;
            


            // TODO: cpps receive event process.
            //
            cpps.ReceiveARDEvent += new ReceiveARDHandler(ARDProcessor.Default.Process);
            //cpps.ReceiveTimeOutEvent +=new ReceiveTimeOutEventHandler(CommTaskResultProcessor.Default.Process);
            
            
            // TODO: 解析tbl_xgTask表，生成XGTask及XGTaskScheduler。
            //
            // 



            //连接请求：
            //	接受
            //	加入TaskScheduler.CppsCollection中，（检查是否有同源的连接，如有先删除）

            return true;
        }

        #endregion //InitialGlobal

        #region ListenPort
        /// <summary>
        /// 
        /// </summary>
        private static bool ListenPort()
        {
            try
            {
                WSListen gprsListen = new WSListen( XGConfig.Default.ListenPort );
                gprsListen.NewConnection += new EventHandler( GCRQProcesser.Default.Process );
                Singles.S.GprsListen = gprsListen;

                gprsListen.Listen();
                WSListen._log = frmLogs.Default;
                return true;
            }
            catch( Exception ex )
            {
                System.Runtime.InteropServices.COMException comEx = ex as System.Runtime.InteropServices.COMException;
                if ( comEx != null )
                {
                    string errorInfo = GetWSErrorInfo ( (uint)comEx.ErrorCode );
                    MsgBox.Show( 
                        errorInfo, 
                        //"错误", 
                        GT.TEXT_ERROR,
                        System.Windows.Forms.MessageBoxIcon.Error 
                        );
                }
                else
                {
                    MsgBox.Show(
                        ex.ToString(), 
                        //"错误",
                        GT.TEXT_ERROR,
                        System.Windows.Forms.MessageBoxIcon.Error 
                        );
                }
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        private static string GetWSErrorInfo ( uint errorCode )
        {
            string s = string.Empty;
            switch ( errorCode )
            {
                case 0x800A2740:
                    s = "地址或端口正在使用中";
                    break;

                default:
                    s = "未知错误。\r\n错误码: " + errorCode.ToString("X") ;
                    break;
            }

            return s;
        }

        #endregion //ListenPort

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() 
        {
            new MainClass();
        }
    }
}
