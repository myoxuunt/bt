namespace CFW
{
    #region ErrorData
    /// <summary>
    /// 
    /// </summary>
    public class ErrorData: TimeSubObjectBase
    {
        private string m_ErrorDescription = null;

        public ErrorData()
            : base()
        {
            
        }

        public ErrorData(string errorDescription)
            : base()
        {
            m_ErrorDescription = Utility.EnsureNotNull( errorDescription );
        }


        

        public string ErrorDescription
        {
            get { return m_ErrorDescription; }
            set { m_ErrorDescription = Utility.EnsureNotNull( value ); }
        }

    }

    #endregion //ErrorData
}
