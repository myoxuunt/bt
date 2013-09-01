using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Communication.GRCtrl;
using CFW;

namespace Communication
{
	/// <summary>
	/// frmGiveTempMode 的摘要说明。
	/// </summary>
	public class frmGiveTempMode : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnWirte;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.RadioButton rdoGiveTempLine;
        private System.Windows.Forms.RadioButton rdoGiveTempValue;
        private System.Windows.Forms.TextBox txtGiveTempValue;
        private GRStation _grst;

		public frmGiveTempMode( GRStation grst )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //      
            this.StartPosition = FormStartPosition.CenterParent;

            if( grst == null )
                throw new ArgumentNullException( "grst" );

            _grst = grst;
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
            this.txtGiveTempValue = new System.Windows.Forms.TextBox();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnWirte = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.rdoGiveTempLine = new System.Windows.Forms.RadioButton();
            this.rdoGiveTempValue = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGiveTempValue
            // 
            this.txtGiveTempValue.Location = new System.Drawing.Point(56, 104);
            this.txtGiveTempValue.Name = "txtGiveTempValue";
            this.txtGiveTempValue.Size = new System.Drawing.Size(68, 21);
            this.txtGiveTempValue.TabIndex = 35;
            this.txtGiveTempValue.Text = "";
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(96, 16);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(188, 21);
            this.txtStationName.TabIndex = 33;
            this.txtStationName.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(40, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "站名：";
            // 
            // btnWirte
            // 
            this.btnWirte.Location = new System.Drawing.Point(160, 176);
            this.btnWirte.Name = "btnWirte";
            this.btnWirte.TabIndex = 31;
            this.btnWirte.Text = "设置";
            this.btnWirte.Click += new System.EventHandler(this.btnWirte_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(80, 176);
            this.btnRead.Name = "btnRead";
            this.btnRead.TabIndex = 30;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // rdoGiveTempLine
            // 
            this.rdoGiveTempLine.Location = new System.Drawing.Point(40, 48);
            this.rdoGiveTempLine.Name = "rdoGiveTempLine";
            this.rdoGiveTempLine.Size = new System.Drawing.Size(244, 24);
            this.rdoGiveTempLine.TabIndex = 36;
            this.rdoGiveTempLine.Text = "使用供温曲线调整二次网供水温度";
            this.rdoGiveTempLine.CheckedChanged += new System.EventHandler(this.rdoGiveTempLine_CheckedChanged);
            // 
            // rdoGiveTempValue
            // 
            this.rdoGiveTempValue.Location = new System.Drawing.Point(40, 76);
            this.rdoGiveTempValue.Name = "rdoGiveTempValue";
            this.rdoGiveTempValue.Size = new System.Drawing.Size(144, 24);
            this.rdoGiveTempValue.TabIndex = 37;
            this.rdoGiveTempValue.Text = "二次网供水温度恒定";
            this.rdoGiveTempValue.CheckedChanged += new System.EventHandler(this.rdoGiveTempValue_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(128, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "摄氏度";
            // 
            // frmGiveTempMode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(306, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdoGiveTempValue);
            this.Controls.Add(this.rdoGiveTempLine);
            this.Controls.Add(this.txtGiveTempValue);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnWirte);
            this.Controls.Add(this.btnRead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGiveTempMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "二次供温模式";
            this.Load += new System.EventHandler(this.frmGiveTempMode_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnRead_Click(object sender, System.EventArgs e)
        {
            // is connected?
            GRReadGiveModeCommand cmd = new GRReadGiveModeCommand( _grst );

            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add ( t );
            frmControlProcess f = new frmControlProcess( t );
            f.ShowDialog();

            if ( t.LastCommResultState == CommResultState.Correct )
            {
                if ( cmd.GiveTempMode == GiveTempMode.TempLine )
                {
                    this.rdoGiveTempLine.Checked = true;
                }
                else
                {
                    this.rdoGiveTempValue.Checked = true;
                    this.txtGiveTempValue.Text = cmd.GiveTempValue.ToString();
                }
            }

        }

        private void CreateImmediateTaskAndExecute( CommCmdBase cmd )
        {
            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add ( t );
            frmControlProcess f = new frmControlProcess( t );
            f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGiveTempMode_Load(object sender, System.EventArgs e)
        {
            this.txtStationName.Text = this._grst.StationName;
            this.rdoGiveTempLine.Checked = true;
        }

        private void rdoGiveTempValue_CheckedChanged(object sender, System.EventArgs e)
        {
            this.txtGiveTempValue.Enabled = this.rdoGiveTempValue.Checked;
        }

        private void rdoGiveTempLine_CheckedChanged(object sender, System.EventArgs e)
        {
            this.txtGiveTempValue.Enabled = !this.rdoGiveTempLine.Checked;
        }

        private void btnWirte_Click(object sender, System.EventArgs e)
        {
            // is connected?
            float val = 0F;
            GiveTempMode mode = GetMode();
            if ( mode == GiveTempMode.TempValue )
            {
                if ( !GetTempValue( out val ) )
                {
                    MsgBox.Show( "输入数据错误!" );
                    return ;
                }
            }

            GRWriteGiveModeCommand cmd = new GRWriteGiveModeCommand( 
                _grst,
                mode,
                val
                );
            CreateImmediateTaskAndExecute( cmd );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private bool GetTempValue( out float val )
        {
            val = 0;
            try
            {
                val = Convert.ToSingle( this.txtGiveTempValue.Text );
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GiveTempMode GetMode()
        {
            if ( rdoGiveTempValue.Checked )
                return GiveTempMode.TempValue;
            else
                return GiveTempMode.TempLine;
        }
	}
}
