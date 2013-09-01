using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace btGRMain.Grid
{
    /// <summary>
    /// frmDataPrint 的摘要说明。
    /// </summary>
    public class frmDataPrint : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbnAdd;
        private System.Windows.Forms.ToolBarButton tbnEdit;
        private System.Windows.Forms.ToolBarButton tbnDelete;
        private System.Windows.Forms.ToolBarButton tbnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private DataSet ds=null;
        private DBcon con=null;
        private int PAGECOUNT0=3;
        private int PAGECOUNT1=11;
        private int PAGECOUNT2=19;
        private System.Windows.Forms.ToolBarButton tbnQuery;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolBarButton tbnPrint;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private SqlDataAdapter da=null;
        // 2007.05.31
        //
        //private bool avgSign=false;
        public static bool d_Avg=false;
        public static bool d_Add=false;
        public static bool d_Max=false;
        public static bool d_Min=false;
        public int d_Row=0;
        private DataTable dt=null;
        private DataTable dt1=null;
        private DataGridTitle[] DGtitle=null;
        public string m_dtBegin;
        public string m_dtEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private string m_Title;

        private bool d_bool=false;
        private string[] d_curveInfo=null;
        private DateTime d_dtB;
        private System.Windows.Forms.ToolBarButton tbnSet;
        private System.Windows.Forms.ToolBarButton tbnInput;
        private DateTime d_dtE;
        private System.Windows.Forms.DataGrid m_dataGridAll;
        private System.Windows.Forms.TabControl tCGrid;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGrid m_dataGrid1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGrid m_dataGrid2;
        private string _stationName;


        #region frmDataPrint
		/// <summary>
		/// 
		/// </summary>
        public frmDataPrint()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            _stationName="*";
            InitializeComponent();
            tCGrid.Visible=false;

			SetToolbarButtonVisible();
        }
        #endregion //frmDataPrint


		#region SetToolbarButtonVisible
		/// <summary>
		/// 
		/// </summary>
		void SetToolbarButtonVisible()
		{
            this.toolBar1.Buttons[0].Visible=false;
            this.toolBar1.Buttons[1].Visible=false;
            this.toolBar1.Buttons[3].Visible=false;
            this.toolBar1.Buttons[5].Visible=true;		// export to excel
            this.toolBar1.Buttons[6].Visible=false;
		}
		#endregion //SetToolbarButtonVisible


        #region frmDataPrint
		/// <summary>
		/// 
		/// </summary>
		/// <param name="HeatStation"></param>
        public frmDataPrint(string HeatStation)
        {
            _stationName=HeatStation;
            InitializeComponent();
            tCGrid.Visible=false;
//            this.toolBar1.Buttons[0].Visible=false;
//            this.toolBar1.Buttons[1].Visible=false;
//            this.toolBar1.Buttons[3].Visible=false;
//            this.toolBar1.Buttons[5].Visible=false;
//            this.toolBar1.Buttons[6].Visible=false;
			SetToolbarButtonVisible();
        }
        #endregion //frmDataPrint


        #region frmDataPrint
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dtBegin"></param>
		/// <param name="dtEnd"></param>
		/// <param name="curveInfo"></param>
		/// <param name="PageCount"></param>
		/// <param name="HeatStation"></param>
        public frmDataPrint(DateTime dtBegin,DateTime dtEnd,string[] curveInfo,
			int PageCount,string HeatStation)
        {
            InitializeComponent();
            d_bool=true;
            _stationName=HeatStation;
            d_dtB=dtBegin;
            d_dtE=dtEnd;
            int m_PageCount;
            m_PageCount=PageCount;
            d_curveInfo=curveInfo;
//            this.toolBar1.Buttons[0].Visible=false;
//            this.toolBar1.Buttons[1].Visible=false;
//            this.toolBar1.Buttons[2].Visible=false;
//            this.toolBar1.Buttons[3].Visible=false;

			this.SetToolbarButtonVisible();
            if(_stationName=="*")
                this.toolBar1.Buttons[4].Visible=false;
            else
                this.toolBar1.Buttons[4].Visible=true;

            InitTabControl(m_PageCount);
        }
        #endregion //frmDataPrint


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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataPrint));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbnAdd = new System.Windows.Forms.ToolBarButton();
            this.tbnEdit = new System.Windows.Forms.ToolBarButton();
            this.tbnQuery = new System.Windows.Forms.ToolBarButton();
            this.tbnDelete = new System.Windows.Forms.ToolBarButton();
            this.tbnSet = new System.Windows.Forms.ToolBarButton();
            this.tbnInput = new System.Windows.Forms.ToolBarButton();
            this.tbnPrint = new System.Windows.Forms.ToolBarButton();
            this.tbnExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.m_dataGridAll = new System.Windows.Forms.DataGrid();
            this.tCGrid = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.m_dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.m_dataGrid2 = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridAll)).BeginInit();
            this.tCGrid.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbnAdd,
                                                                                        this.tbnEdit,
                                                                                        this.tbnQuery,
                                                                                        this.tbnDelete,
                                                                                        this.tbnSet,
                                                                                        this.tbnInput,
                                                                                        this.tbnPrint,
                                                                                        this.tbnExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(836, 41);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbnAdd
            // 
            this.tbnAdd.ImageIndex = 0;
            this.tbnAdd.Text = "添加";
            // 
            // tbnEdit
            // 
            this.tbnEdit.ImageIndex = 1;
            this.tbnEdit.Text = "编辑";
            // 
            // tbnQuery
            // 
            this.tbnQuery.ImageIndex = 2;
            this.tbnQuery.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnQuery.Text = "查询";
            // 
            // tbnDelete
            // 
            this.tbnDelete.ImageIndex = 6;
            this.tbnDelete.Text = "删除";
            // 
            // tbnSet
            // 
            this.tbnSet.ImageIndex = 3;
            this.tbnSet.Text = "统计";
            this.tbnSet.Visible = false;
            // 
            // tbnInput
            // 
            this.tbnInput.ImageIndex = 4;
            this.tbnInput.Text = "导出";
            // 
            // tbnPrint
            // 
            this.tbnPrint.ImageIndex = 5;
            this.tbnPrint.Text = "打印";
            // 
            // tbnExit
            // 
            this.tbnExit.ImageIndex = 7;
            this.tbnExit.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 428);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 428);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 192);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(224, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "时";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(224, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "时";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(192, 72);
            this.numericUpDown2.Maximum = new System.Decimal(new int[] {
                                                                           24,
                                                                           0,
                                                                           0,
                                                                           0});
            this.numericUpDown2.Minimum = new System.Decimal(new int[] {
                                                                           1,
                                                                           0,
                                                                           0,
                                                                           0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(32, 21);
            this.numericUpDown2.TabIndex = 15;
            this.numericUpDown2.Value = new System.Decimal(new int[] {
                                                                         8,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(192, 32);
            this.numericUpDown1.Maximum = new System.Decimal(new int[] {
                                                                           24,
                                                                           0,
                                                                           0,
                                                                           0});
            this.numericUpDown1.Minimum = new System.Decimal(new int[] {
                                                                           1,
                                                                           0,
                                                                           0,
                                                                           0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 21);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new System.Decimal(new int[] {
                                                                         8,
                                                                         0,
                                                                         0,
                                                                         0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "站点名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "开始时间：";
            // 
            // cmbStation
            // 
            this.cmbStation.Location = new System.Drawing.Point(80, 112);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(128, 20);
            this.cmbStation.TabIndex = 10;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(80, 72);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(112, 21);
            this.dtEnd.TabIndex = 9;
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(80, 32);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(112, 21);
            this.dtBegin.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(168, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 32);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "查询";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // m_dataGridAll
            // 
            this.m_dataGridAll.DataMember = "";
            this.m_dataGridAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGridAll.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGridAll.Location = new System.Drawing.Point(264, 41);
            this.m_dataGridAll.Name = "m_dataGridAll";
            this.m_dataGridAll.ReadOnly = true;
            this.m_dataGridAll.Size = new System.Drawing.Size(572, 428);
            this.m_dataGridAll.TabIndex = 4;
            // 
            // tCGrid
            // 
            this.tCGrid.Controls.Add(this.tabPage1);
            this.tCGrid.Controls.Add(this.tabPage2);
            this.tCGrid.Controls.Add(this.tabPage3);
            this.tCGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCGrid.Location = new System.Drawing.Point(264, 41);
            this.tCGrid.Name = "tCGrid";
            this.tCGrid.SelectedIndex = 0;
            this.tCGrid.Size = new System.Drawing.Size(572, 428);
            this.tCGrid.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_dataGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(564, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "页1";
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.CaptionFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.m_dataGrid.CausesValidation = false;
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(0, 0);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(564, 403);
            this.m_dataGrid.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_dataGrid1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(512, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "页2";
            this.tabPage2.Visible = false;
            // 
            // m_dataGrid1
            // 
            this.m_dataGrid1.DataMember = "";
            this.m_dataGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.m_dataGrid1.Name = "m_dataGrid1";
            this.m_dataGrid1.ReadOnly = true;
            this.m_dataGrid1.Size = new System.Drawing.Size(512, 363);
            this.m_dataGrid1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_dataGrid2);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(512, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "页3";
            this.tabPage3.Visible = false;
            // 
            // m_dataGrid2
            // 
            this.m_dataGrid2.DataMember = "";
            this.m_dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid2.Location = new System.Drawing.Point(0, 0);
            this.m_dataGrid2.Name = "m_dataGrid2";
            this.m_dataGrid2.ReadOnly = true;
            this.m_dataGrid2.Size = new System.Drawing.Size(512, 363);
            this.m_dataGrid2.TabIndex = 0;
            // 
            // frmDataPrint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(836, 469);
            this.Controls.Add(this.tCGrid);
            this.Controls.Add(this.m_dataGridAll);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmDataPrint";
            this.Text = "frmDataPrint";
            this.Load += new System.EventHandler(this.frmDataPrint_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGridAll)).EndInit();
            this.tCGrid.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion


        #region frmDataPrint_Load
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void frmDataPrint_Load(object sender, System.EventArgs e)
        {
            UnQuery();
            if(d_bool==true)
            {
                this.Text="数据查询与打印";
                if(_stationName=="*")
                    m_Title="全部热力站数据报表";
                else
                    m_Title=_stationName+"热力站数据报表";
                ReadGridDataTitle();
                InitQueryBar();
                InitGridDataTitle();
                if(TestStationName())
                    LoadDatas();
            }
            else
            {
                ReadGridDataTitle();
                InitQueryBar();
                InitGridDataTitle();
                if(TestStationName())
                    LoadDatas();
            }
        }
        #endregion //frmDataPrint_Load

        #region InitializeDatas
        private bool TestStationName()
        {
            if(_stationName=="*")
                return true;
            else
            {
                try
                {
                    con=new DBcon();
                    string str="select * from tbl_grStation where name='"+_stationName+"'";
                    SqlCommand  cmd=new SqlCommand(str,con.GetConnection());
                    SqlDataReader dr=cmd.ExecuteReader();
                    if(!dr.Read())
                        return false;
                    dr.Close();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());//"站点信息不存在!");
                    return false;
                }
            }
        }


        #region InitTabControl
        private void InitTabControl(int index)
        {
            int m_PageCount;
            m_PageCount=index;
            tCGrid.TabPages.Remove(tabPage2);
            tCGrid.TabPages.Remove(tabPage3);
            if(m_PageCount==2)
            {
                tCGrid.TabPages.Add(tabPage2);
            }
            else if(m_PageCount==3)
            {
                tCGrid.TabPages.Add(tabPage2);
                tCGrid.TabPages.Add(tabPage3);
            }			
        }
        #endregion //InitTabControl


        #region InitGridDataTitle
        private void InitGridDataTitle()
        {
            if(d_bool)
            {
                int continueID1=0;
                DataGridTableStyle tbs= new DataGridTableStyle();
                DataGridTableStyle tbs1= new DataGridTableStyle();
                DataGridTableStyle tbs2= new DataGridTableStyle();
                for(int i=1;i<3;i++)
                {
                    DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                    clm.MappingName=DGtitle[i].m_GName;
                    clm.HeaderText=DGtitle[i].m_GTitle;
                    //				clm.Alignment=HorizontalAlignment.Center;
                    tbs.GridColumnStyles.Add(clm);
                    tbs.GridColumnStyles[i-1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                }
                int index=2;
                int continueID=0;
                for(int i=3;i<DGtitle.Length;i++)
                {
                    for(int j=0;j<d_curveInfo.Length;j++)
                    {
                        string s=d_curveInfo[j];
                        if(d_curveInfo[j]!=DGtitle[i].m_GTitle)
                            continue;
                        DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                        clm.MappingName=DGtitle[i].m_GName;
                        clm.HeaderText=DGtitle[i].m_GTitle+"\n("+DGtitle[i].m_GUnit+")";
                        //					clm.Alignment=HorizontalAlignment.Center;
                        tbs.GridColumnStyles.Add(clm);
                        tbs.GridColumnStyles[index].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                        index++;
                    }
                    if(index>9)
                    {
                        continueID=++i;
                        break;
                    }
                }
                if(continueID!=0)
                {
                    for(int i=1;i<3;i++)
                    {
                        DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                        clm.MappingName=DGtitle[i].m_GName;
                        clm.HeaderText=DGtitle[i].m_GTitle;
                        //					clm.Alignment=HorizontalAlignment.Center;
                        tbs1.GridColumnStyles.Add(clm);
                        tbs1.GridColumnStyles[i-1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                    }
                    int index1=2;
                    for(int i=continueID;i<DGtitle.Length;i++)
                    {
                        for(int j=0;j<d_curveInfo.Length;j++)
                        {
                            string s=d_curveInfo[j];
                            if(d_curveInfo[j]!=DGtitle[i].m_GTitle)
                                continue;
                            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                            clm.MappingName=DGtitle[i].m_GName;
                            clm.HeaderText=DGtitle[i].m_GTitle+"\n("+DGtitle[i].m_GUnit+")";
                            //						clm.Alignment=HorizontalAlignment.Center;
                            tbs1.GridColumnStyles.Add(clm);
                            tbs1.GridColumnStyles[index1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                            index1++;
                        }
                        if(index1>9)
                        {
                            continueID1=++i;
                            break;
                        }
                    }
                }
                if(continueID1!=0)
                {
                    for(int i=1;i<3;i++)
                    {
                        DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                        clm.MappingName=DGtitle[i].m_GName;
                        clm.HeaderText=DGtitle[i].m_GTitle;
                        //					clm.Alignment=HorizontalAlignment.Center;
                        tbs2.GridColumnStyles.Add(clm);
                        tbs2.GridColumnStyles[i-1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                    }
                    int index2=2;
                    int continueID2=0;
                    for(int i=continueID1;i<DGtitle.Length;i++)
                    {
                        for(int j=0;j<d_curveInfo.Length;j++)
                        {
                            string s=d_curveInfo[j];
                            if(d_curveInfo[j]!=DGtitle[i].m_GTitle)
                                continue;
                            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                            clm.MappingName=DGtitle[i].m_GName;
                            clm.HeaderText=DGtitle[i].m_GTitle+"\n("+DGtitle[i].m_GUnit+")";
                            //						clm.Alignment=HorizontalAlignment.Center;
                            tbs2.GridColumnStyles.Add(clm);
                            tbs2.GridColumnStyles[index2].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                            index2++;
                        }
                        if(index2>9)
                        {
                            continueID2=++i;
                            break;
                        }
                    }
                }
                tbs.MappingName ="table1";
                tbs1.MappingName ="table2";
                tbs2.MappingName ="table3";
                m_dataGrid.TableStyles.Add(tbs);
                m_dataGrid.HeaderFont=new Font("Arial",15);
                m_dataGrid1.TableStyles.Add(tbs1);
                m_dataGrid1.HeaderFont=new Font("Arial",15);
                m_dataGrid2.TableStyles.Add(tbs2);
                m_dataGrid2.HeaderFont=new Font("Arial",15);
            }
            else
            {
                DataGridTableStyle tbs= new DataGridTableStyle();
                for(int i=1;i<3;i++)
                {
                    DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                    clm.MappingName=DGtitle[i].m_GName;
                    clm.HeaderText=DGtitle[i].m_GTitle;
                    //				clm.Alignment=HorizontalAlignment.Center;
                    tbs.GridColumnStyles.Add(clm);
                    tbs.GridColumnStyles[i-1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                }
                for(int i=3;i<DGtitle.Length;i++)
                {
                    DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                    clm.MappingName=DGtitle[i].m_GName;
                    clm.HeaderText=DGtitle[i].m_GTitle+"\n("+DGtitle[i].m_GUnit+")";
                    //				clm.Alignment=HorizontalAlignment.Center;
                    tbs.GridColumnStyles.Add(clm);
                    tbs.GridColumnStyles[i-1].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                }
                tbs.MappingName ="Table";
                m_dataGridAll.TableStyles.Add(tbs);
                m_dataGridAll.HeaderFont=new Font("Arial",15);
            }
        }
        #endregion //InitGridDataTitle


        #region LoadDatas
        private void LoadDatas()
        {
            m_dtBegin=dtBegin.Value.ToShortDateString()+" "+numericUpDown1.Value.ToString()+":00:00";
            m_dtEnd=dtEnd.Value.ToShortDateString()+" "+numericUpDown2.Value.ToString()+":00:00";
            string strName=null;
            if(_stationName=="*")
                strName="";
            else
                strName=" name='"+_stationName+"'";
            try
            {
                con=new DBcon();
                if(!d_bool)
                {
                    if(strName=="")
                    {
                        string str="select * from V_heatdatas where time between '"+m_dtBegin+"' and '"+m_dtEnd+"' order by time desc";
                        da=new SqlDataAdapter(str,con.GetConnection());
                        ds=new DataSet();
                        da.Fill(ds,"Table");
                        m_dataGridAll.DataSource=ds.Tables["Table"].DefaultView;
                        d_Row=ds.Tables["table"].Rows.Count;
                    }
                    else
                    {
                        string str="select * from V_heatdatas where time between '"+m_dtBegin+"' and '"+m_dtEnd+"' order by time desc";
                        da=new SqlDataAdapter(str,con.GetConnection());
                        ds=new DataSet();
                        da.Fill(ds,"Table");
                        m_dataGridAll.DataSource=ds.Tables["Table"].DefaultView;
                        d_Row=ds.Tables["table"].Rows.Count;
                    }
                }
                else
                {
                    if(DGtitle.Length>PAGECOUNT1)
                    {
                        string str1="select "+DGtitle[1].m_GName.Trim();
                        str1=str1+","+DGtitle[2].m_GName.Trim();
                        for(int i=PAGECOUNT0;i<PAGECOUNT1;i++)
                        {
                            str1=str1+","+DGtitle[i].m_GName.Trim();
                        }
                        str1=str1+" from V_heatdatas where"+strName+"  and time between '";
                        str1=str1+d_dtB+"' and '";
                        str1=str1+d_dtE+"' order by time";
                        da=new SqlDataAdapter(str1,con.GetConnection());
                        ds=new DataSet();
                        da.Fill(ds,"table1");
                        m_dataGrid.DataSource=ds.Tables["table1"].DefaultView;
                        da.Dispose();
                        if(DGtitle.Length>PAGECOUNT2)
                        {
                            string str2="select "+DGtitle[1].m_GName.Trim();
                            str2=str2+","+DGtitle[2].m_GName.Trim();
                            for(int i=PAGECOUNT1;i<PAGECOUNT2;i++)
                            {
                                str2=str2+","+DGtitle[i].m_GName.Trim();
                            }
                            str2=str2+" from V_heatdatas where"+strName+" time between '";
                            str2=str2+d_dtB+"' and '";
                            str2=str2+d_dtE+"' order by time";
                            da=new SqlDataAdapter(str2,con.GetConnection());
                            da.Fill(ds,"table2");
                            m_dataGrid1.DataSource=ds.Tables["table2"].DefaultView;
                            string str3="select "+DGtitle[1].m_GName.Trim();
                            str3=str3+","+DGtitle[2].m_GName.Trim();
                            for(int i=PAGECOUNT2;i<DGtitle.Length;i++)
                            {
                                str3=str3+","+DGtitle[i].m_GName.Trim();
                            }
                            str3=str3+" from V_heatdatas where"+strName+" time between '";
                            str3=str3+d_dtB+"' and '";
                            str3=str3+d_dtE+"' order by time";
                            da=new SqlDataAdapter(str3,con.GetConnection());
                            da.Fill(ds,"table3");
                            m_dataGrid2.DataSource=ds.Tables["table3"].DefaultView;
                        }
                        else
                        {
                            string str2="select "+DGtitle[1].m_GName.Trim();
                            str2=str2+","+DGtitle[2].m_GName.Trim();
                            for(int i=PAGECOUNT1;i<DGtitle.Length;i++)
                            {
                                str2=str2+","+DGtitle[i].m_GName.Trim();
                            }
                            str2=str2+" from V_heatdatas where"+strName+" time between '";
                            str2=str2+d_dtB+"' and '";
                            str2=str2+d_dtE+"' order by time";
                            da=new SqlDataAdapter(str2,con.GetConnection());	
                            da.Fill(ds,"table2");
                            m_dataGrid1.DataSource=ds.Tables["table2"].DefaultView;
                            da.Dispose();
                        }
                    }
                    else
                    {
                        string str1="select "+DGtitle[1].m_GName.Trim();
                        str1=str1+","+DGtitle[2].m_GName.Trim();
                        for(int i=PAGECOUNT0;i<DGtitle.Length;i++)
                        {
                            str1=str1+","+DGtitle[i].m_GName.Trim();
                        }
                        str1=str1+" from V_heatdatas where"+strName+" time between '";
                        str1=str1+d_dtB+"' and '";
                        str1=str1+d_dtE+"' order by time";
                        da=new SqlDataAdapter(str1,con.GetConnection());
                        ds=new DataSet();
                        da.Fill(ds,"table1");
                        DataTable dt=ds.Tables["table1"];
                        m_dataGrid.DataSource=dt;
                    }
                    d_Row=ds.Tables["table1"].Rows.Count;
                }
				
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion //LoadDatas


        #region RefreshData
        private void RefreshData()
        {
            try
            {
                //				ReadGridDataTitle();
                con=new DBcon();
                da=new SqlDataAdapter(strQuery(),con.GetConnection());
                ds=new DataSet();
                da.Fill(ds,"table");
                m_dataGridAll.DataSource=ds.Tables["table"].DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion //RefreshData
        #endregion

        #region Control
		/// <summary>
		/// 
		/// </summary>
        private void InitQueryBar()
        {
            try
            {
                this.panel1.Visible =false;
                this.splitter1.Visible=false;
                cmbStation.Items.Add("<全部站>");
                string str="select Name from V_heatDatas Group by name";
                con=new DBcon();
                SqlCommand cmd=new SqlCommand(str,con.GetConnection());
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    cmbStation.Items.Add(dr.GetValue(0).ToString().Trim());
                }
                dr.Close();
                cmd.Dispose();
                cmbStation.Text=cmbStation.Items[0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #region toolBar1_ButtonClick
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch(e.Button.Text.Trim())
            {
                case "添加":
                    Add();
                    break; 
                case "编辑":
                    Edit ();
                    break; 
                case "删除":
                    Delete();
                    break; 
                case "打印":
                    //					Print();
                    InputExl();
                    break;
                case "查询":
                    ShowQueryBar(toolBar1.Buttons[3].Pushed);
                    if(toolBar1.Buttons[3].Pushed==false)
                        this.UnQuery();
                    break; 
                case "导出":
					InputExl();
                    break;
                case "统计":
                    Statistic();
                    break;
                case "退出":
                    this.Close();
                    break;
            }
        }
        #endregion //toolBar1_ButtonClick


        #region ShowQueryBar
		/// <summary>
		/// 
		/// </summary>
		/// <param name="blnShow"></param>
        private void ShowQueryBar(bool blnShow)
        {
            this.panel1.Visible=!panel1.Visible;
            this.splitter1.Visible=!splitter1.Visible;
            if(_stationName!="*")
                cmbStation.Text=_stationName;
        }
        #endregion //ShowQueryBar


        #region strQuery
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        private string strQuery()
        {
            string str="select * from V_heatdatas Where time between '";
            str=str+m_dtBegin;
            str=str+"' and '";
            str=str+m_dtEnd;
            str=str+"'";
            if(cmbStation.Text!="<全部站>")
            {
                str=str+" and Name='";
                str=str+cmbStation.Text.Trim();
                str=str+"'";
                m_Title=cmbStation.Text+"数据报表";
            }
            else
                m_Title="全部站数据报表";
            return str;
        }
        #endregion //strQuery


        #region Add
		/// <summary>
		/// 
		/// </summary>
        private void Add()
        {
            frmDataItems f= new frmDataItems();
            if (DialogResult.OK==f.ShowDialog())
            {
                LoadDatas();
            }
        }
        #endregion //Add


        #region Edit
		/// <summary>
		/// 
		/// </summary>
        private void Edit()
        {
            LoadDatas();
            if(NoRecordDataGrid()){return;}
            int row=m_dataGrid.CurrentCell.RowNumber;
            int col=0;
            string s_id=m_dataGrid[row,col].ToString();
            if(s_id.Trim()=="")
            {
                MessageBox.Show("请正确选择需要编辑的数据行!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            int id=Convert.ToInt32(m_dataGrid[row,col].ToString());
            frmDataItems f=new frmDataItems(id);
            if (DialogResult.OK==f.ShowDialog())
            {
                LoadDatas();
            }
        }
        #endregion //Edit


        #region Print
        private void Print()
        {
            try
            {			
                if(tCGrid.SelectedTab==tabPage1)
                {			
                    cutePrinter dgp=new cutePrinter(m_dataGrid,m_Title,30);
                    string[] header={"","","","","","","","","","","",""};
                    dgp.setHeader(header);
                    dgp.dtB=d_dtB.ToLongDateString();
                    dgp.dtE=d_dtE.ToLongDateString();
                    dgp.Print();
                }
                else if(tCGrid.SelectedTab==tabPage2)
                {
                    cutePrinter dgp=new cutePrinter(m_dataGrid1,m_Title,30);
                    string[] header={"","","","","","","","","","","",""};
                    dgp.setHeader(header);
                    dgp.dtB=d_dtB.ToLongDateString();
                    dgp.dtE=d_dtE.ToLongDateString();
                    //					dgp.dtB=m_dtBegin;
                    //					dgp.dtE=m_dtEnd;
                    dgp.Print();
                }
                else if(tCGrid.SelectedTab==tabPage3)
                {
                    cutePrinter dgp=new cutePrinter(m_dataGrid2,m_Title,30);
                    string[] header={"","","","","","","","","","","",""};
                    dgp.setHeader(header);
                    dgp.dtB=d_dtB.ToLongDateString();
                    dgp.dtE=d_dtE.ToLongDateString();
                    dgp.Print();
                }
                else
                    return ;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion //Print
        private DataGrid PrintDataInfo(string s,DataGrid dg)
        {
            DataTable Ptable=ds.Tables[s];
            int TitleCount=Ptable.Columns.Count;
            DataGridTableStyle tbs= new DataGridTableStyle();
            int index=0;
            for(int i=0;i<DGtitle.Length;i++)
            {
                for(int j=0;j<TitleCount;j++)
                {
                    if(Ptable.Columns[j].ColumnName!=DGtitle[i].m_GName)
                        continue;
                    DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
                    clm.MappingName=DGtitle[i].m_GName;
                    clm.HeaderText=DGtitle[i].m_GTitle;
                    tbs.GridColumnStyles.Add(clm);
                    tbs.GridColumnStyles[index].Width=System.Convert.ToInt32(DGtitle[i].m_GWidth);
                    index++;
                }	
            }
            tbs.MappingName ="tableprint";
            dg.TableStyles.Add(tbs);
            dg.DataSource=Ptable;
            return dg;

			
        }
        private void Delete()
        {
            int row=m_dataGrid.CurrentCell.RowNumber;
            int col=0;
            string s_id=m_dataGrid[row,col].ToString();
            if(s_id.Trim()=="")
            {
                MessageBox.Show("请正确选择需要删除的数据行!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            LoadDatas();
            int id=Convert.ToInt32(m_dataGrid[row,col].ToString());
            if(NoRecordDataGrid()) {return;}
            DialogResult a=MessageBox.Show("确定要删除该行数据?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(a==DialogResult.Yes)
            {
                con=new DBcon();
                SqlCommand sqlCmd=new SqlCommand("PointDataDelete",con.GetConnection());
                sqlCmd.CommandType=CommandType.StoredProcedure;
                sqlCmd.Parameters.Add("@p_ID",id);
                sqlCmd.ExecuteNonQuery();
                LoadDatas();
            }
        }
        private void UnQuery()
        {
            dtEnd.Value=dtBegin.Value.AddDays(1);
        }
        protected bool NoRecordDataGrid()
        {
            return -1==m_dataGrid.CurrentRowIndex;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(dtBegin.Value.Date==dtEnd.Value.Date)
            {
                if(numericUpDown1.Value>=numericUpDown2.Value)
                {
                    MessageBox.Show("时间选择条件无效","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            if(dtBegin.Value.Date>dtEnd.Value.Date)
            {
                MessageBox.Show("时间选择条件无效","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            m_dtBegin=dtBegin.Value.ToShortDateString()+" "+numericUpDown1.Value.ToString()+":00:00";
            m_dtEnd=dtEnd.Value.ToShortDateString()+" "+numericUpDown2.Value.ToString()+":00:00";
            RefreshData();			
        }

        private void ReadGridDataTitle()
        {
            try
            {
                XmlDocument xDoc=new XmlDocument();
                xDoc.Load("DataInfo.xml");
                XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table[@Name='DataInfo']");
                if(!d_bool)
                {
                    DGtitle=new DataGridTitle[xNode.ChildNodes.Count];
                    DGtitle[0].m_GName="grrealdata_id";
                    DGtitle[0].m_GTitle="编号";
                    DGtitle[0].m_GWidth="30";
                    DGtitle[1].m_GName="Name";
                    DGtitle[1].m_GTitle="名称";
                    DGtitle[1].m_GWidth="100";
                    DGtitle[2].m_GName="time";
                    DGtitle[2].m_GTitle="时间";
                    DGtitle[2].m_GWidth="130";
                    for(int i=3;i<xNode.ChildNodes.Count;i++)
                    {
                        DGtitle[i].m_GName=xNode.ChildNodes[i].Attributes.GetNamedItem("name").Value.ToString().Trim();
                        DGtitle[i].m_GTitle=xNode.ChildNodes[i].InnerText.Trim();
                        DGtitle[i].m_GWidth=xNode.ChildNodes[i].Attributes.GetNamedItem("width").Value.ToString().Trim();
                        DGtitle[i].m_GUnit=xNode.ChildNodes[i].Attributes.GetNamedItem("ytitle").Value.ToString().Trim();
                    }
                }
                else
                {
                    DGtitle=new DataGridTitle[d_curveInfo.Length+3];
                    DGtitle[0].m_GName="grrealdata_id";
                    DGtitle[0].m_GTitle="编号";
                    DGtitle[0].m_GWidth="30";
                    DGtitle[1].m_GName="Name";
                    DGtitle[1].m_GTitle="名称";
                    DGtitle[1].m_GWidth="100";
                    DGtitle[2].m_GName="time";
                    DGtitle[2].m_GTitle="时间";
                    DGtitle[2].m_GWidth="130";
                    for(int i=0;i<xNode.ChildNodes.Count;i++)
                    {
                        for(int j=0;j<d_curveInfo.Length;j++)
                        {
                            if(d_curveInfo[j]==xNode.ChildNodes[i].InnerText.Trim())
                            {
                                DGtitle[j+3].m_GName=xNode.ChildNodes[i].Attributes.GetNamedItem("name").Value.ToString().Trim();
                                DGtitle[j+3].m_GTitle=xNode.ChildNodes[i].InnerText.Trim();
                                DGtitle[j+3].m_GWidth=xNode.ChildNodes[i].Attributes.GetNamedItem("width").Value.ToString().Trim();
                                DGtitle[i].m_GUnit=xNode.ChildNodes[i].Attributes.GetNamedItem("ytitle").Value.ToString().Trim();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
	
		/// <summary>
		/// 
		/// </summary>
        private void Statistic()
        {
            if(ChangeDataGrid()==0)
                return;
            DataChang();
            int d_RowsCount=dt1.Rows.Count;
            d_Avg=false;
            d_Add=false;
            d_Max=false;
            d_Min=false;
            // 2007.05.31
            //
            //avgSign=false;
            ClearAgg(d_RowsCount);
            frmStatistic f=new frmStatistic();
            f.ShowDialog();
            if(d_Max)
            {
                object[] d_Agg=new object[dt1.Columns.Count];
                d_Agg[0]="";
                //				int d_ID=0;
                int d_dtInt=2;
                for(int i=0;i<dt1.Columns.Count;i++)
                {
                    double d_Value=0;
                    double d_Value0=0;
                    //					if(dt.Columns[i].ColumnName.Trim()=="watNo")
                    //					{
                    //						d_ID=i;
                    //						continue;
                    //					}
                    //					if(dt.Columns[i].ColumnName.Trim()=="description")
                    //						continue;
                    if(dt1.Columns[i].ColumnName.Trim()=="time")
                    {
                        d_dtInt=i;
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="Name")
                    {
                        d_Agg[i]="最大值";
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="oneAccum"||dt1.Columns[i].ColumnName.Trim()=="twoAccum")
                    {
                        d_Agg[i]=null;
                        continue;
                    }
                    else
                    {
                        d_Value=System.Convert.ToDouble(dt1.Rows[0][i]);
                        d_Agg[d_dtInt]=dt1.Rows[0][d_dtInt].ToString();
                        for(int j=1;j<dt1.Rows.Count;j++)
                        {
                            //							if(dt.Rows[j][d_ID].ToString()=="")
                            //								continue;
                            d_Value0=System.Convert.ToDouble(dt1.Rows[j][i]);
                            if(d_Value==d_Value0)
                            {
                                d_Agg[d_dtInt]=d_Agg[d_dtInt];//+"和"+dt1.Rows[j][d_dtInt].ToString();
                            }
                            if(d_Value<d_Value0)
                            {
                                d_Value=d_Value0;
                                d_Agg[d_dtInt]=dt1.Rows[j][d_dtInt].ToString();
                            }
                        }
                        d_Agg[i]=d_Value;
                    }
                }
                dt1.Rows.Add(d_Agg);
                if(tCGrid.SelectedTab==tabPage1)
                    m_dataGrid.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage2)
                    m_dataGrid1.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage3)
                    m_dataGrid2.DataSource=dt1.DefaultView;
            }

            if(d_Min)
            {
                object[] d_Agg=new object[dt1.Columns.Count];
                d_Agg[0]="";
                //				int d_ID=0;
                int d_dtInt=2;
                for(int i=0;i<dt1.Columns.Count;i++)
                {
                    double d_Value=0;
                    double d_Value0=0;
                    //					if(dt.Columns[i].ColumnName.Trim()=="watNo")
                    //					{
                    //						d_ID=i;
                    //						continue;
                    //					}
                    //					if(dt.Columns[i].ColumnName.Trim()=="description")
                    //						continue;
                    if(dt1.Columns[i].ColumnName.Trim()=="time")
                    {
                        d_dtInt=i;
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="Name")
                    {
                        d_Agg[i]="最小值";
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="oneAccum"||dt1.Columns[i].ColumnName.Trim()=="twoAccum")
                    {
                        d_Agg[i]=null;
                        continue;
                    }
                    else
                    {
                        d_Value=System.Convert.ToDouble(dt1.Rows[0][i]);
                        d_Agg[d_dtInt]=dt1.Rows[0][d_dtInt].ToString();
                        for(int j=1;j<dt1.Rows.Count;j++)
                        {
                            //							if(dt.Rows[j][d_ID].ToString()=="")
                            //								continue;
                            d_Value0=System.Convert.ToDouble(dt1.Rows[j][i]);
                            if(d_Value==d_Value0)
                            {
                                d_Agg[d_dtInt]=d_Agg[d_dtInt];//+"和"+dt1.Rows[j][d_dtInt].ToString();
                            }
                            if(d_Value>d_Value0)
                            {
                                d_Value=d_Value0;
                                d_Agg[d_dtInt]=dt1.Rows[j][d_dtInt].ToString();
                            }
                        }
                        d_Agg[i]=d_Value;
                    }
                }
                dt1.Rows.Add(d_Agg);
                if(tCGrid.SelectedTab==tabPage1)
                    m_dataGrid.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage2)
                    m_dataGrid1.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage3)
                    m_dataGrid2.DataSource=dt1.DefaultView;
            }

            if(d_Avg)
            {
				
                object[] d_Agg=new object[dt1.Columns.Count];
                d_Agg[0]="";
                //				int d_ID=0;
                for(int i=0;i<dt.Columns.Count;i++)
                {
                    double d_Value=0;
                    //					if(dt.Columns[i].ColumnName.Trim()=="watNo")
                    //					{
                    //						d_ID=i;
                    //						continue;
                    //					}
                    //					if(dt.Columns[i].ColumnName.Trim()=="description")
                    //						continue;
                    if(dt1.Columns[i].ColumnName.Trim()=="time")
                    {
                        d_Agg[i]=d_dtB.ToShortDateString()+"至"+d_dtE.ToShortDateString();
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="Name")
                    {
                        d_Agg[i]="平均值";
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="oneAccum"||dt1.Columns[i].ColumnName.Trim()=="twoAccum")
                    {
                        d_Agg[i]=null;
                        continue;
                    }
                    else
                    {
                        for(int j=0;j<dt1.Rows.Count;j++)
                        {
                            //							if(dt.Rows[j][d_ID].ToString()=="")
                            //								continue;
                            if(dt1.Rows[j][0].ToString()=="最大值"||dt1.Rows[j][0].ToString()=="最小值"||dt1.Rows[j][0].ToString()=="平均值"||dt1.Rows[j][0].ToString()=="累计总量")
                                continue;
                            d_Value=d_Value+System.Convert.ToDouble(dt1.Rows[j][i]);	
                        }
                        d_Value=d_Value/d_RowsCount;
                        d_Value=System.Convert.ToDouble(d_Value.ToString("F2"));
                        d_Agg[i]=d_Value;
                    }
                }
                dt1.Rows.Add(d_Agg);
                if(tCGrid.SelectedTab==tabPage1)
                    m_dataGrid.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage2)
                    m_dataGrid1.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage3)
                    m_dataGrid2.DataSource=dt1.DefaultView;
            }

            if(d_Add)
            {
                //				if(!avgSign)
                //					DataChang();
                int wee=dt1.Rows.Count;
                object[] d_Agg=new object[dt1.Columns.Count];
                d_Agg[0]="";
				
                //				int d_ID=0;
                for(int i=0;i<dt1.Columns.Count;i++)
                {
                    double d_Value=0;
                    //					if(dt.Columns[i].ColumnName.Trim()=="watNo")
                    //					{
                    //						d_ID=i;
                    //						continue;
                    //					}
                    //					if(dt.Columns[i].ColumnName.Trim()=="description")
                    //						continue;
                    if(dt1.Columns[i].ColumnName.Trim()=="time")
                    {
                        d_Agg[i]=d_dtB.ToShortDateString()+"至"+d_dtE.ToShortDateString();
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="Name")
                    {
                        d_Agg[i]="累计总量";
                        continue;
                    }
                    if(dt1.Columns[i].ColumnName.Trim()=="oneAccum"||dt1.Columns[i].ColumnName.Trim()=="twoAccum")
                    {
                        //						for(int j=0;j<dt1.Rows.Count;j++)
                        //						{
                        //							if(dt1.Rows[j][0].ToString()=="最大值"||dt1.Rows[j][0].ToString()=="最小值"||dt1.Rows[j][0].ToString()=="平均值"||dt1.Rows[j][0].ToString()=="累计总量")
                        //								continue;
                        //							d_Value=d_Value+System.Convert.ToDouble(dt1.Rows[j][i]);
                        //						}
                        //						d_Agg[i]=d_Value;
                        d_Value=System.Convert.ToDouble(dt1.Rows[0][i]);
                        d_Value=System.Convert.ToDouble(dt1.Rows[d_Row-1][i])-d_Value;
                        d_Agg[i]=d_Value;
                    }
                    else
                    {
                        d_Agg[i]=null;
                    }
                }
                dt1.Rows.Add(d_Agg);
                if(tCGrid.SelectedTab==tabPage1)
                    m_dataGrid.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage2)
                    m_dataGrid1.DataSource=dt1.DefaultView;
                if(tCGrid.SelectedTab==tabPage3)
                    m_dataGrid2.DataSource=dt1.DefaultView;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        private void DataChang()
        {
            dt1=dt.Clone();
            for(int colnum=0;colnum<dt1.Columns.Count;colnum++)
            {
                dt1.Columns[colnum].DataType=System.Type.GetType("System.String");
            }
            for(int i=0;i<dt.Rows.Count;i++)
            {
                DataRow newrow = dt1.NewRow();
                dt1.Rows.Add(newrow);
                for(int j=0;j<dt.Columns.Count;j++)
                {
                    dt1.Rows[i][j]=dt.Rows[i][j].ToString();					
                }
            }
            //			DataView   dv=new DataView(dt1);
            //			dv.Sort="time asc";
            m_dataGrid.DataSource=dt1.DefaultView;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
        private void ClearAgg(int index)
        {
            for(int i=d_Row;i<index;i++)
            {
                dt.Rows[d_Row].Delete();					
            }			
        }

		/// <summary>
		/// 
		/// </summary>
        private void InputExl()
        {
            string time=m_dtBegin+" 至 "+m_dtEnd;
            if(d_bool)
            {
                if(tCGrid.SelectedTab==tabPage1)
                {
                    DataTable dtE=ds.Tables["table1"];	
                    ExcelInput exl=new ExcelInput(dtE,d_bool,time);
                }
                else if(tCGrid.SelectedTab==tabPage2)
                {
                    DataTable dtE=ds.Tables["table2"];	
                    ExcelInput exl=new ExcelInput(dtE,d_bool,time);
                }
                else if(tCGrid.SelectedTab==tabPage3)
                {
                    DataTable dtE=ds.Tables["table3"];	
                    ExcelInput exl=new ExcelInput(dtE,d_bool,time);
                }
                else
                    return ;
            }
            else
            {
                DataTable dtE=ds.Tables["table"];	
                //				DataTable dtE=(DataTable)m_dataGridAll.DataSource;
				if( dtE.Rows.Count != 0 )
				{
					bool b = true;
					if( dtE.Rows.Count > 300 )
					{
						string s = "导入大量数据将花费较长时间，是否继续？";
						DialogResult dr = MessageBox.Show(s, "提示", 
							MessageBoxButtons.YesNo, MessageBoxIcon.Question );
						b = ( dr == DialogResult.Yes );
					}

					if( b )
					{
						ExcelInput exl=new ExcelInput(dtE,d_bool,time);
					}
				}
				else
				{
					MessageBox.Show("没有可导入的数据！","错误",
						MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        private bool NoIDDataGrid(int id)
        {
            if(id.ToString()=="")
                return true;
            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        private int ChangeDataGrid()
        {
            int i=0;
            if(tCGrid.SelectedTab==tabPage1)
            {
                m_dataGrid.DataSource=ds.Tables["table1"].DefaultView;
                i=ds.Tables["table1"].Rows.Count;
                dt=ds.Tables["table1"];
                return i;
            }
            if(tCGrid.SelectedTab==tabPage2)
            {
                m_dataGrid1.DataSource=ds.Tables["table2"].DefaultView;
                i=ds.Tables["table2"].Rows.Count;
                dt=ds.Tables["table2"];
                return i;
            }
            if(tCGrid.SelectedTab==tabPage3)
            {
                m_dataGrid2.DataSource=ds.Tables["table3"].DefaultView;
                i=ds.Tables["table3"].Rows.Count;
                dt=ds.Tables["table3"];
                return i;
            }
            return i;
        }
        #endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void tCGrid_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ChangeDataGrid();
        }
    }
}
