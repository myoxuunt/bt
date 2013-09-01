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
    /// frmRMDatas 的摘要说明。
    /// </summary>
    public class frmRMDatas : System.Windows.Forms.Form
    {
        #region Members
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBarButton tbnExit;
        private System.Windows.Forms.ToolBarButton tbnPrint;
        private System.Windows.Forms.ToolBarButton tbnQuery;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private DataTable dtRm=null;
        private DateTime m_dtime;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labAddWat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labMissHeat;
        private System.Windows.Forms.ToolBarButton tbnFont;
        private DBcon con=null;
        #endregion //Members

        #region frmRMDatas
        public frmRMDatas()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }
        #endregion //frmRMDatas

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRMDatas));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbnExit = new System.Windows.Forms.ToolBarButton();
            this.tbnPrint = new System.Windows.Forms.ToolBarButton();
            this.tbnQuery = new System.Windows.Forms.ToolBarButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labMissHeat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labAddWat = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbnFont = new System.Windows.Forms.ToolBarButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbnExit
            // 
            this.tbnExit.ImageIndex = 7;
            this.tbnExit.Text = "退出";
            // 
            // tbnPrint
            // 
            this.tbnPrint.ImageIndex = 5;
            this.tbnPrint.Text = "打印";
            // 
            // tbnQuery
            // 
            this.tbnQuery.ImageIndex = 2;
            this.tbnQuery.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
            this.tbnQuery.Text = "查询";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 436);
            this.panel1.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labMissHeat);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labAddWat);
            this.groupBox2.Location = new System.Drawing.Point(8, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 128);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计总量";
            this.groupBox2.Visible = false;
            // 
            // labMissHeat
            // 
            this.labMissHeat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labMissHeat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labMissHeat.Location = new System.Drawing.Point(84, 84);
            this.labMissHeat.Name = "labMissHeat";
            this.labMissHeat.Size = new System.Drawing.Size(164, 24);
            this.labMissHeat.TabIndex = 16;
            this.labMissHeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "总耗热量：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "总补水量：";
            // 
            // labAddWat
            // 
            this.labAddWat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labAddWat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labAddWat.Location = new System.Drawing.Point(84, 28);
            this.labAddWat.Name = "labAddWat";
            this.labAddWat.Size = new System.Drawing.Size(164, 24);
            this.labAddWat.TabIndex = 0;
            this.labAddWat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 96);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计分析条件设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "时";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(212, 32);
            this.numericUpDown1.Maximum = new System.Decimal(new int[] {
                                                                           23,
                                                                           0,
                                                                           0,
                                                                           0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 21);
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
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "站点名称：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "选择日期：";
            // 
            // cmbStation
            // 
            this.cmbStation.Location = new System.Drawing.Point(84, 68);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(164, 20);
            this.cmbStation.TabIndex = 10;
            this.cmbStation.Visible = false;
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(84, 32);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(128, 21);
            this.dtDate.TabIndex = 9;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(176, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 32);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "查询";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbnQuery,
                                                                                        this.tbnFont,
                                                                                        this.tbnPrint,
                                                                                        this.tbnExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(800, 41);
            this.toolBar1.TabIndex = 13;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbnFont
            // 
            this.tbnFont.ImageIndex = 8;
            this.tbnFont.Text = "字体";
            this.tbnFont.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(288, 41);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 436);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(291, 41);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(509, 436);
            this.m_dataGrid.TabIndex = 19;
            // 
            // frmRMDatas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.m_dataGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmRMDatas";
            this.Text = "frmRMDatas";
            this.Load += new System.EventHandler(this.frmRMDatas_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region frmRMDatas_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRMDatas_Load(object sender, System.EventArgs e)
        {
            con=new DBcon();
            toolBar1.Buttons[0].Pushed=true;
            cmbStationLoad();
            DataGridTitle();
        }
        #endregion //frmRMDatas_Load

        #region cmbStationLoad
        /// <summary>
        /// 
        /// </summary>
        private void cmbStationLoad()
        {
            try
            {
                cmbStation.Items.Add("<全部站>");
                string str="select name from tbl_gprs_station order by team";
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
                //MessageBox.Show("站点信息加载失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("站点信息加载失败!", ex );
            }
        }
        #endregion //cmbStationLoad

        #region RemoveColumns
        /// <summary>
        /// remove col: heatArea, name1.
        /// </summary>
        /// 
        /// <param name="dt"></param>
        private void RemoveColumns(DataTable dt)
        {
            if(dt!=null)
            {
                DataColumnCollection cols=dt.Columns;
                if(cols.Contains("heatArea"))
                    if(cols.CanRemove(cols["heatArea"])) 
                        cols.Remove("heatArea");
                if(cols.Contains("Name1"))
                    if(cols.CanRemove(cols["Name1"])) 
                        cols.Remove("Name1");
            }
        }
        #endregion //RemoveColumns

        #region LoadDatas
        /// <summary>
        /// 
        /// </summary>
        private void LoadDatas()
        {
            try
            {
                m_dtime=System.Convert.ToDateTime(dtDate.Value.ToShortDateString()+" "+numericUpDown1.Value.ToString()+":00:00");
                RMStatistics RmDatas=new RMStatistics(m_dtime,cmbStation.Text.Trim());
                dtRm=RmDatas.GetRMDataTable();
                //			DataView dv=new DataView(dtRm);
                //			dv.Sort="team desc";
                //			m_dataGrid.DataSource=dv;

                DataView dv = new DataView( dtRm,"", "teamorder, name",DataViewRowState.CurrentRows ); 
                //				m_dataGrid.DataSource=dtRm;
                m_dataGrid.DataSource = dv;
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据读取失败!", ex );
            }
        }
        #endregion //LoadDatas

        #region StatisticAll
        /// <summary>
        /// 
        /// </summary>
        private void StatisticAll()
        {
            Decimal all_addWat;
            Decimal all_MissHeat;
            if(dtRm.Rows.Count==0)
                return;
            else
            {
                all_addWat=System.Convert.ToDecimal(dtRm.Rows[0]["AddWat"]);
                all_MissHeat=System.Convert.ToDecimal(dtRm.Rows[0]["DayHeat"]);
                for(int i=1;i<dtRm.Rows.Count;i++)
                {
                    all_addWat=all_addWat+System.Convert.ToDecimal(dtRm.Rows[i]["AddWat"]);
                    all_MissHeat=all_MissHeat+System.Convert.ToDecimal(dtRm.Rows[i]["DayHeat"]);
                }
                labAddWat.Text=all_addWat.ToString();
                labMissHeat.Text=all_MissHeat.ToString();
            }
        }
        #endregion //StatisticAll

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

        #region ShowQueryBar
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
                this.panel1.Visible=false;
                this.splitter1.Visible=false;
            }
        }
        #endregion //ShowQueryBar

        #region DataGridTitle
        /// <summary>
        /// 
        /// </summary>
        private void DataGridTitle()
        {
            DataGridTableStyle tbs=new DataGridTableStyle(); 
            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="name";
            clm.HeaderText="站名称";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="team";
            clm.HeaderText="所属班组";
            clm.Width=100;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="heatArea";
            clm.HeaderText="供热面积"+"\n("+"万平方米"+")";
            clm.Width=100;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneGivePress";
            clm.HeaderText="一次供水压力"+"\n("+"Mpa"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneBackPress";
            clm.HeaderText="一次回水压力"+"\n("+"Mpa"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneGiveTemp";
            clm.HeaderText="一次供水温度"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneBackTemp";
            clm.HeaderText="一次回水温度"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneTempCha";
            clm.HeaderText="一次供回水温差"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="oneAccum";
            clm.HeaderText="流量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="YestOneAccum";
            clm.HeaderText="前日流量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="twoGivePress";
            clm.HeaderText="二次供水压力"+"\n("+"Mpa"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="twoBackPress";
            clm.HeaderText="二次回水压力"+"\n("+"Mpa"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="twoGiveTemp";
            clm.HeaderText="二次供水温度"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="twoBackTemp";
            clm.HeaderText="二次回水温度"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="addPumpValue";
            clm.HeaderText="自来水流量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="YestAddPumpValue";
            clm.HeaderText="前日自来水流量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="AddWat";
            clm.HeaderText="补水量"+"\n("+"T"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="MissWat";
            clm.HeaderText="失水率";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="DayHeat";
            clm.HeaderText="日耗热量"+"\n("+"GJ"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="AvgHeat";
            clm.HeaderText="每万平方米耗热量"+"\n("+"C"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            clm=new DataGridTextBoxColumn();
            clm.MappingName="name1";
            clm.HeaderText="站名称";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            tbs.MappingName ="RMDayReport";
            
            m_dataGrid.TableStyles.Add(tbs);
            m_dataGrid.HeaderFont=new Font("Arial",15);
        }
        #endregion //DataGridTitle

        #region GetDataGridRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridRow"></param>
        /// <returns></returns>
        private object [] GetDataGridRow ( int dataGridRow )
        {
            const int TOTAL_COLUMN = 21;
            object[] objs = new object[ TOTAL_COLUMN ];
            for ( int colIndex=0; colIndex < TOTAL_COLUMN ; colIndex ++)
            {
                objs[colIndex] = m_dataGrid[ dataGridRow, colIndex ];
            }
            return objs;
        }
        #endregion //GetDataGridRow

        #region Print
        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            DataTable tbl =dtRm.Clone();
            tbl.Rows.Clear();

            for( int i=0; i<dtRm.Rows.Count; i++ )
            {
                object[] objs = GetDataGridRow( i );
                tbl.Rows.Add( objs );
            }
            // 2007.03.28 for order by team
            //
            //RemoveColumns(dtRm);
            //InputExlPrint pnt=new InputExlPrint(dtRm,m_dtime,this.labAddWat.Text,this.labMissHeat.Text);
            //LoadDatas();
            RemoveColumns( tbl );
            InputExlPrint pnt = new InputExlPrint( 
                tbl, 
                m_dtime, 
                labAddWat.Text, 
                labMissHeat.Text 
                );
        }
        #endregion //Print

        #region btnOK_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            LoadDatas();
            this.groupBox2.Visible=true;
            StatisticAll();
        }
        #endregion //btnOK_Click

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
                case "打印":
                    Print();
                    break;
                case "查询":
                    ShowQueryBar(toolBar1.Buttons[0].Pushed);
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
    }
}
