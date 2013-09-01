using System;

namespace UICOMM
{
    public enum UIFunctionCode 
    {
        /// <summary>
        /// GIS
        /// </summary>
        GIS,

        /// <summary>
        /// 用户管理
        /// </summary>
        UserManager,

        /// <summary>
        /// 站点管理
        /// </summary>
        StationManager,

        /// <summary>
        /// GPRS连接管理
        /// </summary>
        GprsConnManager,

        /// <summary>
        /// TM卡管理
        /// </summary>
        XGTMCardManager,

        /// <summary>
        /// XG任务管理
        /// </summary>
        XGTaskManager,

        /// <summary>
        /// XG数据管理
        /// </summary>
        XGDataManager,

        /// <summary>
        /// XG任务结果管理
        /// </summary>
        XGTaskResultManager,
        
        /// <summary>
        /// GR采集设置
        /// </summary>
        GRCollSet,

        /// <summary>
        /// GR控制设置
        /// </summary>
        GRCtrlSet,

        /// <summary>
        /// GR实时数据
        /// </summary>
        GRRealDataManager,

        /// <summary>
        /// GR报警数据
        /// </summary>
        GRAlarmDataManager,

        /// <summary>
        /// GR历史数据
        /// </summary>
        GRHistoryDataManager,

        /// <summary>
        /// GR历史曲线
        /// </summary>
        GRHistoryLineManager,
        
        /// <summary>
        /// 帮助
        /// </summary>
        Help,

        /// <summary>
        ///  
        /// </summary>
        GRSetOutSideTemperature,

        /// <summary>
        /// 
        /// </summary>
        XGDateTimeSetting,
    }


    public class BTGRUIEventArgs : System.EventArgs 
    {
        private UIFunctionCode  _uiFc;
        private object[]        _additives;

        public UIFunctionCode UIFunctionCode
        {
            get { return _uiFc; }
        }

        public object[] Additives 
        {
            get { return _additives; }
        }

        public BTGRUIEventArgs ( UIFunctionCode uiFc, object[] additives )
        {
            _uiFc = uiFc;
            _additives = additives;
        }
    }
    public delegate void BTGRUIEventHandler ( object sender, BTGRUIEventArgs args );

}
