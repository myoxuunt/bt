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
        /// 命令的等待时间 (毫秒)
        /// </summary>
        /// <remarks>
        /// 返回数据应该在该时间内传回，到达时间后CommPortProxy会返回接收到的数据
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
        /// 生成通讯 byte[] 命令
        /// </summary>  
        abstract public byte[] MakeCommand();

        /// <summary>
        /// 分析从CommPort返回数据
        /// </summary>
        ///// <param name="station">是哪个站的返回数据</param>
        ///// <param name="parameters">参数数组</param>
        /// <param name="data">返回数据</param>
        /// <returns>返回数据的状态</returns>
        abstract public CommResultState ProcessReceived( byte[] data );

        
        /// <summary>
        /// 获取或设置站点
        /// </summary>
        public Station Station 
        {
            get { return m_Station ; }
            set { m_Station = value; } 
        }
        
    }

}
