using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace btGRMain
{
    /// <summary>
    /// frmDataBase 的摘要说明。
    /// </summary>
    public class frmAddPumpDatas : System.Windows.Forms.Form
    {
        #region Members
        private System.Windows.Forms.ToolBarButton tbnQuery;
        private System.Windows.Forms.ToolBarButton tbnEdit;
        private System.Windows.Forms.ToolBarButton tbnDelete;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbnAdd;
        private System.Windows.Forms.ToolBarButton tbnPrint;
        private System.Windows.Forms.ToolBarButton tbnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Button btnOK;
        private bool b_analyse=false;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private System.ComponentModel.IContainer components;
        private DBcon con=null;
        private bool b_New=false;
        private DateTime m_dtBegin;
        private DateTime m_dtEnd;
        private bool m_Set=false;
        private string m_Title=null;
        private System.Windows.Forms.ToolBarButton tbnSet;
        private System.Windows.Forms.ToolBarButton tbnFont;
        private DataTable dtAnalyse=null;
        #endregion //

        #region frmAddPumpDatas
        /// <summary>
        /// 
        /// </summary>
        public frmAddPumpDatas()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            //            this.tbnFontVisible =
        }
        #endregion //

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
        #endregion //

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmAddPumpDatas));
            this.tbnQuery = new System.Windows.Forms.ToolBarButton();
            this.tbnEdit = new System.Windows.Forms.ToolBarButton();
            this.tbnDelete = new System.Windows.Forms.ToolBarButton();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbnAdd = new System.Windows.Forms.ToolBarButton();
            this.tbnSet = new System.Windows.Forms.ToolBarButton();
            this.tbnFont = new System.Windows.Forms.ToolBarButton();
            this.tbnPrint = new System.Windows.Forms.ToolBarButton();
            this.tbnExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tbnQuery
            // 
            this.tbnQuery.ImageIndex = 2;
            this.tbnQuery.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnQuery.Text = "查询";
            // 
            // tbnEdit
            // 
            this.tbnEdit.ImageIndex = 1;
            this.tbnEdit.Text = "编辑";
            // 
            // tbnDelete
            // 
            this.tbnDelete.ImageIndex = 6;
            this.tbnDelete.Text = "删除";
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbnAdd,
                                                                                        this.tbnEdit,
                                                                                        this.tbnDelete,
                                                                                        this.tbnQuery,
                                                                                        this.tbnSet,
                                                                                        this.tbnFont,
                                                                                        this.tbnPrint,
                                                                                        this.tbnExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(856, 41);
            this.toolBar1.TabIndex = 3;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbnAdd
            // 
            this.tbnAdd.ImageIndex = 0;
            this.tbnAdd.Text = "添加";
            // 
            // tbnSet
            // 
            this.tbnSet.ImageIndex = 3;
            this.tbnSet.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnSet.Text = "分析";
            // 
            // tbnFont
            // 
            this.tbnFont.ImageIndex = 8;
            this.tbnFont.Text = "字体";
            this.tbnFont.Visible = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 460);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计分析条件设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "站点名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束时间：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "开始时间：";
            // 
            // cmbStation
            // 
            this.cmbStation.Location = new System.Drawing.Point(80, 112);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(112, 20);
            this.cmbStation.TabIndex = 2;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(80, 72);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(112, 21);
            this.dtEnd.TabIndex = 1;
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(80, 32);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(112, 21);
            this.dtBegin.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 160);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "查询";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(208, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 460);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(211, 41);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(645, 460);
            this.m_dataGrid.TabIndex = 1;
            // 
            // frmAddPumpDatas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(856, 501);
            this.Controls.Add(this.m_dataGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmAddPumpDatas";
            this.Text = "frmAddPumpDatas";
            this.Load += new System.EventHandler(this.frmAddPumpDatas_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region frmAddPumpDatas_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddPumpDatas_Load(object sender, System.EventArgs e)
        {
            if(this.Text=="补水数据查询")
            {
                this.toolBar1.Buttons[4].Visible=false;
                InitQueryBar();
                InitializeGrid();
                LoadData();
            }
            else if(this.Text=="补水参数统计分析报表")  // unuse
            {
                InitQueryBar();
                this.toolBar1.Buttons[4].Pushed=true;
                m_Set=true;
                ShowQueryBar(toolBar1.Buttons[4].Pushed);
                if(toolBar1.Buttons[4].Pushed!=false)
                    this.UnQuery();
            }
        }
        #endregion //

        #region InitializeGrid
        /// <summary>
        /// 
        /// </summary>
        private void InitializeGrid()
        {
            DataGridTableStyle tbs=new DataGridTableStyle(); 
            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();

            clm.MappingName="id";
            clm.HeaderText="编号";
            clm.Width=60;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="name";
            clm.HeaderText="站点名称";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="team";
            clm.HeaderText="所属班组";
            clm.Width=100;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="time";
            clm.HeaderText="时间";
            clm.Width=140;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="addPumpValue";
            clm.HeaderText="自来水流量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="description";
            clm.HeaderText="备注";
            clm.Width=this.m_dataGrid.Width-580;
            tbs.GridColumnStyles.Add(clm);

            tbs.MappingName ="addPumpDatas";
            m_dataGrid.TableStyles.Add(tbs);
            m_dataGrid.HeaderFont=new Font("Arial",15);
        }
        #endregion //

        #region LoadData
        /// <summary>
        /// 
        /// </summary>
        private void LoadData()
        {
            try
            {
                con=new DBcon();
                if(TimeBeginEnd())
                {
                    string str="select * from v_AddPumpDatas where time between '"+m_dtBegin.Date+"' and '"+m_dtEnd.Date+"' order by team desc";
                    SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                    DataSet ds=new DataSet();
                    da.Fill(ds,"addPumpDatas");
                    da.Dispose();
                    m_dataGrid.DataSource=ds.Tables["addPumpDatas"];
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据读取失败!","错误",
                //MessageBoxButtons.OK,
                //MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据读取失败!", ex );
            }
        }
        #endregion //LoadData

        #region RefreshTitle
        /// <summary>
        /// 
        /// </summary>
        private void RefreshTitle()
        {
            if(!b_New)
            {
                DataGridTableStyle tbs=new DataGridTableStyle(); 
                DataGridTextBoxColumn clm=new DataGridTextBoxColumn();

                clm.MappingName="id";
                clm.HeaderText="编号";
                clm.Width=60;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="name";
                clm.HeaderText="站点名称";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                clm=new DataGridTextBoxColumn();
                clm.MappingName="team";
                clm.HeaderText="所属班组";
                clm.Width=100;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="time";
                clm.HeaderText="时间";
                clm.Width=140;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="addPumpValue";
                clm.HeaderText="自来水流量"+"\n("+"T"+")";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="description";
                clm.HeaderText="备注";
                clm.Width=this.m_dataGrid.Width-470;
                tbs.GridColumnStyles.Add(clm);
				

                tbs.MappingName ="addPumpDatasNew";
                m_dataGrid.TableStyles.Add(tbs);
                m_dataGrid.HeaderFont=new Font("Arial",15);
            }
        }
        #endregion //RefreshTitle

        #region RefreshData
        /// <summary>
        /// 
        /// </summary>
        private void RefreshData()
        {
            try
            {
                con=new DBcon();
                string str="select * from v_AddPumpDatas where time between '"+m_dtBegin.Date+"' and '"+m_dtEnd.Date+"' order by team desc";
                SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                DataSet ds=new DataSet();
                da.Fill(ds,"addPumpDatasNew");
                da.Dispose();
                RefreshTitle();
                m_dataGrid.DataSource=ds.Tables["addPumpDatasNew"];
                b_New=true;
            }
            catch
            {
                MessageBox.Show("数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion //RefreshData

        #region strQuery
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string strQuery()
        {
            string str="select * from v_AddPumpDatas Where time between '";
            str=str+m_dtBegin.Date;
            str=str+"' and '";
            str=str+m_dtEnd.Date;
            if(cmbStation.Text!="<全部站>")
            {
                str=str+"' and Name='";
                str=str+cmbStation.Text.Trim();
                //				str=str+"'";
                m_Title=cmbStation.Text+"数据报表";
            }
            else
                m_Title="全部站数据报表";

            str=str+"' order by time desc";
				
            return str;

        }
        #endregion //strQuery

        #region QueryData
        /// <summary>
        /// 
        /// </summary>
        private void QueryData()
        {
            try
            {
                //ReadGridDataTitle();
                con=new DBcon();
                SqlDataAdapter da=new SqlDataAdapter(strQuery(),con.GetConnection());
                DataSet ds=new DataSet();
                da.Fill(ds,"addPumpDatas");
                da.Dispose();
                m_dataGrid.DataSource=ds.Tables["addPumpDatas"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());//"数据查询失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion //QueryData

        #region AnalyseTitle
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="dtTitle"></param>
        private void AnalyseTitle(DateTime Begin,DateTime End,DateTime dtTitle)
        {
            if(!b_analyse)
            {
                DataGridTableStyle tbs=new DataGridTableStyle(); 
                DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="name";
                clm.HeaderText="站点名称";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                clm=new DataGridTextBoxColumn();
                clm.MappingName="team";
                clm.HeaderText="所属班组";
                clm.Width=100;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="ValueBegin";
                clm.HeaderText=Begin.ToShortDateString()+"自来水流量"+"\n("+"T"+")";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                clm=new DataGridTextBoxColumn();
                clm.MappingName="ValueEnd";
                clm.HeaderText=End.ToShortDateString()+"自来水流量"+"\n("+"T"+")";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);
				
                clm=new DataGridTextBoxColumn();
                clm.MappingName="AddWat";
                clm.HeaderText="补水量"+"\n("+"T"+")";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                clm=new DataGridTextBoxColumn();
                clm.MappingName="AverageWat";
                clm.HeaderText="平均每日补水量"+"\n("+"T"+")";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                clm=new DataGridTextBoxColumn();
                clm.MappingName="MissWat";
                clm.HeaderText="平均失水率";
                clm.Width=120;
                tbs.GridColumnStyles.Add(clm);

                tbs.MappingName ="AddPumpTrimTable";
                m_dataGrid.TableStyles.Add(tbs);
                m_dataGrid.HeaderFont=new Font("Arial",15);
            }
        }
        #endregion //AnalyseTitle

        #region InitQueryBar
        /// <summary>
        /// 
        /// </summary>
        private void InitQueryBar()
        {
            try
            {
                this.panel1.Visible =false;
                this.splitter1.Visible=false;
                UnQuery();
                cmbStation.Items.Add("<全部站>");
                string str="select Name from v_AddPumpDatas Group by name";
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
                // 2007.05.30
                //
                //MessageBox.Show("站点数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("站点数据读取失败!", ex );
            }
        }
        #endregion //InitQueryBar

        #region TimeBeginEnd
        /// <summary>
        /// 判断日期范围是否合法，同时保存日期值
        /// </summary>
        /// <returns></returns>
        private bool TimeBeginEnd()
        {
            #region ...
//            if(dtBegin.Value.Date==dtEnd.Value.Date)
//            {
//                if(numericUpDown1.Value>=numericUpDown2.Value)
//                {
//                    MessageBox.Show(
//                        "时间选择条件无效",
//                        "错误",
//                        MessageBoxButtons.OK,
//                        MessageBoxIcon.Error
//                        );
//                    return false;
//                }
//            }
//            if(dtBegin.Value.Date>dtEnd.Value.Date)
//            {
//                MessageBox.Show(
//                    "时间选择条件无效",
//                    "错误",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error
//                    );
//                return false;
//            }
            #endregion //...

            // 该日起
            //
            m_dtBegin = //System.Convert.ToDateTime(dtBegin.Value.ToShortDateString()+" "+numericUpDown1.Value.ToString()+":00:00");
                dtBegin.Value.Date;
            // 该日尾
            //
            m_dtEnd = //System.Convert.ToDateTime(dtEnd.Value.ToShortDateString()+" "+numericUpDown2.Value.ToString()+":00:00");
                dtEnd.Value.Date + TimeSpan.Parse("23:59:59");
            if ( m_dtBegin > m_dtEnd )
            {
                MessageBox.Show(
                    "时间选择条件无效",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            return true;
        }
        #endregion //TimeBeginEnd

        #region Add
        /// <summary>
        /// 
        /// </summary>
        private void Add()
        {
            frmteamAddPump f= new frmteamAddPump();
            if (DialogResult.OK==f.ShowDialog())
            {
                RefreshData();
            }
        }
        #endregion //Add

        #region Edit
        /// <summary>
        /// 
        /// </summary>
        private void Edit()
        {
            if(NoRecordDataGrid()){return;}
            int row=m_dataGrid.CurrentCell.RowNumber;
            int col=0;
            string s_id=m_dataGrid[row,col].ToString();

            if(s_id.Trim() == string.Empty )
            {
                MessageBox.Show(
                    "请正确选择需要编辑的数据行!",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                return;
            }

            int id=Convert.ToInt32(m_dataGrid[row,col].ToString());
            frmAddPumpDatasItem f=new frmAddPumpDatasItem(id);
            if (DialogResult.OK==f.ShowDialog())
            {
                RefreshData();
            }
        }

        #endregion //

        #region ChangeFont
        /// <summary>
        /// 
        /// </summary>
        private void ChangeFont()
        {
            FontDialog fd = new FontDialog();
            fd.Font = this.m_dataGrid.Font;
            if ( fd.ShowDialog(this) == DialogResult.OK )
            {
                m_dataGrid.Font = fd.Font;
            }
        }
        #endregion //ChangeFont

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        private void Delete()
        {
            if(NoRecordDataGrid()) {return;}
			
            int row=m_dataGrid.CurrentCell.RowNumber;
            int col=1;
            string UserName=m_dataGrid[row,col].ToString().ToString().Trim();
            if(UserName==null)
            {
                MessageBox.Show("请正确选择需要删除的数据行!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return ;
            }

            if(MessageBox.Show("确定要删除该行数据?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes){	return ;}
            row=m_dataGrid.CurrentCell.RowNumber;
            col=0;
            DBcon con=new DBcon();
            int id=Convert.ToInt32(m_dataGrid[row,col].ToString());
            SqlCommand sqlCmd=new SqlCommand("DELETE FROM tbl_addPumpDatas WHERE ID=" + id,con.GetConnection());
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Dispose();
            RefreshData();
        }
        #endregion //Delete

        #region ShowQueryBar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnShow"></param>
        private void ShowQueryBar(bool blnShow)
        {
            if(blnShow)
            {
                if(m_Set)
                {
                    this.tbnAdd.Visible=false;
                    this.tbnDelete.Visible=false;
                    this.tbnEdit.Visible=false;
                    this.tbnQuery.Visible=false;
                }
                else
                    this.groupBox1.Text="查询条件";
                this.panel1.Visible=true;
                this.splitter1.Visible=true;
            }
            else
            {
                this.panel1.Visible=!panel1.Visible;
                this.splitter1.Visible=!splitter1.Visible;
            }
        }
        #endregion //ShowQueryBar

        #region UnQuery
        /// <summary>
        /// 
        /// </summary>
        private void UnQuery()
        {
            dtBegin.Value=dtEnd.Value.AddDays(-1);
        }
        #endregion //UnQuery

        #region NoRecordDataGrid
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool NoRecordDataGrid()
        {
            return -1==m_dataGrid.CurrentRowIndex;
        }
        #endregion //NoRecordDataGrid

        #region Print
        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            if(m_Set)
            {
                if(dtAnalyse==null)
                {
                    MessageBox.Show("请选择分析条件");
                    return;
                }
                InputExlPrint exl=new InputExlPrint(dtAnalyse,m_Set,m_dtBegin,m_dtEnd);
            }
            else
            {
				
                DataTable dtBS=(DataTable)m_dataGrid.DataSource;
                InputExlPrint exl=new InputExlPrint(dtBS,m_Set,m_dtBegin,m_dtEnd);
            }
        }
        #endregion //Print

        #region toolBar1_ButtonClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar1_ButtonClick(object sender, 
            System.Windows.Forms.ToolBarButtonClickEventArgs e)
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
                    Print();
                    break;
                case "查询":
                    m_Set=false;
                    ShowQueryBar(toolBar1.Buttons[3].Pushed);
                    if(toolBar1.Buttons[3].Pushed!=false)
                        this.UnQuery();
                    break; 
                case "分析":
                    m_Set=true;
                    ShowQueryBar(toolBar1.Buttons[4].Pushed);
                    if(toolBar1.Buttons[4].Pushed!=false)
                        this.UnQuery();
                    break;
                case "退出":
                    this.Close();
                    break;
                case "字体":
                    ChangeFont();
                    break;
            }
        }

        #endregion //toolBar1_ButtonClick

        #region btnQuery_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(TimeBeginEnd())
            {
                if(m_Set)
                {
                    DateTime dtTitle=DateTime.Now;
                    AddPumpAnalyse analyse=new AddPumpAnalyse(
                        m_dtBegin,
                        m_dtEnd,
                        cmbStation.Text.Trim(),
                        dtTitle
                        );
                    dtAnalyse=analyse.GetTableDatas();
                    AnalyseTitle(m_dtBegin,m_dtEnd,dtTitle);
                    m_dataGrid.DataSource=dtAnalyse;
                    b_analyse=true;
                }
                else
                    QueryData();
            }
        }
        #endregion //BtnQueryClick
    }
}
