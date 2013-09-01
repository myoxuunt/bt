using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace btGRMain.User
{
    /// <summary>
    /// frmUserItem 的摘要说明。
    /// </summary>
    public class frmUserItem : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private bool   m_blnEdit;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtPwd2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckedListBox cklPurview;
        private string m_strEditUser;
        private System.Windows.Forms.CheckBox checkBox1;
        private SortedList m_FunName2FunID;

        public frmUserItem()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            m_blnEdit=false;
        }
        public frmUserItem(string EditUser)
        {
			
            InitializeComponent();
            m_blnEdit=true;
            m_strEditUser=EditUser;
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPwd2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cklPurview = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名：";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(116, 8);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(252, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(116, 40);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(252, 21);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // txtPwd2
            // 
            this.txtPwd2.Location = new System.Drawing.Point(116, 72);
            this.txtPwd2.Name = "txtPwd2";
            this.txtPwd2.PasswordChar = '*';
            this.txtPwd2.Size = new System.Drawing.Size(252, 21);
            this.txtPwd2.TabIndex = 5;
            this.txtPwd2.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.TabIndex = 4;
            this.label3.Text = "确认密码：";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(116, 104);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(252, 76);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.TabIndex = 6;
            this.label4.Text = "备注：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 192);
            this.label5.Name = "label5";
            this.label5.TabIndex = 8;
            this.label5.Text = "权限：";
            // 
            // cklPurview
            // 
            this.cklPurview.Location = new System.Drawing.Point(116, 192);
            this.cklPurview.Name = "cklPurview";
            this.cklPurview.Size = new System.Drawing.Size(252, 148);
            this.cklPurview.TabIndex = 9;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(204, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(284, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(120, 344);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 20);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "  用户权限全选";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmUserItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(376, 411);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cklPurview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPwd2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserItem";
            this.Text = "frmUserItem";
            this.Load += new System.EventHandler(this.frmUserItem_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void frmUserItem_Load(object sender, System.EventArgs e)
        {
            m_FunName2FunID = new SortedList();
            ReadFunction();
            if(m_blnEdit)
            {
                Text = "编辑用户";
                ReadEditUserInfo();
            }
            else
            {
                Text = "新增用户";
            }
			
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if(!Check()) return ;
            if(m_blnEdit)	
                UpdateRecord();
            else 
                AddRecord();
            DialogResult =DialogResult.OK;
            Close();
        }

        private void AddRecord()
        {
            try
            {
                DBcon con = new DBcon();
                SqlCommand cmd= new SqlCommand("UserAdd",con.GetConnection());
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_Name",txtUserName.Text.Trim());
                cmd.Parameters.Add("@p_Password",txtPwd.Text);
                cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
                SqlDataReader dr=cmd.ExecuteReader();
                if(!dr.Read())
                {
                    dr.Close();
                    return;
                }
                string UserID=dr["ID"].ToString().Trim();
                int intUserID=Convert.ToInt32(UserID);
                dr.Close();
                cmd.Dispose();

                for(int i=0;i<cklPurview.Items.Count;i++)
                {
                    if(cklPurview.GetItemChecked(i))
                    {
                        int intFunID=Convert.ToInt32(m_FunName2FunID[cklPurview.Items[i]].ToString());
                        cmd= new SqlCommand("UserFunctionAdd",con.GetConnection());
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.Add("@p_UserID",intUserID);
                        cmd.Parameters.Add("@p_FunctionID",intFunID);
                        cmd.ExecuteNonQuery ();
                        cmd.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("添加用户失败！");
                ExceptionHandler.Handle("添加用户失败！" , ex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateRecord()
        {
            try
            {
                DBcon con = new DBcon();
                SqlCommand cmd= new SqlCommand("UserUpdate",con.GetConnection());
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.Add("@p_EditName",m_strEditUser);
                cmd.Parameters.Add("@p_Name",txtUserName.Text.Trim());
                cmd.Parameters.Add("@p_Password",txtPwd.Text);
                cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
                SqlDataReader dr=cmd.ExecuteReader();
                if(!dr.Read())
                {
                    dr.Close();
                    return;
                }
                string UserID=dr["ID"].ToString().Trim();
                int intUserID=Convert.ToInt32(UserID);
                dr.Close();
                cmd.Dispose();

                //delete old funID
                cmd = new SqlCommand("DELETE FROM WUserFunction WHERE UserID="+intUserID,con.GetConnection());
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                for(int i=0;i<cklPurview.Items.Count;i++)
                {
                    if(cklPurview.GetItemChecked(i))
                    {
                        int intFunID=Convert.ToInt32(m_FunName2FunID[cklPurview.Items[i]].ToString());
                        //add userid -> codeID to UserFunction
                        cmd= new SqlCommand("UserFunctionAdd",con.GetConnection());
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.Add("@p_UserID",intUserID);
                        cmd.Parameters.Add("@p_FunctionID",intFunID);
                        cmd.ExecuteNonQuery ();
                        cmd.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("编辑用户失败！");
                ExceptionHandler.Handle("编辑用户失败！", ex );
            }
			
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        private bool UserNameExist(string UserName)
        {
            DBcon con = new DBcon();
            SqlCommand cmd= new SqlCommand("SELECT * FROM tbWUser WHERE Name='"+UserName.Trim()+"'",con.GetConnection()); 
            SqlDataReader dr=cmd.ExecuteReader();
            bool bln=dr.Read();
            dr.Close();
			
			
            if(bln ) 
                return true;
            else 
                return false;			
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            if(""==txtUserName.Text.Trim())
            {
                MessageBox.Show("请填写用户名称","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
                txtUserName.Focus();
                txtUserName.SelectAll();
                goto PRO_FALSE;
            }

            if(txtPwd.Text != txtPwd2.Text)
            {
                MessageBox.Show("确认密码不正确","错误",MessageBoxButtons.OK , MessageBoxIcon.Error);
                txtPwd.Focus();
                txtPwd.SelectAll();
                goto PRO_FALSE;
            }

            if(!m_blnEdit || (m_blnEdit && txtUserName.Text.Trim().ToUpper()!=m_strEditUser.Trim().ToUpper()))		
            {
                if(UserNameExist(txtUserName.Text.Trim()))
                {
                    MessageBox.Show("用户名已存在!","错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                    goto PRO_FALSE;
                }					
            }
            return true;

            PRO_FALSE:
                return false;

        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadFunction()
        {
            try
            {
                DBcon con =new DBcon();
                SqlCommand cmd= new SqlCommand("SELECT * FROM tbWFunction ORDER BY ID",con.GetConnection());
                SqlDataReader dr= cmd.ExecuteReader();
                while(dr.Read())
                {
                    string FunName=dr["Name"].ToString().Trim();
                    cklPurview.Items.Add(FunName);
                    m_FunName2FunID.Add(FunName, (int)dr["id"]);
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadEditUserInfo()
        {
            try
            {
                txtUserName.Text= m_strEditUser;
                DBcon con = new DBcon();
                SqlCommand cmd= new SqlCommand("SELECT * FROM tbWUser WHERE Name='"+m_strEditUser+"'",con.GetConnection());
                SqlDataReader dr= cmd.ExecuteReader();
                int intUserID;
                if(!dr.Read())
                {
                    dr.Close();
                    cmd.Dispose();
                    return ;
                }
                intUserID=Convert.ToInt32(dr["ID"]);
                txtPwd.Text =dr["Password"].ToString();
                txtPwd2.Text =txtPwd.Text;
                txtDescription.Text = dr["Description"].ToString().Trim();
                dr.Close();
                cmd.Dispose();

                cmd=new SqlCommand("SELECT * FROM WUserFunction WHERE UserID="+intUserID,con.GetConnection());
                dr=cmd.ExecuteReader();
                ArrayList arrFun = new ArrayList();
                while(dr.Read())
                {
                    arrFun.Add(dr["FunctionID"]);
                }
                dr.Close();
                cmd.Dispose();

                for(int i=0;i<arrFun.Count;i++)
                {
                    SetItemCheckedByFunID((int)arrFun[i]);
                }
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show(ex.ToString());
                ExceptionHandler.Handle( ex );
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="FunID"></param>
        private void SetItemCheckedByFunID(int FunID)
        {
            try
            {
                int idx=m_FunName2FunID.IndexOfValue((object)FunID);
                string strFunName=m_FunName2FunID.GetKey(idx).ToString().Trim();

                int idxOfCklItem=cklPurview.Items.IndexOf(strFunName);
                cklPurview.SetItemChecked(idxOfCklItem,true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            cklPurview.Focus();
            if(checkBox1.Checked==true)
            {
                for(int i=0;i<cklPurview.Items.Count;i++)
                {
                    cklPurview.SetItemChecked(i,true);
                }
            }
            else
            {
                for(int i=0;i<cklPurview.Items.Count;i++)
                {
                    cklPurview.SetItemChecked(i,false);
                }
			
            }
        }
    }
}
