using System;
using System.Collections;

namespace Communication.GRCtrl
{
	/// <summary>
	/// 分时供温曲线
	/// </summary>
	public class TimeTempLine
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="bs"></param>
		/// <param name="beginIdx"></param>
		/// <returns></returns>
		static public TimeTempLine Parse( byte[] bs, int beginIdx )
		{
			TimeTempLine ttl = new TimeTempLine();
			for( int i=0; i<POINTSIZE; i++ )
			{
				ttl.list[i] = new TimeTempPoint( (byte)(i*2), bs[i+beginIdx] );
			}

			return ttl;
		}

		/// <summary>
		/// 
		/// </summary>
		ArrayList list = new ArrayList();

		/// <summary>
		/// 
		/// </summary>
		private const int POINTSIZE = 12;

		/// <summary>
		/// 
		/// </summary>
		public TimeTempLine()
		{
			for ( int i=0; i<POINTSIZE; i++ )
			{
				
				list.Add ( new TimeTempPoint( (byte)(i*2), 0 ) );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s=string.Empty;
			for( int i=0;i<this.list.Count - 1; i++ )
			{
				s += this.list[i].ToString() + ", ";
			}
			s += this.list[list.Count -1 ].ToString();
			return s;
		}


		/// <summary>
		///  idx - 1-11
		/// </summary>
		/// <param name="idx"></param>
		/// <param name="temp"></param>
		public void SetTemp( int idx, byte temp )
		{
			((TimeTempPoint )this.list[idx]).Temp = temp;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public byte[] GetBytes()
		{
			byte[] bs = new byte[POINTSIZE];
			for( int i=0; i<POINTSIZE; i ++ )
			{
				bs[i] = ((TimeTempPoint)list[i]).Temp ;
			}
			return bs;
		}
	}
}
