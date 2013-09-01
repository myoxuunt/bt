namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    #region frmXGDataQuery
	/// <summary>
	/// frmXGDataQuery 的摘要说明。
	/// </summary>
	public class frmXGDataQuery : System.Windows.Forms.Form
	{
        #region DataGridType
        /// <summary>
        /// 
        /// </summary>
        private enum DataGridType
        {
            /// <summary>
            /// 
            /// </summary>
            None,
            /// <summary>
            /// 当前DataGrid正显示XgData
            /// </summary>
            XgData,
            /// <summary>
            /// 当前DataGrid正显示XgCount
            /// </summary>
            XgCount,
        }
        #endregion //DataGridType


        #region Members
        private frmXGDataQuery.DataGridType _dataGridType = DataGridType.None;

        private System.Windows.Forms.DataGrid dataGridXGData;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbDelete;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.ToolBarButton tbbQuery;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmdCardPerson;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox txtMinCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkUseXgCount;
        private System.Windows.Forms.DateTimePicker dtpBeginTime;
        public System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cmbTeam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolBarButton tblExport;
        private string  _queryWhere = string.Empty;

//        private string TEXT_ALL = "<全部>";

        #endregion //Members

        #region Constructor
		public frmXGDataQuery()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            this.dataGridXGData.Dock = DockStyle.Fill;

            // 2007.03.12 Disable splitter
            //
            this.splitter1.Enabled = false;
            this.txtMinCount.Enabled = false;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXGDataQuery));
            this.dataGridXGData = new System.Windows.Forms.DataGrid();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbQuery = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.chkUseXgCount = new System.Windows.Forms.CheckBox();
            this.cmdCardPerson = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStationName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMinCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tblExport = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridXGData
            // 
            this.dataGridXGData.DataMember = "";
            this.dataGridXGData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridXGData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridXGData.Location = new System.Drawing.Point(280, 41);
            this.dataGridXGData.Name = "dataGridXGData";
            this.dataGridXGData.ReadOnly = true;
            this.dataGridXGData.Size = new System.Drawing.Size(632, 652);
            this.dataGridXGData.TabIndex = 8;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbbQuery,
                                                                                        this.tblExport,
                                                                                        this.tbbDelete,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(912, 41);
            this.toolBar1.TabIndex = 9;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbQuery
            // 
            this.tbbQuery.ImageIndex = 2;
            this.tbbQuery.Pushed = true;
            this.tbbQuery.Text = "查询";
            // 
            // tbbDelete
            // 
            this.tbbDelete.ImageIndex = 6;
            this.tbbDelete.Text = "删除";
            this.tbbDelete.Visible = false;
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 7;
            this.tbbExit.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(280, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 652);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 652);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTeam);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpEndTime);
            this.groupBox1.Controls.Add(this.dtpBeginTime);
            this.groupBox1.Controls.Add(this.chkUseXgCount);
            this.groupBox1.Controls.Add(this.cmdCardPerson);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbStationName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMinCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 368);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbTeam
            // 
            this.cmbTeam.Location = new System.Drawing.Point(120, 216);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(136, 20);
            this.cmbTeam.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 216);
            this.label6.Name = "label6";
            this.label6.TabIndex = 35;
            this.label6.Text = "班组：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.AllowDrop = true;
            this.dtpEndTime.CustomFormat = "";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(120, 120);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(136, 21);
            this.dtpEndTime.TabIndex = 34;
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBeginTime.Location = new System.Drawing.Point(120, 56);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.ShowUpDown = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(136, 21);
            this.dtpBeginTime.TabIndex = 33;
            // 
            // chkUseXgCount
            // 
            this.chkUseXgCount.Location = new System.Drawing.Point(8, 264);
            this.chkUseXgCount.Name = "chkUseXgCount";
            this.chkUseXgCount.Size = new System.Drawing.Size(224, 24);
            this.chkUseXgCount.TabIndex = 32;
            this.chkUseXgCount.Text = "按巡更次数查询";
            this.chkUseXgCount.CheckedChanged += new System.EventHandler(this.chkUseXgCount_CheckedChanged);
            // 
            // cmdCardPerson
            // 
            this.cmdCardPerson.Location = new System.Drawing.Point(120, 184);
            this.cmdCardPerson.Name = "cmdCardPerson";
            this.cmdCardPerson.Size = new System.Drawing.Size(136, 20);
            this.cmdCardPerson.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 152);
            this.label3.Name = "label3";
            this.label3.TabIndex = 29;
            this.label3.Text = "站名：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 184);
            this.label4.Name = "label4";
            this.label4.TabIndex = 28;
            this.label4.Text = "持卡人：";
            // 
            // cmbStationName
            // 
            this.cmbStationName.Location = new System.Drawing.Point(120, 152);
            this.cmbStationName.Name = "cmbStationName";
            this.cmbStationName.Size = new System.Drawing.Size(136, 20);
            this.cmbStationName.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 29);
            this.label2.Name = "label2";
            this.label2.TabIndex = 26;
            this.label2.Text = "起始日期：";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(120, 88);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(136, 21);
            this.dtpEnd.TabIndex = 25;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(120, 29);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(136, 21);
            this.dtpBegin.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 88);
            this.label1.Name = "label1";
            this.label1.TabIndex = 22;
            this.label1.Text = "结束日期：";
            // 
            // txtMinCount
            // 
            this.txtMinCount.Location = new System.Drawing.Point(120, 296);
            this.txtMinCount.Name = "txtMinCount";
            this.txtMinCount.Size = new System.Drawing.Size(136, 21);
            this.txtMinCount.TabIndex = 17;
            this.txtMinCount.Text = "1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "小于指定次数：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 336);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tblExport
            // 
            this.tblExport.ImageIndex = 8;
            this.tblExport.Text = "导出";
            // 
            // frmXGDataQuery
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(912, 693);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridXGData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmXGDataQuery";
            this.Text = "巡更数据管理";
            this.Load += new System.EventHandler(this.frmXGDataQuery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXGData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        #region SetDefaultTimeRange
        private void SetDefaultTimeRange()
        {
            this.dtpBegin.Value  = DateTime.Now.Date - new TimeSpan(1,0,0,0,0);
            this.dtpBeginTime.Value = dtpBegin.Value;

            this.dtpEnd.Value  = DateTime.Now.Date + new TimeSpan( 0,23,59,59,0 );
            this.dtpEndTime.Value = dtpEnd.Value; 

        }
        #endregion //SetDefaultTimeRange

        private const string XG_COUNT_TABLE = "xgcounttable";

        #region frmXGDataQuery_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXGDataQuery_Load(object sender, System.EventArgs e)
        {

//            string[] colNames = {"xgdata_id", "station_address", "card_sn", "station_time", "computer_time", "isAuto", "tag"};
//            string[] showNames = {"编号", "站点地址", "卡号", "站点时间", "时间", "自动上报", "备注"};

            // 2007-10-30 Added "team", "班组", 50
            //
            string[] colNames = {"xgdata_id", "team",   "stationName", "person", /*"sn",*/   "xgtime"};
            string[] showNames = {"编号",     "班组",   "站名",        "持卡人", /*"卡号",*/ "时间" };
            int [] colWidths = new int[] {50, 50, 100, 100, /*150,*/ 120 };

//            int[] boolIndexs = {5};
            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "table", colNames, showNames, null, colWidths );
            this.dataGridXGData.TableStyles.Add( dgts );


            string[] colNames2 = {"team", "name","ci"};
            string[] showNames2 = {"班组", "站名","巡更次数"};
            int [] colWidths2 = {50, 100, 100 };
            DataGridTableStyle dgts2 = Misc.CreateDataGridTableStyle ( XG_COUNT_TABLE, colNames2, showNames2, null , colWidths2 );
            this.dataGridXGData.TableStyles.Add( dgts2 );

            this.FillStationName ();
            this.FillCardPerson (); 
            // 2007-10-30 Added
            //
            this.FillTeam();
            SetDefaultTimeRange ();
            this.QueryXgData ();

//            LoadXGDataFromDB();
        }
        #endregion //frmXGDataQuery_Load

        #region LoadXGDataFromDB
        /// <summary>
        /// 
        /// </summary>
        private void LoadXGDataFromDB()
        {
//            string s = "select xgdata_id, stationName, person, sn, xgtime from v_xgdata"; 

            // 2007-10-30 Added team column
            //
            //string s = "select xgdata_id, stationName, person, sn, xgtime from v_xgdata" + _queryWhere ; 
            string s = "select xgdata_id, team, stationName, person, sn, xgtime from v_xgdata" +
                _queryWhere ; 

//            MsgBox.Show( s );
            DataSet ds = XGDB.DbClient.Execute( s );
            dataGridXGData.DataSource = ds.Tables[0];
        }
        #endregion //LoadXGDataFromDB

        #region toolBar1_ButtonClick
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == tbbDelete )
                DeleteSelectRow();
            else if ( e.Button == tbbExit )
                Close ();
            else if ( e.Button == tbbQuery )
