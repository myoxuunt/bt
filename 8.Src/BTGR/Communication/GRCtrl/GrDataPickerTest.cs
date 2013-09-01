using System;
using NUnit.Framework;
using Communication;
using Utilities;

namespace Communication.GRCtrl
{
	/// <summary>
	/// GrDataPickerTest 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class GrDataPickerTest
	{

		public GrDataPickerTest()
		{
		}

       
        [SetUp]
        public void setup()
        {

        }

        [Test]
        public void t1()
        {
            string s = 
                  "21 58 44 00 A0 20 02 10 00 B9 E6 " 
                + "21 58 44 00 A0 20 02 00 00 B4 26 " 
                + "21 58 44 00 A0 1E 68 00 07 03 0F 10 24 17 03 00 00 34 42 8F C2 F5 3D E1 7A 94 3E A6 D9 FA 40 AF 03 A7 42 AE 62 7A 42 40 D5 37 42 15 A0 22 42 E2 35 0C 3F 4B 5C EA 3E DC 12 DF 3E 63 D5 A9 3E 5A 00 00 00 00 2C A3 8E 43 00 00 00 00 00 00 00 00 00 00 00 00 B9 42 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 31 42 45";
            byte[] bs = CT.StringToBytes( s, new char[]{' '}, StringFormat.Hex );
            GrDataPicker p = new GrDataPicker();
            byte[][] pr = p.Picker( bs );
            Assert.IsTrue( pr != null );
            if ( pr != null )
                Assert.AreEqual(3, pr.Length );

            foreach( byte[] b in pr )
            {
                //System.Windows.Forms.MessageBox.Show( b.Length.ToString() + "\r" + BitConverter.ToString( b ) );
                Assert.IsTrue( CRC16.CheckCrc( b ) );
            }
        }

        [Test]
        public void t_grRealDataParse()
        {
            string s = "21 58 44 00 A0 1E 68 00 07 03 0F 10 24 17 03 00 00 34 42 8F C2 F5 3D E1 7A 94 3E A6 D9 FA 40 AF 03 A7 42 AE 62 7A 42 40 D5 37 42 15 A0 22 42 E2 35 0C 3F 4B 5C EA 3E DC 12 DF 3E 63 D5 A9 3E 5A 00 00 00 00 2C A3 8E 43 00 00 00 00 00 00 00 00 00 00 00 00 B9 42 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00 00 00 00 31 42 45";
            byte[] bs = CT.StringToBytes( s, null, StringFormat.Hex );
            GrRealDataParser t = new GrRealDataParser( bs );
            object obj = t.ToValue();
            Assert.IsNotNull( obj );
            GRRealData rd = obj as GRRealData;

            Assert.AreEqual( CFW.CommResultState.Correct, t.CommResultState );
            //Assert.AreEqual( rd.DT, DateTime.Parse("2007-09-09 1:2:3"));

            t.Bytes = null;
            obj = t.ToValue();
            Assert.IsNull( obj );
            Assert.AreEqual( CFW.CommResultState.NullData, t.CommResultState );
        }
	}
}
