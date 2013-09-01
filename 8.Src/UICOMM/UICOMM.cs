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
        /// �û�����
        /// </summary>
        UserManager,

        /// <summary>
        /// վ�����
        /// </summary>
        StationManager,

        /// <summary>
        /// GPRS���ӹ���
        /// </summary>
        GprsConnManager,

        /// <summary>
        /// TM������
        /// </summary>
        XGTMCardManager,

        /// <summary>
        /// XG�������
        /// </summary>
        XGTaskManager,

        /// <summary>
        /// XG���ݹ���
        /// </summary>
        XGDataManager,

        /// <summary>
        /// XG����������
        /// </summary>
        XGTaskResultManager,
        
        /// <summary>
        /// GR�ɼ�����
        /// </summary>
        GRCollSet,

        /// <summary>
        /// GR��������
        /// </summary>
        GRCtrlSet,

        /// <summary>
        /// GRʵʱ����
        /// </summary>
        GRRealDataManager,

        /// <summary>
        /// GR��������
        /// </summary>
        GRAlarmDataManager,

        /// <summary>
        /// GR��ʷ����
        /// </summary>
        GRHistoryDataManager,

        /// <summary>
        /// GR��ʷ����
        /// </summary>
        GRHistoryLineManager,
        
        /// <summary>
        /// ����
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
