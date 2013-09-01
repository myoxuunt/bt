using System;

namespace Utilities
{

    public enum StringFormat
    {
        Hex,
        Dec,
    }


    public class CT
    {
        private static bool _isWithLength = true;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsWithLength
        {
            get { return _isWithLength; }
            set {_isWithLength = true; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] bytes)
        {
            return BytesToString( bytes, "X2" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string BytesToString( byte[] bytes, string format )
        {
            if ( bytes == null )
            {
                // 2007.02.15 Modify
                //
                //throw new ArgumentNullException("bytes");
                return string.Empty;
            }
            if ( bytes.Length == 0 )
                return string.Empty;

            //string s = string.Empty;
            string s = "[ " + bytes.Length + " ] ";
            for(int i=0; i<bytes.Length; i++)
            {
                s += bytes[i].ToString( format ) + ( ( i != bytes.Length - 1 ) ? " " : "" );
            }

            return s;
        }
        



        private static int GetFromBase( StringFormat format )
        {
            if ( format == StringFormat.Hex )
                return 16;
            else if ( format == StringFormat.Hex )
                return 10;
            else
                throw new ArgumentException( format.ToString() );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToBytes ( string str,  char[] split, StringFormat format )
        {
            string[] items = str.Split( split );
            if ( items == null || items.Length == 0 )
                return null;

            byte[] bs = new byte[ items.Length ];
            for( int i=0; i<items.Length; i++)
            {
                bs[i] = Convert.ToByte(items[i], GetFromBase( format ) );
            }

            return bs;
        }
    }
}
