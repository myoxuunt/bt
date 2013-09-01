using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Communication
{
	/// <summary>
	/// frmLogs 的摘要说明。
	/// </summary>
	public class frmLogs : System.Windows.Forms.Form, CFW.ILog
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private static frmLogs s_default = new frmLogs();
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpDefault;
        private System.Windows.Forms.TabPage tpCommFail;
        private System.Windows.Forms.TabPage tpARD;
        private System.Windows.Forms.TextBox txtDefault;
        private System.Windows.Forms.TextBox txtArd;
        private System.Windows.Forms.TabPage tpNotFindRemoteIP;
        private System.Windows.Forms.TabPage tpTaskLog;
        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.TextBox txtTaskLog;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbCmd;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuOption;
        private System.Windows.Forms.MenuItem menuTopMost;
        private System.Windows.Forms.TextBox txtCommFail;

        //private static frmLogs s_failForm = new frmLogs("Logs - comm fail");
        //
        //public static frmLogs FailForm
        //{
        //    get { return s_failForm; }
        //}

        public static frmLogs Default
        {
            get { return s_default; } 
        }
		public frmLogs()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
        public frmLogs( string text ) : this()
        {
            if (text == null )
                text = string.Empty;
            this.Text = text;
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpDefault = new System.Windows.Forms.TabPage();
            this.txtDefault = new System.Windows.Forms.TextBox();
            this.tpCommFail = new System.Windows.Forms.TabPage();
            this.txtCommFail = new System.Windows.Forms.TextBox();
            this.tpARD = new System.Windows.Forms.TabPage();
            this.txtArd = new System.Windows.Forms.TextBox();
            this.tpNotFindRemoteIP = new System.Windows.Forms.TabPage();
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.tpTaskLog = new System.Windows.Forms.TabPage();
            this.txtTaskLog = new System.Windows.Forms.TextBox();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.cmbCmd = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuOption = new System.Windows.Forms.MenuItem();
            this.menuTopMost = new System.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tpDefault.SuspendLayout();
            this.tpCommFail.SuspendLayout();
            this.tpARD.SuspendLayout();
            this.tpNotFindRemoteIP.SuspendLayout();
            this.tpTaskLog.SuspendLayout();
            this.tpDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpDefault);
            this.tabControl1.Controls.Add(this.tpCommFail);
            this.tabControl1.Controls.Add(this.tpARD);
            this.tabControl1.Controls.Add(this.tpNotFindRemoteIP);
            this.tabControl1.Controls.Add(this.tpTaskLog);
            this.tabControl1.Controls.Add(this.tpDebug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 288);
            this.tabControl1.TabIndex = 1;
            // 
            // tpDefault
            // 
            this.tpDefault.Controls.Add(this.txtDefault);
            this.tpDefault.Location = new System.Drawing.Point(4, 21);
            this.tpDefault.Name = "tpDefault";
            this.tpDefault.Size = new System.Drawing.Size(568, 263);
            this.tpDefault.TabIndex = 0;
            this.tpDefault.Text = "默认";
            // 
            // txtDefault
            // 
            this.txtDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDefault.Location = new System.Drawing.Point(0, 0);
            this.txtDefault.Multiline = true;
            this.txtDefault.Name = "txtDefault";
            this.txtDefault.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDefault.Size = new System.Drawing.Size(568, 263);
            this.txtDefault.TabIndex = 1;
            this.txtDefault.Text = "";
            this.txtDefault.WordWrap = false;
            // 
            // tpCommFail
            // 
            this.tpCommFail.Controls.Add(this.txtCommFail);
            this.tpCommFail.Location = new System.Drawing.Point(4, 21);
            this.tpCommFail.Name = "tpCommFail";
            this.tpCommFail.Size = new System.Drawing.Size(568, 263);
            this.tpCommFail.TabIndex = 1;
            this.tpCommFail.Text = "通讯失败";
            // 
            // txtCommFail
            // 
            this.txtCommFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommFail.Location = new System.Drawing.Point(0, 0);
            this.txtCommFail.Multiline = true;
            this.txtCommFail.Name = "txtCommFail";
            this.txtCommFail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommFail.Size = new System.Drawing.Size(568, 263);
            this.txtCommFail.TabIndex = 0;
            this.txtCommFail.Text = "";
            this.txtCommFail.WordWrap = false;
            // 
            // tpARD
            // 
            this.tpARD.Controls.Add(this.txtArd);
            this.tpARD.Location = new System.Drawing.Point(4, 21);
            this.tpARD.Name = "tpARD";
            this.tpARD.Size = new System.Drawing.Size(568, 263);
            this.tpARD.TabIndex = 2;
            this.tpARD.Text = "自动上报";
            // 
            // txtArd
            // 
            this.txtArd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtArd.Location = new System.Drawing.Point(0, 0);
            this.txtArd.Multiline = true;
            this.txtArd.Name = "txtArd";
            this.txtArd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtArd.Size = new System.Drawing.Size(568, 263);
            this.txtArd.TabIndex = 1;
            this.txtArd.Text = "";
            this.txtArd.WordWrap = false;
            // 
            // tpNotFindRemoteIP
            // 
            this.tpNotFindRemoteIP.Controls.Add(this.txtRemoteIP);
            this.tpNotFindRemoteIP.Location = new System.Drawing.Point(4, 21);
            this.tpNotFindRemoteIP.Name = "tpNotFindRemoteIP";
            this.tpNotFindRemoteIP.Size = new System.Drawing.Size(568, 263);
            this.tpNotFindRemoteIP.TabIndex = 3;
            this.tpNotFindRemoteIP.Text = "远程连接";
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemoteIP.Location = new System.Drawing.Point(0, 0);
            this.txtRemoteIP.Multiline = true;
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemoteIP.Size = new System.Drawing.Size(568, 263);
            this.txtRemoteIP.TabIndex = 2;
            this.txtRemoteIP.Text = "";
            this.txtRemoteIP.WordWrap = false;
            // 
            // tpTaskLog
            // 
            this.tpTaskLog.Controls.Add(this.txtTaskLog);
            this.tpTaskLog.Location = new System.Drawing.Point(4, 21);
            this.tpTaskLog.Name = "tpTaskLog";
            this.tpTaskLog.Size = new System.Drawing.Size(568, 263);
            this.tpTaskLog.TabIndex = 4;
            this.tpTaskLog.Text = "采集记录";
            // 
            // txtTaskLog
            // 
            this.txtTaskLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTaskLog.Location = new System.Drawing.Point(0, 0);
            this.txtTaskLog.Multiline = true;
            this.txtTaskLog.Name = "txtTaskLog";
            this.txtTaskLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTaskLog.Size = new System.Drawing.Size(568, 263);
            this.txtTaskLog.TabIndex = 2;
            this.txtTaskLog.Text = "";
            this.txtTaskLog.WordWrap = false;
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.cmbCmd);
            this.tpDebug.Controls.Add(this.btnSubmit);
            this.tpDebug.Location = new System.Drawing.Point(4, 21);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Size = new System.Drawing.Size(568, 263);
            this.tpDebug.TabIndex = 5;
            this.tpDebug.Text = "Debug";
            // 
            // cmbCmd
            // 
            this.cmbCmd.Location = new System.Drawing.Point(16, 16);
            this.cmbCmd.Name = "cmbCmd";
            this.cmbCmd.Size = new System.Drawing.Size(208, 20);
            this.cmbCmd.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(232, 16);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.menuOption});
            // 
            // menuOption
            // 
            this.menuOption.Index = 0;
            this.menuOption.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                       this.menuTopMost});
            this.menuOption.Text = "&Option";
            // 
            // menuTopMost
            // 
            this.menuTopMost.Index = 0;
            this.menuTopMost.Text = "Top &Most";
            this.menuTopMost.Click += new System.EventHandler(this.menuTopMost_Click);
            // 
            // frmLogs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(576, 288);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Menu = this.mainMenu1;
            this.Name = "frmLogs";
            this.ShowInTaskbar = false;
            this.Text = "数据记录";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLogs_Closing);
            this.Load += new System.EventHandler(this.frmLogs_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpDefault.ResumeLayout(false);
            this.tpCommFail.ResumeLayout(false);
            this.tpARD.ResumeLayout(false);
            this.tpNotFindRemoteIP.ResumeLayout(false);
            this.tpTaskLog.ResumeLayout(false);
            this.tpDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion


        private int _clearCount = 100;

        private int _defaultCount = 0;
        private int _commFailCount = 0;
        private int _ardCount = 0;
        private int _remoteIPCount = 0;
        private int _taskLogCount = 0;


        public void AddLog( string s )
        {
            if ( _defaultCount >= _clearCount )
            {
                this.txtDefault.Clear();
                _defaultCount = 0;
            }

            //this.textBox1.AppendText( s + Environment.NewLine );
            this.txtDefault.AppendText( s + Environment.NewLine );
            _defaultCount ++;
        }

        public void AddLogCommFail( string s )
        {
            if ( _commFailCount >= _clearCount )
            {
                txtCommFail.Clear();
                _commFailCount = 0;
            }
            this.txtCommFail.AppendText( s + Environment.NewLine );
            _commFailCount ++;
        }

        public void AddLogARD( string s )
        {
            if ( _ardCount >= _clearCount )
            {
                txtArd.Clear();
                _ardCount = 0;
            }
            this.txtArd.AppendText( s + Environment.NewLine );
            _ardCount ++;
        }

        public void AddLogRemoteIP( string s )
        {
            if ( _remoteIPCount >= _clearCount )
            {
                txtRemoteIP.Clear();
                _remoteIPCount = 0;
            }
            txtRemoteIP.AppendText( s + Environment.NewLine );
        }

        public void AddLogTaskLog ( string s )
        {
            if ( _taskLogCount >= _clearCount )
            {
                txtTaskLog.Clear();
                _taskLogCount = 0;
            }
            txtTaskLog.AppendText( s + Environment.NewLine );
        }

        private void frmLogs_Load(object sender, System.EventArgs e)
        {
        
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            Execute(); 
        }

        private string getCmd()
        {
            return this.cmbCmd.Text.Trim().ToLower();
        }

        private void Execute()
        {
            string cmd = getCmd();
            if ( cmd == "c" )
            {
//                frmControl f = new frmControl();
                frmXGDataQuery f = new frmXGDataQuery();
                f.Show();
            }
        }

        private void menuTopMost_Click(object sender, System.EventArgs e)
        {
            this.TopMost = ! this.TopMost ;
            this.menuTopMost.Checked = this.TopMost;
        }

        private void frmLogs_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }
	}
}
