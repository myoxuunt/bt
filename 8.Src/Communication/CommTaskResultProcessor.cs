namespace Communication
{
    using System;
    using CFW;
    using Communication.GRCtrl;
    using System.Diagnostics;
    using Utilities;
    using System.Data;
    using System.Data.SqlClient;
 
    #region CommTaskResultProcessor
    /// <summary>
	/// for listen TaskScheduler.Executed
	/// 招测任务结果处理器
	/// </summary>
	/// <remarks>
	/// 处理以下几种命令:
	/// 1. GR real data command
	/// 2. GR set out side temperature
	/// 3. GR remote set control params
	/// 4. XG read total record count
	/// 5. XG read record
	/// 6. XG clear record
	/// </remarks>
	public class CommTaskResultProcessor
	{
        #region Default
        private static CommTaskResultProcessor s_default = new CommTaskResultProcessor();

//        private object _lock = new object();

        public static CommTaskResultProcessor Default 
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Constructor
		public CommTaskResultProcessor()
		{
		}
        #endregion //Constructor

        #region Process
        public void Process(object sender, EventArgs e)
        //public void Process(object sender, ReceiveTimeOutEventArgs e)

        {
            // 2007.02.24
            //
            //lock( _lock )
            //{
            //    //Utilities.frmPropertiesGrid f = new frmPropertiesGrid();
            //    //f.ShowMe( sender, "" );
            //    TaskScheduler sch = (TaskScheduler)sender;
            //    CommPortProxy cpp = sch.CommPortProxy;
            //    int commPort = cpp.ComPort;
            //    Task activeTask = sch.ActiveTask;
            //    Debug.Assert( activeTask != null, "activeTask != nul" );
            //    Process( commPort, activeTask );
            //}

            //CommPortProxy cpp = e.Source ;
            TaskScheduler sch = (TaskScheduler) sender;
            
            //string remoteIP = cpp.RemoteHostIP;
            Task activeTask = sch.ActiveTask;
            Debug.Assert( activeTask != null );


            Singles.S.CollStateDisPlay.Text += GetCommResultText ( activeTask.LastCommResultState  );

//            string remoteIP = activeTask.CommCmd.Station.DestinationIP; 
//            Process( remoteIP, activeTask );
            Process( activeTask );
        }
        #endregion //Process

        #region GetCommResultText
        private string GetCommResultText( CommResultState state )
        {
            string r = string.Empty;
            if ( state == CommResultState.Correct )
                return " 成功";
            else 
                r = " 失败(";

            switch ( state  )
            {
                case CommResultState.CheckError:
                    r += "校验错";
                    break;

//                case CommResultState.Correct:
//                    r = "成功";
//                    break;

                case CommResultState.DataError: 
                    r += "接收数据错误";
                    break;

                case CommResultState.LengthError: 
                    r += "接收数据长度错误";
                    break;

                case CommResultState.NullData: 
                    r += "未接收到数据";
                    break;

                default:
                    r += "未知错误";
                    break;
            }
            r +=")";

            return r;
        }
        #endregion //GetCommResultText

        #region GetLogString
        //private string getlogstring( int commport, task task )
        private string GetLogString( string remoteIP, Task task )
        {
            CommCmdBase cmd = task.CommCmd;
            CommResultState commResultState = task.LastCommResultState;
            string sLastReceive = string.Empty;
            if ( task.LastReceived != null )
                sLastReceive = CT.BytesToString ( task.LastReceived );

            string s = string.Format( "Send\t\t: {0}, {1}\r\nReceived\t: {2}, {3}\r\nCommResult\t: {4}\r\nCmdType\t\t: {5}\r\nRemoteIP\t: {6}\r\n",
                task.LastSendDateTime, CT.BytesToString( task.LastSendDatas ), 
                //task.LastReceivedDateTime, CT.BytesToString( task.LastReceived),
                task.LastReceivedDateTime, sLastReceive,
                commResultState.ToString(), cmd.GetType().Name, remoteIP );
            return s;
        }
        #endregion //GetLogString

        #region Process
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
//        private void Process( string remoteIP, Task task )
        private void Process( Task task )
        {
            ArgumentChecker.CheckNotNull( task );

            string remoteIP = task.CommCmd.Station.DestinationIP; 
            CommCmdBase cmd = task.CommCmd;
            Station st = cmd.Station;
            
            CommResultState commResultState = task.LastCommResultState;
            string s = null;
            
            if ( XGConfig.Default.LogCommIO )
            {
                if ( s == null )
                    //s = GetLogString( commPort, task );
                    s = GetLogString( remoteIP, task );

                FileLog.CommIO.Add( s );
                if ( XGConfig.Default.ShowLogForm )
                    frmLogs.Default.AddLog( s );
            }

            // log fail comm
            // 所有通讯失败情况在此处理
            //
            if ( commResultState != CommResultState.Correct )
            {
                if ( XGConfig.Default.LogCommFail )
                {
                    if ( s == null )
                        s = GetLogString( remoteIP, task );

                    if ( XGConfig.Default.LogCommFail )
                        FileLog.CommFail.Add ( s );

                    if ( XGConfig.Default.ShowLogForm)
                    {
                        //frmLogs.FailForm.AddLog( s );
                        frmLogs.Default.AddLogCommFail ( s );
                    }
                }

                ProcessFreeData( task.CommCmd.Station.DestinationIP, task.LastReceived );//, task);
                return ;
            }

            // 以下只是处理通讯成功的情况
            //

            // 4. XG real total count command
            //
            if ( cmd is ReadTotalCountCommand )
            {
                ReadTotalCountCommand readCountCmd = cmd as ReadTotalCountCommand;
                ProcessReadTotalCountCmd( readCountCmd, task );
            }

            // 5. XG real record
            //
            if ( cmd is ReadRecordCommand )
            {
                ReadRecordCommand readRecordCmd = cmd as ReadRecordCommand;
                ProcessReadRecordCmd( readRecordCmd );
            }

            // 6. XG clear record command
            // 

            // 读取供热控制器实时数据
            // 1. GR real data command
            //
            if ( cmd is GRRealDataCommand )
            {
                GRRealDataCommand realDataCmd = ( GRRealDataCommand ) cmd;
                //ProcessGRRealDataCmd( commPort, realDataCmd );
                ProcessGRRealDataCmd( remoteIP, realDataCmd );
            }

            // 2. GR set out side temperature command
            //
            if ( cmd is GRSetOutSideTempCommand )
            {
                GRSetOutSideTempCommand c = (GRSetOutSideTempCommand) cmd;
                ProcessGRSetOutSideTempCmd( c );
            }

            // 3. GR remote set control params
            //
        }

        #endregion //Process


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromIP"></param>
        /// <param name="datas"></param>
        private void ProcessFreeData( string fromIP, byte[] datas )//, Task task )
        {
            FreeDataProcessor.Default.Process( fromIP, datas );
            #region ...
            ////TODO: 
            //GrDataPicker gdp = new GrDataPicker();
            //byte[][] grDatas = gdp.Picker( datas );
            //if ( grDatas != null )
            //{
            //    foreach ( byte[] bs in grDatas )
            //    {
            //        // check crc
            //        if ( CRC16.CheckCrc( bs ) )
            //        {
            //            // get dev type ? grDataPicker make sure!
            //            // get fc
            //            byte fc = bs[ GRDef.FUNCTION_CODE_POS ];
            //            
            //            // process
            //            if ( GRDef.FC_READ_REALDATA == fc )
            //            {
            //                int address;
            //                GRRealData grRealData;
            //
            //                CommResultState result = GRRealDataCommand.ProcessReceived(
            //                    bs,
            //                    out address,
            //                    out grRealData
            //                    );
            //
            //                if ( result == CommResultState.Correct )
            //                {
            //                    ProcessGRRealData( fromIP, address, grRealData );
            //                }
            //            }
            //            if ( GRDef.FC_AUTO_ALARMDATA == fc )
            //            {
            //
            //            }
            //        }
            //
            //    }
            //}
            //
            //XgDataPicker xgdp = new XgDataPicker();
            //byte[][] xgDatas = xgdp.Picker( datas );
            //if ( xgDatas != null )
            //{
            //    foreach( byte[] bs in xgDatas )
            //    {
            //        // check crc
            //        // get fc
            //        // process
            //    }
            //}
            #endregion //...
        }

        #region Process Render

        private void ProcessGRSetOutSideTempCmd( GRSetOutSideTempCommand c )
        {
            // do nothing
            //
        }

        //private void ProcessGRRealDataCmd( int commPort , Communication.GRCtrl.GRRealDataCommand realDataCmd )
        /// <summary>
        /// 处理供热实时采集数据
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="realDataCmd"></param>
        private void ProcessGRRealDataCmd( string remoteIP, Communication.GRCtrl.GRRealDataCommand realDataCmd )
        {
            // save gr real data to db
            //
            GRRealData rd = realDataCmd.GRRealData;
            int addr = realDataCmd.Station.Address;
    
            // Save( commPort, addr, rd );
            InsertGRRealDataToDb( remoteIP, addr, rd );

            // Update Singles.S.OutSideTemperature
            //
            GRStation grSt = (GRStation)realDataCmd.Station;
            if ( grSt.OSTWorkMode == OutSideTempWorkMode.CollByControllor )
            {
                Singles.S.OutSideTemperature = rd.OutSideTemp;
                //TODO: Write out side temperature to DB
                //
            }

            // process grAlarmData in grRealData
            //
            GRAlarmData adFromRealData = rd.GrAlarmData;
            if ( IsIncludeAlarm( adFromRealData ) )
            {
                ARDProcessor.Default.InsertGRAlarmDataToDb( remoteIP, addr, adFromRealData );
            }

            // 2007.03.03 Added to singles.GrStRds
            //
//            GRStationLastRealData last = new GRStationLastRealData( grSt, rd );
//            Singles.S.GRStRds.Add( last );
            Singles.S.GRStRds.ChangeWithRemoteIP( grSt.DestinationIP, grSt.Address, rd );
        }


        /// <summary>
        /// 处理由自动上报数据处理器接收到的供热实时数据
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <param name="rd"></param>
        public void ProcessGRRealData (string remoteIP, int address, GRRealData rd )
        {
            ArgumentChecker.CheckNotNull( rd );

            InsertGRRealDataToDb ( remoteIP, address, rd );

            GRAlarmData adFromRealData = rd.GrAlarmData;
            if ( IsIncludeAlarm( adFromRealData ) )
            {
                ARDProcessor.Default.InsertGRAlarmDataToDb( remoteIP, address, adFromRealData );
            }

            Singles.S.GRStRds.ChangeWithRemoteIP( remoteIP, address, rd );
        }

        /// <summary>
        /// 判断从供热实时数据中获取的报警数据中是否包含报警值
        /// </summary>
        /// <remarks>
        /// 供热实时数据中包含报警数据（同自动上报的报警数据），该报警数据中可能包含或不包含报警数据。
        /// 不包含报警值时，报警数据不存入数据库，
        /// 包含报警值时，处理同自动上报的报警数据。
        /// </remarks>
        /// <param name="ad"></param>
        /// <returns></returns>
        private bool IsIncludeAlarm( GRAlarmData ad )
        {
            ArgumentChecker.CheckNotNull( ad );
            if ( ad.cycPump1 || ad.cycPump2 || ad.cycPump3 )
                return true;
            if ( ad.oneGivePress_lo || ad.oneGiveTemp_lo )
                return true;
            if ( ad.powerOff || ad.recruitPump1 || ad.recruitPump2 )
                return true;
            if ( ad.twoBackPress_hi || ad.twoBackPress_lo || ad.twoGivePress_hi || ad.twoGiveTemp_hi )
                return true;
            if ( ad.watLevel_hi || ad.watLevel_lo )
                return true;

            return false;
        }

        private void InsertGRRealDataToDb ( string remoteIP, int address, GRRealData realData )
        {
            int grStId = XGDB.GetGRStationID( remoteIP, address );
            GRRealData GRDatas = realData; //new GRRealData();

//            DBcon con=new DBcon();
            SqlConnection con  = new SqlConnection( XGConfig.Default.ConnectionString /*XGDB.DbClient.Connection.ConnectionString*/ );
            con.Open();

            SqlCommand cmd= new SqlCommand("AddGRDatas", con );

            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_grstation_id", grStId );

            cmd.Parameters.Add("@p_time",GRDatas.DT);//dtt);//
            cmd.Parameters.Add("@p_oneGiveTemp",GRDatas.OneGiveTemp);
            cmd.Parameters.Add("@p_oneBackTemp",GRDatas.OneBackTemp);
            cmd.Parameters.Add("@p_twoGiveTemp",GRDatas.TwoGiveTemp);
            cmd.Parameters.Add("@p_twoBackTemp",GRDatas.TwoBackTemp);
            cmd.Parameters.Add("@p_outsideTemp",GRDatas.OutSideTemp);
            cmd.Parameters.Add("@p_twoGiveBaseTemp",GRDatas.TwoGiveBaseTemp);
//            cmd.Parameters.Add("@p_oneGivePress",GRDatas.OnwGivePress);
            cmd.Parameters.Add("@p_oneGivePress",GRDatas.OneGivePress);

            cmd.Parameters.Add("@p_oneBackPress",GRDatas.OneBackPress);
            cmd.Parameters.Add("@p_WatBoxLevel",GRDatas.WatBoxLevel);
            cmd.Parameters.Add("@p_twoGivePress",GRDatas.TwoGivePress);
            cmd.Parameters.Add("@p_twoBackPress",GRDatas.TwoBackPress);
            cmd.Parameters.Add("@p_oneInstant",GRDatas.OneInstant);
            cmd.Parameters.Add("@p_twoInstant",GRDatas.TwoInstant);
            cmd.Parameters.Add("@p_oneAccum",GRDatas.OneAccum);
            cmd.Parameters.Add("@p_twoAccum",GRDatas.TwoAccum);
            cmd.Parameters.Add("@p_openDegree",GRDatas.OpenDegree);
            cmd.Parameters.Add("@p_twoPressCha",GRDatas.TwoPressCha);

//            GRPumpState GRState=new GRPumpState();
            GRPumpState GRState = GRDatas.GrPumpState;
            cmd.Parameters.Add("@p_pumpState1",GRState.CyclePump1);
            cmd.Parameters.Add("@p_pumpState2",GRState.CyclePump2);
            cmd.Parameters.Add("@p_pumpState3",GRState.CyclePump3);
            cmd.Parameters.Add("@p_addPumpState1",GRState.RecruitPump1);
            cmd.Parameters.Add("@p_addPumpState2",GRState.RecruitPump2);

            cmd.ExecuteNonQuery ();
            cmd.Dispose();
            con.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessReadRecordCmd( ReadRecordCommand cmd )
        {
            XGData xgData = cmd.XGData;
            
            if ( xgData != null )
            {
//                XGDB.InsertXGData ( cmd.XGData );
//                XGTask[] matchedXgTasks = Singles.S.XGScheduler.Tasks.MatchXGData( cmd.XGData );
//                foreach ( XGTask t in matchedXgTasks )
//                {
//                    t.IsComplete = true;
                // ?TODO: save complete task to db
                //
                XGDB.InsertXGData( cmd.Station.DestinationIP, xgData );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="owningTask"></param>
        /// <remarks>
        /// 可能包含读取并清除本地数据的后续指示(在Task.Tag中)
        /// </remarks>
        private void ProcessReadTotalCountCmd( ReadTotalCountCommand cmd, Task owningTask )
        {
            int recordCount = cmd.TotalCount;
            if ( recordCount <= 0 )
                return ;

            XGStation st = (XGStation) cmd.Station;

            //Immediate task strategy 被加到tasks的最前端，所以要先加入，一般在读取完所有的记录后清空。
            //
            RemoveAllCommand clearCmd = new RemoveAllCommand( st );
            Task clearTask = new Task( clearCmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add( clearTask );
            
            for ( int i=0; i<recordCount; i++ )
            {
                ReadRecordCommand rdcmd = new ReadRecordCommand( st, i+1 );
                Task t = new Task(rdcmd, new ImmediateTaskStrategy() );
                Singles.S.TaskScheduler.Tasks.Add( t );
            }

        }
        #endregion //Process Render
	}
    #endregion //CommTaskResultProcessor
}
