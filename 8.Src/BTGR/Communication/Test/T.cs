using System;
using Communication;
using Communication.GRCtrl;

namespace Communication.Test
{
	/// <summary>
	/// T 的摘要说明。
	/// </summary>
	public class T
	{
		public T()
		{
//            frmGRAlarmDataPopUp.Default.Show();
//            testTempLine();
//            test_readtl();            
//            this.gr_alarm_data();
//            try
//            {
//                insert_ard_xgdata();
//            }
//            catch (Exception ex )
//            {
//                MsgBox.Show( ex.ToString() );
//            }

//            new FreeDataProcessorTest().t();
//            testXGARD();


//            testXgRecordParse();
		}

        /// <summary>
        /// 
        /// </summary>
        private void testXgRecordParse()
        {
            string s = "21 58 44 00 B0 07 10 00 03 29 52 06 02 00 00 01 7B AE EA 0D 00 00 8E 37 DB";
            string innerString = "00 03 29 52 06 02 00 00 01 7B AE EA 0D 00 00 8E";

            byte[] bs = Utilities.CT.StringToBytes(
                innerString, 
                null,
                Utilities.StringFormat.Hex 
                );

            byte[] bs0 = Utilities.CT.StringToBytes(
                s,
                null,
                Utilities.StringFormat.Hex
                );

            Record r = Record.Analyze( bs );
            if ( r == null )
                MsgBox.Show( "yes" );

            object obj = new XgRecordParser( bs0 ).ToValue();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void testXGARD()
        {

            try
            {
                string s = "00 08 51 38 20 24 10 07 01 C9 3C DE 01 00 00 2E";
                byte[] bs = Utilities.CT.StringToBytes( s, null, Utilities.StringFormat.Hex );
                ARDProcessor.Default.ProcessXGARD( "10.110.51.62", 5, bs );
            }
            catch ( Exception ex )
            {
                System.Windows.Forms.MessageBox.Show( ex.ToString() );
            }
        }

        public void test1()
        {
            MsgBox.Show( XGDB.GetGRStationName( "1.2.3.4" ) );
			//
			// TODO: 在此处添加构造函数逻辑
			//
//            frmGRAlarmDataPopUp f = frmGRAlarmDataPopUp.Default;
//            f.AddGrAlarmData( "st", "1.1.1.2", 0, GRCtrl.GRAlarmData.s_test );
        }

        public void insert_ard_xgdata()
        {
            string remoteIP = "10.110.51.3";
            string sn = "9993456789123456";
            int address = 0;

            XGData xgData = new XGData( sn, address, DateTime.Now, true );

            // TODO: save xg ard and Match XgTask with the xgdata
            //
            XGDB.InsertXGData( remoteIP, xgData );
        }

        public void gr_alarm_data()
        {
            frmGrAlarmDataManager f = new frmGrAlarmDataManager();
            f.Show();
        }

//        public void test_readtl()
//        {
//            frmTempLine f1 = new frmTempLine( new GRStation( "a",0,"1.1.1.1" ) );
//
//            GRReadTLCommand c = new GRReadTLCommand( new GRStation( "a",0,"1.1.1.1" ) );
//            if ( c.ProcessReceived ( GRReadTLCommand .test_receive ) == CFW.CommResultState.Correct )
//            {   
//                byte[] bs = new GRWriteTLCommand ( new GRStation( "a",0,"1.1.1.1" ), c.TemperatureLine, 
//					c.TimeTempLine ).MakeCommand ();//MakeCmmand();
//                MsgBox.Show( Utilities.CT.BytesToString( bs ) );
//                f1.ShowTL( c.TemperatureLine );
//
//                f1.ShowDialog();
//
////                ;
////                Utilities.frmPropertiesGrid f = new Utilities.frmPropertiesGrid();
////                f.ShowMe( c.TemperatureLine );
//            }
//            else
//            {
//                MsgBox.Show( "not correct" );
//            }
//        }

        public void testTempLine()
        {
            frmTempLine f = new frmTempLine( new GRStation( "A",0,"1.1.1.1" ) );
            f.ShowDialog();
        }
	}
}
