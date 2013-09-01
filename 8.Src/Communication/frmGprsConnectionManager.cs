namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using CFW;
    using System.Data;

    #region frmGprsConnectionManager
    /// <summary>
    /// frmGprsConnectionManager 的摘要说明。
    /// </summary>
    public class frmGprsConnectionManager : System.Windows.Forms.Form
    {

        private static frmGprsConnectionManager s_default = new frmGprsConnectionManager();
        public  static frmGprsConnectionManager Default
        {
            get { return s_default; }
        }

        private System.Windows.Forms.ColumnHeader chRemoteIP;
        private System.Windows.Forms.ColumnHeader chRemotePort;
        private System.Windows.Forms.ColumnHeader chState;
        private System.Windows.Forms.ColumnHeader chLocalIP;
        private System.Windows.Forms.ColumnHeader chLocalPort;
        private System.Windows.Forms.ListView lvCpps;
        private System.Windows.Forms.ColumnHeader chCreateTime;
        private System.Windows.Forms.ColumnHeader chSN;
        private DataTable _gprsTable = null;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ColumnHeader chStationName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbRefresh;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel sbpServerIP;
        private System.Windows.Forms.StatusBarPanel sbpListenState;
        private System.Windows.Forms.StatusBarPanel sbpConnState;
        private string [] _wsStateTexts =  new string[]{
                                                           "关闭",          //"sckClosed",
                                                           "打开",          //"sckOpen",
                                                           "监听",          //"sckListening",
                                                           "连接挂起",      //"sckConnectionPending",
                                                           "识别主机",      //"sckResolvingHost",
                                                           "已识别主机",    //"sckHostResolved",
                                                           "正在连接",      //"sckConnecting",
                                                           "已连接",        //"sckConnected",
                                                           "正在关闭",      //"sckClosing",
                                                           "错误",          //"sckError"
                                                       };

        public frmGprsConnectionManager()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGprsConnectionManager));
            this.lvCpps = new System.Windows.Forms.ListView();
            this.chSN = new System.Windows.Forms.ColumnHeader();
            this.chStationName = new System.Windows.Forms.ColumnHeader();
            this.chLocalIP = new System.Windows.Forms.ColumnHeader();
            this.chLocalPort = new System.Windows.Forms.ColumnHeader();
            this.chRemoteIP = new System.Windows.Forms.ColumnHeader();
            this.chRemotePort = new System.Windows.Forms.ColumnHeader();
            this.chState = new System.Windows.Forms.ColumnHeader();
            this.chCreateTime = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpServerIP = new System.Windows.Forms.StatusBarPanel();
            this.sbpListenState = new System.Windows.Forms.StatusBarPanel();
            this.sbpConnState = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sbpServerIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpListenState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpConnState)).BeginInit();
            this.SuspendLayout();
            // 
            // lvCpps
            // 
            this.lvCpps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCpps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                     this.chSN,
                                                                                     this.chStationName,
                                                                                     this.chLocalIP,
                                                                                     this.chLocalPort,
                                                                                     this.chRemoteIP,
                                                                                     this.chRemotePort,
                                                                                     this.chState,
                                                                                     this.chCreateTime});
            this.lvCpps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCpps.FullRowSelect = true;
            this.lvCpps.GridLines = true;
            this.lvCpps.Location = new System.Drawing.Point(0, 41);
            this.lvCpps.Name = "lvCpps";
            this.lvCpps.Size = new System.Drawing.Size(896, 414);
            this.lvCpps.TabIndex = 0;
            this.lvCpps.View = System.Windows.Forms.View.Details;
            this.lvCpps.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCpps_ColumnClick);
            this.lvCpps.SelectedIndexChanged += new System.EventHandler(this.lvCpps_SelectedIndexChanged);
            // 
            // chSN
            // 
            this.chSN.Text = "序号";
            // 
            // chStationName
            // 
            this.chStationName.Text = "站名";
            this.chStationName.Width = 120;
            // 
            // chLocalIP
            // 
            this.chLocalIP.Text = "本地地址";
            this.chLocalIP.Width = 100;
            // 
            // chLocalPort
            // 
            this.chLocalPort.Text = "本地端口";
            this.chLocalPort.Width = 100;
            // 
            // chRemoteIP
            // 
            this.chRemoteIP.Text = "远程地址";
            this.chRemoteIP.Width = 100;
            // 
            // chRemotePort
            // 
            this.chRemotePort.Text = "远程端口";
            this.chRemotePort.Width = 100;
            // 
            // chState
            // 
            this.chState.Text = "连接状态";
            this.chState.Width = 100;
            // 
            // chCreateTime
            // 
            this.chCreateTime.Text = "创建时间";
            this.chCreateTime.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbbRefresh,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(896, 41);
            this.toolBar1.TabIndex = 2;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbRefresh
            // 
            this.tbbRefresh.ImageIndex = 4;
            this.tbbRefresh.Text = "刷新";
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 3;
            this.tbbExit.Text = "退出";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 455);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                          this.sbpServerIP,
                                                                                          this.sbpListenState,
                                                                                          this.sbpConnState});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(896, 22);
            this.statusBar1.TabIndex = 3;
            // 
            // sbpServerIP
            // 
            this.sbpServerIP.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpServerIP.Width = 250;
            // 
            // sbpListenState
            // 
            this.sbpListenState.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpListenState.Width = 250;
            // 
            // sbpConnState
            // 
            this.sbpConnState.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.sbpConnState.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpConnState.Width = 380;
            // 
            // frmGprsConnectionManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(896, 477);
            this.Controls.Add(this.lvCpps);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmGprsConnectionManager";
            this.Text = "GPRS连接管理";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGprsConnectionManager_Closing);
            this.Load += new System.EventHandler(this.frmGprsConnectionManager_Load);
            this.Activated += new System.EventHandler(this.frmGprsConnectionManager_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.sbpServerIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpListenState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpConnState)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region frmGprsConnectionManager_Load
        private void frmGprsConnectionManager_Load(object sender, System.EventArgs e)
        {
            RefreshCpps();
            this.RefreshStatusBar();
        }
        #endregion //frmGprsConnectionManager_Load

        #region RefreshStatusBar
        private void RefreshStatusBar()
        {
            this.sbpServerIP.Text = GetServerIP();
            this.sbpListenState.Text = this.GetListenState();

            //TODO: connected count and unconnected count
            //
            // this.sbpConnState 

        }
        #endregion //RefreshStatusBar

        private string GetServerIP()
        {
            return "服务器IP地址: " +  XGConfig.Default.ServerIP;
        }

        private string GetListenState()
        {
            return "端口: " + XGConfig.Default.ListenPort + 
                ( Singles.S.GprsListen.IsListening ? " 正在监听 " : "　未监听　" );
        }
        
        #region RefreshCpps
        private void RefreshCpps()
        {
            this.LoadGprsTable();

            this.lvCpps.Items.Clear();
            //MsgBox.Show( lvCpps.Columns.Count.ToString() );
            int i = 1;
            CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;

            // connected gprs
            //
            foreach ( CommPortProxy c in cpps )
            {
                ListViewItem lvi = this.lvCpps.Items.Add( i++.ToString("00") );    
                string[] subItems = new string[] {  GetGprsStationName( c.RemoteHostIP ),
                                                     c.LocalHostIP, 
                                                     c.LocalPort.ToString(), 
                                                     c.RemoteHostIP, 
                                                     c.RemotePort.ToString(), 
                                                     GetStateText( c.State ), 
                                                     c.CreateTime.ToString() };
                lvi.SubItems.AddRange( subItems );
            }

            // not connected gprs
            // 
            foreach ( DataRow r in _gprsTable.Rows )
            {
                string name = r["name"].ToString();
                ListViewItem lvi = this.lvCpps.Items.Add( i++.ToString("00") );
                string [] subItems = new string[] {    name,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    string.Empty,
                                                    "未连接",
                                                    string.Empty,
                                               };
                lvi.SubItems.AddRange( subItems );
            }

            this.lvCpps.Refresh();
        }
        #endregion //RefreshCpps

        #region GetGprsStationName
        private string  GetGprsStationName( string remoteIP )
        {
            if ( _gprsTable == null )
                return string.Empty;

            foreach ( DataRow r in _gprsTable.Rows )
            {
                if ( r["ip"].ToString().Trim() == remoteIP )
                {
                    // 2007.03.16 Modify for get not connected station name
                    //
                    //return r["name"].ToString();
                    string s = r["name"].ToString();
                    _gprsTable.Rows.Remove( r );
                    return s;
                }
            }

            return string.Empty;
        }
        #endregion //GetGprsStationName

        #region LoadGprsTable
        private void LoadGprsTable()
        {
            string sql = string.Format( "select * from tbl_gprs_station where serverip = '{0}'",
                XGConfig.Default.ServerIP );
            _gprsTable = XGDB.DbClient.Execute( sql ).Tables[0];
        }
        #endregion //LoadGprsTable

        // 2007.03.09 Added replace with toolBox
        //
        //private void btnRefresh_Click(object sender, System.EventArgs e)
        //{
        //RefreshCpps();
        //}

        #region GetStateText
        private string GetStateText( short state )
        {
            return _wsStateTexts[state];
        }
        #endregion //GetStateText 

        int _lastSortColumn = -1;
        bool _isAsc;

        #region FormEvent
        private void lvCpps_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
