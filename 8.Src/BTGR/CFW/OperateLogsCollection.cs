namespace CFW
{

    #region OperationLogsCollection
    /// <summary>
    /// 
    /// </summary>
    public class OperationLogsCollection: Infragistics.Shared.SubObjectsCollectionBase 
    {
        const int DEFAULT_CAPACITY = 100;
        const int DEFAULT_MAXCOUNT = 2000;
        const int MIN_MAXCOUNT = 1000;
        /// <summary>
        /// can save max count of logs. 
        /// default to 2000.
        /// min count to 1000.
        /// </summary>
        private int _maxCount;

        private void init()
        {
            _maxCount = DEFAULT_MAXCOUNT;
        }

        public int MaxCount
        {
            get { return _maxCount; }
            set 
            { 
                if ( value < MIN_MAXCOUNT )
                    _maxCount = MIN_MAXCOUNT;
                else
                    _maxCount = value; 
            }
        }


        /// <summary>
        /// 记录数将要到达最大时触发次事件。
        /// </summary>
        public event System.EventHandler Filling = null;
        protected override int InitialCapacity
        {
            get
            {
                return DEFAULT_CAPACITY;
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public OperationLogsCollection()
        {
            init();
        }

        public int Add( OperationLog log )
        {
            // 2006.12.20 Added maxCount and clear logs code.
            //
            const float reportFactor = 0.9F;
            int reportCount =(int)( _maxCount * reportFactor );
            int clearCount = _maxCount;

            if (this.Count >= reportCount)
                if ( this.Filling != null)
                    Filling( this, System.EventArgs.Empty );
            if ( this.Count >= clearCount )
                base.InternalClear();

            return base.InternalAdd( log );
        }

        public OperationLog GetOperationLog( int index )
        {
            return base.GetItem( index ) as OperationLog;
        }

        public OperationLog this[int index]
        {
            get { return this.GetOperationLog( index ); }
        }

        public void RemoveAt (int index )
        {
            base.InternalRemove( index );
        }

        public void Clear()
        {
            base.List.Clear(); 
        }
    }
    #endregion //OperationLogsCollection
}
