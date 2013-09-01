using System;
using CFW;
using Utilities;

namespace Communication
{


    // 2007.02.11 replace with commTaskResultProcessor
    //

	/// <summary>
	/// 
	/// </summary>
	public class XGCommTaskResultProcesser
	{
        static private XGCommTaskResultProcesser s_Default = new XGCommTaskResultProcesser();

        static public XGCommTaskResultProcesser Default
        {
            get { return s_Default;}
        }

		public XGCommTaskResultProcesser()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process(object sender, EventArgs e)
        {
            ArgumentChecker.CheckNotNull( sender );
            TaskScheduler sch = (TaskScheduler) sender;
            Task task = sch.ActiveTask;
            ArgumentChecker.CheckNotNull ( task );

            CommCmdBase cmd = task.CommCmd;
            CommResultState commResultState = task.LastCommResultState;

            if ( commResultState != CommResultState.Correct )
            {
                if ( XGConfig.Default.LogCommFail )
                {
                    string s = string.Format( "Send\t\t: {0}, {1}\r\nReceived\t: {2}, {3}\r\nCommResult\t: {4}\r\nCmdType\t\t: {5}\r\n",
                        task.LastSendDateTime, CT.BytesToString( task.LastSendDatas ), 
                        task.LastReceivedDateTime, CT.BytesToString( task.LastReceived),
                        commResultState.ToString(), cmd.GetType().Name );
                    FileLog.CommFail.Add ( s );
                }
                return ;
            }
            
            if ( cmd is ReadRecordCommand )
            {
                ReadRecordCommand readRecordCmd = cmd as ReadRecordCommand;
                ProcessReadRecordCmd( readRecordCmd );
            }

            if ( cmd is ReadTotalCountCommand )
            {
                ReadTotalCountCommand readCountCmd = cmd as ReadTotalCountCommand;
                ProcessReadTotalCountCmd( readCountCmd, task );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessReadRecordCmd( ReadRecordCommand cmd )
        {
            if ( cmd.XGData != null )
            {
                // 2007.03.11 Modify
                //
                //XGDB.InsertXGData ( cmd.XGData );
                XGDB.InsertXGData( cmd.Station.DestinationIP, cmd.XGData );

                XGTask[] matchedXgTasks = Singles.S.XGScheduler.Tasks.MatchXGData( cmd.XGData );
                foreach ( XGTask t in matchedXgTasks )
                {
                    t.IsComplete = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="owningTask"></param>
        /// <remarks>
        /// 可能包含读取并清除本地数据的后续指示(在Task.Tag中)
        /// </remarks>
        private void ProcessReadTotalCountCmd( ReadTotalCountCommand cmd, Task owningTask )
        {
            if ( owningTask.Tag != null )
            {
                object[] tags = owningTask.Tag as object[];
                if ( tags != null && tags.Length == 2 )
                {
                    TagType tagType = (TagType)tags[0];
                    XGTask xgtask = (XGTask) tags[1];


                    //Immediate task strategy 被加到tasks的最前端，所以要先加入，一般在读取完所有的记录后清空。
                    //
                    RemoveAllCommand clearCmd = new RemoveAllCommand( cmd.Station as XGStation );
                    Task clearTask = new Task( clearCmd, new ImmediateTaskStrategy () );
                    clearTask.Tag = xgtask;
                    clearTask.BeforeExecuteTask +=new EventHandler(clearTask_BeforeExecuteTask);
                    Singles.S.TaskScheduler.Tasks.Add( clearTask );

                    for ( int i=0; i<cmd.TotalCount; i++ )
                    {
                        ReadRecordCommand rdcmd = new ReadRecordCommand( cmd.Station as XGStation, i+1 );
                        Task t = new Task(rdcmd, new ImmediateTaskStrategy() );
                        Singles.S.TaskScheduler.Tasks.Add( t );
                    }
                }
            }
        }

        private void clearTask_BeforeExecuteTask(object sender, EventArgs e)
        {
            //RemoveAllCommand c = sender as RemoveAllCommand ;
            Task t = sender as Task;
            ArgumentChecker.CheckNotNull ( t );
            if ( t.Tag != null )
            {
                XGTask xgt = t.Tag as XGTask;
                xgt.ReadLocalXgDataComplete();
            }
        }
    }
}
