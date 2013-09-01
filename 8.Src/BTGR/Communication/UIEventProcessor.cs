

namespace Communication
{
    using System;
    using UICOMM;
    using System.Windows.Forms;

    #region UIEventProcessor
    /// <summary>
    /// UIEventProcessor 的摘要说明。
    /// </summary>
    public class UIEventProcessor
    {
        static private UIEventProcessor s_default = new UIEventProcessor();

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public UIEventProcessor Default 
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public UIEventProcessor()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion //Constructo

        #region Process
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Process( object sender, UICOMM.BTGRUIEventArgs args )
        {
            //MsgBox.Show( args.UIFunctionCode.ToString() );

            UIFunctionCode fc = args.UIFunctionCode;

            Form parent = (Form) sender;
            
            switch ( fc )
            {
                case UIFunctionCode.GprsConnManager:
                    frmGprsConnectionManager frmGprsMan = frmGprsConnectionManager.Default;//.MdiParent = parent;
                    frmGprsMan.MdiParent = parent; 
                    frmGprsMan.Show();

                    //TODO: 2007-10-17 Added 处理Gprs连接管理弹不出来问题
                    //
                    frmGprsMan.WindowState = FormWindowState.Maximized;
                    frmGprsMan.Activate();
                    break;
                     
                case UIFunctionCode.GRAlarmDataManager:
                    //TODO: UIFunctionCode.GRAlarmDataManager
                    //
                    frmGrAlarmDataManager f = new frmGrAlarmDataManager();
                    f.MdiParent = parent;
                    f.Show();
                    break;

                case UIFunctionCode.GRRealDataManager:
                    frmAllGRRealDatas frmGRRds =  frmAllGRRealDatas.Default;//.Show();
                    frmGRRds.MdiParent = parent;
                    frmGRRds.Show();
                    frmGRRds.WindowState = FormWindowState.Maximized;
                    frmGRRds.Activate();
                    break;

                case UIFunctionCode.StationManager:
                    frmXGStationManager frmGprsStMan = new frmXGStationManager();
                    frmGprsStMan.MdiParent = parent;
                    frmGprsStMan.Show();
                    break;

                case UIFunctionCode.XGDataManager:
                    //frmXGDataManager frmXgDataMan = new frmXGDataManager();
                    //frmXgDataMan.MdiParent = parent;
                    //frmXgDataMan.Show();
                    frmXGDataQuery frmXgDataQ = new frmXGDataQuery();
                    frmXgDataQ.WindowState = FormWindowState.Maximized;
                    frmXgDataQ.MdiParent = parent;
                    frmXgDataQ.Show();
                    break;

                    //case UIFunctionCode.XGTaskManager:
                    //  frmXGTaskManager frmXgTaskMan = new frmXGTaskManager();
                    //  frmXgTaskMan.MdiParent = parent;
                    //  frmXgTaskMan.Show();
                    //  break;

                case UIFunctionCode.XGTMCardManager:
                    //frmXGTaskResultManager frmXgTaskResultMan = new frmXGTaskResultManager ();
                    //frmXgTaskResultMan.Show();
                    frmCardManager frmCardMan = new frmCardManager();
                    frmCardMan.MdiParent = parent;
                    frmCardMan.Show();
                    break;

                case UIFunctionCode.GRCollSet:
                    //frmGrAlarmDataManager f2 = new frmGrAlarmDataManager();
                    //f2.MdiParent = parent;
                    //f2.Show();
                    frmCollSettings aFrmCollSettings = new frmCollSettings();
                    aFrmCollSettings.ShowDialog();
                    break;
                case UIFunctionCode.Help:
                    Help();
                    break;

                case UIFunctionCode.GRCtrlSet:
                    GrCtrl( parent );
                    break;

                case UIFunctionCode.GRSetOutSideTemperature:
//                    frmWastingCaloricReportMonth frmwc = new frmWastingCaloricReportMonth();
//                    frmwc.StartPosition = FormStartPosition.CenterParent;
//                    frmwc.ShowDialog();
//
//                    frmWaterReportMonth frmdw = new frmWaterReportMonth();
//                    frmdw.ShowDialog();

                    SetOutsideTemp();
                    break;

                case UIFunctionCode.XGDateTimeSetting:
                    ShowXgDateTimeSettingForm();
                    break;
            }
        }
        #endregion //Process

        /// <summary>
        /// 
        /// </summary>
        private void ShowXgDateTimeSettingForm()
        {
            frmXGDateTimeSetting f = new frmXGDateTimeSetting();
            f.ShowDialog();
        }

        #region SetOutsideTemp
        /// <summary>
        /// 
        /// </summary>
        private void SetOutsideTemp()
        {
            frmSetOutsideTemperature f = new frmSetOutsideTemperature();
            f.ShowDialog( );
        }
        #endregion //SetOutsideTemp

        #region GrCtrl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void GrCtrl( Form parent )
        {
            ArgumentChecker.CheckNotNull( parent );
            frmControl f = new frmControl();
            //f.MdiParent = parent;
            f.ShowDialog();
        }
        #endregion //GrCtrl

        #region Help
        /// <summary>
        /// 
        /// </summary>
        private void Help()
        {
            //frmControl f = new frmControl();
            //f.ShowDialog();
        }
        #endregion //Help
    }
    #endregion //UIEventProcessor
}
