using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Communication
{
	/// <summary>
	/// frmCardItem 的摘要说明。
	/// </summary>
	public class frmXGStationItem : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ADEState    _adeState = ADEState.Add;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private int         _editId = -1;

        public ADEState AdeState
        {
            get { return _adeState; }
            set { _adeState = value; }
        }

        public int EditId
        {
            get { return _editId; }
            set { _editId = value; }
        }

		public frmXGStationItem()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            FormAdjust.SetFormAppearance( this, false, false, false, false, true );
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(232, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(32, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 23);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "站名：";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(104, 16);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(288, 21);
            this.txtStationName.TabIndex = 1;
            this.txtStationName.Text = "";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(104, 48);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(288, 21);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Text = "";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(32, 48);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(64, 23);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "地址：";
            // 
            // frmXGStationItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(408, 117);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmXGStationItem";
            this.Text = "巡更站点";
            this.Load += new System.EventHandler(this.frmCardItem_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmCardItem_Load(object sender, System.EventArgs e)
        {
            
            Text += Misc.GetAdeStateText( _adeState );
        }

        public string XGStationName
        {
            get { return txtStationName.Text; }
            set 
            { 
                txtStationName.Text = value; 
            }
        }

        public int Address
        {
            get { return Convert.ToInt32(txtAddress.Text); }
            set { txtAddress.Text = value.ToString(); }
        }

        private bool CheckStationName( string s )
        {
            return s.Trim().Length > 0;
        }

        private bool CheckAddress( string s )
        {
            if ( s.Trim().Length == 0 ) 
            {
                MsgBox.Show("地址不能为空!");
                return false;
            }

            try
            {
                Address = Convert.ToInt32(s );
                if ( Address < 0 )
                    return false;
                else
                    return true;
            }
            catch 
            {
                MsgBox.Show("地址错误!");
                return false;
            }
        }

        //private bool CheckExist( string sn )
        //{
        //    sn = sn.Trim();
        //    return XGDB.CheckCardSNExist(.CheckCardSNExist( sn );
        //}


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if ( !CheckStationName( XGStationName ) )
            {
                MsgBox.Show("站名错误!");
                return ;
            }

            if ( !CheckAddress( txtAddress.Text ) )
                return;

            bool nameExist;
            nameExist = XGDB.CheckXGStationNameExist( XGStationName.Trim(), _editId );
            if ( nameExist )
            {
                MsgBox.Show( "站名已经存在!" );
                return ;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

	}
}
