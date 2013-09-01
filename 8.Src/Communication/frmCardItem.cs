
namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    #region frmCardItem
	/// <summary>
	/// frmCardItem 的摘要说明。
	/// </summary>
	public class frmCardItem : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCardSN;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.TextBox txtCardSN;
        private System.Windows.Forms.TextBox txtPerson;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private ADEState    _adeState = ADEState.Add;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtTeam;
        private System.Windows.Forms.Label label1;
        private int         _editId = -1;

        
        #region Constructor
		public frmCardItem()
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
        #endregion //Constructor


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
            this.lblCardSN = new System.Windows.Forms.Label();
            this.txtCardSN = new System.Windows.Forms.TextBox();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.lblPerson = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtTeam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(240, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(320, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCardSN
            // 
            this.lblCardSN.Location = new System.Drawing.Point(32, 16);
            this.lblCardSN.Name = "lblCardSN";
            this.lblCardSN.Size = new System.Drawing.Size(64, 23);
            this.lblCardSN.TabIndex = 5;
            this.lblCardSN.Text = "卡号：";
            // 
            // txtCardSN
            // 
            this.txtCardSN.Location = new System.Drawing.Point(104, 16);
            this.txtCardSN.Name = "txtCardSN";
            this.txtCardSN.Size = new System.Drawing.Size(288, 21);
            this.txtCardSN.TabIndex = 0;
            this.txtCardSN.Text = "";
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(104, 48);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(288, 21);
            this.txtPerson.TabIndex = 1;
            this.txtPerson.Text = "";
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(32, 48);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(72, 23);
            this.lblPerson.TabIndex = 6;
            this.lblPerson.Text = "持卡人：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(104, 112);
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
            this.lblAddress.Location = new System.Drawing.Point(32, 112);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 23);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "备注：";
            // 
            // txtTeam
            // 
            this.txtTeam.Location = new System.Drawing.Point(104, 80);
            this.txtTeam.Name = "txtTeam";
            this.txtTeam.Size = new System.Drawing.Size(288, 21);
            this.txtTeam.TabIndex = 8;
            this.txtTeam.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "所属班组：";
            // 
            // frmCardItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(408, 237);
            this.Controls.Add(this.txtTeam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.txtCardSN);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblCardSN);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "frmCardItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TM卡";
            this.Load += new System.EventHandler(this.frmCardItem_Load);
            this.ResumeLayout(false);

        }
		#endregion

        #region Properties
        
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

        public string CardSN
        {
            get { return txtCardSN.Text; }
            set 
            { 
                
                //// ?? not check if pass in a err sn
                //if ( CheckCardSN( value ) )
                //{
                //    txtCardSN.Text = value; 
                //}
                //else
                //{
                //    //TODO: Msgbox error info 
                //    // ??
                //}
                txtCardSN.Text = value; 
            }
        }

        public string Person
        {
            get { return txtPerson.Text; }
            set { txtPerson.Text = value; }
        }

        
        public string Team
        {
            get { return txtTeam.Text; }
            set { txtTeam.Text = value; }
        }


        public string Remark
        {
            get { return txtRemark.Text; }
            set { this.txtRemark.Text = value; }
        }
        #endregion //Properties

        #region CheckCardSN
        private bool CheckCardSN( string sn )
        {

            sn = sn.Trim().ToUpper();
            if ( sn.Length != 16 )
                return false;
            foreach ( char c in sn )
            {
                // TODO: check c in 0 - F
                if ( ( c >= (char)'0' && c <= (char)'9' ) || 
                    ( c >= (char)'A' && c <= (char)'F' ) )
                {
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion //CheckCardSN

        //private bool CheckExist( string sn )
        //{
        //    sn = sn.Trim();
        //    return XGDB.CheckCardSNExist(.CheckCardSNExist( sn );
        //}

        #region FormEvent

        private void frmCardItem_Load(object sender, System.EventArgs e)
        {
            
            Text += Misc.GetAdeStateText( _adeState );
        }


        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if ( !CheckCardSN ( CardSN ) )
            {
                //remove   comment
                //
                MsgBox.Show( "卡号错误!" + Environment.NewLine + 
                    "卡号长度必须为16位，并且只能由数字或 A - F 的字母组成!" );
                return;
            }
            bool snExist;
            snExist = XGDB.CheckCardSNExist( CardSN.Trim(), _editId );
            if ( snExist )
            {
                MsgBox.Show( "卡号已经存在!" );
                return ;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        #endregion //FormEvent

	}
    #endregion //frmCardItem
}
