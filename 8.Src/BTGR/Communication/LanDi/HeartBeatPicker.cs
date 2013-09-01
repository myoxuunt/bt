using System;

namespace Communication.LanDi
{
	/// <summary>
	/// HeartBeatPicker 的摘要说明。
	/// </summary>
	public class HeartBeatPicker
	{
        /// <summary>
        /// 
        /// </summary>
		public HeartBeatPicker()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public byte[][] Pick( byte[] bs )
        {
            if ( bs == null || bs.Length < LanDiDef.MIN_LENGTH )
                return null;
                
            int headPos = LanDiDef.HEAD.SearchBeginPos( bs );
            if( headPos != -1 )
            {
                int tailPos = LanDiDef.TAIL.SearchBeginPos( bs );
                if ( tailPos != -1 )
                {
                    int len = tailPos - headPos + LanDiDef.TAIL_LENGTH;
                    if ( len >= LanDiDef.MIN_LENGTH )
                    {
                        byte[] hbbs = new byte[len];
                        Array.Copy( bs, headPos, hbbs, 0, len );
                        byte[][] ans = new byte[][] { hbbs };
                        return ans;
                    }
                }
            }

            return null;
        }
	}
}
