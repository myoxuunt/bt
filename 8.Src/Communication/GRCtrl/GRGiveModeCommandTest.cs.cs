using System;
using NUnit.Framework;
using CFW;
using Utilities;
namespace Communication.GRCtrl
{
	/// <summary>
	/// GRGiveModeCommandTest 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class GRGiveModeCommandTest
	{
        private GRStation grst = new GRStation("a",0,"1.0.0.1");
		public GRGiveModeCommandTest()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        [Test]
        public void t1()
        {
            GRReadGiveModeCommand cmd = new GRReadGiveModeCommand( grst );
            byte[] bscmd = cmd.MakeCommand();
            Assert.IsNotNull( bscmd );
            Assert.AreEqual( 10, bscmd.Length );

            string s = "21 58 44 00 A0 14 0A 47 01 00 00 00 00 06 07 08 09 1e bb";
            byte[] bsrece = new byte[] {
                                       };

            bsrece = Utilities.CT.StringToBytes( s, null, StringFormat.Hex );

            CommResultState r = cmd.ProcessReceived( bsrece );
            Assert.AreEqual( CommResultState.Correct, r );
            Assert.AreEqual( GiveTempMode.TempLine, cmd.GiveTempMode );
            Assert.AreEqual( 0, cmd.GiveTempValue );
        }

        [Test]
        public void t2()
        {
            GRWriteGiveModeCommand cmd = new GRWriteGiveModeCommand( grst,
                GiveTempMode.TempLine,
                55.32F
                );

            byte[] bssend = cmd.MakeCommand();
            System.Diagnostics.Debug.Fail( BitConverter.ToString(bssend) );
            
        }
	}
}
