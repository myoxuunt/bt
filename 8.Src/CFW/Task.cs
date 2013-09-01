using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Infragistics.Shared;

namespace CFW
{
    #region Task
    /// <summary>
    /// 
    /// </summary>
    // 2006.10.23 Changed, Inherit from KeyedSubObjectBase for add task Name field.
    //
    //public class Task: Infragistics.Shared.SubObjectBase 
    [Serializable]
    public class Task: Infragistics.Shared.KeyedSubObjectBase ,ISerializable
    {

        #region Private Members

        // 2006.12.15 Added m_LastSendTime, m_LastSendData，m_LastReceivedTime
        //
        /// <summary>
        /// 最后一次发送命令的时间
        /// </summary>
        private DateTime        m_LastSendDateTime      = DateTime.MinValue;

        /// <summary>
        /// 最后一次接收数据的时间
        /// </summary>
        private DateTime        m_LastReceivedDateTime  = DateTime.MinValue;

        /// <summary>
        /// 最后一次发送的数据
        /// </summary>
        private byte[]          m_LastSendDatas     = null;

        // 2006.10.23 Added
        //
        //private string          m_Name              = null;
        private TaskStrategy    m_TaskStrategy      = null;
        private CommCmdBase     m_CommCmd           = null;

        // 2006.11.13 Added
        //
        private string          m_Description       = null;
        
        /// <summary>
        /// 最后一次执行该Task的时间
        /// </summary>
        private DateTime        m_LastExecute       = DateTime.MinValue ;

        /// <summary>
        /// 保存最后一次的通讯的结果
        /// </summary>
        private CommResultState m_LastCommResultState   = CommResultState.UnknownError ;

        /// <summary>
        /// 保存最后一次通讯接收的数据
        /// </summary>
        private byte[]          m_LastReceived          = null;

        #endregion //Private Members

        #region Events

        protected       EventHandler    m_BeforeExecuteTaskDelegate     = null;
        protected       EventHandler    m_AfterExecuteTaskDelegate      = null;

        protected       EventHandler    m_BeforeProcessReceivedDelegate = null;
        protected       EventHandler    m_AfterProcessReceivedDelegate  = null;


        public event EventHandler BeforeExecuteTask
        {
            add 
            {
                m_BeforeExecuteTaskDelegate += value;
            }
            remove
            {
                m_BeforeExecuteTaskDelegate -= value;
            }
        }

        public event EventHandler AfterExecuteTask
        {
            add 
            {
                m_AfterExecuteTaskDelegate += value;
            }
            remove
            {
                m_AfterExecuteTaskDelegate -= value;
            }
        }

        public event EventHandler BeforeProcessReceived
        {
            add 
            {
                m_BeforeProcessReceivedDelegate += value;
            }
            remove
            {
                m_BeforeProcessReceivedDelegate -= value;
            }
        }

        public event EventHandler AfterProcessReceived
        {
            add 
            {
                m_AfterProcessReceivedDelegate += value;
            }
            remove
            {
                m_AfterProcessReceivedDelegate -= value;
            }
        }

        #endregion Events
        
        #region Constructors
       
        public Task( CommCmdBase commCmd, TaskStrategy taskStrategy )
            : this ( string.Empty, commCmd, taskStrategy )
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Task的名称</param>
        /// <param name="commCmd">执行的命令</param>
        /// <param name="taskStrategy">使用的策略</param>
        // 2006.12.13 move station parameters to commandBase
        //
        //// 2006.10.26
        ////
        ////public Task( Station station, CommCmdBase commCmd, TaskStrategy taskStrategy )
        ////public Task( string name, Station station, CommCmdBase commCmd, TaskStrategy taskStrategy )
        public Task( string name, CommCmdBase commCmd, TaskStrategy taskStrategy )
        {
            this.Name = name;
            // 2006.12.13
            //
            ////Debug.Assert (station != null,      "station can't is null.");
            //if ( station == null )
            //    throw new ArgumentNullException("station", SR.GetString("LE_StationNull"));

            //Debug.Assert (commCmd != null,      "commCmd can't is null.");
            if (commCmd == null)
                throw new ArgumentNullException("commCmd", SR.GetString("LE_CommCmdNull"));
            


            // 2006.12.13
            //
            //m_Station = station;

            m_CommCmd = commCmd;

            TaskStrategy = taskStrategy;
        }

