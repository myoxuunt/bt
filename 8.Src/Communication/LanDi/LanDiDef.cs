using System;
using Communication;

namespace Communication.LanDi
{
	/// <summary>
	/// LanDiDef 的摘要说明。
	/// </summary>
	public class LanDiDef
	{
        public const byte HEAD_BYTE = 0x40;
        public const byte TAIL_BYTE = 0x23;
        public const int  HEAD_LENGTH = 2;
        public const int  TAIL_LENGTH = 2;

        // 25 = 2 + 2 + 11 + 3 + 4 + 3;
        public const int MIN_LENGTH = 25;

        /// <summary>
        /// @@
        /// </summary>
        public static readonly DataField HEAD = new DataField(
            0,
            2,
            new byte[] {HEAD_BYTE, HEAD_BYTE}
            );

        /// <summary>
        /// ##
        /// </summary>
        public static readonly DataField TAIL = new DataField(
            DataField.UNSURENESS,
            2,
            new byte[] {TAIL_BYTE, TAIL_BYTE}
            );

        /// <summary>
        /// IP:
        /// </summary>
        public static readonly DataField IPSTR = new DataField(
            DataField.UNSURENESS,
            3,
            new byte[] {0x49, 0x50, 0x3A}
            );

		public LanDiDef()
		{
		}
	}
}
