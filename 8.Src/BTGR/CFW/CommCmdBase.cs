namespace CFW
{



    public abstract class CommCmdBase: Infragistics.Shared.SubObjectBase 
    {

        public const int DEFAULT_LATENCY_TIME  =        9000;//150;
        private Station         m_Station           = null;
        // 2007.03.05 Removed
        //
        //private object[]        m_Parameters        = null;

        protected CommCmdBase ()
        {
        }
        
        /// <summary> 
        /// ����ĵȴ�ʱ�� (����)
        /// </summary>
        /// <remarks>
        /// ��������Ӧ���ڸ�ʱ���ڴ��أ�����ʱ���CommPortProxy�᷵�ؽ��յ�������
        /// </remarks>
        /// 
        virtual public int LatencyTime
        {
            get 
            {
                return DEFAULT_LATENCY_TIME;
            }
        }

        /// <summary>
        /// ����ͨѶ byte[] ����
        /// </summary>  
        abstract public byte[] MakeCommand();

        /// <summary>
        /// ������CommPort��������
        /// </summary>
        ///// <param name="station">���ĸ�վ�ķ�������</param>
        ///// <param name="parameters">��������</param>
        /// <param name="data">��������</param>
        /// <returns>�������ݵ�״̬</returns>
        abstract public CommResultState ProcessReceived( byte[] data );

        
        /// <summary>
        /// ��ȡ������վ��
        /// </summary>
        public Station Station 
        {
            get { return m_Station ; }
            set { m_Station = value; } 
        }
        
    }

}
