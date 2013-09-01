using System;

namespace Communication.GRCtrl
{
	/// <summary>
	/// 
	/// </summary>
	public class TemperatureLinePoint
	{
		private int _outSideTemp,
			_twoGiveTemp;

		public const int MIN_OUTSIDE_TEMPERATURE = -50;

		// 20090902 最大室外温度扩大为20度, 最低二次供温20度
		//
//		private const int MAX_OUTSIDE_TEMPERATURE =  10;
		public const int MAX_OUTSIDE_TEMPERATURE =  20;

//		private const int MIN_TWOGIVE_TEMPERATURE = 40;
		public const int MIN_TWOGIVE_TEMPERATURE = 20;
		public const int MAX_TWOGIVE_TEMPERATURE = 90;

       
		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		static public bool IsValidOutsideTemperature( int val )
		{
			return val >= MIN_OUTSIDE_TEMPERATURE &&
				val <= MAX_OUTSIDE_TEMPERATURE;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		static public bool IsValidTwoGiveTemperature( int val )
		{
			return val >= MIN_TWOGIVE_TEMPERATURE &&
				val <= MAX_TWOGIVE_TEMPERATURE;
		}

		#region TemperatureLinePoint
		/// <summary>
		/// 
		/// </summary>
		/// <param name="outSideTemp"></param>
		/// <param name="twoGiveTemp"></param>
		public TemperatureLinePoint(int outSideTemp, int twoGiveTemp)
		{
			//            if ( !( outSideTemp >= MIN_OUTSIDE_TEMPERATURE &&
			//                outSideTemp <= MAX_OUTSIDE_TEMPERATURE ) )
			//            {
			//                throw new ArgumentOutOfRangeException ( "outSideTemperature" );
			//            }
			//
			//            if ( ! (twoGiveTemp >= MIN_TWOGIVE_TEMPERATURE && 
			//                twoGiveTemp <= MAX_TWOGIVE_TEMPERATURE ) )
			//            {
			//                throw new ArgumentOutOfRangeException ( "twoGiveTemperature");
			//            }

			_outSideTemp = outSideTemp;
			_twoGiveTemp = twoGiveTemp;
		}
		#endregion //TemperatureLinePoint


		#region OutSideTemperature
		/// <summary>
		/// 
		/// </summary>
		public int OutSideTemperature
		{
			get { return _outSideTemp; }
		}
		#endregion //OutSideTemperature


		#region TwoGiveTemperature
		/// <summary>
		/// 
		/// </summary>
		public int TwoGiveTemperature
		{
			get { return _twoGiveTemp; }
		}
		#endregion //TwoGiveTemperature


		#region TemperatureLinePoint
		/// <summary>
		/// 
		/// </summary>
		/// <param name="datas"></param>
		/// <returns></returns>
		static public TemperatureLinePoint Parse ( byte[] datas )
		{
			ArgumentChecker.CheckNotNull( datas );
			if ( datas.Length < 2 )
				throw new ArgumentException ( "datas.length < 2" );
			int outSidetemp = m( datas[0] );
			int twoGiveTemp = m( datas[1] );

			return new TemperatureLinePoint ( outSidetemp, twoGiveTemp );
		}
		#endregion //TemperatureLinePoint


		#region Parse
		/// <summary>
		/// 
		/// </summary>
		/// <param name="linePoint"></param>
		/// <returns></returns>
		static public byte[] Parse ( TemperatureLinePoint linePoint )
		{
			ArgumentChecker.CheckNotNull( linePoint );
			byte[] bs = new byte[2];
			bs[0] = um( linePoint.OutSideTemperature );
			bs[1] = um( linePoint.TwoGiveTemperature );

			return bs;
		}
		#endregion //Parse


		#region m
		/// <summary>
		/// 
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		static private int m( byte b )
		{
			if ( b>127)
				return b-256;
			else
				return b;
		}
		#endregion //m

		#region um
		/// <summary>
		/// 
		/// </summary>
		/// <param name="temp"></param>
		/// <returns></returns>
		static private byte um( int temp )
		{
			if ( temp > 127 || temp < -128 )
				throw new ArgumentOutOfRangeException ( "temp" );

			if ( temp >=0 )
				return (byte)temp;
			else
				return (byte)(temp + 256);
		}
		#endregion //um
	}
		
}
