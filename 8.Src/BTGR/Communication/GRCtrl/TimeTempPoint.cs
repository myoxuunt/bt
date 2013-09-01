using System;

namespace Communication.GRCtrl
{
	/// <summary>
	/// TimeTempPoint 的摘要说明。
	/// </summary>
	public class TimeTempPoint
	{
		/// <summary>
		/// 
		/// </summary>
		public TimeTempPoint( byte h, byte t)
		{
			// h == 0, 2, 4 ... 11
			//
			_hour = h;

//			if( t < TemperatureLinePoint.MIN_TWOGIVE_TEMPERATURE ||
//				t > TemperatureLinePoint.MAX_TWOGIVE_TEMPERATURE  )
//				throw new ArgumentOutOfRangeException("t", t, 
//					string.Format("temperature must in [20,90]"));
			_temp = t;
		}

		/// <summary>
		/// 
		/// </summary>
		public byte Hour 
		{
			get { return _hour; }
			set { _hour = value; }
		} private byte _hour; 

		/// <summary>
		/// 
		/// </summary>
		public byte Temp
		{
			set { _temp = value; }
			get { return _temp; }
		} private byte _temp;


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("[{0}-{1}]:{2}", this.Hour , this.Hour + 2, this.Temp );
		}

	}
}
