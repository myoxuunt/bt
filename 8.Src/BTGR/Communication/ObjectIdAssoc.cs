using System;

namespace Communication
{
    #region ObjectIdAssociateCollection 

    /// <summary>
    /// 
    /// </summary>
    public class ObjectIdAssociateCollection : 
        Infragistics.Shared.SubObjectsCollectionBase 
    {
        #region ObjectIdAssociate

        /// <summary>
        /// 关联一个对象和其对应的数据库Id
        /// </summary>
        public class ObjectIdAssociate : Infragistics.Shared.SubObjectBase 
        {
            
            private int _id;
            private object  _obj;

            public ObjectIdAssociate(object obj, int id)
            {
                Object = obj;
                Id = id;
            }

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public object Object
            {
                get { return _obj; }
                set 
                { 
                    if ( value == null )
                        throw new NullReferenceException("Object");

                    _obj = value;
                }
            }
        }
        #endregion // ObjectIdAssociate

        private string _tableName;

        public ObjectIdAssociateCollection( string tableName )
        {
            _tableName = tableName;
        }

        public string TableName
        {
            get { return _tableName; }
        }

        protected override int InitialCapacity
        {
            get
            {
                return 100;
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        //private bool Exist( object obj )
        public bool Exist( object obj )
        {
            for (int i=0; i<Count; i++)
            {
                ObjectIdAssociate oia = base.List[i] as ObjectIdAssociate;
                if (oia.Object == obj)
                    return true;
            }
            return false;
        }

        private int Add( ObjectIdAssociate objIdAssoc )
        {
            if ( base.IndexOf( objIdAssoc ) != -1 )
                throw new ArgumentException("ObjectIdAssociate exist");
            object obj = objIdAssoc.Object ;

            if (Exist( obj ))
                throw new ArgumentException("object be associated");

            return base.InternalAdd( objIdAssoc );
        }

        public int Add( object obj, int id )
        {
            return this.Add( new ObjectIdAssociate( obj, id ) );
        }

        public object GetObject ( int id )
        {
            for ( int i=0; i<Count; i++ )
            {
                ObjectIdAssociate oia = base.List[i] as ObjectIdAssociate;
                if ( oia.Id == id )
                {
                    return oia.Object;
                }
            }
            return null;
        }

        public object GetObjectByIndex( int index )
        {
            return ((ObjectIdAssociate)List[index]).Object;
        }

        public object this [int index]
        {
            get { return List[ index ]; }
        }

        public bool GetId ( object obj, out int id )
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            for( int i=0; i<base.Count; i++)
            {
                ObjectIdAssociate oia = base.List[i] as ObjectIdAssociate;
                if ( oia.Object == obj )
                {
                    id = oia.Id;
                    return true;
                }
            }
            id = 0;
            return false;
        }

        public void RemoveObject( object obj )
        {
            for ( int i=0; i<Count; i++)
            {
                ObjectIdAssociate oia = base.List[i] as ObjectIdAssociate;
                if (oia.Object == obj)
                    InternalRemove( i );
            }
        }

        public void Clear()
        {
            base.InternalClear();
        }
    }
    #endregion // ObjectIdAssociateCollection 
}
