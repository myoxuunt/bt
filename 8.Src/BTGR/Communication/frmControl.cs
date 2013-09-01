using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CFW;
using Communication.GRCtrl;

namespace Communication
{
	/// <summary>
	/// frmControl 的摘要说明。
	/// </summary>
    public class frmControl : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ColumnHeader chGprsStationName;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem miGrCollRd;
        private System.Windows.Forms.MenuItem miXGQueryCount;
        private System.Windows.Forms.MenuItem miXGSetTime;
        private System.Windows.Forms.MenuItem miXGClear;
        private System.Windows.Forms.ListView lvGprsStation;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem miPressAlarmSet;
        private System.Windows.Forms.MenuItem miTemperatureAlarmSet;
        private System.Windows.Forms.MenuItem miStopCycPump;
        private System.Windows.Forms.MenuItem miStopRePump;
        private System.Windows.Forms.Button btnTempLine;
        private System.Windows.Forms.Button btnPressAlarmSet;
        private System.Windows.Forms.Button btnTempAlarmSet;
        private System.Windows.Forms.Button btnStopCyclePump;
        private System.Windows.Forms.Button btnStopRecruitPump;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartRe;
        private System.Windows.Forms.Button btnStartCyc;
        private System.Windows.Forms.Label lblSelectedStation;
        private System.Windows.Forms.Button btnGiveTempMode;
        private System.Windows.Forms.Button btnOpenDegree;
		private System.Windows.Forms.Button txtlog;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnTimeTempLine;
		private System.Windows.Forms.Button btnPumpSetting;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmControl()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.lvGprsStation = new System.Windows.Forms.ListView();
			this.chGprsStationName = new System.Windows.Forms.ColumnHeader();
			this.chIP = new System.Windows.Forms.ColumnHeader();
			this.chState = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.miGrCollRd = new System.Windows.Forms.MenuItem();
			this.miXGQueryCount = new System.Windows.Forms.MenuItem();
			this.miXGClear = new System.Windows.Forms.MenuItem();
			this.miXGSetTime = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miPressAlarmSet = new System.Windows.Forms.MenuItem();
			this.miTemperatureAlarmSet = new System.Windows.Forms.MenuItem();
			this.miStopCycPump = new System.Windows.Forms.MenuItem();
			this.miStopRePump = new System.Windows.Forms.MenuItem();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnTempLine = new System.Windows.Forms.Button();
			this.btnPressAlarmSet = new System.Windows.Forms.Button();
			this.btnTempAlarmSet = new System.Windows.Forms.Button();
			this.btnStopCyclePump = new System.Windows.Forms.Button();
			this.btnStopRecruitPump = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnStartRe = new System.Windows.Forms.Button();
			this.btnStartCyc = new System.Windows.Forms.Button();
			this.lblSelectedStation = new System.Windows.Forms.Label();
			this.btnGiveTempMode = new System.Windows.Forms.Button();
			this.btnOpenDegree = new System.Windows.Forms.Button();
			this.txtlog = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btnTimeTempLine = new System.Windows.Forms.Button();
			this.btnPumpSetting = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lvGprsStation
			// 
			this.lvGprsStation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.chGprsStationName,
																							this.chIP,
																							this.chState});
			this.lvGprsStation.ContextMenu = this.contextMenu1;
			this.lvGprsStation.FullRowSelect = true;
			this.lvGprsStation.GridLines = true;
			this.lvGprsStation.Location = new System.Drawing.Point(8, 32);
			this.lvGprsStation.MultiSelect = false;
			this.lvGprsStation.Name = "lvGprsStation";
			this.lvGprsStation.Size = new System.Drawing.Size(360, 424);
			this.lvGprsStation.TabIndex = 0;
			this.lvGprsStation.View = System.Windows.Forms.View.Details;
			this.lvGprsStation.SelectedIndexChanged += new System.EventHandler(this.lvGprsStation_SelectedIndexChanged);
			// 
			// chGprsStationName
			// 
			this.chGprsStationName.Text = "站名";
			this.chGprsStationName.Width = 140;
			// 
			// chIP
			// 
			this.chIP.Text = "IP地址";
			this.chIP.Width = 120;
			// 
			// chState
			// 
			this.chState.Text = "连接状态";
			this.chState.Width = 90;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.miGrCollRd,
																						 this.miXGQueryCount,
																						 this.miXGClear,
																						 this.miXGSetTime,
																						 this.menuItem1,
																						 this.miPressAlarmSet,
																						 this.miTemperatureAlarmSet,
																						 this.miStopCycPump,
																						 this.miStopRePump});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// miGrCollRd
			// 
			this.miGrCollRd.Index = 0;
			this.miGrCollRd.Text = "采集供热数据";
			this.miGrCollRd.Visible = false;
			this.miGrCollRd.Click += new System.EventHandler(this.miGrCollRd_Click);
			// 
			// miXGQueryCount
			// 
			this.miXGQueryCount.Index = 1;
			this.miXGQueryCount.Text = "查询巡更记录";
			this.miXGQueryCount.Visible = false;
			this.miXGQueryCount.Click += new System.EventHandler(this.miXGQueryCount_Click);
			// 
			// miXGClear
			// 
			this.miXGClear.Index = 2;
			this.miXGClear.Text = "清除巡更数据";
			this.miXGClear.Visible = false;
			this.miXGClear.Click += new System.EventHandler(this.miXGClear_Click);
			// 
			// miXGSetTime
			// 
			this.miXGSetTime.Index = 3;
			this.miXGSetTime.Text = "同步巡更时间";
			this.miXGSetTime.Visible = false;
			this.miXGSetTime.Click += new System.EventHandler(this.miXGSetTime_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "室外温度-二次供温曲线";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// miPressAlarmSet
			// 
			this.miPressAlarmSet.Index = 5;
			this.miPressAlarmSet.Text = "压力报警值设定";
			this.miPressAlarmSet.Click += new System.EventHandler(this.miPressAlarmSet_Click);
			// 
			// miTemperatureAlarmSet
			// 
			this.miTemperatureAlarmSet.Index = 6;
			this.miTemperatureAlarmSet.Text = "温度报警值设定";
			this.miTemperatureAlarmSet.Click += new System.EventHandler(this.miTemperatureAlarmSet_Click);
			// 
			// miStopCycPump
			// 
			this.miStopCycPump.Index = 7;
			this.miStopCycPump.Text = "停止循环泵";
			this.miStopCycPump.Click += new System.EventHandler(this.miStopCycPump_Click);
			// 
			// miStopRePump
			// 
			this.miStopRePump.Index = 8;
			this.miStopRePump.Text = "停止补水泵";
			this.miStopRePump.Click += new System.EventHandler(this.miStopRePump_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(384, 8);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.TabIndex = 1;
			this.btnRefresh.Text = "刷新";
			this.btnRefresh.Visible = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnTempLine
			// 
			this.btnTempLine.Location = new System.Drawing.Point(384, 64);
			this.btnTempLine.Name = "btnTempLine";
			this.btnTempLine.Size = new System.Drawing.Size(88, 23);
			this.btnTempLine.TabIndex = 2;
			this.btnTempLine.Text = "二次供温曲线";
			this.btnTempLine.Click += new System.EventHandler(this.btnTempLine_Click);
			// 
			// btnPressAlarmSet
			// 
			this.btnPressAlarmSet.Location = new System.Drawing.Point(384, 96);
			this.btnPressAlarmSet.Name = "btnPressAlarmSet";
			this.btnPressAlarmSet.Size = new System.Drawing.Size(88, 23);
			this.btnPressAlarmSet.TabIndex = 3;
			this.btnPressAlarmSet.Text = "压力报警设定";
			this.btnPressAlarmSet.Click += new System.EventHandler(this.btnPressAlarmSet_Click);
			// 
			// btnTempAlarmSet
			// 
			this.btnTempAlarmSet.Location = new System.Drawing.Point(384, 128);
			this.btnTempAlarmSet.Name = "btnTempAlarmSet";
			this.btnTempAlarmSet.Size = new System.Drawing.Size(88, 23);
			this.btnTempAlarmSet.TabIndex = 4;
			this.btnTempAlarmSet.Text = "温度报警设定";
			this.btnTempAlarmSet.Click += new System.EventHandler(this.btnTempAlarmSet_Click);
			// 
			// btnStopCyclePump
			// 
			this.btnStopCyclePump.Location = new System.Drawing.Point(384, 160);
			this.btnStopCyclePump.Name = "btnStopCyclePump";
			this.btnStopCyclePump.Size = new System.Drawing.Size(88, 23);
			this.btnStopCyclePump.TabIndex = 5;
			this.btnStopCyclePump.Text = "停止循环泵";
			this.btnStopCyclePump.Click += new System.EventHandler(this.btnStopCyclePump_Click);
			// 
			// btnStopRecruitPump
			// 
			this.btnStopRecruitPump.Location = new System.Drawing.Point(384, 192);
			this.btnStopRecruitPump.Name = "btnStopRecruitPump";
			this.btnStopRecruitPump.Size = new System.Drawing.Size(88, 23);
			this.btnStopRecruitPump.TabIndex = 6;
			this.btnStopRecruitPump.Text = "停止补水泵";
			this.btnStopRecruitPump.Click += new System.EventHandler(this.btnStopRecruitPump_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 7;
			this.label1.Text = "已选择站点：";
			// 
			// btnStartRe
			// 
			this.btnStartRe.Location = new System.Drawing.Point(384, 256);
			this.btnStartRe.Name = "btnStartRe";
			this.btnStartRe.Size = new System.Drawing.Size(88, 23);
			this.btnStartRe.TabIndex = 10;
			this.btnStartRe.Text = "启动补水泵";
			this.btnStartRe.Click += new System.EventHandler(this.btnStartRe_Click);
			// 
			// btnStartCyc
			// 
			this.btnStartCyc.Location = new System.Drawing.Point(384, 224);
			this.btnStartCyc.Name = "btnStartCyc";
			this.btnStartCyc.Size = new System.Drawing.Size(88, 23);
			this.btnStartCyc.TabIndex = 9;
			this.btnStartCyc.Text = "启动循环泵";
			this.btnStartCyc.Click += new System.EventHandler(this.btnStartCyc_Click);
			// 
			// lblSelectedStation
			// 
			this.lblSelectedStation.ForeColor = System.Drawing.Color.Red;
			this.lblSelectedStation.Location = new System.Drawing.Point(128, 8);
			this.lblSelectedStation.Name = "lblSelectedStation";
			this.lblSelectedStation.Size = new System.Drawing.Size(232, 23);
			this.lblSelectedStation.TabIndex = 11;
			// 
			// btnGiveTempMode
			// 
			this.btnGiveTempMode.Location = new System.Drawing.Point(384, 32);
			this.btnGiveTempMode.Name = "btnGiveTempMode";
			this.btnGiveTempMode.Size = new System.Drawing.Size(88, 23);
			this.btnGiveTempMode.TabIndex = 12;
			this.btnGiveTempMode.Text = "供温模式";
			this.btnGiveTempMode.Click += new System.EventHandler(this.btnGiveTempMode_Click);
			// 
			// btnOpenDegree
			// 
			this.btnOpenDegree.Location = new System.Drawing.Point(384, 288);
			this.btnOpenDegree.Name = "btnOpenDegree";
			this.btnOpenDegree.Size = new System.Drawing.Size(88, 23);
			this.btnOpenDegree.TabIndex = 13;
			this.btnOpenDegree.Text = "调节阀开度";
			this.btnOpenDegree.Click += new System.EventHandler(this.btnOpenDegree_Click);
			// 
			// txtlog
			// 
			this.txtlog.Location = new System.Drawing.Point(384, 352);
			this.txtlog.Name = "txtlog";
			this.txtlog.Size = new System.Drawing.Size(88, 23);
			this.txtlog.TabIndex = 14;
			this.txtlog.Text = "操作记录";
			this.txtlog.Click += new System.EventHandler(this.txtlog_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(384, 320);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(88, 23);
			this.button1.TabIndex = 15;
			this.button1.Text = "室外温度参数";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnTimeTempLine
			// 
			this.btnTimeTempLine.Location = new System.Drawing.Point(384, 432);
			this.btnTimeTempLine.Name = "btnTimeTempLine";
			this.btnTimeTempLine.Size = new System.Drawing.Size(88, 23);
			this.btnTimeTempLine.TabIndex = 16;
			this.btnTimeTempLine.Text = "分时供热";
			this.btnTimeTempLine.Click += new System.EventHandler(this.btnTimeTempLine_Click);
			// 
			// btnPumpSetting
			// 
			this.btnPumpSetting.Location = new System.Drawing.Point(384, 400);
			this.btnPumpSetting.Name = "btnPumpSetting";
			this.btnPumpSetting.Size = new System.Drawing.Size(88, 23);
			this.btnPumpSetting.TabIndex = 17;
			this.btnPumpSetting.Text = "泵参数设置";
			this.btnPumpSetting.Click += new System.EventHandler(this.btnPumpSetting_Click);
			// 
			// frmControl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(482, 471);
			this.Controls.Add(this.btnPumpSetting);
			this.Controls.Add(this.btnTimeTempLine);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.txtlog);
			this.Controls.Add(this.btnOpenDegree);
			this.Controls.Add(this.btnGiveTempMode);
			this.Controls.Add(this.lblSelectedStation);
			this.Controls.Add(this.btnStartRe);
			this.Controls.Add(this.btnStartCyc);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lvGprsStation);
			this.Controls.Add(this.btnPressAlarmSet);
			this.Controls.Add(this.btnTempAlarmSet);
			this.Controls.Add(this.btnStopRecruitPump);
			this.Controls.Add(this.btnStopCyclePump);
			this.Controls.Add(this.btnTempLine);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "远程控制";
			this.Load += new System.EventHandler(this.frmControl_Load);
			this.ResumeLayout(false);

		}
        #endregion
        
        private const int DEFAILT_ADDRESS = 0;

        private void ShowNotConnectedMsg()
        {
             MsgBox.Show( "该站点尚未与中心建立连接" );
        }

        private void miGrCollRd_Click(object sender, System.EventArgs e)
        {
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected( remoteIP  ) )
                {
                    GRCollRealData ( remoteIP, DEFAILT_ADDRESS );
                }
                else
                {
                    ShowNotConnectedMsg();
                    return ;
                }
            }
        }

        private void miXGSetTime_Click(object sender, System.EventArgs e)
        {
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected ( remoteIP ) )
                {
                    XGSetTime ( remoteIP , DEFAILT_ADDRESS );
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }
        }

        private void miXGClear_Click(object sender, System.EventArgs e)
        {
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected ( remoteIP ) )
                {
                    XGClear ( remoteIP , DEFAILT_ADDRESS );
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }
        }

        private void miXGQueryCount_Click(object sender, System.EventArgs e)
        {
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected ( remoteIP ) )
                {
                    XGQueryCount ( remoteIP , DEFAILT_ADDRESS );
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }      
        }

        /// <summary>
        /// read temperature line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
