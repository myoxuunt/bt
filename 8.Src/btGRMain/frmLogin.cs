using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using Utilities;

namespace btGRMain
{
    /// <summary>
    /// frmLogin 的摘要说明。
    /// </summary>
    public class frmLogin : System.Windows.Forms.Form
    {
        public static bool m_Login=false;
        public static int m_UserID=0;
        public static string m_UserName=null;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmLogin()
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 263);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(414, 232);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(72, 24);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click_1);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(342, 232);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(72, 24);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "登录";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click_1);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(304, 156);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(184, 21);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(304, 192);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(184, 21);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Text = "";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(498, 263);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void btnYes_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                string str=null;
                XmlDocument XDoc=new XmlDocument();
                XDoc.Load("Server.xml");
                XmlNode XNode=XDoc.DocumentElement.SelectSingleNode("./SqlCon");
                for(int i=0;i<XNode.ChildNodes.Count;i++)
                {
                    str=str+XNode.ChildNodes[i].Name;
                    str=str+"=";
                    str=str+XNode.ChildNodes[i].InnerText.Trim();
                    str=str+";";
                }
                SqlConnection sCon=new  SqlConnection(str);
			
				
                sCon.Open();
			
                string strUser="select * from tbWUser where name='"+txtUser.Text.Trim()+"'";
                SqlCommand cmd=new SqlCommand(strUser,sCon);
                SqlDataReader dr=cmd.ExecuteReader();
                if(!dr.Read())
                {
                    MessageBox.Show("用户不存在！","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
                    txtUser.SelectAll();
                    txtUser.Focus();
                    dr.Close();
                    return ;
                }
                string strPwd=dr["password"].ToString();
                int UserID= Convert.ToInt32(dr["ID"]);
                dr.Close();
                if(strPwd!=txtPwd.Text.Trim())
                {
                    MessageBox.Show("密码无效！","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
                    txtPwd.Clear();
                    txtPwd.Focus();
                    return ;
                }
                m_UserName=txtUser.Text.Trim();
                m_UserID=UserID;
                m_Login=true;
                this.Close();
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("连接失败，请测试连接!","连接错误",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                ExceptionHandler.Handle("连接失败，请测试连接!", ex );
                return ;
            }
        }


        private void btnNo_Click_1(object sender, System.EventArgs e)
        {
            m_Login=false;
            this.Close();
        }

        private void frmLogin_Load(object sender, System.EventArgs e)
        {
            this.txtUser.Focus();
        }
        //		private SqlConnection GetCon()
        //		{
        //			
        //		}
    }
}