//            this.lvCpps.ListViewItemSorter = new ListViewItemComparer(e.Column);
//            lvCpps.Sort();
            int col = e.Column;
            if ( col == _lastSortColumn )
                _isAsc = !_isAsc ;
            else
                _isAsc = true;

            this.lvCpps.ListViewItemSorter = new ListViewItemComparer ( col, _isAsc );
            this.lvCpps.Sort();

            _lastSortColumn = col;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGprsConnectionManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //TODO: 2007-10-17 处理该窗体弹不出来问题。
            //
            e.Cancel = true;
            // 2007-10-26 Added
            //
            if ( this.MdiParent != null )
                MdiParent = null;
            this.Hide();
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == this.tbbRefresh )
            {
                this.RefreshCpps();
                this.RefreshStatusBar();
            }
            if ( e.Button == this.tbbExit )
                Close ();
        }
        #endregion //FormEvent

        #region frmGprsConnectionManager_Activated
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGprsConnectionManager_Activated(object sender, System.EventArgs e)
        {
            this.RefreshCpps();
            this.RefreshStatusBar();
        }
        #endregion //frmGprsConnectionManager_Activated

        private void lvCpps_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        
        }
    }
    #endregion //frmGprsConnectionManager

//    #region ListViewItemComparer
//    /// <summary>
//    /// 
//    /// </summary>
//    class ListViewItemComparer : IComparer 
//    {
//        private int col;
//        public ListViewItemComparer() 
//        {
//            col=0;
//        }
//        public ListViewItemComparer(int column) 
//        {
//            col=column;
//        }
//        public int Compare(object x, object y) 
//        {
//            //            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
//            return 0;
//        }
//    }
//    #endregion //ListViewItemComparer

}
