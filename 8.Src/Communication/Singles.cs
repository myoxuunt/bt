using System;
using CFW;

namespace Communication
{
    using GRCtrl;

	/// <summary>
	/// Singles 的摘要说明。
	/// </summary>
    public class Singles
    {
        private static Singles _singles = null;
        private Singles()
        {
        }
        
//        private XGScheduler _xgScheduler;
        private ObjectIdAssociateCollection _cardIds;
        private ObjectIdAssociateCollection _xgStationIds;
        private ObjectIdAssociateCollection _xgTaskIds;  
        private TaskScheduler               _taskScheduler;
//        private ARDProcessor                _ardProcessor;
        // 2007.02.11 Added
        //
//        private TaskSchedulersCollection    _taskScheulersCollection;

        private float                       _outSideTemperature;
        private WSListen                    _gprsListen;
        private User                        _currentUser;
        private GRStationLastRealDatasCollection 
                                            _grStRds;
        

        // 2007.03.07 Added
        //
        private GRStationsCollection        _grStationsCollection = new GRStationsCollection();

        // 2007.03.12 Added
        //
        private XGStationsCollection        _xgStationsCollection = new XGStationsCollection();


        // 2007.03.13 Added
        //
        private CollStateDisplay            _collStateDisplay;

        /// <summary>
        /// 
        /// </summary>
        public CollStateDisplay CollStateDisPlay
        {
            get { return _collStateDisplay; }
            set { _collStateDisplay = value; }
        }

        /// <summary>
        /// 通过IP和站点地址获取巡更控制器对象
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public XGStation GetXGStation( string remoteIP, int address )
        {
            foreach ( object obj in _xgStationIds )
            {
                ObjectIdAssociateCollection.ObjectIdAssociate obj_Id =  (ObjectIdAssociateCollection.ObjectIdAssociate) obj;
                XGStation xgst = (XGStation) obj_Id.Object; 
                if ( xgst.DestinationIP == remoteIP &&
                    xgst.Address == address )
                {
                    return xgst;
                }
                    
            }
            return null;
        }

        /// <summary>
        /// 获取或设置供热控制器的站点集合
        /// </summary>
        public GRStationsCollection GRStsCollection
        {
            get { return _grStationsCollection; }
            set { _grStationsCollection = value; }
        }

        /// <summary>
        /// 获取或设置巡更控制器站点集合
        /// </summary>
        public XGStationsCollection XGStsCollection
        {
            get { return _xgStationsCollection; }
            set { _xgStationsCollection = value; }
        }

        /// <summary>
        /// 获取或设置供热站点最后采集实时数据集合
        /// </summary>
        public GRStationLastRealDatasCollection GRStRds
        {
            get { return _grStRds; }
            set { _grStRds = value; }
        }

        public User CurrentUser
        {
            get { return _currentUser;  }
            set { _currentUser = value; }
        }


        /// <summary>
        /// 室外温度
        /// </summary>
        /// <remarks>
        /// 从一台供热控制器上采集，并将此值设置到其他控制器。
        /// </remarks>
        public float OutSideTemperature
        {
            get { return _outSideTemperature; }
            set 
            { 
                _outSideTemperature = value; 
                // TODO: Update DB last out side temperature
                //
            }
        }

        public WSListen GprsListen
        {
            get { return _gprsListen; }
            set { _gprsListen = value; }
        }

        //public TaskSchedulersCollection TaskSchCollection
        //{
        //    get { return _taskScheulersCollection; }
        //    set { _taskScheulersCollection = value; }
        //}

//            public XGScheduler XGScheduler
//        {
//            get { return _xgScheduler; }
//            set { _xgScheduler = value; }
//        }
        
        public ObjectIdAssociateCollection CardIds
        {
            get { return _cardIds; }
            set { _cardIds = value; }
        }
        
        public ObjectIdAssociateCollection XGStationIds
        {
            get { return _xgStationIds; }
            set { _xgStationIds = value; }
        }

        public ObjectIdAssociateCollection XGTaskIds
        {
            get { return _xgTaskIds; }
            set { _xgTaskIds = value; }
        }

        public TaskScheduler TaskScheduler
        {
            get { return _taskScheduler; }
            set { _taskScheduler = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		public CommPortProxysCollection CommPortProxyCollection 
		{
			get { return _taskScheduler.CppsCollection; }
		}

        //public ARDProcessor ArdProcessor
        //{
        //    get { return _ardProcessor; }
        //    set { _ardProcessor = value; } 
        //}

        static public Singles S
        {
            get 
            {
                if ( _singles == null )
                {
                    _singles = new Singles();
                }
                return _singles;
            }
        }
	}
}
