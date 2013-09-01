namespace CFW
{
    #region Utility
    /// <summary>
    /// 
    /// </summary>
    public class Utility
    {
        public static string EnsureNotNull(string str)
        {
            return str == null ? string.Empty : str;
        }

        /// <summary>
        /// �����ִ�Сд����������β�ո��ַ����Ƚ�
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="ignoreCase">���Դ�Сд</param>
        /// <param name="trim">�Ƴ����пո�</param>
        /// <returns></returns>
        public static bool Equals(string s1, string s2, bool ignoreCase, bool trim)
        {
            if (trim)
            {
                if ( s1 != null )
                    s1 = s1.Trim();
                if ( s2 != null )
                    s2 = s2.Trim();

            }

            return string.Compare( s1, s2, ignoreCase ) == 0;
        }


        public static byte[] ConvertStringToBytes(string str)
        {
            char[] chars = str.ToCharArray();
            byte[] bytes = new byte[chars.Length];

            for (int i=0; i<chars.Length; i++)
            {
                bytes[i] = (byte)chars[i] ;
            }
            return bytes;
        }
    }
    #endregion //Utility

}
