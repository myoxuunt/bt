

namespace Communication
{

    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    #region frmXGDataManager
	/// <summary>
	/// frmXGDataManager 的摘要说明。
	/// </summary>
	public class frmXGDataManager : System.Windows.Forms.Form
	{
        #region Members
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
        
        private string  _queryWhere = string.Empty;

//        private string TEXT_ALL = "<全部>";

        #endregion //Members

        #region Constructor
		public frmXGDataManager()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXGDataManager));
            this.dataGridXGData = new System.Windows.Forms.DataGrid();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbQuery = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdCardPerson = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStationName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdCardPerson);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbStationName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 192);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmdCardPerson
            // 
            this.cmdCardPerson.Location = new System.Drawing.Point(120, 128);
            this.cmdCardPerson.Name = "cmdCardPerson";
            this.cmdCardPerson.Size = new System.Drawing.Size(136, 20);
            this.cmdCardPerson.TabIndex = 31;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.TabIndex = 29;
            this.label3.Text = "站名：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 125);
            this.label4.Name = "label4";
            this.label4.TabIndex = 28;
            this.label4.Text = "所属班组：";
            // 
            // cmbStationName
            // 
            this.cmbStationName.Location = new System.Drawing.Point(120, 96);
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
            this.dtpEnd.Location = new System.Drawing.Point(120, 61);
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
            this.label1.Location = new System.Drawing.Point(8, 61);
            this.label1.Name = "label1";
            this.label1.TabIndex = 22;
            this.label1.Text = "结束日期：";
            // 
            // frmXGDataManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(912, 693);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridXGData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmXGDataManager";
            this.Text = "巡更数据管理";
            this.Load += new System.EventHandler(this.frmXGDataManager_Load);
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
            this.dtpEnd.Value  = DateTime.Now.Date + new TimeSpan( 0,23,59,59,0 );
        }
        #endregion //SetDefaultTimeRange

        #region frmXGDataManager_Load
        private void frmXGDataManager_Load(object sender, System.EventArgs e)
        {

//            string[] colNames = {"xgdata_id", "station_address", "card_sn", "station_time", "computer_time", "isAuto", "tag"};
//            string[] showNames = {"编号", "站点地址", "卡号", "站点时间", "时间", "自动上报", "备注"};
            string[] colNames = {"xgdata_id", "stationName", "person", /*"sn",*/   "xgtime"};
            string[] showNames = {"编号",     "站名",        "所属班组", /*"卡号",*/ "时间" };
            int [] colWidths = new int[] {50, 100, 100, /*150,*/ 120 };

//            int[] boolIndexs = {5};
            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "table", colNames, showNames, null, colWidths );
            this.dataGridXGData.TableStyles.Add( dgts );

            this.FillStationName ();
            this.FillCardPerson (); 
            SetDefaultTimeRange ();
            this.QueryXgData ();

//            LoadXGDataFromDB();
        }
        #endregion //frmXGDataManager_Load

        #region LoadXGDataFromDB
        private void LoadXGDataFromDB()
        {
//            string s = "select xgdata_id, stationName, person, sn, xgtime from v_xgdata"; 
            string s = "select xgdata_id, stationName, person, sn, xgtime from v_xgdata" + _queryWhere ; 
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
        }
        #endregion //toolBar1_ButtonClick

        #region QueryXgData
        /// <summary>
        /// 
        /// </summary>
        private void QueryXgData()
        {
            DateTime begin = dtpBegin.Value;
            DateTime end   = dtpEnd.Value;
            if ( end <= begin )
            {
                MsgBox.Show ( "起始日期必须小于结束日期" );
                return;
            }

            string stName = cmbStationName.Text;
            string cardPerson = cmdCardPerson.Text;
            
            _queryWhere = string.Format( " where xgtime >= '{0}' and xgtime <= '{1}'",
                begin.ToString(), end.ToString() );

            if ( stName != GT.TEXT_ALL_STATION )
                _queryWhere += string.Format( " and stationName = '{0}'", stName );

            if ( cardPerson != GT.TEXT_ALL )
                _queryWhere += string.Format( " and person = '{0}'", cardPerson );

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

        #region btnOK_Click
        /// <summary>
        /// query ok button be click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            QueryXgData ();
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
        private void FillCardPerson()
        {
            string sql = "select person from tbl_card order by person asc";
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            DataRow row = tbl.NewRow();
            row[0] = GT.TEXT_ALL;
            tbl.Rows.InsertAt( row, 0 );
            this.cmdCardPerson.DataSource = tbl;
            this.cmdCardPerson.DisplayMember = "person";
        }
        #endregion //FillCardPerson
	}
    #endregion //frmXGDataManager
}
