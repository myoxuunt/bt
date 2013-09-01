using System;
using NUnit.Framework;

namespace Communication.LanDi
{
	/// <summary>
	/// HeartBeatParserTest 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
    public class HeartBeatParserTest
    {
        //@@13500627885IP:10.110.51.24##
        string[] _s =new string[]
        {
            "40 40 31 33 35 30 30 36 32 37 38 38 35 49 50 3A 31 30 2E 31 31 30 2E 35 31 2E 32 34 23 23",
            //13514724359
            "40 40 31 33 35 31 34 37 32 34 33 35 39 49 50 3A 31 30 2E 31 31 30 2E 35 31 2E 37 23 23",
            "40 40 31 33 35 31 34 38 39 30 38 31 34 49 50 3A 31 30 2E 31 31 30 2E 35 31 2E 31 37 23 23",
            "00 05 32 40 40 31 33 35 31 34 38 39 30 38 31 34 49 50 3A 31 30 2E 31 31 30 2E 35 31 2E 31 37 23 23 AA CC EF"
        };

        private byte[] S
        {
            get { return Utilities.CT.StringToBytes( _s[0], null, Utilities.StringFormat.Hex ); }
        }

        private byte[] S1
        {
            get { return Utilities.CT.StringToBytes( _s[1], null, Utilities.StringFormat.Hex ); }
        }

        private byte[] S2
        {
            get 
            {
                return  Utilities.CT.StringToBytes( 
                      _s[3],
                      null,
                      Utilities.StringFormat.Hex
                      );
            }
        }

		public HeartBeatParserTest()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        [Test]
        public void t_heartBeatParser()
        {
            HeartBeatParser hbp = new HeartBeatParser( S );
            HeartBeat hb = hbp.ToValue() as HeartBeat;
//            Assert.IsNull( hb );
            Assert.IsNotNull( hb );
            Assert.AreEqual( "13500627885", hb.SimNumber );
            Assert.AreEqual( "10.110.51.24", hb.Ip );

            hbp = new HeartBeatParser( S1 );
            hb = hbp.ToValue() as HeartBeat;
            Assert.IsNotNull( hb );
            Assert.AreEqual( "13514724359", hb.SimNumber );
            Assert.AreEqual( "10.110.51.7", hb.Ip );

            hbp = new HeartBeatParser( new byte[] {00,01,01} );
            object obj = hbp.ToValue();
            Assert.IsNull( obj );
        }


        [Test]
        public void t_heartBeatPicker()
        {
            HeartBeatPicker hbp = new HeartBeatPicker();
            byte[][] b2dim = hbp.Pick( S2 );
            Assert.IsNotNull( b2dim );
            Assert.IsNotNull( new HeartBeatParser( b2dim[0] ).ToValue() );
        }
	}
}
