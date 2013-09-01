#define USEWINSOCK
#if USEWINSOCK
using System;
using System.Runtime.Serialization;
using System.Diagnostics;
using Infragistics.Shared;
using System.Windows.Forms;

namespace CFW
{
    #region TaskScheduler with winsock
    [Serializable]
    // 2007.02.11
    //
    //public class TaskScheduler : ISerializable
    public class TaskScheduler : SubObjectBase, ISerializable
    {
        #region Private Members
        
        /// <summary>
        /// Task 集合
        /// </summary>
        private TasksCollection m_Tasks             = null;

        // 2007.05.30
        //
        ///// <summary>
        ///// 命令由该CommPort发送
        ///// </summary>
        //private CommPortProxy   m_CommPortProxy     = null;

        

        /// <summary>
        /// 当前正在执行的Task
        /// </summary>
        private Task            m_ActiveTask        = null;

        /// <summary>
        /// 默认扫描间隔100毫秒
        /// </summary>
        private const int		DEFAULT_INTERVAL	= 100;

        /// <summary>
        /// 
        /// </summary>
        private Timer           m_SchedulerTimer    = null;

        /// <summary>
        /// Scheduler 
        /// </summary>
        public event System.EventHandler Executing   = null;
        
        /// <summary>
        /// 
        /// </summary>
        public event System.EventHandler Executed   = null;
        
        // 2007.02.02 Removed
        //
        ///// <summary>
        ///// 当前正在执行的Task在m_Tasks中的索引号
        ///// </summary>
        //private int             m_ActiveTaskIndex   = -1;

        // 2007.05.30
        //
        //private System.EventHandler m_ReceiveCompleteHandler = null;
 


        // 2007.02.23 Added NotFindMatchCpp event, 
        // if not find CPP in _cppsCollection raise the event.
        // can use ActiveTask.Cmd.Station.IP find the ip
        //
        public event System.EventHandler NotFindMatchCPPEvent;

        private CommPortProxysCollection    _cppsCollection = null;

        // 2007-12-18
        // 60 -> 20
        private static readonly TimeSpan DEFAULT_MAX_TASK_EXECUTE_TIMESPAN = new TimeSpan( 0,0,0,20,0 );
        /// <summary>
        /// 任务最大执行时间
        /// </summary>
        private TimeSpan _maxTaskExecuteTimespan = DEFAULT_MAX_TASK_EXECUTE_TIMESPAN;

     
        #endregion Private Membersr

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commPortProxy"></param>
        public TaskScheduler (CommPortProxy commPortProxy)
            : this ( commPortProxy, DEFAULT_INTERVAL )
        {
        }

        public TaskScheduler( CommPortProxysCollection cpps ,  int interval )
        {
            if ( cpps == null )
                throw new ArgumentNullException ("cpps");
            if ( interval < DEFAULT_INTERVAL)
                throw new ArgumentException( "interval too small" );

            _cppsCollection = cpps;
            m_SchedulerTimer = new Timer();
            m_SchedulerTimer.Interval = interval;
            m_SchedulerTimer.Tick +=new EventHandler(SchedulerTimer_Tick);

            //cpps.ReceiveARDEvent +=new ReceiveARDHandler(cpps_ReceiveARDEvent);
            cpps.ReceiveTimeOutEvent +=new ReceiveTimeOutEventHandler(cpps_ReceiveTimeOutEvent);
        }
        public TaskScheduler (CommPortProxy commPortProxy, int interval)
        {
            //System.Diagnostics.Debug.Assert (commPortProxy != null, "commPortProxy can't is null.");
            if (commPortProxy == null)
                throw new ArgumentNullException ("commPortProxy", SR.GetString("LE_CommPortProxyNull"));

            m_SchedulerTimer = new Timer();
            m_SchedulerTimer.Interval = interval;
            m_SchedulerTimer.Tick +=new EventHandler(SchedulerTimer_Tick);
            CommPortProxy = commPortProxy;
        }