//                QueryXgData();
                SwitchQueryPane();
            else if ( e.Button == tblExport )
                ExportToExcel();
        }
        #endregion //toolBar1_ButtonClick

        #region IsShowingXgData
        /// <summary>
        /// 当前DataGrid中显示的数据是否为XgData
        /// </summary>
        /// <returns></returns>
        private bool IsShowingXgData()
        {
            //return true;
            return _dataGridType == DataGridType.XgData;
        }
        #endregion //IsShowingXgData
       
        #region  IsShowingXgCount
        /// <summary>
        /// 当前DataGrid中显示的数据是否为XgCount
        /// </summary>
        /// <returns></returns>
        private bool IsShowingXgCount()
        {
            return _dataGridType == DataGridType.XgCount;
        }
        #endregion //IsshowingXgCount
        
        #region ExportToExcel
        /// <summary>
        /// 
        /// </summary>
        private void ExportToExcel()
        {
            if( IsShowingXgData() )
            {
                XgDataExport xde = new XgDataExport( 
                    this.dtpBegin.Value,
                    this.dtpEnd.Value,
                    this.dataGridXGData.DataSource as DataTable 
                    );
                xde.Export();
            }
            else if( IsShowingXgCount() )
            {
                XgCountExport xce = new XgCountExport(
                    this.dtpBegin.Value,
                    this.dtpEnd.Value,
                    this.dataGridXGData.DataSource as DataTable
                    );
                xce.Export();
            }
            else
            {
                MsgBox.Show( "没有可导出数据!" );
            }
        }
        #endregion //ExportToExcel

        #region QueryXgData
        /// <summary>
        /// 
        /// </summary>
        private void QueryXgData()
        {
            DateTime begin = GetBeginDateTime(); //dtpBegin.Value;
            DateTime end   = GetEndDateTime(); //dtpEnd.Value;
            if ( end <= begin )
            {
                MsgBox.Show ( "起始日期必须小于结束日期" );
                return;
            }

            string stName = cmbStationName.Text;
            string cardPerson = cmdCardPerson.Text;
            // 2007-10-30 Added team
            //
            string team = cmbTeam.Text;
            
            _queryWhere = string.Format( " where xgtime >= '{0}' and xgtime <= '{1}'",
                begin.ToString(), end.ToString() );

            if ( stName != GT.TEXT_ALL_STATION )
                _queryWhere += string.Format( " and stationName = '{0}'", stName );

            if ( cardPerson != GT.TEXT_ALL )
                _queryWhere += string.Format( " and person = '{0}'", cardPerson );

            if ( team != GT.TEXT_ALL )
                _queryWhere += string.Format( " and team = '{0}'", team );

            LoadXGDataFromDB ();
        }
        #endregion //QueryXgData

        #region SwitchQueryPane
        private void SwitchQueryPane()
        {
            this.tbbQuery.Pushed = !tbbQuery.Pushed; 
            bool queryPushed = this.tbbQuery.Pushed;
            this.panel1.Visible = queryPushed;
            this.splitter1.Visible = queryPushed;
        }
        #endregion //SwitchQueryPane

        #region DeleteSelectRow
        /// <summary>
        /// 
        /// </summary>
        private void DeleteSelectRow()
        {
            //TODO: delete xgdata row
            //
            int row = dataGridXGData.CurrentRowIndex;
            if ( row == -1 )
                return;

            DialogResult dr = MsgBox.ShowQuestion( GT.TIP_DELELE_DATAGRID_ROW );
            if ( dr == DialogResult.Yes )
            {
                int id = int.Parse( this.dataGridXGData [ row, 0 ].ToString() );
//                XGDB.DeleteXGTask( id );
                XGDB.DeleteXGData( id );
                DataTable tbl = (DataTable)this.dataGridXGData.DataSource ;
                DataRow [] delRows = tbl.Select( "xgdata_id = " + id );
                foreach ( DataRow r in delRows )
                {
                    tbl.Rows.Remove( r );
                }
                
//                XGDB.Resolve();
            }

        }
        #endregion //DeleteSelectRow

        #region IsUseXgCount
        private bool IsUseXgCount
        {
            get { return this.chkUseXgCount.Checked;  }
        }
        #endregion //IsUseXgCount

        #region btnOK_Click
        /// <summary>
        /// query ok button be click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if ( IsUseXgCount )
            {
                btnQuery_Click( this, EventArgs.Empty );
                _dataGridType = DataGridType.XgCount;
            }
            else
            {
                QueryXgData ();
                _dataGridType = DataGridType.XgData;
            }
        }
        #endregion //btnOK_Click

        #region FillStationName
        private void FillStationName()
        {
            string sql = "select name from tbl_gprs_station order by name asc";
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];

            DataRow row = tbl.NewRow();
            row[0] = GT.TEXT_ALL_STATION;
            tbl.Rows.InsertAt( row , 0 );
            this.cmbStationName.DataSource = tbl;
            this.cmbStationName.DisplayMember = "name";
        }
        #endregion //FillStationName

        #region FillCardPerson
        /// <summary>
        /// 
        /// </summary>
        private void FillCardPerson()
        {
            string sql = "select distinct person from tbl_card order by person asc";
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            DataRow row = tbl.NewRow();
            row[0] = GT.TEXT_ALL;
            tbl.Rows.InsertAt( row, 0 );
            this.cmdCardPerson.DataSource = tbl;
            this.cmdCardPerson.DisplayMember = "person";
        }
        #endregion //FillCardPerson

        #region FillTeam
        /// <summary>
        /// 
        /// </summary>
        private void FillTeam()
        {
            string sql = "select distinct team from tbl_card";
            DataSet ds  = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            DataRow r = tbl.NewRow();
            r[0] = GT.TEXT_ALL;
            tbl.Rows.InsertAt( r, 0 );
            this.cmbTeam.DataSource = tbl;
            this.cmbTeam.DisplayMember = "team";
        }
        #endregion //FillTeam

        #region GetMinCount
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetMinCount()
        {
            return int.Parse( this.txtMinCount.Text );
        }

        #endregion //GetMinCount

        #region GetStationTbl
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable GetStationTbl()
        {
            // 2007-10-30 Added team column
            //
            string sql = "select team, name from tbl_gprs_station";
            if ( cmbTeam.Text != GT.TEXT_ALL )
            {
                sql += string.Format(" where team = '{0}'", cmbTeam.Text );
            }

            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            tbl.TableName = XG_COUNT_TABLE;

            DataColumn col = new DataColumn( "ci", typeof(int) );
            col.DefaultValue = 0;
            tbl.Columns.Add( col );
            return tbl ;
        }

        #endregion //GetStationTbl

        #region GetBeginDateTime
        private DateTime GetBeginDateTime()
        {
            return this.dtpBegin.Value.Date + this.dtpBeginTime.Value.TimeOfDay;
        }

        #endregion //GetBeginDateTime

        #region GetEndDateTime
        private DateTime GetEndDateTime()
        {
            return this.dtpEnd.Value.Date + this.dtpEndTime.Value.TimeOfDay;;
        }
        
        #endregion //GetEndDateTime

        #region btnQuery_Click
        /// <summary>
        /// 按照巡更次数查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, System.EventArgs e)
        {
            int minCount;
            try
            {
                 minCount = GetMinCount();
            }
            catch 
            {
                MsgBox.Show("巡更次数输入错误");
                return ;
            }

            DataTable stTbl = GetStationTbl();

            string sql = string.Format( 
                @"select stationname, count (*) as ci from v_xgdata 
                {0} 
                group by stationname",
                GetQueryXgCountCondition()
                );
            
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
             
            foreach ( DataRow row in tbl.Rows  )
            {
                int stXgCount = Convert.ToInt32( row["ci"] );
                DataRow stRow = GetStRow( stTbl, row["stationname"].ToString().Trim() );
                if ( stRow != null )
                {
                    if ( stXgCount >= minCount )
                    {
                        //RemoveStationRow( stTbl, row["stationname"].ToString().Trim() );
                        stTbl.Rows.Remove( stRow );
//                        stRow["ci"] = stXgCount; 
                    }
                    else
                    {
                        //row["ci"] = stXgCount ;
                        stRow["ci"] = stXgCount;
                    }
                }
            }
            this.dataGridXGData.DataSource = stTbl; 
        }
        #endregion //btnQuery_Click

        #region GetQueryXgCountCondition
        /// <summary>
        /// 获取查询巡更次数时的查询条件
        /// </summary>
        /// <returns></returns>
        private string GetQueryXgCountCondition()
        {
            DateTime begin = GetBeginDateTime(); //this.dtpBegin.Value.Date + this.dtpBeginTime.Value.TimeOfDay;
            DateTime end  = GetEndDateTime(); //this.dtpEnd.Value.Date + this.dtpEndTime.Value.TimeOfDay;;

            string sql = string.Format(" where xgtime between '{0}' and '{1}' ",
                begin, end );

            /*
            if ( cmbTeam.Text != GT.TEXT_ALL )
            {
                sql += string.Format(" team = '{0}'", this.cmbTeam.Text.Trim() );
            }
            */
            return sql;
        }
        #endregion //GetQueryXgCountCondition

        #region GetStRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="stname"></param>
        /// <returns></returns>
        private DataRow GetStRow ( DataTable tbl, string stname )
        {
            foreach ( DataRow row in tbl.Rows )
            {
                if ( row["name"].ToString().Trim() == stname )
                    return row;
            }
            return null;
        }
        #endregion //GetStRow

        #region RemoveStationRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        private void RemoveStationRow( DataTable tbl, string stname )
        {
            for ( int i = tbl.Rows.Count - 1; i>=0; i--)
            {
                DataRow row = tbl.Rows[i];
                if ( row["name"].ToString().Trim() == stname )
                {
                    tbl.Rows.Remove( row );
                }
            }
            
//            foreach ( DataRow row in tbl )
//            {
//                if ( row["stationname"].ToString().Trim() == stname )
//                {
//                    tbl.Rows.Remove( row );
//                }
//            }
        }
        #endregion //RemoveStationRow

        #region chkUseXgCount_CheckedChanged
        private void chkUseXgCount_CheckedChanged(object sender, System.EventArgs e)
        {
            this.txtMinCount.Enabled = IsUseXgCount;
            this.cmbStationName.Enabled = !IsUseXgCount;
            this.cmdCardPerson.Enabled = !IsUseXgCount;
        }
        #endregion //chkUseXgCount_CheckedChanged

        #region ...
        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        
        }
        #endregion //...
	}
    #endregion //frmXGDataQuery
}
