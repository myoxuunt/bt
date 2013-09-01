namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    #region frmGprsStationItem
    /// <summary>
	/// frmGprsStationItem 的摘要说明。
	/// </summary>
	public class frmGprsStationItem : System.Windows.Forms.Form
	{
        #region Members
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private ADEState    _adeState = ADEState.Add;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtGrAddress;
        private System.Windows.Forms.TextBox txtXgAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddDrug;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbServerIP;
        private System.Windows.Forms.GroupBox grpCommSettings;
        private System.Windows.Forms.ComboBox cmbTeam;

        private int         _editId = -1;
        #endregion //Members

        #region AdeState
        public ADEState AdeState
        {
            get { return _adeState; }
            set { _adeState = value; }
        }
        #endregion //AdeState

        #region EditId
        public int EditId
        {
            get { return _editId; }
            set { _editId = value; }
        }
        #endregion //EditId

        #region Constructor
		public frmGprsStationItem()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            FormAdjust.SetFormAppearance( this, false, false, false, false, true );
            this.cmbServerIP.Text = cmbServerIP.Items[0].ToString();
            this.cmbTeam.Text = cmbTeam.Items[0].ToString();

		}
        #endregion //Constructor

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
            this.grpCommSettings = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtGrAddress = new System.Windows.Forms.TextBox();
            this.txtXgAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServerIP = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTeam = new System.Windows.Forms.ComboBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddDrug = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpCommSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCommSettings
            // 
            this.grpCommSettings.Controls.Add(this.label8);
            this.grpCommSettings.Controls.Add(this.txtIPAddress);
            this.grpCommSettings.Controls.Add(this.txtGrAddress);
            this.grpCommSettings.Controls.Add(this.txtXgAddress);
            this.grpCommSettings.Controls.Add(this.label4);
            this.grpCommSettings.Controls.Add(this.label3);
            this.grpCommSettings.Controls.Add(this.label1);
            this.grpCommSettings.Controls.Add(this.cmbServerIP);
            this.grpCommSettings.Location = new System.Drawing.Point(8, 176);
            this.grpCommSettings.Name = "grpCommSettings";
            this.grpCommSettings.Size = new System.Drawing.Size(440, 164);
            this.grpCommSettings.TabIndex = 1;
            this.grpCommSettings.TabStop = false;
            this.grpCommSettings.Text = "通讯设置";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "服务器IP地址：";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(152, 29);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(272, 21);
            this.txtIPAddress.TabIndex = 0;
            this.txtIPAddress.Text = "";
            // 
            // txtGrAddress
            // 
            this.txtGrAddress.Location = new System.Drawing.Point(152, 61);
            this.txtGrAddress.Name = "txtGrAddress";
            this.txtGrAddress.Size = new System.Drawing.Size(272, 21);
            this.txtGrAddress.TabIndex = 1;
            this.txtGrAddress.Text = "0";
            // 
            // txtXgAddress
            // 
            this.txtXgAddress.Location = new System.Drawing.Point(152, 93);
            this.txtXgAddress.Name = "txtXgAddress";
            this.txtXgAddress.Size = new System.Drawing.Size(272, 21);
            this.txtXgAddress.TabIndex = 2;
            this.txtXgAddress.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "IP地址：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "供热控制器地址：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "巡更控制器地址：";
            // 
            // cmbServerIP
            // 
            this.cmbServerIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServerIP.Items.AddRange(new object[] {
                                                             "10.110.51.1",
                                                             "10.110.51.2"});
            this.cmbServerIP.Location = new System.Drawing.Point(152, 128);
            this.cmbServerIP.Name = "cmbServerIP";
            this.cmbServerIP.Size = new System.Drawing.Size(272, 20);
            this.cmbServerIP.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTeam);
            this.groupBox1.Controls.Add(this.txtArea);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAddDrug);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStationName);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "站点信息";
            // 
            // cmbTeam
            // 
            this.cmbTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeam.Items.AddRange(new object[] {
                                                         "（无）",
                                                         "一",
                                                         "二",
                                                         "三",
                                                         "四",
                                                         "五",
                                                         "六",
                                                         "七",
                                                         "八",
                                                         "九",
                                                         "十"});
            this.cmbTeam.Location = new System.Drawing.Point(152, 56);
            this.cmbTeam.Name = "cmbTeam";
            this.cmbTeam.Size = new System.Drawing.Size(272, 20);
            this.cmbTeam.TabIndex = 8;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(152, 120);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(272, 21);
            this.txtArea.TabIndex = 3;
            this.txtArea.Text = "1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "供热面积 (万平方米)：";
            // 
            // txtAddDrug
            // 
            this.txtAddDrug.Location = new System.Drawing.Point(152, 88);
            this.txtAddDrug.Name = "txtAddDrug";
            this.txtAddDrug.Size = new System.Drawing.Size(272, 21);
            this.txtAddDrug.TabIndex = 2;
            this.txtAddDrug.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "加药方式：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "所属班组：";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(152, 24);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(272, 21);
            this.txtStationName.TabIndex = 0;
            this.txtStationName.Text = "";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(8, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(136, 23);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "站名：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(160, 348);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(288, 80);
            this.txtRemark.TabIndex = 2;
            this.txtRemark.Text = "";
            this.txtRemark.WordWrap = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(16, 348);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(136, 23);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "备注：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(368, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(288, 444);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmGprsStationItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(456, 473);
            this.Controls.Add(this.grpCommSettings);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmGprsStationItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPRS站点";
            this.Load += new System.EventHandler(this.frmGprsStationItem_Load);
            this.grpCommSettings.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        #region StationName
        public string StationName
        {
            get { return txtStationName.Text.Trim(); }
            set { txtStationName.Text = value; }
        }
        #endregion //StationName

        #region Team
        /// <summary>
        /// 获取或设置所属班组
        /// </summary>
        public string Team
        {
//            get { return this.txtTeamNO.Text.Trim(); }
//            set { this.txtTeamNO.Text = value.Trim(); }
            get { return this.cmbTeam.Text.Trim(); }
            set { this.cmbTeam.Text = value.Trim(); }
        } 
        #endregion //Team

        #region AddDrug
        /// <summary>
        /// 获取或设置加药方式
        /// </summary>
        public string AddDrug
        {
            get { return this.txtAddDrug.Text.Trim(); }
            set { this.txtAddDrug.Text = value.Trim(); }
        }
        #endregion //AddDrug

        #region Area
        /// <summary>
        /// 获取或设置供热面积
        /// </summary>
        public float Area
        {
            get { return float.Parse( this.txtArea.Text ); }
            set { this.txtArea.Text = value.ToString(); }
        }
        #endregion //Area

        #region GrAddress
        public int GrAddress
        {
            get { return Convert.ToInt32( txtGrAddress.Text.Trim() ); }
            set { txtGrAddress.Text = value.ToString(); }
        }
        #endregion //GrAddress

        #region XgAddress
        public int XgAddress
        {
            get { return Convert.ToInt32( txtXgAddress.Text.Trim() ); }
            set { txtXgAddress.Text = value.ToString(); }
        }
        #endregion //XgAddress

        #region Remark
        public string Remark
        {
            get { return txtRemark.Text; }
            set { txtRemark.Text = value; }
        }
        #endregion //Remark

        #region IpAddress
        public string IpAddress
        {
            get { return txtIPAddress.Text.Trim(); }
            set { txtIPAddress.Text = value; }
        }
        #endregion //IpAddress
        
        #region ServerIpAddress
        public string ServerIpAddress
        {
//            get { return txtServerIP.Text.Trim(); }
//            set { txtServerIP.Text = value; }
            get { return cmbServerIP.Text; }
            set { cmbServerIP.Text = value; }
        }
        #endregion //ServerIpAddress

        #region btnOK_Click
        private void btnOK_Click(object sender, System.EventArgs e)
        {
            int grAddr, xgAddr;
            float area;
            //, cpn;

            // check gprs staion name
            //
            if ( StationName == string.Empty )
            {
                MsgBox.Show("站名不能为空!");
                return ;
            }
       
            // check gr address
            //
            try
            {
                grAddr = GrAddress;
            }
            catch
            {
                MsgBox.Show("供热控制器地址错误!");
                return ;
            }
            // check xg address
            //
            try
            {
                xgAddr = XgAddress;
            }
            catch
            {
                MsgBox.Show("巡更控制器地址错误!");
                return ;
            }

            //// check commport
            //
//            try
//            {
//                cpn = CommPort; 
//            }
//            catch
//            {   
//                MsgBox.Show("串口号错误!");
//                return ;
//            }

            // check ip address
            //
            try
            {
                if ( IpAddress.Length == 0 )
                {
                    MsgBox.Show( "IP地址不能为空!" );
                    return ;
                }
                System.Net.IPAddress.Parse( IpAddress );
            }
            catch
            {
                MsgBox.Show("IP地址错误");
                return ;
            }

            try
            {
                if ( ServerIpAddress.Length == 0 )
                {
                    MsgBox.Show ("服务器IP地址不能为空!");
                    return ;
                }
                System.Net.IPAddress.Parse( ServerIpAddress );
            }
            catch
            {
                MsgBox.Show( "服务器IP地址错误" );
                return ;
            }

            try
            {
                area = this.Area;
            }
            catch 
            {
                MsgBox.Show( "供热面积错误" );
                return ;
            }



            // check station name not use
            //
            bool nameExist = XGDB.CheckGprsStationNameExist( StationName.Trim(), 
                EditId, XGConfig.Default.ClientAorB ); 
            if ( nameExist )
            {
                MsgBox.Show("站名已经存在!");
                return ;
            }

            // check commport not use
            //
//            bool cpExist = XGDB.CheckGprsStationCommPortExist( CommPort, EditId, XGConfig.Default.ClientAorB );
//            if ( cpExist )
//            {
//                MsgBox.Show( "串口号已经存在!" );
//                return ;
//            }



            this.DialogResult = DialogResult.OK;
            Close();
        }

        #endregion //btnOK_Click

        #region btnCancel_Click
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        #endregion //btnCancel_Click

        #region frmGprsStationItem_Load
        private void frmGprsStationItem_Load(object sender, System.EventArgs e)
        {
            this.Text += Misc.GetAdeStateText( this._adeState );
            if ( this.AdeState == ADEState.Edit )
            {
                this.grpCommSettings.Enabled = XGConfig.Default.IsEnableMCS;
            }
            

        }
        #endregion //frmGprsStationItem_Load
	}
    #endregion //frmGprsStationItem
}
