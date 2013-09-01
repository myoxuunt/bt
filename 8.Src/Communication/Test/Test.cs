using System;
using NUnit.Framework;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using Communication.GRCtrl;
namespace Communication.Test
{
	/// <summary>
	/// Test 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class Test
	{
		public Test()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//

//            XGDB.DbClient = new Utilities.Database.DbClient(new Utilities.Database.SqlFactory(),
//                "workstation id=A;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1;persist security info=False;initial catalog=XGDB;");
//            XGDB.XGDBConnectionString = "workstation id=A;packet size=4096;user id=sa;pwd=sa;data source=192.168.0.1;persist security info=False;initial catalog=XGDB;";
            XGDB.XGDBConnectionString = "workstation id=A;packet size=4096;user id=sa;pwd=sa;data source=(local);persist security info=False;initial catalog=XGDB;";
            XGDB.DbClient.Open();
            XGConfig.Default.ConnectionString = XGDB.XGDBConnectionString;
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
            cmd.Parameters.Add("@p_oneAccum",(int)GRDatas.OneAccum);
            cmd.Parameters.Add("@p_twoAccum",(int)GRDatas.TwoAccum);
            cmd.Parameters.Add("@p_openDegree",GRDatas.OpenDegree);
            cmd.Parameters.Add("@p_twoPressCha",GRDatas.TwoPressCha);

            //            GRPumpState GRState=new GRPumpState();
            GRPumpState GRState = GRDatas.GrPumpState;
//            MsgBox.Show( GRState.CyclePump1.ToString() );
            cmd.Parameters.Add("@p_pumpState1",GRState.CyclePump1);
            cmd.Parameters.Add("@p_pumpState2",GRState.CyclePump2);
            cmd.Parameters.Add("@p_pumpState3",GRState.CyclePump3);
            cmd.Parameters.Add("@p_addPumpState1",GRState.RecruitPump1);
            cmd.Parameters.Add("@p_addPumpState2",GRState.RecruitPump2);

            cmd.ExecuteNonQuery ();
            cmd.Dispose();
            con.Close();
        }


        private void InsertGRAlarmDataToDB( int grStId, GRAlarmData ad )
        {
            GRAlarmData GRAlarm = ad;

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

        [Test]
        public void InsertGrRealDataToDB()
        {
            int id = XGDB.GetGRStationID ("10.110.51.3",0);
            Assert.AreEqual( 6, id );
            InsertGRRealDataToDb( "10.110.51.3",0, GRRealData.s_test );
            
        }

        [Test ]
        public void InsertGrAlarmData()
        {
            InsertGRAlarmDataToDB( 6, GRAlarmData.s_test );
        }

        [Test]
        public void InsertPumpOPLog()
        {
            XGDB.InsertCtrlLog( DateTime.Now, "xunhuanb","stop", "me" );
        }
	}
}
