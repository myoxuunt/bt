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

        // 2006.12.15 Added m_LastSendTime, m_LastSendData��m_LastReceivedTime
        //
        /// <summary>
        /// ���һ�η��������ʱ��
        /// </summary>
        private DateTime        m_LastSendDateTime      = DateTime.MinValue;

        /// <summary>
        /// ���һ�ν������ݵ�ʱ��
        /// </summary>
        private DateTime        m_LastReceivedDateTime  = DateTime.MinValue;

        /// <summary>
        /// ���һ�η��͵�����
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
        /// ���һ��ִ�и�Task��ʱ��
        /// </summary>
        private DateTime        m_LastExecute       = DateTime.MinValue ;

        /// <summary>
        /// �������һ�ε�ͨѶ�Ľ��
        /// </summary>
        private CommResultState m_LastCommResultState   = CommResultState.UnknownError ;

        /// <summary>
        /// �������һ��ͨѶ���յ�����
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
        /// <param name="name">Task������</param>
        /// <param name="commCmd">ִ�е�����</param>
        /// <param name="taskStrategy">ʹ�õĲ���</param>
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
        /// ��ȡ��Task�Ƿ����ɾ�����
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
        /// ��ȡ������Task����
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
        /// �ڵ�ǰʱ�䣬��Task�Ƿ���Ҫִ��
        /// </summary>
        /// <returns></returns>
        public bool NeedExecute()
        {
            return m_TaskStrategy.NeedExecute (DateTime.Now);
        }

        /// <summary>
        /// ��ȡ���������ִ��ʱ��
        /// </summary>
        public DateTime LastExecute
        {
            get { return m_LastExecute; }
            set { m_LastExecute = value; } 
        }


        /// <summary>
        /// ��ȡ����,ֻ��
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
        /// ��ȡ������Task����
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
        /// ��ȡ���������ʱ��
        /// </summary>
        public DateTime LastSendDateTime
        {
            get { return m_LastSendDateTime; }
        }

        /// <summary>
        /// ��ȡ���������ݵ�ʱ��
        /// </summary>
        public DateTime LastReceivedDateTime
        {
            get { return m_LastReceivedDateTime; }
        }

        /// <summary>
        /// ��ȡ����͵���������
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
        /// ��ָ����ʱ�䣬��Task�Ƿ���Ҫִ��
        /// </summary>
        /// <param name="dt">ָ����ʱ��</param>
        /// <returns></returns>
        virtual public bool NeedExecute( DateTime dt )
        {
            return m_TaskStrategy.NeedExecute ( dt );
        }

        /// <summary>
        /// ִ��Task
        /// </summary>
        /// <param name="commPortProxy">ͨ���ĸ�����ִ��</param>
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
        /// ������յ�������
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
            //����ϸ���� CommCmd ����
            // 2006.12.13
            //
            //return m_CommCmd.ProcessReceived ( station, parameters, received );
            return m_CommCmd.ProcessReceived ( received );
        }

        #endregion //ProcessReceived
        #endregion //Methods

        #region ISerializable ��Ա

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  ��� Task.GetObjectData ʵ��
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
