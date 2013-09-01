

namespace Communication
{
	
    using System;
    using CFW;
    using Communication.GRCtrl;

    #region TaskExecutingProcessor
    /// <summary>
    /// 
    /// </summary>
    public class TaskExecutingProcessor
    {
        #region Members
        /// <summary>
        /// 
        /// </summary>
        private static TaskExecutingProcessor s_default = new TaskExecutingProcessor();
        #endregion //Members

        #region Default
        /// <summary>
        /// 
        /// </summary>
        public static TaskExecutingProcessor Default 
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public TaskExecutingProcessor ()
        {
        }
        #endregion //Constructor

        #region Process
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process ( object sender, EventArgs e )
        {
            TaskScheduler sch = sender as TaskScheduler;
            Task actTask = sch.ActiveTask ;
            CommCmdBase cmd = actTask.CommCmd;
            if ( Singles.S.CollStateDisPlay != null )
                Singles.S.CollStateDisPlay.Text = GetDisplayText( cmd );
            
        }
        
        #endregion //Process

        #region GetDisplayText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private string GetDisplayText ( CommCmdBase cmd )
        {
            return CommCmdText.GetCommCmdText( cmd );
        }
        #endregion //GetDisplayText

//        #region IsConnected
//        /// <summary>
//        /// 检查是否已经和指定的站点建立了连接
//        /// </summary>
//        /// <param name="stName"></param>
//        /// <returns></returns>
//        private bool IsConnected( string ip )
//        {
//            CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;
//            foreach ( CommPortProxy c in cpps )
//            {
//                if ( c.RemoteHostIP == ip &&
//                    c.IsConnected )
//                    return true;
//            }
//            return false;
//        }
//        #endregion //IsConnected
    }
    #endregion //TaskExecutingProcessor
}
