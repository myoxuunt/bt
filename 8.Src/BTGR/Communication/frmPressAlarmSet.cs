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
	/// frmPressAlarmSet 的摘要说明。
	/// </summary>
	public class frmPressAlarmSet : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOneGivePressLo;
        private System.Windows.Forms.TextBox txtTwoGivePressHi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTwoBackPressLo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTwoBackPressHi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWirte;



        private GRStation _grSt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStationName;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPressAlarmSet( GRStation grSt )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            ArgumentChecker.CheckNotNull( grSt );
            _grSt = grSt ;
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
            this.txtOneGivePressLo = new System.Windows.Forms.TextBox();
            this.txtTwoGivePressHi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTwoBackPressLo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTwoBackPressHi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWirte = new System.Windows.Forms.Button();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "一次供低压报警值：";
            // 
            // txtOneGivePressLo
            // 
            this.txtOneGivePressLo.Location = new System.Drawing.Point(160, 48);
            this.txtOneGivePressLo.Name = "txtOneGivePressLo";
            this.txtOneGivePressLo.Size = new System.Drawing.Size(120, 21);
            this.txtOneGivePressLo.TabIndex = 1;
            this.txtOneGivePressLo.Text = "";
            // 
            // txtTwoGivePressHi
            // 
            this.txtTwoGivePressHi.Location = new System.Drawing.Point(160, 80);
            this.txtTwoGivePressHi.Name = "txtTwoGivePressHi";
            this.txtTwoGivePressHi.Size = new System.Drawing.Size(120, 21);
            this.txtTwoGivePressHi.TabIndex = 3;
            this.txtTwoGivePressHi.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "二次供高压报警值：";
            // 
            // txtTwoBackPressLo
            // 
            this.txtTwoBackPressLo.Location = new System.Drawing.Point(160, 144);
            this.txtTwoBackPressLo.Name = "txtTwoBackPressLo";
            this.txtTwoBackPressLo.Size = new System.Drawing.Size(120, 21);
            this.txtTwoBackPressLo.TabIndex = 7;
            this.txtTwoBackPressLo.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "二次回低压报警值：";
            // 
            // txtTwoBackPressHi
            // 
            this.txtTwoBackPressHi.Location = new System.Drawing.Point(160, 112);
            this.txtTwoBackPressHi.Name = "txtTwoBackPressHi";
            this.txtTwoBackPressHi.Size = new System.Drawing.Size(120, 21);
            this.txtTwoBackPressHi.TabIndex = 5;
            this.txtTwoBackPressHi.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "二次回高压报警值：";
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(104, 192);
            this.btnRead.Name = "btnRead";
            this.btnRead.TabIndex = 8;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWirte
            // 
            this.btnWirte.Location = new System.Drawing.Point(184, 192);
            this.btnWirte.Name = "btnWirte";
            this.btnWirte.TabIndex = 9;
            this.btnWirte.Text = "设置";
            this.btnWirte.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(160, 16);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(120, 21);
            this.txtStationName.TabIndex = 11;
            this.txtStationName.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "站名：";
            // 
            // frmPressAlarmSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(298, 231);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnWirte);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtTwoBackPressLo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTwoBackPressHi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTwoGivePressHi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOneGivePressLo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPressAlarmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "压力报警设置";
            this.Load += new System.EventHandler(this.frmPressAlarmSet_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void button2_Click(object sender, System.EventArgs e)
        {
            Write();
        }

        private void frmPressAlarmSet_Load(object sender, System.EventArgs e)
        {
            this.txtStationName.Text = _grSt.StationName;
        }

        private void btnRead_Click(object sender, System.EventArgs e)
        {
            Read();
        }

        private void Read()
        {
            GRReadPressAlarmSetCommand cmd = new GRReadPressAlarmSetCommand( _grSt );
            Task t = new Task( cmd, new ImmediateTaskStrategy() );
            frmControlProcess f = new frmControlProcess( t );
            Singles.S.TaskScheduler.Tasks.Add( t );

            DialogResult r =  f.ShowDialog( this );
            if ( t.LastCommResultState == CommResultState.Correct )
            {
                txtOneGivePressLo.Text = cmd.OneGivePressLo.ToString();
                txtTwoGivePressHi.Text = cmd.TwoGivePressHiSetV.ToString();
                txtTwoBackPressHi.Text = cmd.TwoBackPressHiSetV.ToString();
                txtTwoBackPressLo.Text = cmd.TwoBackPressLoSetV.ToString();
            }
        }

        private void Write()
        {
            float onegpl;
            float twogph ;
            float twobph ;
            float twobpl ;
            
            try
            {
                onegpl = Convert.ToSingle( txtOneGivePressLo.Text );
            }
            catch
            {
                MsgBox.Show("一次供低压报警值错误");
                return;
            }

            try
            {
                twogph = Convert.ToSingle( txtTwoGivePressHi.Text );
            }
            catch
            {
                MsgBox.Show("二次供高压报警值错误");
                return;
            }
            try
            {
                twobph = Convert.ToSingle( txtTwoBackPressHi.Text );
            }
            catch
            {
                MsgBox.Show("二次回高压报警值错误");
                return;
            }

            try
            {
                twobpl = Convert.ToSingle( txtTwoBackPressLo.Text );
            }
            catch
            {
                MsgBox.Show("二次回低压报警值错误");
                return;
            }

            GRWritePressAlarmSetCommand cmd = new GRWritePressAlarmSetCommand( _grSt,
                onegpl,
                twogph,
                twobph,
                twobpl );

            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add( t );
            frmControlProcess f = new frmControlProcess( t );
            DialogResult r = f.ShowDialog( this );
            if ( t.LastCommResultState == CommResultState.Correct )
            {
            }
                
        }
	}
}
