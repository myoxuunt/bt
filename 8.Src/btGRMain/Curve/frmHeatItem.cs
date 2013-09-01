using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace btGRMain.Curve
{
	/// <summary>
	/// frmHeatItem 的摘要说明。
	/// </summary>
	public class frmHeatItem : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private DBcon con=null;
        private System.Windows.Forms.DataGrid m_dataGrid;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private DataTable dt=null;
        private DataSet ds=null;

		public frmHeatItem()
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
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(3, 17);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.Size = new System.Drawing.Size(290, 316);
            this.m_dataGrid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_dataGrid);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 336);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采暖规范标准参数";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(216, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(144, 360);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(72, 24);
            this.btnYes.TabIndex = 39;
            this.btnYes.Text = "确定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // frmHeatItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(312, 397);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmHeatItem";
            this.Text = "参数编辑";
            this.Load += new System.EventHandler(this.frmHeatItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {
        
        }

        private void frmHeatItem_Load(object sender, System.EventArgs e)
        {
            this.Text="参数编辑";
            con=new DBcon();
            InitializeGridTable();
            LoadDatas();
        }

        private void InitializeGridTable()
        {
            DataGridTableStyle tbs=new DataGridTableStyle(); 
            DataGridTextBoxColumn clm=new DataGridTextBoxColumn();
            
//            clm.MappingName="ID";
//            clm.HeaderText="编号";
//            clm.Width=40;
//            tbs.GridColumnStyles.Add(clm);
	
            clm=new DataGridTextBoxColumn();
            clm.MappingName="OutTemp";
            clm.HeaderText="室外温度"+"("+"C"+")";
            clm.Width=100;
            tbs.GridColumnStyles.Add(clm);
				
            clm=new DataGridTextBoxColumn();
            clm.MappingName="HeatIndex";
            clm.HeaderText="单位面积热负荷"+" ("+"W/m2"+")";
            clm.Width=120;
            tbs.GridColumnStyles.Add(clm);

            tbs.MappingName ="HeatIndex";
            m_dataGrid.TableStyles.Add(tbs);
            m_dataGrid.HeaderFont=new Font("Arial",15);
        }

        private void LoadDatas()
        {
            try
            {
                string str="select * from tbl_HeatIndex order by outTemp desc";
                SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                ds=new DataSet();
                da.Fill(ds,"HeatIndex");
                da.Dispose();
                dt=ds.Tables["HeatIndex"];
                m_dataGrid.DataSource=dt;
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("参数读取错误");
                ExceptionHandler.Handle("参数读取错误", ex );
            }
        }

        private void EditDatas()
        {
            try
            {
                string str="select * from tbl_HeatIndex order by outTemp desc";
                SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                ds=new DataSet();
                da.Fill(ds,"HeatIndex");
                da.Dispose();
                DataTable EditDT=(DataTable)m_dataGrid.DataSource;
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    for(int j=0;j<EditDT.Rows.Count;j++)
                    {
                        string ss=EditDT.Rows[j]["outTemp"].ToString();
                        if(System.Convert.ToDecimal(EditDT.Rows[j]["outTemp"])==System.Convert.ToDecimal(ds.Tables["HeatIndex"].Rows[i]["outTemp"]))                
                        {
                            Decimal aa=System.Convert.ToDecimal(EditDT.Rows[j]["HeatIndex"]);
                            Decimal bb=System.Convert.ToDecimal(ds.Tables["HeatIndex"].Rows[i]["HeatIndex"]);
                            
                           if(System.Convert.ToDecimal(EditDT.Rows[j]["HeatIndex"])==System.Convert.ToDecimal(ds.Tables["HeatIndex"].Rows[i]["HeatIndex"]))
                               continue;
                            string strEdit="upDate tbl_HeatIndex set HeatIndex="+System.Convert.ToDecimal(EditDT.Rows[j]["HeatIndex"])+" where outTemp="+System.Convert.ToDecimal(ds.Tables["HeatIndex"].Rows[i]["outTemp"]);
                            SqlCommand cmd=new SqlCommand(strEdit,con.GetConnection());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据录入错误，请检查数据格式是否输入错误");
                ExceptionHandler.Handle("数据录入错误，请检查数据格式是否输入错误", ex);
            }
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            EditDatas();
            LoadDatas();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
	}
}
