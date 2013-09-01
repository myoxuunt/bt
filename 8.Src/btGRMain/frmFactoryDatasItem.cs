using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Utilities;
namespace btGRMain
{
    /// <summary>
    /// frmFactoryDatasItem 的摘要说明。
    /// </summary>
    public class frmFactoryDatasItem : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private int m_DataID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private bool m_bolEdit=false;
        private Decimal GiveT;
        private Decimal BackT;
        private Decimal GiveW;
        private Decimal BackW;
        private Decimal AddW;
        private Decimal MissH;
        private System.Windows.Forms.TextBox txtGiveT;
        private System.Windows.Forms.TextBox txtBackT;
        private System.Windows.Forms.TextBox txtGiveW;
        private System.Windows.Forms.TextBox txtBackW;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private DBcon con=null;

        public frmFactoryDatasItem()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public frmFactoryDatasItem(int id)
        {
            InitializeComponent();
            m_DataID=id;
            m_bolEdit=true;
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
            this.label11 = new System.Windows.Forms.Label();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiveT = new System.Windows.Forms.TextBox();
            this.txtBackT = new System.Windows.Forms.TextBox();
            this.txtGiveW = new System.Windows.Forms.TextBox();
            this.txtBackW = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "供水流量：";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(112, 16);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(192, 21);
            this.dtDate.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "回水平均温度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "供水平均温度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "回水流量：";
            // 
            // txtGiveT
            // 
            this.txtGiveT.Location = new System.Drawing.Point(112, 56);
            this.txtGiveT.Name = "txtGiveT";
            this.txtGiveT.Size = new System.Drawing.Size(192, 21);
            this.txtGiveT.TabIndex = 44;
            this.txtGiveT.Text = "";
            // 
            // txtBackT
            // 
            this.txtBackT.Location = new System.Drawing.Point(112, 96);
            this.txtBackT.Name = "txtBackT";
            this.txtBackT.Size = new System.Drawing.Size(192, 21);
            this.txtBackT.TabIndex = 47;
            this.txtBackT.Text = "";
            // 
            // txtGiveW
            // 
            this.txtGiveW.Location = new System.Drawing.Point(112, 136);
            this.txtGiveW.Name = "txtGiveW";
            this.txtGiveW.Size = new System.Drawing.Size(192, 21);
            this.txtGiveW.TabIndex = 51;
            this.txtGiveW.Text = "";
            // 
            // txtBackW
            // 
            this.txtBackW.Location = new System.Drawing.Point(112, 176);
            this.txtBackW.Name = "txtBackW";
            this.txtBackW.Size = new System.Drawing.Size(192, 21);
            this.txtBackW.TabIndex = 52;
            this.txtBackW.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(232, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(160, 224);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(72, 24);
            this.btnYes.TabIndex = 53;
            this.btnYes.Text = "确定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // frmFactoryDatasItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(320, 271);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.txtBackW);
            this.Controls.Add(this.txtGiveW);
            this.Controls.Add(this.txtBackT);
            this.Controls.Add(this.txtGiveT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFactoryDatasItem";
            this.Text = "frmFactoryDatasItem";
            this.Load += new System.EventHandler(this.frmFactoryDatasItem_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmFactoryDatasItem_Load(object sender, System.EventArgs e)
        {
            if(m_bolEdit)
            {
                this.Text="编辑数据";
                EditLoad();
            }
            else
            {
                this.Text="添加数据";
            }
            con=new DBcon();
        }

        private bool CheckDatas()
        {
            try
            {
                if(dtDate.Value.ToShortDateString()=="")
                {
                    MessageBox.Show("请选择时间","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
                    dtDate.Focus();
                    return false;
                }
                if(txtGiveT.Text.Trim()=="")
                    GiveT=0;
                else
                    GiveT=System.Convert.ToDecimal(txtGiveT.Text.Trim());
                if(txtBackT.Text.Trim()=="")
                    BackT=0;
                else
                    BackT=System.Convert.ToDecimal(txtBackT.Text.Trim());
                if(txtGiveW.Text.Trim()=="")
                    GiveW=0;
                else
                    GiveW=System.Convert.ToDecimal(txtGiveW.Text.Trim());
                if(txtBackW.Text.Trim()=="")
                    BackW=0;
                else
                    BackW=System.Convert.ToDecimal(txtBackW.Text.Trim());
                return true;
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("输入数据格式不正确");
                ExceptionHandler.Handle("输入数据格式不正确", ex );
                return false;
            }
        }

        private void EditLoad()
        {
            DateTime dt;
            try
            {
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("select * from tbl_factorydatas where id=@m_id",con.GetConnection());
                cmd.Parameters.Add("@m_id",m_DataID);
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    dt=System.Convert.ToDateTime(dr["time"]);
                    dtDate.Value=dt.Date;
                    txtBackT.Text=dr["BackTemp"].ToString();
                    txtGiveT.Text=dr["GiveTemp"].ToString();
                    txtBackW.Text=dr["BackWat"].ToString();
                    txtGiveW.Text=dr["GiveWat"].ToString();
                }
			
                dr.Close();
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据读取失败!", ex );

            }
        }

        private void UpdateRecord()
        {
            try
            {
                Decimal i=System.Convert.ToDecimal(4.1868);
                AddW=GiveW-BackW;
                MissH=Math.Round((GiveW*(GiveT-BackT)+(GiveW-BackW)*BackT)*i/1000,2);
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("addPumpUpdate",con.GetConnection());
                cmd.CommandType=CommandType.StoredProcedure;
				
                cmd.Parameters.Add("@p_ID",m_DataID);
                cmd.Parameters.Add("@p_Time",dtDate.Value.Date);
                cmd.Parameters.Add("@p_GiveTemp",GiveT);
                cmd.Parameters.Add("@p_BackTemp",BackT);
                cmd.Parameters.Add("@p_GiveWat",GiveW);
                cmd.Parameters.Add("@p_BackWat",BackW);
                cmd.Parameters.Add("@p_AddWat",AddW);
                cmd.Parameters.Add("@p_MissHeat",MissH);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据编辑失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据编辑失败!", ex );
            }
        }

        private void AddRecord()
        {
            try
            {
                Decimal i=System.Convert.ToDecimal(4.1868);
                AddW=GiveW-BackW;
                MissH=Math.Round((GiveW*(GiveT-BackT)+(GiveW-BackW)*BackT)*i/1000,2);
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("addfactoryDatas",con.GetConnection());
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_Time",dtDate.Value.Date);
                cmd.Parameters.Add("@p_GiveTemp",GiveT);
                cmd.Parameters.Add("@p_BackTemp",BackT);
                cmd.Parameters.Add("@p_GiveWat",GiveW);
                cmd.Parameters.Add("@p_BackWat",BackW);
                cmd.Parameters.Add("@p_AddWat",AddW);
                cmd.Parameters.Add("@p_MissHeat",MissH);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据添加失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据添加失败!", ex );
            }
        }

        private void txtBackT_TextChanged(object sender, System.EventArgs e)
        {
		
        }

        private void btnYes_Click(object sender, System.EventArgs e)
        {
            if(!CheckDatas())
                return;
            if(m_bolEdit)
                UpdateRecord();
            else
                AddRecord();
            DialogResult =DialogResult.OK ;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click_1(object sender, System.EventArgs e)
        {
		
        }

        private void btnCancel_Click_1(object sender, System.EventArgs e)
        {
		
        }
    }
}
