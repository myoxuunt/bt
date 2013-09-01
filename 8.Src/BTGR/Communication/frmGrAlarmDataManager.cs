

namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;

    #region frmGrAlarmDataManager
	/// <summary>
	/// frmGrAlarmDataManager 的摘要说明。
	/// </summary>
	public class frmGrAlarmDataManager : System.Windows.Forms.Form
	{
        #region Members
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGrid dataGridGrAlarmData;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbDelete;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.Windows.Forms.ToolBarButton tbbQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components;

        private string _queryWhere = string.Empty;
        #endregion //Members

        #region Constructor
		public frmGrAlarmDataManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            this.btnDelete.Visible = false;
		}
        #endregion //Constructor

        #region SetDefaultTimeRange
        private void SetDefaultTimeRange()
        {
            this.dtpBegin.Value  = DateTime.Now.Date - new TimeSpan(1,0,0,0,0);
            this.dtpEnd.Value  = DateTime.Now.Date + new TimeSpan( 0,23,59,59,0 );
        }
        #endregion //SetDefaultTimeRange

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGrAlarmDataManager));
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridGrAlarmData = new System.Windows.Forms.DataGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbQuery = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStationName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrAlarmData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(808, 568);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridGrAlarmData
            // 
            this.dataGridGrAlarmData.DataMember = "";
            this.dataGridGrAlarmData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGrAlarmData.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridGrAlarmData.Location = new System.Drawing.Point(280, 41);
            this.dataGridGrAlarmData.Name = "dataGridGrAlarmData";
            this.dataGridGrAlarmData.Size = new System.Drawing.Size(608, 556);
            this.dataGridGrAlarmData.TabIndex = 12;
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
                                                                                        this.tbbQuery,
                                                                                        this.tbbDelete,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(888, 41);
            this.toolBar1.TabIndex = 14;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbQuery
            // 
            this.tbbQuery.ImageIndex = 5;
            this.tbbQuery.Pushed = true;
            this.tbbQuery.Text = "查询";
            // 
            // tbbDelete
            // 
            this.tbbDelete.ImageIndex = 2;
            this.tbbDelete.Text = "删除";
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 3;
            this.tbbExit.Text = "退出";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 556);
            this.panel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbStationName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 160);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 128);
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
            // frmGrAlarmDataManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(888, 597);
            this.Controls.Add(this.dataGridGrAlarmData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmGrAlarmDataManager";
            this.Text = "报警数据管理";
            this.Load += new System.EventHandler(this.frmGrAlarmDataManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGrAlarmData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        #region GetSelectedId
        private int GetSelectedId ()
        {
            int row = dataGridGrAlarmData.CurrentRowIndex;
            int col=0;

            if ( row == -1 )
            {
                return -1;
            }
            else
            {
                object obj = dataGridGrAlarmData[ row, col ];
                return Convert.ToInt32( obj );
            }
        }
        #endregion //GetSelectedId

        #region setTableStyle
        private void setTableStyle()
        {
            string [] colName = new string[] {"id","name","time","oneGiveTempLow","twoGiveTempHigh","oneGivePressLow",
                                            "twoGivePressHigh","twoBackPressHigh","twoBackPressLow","watLevelLow","watLevelHigh",
                                            "pumpAlarm1","pumpAlarm2","pumpAlarm3","addPumpAlarm1","addPumpAlarm2",
                                                 "NoPower" };
            string [] colText = new string[] { "编号","站名","时间","一次供温低","二次供温高","一次供压低",
                                              "二次供压高","二次回压高","二次回压低", "水箱水位低","水箱水位高",
                                              "循环泵1故障","循环泵2故障","循环泵3故障","补水泵1故障","补水泵2故障",
                                              "掉电"};
            int [] boolColIndexs = {3,4,5,6,7,8,9,10,11,12,13,14,15,16};
            int [] colWidths = new int[] {50,100, 100, 75, 75, 75,
                                        75,75,75,75,75,
                                        75,75,75,75,75,
                                        75};
            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle( "table", colName, colText, boolColIndexs, colWidths );
            this.dataGridGrAlarmData.TableStyles.Add( dgts );
        }
        #endregion //setTableStyle

        #region LoadGrAlarmFromDB
        private void LoadGrAlarmFromDB()
        {
            string sql = "select * from v_gralarmdata " + this._queryWhere ;
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];

            this.dataGridGrAlarmData.DataSource = tbl;
        }
        #endregion //LoadGrAlarmFromDB

        #region btnDelete_Click
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            //TODO: delete gr alarm data
            //
            int id = GetSelectedId();
            if ( id == -1 )
                return ;
            DialogResult dr = MsgBox.ShowQuestion( GT.TIP_DELELE_DATAGRID_ROW );
            if ( dr == DialogResult.Yes )
            {
//                XGDB.DeleteGrAlarmData( id );
                DataTable tbl = (DataTable)this.dataGridGrAlarmData.DataSource;
                DataRow[] rs = tbl.Select( "id=" + id );
                foreach ( DataRow r in rs )
                {
                    tbl.Rows.Remove( r );
                }
//                LoadCardFromDB();
//                XGDB.Resolve();
            }
        }
        #endregion //btnDelete_Click

        #region frmGrAlarmDataManager_Load
        private void frmGrAlarmDataManager_Load(object sender, System.EventArgs e)
        {
            this.dataGridGrAlarmData.ReadOnly = true;            
            this.FillStationName();

            this.SetDefaultTimeRange();
            this.setTableStyle ();

//            this.LoadGrAlarmFromDB();
            this.QueryGRAlarmData();
        }
        #endregion //frmGrAlarmDataManager_Load

        #region toolBar1_ButtonClick
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if ( e.Button == tbbDelete )
                this.btnDelete_Click( this, EventArgs.Empty );
            else if ( e.Button == tbbExit )
                Close();
            else if ( e.Button == tbbQuery )
                this.SwitchQueryPane();
        }
        #endregion //toolBar1_ButtonClick

        #region FillStationName
        /// <summary>
        /// 
        /// </summary>
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

        #region btnOK_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            QueryGRAlarmData();
        }
        #endregion //btnOK_Click

        #region QueryGRAlarmData
        /// <summary>
        /// 
        /// </summary>
        private void QueryGRAlarmData()
        {
            DateTime begin = dtpBegin.Value;
            DateTime end   = dtpEnd.Value;
            if ( end <= begin )
            {
                MsgBox.Show ( "开始时间必须小于结束时间" );
                return;
            }

            string stName = cmbStationName.Text;
//            string cardPerson = cmdCardPerson.Text;
            
            _queryWhere = string.Format( " where time >= '{0}' and time <= '{1}'",
                begin.ToString(), end.ToString() );

            if ( stName != GT.TEXT_ALL_STATION  )
                _queryWhere += string.Format( " and name = '{0}'", stName );

//            if ( cardPerson != GT.TEXT_ALL_STATION )
//                _queryWhere += string.Format( " and person = '{0}'", cardPerson );

//            LoadXGDataFromDB ();
            this.LoadGrAlarmFromDB();

        }
        #endregion //QueryGRAlarmData

        #region SwitchQueryPane
        private void SwitchQueryPane()
        {
            this.tbbQuery.Pushed = !tbbQuery.Pushed; 
            bool queryPushed = this.tbbQuery.Pushed;
            this.panel1.Visible = queryPushed;
//            this.splitter1.Visible = queryPushed;
        }
        #endregion //SwitchQueryPane

	}
    #endregion //frmGrAlarmDataManager
}
