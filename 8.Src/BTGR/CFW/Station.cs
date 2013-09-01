using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CFW
{
    #region Station
    [Serializable]
    public class Station: Infragistics.Shared.KeyedSubObjectBase, ISerializable
    {
        #region Member Variables

        private AlarmDatasCollection        m_AlarmDatas    = null;
        private ErrorDatasCollection        m_ErrorDatas    = null;
        private OperationLogsCollection     m_OperateLogs   = null;
        private RealDatasCollection         m_RealDatas     = null;
        private string                      m_StationName   = null;
        private string                      m_Description   = null;
        private int                         m_Address       = 0;

        private string                      _destinationIP  = null;
        private bool                        _useIP          = false;

        #endregion //Member Variables

        #region Constructors
        
        // 2006.12.25 Modify protected to public.
        //
        //protected Station( string stationName, int address )
        public Station( string stationName, int address )
        {
            StationName = stationName;
            Address = address;
            init();
        }

        public Station ( string stName, string destIp, int address )
        {
            // check ip format
            //
            System.Net.IPAddress ip = System.Net.IPAddress.Parse( destIp );
            if ( ip.ToString() == "0.0.0.0" )
                throw new ArgumentException("ip address");

            SetStationName( stName );
            _destinationIP = destIp;
            m_Address = address;
            _useIP = true;
        }

        protected Station(SerializationInfo info, StreamingContext context)
            //: base ("NoName",0)
        {
            foreach( SerializationEntry entry in info)
            {
                switch (entry.Name)
                {
                    case "StationName":
                        this.StationName = (string)entry.Value;
                        break;

                    case "Address":
                        this.Address = Convert.ToInt32( entry.Value );
                        break;

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

        #endregion Constructors

        #region Protected Properties
        

        protected AlarmDatasCollection _AlarmDatas
        {
            get { return m_AlarmDatas;  }
            set { m_AlarmDatas = value; }
        }

        protected ErrorDatasCollection  _ErrorDatas
        {
            get { return m_ErrorDatas ; }
            set { m_ErrorDatas = value; }
        }

        // 2006.12.22 Replace _Operatelogs with public property OperationLogs
        //
        //protected OperationLogsCollection _OperateLogs
        //{
        //    get { return m_OperateLogs; }
        //    set { m_OperateLogs = value;}
        //}

        protected RealDatasCollection _RealDatas
        {
            get { return m_RealDatas;   }
            set { m_RealDatas = value;  }    
        }

        #endregion Protected Properties

        #region Public Properties

        public string DestinationIP
        {
            get { return _destinationIP; }
        }

        public bool IsUseIP
        {
            get { return _useIP; }
        }

        // 2006.11.13 Added
        //
        /// <summary>
        /// 获取或设置站描述
        /// </summary>
        public string Description
        {
            get
            {
                if (m_Description == null)
                    m_Description = string.Empty;
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        /// <summary>
        /// 获取或设置站名称
        /// </summary>
        /// <remarks>
        /// 名称首尾不包含空格
        /// 同一个集合中名称不能相同（不区分大小写）
        /// </remarks>
        public string StationName 
        {
            get { return m_StationName; }
            set 
            {
                SetStationName( value );
            }
        }

        private void SetStationName( string value )
        {
            if (value == null || value.Trim().Length == 0)
            {
                throw new System.ArgumentException("Argument stationName exception.");
            }

            if (! Utility.Equals( m_StationName, value ,true, true) )
            {
                if (PrimaryCollection != null )
                {
                    ( (StationsCollection)PrimaryCollection ).ValidateStationName (value, this);
                }

                m_StationName = value.Trim();
                Key = m_StationName;
            }
        }


        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public int Address
        {
            get { return m_Address; }
            set 
            {
                //Debug.Assert( value >=0 , "Address must >=0");
                if (value<0)
                    throw new ArgumentOutOfRangeException("Address");
                m_Address = value; 
            }
        }
        
        public OperationLogsCollection OperationLogs
        {
            get { return m_OperateLogs; }
            set 
            { 
                if (value == null)
                    throw new ArgumentNullException ( "OperateLogs" );
                this.m_OperateLogs = value;
            }
        }
        #endregion Public Properties

        #region Private Method
        private void init()
        {
            // 2006.12.15 Added
            //
            m_OperateLogs = new OperationLogsCollection();
        }
        
        #endregion Private Method

        #region ISerializable Member

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue ("StationName", this.StationName);
            info.AddValue ("Address", this.Address);
            info.AddValue ("Key",Key);
            info.AddValue ("Tag",Tag);
        }

        #endregion // ISerializable Member
    }
    #endregion //Station

}
