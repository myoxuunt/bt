using System;
using NUnit.Framework ;

namespace Communication
{
	/// <summary>
	/// TestFixture 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class TestFixture
	{
		public TestFixture()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        [Test]
        public void test_card()
        {
            Card c1 = new Card("1");
            Card c2 = new Card("2");
            Card c3 = new Card("3");

            CardsCollection cs = new CardsCollection();
            cs.Add(c1);
            cs.Add(c2);
            cs.Add(c3);
           //cs.Add(c3);
Assert.AreEqual( 3, cs.Count );
            c3.SerialNumber = " 2";
        }
	}
}
