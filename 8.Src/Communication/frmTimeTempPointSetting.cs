using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Communication.GRCtrl ;

namespace Communication
{
	/// <summary>
	/// frmTimeTempPointSetting 的摘要说明。
	/// </summary>
	public class frmTimeTempPointSetting : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnok;
		private System.Windows.Forms.Button btncancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTimeTempPointSetting()
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btnok = new System.Windows.Forms.Button();
			this.btncancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "0-2点：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(112, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "0";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(112, 55);
			this.textBox2.Name = "textBox2";
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "0";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "2-4点：";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(112, 78);
			this.textBox3.Name = "textBox3";
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "0";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "4-6点：";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(112, 101);
			this.textBox4.Name = "textBox4";
			this.textBox4.TabIndex = 5;
			this.textBox4.Text = "0";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "6-8点：";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(112, 124);
			this.textBox5.Name = "textBox5";
			this.textBox5.TabIndex = 15;
			this.textBox5.Text = "0";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 124);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "8-10点：";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(112, 147);
			this.textBox6.Name = "textBox6";
			this.textBox6.TabIndex = 13;
			this.textBox6.Text = "0";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 147);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "10-12点：";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(112, 170);
			this.textBox7.Name = "textBox7";
			this.textBox7.TabIndex = 11;
			this.textBox7.Text = "0";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 170);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 23);
			this.label7.TabIndex = 10;
			this.label7.Text = "12-14点：";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(112, 193);
			this.textBox8.Name = "textBox8";
			this.textBox8.TabIndex = 9;
			this.textBox8.Text = "0";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 193);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "14-16点：";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(112, 216);
			this.textBox9.Name = "textBox9";
			this.textBox9.TabIndex = 23;
			this.textBox9.Text = "0";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 216);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 23);
			this.label9.TabIndex = 22;
			this.label9.Text = "16-18点：";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(112, 239);
			this.textBox10.Name = "textBox10";
			this.textBox10.TabIndex = 21;
			this.textBox10.Text = "0";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 239);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 23);
			this.label10.TabIndex = 20;
			this.label10.Text = "18-20点：";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(112, 262);
			this.textBox11.Name = "textBox11";
			this.textBox11.TabIndex = 19;
			this.textBox11.Text = "0";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 262);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 23);
			this.label11.TabIndex = 18;
			this.label11.Text = "20-22点：";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(112, 285);
			this.textBox12.Name = "textBox12";
			this.textBox12.TabIndex = 17;
			this.textBox12.Text = "0";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 285);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 23);
			this.label12.TabIndex = 16;
			this.label12.Text = "22-24点：";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 8);
			this.label13.Name = "label13";
			this.label13.TabIndex = 24;
			this.label13.Text = "时间";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(112, 8);
			this.label14.Name = "label14";
			this.label14.TabIndex = 25;
			this.label14.Text = "温度";
			// 
			// btnok
			// 
			this.btnok.Location = new System.Drawing.Point(56, 328);
			this.btnok.Name = "btnok";
			this.btnok.TabIndex = 26;
			this.btnok.Text = "确定";
			this.btnok.Click += new System.EventHandler(this.btnok_Click);
			// 
			// btncancel
			// 
			this.btncancel.Location = new System.Drawing.Point(136, 328);
			this.btncancel.Name = "btncancel";
			this.btncancel.TabIndex = 27;
			this.btncancel.Text = "取消";
			this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
			// 
			// frmTimeTempPointSettings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(226, 367);
			this.Controls.Add(this.btncancel);
			this.Controls.Add(this.btnok);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTimeTempPointSettings";
			this.Text = "分时供热";
			this.Load += new System.EventHandler(this.frmTimeTempPointSetting_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btncancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		public TimeTempLine TimeTempLine 
		{
			get { return _ttl; }
		} private TimeTempLine _ttl;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnok_Click(object sender, System.EventArgs e)
		{
			try
			{
				TimeTempLine ttl = new TimeTempLine();
				for( int i=0; i<12; i++ )
				{
					byte temp = GetTemp(i);
					ttl.SetTemp(i, temp );
				}
				_ttl = ttl;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message , "提示", 
					MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idx"></param>
		/// <returns></returns>
		byte GetTemp(int idx )
		{
			return byte.Parse( _txts[idx].Text );
		}
		private TextBox[] _txts = new TextBox[12];

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmTimeTempPointSetting_Load(object sender, System.EventArgs e)
		{
			int i=0;
			this._txts[i++] = this.textBox1;
			this._txts[i++] = this.textBox2;
			this._txts[i++] = this.textBox3;
			this._txts[i++] = this.textBox4;
			this._txts[i++] = this.textBox5;
			this._txts[i++] = this.textBox6;
			this._txts[i++] = this.textBox7;
			this._txts[i++] = this.textBox8;
			this._txts[i++] = this.textBox9;
			this._txts[i++] = this.textBox10;
			this._txts[i++] = this.textBox11;
			this._txts[i++] = this.textBox12;
			System.Diagnostics.Debug.Assert(this._txts.Length == 12);
		}		 
	}
}
