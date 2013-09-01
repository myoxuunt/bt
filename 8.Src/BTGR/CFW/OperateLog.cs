namespace CFW
{
    #region OperationLog
    /// <summary>
    /// 
    /// </summary>
    public class OperationLog: TimeSubObjectBase   
    {
        private string m_Content = null;

        // 2006.12.20 Added m_Operation and m_Remark
        //
        private string m_Operation;
        private string m_Remark;

        public OperationLog (string content)
            : this( string.Empty, content, string.Empty)
        {
        }

        public OperationLog(string operation, string content)
            : this( operation, content, string.Empty )
        {
        }

        public OperationLog(string operation, string content, string remark)
        {
            m_Operation = operation;
            m_Content = content;
            m_Remark = remark;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return m_Content; }
            set { m_Content = Utility.EnsureNotNull( value ); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Operation
        {
            get
            {
                return m_Operation;
            }
            set
            {
                m_Operation = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }
    }
    #endregion //OperationLog
}
