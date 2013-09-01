namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Communication.GRCtrl;
    using CFW;
    using System.Data;
    using Excel;
    using System.IO;
    using System.Diagnostics;

    #region frmAllGRRealDatas
    /// <summary>
    /// 显示所有供热站点的实时采集数据
    /// </summary>
    public class frmAllGRRealDatas : System.Windows.Forms.Form
    {

        #region Default
        private static frmAllGRRealDatas s_default = new frmAllGRRealDatas();
        public static frmAllGRRealDatas Default
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Members
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvGrStRds;
        private System.Windows.Forms.ColumnHeader chStName;
        private System.Windows.Forms.ColumnHeader chDateTime;
        private System.Windows.Forms.ColumnHeader chOneGP;
        private System.Windows.Forms.ColumnHeader chOneBP;
        private System.Windows.Forms.ColumnHeader chOneGT;
        private System.Windows.Forms.ColumnHeader chOneBT;
        private System.Windows.Forms.ColumnHeader chOneInstant;
        private System.Windows.Forms.ColumnHeader chOneAcc;
        private System.Windows.Forms.ColumnHeader chTwoGP;
        private System.Windows.Forms.ColumnHeader chTwoBP;
        private System.Windows.Forms.ColumnHeader chTwoGT;
        private System.Windows.Forms.ColumnHeader chTwoBT;
        private System.Windows.Forms.ColumnHeader chTwoInstant;
        private System.Windows.Forms.ColumnHeader chTwoAcc;
        private System.Windows.Forms.ColumnHeader chTwoBaseBT;
        private System.Windows.Forms.ColumnHeader chOpenDegree;
        private System.Windows.Forms.ColumnHeader chWL;
        private System.Windows.Forms.ColumnHeader chDrangeSet;
        private System.Windows.Forms.ColumnHeader chDrangeSubSet;
        private System.Windows.Forms.ColumnHeader clOutSideT;
        private System.Windows.Forms.ColumnHeader chCycPump1;
        private System.Windows.Forms.ColumnHeader chCycPump2;
        private System.Windows.Forms.ColumnHeader chCycPump3;
        private System.Windows.Forms.ColumnHeader chRecuuitPump1;
        private System.Windows.Forms.ColumnHeader chRecuuitPump2;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbRefresh;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton tbbCollGRRD;
        private System.Windows.Forms.Timer timerReadGRStationRD;
        private System.Windows.Forms.ToolBarButton tbbDetail;
        private System.Windows.Forms.Panel panel1;
        private Communication.GRRealDataDetail grRealDataDetail1;
        private System.Windows.Forms.ToolBarButton tbbFont;
        private System.ComponentModel.IContainer components;

        int _lastSortColumn = -1;
        private System.Windows.Forms.ContextMenu cmColl;
        private System.Windows.Forms.MenuItem miCollGRRD;
        private System.Windows.Forms.MenuItem miCollXG;
        private System.Windows.Forms.ColumnHeader chTeam;
        private System.Windows.Forms.ToolBarButton tbbExport;
        bool _isAsc;

        #endregion //Members

        #region Constructor
        public frmAllGRRealDatas()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            //

            this.btnRefresh.Visible = false;
            Singles.S.GRStRds.Changed += new EventHandler(GRStRds_Changed);
//            this.tbbDetail.Visible = false;
//            this.grRealDataDetail1.Visible = false;
            this.panel1.Visible = false;
        }
        #endregion //Constructor

        #region Dispose
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

        #endregion //Dispose

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAllGRRealDatas));
            this.lvGrStRds = new System.Windows.Forms.ListView();
            this.chTeam = new System.Windows.Forms.ColumnHeader();
            this.chStName = new System.Windows.Forms.ColumnHeader();
            this.chDateTime = new System.Windows.Forms.ColumnHeader();
            this.chOneGP = new System.Windows.Forms.ColumnHeader();
            this.chOneBP = new System.Windows.Forms.ColumnHeader();
            this.chOneGT = new System.Windows.Forms.ColumnHeader();
            this.chOneBT = new System.Windows.Forms.ColumnHeader();
            this.chOneInstant = new System.Windows.Forms.ColumnHeader();
            this.chOneAcc = new System.Windows.Forms.ColumnHeader();
            this.chTwoGP = new System.Windows.Forms.ColumnHeader();
            this.chTwoBP = new System.Windows.Forms.ColumnHeader();
            this.chTwoGT = new System.Windows.Forms.ColumnHeader();
            this.chTwoBT = new System.Windows.Forms.ColumnHeader();
            this.chTwoInstant = new System.Windows.Forms.ColumnHeader();
            this.chTwoAcc = new System.Windows.Forms.ColumnHeader();
            this.chTwoBaseBT = new System.Windows.Forms.ColumnHeader();
            this.chOpenDegree = new System.Windows.Forms.ColumnHeader();
            this.chWL = new System.Windows.Forms.ColumnHeader();
            this.chDrangeSet = new System.Windows.Forms.ColumnHeader();
            this.chDrangeSubSet = new System.Windows.Forms.ColumnHeader();
            this.clOutSideT = new System.Windows.Forms.ColumnHeader();
            this.chCycPump1 = new System.Windows.Forms.ColumnHeader();
            this.chCycPump2 = new System.Windows.Forms.ColumnHeader();
            this.chCycPump3 = new System.Windows.Forms.ColumnHeader();
            this.chRecuuitPump1 = new System.Windows.Forms.ColumnHeader();
            this.chRecuuitPump2 = new System.Windows.Forms.ColumnHeader();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbRefresh = new System.Windows.Forms.ToolBarButton();
            this.tbbCollGRRD = new System.Windows.Forms.ToolBarButton();
            this.cmColl = new System.Windows.Forms.ContextMenu();
            this.miCollGRRD = new System.Windows.Forms.MenuItem();
            this.miCollXG = new System.Windows.Forms.MenuItem();
            this.tbbDetail = new System.Windows.Forms.ToolBarButton();
            this.tbbFont = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerReadGRStationRD = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.grRealDataDetail1 = new Communication.GRRealDataDetail();
            this.tbbExport = new System.Windows.Forms.ToolBarButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvGrStRds
            // 
            this.lvGrStRds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.chTeam,
                                                                                        this.chStName,
                                                                                        this.chDateTime,
                                                                                        this.chOneGP,
                                                                                        this.chOneBP,
                                                                                        this.chOneGT,
                                                                                        this.chOneBT,
                                                                                        this.chOneInstant,
                                                                                        this.chOneAcc,
                                                                                        this.chTwoGP,
                                                                                        this.chTwoBP,
                                                                                        this.chTwoGT,
                                                                                        this.chTwoBT,
                                                                                        this.chTwoInstant,
                                                                                        this.chTwoAcc,
                                                                                        this.chTwoBaseBT,
                                                                                        this.chOpenDegree,
                                                                                        this.chWL,
                                                                                        this.chDrangeSet,
                                                                                        this.chDrangeSubSet,
                                                                                        this.clOutSideT,
                                                                                        this.chCycPump1,
                                                                                        this.chCycPump2,
                                                                                        this.chCycPump3,
                                                                                        this.chRecuuitPump1,
                                                                                        this.chRecuuitPump2});
            this.lvGrStRds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGrStRds.FullRowSelect = true;
            this.lvGrStRds.GridLines = true;
            this.lvGrStRds.Location = new System.Drawing.Point(0, 41);
            this.lvGrStRds.Name = "lvGrStRds";
            this.lvGrStRds.Size = new System.Drawing.Size(848, 244);
            this.lvGrStRds.TabIndex = 0;
            this.lvGrStRds.View = System.Windows.Forms.View.Details;
            this.lvGrStRds.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvGrStRds_ColumnClick);
            this.lvGrStRds.SelectedIndexChanged += new System.EventHandler(this.lvGrStRds_SelectedIndexChanged);
            // 
            // chTeam
            // 
            this.chTeam.Text = "班组";
            this.chTeam.Width = 40;
            // 
            // chStName
            // 
            this.chStName.Text = "站点名称";
            this.chStName.Width = 120;
            // 
            // chDateTime
            // 
            this.chDateTime.Text = "时间";
            this.chDateTime.Width = 120;
            // 
            // chOneGP
            // 
            this.chOneGP.Text = "一次供水压力";
            this.chOneGP.Width = 90;
            // 
            // chOneBP
            // 
            this.chOneBP.Text = "一次回水压力";
            this.chOneBP.Width = 90;
            // 
            // chOneGT
            // 
            this.chOneGT.Text = "一次供水温度";
            this.chOneGT.Width = 90;
            // 
            // chOneBT
            // 
            this.chOneBT.Text = "一次回水温度";
            this.chOneBT.Width = 90;
            // 
            // chOneInstant
            // 
            this.chOneInstant.Text = "一次瞬时流量";
            this.chOneInstant.Width = 90;
            // 
            // chOneAcc
            // 
            this.chOneAcc.Text = "一次累计流量";
            this.chOneAcc.Width = 90;
            // 
            // chTwoGP
            // 
            this.chTwoGP.Text = "二次供水压力";
            this.chTwoGP.Width = 90;
            // 
            // chTwoBP
            // 
            this.chTwoBP.Text = "二次回水压力";
            this.chTwoBP.Width = 90;
            // 
            // chTwoGT
            // 
            this.chTwoGT.Text = "二次供水温度";
            this.chTwoGT.Width = 90;
            // 
            // chTwoBT
            // 
            this.chTwoBT.Text = "二次回水温度";
            this.chTwoBT.Width = 90;
            // 
            // chTwoInstant
            // 
            this.chTwoInstant.Text = "二次瞬时流量";
            this.chTwoInstant.Width = 90;
            // 
            // chTwoAcc
            // 
            this.chTwoAcc.Text = "二次累计流量";
            this.chTwoAcc.Width = 90;
            // 
            // chTwoBaseBT
            // 
            this.chTwoBaseBT.Text = "二次供温基准";
            this.chTwoBaseBT.Width = 90;
            // 
            // chOpenDegree
            // 
            this.chOpenDegree.Text = "调节阀开度";
            this.chOpenDegree.Width = 90;
            // 
            // chWL
            // 
            this.chWL.Text = "水箱水位";
            // 
            // chDrangeSet
            // 
            this.chDrangeSet.Text = "补水压力设定";
            this.chDrangeSet.Width = 90;
            // 
            // chDrangeSubSet
            // 
            this.chDrangeSubSet.Text = "压差设定";
            this.chDrangeSubSet.Width = 90;
            // 
            // clOutSideT
            // 
            this.clOutSideT.Text = "室外温度";
            // 
            // chCycPump1
            // 
            this.chCycPump1.Text = "循环泵1";
            // 
            // chCycPump2
            // 
            this.chCycPump2.Text = "循环泵2";
            // 
            // chCycPump3
            // 
            this.chCycPump3.Text = "循环泵3";
            // 
            // chRecuuitPump1
            // 
            this.chRecuuitPump1.Text = "补水泵1";
            // 
            // chRecuuitPump2
            // 
            this.chRecuuitPump2.Text = "补水泵2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(768, 648);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbbRefresh,
                                                                                        this.tbbCollGRRD,
                                                                                        this.tbbDetail,
                                                                                        this.tbbFont,
                                                                                        this.tbbExport,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(848, 41);
            this.toolBar1.TabIndex = 2;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbRefresh
            // 
            this.tbbRefresh.ImageIndex = 4;
            this.tbbRefresh.Text = "刷新";
            // 
            // tbbCollGRRD
            // 
            this.tbbCollGRRD.DropDownMenu = this.cmColl;
            this.tbbCollGRRD.ImageIndex = 5;
            this.tbbCollGRRD.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.tbbCollGRRD.Text = "采集";
            // 
            // cmColl
            // 
            this.cmColl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this.miCollGRRD,
                                                                                   this.miCollXG});
            // 
            // miCollGRRD
            // 
            this.miCollGRRD.Index = 0;
            this.miCollGRRD.Text = "供热实时数据";
            this.miCollGRRD.Click += new System.EventHandler(this.miCollGRRD_Click);
            // 
            // miCollXG
            // 
            this.miCollXG.Index = 1;
            this.miCollXG.Text = "巡更数据";
            this.miCollXG.Click += new System.EventHandler(this.miCollXG_Click);
            // 
            // tbbDetail
            // 
            this.tbbDetail.ImageIndex = 6;
            this.tbbDetail.Text = "细节";
            // 
            // tbbFont
            // 
            this.tbbFont.ImageIndex = 7;
            this.tbbFont.Text = "字体";
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 3;
            this.tbbExit.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerReadGRStationRD
            // 
            this.timerReadGRStationRD.Tick += new System.EventHandler(this.timerReadGRStationRD_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grRealDataDetail1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 392);
            this.panel1.TabIndex = 3;
            // 
            // grRealDataDetail1
            // 
            this.grRealDataDetail1.Location = new System.Drawing.Point(8, 0);
            this.grRealDataDetail1.Name = "grRealDataDetail1";
            this.grRealDataDetail1.Size = new System.Drawing.Size(792, 576);
            this.grRealDataDetail1.StationName = "";
            this.grRealDataDetail1.TabIndex = 0;
            // 
            // tbbExport
            // 
            this.tbbExport.ImageIndex = 8;
            this.tbbExport.Text = "导出";
            // 
            // frmAllGRRealDatas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(848, 677);
            this.Controls.Add(this.lvGrStRds);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmAllGRRealDatas";
            this.Text = "供热实时数据";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAllGRRealDatas_Closing);
            this.Load += new System.EventHandler(this.frmAllGRRealDatascs_Load);
            this.Closed += new System.EventHandler(this.frmAllGRRealDatas_Closed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region FormEvents
        private void frmAllGRRealDatascs_Load(object sender, System.EventArgs e)
        {
            //int ms = XGConfig.Default.GrRealDataCollCycle * 60 * 1000;
            int ms = 5 * 60 * 1000;  // 5 minute

            this.timerReadGRStationRD.Interval = ms;
            this.timerReadGRStationRD.Enabled = true;

            RefreshListView();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshListView();
        }

        #region lvGrStRds_SelectedIndexChanged
        private void lvGrStRds_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.lvGrStRds.SelectedItems.Count > 0)
            {
                ListViewItem lvi = lvGrStRds.SelectedItems[0];
//                this.grRealDataDetail1.

                GRRealDataDetail a = grRealDataDetail1;
                a.Clear();
                string stName = //lvi.Text;
                    lvi.SubItems[1].Text;

                a.StationName = stName; 
                GRRealData rd = GetLastestGRRD ( stName );

                string ip, serverIP;

                if ( GetIPAndServerIP ( stName, out ip, out serverIP ) )
                {
                    a.IP = ip;
                    a.ServerIP = serverIP;                
                }

                if ( rd != null )
                {
                    a.DateTime      = rd.DT; 

                    a.WaterLevel    = rd.WatBoxLevel;
                    a.OpenDegree    = rd.OpenDegree ;
                    
                    a.OneGivePress  = rd.OneGivePress;
                    a.OneBackPress  = rd.OneBackPress;
                    a.OneGiveTemp   = rd.OneGiveTemp;
                    a.OneBackTemp   = rd.OneBackTemp;
                    a.OneInst       = rd.OneInstant;
                    a.OneSum        = rd.OneAccum;

                    a.TwoGivePress  = rd.TwoGivePress;
                    a.TwoBackPress  = rd.TwoBackPress;
                    a.TwoGiveTemp   = rd.TwoGiveTemp;
                    a.TwoBackTemp   = rd.TwoBackTemp;
                    a.TwoInst       = rd.TwoInstant;
                    a.TwoSum        = rd.TwoAccum;
                    a.PressSubSet   = rd.TwoPressCha;
                    a.RePressSet    = rd.DrangeSet;
                    a.TwoGiveTempBase = rd.TwoGiveBaseTemp;         
                    a.OutsideTemp   = rd.OutSideTemp;

                    a.RePump1       = GetPumpStateText ( rd.GrPumpState.RecruitPump1 );
                    a.RePump2       = GetPumpStateText ( rd.GrPumpState.RecruitPump2 );
                    a.CyclePump1    = GetPumpStateText ( rd.GrPumpState.CyclePump1 );
                    a.CyclePump2    = GetPumpStateText ( rd.GrPumpState.CyclePump2 );
                    a.CyclePump3    = GetPumpStateText ( rd.GrPumpState.CyclePump3 );
                    a.CheckException();
                }
            }
        }

        #endregion //lvGrStRds_SelectedIndexChanged

        #region GetIPAndServerIP
        private bool GetIPAndServerIP( string stName, out string ip, out string serverIP )
        {
            ip = string.Empty;
            serverIP = string.Empty;

            GRStationsCollection grsts =  Singles.S.GRStsCollection;
            GRStation grst = grsts.GetGRStation( stName );
            if ( grst != null )
            {
                ip = grst.DestinationIP;
                serverIP = grst.ServerIP; 

                return true;        
            }
            return false;
        }
        #endregion //GetIPAndServerIP

        #region GRStRds_Changed
        private void GRStRds_Changed(object sender, EventArgs e)
        {
            GRStationLastRealDatasCollection snd = sender as GRStationLastRealDatasCollection;
            if ( snd != null )
            {
                GRStationLastRealData strd = snd.ChangedSTRD;
                if ( strd != null )
                {
                    ListViewItem lvi = FindLvi( strd.GRStation.StationName );
                    if ( lvi != null )
                    {
                        if ( strd.GRRealData != null )
                        {
                            string [] ss = GetSubItemTexts( strd.GRStation.StationName, strd.GRRealData );
                            string text = lvi.Text;
                            Color  clr = lvi.BackColor;

                            lvi.SubItems.Clear();
                            lvi.Text = text;
                            lvi.BackColor = clr;
                            lvi.SubItems.AddRange( ss );
                        }
                    }
                }
            }
//            RefreshListView ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ListViewItem FindLvi( string name )
        {
            foreach( ListViewItem lvi in lvGrStRds.Items )
            {
                if (lvi.SubItems[1].Text.Trim() == name.Trim() )
                    return lvi;
            }
            return null;
        }
        #endregion //GRStRds_Changed

        #region frmAllGRRealDatas_Closed
        private void frmAllGRRealDatas_Closed(object sender, System.EventArgs e)
        {
            Singles.S.GRStRds.Changed -= new EventHandler(GRStRds_Changed);
        }
        #endregion //frmAllGRRealDatas_Closed

        #region frmAllGRRealDatas_Closing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAllGRRealDatas_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            // 2007-10-16
            //
            if ( MdiParent != null )
                MdiParent = null;
            this.Hide();
        }
        #endregion //frmAllGRRealDatas_Closing

        #region toolBar1_ButtonClick
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == this.tbbRefresh )
            {
                this.ReadGRStationRDFormDB();
                //this.RefreshListView();
            }
            else if ( e.Button == this.tbbExit )
                Close();
            else if ( e.Button == this.tbbCollGRRD )
                CollGRRealData();
            else if ( e.Button == this.tbbDetail )
            {
                SwitchDetail();
            }
            else if ( e.Button == this.tbbFont )
            {
                ChangeFont ();    
            }
            else if( e.Button == this.tbbExport )
            {
                this.ExportXls();
            }
        }
        #endregion //toolBar1_ButtonClick

        #region ChangeFont
        private void ChangeFont()
        {
            FontDialog fd = new FontDialog();
            fd.Font = this.lvGrStRds.Font;
            if ( fd.ShowDialog(this) == DialogResult.OK )
            {
                this.lvGrStRds.Font = fd.Font;
            }
        }
        #endregion //ChangeFont

        #region SwitchDetail
        /// <summary>
        /// 
        /// </summary>
        private void SwitchDetail ()
        {
            this.tbbDetail.Pushed = ! tbbDetail.Pushed;
            this.panel1.Visible = tbbDetail.Pushed;
        }
        #endregion //SwitchDetail



        #region lvGrStRds_ColumnClick
        /// <summary>
        /// Column click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvGrStRds_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            // column base - 0
            //
            int col = e.Column;

            if ( col == _lastSortColumn )
                _isAsc = !_isAsc ;
            else
                _isAsc = true;

            this.lvGrStRds.ListViewItemSorter = new ListViewItemComparer ( col, _isAsc, GetColumnType( col ) );
            this.lvGrStRds.Sort();

            _lastSortColumn = col;
        }
        #endregion //lvGrStRds_ColumnClick
        #endregion //FormEvents

        #region GetColumnType
        /// <summary>
        /// 
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private TypeCode GetColumnType( int col )
        {
            // 0                - team( cn string )
            // 0 + 1            - station name
            // 1 + 1            - datetime
            // 2 + 1  ~ 19 + 1  - double or int
            // 20 + 1 ~ 24 + 1  - pump state
            //
            if ( col == 0 )
                return TypeCode.Char; 
            else if ( col == 2 )
                    //return typeof( DateTime );
                return TypeCode.DateTime;
            else if ( col > 2 && col < 21  )
//                    return typeof( double );
                return TypeCode.Double;
            else
//                return typeof( string );
                return TypeCode.String;
        }
        
        #endregion //GetColumnType

        #region GetLastestGRRD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stName"></param>
        /// <returns></returns>
        private GRRealData GetLastestGRRD( string stName )
        {
            GRStationLastRealDatasCollection grStRds = Singles.S.GRStRds;
            if ( grStRds != null )
            {
                foreach ( GRStationLastRealData l in grStRds )
                {
                    if ( l.GRStation.StationName == stName )
                    {
                        return l.GRRealData;
                    }
                }
            }
            return null;
        }
        #endregion //GetLastestGRRD

        #region RefreshListView
        /// <summary>
        /// 
        /// </summary>
        private void RefreshListView()
        {
            this.lvGrStRds.Items.Clear();
            IComparer comparer = this.lvGrStRds.ListViewItemSorter;
            this.lvGrStRds.ListViewItemSorter = null;
            

            GRStationLastRealDatasCollection grstRds = Singles.S.GRStRds;
            if ( grstRds == null )
                return;
            
            
            // TODO: ?? Add remoteIP and serverIP
            //
            foreach( GRStationLastRealData grStRd in grstRds )
            {
                // TODO: 2007-10-23 added team column
                //
                string team = grStRd.GRStation.Team ;
                if ( team == null )
                    team = string.Empty;

//                ListViewItem lvi = lvGrStRds.Items.Add( grStRd.GRStation.StationName );
                ListViewItem lvi = lvGrStRds.Items.Add( team );
                if ( grStRd.GRStation.ServerIP == XGConfig.Default.ServerIP )
                {
                    lvi.BackColor = Color.FromArgb( 208, 255, 208 );
                }
                GRRealData rd = grStRd.GRRealData;
                if ( rd != null )
                {
                    string [] subItemTexts  = GetSubItemTexts( grStRd.GRStation.StationName, grStRd.GRRealData );
                    lvi.SubItems.AddRange( subItemTexts );
                }
                else
                {
                    string[] subItemTexts = new string[] {grStRd.GRStation.StationName };
                    lvi.SubItems.AddRange( subItemTexts );
                }
            }

            this.lvGrStRds.ListViewItemSorter = comparer;

        }
        #endregion //RefreshListView

        #region GetSubItemTexts
        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private string [] GetSubItemTexts( string stName, GRRealData r )
        {
            //            r.DT.ToString();
            ArrayList s = new ArrayList();
            s.Add ( stName );
            s.Add ( r.DT.ToString() );                  //时间

            s.Add ( r.OneGivePress.ToString() );        //一次供水压力
            s.Add ( r.OneBackPress.ToString() );        //一次回水压力
            s.Add ( r.OneGiveTemp.ToString() );         //一次供水温度
            s.Add ( r.OneBackTemp.ToString() );         //一次回水温度
            s.Add ( r.OneInstant.ToString() );          //一次瞬时流量
            s.Add ( r.OneAccum.ToString() );            //一次累计流量

            s.Add ( r.TwoGivePress.ToString() );        //二次供水压力
            s.Add ( r.TwoBackPress.ToString() );        //二次回水压力
            s.Add ( r.TwoGiveTemp.ToString() );         //二次供水温度
            s.Add ( r.TwoBackTemp.ToString() );         //二次回水温度
            s.Add ( r.TwoInstant.ToString() );          //二次瞬时流量
            s.Add ( r.TwoAccum.ToString() );            //二次累计流量
            s.Add ( r.TwoGiveBaseTemp.ToString() );     //二次供温基准


            s.Add ( r.OpenDegree.ToString() );          //调节阀开度
            s.Add ( r.WatBoxLevel.ToString() );         //水箱水位
            s.Add ( r.DrangeSet.ToString() );           //补水压力设定
            s.Add ( r.DrangeSubSet.ToString() );        //压差设定
            s.Add ( r.OutSideTemp.ToString() );         //室外温度

            GRPumpState ps = r.GrPumpState;
            s.Add ( GetPumpStateText( ps.CyclePump1 ) ); //循环泵
            s.Add ( GetPumpStateText( ps.CyclePump2 ) ); //
            s.Add ( GetPumpStateText( ps.CyclePump3 ) ); //
            s.Add ( GetPumpStateText( ps.RecruitPump1 ) ); //补水泵
            s.Add ( GetPumpStateText( ps.RecruitPump2 ) ); //

            string [] rs = (string [])s.ToArray( typeof(string) );
            return rs;
        }
        #endregion //GetSubItemTexts

        #region GetPumpStateText
        private string GetPumpStateText( PumpState state )
        {
            if ( state == PumpState.Stop )
                return "停止";
            if ( state == PumpState.Running )
                return "运行";

            throw new ArgumentException( state.ToString() );
        }
        #endregion //GetPumpStateText
        
        #region GetSelectStationName
        private string GetSelectStationName ()
        {
            if ( this.lvGrStRds.SelectedItems.Count > 0 )
                return this.lvGrStRds.SelectedItems[0].SubItems[1].Text;
            else
                return null;
        }
        #endregion //GetSelectStationName

        #region IsConnected
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
        #endregion //IsConnected

        #region CollXGData
        private void CollXGData()
        {
            string stName = GetSelectStationName ();
            if ( stName == null || stName.Length == 0 )
            {
                return;
            }

            XGStation xgst = Singles.S.XGStsCollection.GetXGStation( stName );
            if ( xgst.ServerIP != XGConfig.Default.ServerIP )
            {
                MsgBox.Show( string.Format( "站点 {0} 不连接到本台服务器，不能执行操作", xgst.StationName ) );
                return ;
            }

            if ( xgst != null )
            {
                string ip = xgst.DestinationIP;
                if ( IsConnected ( ip ) )
                {
                    ReadTotalCountCommand cmd = new ReadTotalCountCommand( xgst );
                    Task t = new Task( cmd, new ImmediateTaskStrategy() );
                    Singles.S.TaskScheduler.Tasks.Add( t );
                }
                else
                {
                    MsgBox.Show( string.Format("站点 {0} 尚未与中心建立连接", xgst.StationName ) );
                }
                
            }
        }
        #endregion //CollXGData

        #region CollGRRealData
        /// <summary>
        /// 立即采集供热控制器实时数据
        /// </summary>
        private void CollGRRealData()
        {
            string stName = GetSelectStationName();
            if ( stName == null || stName.Length == 0 )
                return ;
            GRStation grSt = Singles.S.GRStsCollection.GetGRStation( stName );
            if ( grSt != null )
            {
                string remoteIP = grSt.DestinationIP ;
                string serverIP = grSt.ServerIP;
                if ( serverIP == XGConfig.Default.ServerIP )
                {
                    if ( IsConnected( remoteIP ) )
                    {
                        GRRealDataCommand cmd = new GRRealDataCommand( grSt );
                        Task t = new Task( cmd, new ImmediateTaskStrategy () );
                        Singles.S.TaskScheduler.Tasks.Add( t );
                        frmControlProcess f = new frmControlProcess( t );
                        f.ShowDialog();
                    }
                    else
                    {
                        MsgBox.Show( string.Format("站点 {0} 尚未与中心建立连接", grSt.StationName ) );
                    }
                }
                else
                {
                    MsgBox.Show( string.Format( "站点 {0} 不连接到本台服务器，不能执行操作", grSt.StationName ) );
                }
            }

        }
        #endregion //CollGRRealData

        #region timerReadGRStationRD_Tick
        private void timerReadGRStationRD_Tick(object sender, System.EventArgs e)
        {
            ReadGRStationRDFormDB();
        }
        #endregion //timerReadGRStationRD_Tick

        #region ReadGRStationRDFormDB
        private void ReadGRStationRDFormDB()
        {
            // 2007.03.31 Modify 刷新所有数据
            //
            //只取非本机采集的实时数据
            //
            //string sql = string.Format( "select * from v_grstlastrd where serverIP <> '{0}'",
            //  XGConfig.Default.ServerIP );
            string sql = string.Format( "select * from v_grstlastrd" );


            DataSet ds = XGDB.DbClient.Execute( sql );
            System.Data.DataTable tbl = ds.Tables[0];
            foreach ( DataRow row in tbl.Rows )
            {
                ProcessGrrdRow( row );
            }
        }
        #endregion //ReadGRStationRDFormDB

        #region ProcessGrrdRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        private void ProcessGrrdRow ( DataRow row )
        {
            string remoteIP     = row["ip"].ToString();
            string stName       = row["name"].ToString();
            int addr            = 0;
            GRRealData grRd     //=// ParseGrRealData ( row );
                = GRRealData.Parse( row );
            if ( grRd != null )
            {
                //            string 
                //            Singles.S.GRStRds.Add( new GRStationLastRealData (grSt, grRd ) );
                Singles.S.GRStRds.ChangeWithStName( stName, addr,  grRd );
            }
        }
        #endregion //ProcessGrrdRow

        #region ParseGrRealData
        /// <summary>
        /// 根据一个tbl.grrealdata.DataRow生成一个gr realdata对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private GRRealData ParseGrRealData ( DataRow row )
        {
            if ( row == null )
                return null;

            GRRealData rd = GRRealData.Parse( row );
            return rd;
            //            GRRealData rd = new GRRealDat
        }
        #endregion //ParseGrRealData

        private void miCollGRRD_Click(object sender, System.EventArgs e)
        {
            CollGRRealData();
        }

        private void miCollXG_Click(object sender, System.EventArgs e)
        {
            CollXGData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ExportXls()
        {
            Excel.ApplicationClass  e = OpenExcel();
            if( e == null )
                return ;

            string t = GetT();
            WriteT( e, t );

            string[] h = GetH();
            WriteH( e, h );

            int r = 3;
            for( int i=0; i<lvGrStRds.Items.Count; i++ )
            {
                int c = 1;
                ListViewItem lvi = lvGrStRds.Items[i];
                for( int j=0; j<lvi.SubItems.Count; j++ )
                {
                    e.Cells[r, c++] = lvi.SubItems[j].Text ;
                }
                r++;
            }
            
            e.Visible = true;
            e.DisplayAlerts = false;
        }

        string[] GetH()
        {
            string[] ss = new string[ this.lvGrStRds.Columns.Count ];
            for( int i=0; i<this.lvGrStRds.Columns.Count; i++ )
            {
                ss[i] = this.lvGrStRds.Columns[i].Text;
            }
            return ss;
        }

        void WriteH( Excel.ApplicationClass e, string[] h )
        {
            for( int i=0; i<h.Length; i++ )
            {
                e.Cells[2,i+1] = h[i];
            }
        }

        string GetT()
        {
            return "供热实时数据 " + DateTime.Now.ToString();
        }

        void WriteT( Excel.ApplicationClass e, string t)
        {
            e.Cells[1,1] = t;
        }

        #region OpenExcel
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Excel.ApplicationClass OpenExcel()
        {
            try
            {
                string xlsFileName = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
                    "\\report\\rptRlt.xls";
                Excel.ApplicationClass excelCls = new ApplicationClass();
                Excel.Workbook excelWb = excelCls.Workbooks.Add( xlsFileName );
                return excelCls;
            }
            catch( Exception ex )
            {
                MsgBox.Show(
                    ex.ToString(),
                    "错误",
                    MessageBoxIcon.Error
                    );
                return null;
            }
        }
        #endregion //OpenExcel
       
    }
    #endregion //frmAllGRRealDatas

    #region ListViewItemComparer
    /// <summary>
    /// 
    /// </summary>
    class ListViewItemComparer : IComparer 
    {
        private bool    _isAsc = true;
        private int     _col;
        private TypeCode    _type;// = typeof(string);

        /// <summary>
        /// 
        /// </summary>
        public ListViewItemComparer() 
        {
            _col=0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="asc"></param>
        public ListViewItemComparer(int column,  bool asc) 
        {
            _isAsc = asc;
            _col=column;
            _type = TypeCode.String; //typeof( string );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="column"></param>
        /// <param name="asc"></param>
        /// <param name="type"></param>
        public ListViewItemComparer( int column, bool asc, System.TypeCode type )
        {
            _isAsc = asc;
            _col = column;
            _type = type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        private int GetTeamOrder( string team )
        {
            string[] teamText = new string[] {
                                                 "一",
                                                 "二",
                                                 "三",
                                                 "四",
                                                 "五",
                                                 "六",
                                                 "七",
                                                 "八",
                                                 "九",
                                                 "十"
                                             };

            for( int i=0; i<teamText.Length; i++ )
            {
                if ( team == teamText[i] )
                    return i+1;
            }
            return 99;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y) 
        {
            ListViewItem lviX = (ListViewItem) x;
            ListViewItem lviY = (ListViewItem) y;

            string sX = GetText( lviX, _col );
            string sY = GetText ( lviY, _col ); 
            
            Debug.Assert( sX != null );
            Debug.Assert( sY != null );

            // TypeCode.Char - team cn string
            //
            if ( _type == TypeCode.Char )
            {
                int ix = GetTeamOrder( sX );
                int iy = GetTeamOrder( sY );
                int d = 0;
                if ( _isAsc )
                    d = ix - iy;
                else
                    d = iy - ix;

                return d > 0 ? 1 : ( d < 0 ? -1 : 0);
            }
            else if ( _type == TypeCode.Double )
            {
                double dx = 0, dy = 0;
//                if ( sX == null )
//                {
//                    int iii=0;
//                    iii=1;
//                }

                if ( sX != string.Empty )
                    dx = double.Parse( sX );

                if ( sY != string.Empty )
                    dy = double.Parse( sY );

                double d = 0;
                
                if ( _isAsc )
                    d = dx - dy;
                else
                    d = dy - dx;

                return d > 0 ? 1 : ( d < 0 ? -1 : 0 );
            }
            else if ( _type == TypeCode.DateTime )
            {
                DateTime dtx = DateTime.MinValue, 
                    dty = DateTime.MinValue;

                if ( sX != string.Empty )
                    dtx = DateTime.Parse( sX );
                if ( sY != string.Empty )
                    dty = DateTime.Parse( sY );

                TimeSpan ts;
                if ( _isAsc )
                    ts = dtx - dty;
                else
                    ts = dty - dtx;

                return ts > TimeSpan.Zero ? 1 : ( ts < TimeSpan.Zero ? -1 : 0 );
            }
            else
            {
                if ( _isAsc  )
                    return string.Compare( sX, sY );
                else
                    return string.Compare( sY, sX );
            }
       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvi"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private string GetText ( ListViewItem lvi, int col )
        {
            if ( col < lvi.SubItems.Count )
            {
                return  lvi.SubItems[ col ].Text;
            }
            else
            {
                return string.Empty;
            }
        }
    }
    #endregion //ListViewItemComparer
}
