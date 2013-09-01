namespace Communication
{
    using System;
    using CFW;

    #region GCRQProcesser
	/// <summary>
	/// GPRS connection require processor
	/// </summary>
	public class GCRQProcesser
	{
        private static GCRQProcesser s_default = new GCRQProcesser();

        /// <summary>
        /// 
        /// </summary>
        public static GCRQProcesser Default
        {
            get { return s_default; }
        }

        /// <summary>
        /// 
        /// </summary>
		public GCRQProcesser()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process( object sender, EventArgs e )
        {
            WSListen listen = (WSListen)sender;
            CommPortProxy cpp = listen.LastConnection;
            string remoteIP = cpp.RemoteHostIP;
            RemoveExist( Singles.S.TaskScheduler.CppsCollection, remoteIP );
            
            Singles.S.TaskScheduler.CppsCollection.Add( cpp );
//            frmLogs.Default.AddLog( "accept conn " + remoteIP );
            frmLogs.Default.AddLogRemoteIP( 
                DateTime.Now.ToString() + " accept conn : " + remoteIP );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpps"></param>
        /// <param name="remoteIP"></param>
        private void RemoveExist( CommPortProxysCollection cpps, string remoteIP )
        {
            ArgumentChecker.CheckNotNull ( cpps );
            //foreach( CommPortProxy c in cpps )

            bool removed = true;
            while( removed )
            {
                removed = false;

                for ( int i=0; i<cpps.Count; i++)
                {
                    CommPortProxy c = cpps[i];
                    if ( c.RemoteHostIP == remoteIP )
                    {
                        c.Close();
                        cpps.RemoveAt( i );
                        removed = true;
                        break;
                    }
                }
            }
        }
	}
    #endregion //GCRQProcesser
}
