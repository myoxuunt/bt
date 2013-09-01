namespace Communication
{
    using System;
    using System.IO;

    #region FileLog
    /// <summary>
    /// FileLog 的摘要说明。
    /// </summary>
    public class FileLog
    {
        string m_Path;
        System.IO.StreamWriter m_SW = null; 

        public static FileLog CommFail  = new FileLog( "commFail.log" );
        public static FileLog CommIO    = new FileLog( "commIO.log" );
        public static FileLog CommARD   = new FileLog( "commArd.log" );

        public FileLog() : this(".\\Log\\default.log")
        {
        }

        public FileLog(string path)
        {
            this.m_Path = path;
        }

        private void OpenLogFile()
        {
            m_SW = File.AppendText(m_Path);
        }
		
        public void Add(string str)
        {
            if (m_SW == null) 
                OpenLogFile();

            //m_SW.WriteLine ( System.DateTime.Now );
            m_SW.WriteLine ( str );
            m_SW.Flush();
        }

        public void Add(string str1, string str2)
        {
            if ( m_SW == null )
                OpenLogFile();

            m_SW.WriteLine ( "[" + System.DateTime.Now + "]: " + str1 + ": " + str2 );
            m_SW.WriteLine ( str1 + ": " + str2 );
            m_SW.Flush();
        }

        public void Close()
        {
            if ( m_SW != null )
            {
				
                m_SW.Close();
                //m_SW = null;
            }
        }

        //~FileLog()
        //{
        //    Close();
        //}
    }
    #endregion //FileLog
}