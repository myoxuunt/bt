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
    /// frmteamAddPump 的摘要说明。
    /// </summary>
    public class frmteamAddPump : System.Windows.Forms.Form
    {
        #region Members
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTeam;
        private DBcon con=null;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private DataTable dt;
        private System.Data.DataView dataView1;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion //

        #region frmteamAddPump
        /// <summary>
        /// 
        /// </summary>
        public frmteamAddPump()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.dataView1 = new System.Data.DataView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 376);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(184, 376);
            this.btnYes.Name = "btnYes";
            this.btnYes.TabIndex = 37;
            this.btnYes.Text = "确定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "时间：";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(104, 16);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(232, 21);
            this.dtDate.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "班组：";
            // 
            // cmbTeam
            // 
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.Location = new System.Drawing.Point(104, 48);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(232, 20);
            this.cmbTeam.Sorted = true;
            this.cmbTeam.TabIndex = 51;
            this.cmbTeam.SelectedIndexChanged += new System.EventHandler(this.cmbTeam_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_dataGrid);
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 288);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据录入";
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(3, 17);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.Size = new System.Drawing.Size(346, 268);
            this.m_dataGrid.TabIndex = 53;
            // 
            // dataView1
            // 
            this.dataView1.AllowNew = false;
            // 
            // frmteamAddPump
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(370, 413);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbTeam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmteamAddPump";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmteamAddPump";
            this.Load += new System.EventHandler(this.frmteamAddPump_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region frmteamAddPump_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmteamAddPump_Load(object sender, System.EventArgs e)
        {
            this.Text="数据添加";
            con=new DBcon();
            LoadTeamName();
            InitializeGridTable();
            LoadDatas();
        }
        #endregion //
		
        #region LoadTeamName
        /// <summary>
        /// 
        /// </summary>
        private void LoadTeamName()
        {
            string str="select team from tbl_gprs_station group by team order by team desc";
            SqlCommand cmd=new SqlCommand(str,con.GetConnection());
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                cmbTeam.Items.Add(dr.GetValue(0).ToString().Trim());
            }
            dr.Close();
            cmbTeam.Text=cmbTeam.Items[0].ToString();
        }
        #endregion //

        #region InitializeGridTable
        /// <summary>
        /// 
        /// </summary>
        private void InitializeGridTable()
        {
            DataGridTableStyle tbs=new DataGridTableStyle(); 
            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="name";
            clm.HeaderText="站名称";
            clm.Width=140;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="addPumpValue";
            clm.HeaderText="自来水表流量"+" ("+"T"+")";
            clm.Width=140;
            tbs.GridColumnStyles.Add(clm);

            tbs.MappingName ="Add_addpumpDatas";
            m_dataGrid.TableStyles.Add(tbs);
            m_dataGrid.HeaderFont=new Font("Arial",15);
        }
        #endregion //

        #region LoadDatas
        /// <summary>
        /// 
        /// </summary>
        private void LoadDatas()
        {
            try
            {
                bool b_Name=false;
                string name;
                dt=CreatTable();
                string teamName=this.cmbTeam.Text.Trim();
                DateTime addTime=this.dtDate.Value.Date;
                string str="select Name from tbl_gprs_station where team='";
                str=str+teamName;
                str=str+"'";

                string str2="select name from v_addPumpdatas where time between '";
                str2=str2+addTime;
                str2=str2+"' and '";
                str2=str2+addTime.AddHours(12);
                str2=str2+"'";
	
                SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                DataSet ds=new DataSet();
                da.Fill(ds,"allName");
                da.Dispose();
                da=new SqlDataAdapter(str2,con.GetConnection());
                da.Fill(ds,"HaveName");
                da.Dispose();
                int z=0;
                for(int i=0;i<ds.Tables["allName"].Rows.Count;i++)
                {
                    for(int j=0;j<ds.Tables["HaveName"].Rows.Count;j++)
                    {
                        if(ds.Tables["HaveName"].Rows[j]["name"].ToString()==ds.Tables["allName"].Rows[i]["name"].ToString())
                        {
                            b_Name=true;
                            break;
                        }
                        else
                            b_Name=false;
                    }
                    if(!b_Name)
                    {
                        name=ds.Tables["allName"].Rows[i]["name"].ToString();
                        DataRow newrow =dt.NewRow();
                        dt.Rows.Add(newrow);
                        dt.Rows[z]["name"]=name;
                        z=z+1;
                    }
                }
                m_dataGrid.DataSource=dt;
//                this.dataView1.Table = dt;
//                dataView1.AllowNew = false;
//                m_dataGrid.DataSource = dataView1;
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据读取错误");
                ExceptionHandler.Handle("数据读取错误", ex );
            }
        }
        #endregion //

        #region InsertDatas
        /// <summary>
        /// 
        /// </summary>
        private void InsertDatas()
        {
            try
            {
                DataTable InsertDT=(DataTable)m_dataGrid.DataSource;
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    for(int j=0;j<InsertDT.Rows.Count;j++)
                    {
                        if(InsertDT.Rows[j]["name"].ToString()==dt.Rows[i]["name"].ToString())
                        {
                            if(InsertDT.Rows[j]["addPumpValue"]!=System.DBNull.Value)
                            {
                                con=new DBcon();
                                SqlCommand cmd=new SqlCommand("addPumpAdd",con.GetConnection());
                                cmd.CommandType=CommandType.StoredProcedure;

                                //cmd.Parameters.Add("@p_grStationID",StationID(InsertDT.Rows[j]["name"].ToString()));
                                string stname = InsertDT.Rows[j]["name"].ToString().Trim();
                                int grstid = GetStationID ( stname );
                                if ( grstid == -1 )
                                {
                                    MessageBox.Show(
                                        "未找到相关站名: " + stname,
                                        "错误",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error 
                                        );
                                    continue;
                                }
                                else
                                {
                                    cmd.Parameters.Add("@p_grStationId",grstid );
                                }

                                cmd.Parameters.Add("@p_Time",dtDate.Value.Date);
                                cmd.Parameters.Add("@p_addPumpValue",System.Convert.ToDecimal(InsertDT.Rows[j]["addPumpValue"]));
                                cmd.Parameters.Add("@p_Description"," ");
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据录入错误，请检查数据格式是否输入错误");
                ExceptionHandler.Handle("数据录入错误，请检查数据格式是否输入错误", ex );
            }
        }
        #endregion //

        //#region StationID
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //private int StationID(string name)
        //{
        //    int sID;
        //    string str="select gprs_station_id,name from tbl_gprs_station";
        //    con=new DBcon();
        //    SqlCommand cmd=new SqlCommand(str,con.GetConnection());
        //    SqlDataReader dr=cmd.ExecuteReader();
        //    while(dr.Read())
        //    {
        //        if(dr.GetValue(1).ToString().Trim()==name)
        //        {
        //            sID=System.Convert.ToInt32(dr.GetValue(0));
        //            dr.Close();
        //            return sID;
        //        }
        //    }
        //    dr.Close();
        //    return 0;
        //}
        //#endregion //

        #region StationID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetStationID(string name)
        {
            string sql = string.Format(
                "select grstation_id from v_gprs_gr_xg where name = '{0}'",
                name
                );

            con=new DBcon();
            SqlCommand cmd=new SqlCommand(sql, con.GetConnection());
            SqlDataReader dr=cmd.ExecuteReader();

            int grstationId = -1;
            while(dr.Read())
            {
                grstationId = int.Parse( dr[0].ToString() );
            }
            dr.Close();
            return grstationId;
        }
        #endregion //StationID

        #region CreatTable
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable CreatTable()
        {
            DataTable dt=new DataTable("Add_addpumpDatas");
            DataColumn dc=new DataColumn();
            dc.ColumnName="name";
            dc.DataType=System.Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc=new DataColumn();
            dc.ColumnName="addPumpValue";
            dc.DataType=System.Type.GetType("System.Decimal");
            dt.Columns.Add(dc);
            return dt;
        }
        #endregion //

        #region cmbTeam_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTeam_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadDatas();
        }
        #endregion //

        #region btnCancel_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult =DialogResult.OK ;
            this.Close();
        }
        #endregion //

        #region btnYes_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, System.EventArgs e)
        {
            InsertDatas();
            LoadDatas();
        }
        #endregion //
    }
}
