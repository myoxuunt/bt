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
    /// frmFactoryDatas 的摘要说明。
    /// </summary>
    public class frmFactoryDatas : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolBarButton tbnQuery;
        private System.Windows.Forms.ToolBarButton tbnAdd;
        private System.Windows.Forms.ToolBarButton tbnEdit;
        private System.Windows.Forms.ToolBarButton tbnDelete;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbnPrint;
        private System.Windows.Forms.ToolBarButton tbnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Splitter splitter1;
        private System.ComponentModel.IContainer components;
        private DateTime m_Begin;
        private DateTime m_End;
        private DBcon con=null;
        private DataSet ds=null;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private System.Windows.Forms.ToolBarButton tbnFont;
        private DataTable dt=null;

        /// <summary>
        /// 
        /// </summary>
        public frmFactoryDatas()
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFactoryDatas));
            this.tbnQuery = new System.Windows.Forms.ToolBarButton();
            this.tbnAdd = new System.Windows.Forms.ToolBarButton();
            this.tbnEdit = new System.Windows.Forms.ToolBarButton();
            this.tbnDelete = new System.Windows.Forms.ToolBarButton();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbnFont = new System.Windows.Forms.ToolBarButton();
            this.tbnPrint = new System.Windows.Forms.ToolBarButton();
            this.tbnExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tbnQuery
            // 
            this.tbnQuery.ImageIndex = 2;
            this.tbnQuery.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnQuery.Text = "查询";
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
                                                                                        this.tbnFont,
                                                                                        this.tbnPrint,
                                                                                        this.tbnExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(608, 41);
            this.toolBar1.TabIndex = 13;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
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
            this.panel1.Size = new System.Drawing.Size(264, 356);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtBegin);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 136);
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
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(168, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 32);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "查询";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(264, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 356);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(267, 41);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(341, 356);
            this.m_dataGrid.TabIndex = 19;
            // 
            // frmFactoryDatas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(608, 397);
            this.Controls.Add(this.m_dataGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmFactoryDatas";
            this.Text = "frmFactoryDatas";
            this.Load += new System.EventHandler(this.frmFactoryDatas_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFactoryDatas_Load(object sender, System.EventArgs e)
        {
            dtBegin.Value=dtEnd.Value.AddDays(-1);
            //			this.toolBar1.Buttons[3].Pushed=true;
            InitQueryBar();
            m_Begin=dtBegin.Value.Date;
            m_End=dtEnd.Value.Date;
            con=new DBcon();
            InitializeGridTitle();
            LoadDatas(m_Begin,m_End);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitQueryBar()
        {
            this.panel1.Visible =false;
            this.splitter1.Visible=false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        private void LoadDatas(DateTime Begin,DateTime End)
        {
            try
            {
                string str=sqlStr(Begin,End);
                SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                ds=new DataSet();
                da.Fill(ds,"factory");
                m_dataGrid.DataSource=ds.Tables["factory"];
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据读取失败!", ex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeGridTitle()
        {
            DataGridTableStyle tbs= new DataGridTableStyle();
            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
            clm.MappingName="id";
            clm.HeaderText="编号";
            clm.Width=60;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="time";
            clm.HeaderText="时间";
            clm.Width=150;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="GiveTemp";
            clm.HeaderText="供水平均温度"+"\n(C)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="BackTemp";
            clm.HeaderText="回水平均温度"+"\n(C)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="GiveWat";
            clm.HeaderText="送水流量"+"\n(T)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="BackWat";
            clm.HeaderText="回水流量"+"\n(T)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);
			
            clm=new DataGridTextBoxColumn();
            clm.MappingName="AddWat";
            clm.HeaderText="补水量"+"\n(T)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="MissHeat";
            clm.HeaderText="耗热量"+"\n(GJ)";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            tbs.MappingName ="factory";
            this.m_dataGrid.TableStyles.Add(tbs);
            m_dataGrid.HeaderFont=new Font("Arial",15);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        private string sqlStr(DateTime Begin,DateTime End)
        {
            string str="select * from tbl_factoryDatas where time between '";
            str=str+Begin.Date;
            str=str+"' and '";
            str=str+End.Date;
            str=str+"' order by time desc";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Add()
        {
            frmFactoryDatasItem f=new frmFactoryDatasItem();
            if (DialogResult.OK==f.ShowDialog())
            {
                m_dataGrid.TableStyles.Clear();
                m_dataGrid.DataSource=null;
                InitializeGridTitle();
                LoadDatas(m_Begin,m_End);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Edit()
        {
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
            frmFactoryDatasItem f=new frmFactoryDatasItem(id);
            if (DialogResult.OK==f.ShowDialog())
            {
                m_dataGrid.TableStyles.Clear();
                m_dataGrid.DataSource=null;
                InitializeGridTitle();
                LoadDatas(m_Begin,m_End);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            try
            {
                dt=ds.Tables["factory"];
                RemoveID();
                InputExlPrint pnt=new InputExlPrint(m_Begin,m_End,dt);
                LoadDatas(m_Begin,m_End);
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据打印失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据打印失败!", ex );
            }
        }

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
            SqlCommand sqlCmd=new SqlCommand("DELETE FROM tbl_factoryDatas WHERE ID=" + id,con.GetConnection());
            sqlCmd.ExecuteNonQuery();
            sqlCmd.Dispose();
            m_dataGrid.TableStyles.Clear();
            m_dataGrid.DataSource=null;
            InitializeGridTitle();
            LoadDatas(m_Begin,m_End);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blnShow"></param>
        private void ShowQueryBar(bool blnShow)
        {
            if(blnShow)
            {
                this.panel1.Visible=true;
                this.splitter1.Visible=true;
            }
            else
            {
                this.panel1.Visible=!panel1.Visible;
                this.splitter1.Visible=!splitter1.Visible;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RemoveID()
        {
            if(dt!=null)
            {
                DataColumnCollection cols=dt.Columns;
                if(cols.Contains("id"))
                    if(cols.CanRemove(cols["id"])) 
                        cols.Remove("id");
            }
			
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool TimeBeginEnd()
        {
            if(dtBegin.Value.Date==dtEnd.Value.Date)
            {
                if(numericUpDown1.Value>=numericUpDown2.Value)
                {
                    MessageBox.Show("时间选择条件无效","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            if(dtBegin.Value.Date>dtEnd.Value.Date)
            {
                MessageBox.Show("时间选择条件无效","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            m_Begin=System.Convert.ToDateTime(dtBegin.Value.ToShortDateString()+" "+numericUpDown1.Value.ToString()+":00:00");
            m_End=System.Convert.ToDateTime(dtEnd.Value.ToShortDateString()+" "+numericUpDown2.Value.ToString()+":00:00");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool NoRecordDataGrid()
        {
            return -1==m_dataGrid.CurrentRowIndex;
        }

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
                    Edit();
                    break; 
                case "删除":
                    Delete();
                    break; 
                case "查询":
                    ShowQueryBar(toolBar1.Buttons[3].Pushed);
                    break;
                case "打印":
                    Print();
                    break;
                case "退出":
                    this.Close();
                    break;
                case "字体":
                    ChangeFont();
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(TimeBeginEnd())
            {
                m_dataGrid.TableStyles.Clear();
                m_dataGrid.DataSource=null;
                InitializeGridTitle();
                LoadDatas(m_Begin,m_End);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        
        }
    }
}