        protected TaskScheduler (SerializationInfo info, StreamingContext context)
        {
            //foreach (SerializationEntry entry in info )
            //{
            //    switch(entry.Name)
            //    {
            //        case "Tasks":
            //            this.m_Tasks = (TasksCollection)entry.Value;
            //            if ( m_Tasks != null)
            //            {
            //                m_Tasks.SubObjectPropChanged +=new Infragistics.Shared.SubObjectPropChangeEventHandler(m_Tasks_SubObjectPropChanged);
            //            }
            //            break;
            //
            //        case "CommPortProxy":
            //            this.m_CommPortProxy = (CommPortProxy)entry.Value;
            //            this.m_CommPortProxy.ReceiveComplete +=ReceiveCompleteHandler;
            //
            //            break;
            //
            //        case "SchedulerInterval":
            //            m_SchedulerTimer = new Timer();
            //            m_SchedulerTimer.Interval = Convert.ToInt32(entry.Value);
            //            m_SchedulerTimer.Tick +=new EventHandler(SchedulerTimer_Tick);
            //            break;
            //
            //        default:
            //            throw new SerializationException( entry.Name + " " + entry.Value);
            //    }
            //}
        }
        #endregion Constructors

        #region ISerializable 成员

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue( "Tasks", m_Tasks);
            //info.AddValue( "CommPortProxy", m_CommPortProxy);
            //info.AddValue( "SchedulerInterval", this.m_SchedulerTimer.Interval);
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// 获取或设置一个值，该值指示Scheduler是否正在运行
        /// </summary>
        public bool Enabled
        {
            get { return this.m_SchedulerTimer.Enabled; }

            set
            {
                if ( value )
                {
                    //if (!m_CommPortProxy.IsOpen)
                    //{
                    //    throw new InvalidOperationException(SR.GetString("LE_StartScheduler"));
                    //}
                }
                this.m_SchedulerTimer.Enabled = value;
            }
        }

        /// <summary>
        /// 获取或设置Scheduler的扫描时间间隔
        /// </summary>
        public int Interval
        {
            get { return m_SchedulerTimer.Interval;}
            set { m_SchedulerTimer.Interval = value; }
        }


        /// <summary>
        /// 获取活动的Task,如果没有Task处于活动状态则返回null.
        /// </summary>
        public Task ActiveTask
        {
            get{ return m_ActiveTask ; }
        }

        public CommPortProxysCollection CppsCollection
        {
            get { return _cppsCollection; }
        }


        /// <summary>
        /// 一个任务的最大执行时间，当该任务的执行时间超过该值时，activeTask会被释放
        /// </summary>
        /// <remarks>
        /// 解决activeTask有时不被释放导致其他任务不能被执行问题。
        /// </remarks>
        public TimeSpan MaxTaskExecuteTimespan
        {
            get { return _maxTaskExecuteTimespan; }
            set 
            {
                if ( value < DEFAULT_MAX_TASK_EXECUTE_TIMESPAN )
                    throw new ArgumentOutOfRangeException( "MaxTaskExecuteTimespan", value.ToString() );

                _maxTaskExecuteTimespan = value; 
            }
        }
        #endregion

        #region Tasks
        /// <summary>
        /// 
        /// </summary>
        public TasksCollection Tasks
        {
            get 
            {
                if (m_Tasks == null)
                {
                    m_Tasks = new TasksCollection(this);
                    m_Tasks.SubObjectPropChanged +=new Infragistics.Shared.SubObjectPropChangeEventHandler(m_Tasks_SubObjectPropChanged);
                }
                return m_Tasks ;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Tasks");

                if (value == this.m_Tasks)
                    return;

                if (value.Owning != null )
                    throw new ArgumentException(SR.GetString("LE_TasksOwningNotNull"), "Tasks");
                
                if (m_Tasks != null)
                {
                    m_Tasks.Owning = null;
                    m_Tasks.SubObjectPropChanged -= new Infragistics.Shared.SubObjectPropChangeEventHandler(m_Tasks_SubObjectPropChanged);
                }
                
                m_Tasks = value;
                m_Tasks.Owning = this;
                m_Tasks.SubObjectPropChanged += new Infragistics.Shared.SubObjectPropChangeEventHandler(m_Tasks_SubObjectPropChanged);
            }
        }

