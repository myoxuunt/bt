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
	/// frmOTOP 的摘要说明。
	/// </summary>
	public class frmOTOP : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtStationName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnWirte;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtB;
		private System.Windows.Forms.TextBox txtK;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOTOP( GRStation st)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			this._st = st;
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
			this.txtStationName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnWirte = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.txtB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtK = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtStationName
			// 
			this.txtStationName.Location = new System.Drawing.Point(158, 16);
			this.txtStationName.Name = "txtStationName";
			this.txtStationName.ReadOnly = true;
			this.txtStationName.Size = new System.Drawing.Size(120, 21);
			this.txtStationName.TabIndex = 9;
			this.txtStationName.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "站名：";
			// 
			// btnWirte
			// 
			this.btnWirte.Location = new System.Drawing.Point(174, 120);
			this.btnWirte.Name = "btnWirte";
			this.btnWirte.TabIndex = 15;
			this.btnWirte.Text = "设置";
			this.btnWirte.Click += new System.EventHandler(this.btnWirte_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(94, 120);
			this.btnRead.Name = "btnRead";
			this.btnRead.TabIndex = 14;
			this.btnRead.Text = "读取";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// txtB
			// 
			this.txtB.Location = new System.Drawing.Point(158, 80);
			this.txtB.Name = "txtB";
			this.txtB.Size = new System.Drawing.Size(120, 21);
			this.txtB.TabIndex = 13;
			this.txtB.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "B值：";
			// 
			// txtK
			// 
			this.txtK.Location = new System.Drawing.Point(158, 48);
			this.txtK.Name = "txtK";
			this.txtK.Size = new System.Drawing.Size(120, 21);
			this.txtK.TabIndex = 11;
			this.txtK.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "K值：";
			// 
			// frmOTOP
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 150);
			this.Controls.Add(this.txtStationName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.btnWirte);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.txtB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtK);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOTOP";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "室外温度参数";
			this.Load += new System.EventHandler(this.frmOTOP_Load);
			this.ResumeLayout(false);

		}
		#endregion


		GRStation _st;
		byte[] _readids;

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			GRReadTEMPOP   cmd = new GRReadTEMPOP ( _st );
			Task t = new Task( cmd, new ImmediateTaskStrategy() );
			frmControlProcess f = new frmControlProcess( t );
			Singles.S.TaskScheduler.Tasks.Add( t );

			DialogResult r =  f.ShowDialog( this );
			if ( t.LastCommResultState == CommResultState.Correct )
			{
				//this.txtMin.Text = cmd.MinOpenDegree.ToString();
				this.txtK.Text = cmd.K.ToString();
				this.txtB.Text = cmd.B.ToString();
				_readids = cmd.Ids;
				//this.txtMax.Text = cmd.MaxOpenDegree.ToString();
			}
		}

		private void btnWirte_Click(object sender, System.EventArgs e)
		{
			float k =0, b=0;
			if( _readids == null )
			{
				MsgBox.Show("请先读取参数!");
				return ;
			}

			try
			{
				k = float.Parse( this.txtK.Text);
			}
			catch
			{	
				MsgBox.Show("K值输入错误");
				return ;
			}

			try
			{
				b = float.Parse( this.txtB.Text);
			}
			catch
			{	
				MsgBox.Show("B值输入错误");
				return ;
			}

			if (!( k>= 0.5F && k<= 1.5F))
			{
				MsgBox.Show("K值必须介于 0.5 到 1.5 之间");
				return;
			}

			if(!(b>= -10F && b<= 10F))
			{
				MsgBox.Show("B值必须介于 -10 到 10 之间");
				return;
			}

			GRWriteTEMPOP   cmd = new GRWriteTEMPOP ( _st,this._readids, k, b );
			Task t = new Task( cmd, new ImmediateTaskStrategy() );
			frmControlProcess f = new frmControlProcess( t );
			Singles.S.TaskScheduler.Tasks.Add( t );

			DialogResult r =  f.ShowDialog( this );
		}

		private void frmOTOP_Load(object sender, System.EventArgs e)
		{
			this.txtStationName.Text = this._st.StationName;
		}
	}
}
