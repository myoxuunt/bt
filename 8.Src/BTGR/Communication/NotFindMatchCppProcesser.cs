

namespace Communication
{
    using System;
    using CFW;

    #region NotFindMatchCppProcesser
	/// <summary>
	/// NotFindMatchCppProcesser 的摘要说明。
	/// </summary>
	public class NotFindMatchCppProcesser
	{
        private static NotFindMatchCppProcesser s_default = new NotFindMatchCppProcesser();

        public static NotFindMatchCppProcesser Default
        {
            get { return s_default; }
        }

        /// <summary>
        /// 采集时候没有找到匹配的GPRS站点的ip地址时，在此处处理
        /// </summary>
		public NotFindMatchCppProcesser()
		{
		}

        public void Process ( object sender, EventArgs e )
        {
            TaskScheduler sch = (TaskScheduler)sender;
            Task act = sch.ActiveTask;
            CommCmdBase cmd = act.CommCmd;
            Station st = cmd.Station;
            string remoteIP = st.DestinationIP;
            string s =  "DateTime   : " + DateTime.Now + Environment.NewLine;
            s +=        "Not find IP: " + remoteIP + Environment.NewLine;
            s +=        "cmd        : " + cmd.GetType().Name + Environment.NewLine;
            s +=        "stationName: " + st.StationName + Environment.NewLine;
            s += Environment.NewLine;

//            frmLogs.Default.AddLog( s );
            if ( XGConfig.Default.ShowLogForm ) 
            {
                frmLogs.Default.AddLogRemoteIP( s );
            }

            // refreash run state
            //
            frmGprsCollState.Default.RunState = s ;
        }
	}
    #endregion //NotFindMatchCppProcesser
}