        #endregion //Tasks

        #region CommPortProxy Canceled
        /// <summary>
        /// 
        /// </summary>
        public CommPortProxy CommPortProxy
        {
            get 
            {
                //return this.m_CommPortProxy;
                throw new NotImplementedException("commport proxy");
            }
            set 
            {
                //Debug.Assert (value != null, "commPortProxy can't is null.");
                //if (value == null)
                //    throw new ArgumentNullException ("CommPortProxy",SR.GetString("LE_CommPortProxyNull"));
                //
                //if (this.m_SchedulerTimer.Enabled)
                //    throw new InvalidOperationException(SR.GetString("LE_SetCommPortProxy"));
                //
                //if ( m_CommPortProxy != value )
                //{
                //    if (m_CommPortProxy != null)
                //        m_CommPortProxy.ReceiveComplete -= ReceiveCompleteHandler;
                //
                //    m_CommPortProxy = value;
                //    m_CommPortProxy.ReceiveComplete += ReceiveCompleteHandler;
                //}
                throw new NotImplementedException("commport proxy");
            }
        }
        #endregion //CommPortProxy Canceled

 
        #region Public Methods

        #region FindNeedExecuteTask
        /// <summary>
        /// 查找需要执行的Task
        /// </summary>
        /// <returns>找到则返回需要执行的Task, 否则返回null</returns>
        /// <remarks>
        /// 如果有Task正在执行,返回null
        /// </remarks>
        public Task FindNeedExecuteTask()
        { 
            // 2007.03.04 check m_active not overflow max task execute time
            //
            //if ( m_ActiveTask != null )
            //return null;
            if ( m_ActiveTask != null )
            {
                TimeSpan executedTimeSpan = DateTime.Now - m_ActiveTask.LastExecute ;

                if ( executedTimeSpan <= MaxTaskExecuteTimespan )
                    return null;
            }
            
            if ( m_Tasks == null || m_Tasks.Count == 0 )
                return null;

            int count = m_Tasks.Count;
            for ( int i=0; i<count; i++ )
            {
                Task first = m_Tasks[0];
                m_Tasks.RemoveAt( 0 );

                if ( first.NeedExecute() )
                {
                    this.m_ActiveTask = first;
                    if ( !first.CanRemove )
                        this.Tasks.Add( first );
                    return first;
                }
                else
                {
                    if (first.CanRemove)
                    {
                        // remove the task
                    }
                    else
                    {
                        // add the task to end
                        //
                        m_Tasks.Add( first );
                    }

                }
            }
            return null;
        }
        #endregion //FindNeedExecuteTask

       
        #endregion //Public Methods
        
        #region Protected Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected virtual void OnReceiveComplete(object sender, System.EventArgs e)
        //{
        //    Debug.Assert (m_ActiveTask != null, "m_ActiveTask null");
        //    m_ActiveTask.ProcessReceived ( m_CommPortProxy.ReceiveData );
        //
        //    if ( Executed != null )
        //        Executed( this, EventArgs.Empty);
        //
        //    // 2007.02.23 Move to findNeedExecuteTask        
        //    //
        //    //if ( !m_ActiveTask.CanRemove )
        //    //    this.m_Tasks.Add( m_ActiveTask );
        //
        //    m_ActiveTask = null;
        //}
        #endregion //Protected Methods

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        //private System.EventHandler ReceiveCompleteHandler
        //{
        //    get
        //    {
        //        if (m_ReceiveCompleteHandler == null)
        //            m_ReceiveCompleteHandler = new System.EventHandler( OnReceiveComplete );
        //        return m_ReceiveCompleteHandler;
        //    }
        //}



