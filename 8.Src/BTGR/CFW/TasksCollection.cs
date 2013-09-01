using System;
using System.Runtime.Serialization;
using System.Diagnostics;
using Infragistics.Shared;

namespace CFW
{
    /// <summary>
    /// 
    /// </summary>
    // 2006.10.23 Changed, Inherit from KeyedSubObjectsCollectionBase for Task class add 'Name' field.
    //
    //public class TasksCollection: Infragistics.Shared.SubObjectsCollectionBase 
    [Serializable]
    public class TasksCollection: Infragistics.Shared.KeyedSubObjectsCollectionBase ,ISerializable
    {
        const int DEFAULT_CAPACITY = 10;

        private TaskScheduler   _owning = null;

        // 2007.02.02 Added 
        //
        private bool            _allowDuplicateKeys = true;
        private bool            _allowEmptyKeys = true;
        #region Constructors
       
        public TasksCollection()
        {
        }

        public TasksCollection( TaskScheduler owning)
        {
            Owning = owning;
        }

        protected TasksCollection(SerializationInfo info, StreamingContext context)
        {
            foreach (SerializationEntry entry in info)
            {
                if (entry.ObjectType == typeof (Task) ||
                    entry.ObjectType.IsSubclassOf( typeof(Task) ) )
                {
                    Task t = (Task)entry.Value;

                    if (t != null)
                        this.List.Add ( entry.Value );
                }
            }

        }

        #endregion //Constructor

        #region ISerializable ��Ա

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // TODO:  ��� StationsCollection.GetObjectData ʵ��
            //foreach (object o in this)
            //{
            //    info.AddValue(o.ToString(), o);
            //}

            for (int i=0; i<List.Count; i++)
            {
                info.AddValue(i.ToString(), List[i]);
            }
        }

        #endregion


        protected override int InitialCapacity  { get { return DEFAULT_CAPACITY; } }

        public override bool IsReadOnly         { get { return false; } }
        
        public override bool AllowDuplicateKeys
        {
            get
            {
                // 2007.02.02 Modify
                //
                //return false;
                return GetAllowDuplicateKeys();
            }
        }

        public override bool AllowEmptyKeys
        {
            get
            {
                // 2007.02.02
                //
                //return false;
                return GetAllowEmptyKeys();
            }
        }
        
        internal TaskScheduler Owning
        {
            get
            {
                return _owning;
            }
            set
            {
                _owning = value;
            }
        }
        /// <summary>
        /// ���һ���µ�Task, ���ʱ�����task.TaskStrategy.FirstExecuteֵ���������뵽
        /// ���ϵ�ĩβ�򱻵�һ��ִ�е�λ�á�
        /// </summary>
        /// <param name="task"></param>
        public void Add ( Task task )
        {
            //EnsureNotExist ( task );

            if( task == null)
                throw new ArgumentNullException("task");

            if (task.TaskStrategy.FirstExecute)
            {
                this.AddFirstExectueTask(task);
            }
            else
            {
                this.InternalAdd( task );
            }
            //ͨ��Tasks���ϸı�
            //
            PropChangeInfo trigger = new PropChangeInfo(task,PropertyIds.Add ,null);
            this.NotifyPropChange ( PropertyIds.Tasks , trigger );

        }

        /// <summary>
        /// ��task��ӵ������ڻᱻ��һ��ִ�е�λ��
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public void AddFirstExectueTask( Task task )
        {
            // 2007.02.02
            //
            //if (_owning == null)
            //{
            //    this.InternalInsert(0, task);
            //}
            //else
            //{
            //    this.InternalInsert(_owning.GetActiveTaskIndex() + 1, task);
            //}
            InternalInsert( 0, task );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Task GetTask( int index )
        {
            return List[index] as Task;
        }


        public Task this[ int index ]
        {
            get
            {
                return GetTask( index );
            }
        }
        /// <summary>
        /// �Ƴ�һ��Task
        /// </summary>
        /// <param name="task">���Ƴ���Task</param>
        public void Remove (Task task )
        {
            InternalRemove( task );

            PropChangeInfo trigger = new PropChangeInfo( task, PropertyIds.Remove, null );
            this.NotifyPropChange( PropertyIds.Tasks, trigger );

        }

        /// <summary>
        /// �Ƴ�һ��Task
        /// </summary>
        /// <param name="index">���Ƴ���Task������</param>
        public void RemoveAt (int index )
        {
            Task task = this.GetItem( index ) as Task ;
            Debug.Assert (task != null, "Index error at  RemoveAt( int index ).");

            InternalRemove ( index );

            PropChangeInfo trigger = new PropChangeInfo ( task, PropertyIds.Remove, null);
            this.NotifyPropChange( PropertyIds.Tasks, trigger);
            
        }

        /// <summary>
        /// ����ü����е�����Task
        /// </summary>
        public void Clear()
        {
            InternalClear();
            PropChangeInfo trigger = new PropChangeInfo ( null, PropertyIds.Clear, null);
            this.NotifyPropChange( PropertyIds.Tasks, trigger);
        }


        /// <summary>
        /// ����һ��Task
        /// </summary>
        /// <param name="index"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        public void Insert(int index , Task task )
        {
            //EnsureNotExist ( task );
                
            InternalInsert (index, task );

            PropChangeInfo trigger = new PropChangeInfo ( task, PropertyIds.Insert, null);
            this.NotifyPropChange( PropertyIds.Tasks, trigger);
        }
            
        public void SetAllowDuplicateKeys( bool value )
        {
            if ( _allowDuplicateKeys != value )
                 _allowDuplicateKeys = value;
        }

        public bool GetAllowDuplicateKeys( )
        {
            return _allowDuplicateKeys;
        }

        public void SetAllowEmptyKeys( bool value )
        {
            if ( _allowEmptyKeys != value )
                _allowEmptyKeys = value;
        }
        public bool GetAllowEmptyKeys()
        {
            return _allowEmptyKeys;
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="task"></param>
        //private void EnsureNotExist ( Task task )
        //{
        //    //if ( this.Contains ( task ) )
        //    //    throw new System.ArgumentException ("task already exist.");
        //}
    }
}
