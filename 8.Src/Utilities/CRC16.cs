using System;

namespace Utilities
{
    /// <summary>
    /// CRC16
    /// </summary>
    public class CRC16
    {
        private CRC16()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pByte"></param>
        /// <param name="nNumberOfBytes"></param>
        /// <param name="pChecksum"></param>
        public static void CalculateCRC(byte [] pByte, int nNumberOfBytes, out ushort pChecksum)
        {
            int nBit;
            ushort nShiftedBit;
            pChecksum = 0xFFFF;

            for (int nByte = 0; nByte < nNumberOfBytes; nByte++)
            {
                pChecksum ^= pByte[nByte];

                for (nBit = 0; nBit < 8; nBit++)
                {
                    if((pChecksum & 0x1) == 1)
                    {
                        nShiftedBit = 1;
                    }
                    else
                    {
                        nShiftedBit = 0;
                    }

                    pChecksum >>= 1;
                    if(nShiftedBit != 0)
                    {
                        pChecksum ^= 0xA001;
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pByte"></param>
        /// <param name="nNumberOfBytes"></param>
        /// <param name="hi"></param>
        /// <param name="lo"></param>
        public static void CalculateCRC( byte[] pByte, int nNumberOfBytes, out byte hi, out byte lo)
        {
            ushort sum;
            CRC16.CalculateCRC( pByte, nNumberOfBytes, out sum );
            lo = (byte) (sum & 0xFF);
            hi = (byte) ( (sum & 0xFF00) >> 8 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pByte"></param>
        /// <returns></returns>
        public static bool CheckCrc( byte[] pByte )
        {
            if ( pByte == null || pByte.Length <= 2 )
                return false;

            byte hi, lo;
            CalculateCRC( pByte, pByte.Length - 2, out hi, out lo );

            return pByte[ pByte.Length - 1 ] == hi &&
                pByte[ pByte.Length - 2 ] == lo;
        }
    }
}
