using System;
using CFW;
using Infragistics.Shared;
using Utilities;

namespace Communication.GRCtrl
{
	/// <summary>
	/// GRStation 的摘要说明。
	/// </summary>
	public class GRStation : Station 
	{
        private OutSideTempWorkMode     _outSideTemperatureMode;

        /// <summary>
        /// 该站点连接的服务器的IP地址
        /// </summary>
        private string _serverIP;
        private string _team;

        //public GRStation ( string name, int address )
        //    : this ( name, address, OutSideTempWorkMode.SetByComputer, "10.21.108.23" )
        //{
        //}
        
        public GRStation ( string name, int address, string ip) //, string serverIP )
            : this ( name, address, OutSideTempWorkMode.SetByComputer, ip, string.Empty )//, serverIP )
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public GRStation ( string name, int address, string ip, string team ) //, string serverIP )
            : this ( name, address, OutSideTempWorkMode.SetByComputer, ip, team )//, serverIP )
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="ostMode">室外温度工作模式</param>
		public GRStation( string name, int address , OutSideTempWorkMode ostMode, string ip, string team ) //, string serverIP) 
            : base ( name, ip, address )
		{
//            if ( serverIP == null || serverIP.Length == 0 )
//                throw new ArgumentException( "serverIP error", "serverIP" );
//
//            // check serverIP
//            //
//            System.Net.IPAddress.Parse( serverIP );
//
//            _serverIP = serverIP;
            _outSideTemperatureMode = ostMode;
            _team = team;
		}

        /// <summary>
        /// 获取或设置室外温度工作模式
        /// </summary>
        public OutSideTempWorkMode OSTWorkMode
        {
            get { return _outSideTemperatureMode; }
            set { _outSideTemperatureMode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Team
        {
            get { return _team; }
            set { _team = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServerIP
        {
            get { return _serverIP; }
            set { _serverIP = value; }
        }
	}

    #region XGStationsCollection
    /// <summary>
    /// 
    /// </summary>
    public class XGStationsCollection : StationsCollection 
    {
        public XGStationsCollection()
        {
        }

        public void Add( XGStation st )
        {
            ArgumentChecker.CheckNotNull( st );
            base.InternalAdd( st );
        }

        public void Remote( XGStation st )
        {
            base.InternalRemove ( st );
        }

        public void RemoveAt( int index )
        {
            base.InternalRemove( index );
        }
            
        public XGStation GetXGStation ( string name )
        {
            if ( name == null )
                return null;

            name = name.Trim();
            foreach ( XGStation st in this )
            {
                if ( string.Compare( st.StationName, name, true ) == 0 )
                {
                    return st;
                }
            }
            return null;
        }

        public XGStation GetXGStation ( string remoteIP, int address )
        {
            foreach( XGStation st in this )
            {
                if ( st.DestinationIP == remoteIP && 
                    st.Address == address )
                {
                    return st;
                }
            }
            return null;
        }

        public XGStation this[ int index ]
        {
            get { return (XGStation) base.GetItem( index ); }

        }

    }
    #endregion //XGStationsCollection

    #region GRStationsCollection
    public class GRStationsCollection : StationsCollection 
    {
        /// <summary>
        /// 
        /// </summary>
        public GRStationsCollection ()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        public void Add( GRStation st )
        {
            ArgumentChecker.CheckNotNull( st );
            base.InternalAdd(  st );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="st"></param>
        public void Remove( GRStation st )
        {
            base.InternalRemove( st );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt( int index )
        {
            base.InternalRemoveAt( index );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GRStation GetGRStation( string name )
        {
            if ( name == null )
                return null;
            name = name.Trim();
            foreach ( GRStation st in this )
            {
                if ( string.Compare( st.StationName, name, true ) == 0 )
                {
                    return st;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public GRStation GetGRStation ( string remoteIP, int address )
        {
            foreach( GRStation st in this )
            {
                if ( st.DestinationIP == remoteIP && 
                    st.Address == address )
                {
                    return st;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public GRStation this[int index]
        {
            get { return (GRStation) GetItem( index ); }
        }
    }
    #endregion //GRStationsCollection
}