//            string remoteIP = GetRemoteIP();
//            if ( remoteIP != string.Empty )
//            {
//                //TODO: remove !
//                if ( IsConnected ( remoteIP ) )
//                {
//                    frmTempLine f = new frmTempLine( GetGRStation ( remoteIP, DEFAILT_ADDRESS ) );
//                    f.ShowDialog();
////                    ReadTL( remoteIP, DEFAILT_ADDRESS );
//                }
//                else
//                {
//                    ShowNotConnectedMsg();
//                    return;
//                }
//            }      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        private bool IsConnected( string remoteIP )
        {
            CommPortProxysCollection  cpps = Singles.S.TaskScheduler.CppsCollection;
            foreach ( CommPortProxy c in cpps )
            {
                if ( c.RemoteHostIP == remoteIP &&
                    c.IsConnected )
                    return true;
            }
            return false;
        }

//        private bool IsNameConnected

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GRStation GetGRStation()
        {
            if ( this.lvGprsStation.SelectedItems.Count >0 )
            {
                ListViewItem lvi = lvGprsStation.SelectedItems[0];
                string stName = lvi.Text;
                GRStation st = Singles.S.GRStsCollection.GetGRStation( stName );
                return st;
//                return stName;
            }
            return null;
        }

        private bool IsSelect()
        {
            return this.lvGprsStation.SelectedItems.Count > 0;
        }

        private string GetSelectName()
        {
            if ( IsSelect () )
            {
                ListViewItem lvi = lvGprsStation.SelectedItems[ 0 ];
                return lvi.Text;
            }
            return string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetRemoteIP ()
        {
            if (this.lvGprsStation.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvGprsStation.SelectedItems[0];
                string stName = lvi.Text ;
                string remoteIp = lvi.SubItems[1].Text;
                string state = lvi.SubItems[2].Text;

                return remoteIp;
            }
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private GRStation GetGRStation( string remoteIP, int address )
        {
//            return new GRStation( "n", address, remoteIP );
            return Singles.S.GRStsCollection.GetGRStation( remoteIP, address );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private XGStation GetXGStation( string remoteIP, int address )
        {
            return Singles.S.GetXGStation( remoteIP, address );
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshLV()
        {
            this.lvGprsStation.Items.Clear();
//            CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;
//            this.lvGprsStation.Items.Add( "A").SubItems.AddRange(new string[]{"1.1.1.1","con"});

            GRStationsCollection grSts = Singles.S.GRStsCollection;

            foreach ( GRStation st in grSts )
            {
                if ( st.ServerIP == XGConfig.Default.ServerIP )
                {
                    if ( IsConnected( st.DestinationIP ) )
                    {
                        ListViewItem lvi =  this.lvGprsStation.Items.Add( st.StationName );
                        lvi.SubItems.AddRange( new string[] {
                                                                st.DestinationIP,
                                                                GetConnectState ( st.DestinationIP )
                                                            } );
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        private string GetConnectState ( string remoteIP )
        {
            CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;
            foreach ( CommPortProxy cpp in cpps )
            {
                if ( cpp.RemoteHostIP == remoteIP && 
                    cpp.IsConnected ) 
                {
                    return "已连接";
                }
            }
            return "未连接";
        }
            
        #region Render

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        private void GRCollRealData( string remoteIP, int address )
        {
            GRStation st = GetGRStation ( remoteIP, address );
            if ( st != null )
            {
                GRRealDataCommand cmd = new GRRealDataCommand( st );
//                Task t = new Task( cmd, new ImmediateTaskStrategy () );
////                t.BeforeExecuteTask += new EventHandler(t_BeforeExecuteTask);
////                t.AfterExecuteTask  += new EventHandler(t_AfterExecuteTask);
//                Singles.S.TaskScheduler.Tasks.Add( t );
//
//                frmControlProcess f = new frmControlProcess( t );
//                f.ShowDialog();
                this.CreateImmediateTaskAndExecute( cmd );
            }
        }



        private void XGQueryCount( string remoteIP, int address )
        {
            XGStation xgSt = GetXGStation ( remoteIP, address );
            if ( xgSt != null )
            {
                ReadTotalCountCommand cmd = new ReadTotalCountCommand( xgSt );
                this.CreateImmediateTaskAndExecute( cmd );
            }
        }


        private void ReadTL( string remoteIP, int address )
        {
            GRStation st = GetGRStation ( remoteIP, address );
            if ( st != null )
            {
                GRReadTLCommand c = new GRReadTLCommand( st );
                this.CreateImmediateTaskAndExecute( c );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        private void XGSetTime( string remoteIP, int address )
        {
            XGStation xgSt = GetXGStation ( remoteIP , address );
            if ( xgSt != null )
            {
                DateTime now = DateTime.Now;
                int h = now.Hour;
                int m = now.Minute;
                int s = now.Second;

                ModifyTimeCommand cmd = new ModifyTimeCommand( xgSt, h, m, s );
//                Task t = new Task( cmd, new ImmediateTaskStrategy () );
//                Singles.S.TaskScheduler.Tasks.Add( t );
//                frmControlProcess f = new frmControlProcess( t );
//                f.ShowDialog();
                this.CreateImmediateTaskAndExecute( cmd );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void CreateImmediateTaskAndExecute( CommCmdBase cmd )
        {
            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add ( t );
            frmControlProcess f = new frmControlProcess( t );
            f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <param name="address"></param>
        private void XGClear( string remoteIP, int address )
        {
            XGStation xgst = GetXGStation ( remoteIP,address );
            if ( xgst != null )
            {
                RemoveAllCommand cmd = new RemoveAllCommand( xgst );
//                Task t = new Task( cmd, new ImmediateTaskStrategy () );
//                Singles.S.TaskScheduler.Tasks.Add ( t );
//                frmControlProcess f = new frmControlProcess( t );
//                f.ShowDialog();
                this.CreateImmediateTaskAndExecute( cmd );
            }
        }

        #endregion //Render

        private void frmControl_Load(object sender, System.EventArgs e)
        {
            this.RefreshLV();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshLV();
        }

        #region mi
        private void miPressAlarmSet_Click(object sender, System.EventArgs e)
        {
            
        }

        private void miTemperatureAlarmSet_Click(object sender, System.EventArgs e)
        {
            
        }

        private void contextMenu1_Popup(object sender, System.EventArgs e)
        {
        
        }

        private void miStopCycPump_Click(object sender, System.EventArgs e)
        {
            
        }

        private void miStopRePump_Click(object sender, System.EventArgs e)
        {
        }
        #endregion //mi

        /// <summary>
        /// stop cycle pump operation
        /// </summary>
//        private void StopCycPump()
        private void StopCycPump ( bool isStop )
        {
            GRStation st = GetGRStation();

            // is conncection
            //
            if ( st != null &&
                IsConnected( st.DestinationIP ) )
            {
//                bool isStop = chkStop.Checked;

                GRCyclePumpOpCmd c = new GRCyclePumpOpCmd( st, 
                    isStop ? PumpOP.Stop : PumpOP.Start );
                string op = string.Format( "{0}循环泵", isStop ? "停止" : "启动" );
                XGDB.InsertCtrlLog( DateTime.Now, st.StationName, op, "xd");
                CreateImmediateTaskAndExecute( c );
            }
            else
            {
                ShowNotConnectedMsg();
            }
        }

        /// <summary>
        /// stop recruit pump operation
        /// </summary>
        private void StopRePump( bool isStop )
        {
            
            GRStation st = GetGRStation();
            if ( st != null &&
                IsConnected ( st.DestinationIP ) )
            {
//                bool isStop = chkStop.Checked;

                GRRePumpOpCmd c = new GRRePumpOpCmd( st, 
                    isStop ? PumpOP.Stop : PumpOP.Start );

                string op = string.Format( "{0}补水泵", isStop ? "停止" : "启动" );
                XGDB.InsertCtrlLog( DateTime.Now, st.StationName, op, "xd");

                CreateImmediateTaskAndExecute ( c );
            }
            else
            {
                ShowNotConnectedMsg();
            }
        }

        private void ShowNotSelectMsg()
        {
            MsgBox.Show( "请先选择站点" );
        }
        /// <summary>
        /// temp line set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTempLine_Click(object sender, System.EventArgs e)
        {
            if ( !IsSelect () )
            {
                ShowNotSelectMsg();
                return ;
            }
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                //TODO: remove !
                if ( IsConnected ( remoteIP ) )
                {
                    frmTempLine f = new frmTempLine( GetGRStation ( remoteIP, DEFAILT_ADDRESS ) );
                    f.ShowDialog();
                    //                    ReadTL( remoteIP, DEFAILT_ADDRESS );
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }     
        }

        /// <summary>
        /// press alarm set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPressAlarmSet_Click(object sender, System.EventArgs e)
        {
            if ( !IsSelect () )
            {
                ShowNotSelectMsg();
                return ;
            }

            string ip = GetRemoteIP ();

            GRStation st = this.GetGRStation( ip, DEFAILT_ADDRESS );
            if ( st != null &&
                IsConnected ( ip ) )
            {
                frmPressAlarmSet f = new frmPressAlarmSet( st );
                f.ShowDialog();
            }
            else
            {
                ShowNotConnectedMsg();
            }
        }

        /// <summary>
        /// temp alarm set
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTempAlarmSet_Click(object sender, System.EventArgs e)
        {
            string ip = GetRemoteIP ();
            if ( ip == string.Empty )
            {
                ShowNotSelectMsg(); 
                return ;
            }

            GRStation st = this.GetGRStation( ip, DEFAILT_ADDRESS );
            if ( st != null &&
                IsConnected ( ip ) )
            {
                frmTemperatureAlarmSet f = new frmTemperatureAlarmSet( st );
                f.ShowDialog();
            }
            else
            {
                ShowNotConnectedMsg();
            }
        }

        private void btnStopCyclePump_Click(object sender, System.EventArgs e)
        {

            if ( ! IsSelect () )
            {
                ShowNotSelectMsg();
                return ;
            }

            string msg = string.Format ("您确定要{0} {1} {2}吗?", 
                GT.TEXT_STOP, GetSelectName(), GT.TEXT_CYCLEPUMP );
            if ( MessageBox.Show( msg, GT.TEXT_TIP, MessageBoxButtons.YesNo, MessageBoxIcon.Question )
                == DialogResult.Yes )
            {
                StopCycPump( true );
            }
        }

        private void btnStopRecruitPump_Click(object sender, System.EventArgs e)
        {    
            if ( !IsSelect() )
            {
                ShowNotSelectMsg();
                return;
            }

            string msg = string.Format ("您确定要{0} {1} {2}吗?", 
                GT.TEXT_STOP, GetSelectName(), GT.TEXT_RECRUITPUMP );
            if ( MessageBox.Show( msg, GT.TEXT_TIP, MessageBoxButtons.YesNo, MessageBoxIcon.Question )
                == DialogResult.Yes )
            {
                StopRePump( true );
            }
        }

        private void btnStartCyc_Click(object sender, System.EventArgs e)
        {
            if ( !IsSelect() )
            {
                ShowNotSelectMsg();
                return;
            }

            string msg = string.Format (
                "您确定要{0} {1} {2}吗?", 
                GT.TEXT_START, 
                GetSelectName(), 
                GT.TEXT_CYCLEPUMP 
                );
            
            if ( MessageBox.Show( 
                    msg, 
                    GT.TEXT_TIP, 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question 
                    )
                 == DialogResult.Yes )
            {          
                StopCycPump( false );
            }
        }

        private void btnStartRe_Click(object sender, System.EventArgs e)
        {
            if ( !IsSelect() )
            {
                ShowNotSelectMsg();
                return;
            }

            string msg = string.Format ("您确定要{0} {1} {2}吗?", 
                GT.TEXT_START, GetSelectName(), GT.TEXT_RECRUITPUMP );
            if ( MessageBox.Show( msg, GT.TEXT_TIP, MessageBoxButtons.YesNo, MessageBoxIcon.Question )
                == DialogResult.Yes )
            {   
                StopRePump ( false );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvGprsStation_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.lblSelectedStation.Text = this.GetSelectName();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGiveTempMode_Click(object sender, System.EventArgs e)
        {
            if ( !IsSelect () )
            {
                ShowNotSelectMsg();
                return ;
            }
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected ( remoteIP ) )
                {
                    GRStation grst = GetGRStation( remoteIP, DEFAILT_ADDRESS );
                    frmGiveTempMode f = new frmGiveTempMode( grst );
                    f.ShowDialog();
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }     
        }

        private void btnOpenDegree_Click(object sender, System.EventArgs e)
        {
            if( !IsSelect () )
            {
                ShowNotSelectMsg();
                return;
            }
            string remoteIP = GetRemoteIP();
            if ( remoteIP != string.Empty )
            {
                if ( IsConnected ( remoteIP ) )
                {
                    GRStation grst = GetGRStation( remoteIP, DEFAILT_ADDRESS );
//                    frmGiveTempMode f = new frmGiveTempMode( grst );
                    frmOpenDegree f = new frmOpenDegree( grst );
                    f.ShowDialog();
                }
                else
                {
                    ShowNotConnectedMsg();
                    return;
                }
            }     

        }

		private void txtlog_Click(object sender, System.EventArgs e)
		{
			frmctrllog log = new frmctrllog();
			log.ShowDialog( this );
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			// out t op

			if( !IsSelect () )
			{
				ShowNotSelectMsg();
				return;
			}
			string remoteIP = GetRemoteIP();
			if ( remoteIP != string.Empty )
			{
				if ( IsConnected ( remoteIP ) )
				{
					GRStation grst = GetGRStation( remoteIP, DEFAILT_ADDRESS );
					//                    frmGiveTempMode f = new frmGiveTempMode( grst );
					//frmOpenDegree f = new frmOpenDegree( grst );
					frmOTOP f = new frmOTOP( grst );
					f.ShowDialog();
				}
				else
				{
					ShowNotConnectedMsg();
					return;
				}
			}     
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTimeTempLine_Click(object sender, System.EventArgs e)
		{
			frmTimeTempSetting f = new frmTimeTempSetting();
			f.ShowDialog( this );
		}

		private void btnPumpSetting_Click(object sender, System.EventArgs e)
		{
			frmPumpParamSetting f = new frmPumpParamSetting();
			f.ShowDialog( this );
		}

    }
}
