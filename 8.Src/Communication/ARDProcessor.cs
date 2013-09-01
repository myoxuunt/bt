namespace Communication
{
    using System;
    using Utilities;
    using Communication.GRCtrl;
    using CFW;
    using System.Data;
    using System.Data.SqlClient;

    #region ARDProcessor
	/// <summary>
	/// 自动上报数据处理类
	/// </summary>
	public class ARDProcessor
	{
        #region Default
        private static ARDProcessor s_default = new ARDProcessor();

        /// <summary>
        /// 
        /// </summary>
        public static ARDProcessor Default
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
		public ARDProcessor()
		{
		}

        #endregion //Constructor

        #region GetArdLogString
        //private string GetArdLogString( int commPort, byte[] bs )
        private string GetArdLogString( string remoteIP, byte[] bs )
        {
            string sData;
            if ( bs == null || bs.Length <= 0 )
                sData = string.Empty;
            else
                sData = CT.BytesToString( bs );

            //string s = string.Format("ArdTime\t: {0}\r\nArdData\t: {1}\r\nCommPort: {2}\r\n",
            string s = string.Format("ArdTime\t: {0}\r\nArdData\t: {1}\r\nRemoteIP: {2}\r\n",
                DateTime.Now, sData, remoteIP );

            return s;
        }
        #endregion //GetArdLogString

        #region IsValidARD
        /// <summary>
        /// 是否为有效的上报数据 或者是正确的供热实时数据
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="source"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public bool IsValidARD( //int sourceCommPort, 
            byte[] datas, out int address, out int devType, out int fcType, out byte[] innerData )
        {
            address = -1;
            devType = -1;
            fcType = -1;
            innerData = null;
            
            if ( datas == null || datas.Length == 0 )
                return false;
            if ( datas.Length < 9 )
                return false;

            if ( datas[0] == 0x21 &&
                 datas[1] == 0x58 &&
                 datas[2] == 0x44 &&
                //( datas[4] == 0xA0 || datas[4] == 0xB0 ) )
                ( datas[4] == XGDefinition.DEVICE_TYPE || datas[4] == GRDef.DEVICE_TYPE  ) )
            {
                //int innerDataLen = datas[ 6 ];
                int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
                int corrLen = innerDataLen + XGDefinition.ZERO_DATA_CMD_LENGTH;

                if ( datas.Length < corrLen )
                    return false;

                bool crcR = false;

                if ( datas.Length > corrLen )
                {
                    byte[] ds2 = new byte[corrLen];
                    Array.Copy( datas, 0, ds2, 0, corrLen );
                    crcR = CheckCRC( ds2 );
                    datas = ds2;
                }
                else
                {
                    crcR = CheckCRC( datas );
                }

                if ( crcR == false )
                    return false;

                address = datas[XGDefinition.ADDRESS_POS];
                devType = datas[XGDefinition.DEVICE_TYPE_POS];
                fcType  = datas[XGDefinition.FUNCTION_CODE_POS];
                innerData = GetInnerData( datas );
            }
            return true;
        }
        #endregion //IsValidARD

        #region GetInnerData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        private byte[] GetInnerData(byte[] datas )
        {
            int innerDataLen = datas[ XGDefinition.INNER_DATA_LENGTH_POS ];
            if (innerDataLen == 0)
                return null;

            byte[] innerData = new byte[innerDataLen];

            for (int i=0; i<innerDataLen; i++)
            {
                innerData[i] = datas[XGDefinition.INNER_DATA_BEGIN_POS + i];
            }           

            return innerData;
        }
        #endregion //GetInnerData

        #region CheckCRC
        private bool CheckCRC( byte[] datas )
        {
        
            byte calcHi, calcLo;
            CRC16.CalculateCRC( datas, datas.Length - 2, out calcHi, out calcLo );
            
            byte lo = datas[ datas.Length - 2];
            byte hi = datas[ datas.Length - 1];
            if (hi != calcHi || lo != calcLo)
                return false;

            return true;
        }
        #endregion //CheckCRC

        #region Process
        //public void Process(object sender, EventArgs e)

        //TODO: process with freedata
        //
        public void Process ( object sender, ReceiveARDEventArgs e )
        {
            // 2007.02.24
            //
            //CommPortProxy cpp = (CommPortProxy) sender;
            //int commPort = cpp.ComPort;
            //byte[] bs = cpp.AutoReportData;

            CommPortProxy cpp = e.Source;
            string remoteIP = cpp.RemoteHostIP;
            byte[] bs = e.ARDDatas;

            // Log auto report datas
            //
            string s = GetArdLogString ( remoteIP, bs );
            
            if ( XGConfig.Default.LogCommIO )
                FileLog.CommARD.Add( s );

            if ( XGConfig.Default.ShowLogForm )
                frmLogs.Default.AddLogARD ( s );



            int address, devType, fcType;
            byte[] innerDatas;

            // 2007.03.09 Added comment 检查是否为有效的自动上报数据或供热实时数据 
            //
            bool valid = IsValidARD( bs, out address, out devType, out fcType, out innerDatas );
            if ( valid )
            {
                // is xg ard
                //
                if (devType == XGDefinition.DEVICE_TYPE )
                {
                    if ( fcType == XGDefinition.FC_AUTO_REPORT )
                        this.ProcessXGARD( remoteIP, address, innerDatas );
                }

                // is gr data type 
                //
                if ( devType == GRDef.DEVICE_TYPE )
                {
                    if ( fcType == GRDef.FC_AUTO_ALARMDATA )
                    {
                        this.ProcessGRARD( remoteIP, address, innerDatas );
                    }
                    else
                    {
                        //TODO: ??: Process read timeout, and return as ARD data
                        //
                    }

                    // 2007.03.09 Added check is grRealData
                    //
                    if ( fcType == GRDef.FC_READ_REALDATA )
                    {
                        this.ProcessGrRealData( remoteIP, address, innerDatas );
                    }
                }
            }
        }

        #endregion //Process
        
        #region ProcessGRRealData
        /// <summary>
        /// 处理自动上报的供热控制器实时数据,该数据可能是由于采集是返回数据超时引起
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <param name="innerDatas"></param>
        public void ProcessGrRealData( string remoteIP, int address, byte[] innerDatas )
        {
            GRRealData rd = GRRealData.Parse( innerDatas, address );
            if ( rd != null )
                CommTaskResultProcessor.Default.ProcessGRRealData( remoteIP, address, rd );

        }
        #endregion //ProcessGRRealData

        #region ProcessXGARD
        /// <summary>
        /// 处理巡更控制器的自动上报数据
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <param name="innerDatas"></param>
        /// <returns></returns>
        public XGData ProcessXGARD(  string remoteIP, int address, byte[] innerDatas )
        {
            Record r = Record.Analyze( innerDatas );
            //return new XGData( r.CardSN, address, r.DateTime, true );
            if ( r != null )
            {
                XGData xgData = new XGData( r.CardSN, address, r.DateTime, true );

                // TODO: save xg ard and Match XgTask with the xgdata
                //
                // insert ard xg data to db
                //
                XGDB.InsertXGData( remoteIP, xgData );
                
                // insert a new task to taskScheduler, the task remove the last ard xgdata
                //
                XGStation xgst = Singles.S.GetXGStation( remoteIP, address );
                if ( xgst == null )
                    xgst = new XGStation( "xgst" + DateTime.Now, remoteIP, address );

                CommCmdBase cmd = new AutoReportCommand( xgst );
                Task task = new Task( cmd, new ImmediateTaskStrategy () );
                Singles.S.TaskScheduler.Tasks.Add( task );

                return xgData;
            }

            return null;
        }
        #endregion //ProcessXGARD

        #region ProcessGRARD
        /// <summary>
        /// 处理供热自动上报报警数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="address"></param>
        /// <param name="innerDatas"></param>
        /// <returns></returns>
        //public GRAlarmData ProcessGRARD( int sourceCommPort, int address, byte[] innerDatas )
        public GRAlarmData ProcessGRARD( string remoteIP, int address, byte[] innerDatas )
        {
            GRAlarmData alarm = GRAlarmData.Parse( innerDatas, address );

            InsertGRAlarmDataToDb( remoteIP, address, alarm );
            //TODO:
            //
            string grStName = XGDB.GetGRStationName( remoteIP );

            frmGRAlarmDataPopUp f = frmGRAlarmDataPopUp.Default;
            f.AddGrAlarmData( grStName, remoteIP, address, alarm );
            // f = new frmGRAlarmDataPopUp();

            
            return alarm;
        }
        #endregion //ProcessGRARD

        #region InsertGRAlarmDataToDb
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <param name="ad"></param>
        public void InsertGRAlarmDataToDb( string remoteIP, int address, GRAlarmData ad )
        {
            ArgumentChecker.CheckNotNull( ad );
            int grStId = XGDB.GetGRStationID( remoteIP, address );
            
            if ( grStId != -1 )
            {
                InsertGRAlarmDataToDB( grStId, ad );
            }
        }
        #endregion //InsertGRAlarmDataToDb

        #region InsertGRAlarmDataToDB
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grStId"></param>
        /// <param name="ad"></param>
        private void InsertGRAlarmDataToDB( int grStId, GRAlarmData ad )
        {
            GRAlarmData GRAlarm = ad;

//            SqlConnection con = new SqlConnection( XGDB.DbClient.Connection.ConnectionString );
            SqlConnection con = new SqlConnection( XGConfig.Default.ConnectionString );

            con.Open();            

            SqlCommand cmd= new SqlCommand( "AddGRAlarm", con );
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_grstation_id", grStId );//,i);//

            cmd.Parameters.Add("@p_time",DateTime.Now);
            cmd.Parameters.Add("@p_oneGiveTempLow",GRAlarm.oneGiveTemp_lo);
            cmd.Parameters.Add("@p_twoGiveTempHigh",GRAlarm.twoGiveTemp_hi);
            cmd.Parameters.Add("@p_oneGivePressLow",GRAlarm.oneGivePress_lo);
            cmd.Parameters.Add("@p_twoGivePressHigh",GRAlarm.twoGivePress_hi);
            cmd.Parameters.Add("@p_twoBackPressHigh",GRAlarm.twoBackPress_hi);
            cmd.Parameters.Add("@p_twoBackPressLow",GRAlarm.twoBackPress_lo);
            cmd.Parameters.Add("@p_WatLevelLow",GRAlarm.watLevel_lo);
            cmd.Parameters.Add("@p_WatLevelHigh",GRAlarm.watLevel_hi);
            cmd.Parameters.Add("@p_pumpAlarm1",GRAlarm.cycPump1);
            cmd.Parameters.Add("@p_pumpAlarm2",GRAlarm.cycPump2);
            cmd.Parameters.Add("@p_pumpAlarm3",GRAlarm.cycPump3);
            cmd.Parameters.Add("@p_addPumpAlarm1",GRAlarm.recruitPump1);
            cmd.Parameters.Add("@p_addPumpAlarm2",GRAlarm.recruitPump2);
            cmd.Parameters.Add("@p_NoPower",GRAlarm.powerOff);
            cmd.ExecuteNonQuery ();
            cmd.Dispose();
            con.Close();

        }
        #endregion //InsertGRAlarmDataToDB
	}
    #endregion //ARDProcessor
}
