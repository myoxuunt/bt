using System;
using System.Diagnostics;
using Infragistics.Shared;

namespace CFW
{
    #region TaskSchedulersCollection
	/// <summary>
	/// TaskSchedulersCollection 的摘要说明。
    /// </summary>
    // 2007.02.11 Added
    //
    public class TaskSchedulersCollection : SubObjectsCollectionBase 
	{
		public TaskSchedulersCollection()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        protected override int InitialCapacity
        {
            get { return 10; }
        }
            
        public override bool IsReadOnly
        {
            get { return false; }
        }

        public TaskScheduler this[ int index ]
        {
            get { return (TaskScheduler) GetItem( index ); }
        }
            
        public void Add( TaskScheduler scheduler )
        {
            if ( scheduler == null )
                throw new NullReferenceException ("can not add null scheduler");
            this.InternalAdd( scheduler );
        }

        public void RemoveAt( int index )
        {
            InternalRemove( index );
        }


	}
    #endregion //TaskSchedulersCollection
}
