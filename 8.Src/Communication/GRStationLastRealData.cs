using System;
using Communication.GRCtrl;
using Infragistics.Shared;
using Utilities;
namespace Communication
{
    #region GRStationLastRealData
	/// <summary>
	/// GRStationLastRealData 的摘要说明。
	/// </summary>
	public class GRStationLastRealData : Infragistics.Shared.SubObjectBase 
	{
        private GRStation _grSt;

        /// <summary>
        /// last GR real data
        /// </summary>
        /// <remarks>
        /// can is null
        /// </remarks>
        private GRRealData _grRd;

        public GRStation GRStation 
        {
            get { return _grSt; }
            
        }

        public GRRealData GRRealData
        {
            get { return _grRd; }
            set { _grRd = value; }
        }


		public GRStationLastRealData( GRStation grSt, GRRealData grRd )
		{
            ArgumentChecker.CheckNotNull( grSt );
            _grSt = grSt;
            _grRd = grRd ;
		}

        public GRStationLastRealData( GRStation grSt )
            : this ( grSt , null )
        {
        }
	}
    #endregion //GRStationLastRealData

    #region GRStationLastRealDatasCollection
    public class GRStationLastRealDatasCollection : SubObjectsCollectionBase 
    {

        public event EventHandler Changed;
        private GRStationLastRealData _strd = null;

        public GRStationLastRealDatasCollection ()
        {
        }

        public GRStationLastRealData ChangedSTRD
        {
            get { return _strd; }
        }

        protected override int InitialCapacity
        {
            get { return 40; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public void Add ( GRStationLastRealData grStRd )
        {
            ArgumentChecker.CheckNotNull( grStRd );
            InternalAdd( grStRd );
        }

        public void RemoveAt( int index )
        {
            InternalRemove( index );
        }


        public GRStationLastRealData this[ int index ]
        {
            get { return (GRStationLastRealData) GetItem( index ); }
        }

        public void ChangeWithStName( string stationName, int address, GRRealData grRd )
        {
            bool c = false;

            foreach( GRStationLastRealData strd in this )
            {
                if ( strd.GRStation.StationName == stationName && 
                    strd.GRStation.Address == address )
                {
                    strd.GRRealData = grRd;
                    _strd = strd;
                    c = true;
                }
            }

            if ( c && this.Changed != null )
            {
                EventHandler temp = Changed;
                temp( this, EventArgs.Empty );
            }
        }

        public void ChangeWithRemoteIP ( string remoteIP, int address, GRRealData grRd )
        {
            bool c = false;
            foreach ( GRStationLastRealData strd in this )
            {
                if ( strd.GRStation.DestinationIP == remoteIP && 
                    strd.GRStation.Address == address )
                {
                    strd.GRRealData = grRd;
                    _strd = strd;
                    c = true;
                }
            }

            if ( c && this.Changed != null )
            {
                EventHandler temp = Changed;
                temp( this, EventArgs.Empty );
            }
        }
    }
    #endregion //GRStationLastRealDatasCollection
}
