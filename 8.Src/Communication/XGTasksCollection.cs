using System;
using Infragistics.Shared;

namespace Communication
{
    #region XGTasksCollection
    public class XGTasksCollection : SubObjectsCollectionBase 
    {
        protected override int InitialCapacity
        {
            get { return 10; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }


        public XGTasksCollection()
        {
        }

        public int Add( XGTask task )
        {
            return base.InternalAdd( task );
        }

        public void RemoveAt( int index )
        {
            base.InternalRemove( index );
        }

        public void Clear()
        {
            base.InternalClear();
        }

        public XGTask this[ int index ]
        {
            get { return  (XGTask) this.List[ index ]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public XGTask[] MatchXGData( XGData data )
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();
            if ( data == null )
                return null;
            for (int i=0; i<Count; i++)
            {
                XGTask task = this[ i ];
                if ( task.MatchXGData( data ) )
                {
                    task.XgTaskResult = data;
                    task.IsComplete = true;
                    list.Add( task );
                }
            }

            return (XGTask[])list.ToArray( typeof( XGTask ) );
        }
    }
    #endregion //XGTasksCollection

}
