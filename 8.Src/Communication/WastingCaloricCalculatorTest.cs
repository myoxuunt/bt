using System;
using NUnit.Framework;

namespace Communication
{
	/// <summary>
	/// WastingCaloricCalculatorTest 的摘要说明。
	/// </summary>
	/// 
    [TestFixture]
	public class WastingCaloricCalculatorTest
	{
		public WastingCaloricCalculatorTest()
		{
		}

        [Test]
        public void testCalcZeroDataPoint()
        {
            string name = "name";
            GrDataPoint dp1 = new GrDataPoint(
                name,
                DateTime.Parse("2007-10-12 12:00:00"),
                100,
                50,
                1000
                );

            GrDataPoint dp2 = new GrDataPoint(
                name,
                DateTime.Parse("2007-10-13 11:59:59"),
                80,
                40,
                1200
                );

            WastingCaloricCalculator wcc = new WastingCaloricCalculator(DateTime.Parse("2007-10-12"));
            wcc.AddGrDataPoint( dp1 );
            GrDataPoint ans = wcc.CalcZeroDataPoint(dp2);
            Assert.AreEqual( name, ans.StationName );
            Assert.AreEqual( DateTime.Parse( "2007-10-13 0:0:0"), ans.DateTime );
            Assert.AreEqual( 90F, ans.OneGiveTemp, 0.1F );
            Assert.AreEqual( 45F, ans.OneBackTemp , 0.1F );
            Assert.AreEqual( 1100F, ans.OneSum , 0.1F );


            Assert.AreEqual( true, wcc.CanCalcZeroDataPoint( dp2 ) );
            Assert.AreEqual( false, wcc.IsTodayGrDataPoint( dp2 ) );
            Assert.AreEqual( true, wcc.IsNextDayDataPoint( dp2 ) );

            // 1 gr data point
            Assert.AreEqual( 1, wcc.Calc() );

            wcc.AddGrDataPoint( ans );
            Assert.AreEqual( 1, wcc.Calc() );
        }
	}
}