        /// <summary>
        /// 
        /// </summary>
        /// <param name="propChange"></param>
        private void m_Tasks_SubObjectPropChanged(Infragistics.Shared.PropChangeInfo propChange)
        {
            switch ( (PropertyIds)propChange.PropId )
            {
                case PropertyIds.Tasks :
                    TasksChanged(propChange.Trigger);
                    break;
            }
        }

        private void TasksChanged( PropChangeInfo propChange )
        {
            switch ((PropertyIds)propChange.PropId )
            {
                case PropertyIds.Add :
                    //propChange.Source as Task;
                    break;

                case PropertyIds.Insert:
                    break;

                case PropertyIds.Clear :
                    break;
                
                case PropertyIds.Remove :
                    //?? remove item pos
                    
                    break;

            }
        }
        

        private void SchedulerTimer_Tick(object sender, EventArgs e)
        {
            ScanExecute();
        }

        /// <summary>
        /// 查找需要执行的任务，并执行
        /// </summary>
        private void ScanExecute() 
        {
            Task needExecTask = FindNeedExecuteTask();
            if ( needExecTask != null )
            {
                if ( Executing != null )
                {
                    EventHandler temp = Executing;
                    temp( this, EventArgs.Empty );
                }
                //{

                // 2007.02.23 modify
                //
                //needExecTask.Execute( m_CommPortProxy );
                CommCmdBase cmd = needExecTask.CommCmd;
                Debug.Assert( cmd != null );
                    
                Station st = cmd.Station;
                Debug.Assert ( st != null );
                    
                // use ip
                //
                if( st.IsUseIP )
                {
                    string ip = st.DestinationIP;
                    // TODO: 2007-10-18 Search cpp use ip or simNumber
                    //
                    // search commPortProxy match ip
                    //
                    CommPortProxy cpp = SearchCPP( ip );
                    if ( cpp != null )
                    {
                        needExecTask.Execute( cpp );
                    }
                    else
                    {
                        // not find match cpp
                        //
                        // TODO: raise not find cpp event
                        //
                        if ( this.NotFindMatchCPPEvent != null )
                        {
                            EventHandler temp = NotFindMatchCPPEvent;
                            temp( this, EventArgs.Empty );
                        }
                        needExecTask.LastExecute = DateTime.Now ;
                        Debug.Assert( m_ActiveTask != null,"at not find match ip cpp, m_activeTask == null" );
                        m_ActiveTask = null;
                    }
                }
                // use commport
                //
                else
                {
                    //CommPortProxy cpp;
                    //needExecTask.Execute( cpp );
                    Debug.Fail( "need use IP" );
                }
                //}
            }
        }


        /// <summary>
        /// 查找匹配ip的CommPortProxy
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private CommPortProxy SearchCPP( string ip )
        {
            for ( int i=0; i<_cppsCollection.Count; i++ )
            {
                CommPortProxy cpp = _cppsCollection[i];
                if ( cpp.RemoteHostIP == ip )
                {
                    return cpp;
                }
            }

            return null;
        }
        #endregion //Private Methods

        #region cpps_ReceiveTimeOutEvent
        private void cpps_ReceiveTimeOutEvent(object sender, ReceiveTimeOutEventArgs args)
        {
            CommPortProxy cpp = args.Source;
            byte[] datas = args.Datas;

            // 2007.03.16 Removed 
            //
            //Debug.Assert (m_ActiveTask != null, "m_ActiveTask null");

            // 2007.03.04 Added check m_activeTask != null
            //
            if ( m_ActiveTask != null )
            {
                m_ActiveTask.ProcessReceived( datas );
                if ( Executed != null )
                {
                    EventHandler temp = Executed;
                    temp( this, null );
                }

                m_ActiveTask = null;
            }
        }
        #endregion //cpps_ReceiveTimeOutEvent
    }
    #endregion //TaskScheduler with winsock
}
#endif
