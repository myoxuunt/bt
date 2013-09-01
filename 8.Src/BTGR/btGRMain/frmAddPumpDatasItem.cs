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
    /// frmAddPumpDatasItem 的摘要说明。
    /// </summary>
    public class frmAddPumpDatasItem : System.Windows.Forms.Form
    {
        #region Members
        private System.Windows.Forms.ComboBox cmbPoint;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label11;
        private int m_DataID;
        private bool m_bolEdit=false;
        private DBcon con=null;
        private Decimal m_Value;
        private System.Windows.Forms.TextBox txtValue;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion //Members

        #region frmAddPumpDatasItem
        /// <summary>
        /// 
        /// </summary>
        public frmAddPumpDatasItem()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            m_bolEdit=false;

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }
        #endregion //frmAddPumpDatasItem

        #region frmAddPumpDatasItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public frmAddPumpDatasItem(int id)
        {
            InitializeComponent();
            m_DataID=id;
            m_bolEdit=true;
            this.cmbPoint.Enabled = false;
        }
        #endregion //frmAddPumpDatasItem

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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbPoint = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(112, 80);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(232, 21);
            this.txtValue.TabIndex = 21;
            this.txtValue.Text = "";
            // 
            // cmbPoint
            // 
            this.cmbPoint.Location = new System.Drawing.Point(112, 48);
            this.cmbPoint.Name = "cmbPoint";
            this.cmbPoint.Size = new System.Drawing.Size(232, 20);
            this.cmbPoint.TabIndex = 20;
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(112, 16);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(232, 21);
            this.dtDate.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "自来水表流量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "站点：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "时间：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(176, 208);
            this.btnYes.Name = "btnYes";
            this.btnYes.TabIndex = 27;
            this.btnYes.Text = "确定";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(112, 112);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(232, 88);
            this.txtDescription.TabIndex = 26;
            this.txtDescription.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "备注：";
            // 
            // frmAddPumpDatasItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(368, 239);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbPoint);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPumpDatasItem";
            this.Text = "frmAddPumpDatasItem";
            this.Load += new System.EventHandler(this.frmAddPumpDatasItem_Load);
            this.ResumeLayout(false);

        }
        #endregion

        #region InitializeForm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddPumpDatasItem_Load(object sender, System.EventArgs e)
        {
            if(m_bolEdit)
            {
                this.Text="编辑数据";
                LoadStation();
                EditLoad();
            }
            else
            {
                this.Text="添加数据";
                LoadStation();
                cmbPoint.Text=cmbPoint.Items[0].ToString();
            }
        }
        #endregion //InitializeForm

        #region LoadStation
        /// <summary>
        /// 
        /// </summary>
        private void LoadStation()
        {
            try
            {
                // fill station name combobox
                //
                string str="select name from tbl_gprs_station";
                con=new DBcon();
                SqlCommand cmd=new SqlCommand(str,con.GetConnection());
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    cmbPoint.Items.Add(dr.GetValue(0).ToString().Trim());
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("站点数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("站点数据读取失败!" , ex );
            }
        }
        #endregion //LoadStation

        #region EditLoad
        /// <summary>
        /// 
        /// </summary>
        private void EditLoad()
        {
            DateTime dt;
            try
            {
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("select * from v_AddPumpDatas where id=@m_id",con.GetConnection());
                cmd.Parameters.Add("@m_id",m_DataID);
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    dt=System.Convert.ToDateTime(dr["time"]);
                    dtDate.Value=dt.Date;
                    cmbPoint.Text=dr["Name"].ToString();
                    txtDescription.Text=dr["Description"].ToString();
                    txtValue.Text=dr["addPumpValue"].ToString();
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
        #endregion //EditLoad

        #region UpdateRecord
        /// <summary>
        /// 
        /// </summary>
        private void UpdateRecord()
        {
            try
            {
                int grstid = GetStationID( cmbPoint.Text.Trim() );
                if ( grstid == -1 )
                {
                    MessageBox.Show(
                        "GetStationId error: " + cmbPoint.Text,
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error 
                        );
                    return ;
                }
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("addPumpUpdate",con.GetConnection());
                cmd.CommandType=CommandType.StoredProcedure;
				
                cmd.Parameters.Add("@p_EditID",m_DataID);
                cmd.Parameters.Add("@p_grStationID",grstid );
                cmd.Parameters.Add("@p_Time",dtDate.Value.Date);
                cmd.Parameters.Add("@p_addPumpValue",m_Value);
                cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
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
        #endregion //UpdateRecord

        #region AddRecord
        /// <summary>
        /// 
        /// </summary>
        private void AddRecord()
        {
            try
            {
                con=new DBcon();
                SqlCommand cmd=new SqlCommand("addPumpAdd",con.GetConnection());
                cmd.CommandType=CommandType.StoredProcedure;
                int grStationId = GetStationID ( cmbPoint.Text.Trim() );
                if ( grStationId == -1 )
                {
                    MessageBox.Show( 
                        "error grstation id: " + grStationId + ", grstation name: " + cmbPoint.Text,
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error 
                        );
                    return;
                }
                else
                {
                    cmd.Parameters.Add("@p_grStationID",//GetStationID(cmbPoint.Text.ToString().Trim()));
                        grStationId );
                }
                cmd.Parameters.Add("@p_Time",dtDate.Value.Date);
                cmd.Parameters.Add("@p_addPumpValue",m_Value);
                cmd.Parameters.Add("@p_Description",txtDescription.Text.Trim());
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("数据添加失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("数据添加失败!", ex);
            }
        }
        #endregion //AddRecord

        #region StationID
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int GetStationID(string name)
        {
//            int sID;
//            string str="select gprs_station_id,name from tbl_gprs_station";
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
//                if(dr.GetValue(1).ToString().Trim()==name)
//                {
//                    sID=System.Convert.ToInt32(dr.GetValue(0));
//                    dr.Close();
//                    return sID;
//                }
                grstationId = int.Parse( dr[0].ToString() );
            }
            dr.Close();
            return grstationId;
        }
        #endregion //StationID

        #region CheckDatas
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckDatas()
        {
            try
            {
                if(GetStationID(cmbPoint.Text.Trim()) == -1)
                {
                    MessageBox.Show(
                        "请填写站点名称",
                        "错误",
                        MessageBoxButtons.OK ,
                        MessageBoxIcon.Error
                        );
                    cmbPoint.Focus();
                    cmbPoint.SelectAll();
                    return false;
                }
                if(dtDate.Value.ToShortDateString()=="")
                {
                    MessageBox.Show(
                        "请选择时间",
                        "错误",
                        MessageBoxButtons.OK ,
                        MessageBoxIcon.Error
                        );
                    dtDate.Focus();
                    return false;
                }
                if(txtValue.Text.Trim() == string.Empty )
                {
                    MessageBox.Show(
                        "请输入自来水表流量!",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return false;
                }
                else
                {
                    try
                    {
                        m_Value=System.Convert.ToDecimal(txtValue.Text.Trim());
                    }
                    catch( InvalidCastException icex )
                    {
                        MessageBox.Show(
                            "自来水表流量错误!\r\n" + icex.Message ,
                            "错误",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                // 2007.05.30
                //
                //MessageBox.Show("输入数据错误");
                ExceptionHandler.Handle("输入数据错误" , ex );
                return false;
            }
        }
        #endregion //CheckDatas

        #region btnYes_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, System.EventArgs e)
        {
            if(!CheckDatas())
                return;
            if(m_bolEdit)
                UpdateRecord();
            else
                AddRecord(); //unused
            DialogResult =DialogResult.OK ;
            Close();	
        }
        #endregion //btnYes_Click

        #region btnCancel_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion //btnCancel_Click
    }
}
