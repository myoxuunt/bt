using System;
using NUnit.Framework;
using Utilities;

namespace Communication
{
	/// <summary>
	/// FreeDataProcessorTest 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class FreeDataProcessorTest
	{
		public FreeDataProcessorTest()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        // 10.110.51.3 - 呼5防疫站
        //
        private string _fromIP = "10.110.51.3";

        // s1 - a gr realdata
        //
        private string _s1 = "21 58 44 00 A0 1E 68 00 07 03 0F 10 24 17 03 00 00 34 42 8F C2 F5 3D E1 7A 94 3E A6 D9 FA 40 AF 03 A7 42 AE 62 7A 42 40 D5 37 42 15 A0 22 42 E2 35 0C 3F 4B 5C EA 3E DC 12 DF 3E 63 D5 A9 3E 5A 00 00 00 00 2C A3 8E 43 00 00 00 00 00 00 00 00 00 00 00 00 B9 42 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 31 42 45";
        // s2 - a xg data 
        //
        private string _s2 = "21 58 44 00 B0 07 10 00 01 43 31 18 12 02 07 02 74 83 B7 00 00 00 AC 76 D1";
        // s3 - other unvaild data 
        //
        private string _s3 = "02 fd 9e 08 09";

        private byte[] GetBytesS1()
        {
            return Utilities.CT.StringToBytes( _s1, null, Utilities.StringFormat.Hex );
        }

        private byte[] GetBytesS2()
        {
            return Utilities.CT.StringToBytes( _s2, null, Utilities.StringFormat.Hex );
        }

        private byte[] GetBytesS3()
        {
            return Utilities.CT.StringToBytes( _s3, null, Utilities.StringFormat.Hex );
        }
        
        private byte[] GetBytesS1S2()
        {
            string s = _s1 + " " + _s2 + " " + _s3;
            return Utilities.CT.StringToBytes( s, null, Utilities.StringFormat.Hex );
        }

        [Test]
        public void t()
        {
            FreeDataProcessor.Default.Process( _fromIP, GetBytesS1S2() );
        }
	}
}