        protected Task( SerializationInfo info, StreamingContext context)
        {
            foreach( SerializationEntry entry in info)
            {
                //if (entry.ObjectType == typeof (Station) ||
                //    entry.ObjectType.IsSubclassOf(typeof(Station)))
                //{
                //    this.m_Station = (Station) entry.Value;
                //}
        
                switch (entry.Name)
                {
                    case "TaskStrategy":
                        //this.TaskStrategy = (TaskStrategy)entry.Value;
                        this.m_TaskStrategy = (TaskStrategy)entry.Value;
                        break;
        
                    // 2006.12.13
                    //
                    //case "Station":
                    //    this.m_Station  = (Station)entry.Value;
                    //    break;

                    case "CommCmd":
                        this.m_CommCmd = (CommCmdBase)entry.Value;
                        break;
        
                    // 2006.12.13
                    //
                    //case "Parameters":
                    //    this.m_Parameters = (object[])entry.Value;
                    //    break;

                    case "Key":
                        this.Key =  (string)entry.Value;
                        break;
        
                    case "Tag":
                        this.Tag = (object)entry.Value;
                        break;
        
                    default:
                        throw new SerializationException(entry.Name + " " + entry.Value );
                }
            }    
        }
        #endregion //Constructor

        #region Properties

        /// <summary>
        /// 获取该Task是否可以删除标记
        /// </summary>
        virtual public bool CanRemove
        {
            get
            {
                return this.m_TaskStrategy.CanRemove;
            }
        }

        // 2006.11.13 Added
        //
        /// <summary>
        /// 获取或设置Task描述
        /// </summary>
        public string Description
        {
            get
            {
                if(m_Description == null)
                    m_Description = string.Empty;
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }
        /// <summary>
        /// 在当前时间，该Task是否需要执行
        /// </summary>
        /// <returns></returns>
        public bool NeedExecute()
        {
            return m_TaskStrategy.NeedExecute (DateTime.Now);
        }

        /// <summary>
        /// 获取或设置最后执行时间
        /// </summary>
        public DateTime LastExecute
        {
            get { return m_LastExecute; }
            set { m_LastExecute = value; } 
        }


        /// <summary>
        /// 获取命令,只读
        /// </summary>
        public CommCmdBase CommCmd
        {
            get { return m_CommCmd; }
        }

        public override string Key
        {
            get
            {
                return base.Key;
            }
            set
            {
                // 2007.02.02 Modify
                //
                //if ( value == null )
                //    //throw new ArgumentNullException("Key can not is null.");
                //    throw new ArgumentNullException(SR.GetString("LE_KeyNull"));
                //
                //
                //string s = value.Trim();
                //
                //if (s.Length <1)
                //    //throw new ArgumentException("Key length must > 0");
                //    throw new ArgumentException(SR.GetString("LE_KeyEmpty"));

                base.Key = value;

            }
        }

        public string Name 
        {
            get 
            {
                return this.Key;
            }
            set
            {
                //VerifyName(value);
                //m_Name = value; 
                //this.Key = m_Name;
                this.Key = value;
            }
        }


        /// <summary>
        /// 获取或设置Task策略
        /// </summary>
        public TaskStrategy TaskStrategy
        {
            get { return m_TaskStrategy; }
            set 
            { 
                // taskStrategy value != null
                //
                //Debug.Assert (value != null , "TaskStrategy can't is null." );
                if (value == null)
                    throw new ArgumentNullException ("TaskStrategy");
                
                // taskStrategy value != current taskStrategy
                //
                if ( m_TaskStrategy == value ) 
                    return ;

                // taskStrategy value not associate to other task
                //
                if ( value.Owning != null )
                    //throw new ArgumentException ("taskStrategy be used by other task.");
                    throw new ArgumentException (SR.GetString("LE_TaskStrategyUsed"));


                // if current taskStrategy not null, release it.
                //
                if (m_TaskStrategy != null )
                    m_TaskStrategy.Owning = null;

                // associate 
                //
                m_TaskStrategy = value;
                m_TaskStrategy.Owning = this;
            }
        }

        public CommResultState LastCommResultState
        {
            get { return m_LastCommResultState; }
        }

        internal void _set_comm_result( CommResultState st)
        {
            m_LastCommResultState = st;
        }

        public byte[] LastReceived
        {
            get
            {
                return this.m_LastReceived;
            }
        }

        // 2006.12.15 Added LastSendDateTime, LastReceivedDateTime, LastSendDatas
        //
        /// <summary>
        /// 获取最后发送命令时间
        /// </summary>
        public DateTime LastSendDateTime
        {
            get { return m_LastSendDateTime; }
        }

        /// <summary>
        /// 获取最后接受数据的时间
        /// </summary>
        public DateTime LastReceivedDateTime
        {
            get { return m_LastReceivedDateTime; }
        }

        /// <summary>
        /// 获取最后发送的命令数据
        /// </summary>
        public byte[] LastSendDatas
        {
            get { return m_LastSendDatas; }
        }

        #endregion Properties

        #region Methods
      

        private void VerifyName( string name )
        {
            // trim name.
            //
            if (name == null || name.Trim().Length ==0)
                //throw new ArgumentException("name can not is null and length must > 0","TaskName");
                throw new ArgumentException(SR.GetString("LE_NameNullOrEmpty"));

            // 
            // owning collection not exist the name, exclude this.
            //
            // name cannot is null and trim(name) length >0.
            //
        }



        /// <summary>
        /// 在指定的时间，该Task是否需要执行
        /// </summary>
        /// <param name="dt">指定的时间</param>
        /// <returns></returns>
        virtual public bool NeedExecute( DateTime dt )
        {
            return m_TaskStrategy.NeedExecute ( dt );
        }

        /// <summary>
        /// 执行Task
        /// </summary>
        /// <param name="commPortProxy">通过哪个串口执行</param>
        public void Execute(CommPortProxy commPortProxy)
        {
            // before execute
            //
            if (m_BeforeExecuteTaskDelegate != null )
                m_BeforeExecuteTaskDelegate ( this, EventArgs.Empty );

            // execute
            //
            // 2006.12.13
            //
            //OnExecute( commPortProxy, m_Station, m_CommCmd, m_Parameters );
            OnExecute( commPortProxy, m_CommCmd);

            // update last execute time
            //
            this.LastExecute = DateTime.Now;
                                                                                                                                                                                                                                                               //
            // 2006.12.15 Added update last send command datetime.
            //
            this.m_LastSendDateTime = DateTime.Now;

            // after execute
            //
            if (m_AfterExecuteTaskDelegate != null )
                m_AfterExecuteTaskDelegate ( this, EventArgs.Empty );
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commPortProxy"></param>
        /// <param name="cmd"></param>
        // 2006.12.13
        //
        //virtual protected void OnExecute ( CommPortProxy commPortProxy, Station station, CommCmdBase cmd, object[] parameters )
        virtual protected void OnExecute ( CommPortProxy commPortProxy, CommCmdBase cmd )
        {
            // 2006.12.13
            //
            //byte[] bytesCmd = cmd.MakeCommand ( station, parameters );
            byte[] bytesCmd = cmd.MakeCommand();
            //Debug.Assert (bytesCmd != null && bytesCmd.Length >0 , "bytesCmd can't is null and must length >0" );

            // 2006.12.15 Added, save last send command byte[].
            //
            this.m_LastSendDatas = bytesCmd; 

            commPortProxy.Send ( bytesCmd, cmd.LatencyTime );
        }

        #region ProcessReceived
        /// <summary>
        /// 处理接收到的数据
        /// </summary>
        /// <param name="received"></param>
        public void ProcessReceived( byte[] received )
        {
            m_LastReceived = received ;

            // 2006.12.15 Added, save last received byte[] data.
            //
            m_LastReceivedDateTime = DateTime.Now;

            // before proecee
            //
            if (m_BeforeProcessReceivedDelegate != null )
                m_BeforeProcessReceivedDelegate ( this, EventArgs.Empty );

            // process and save last execute result.
            //
            // 2006.12.13
            //
            //m_LastCommResultState = OnProcessReceived ( Station, Parameters , received );
            m_LastCommResultState = OnProcessReceived ( received );

            
            // after process
            //
            if ( m_AfterProcessReceivedDelegate != null )
                m_AfterProcessReceivedDelegate ( this, EventArgs.Empty );
        }

        /// <summary>
        /// 
        /// </summary>
        // 2006.12.13
        //
        //virtual protected CommResultState OnProcessReceived (Station station, object[] parameters, byte[] received)
        virtual protected CommResultState OnProcessReceived ( byte[] received )
        {
            //具体细节由 CommCmd 处理
            // 2006.12.13
            //
            //return m_CommCmd.ProcessReceived ( station, parameters, received );
            return m_CommCmd.ProcessReceived ( received );
        }

        #endregion //ProcessReceived
        #endregion //Methods

        #region ISerializable 成员

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  添加 Task.GetObjectData 实现
            info.AddValue ("TaskStrategy", m_TaskStrategy);
            // 2006.12.13
            //
            //info.AddValue ("Station", m_Station);
            info.AddValue ("CommCmd", m_CommCmd);
            // 2006.12.13
            //
            //info.AddValue ("Parameters", m_Parameters);
            info.AddValue ("Key", Key);
            info.AddValue ("Tag", Tag);
        }

        #endregion
    }

    #endregion //Task
}
