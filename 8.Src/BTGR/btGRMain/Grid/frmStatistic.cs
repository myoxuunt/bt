using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace btGRMain.Grid
{
	/// <summary>
	/// frmStatistic 的摘要说明。
	/// </summary>
	public class frmStatistic : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbAdd;
		private System.Windows.Forms.CheckBox cbAvg;
		private System.Windows.Forms.CheckBox cbMin;
		private System.Windows.Forms.CheckBox cbMax;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public frmStatistic()
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbAdd = new System.Windows.Forms.CheckBox();
			this.cbAvg = new System.Windows.Forms.CheckBox();
			this.cbMin = new System.Windows.Forms.CheckBox();
			this.cbMax = new System.Windows.Forms.CheckBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(104, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 32);
			this.button1.TabIndex = 4;
			this.button1.Text = "确定";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(176, 96);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 32);
			this.button2.TabIndex = 5;
			this.button2.Text = "取消";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbAdd);
			this.groupBox1.Controls.Add(this.cbAvg);
			this.groupBox1.Controls.Add(this.cbMin);
			this.groupBox1.Controls.Add(this.cbMax);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 80);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "统计类型选择";
			// 
			// cbAdd
			// 
			this.cbAdd.Location = new System.Drawing.Point(136, 48);
			this.cbAdd.Name = "cbAdd";
			this.cbAdd.Size = new System.Drawing.Size(88, 24);
			this.cbAdd.TabIndex = 7;
			this.cbAdd.Text = "  数据累计";
			// 
			// cbAvg
			// 
			this.cbAvg.Location = new System.Drawing.Point(136, 16);
			this.cbAvg.Name = "cbAvg";
			this.cbAvg.Size = new System.Drawing.Size(88, 24);
			this.cbAvg.TabIndex = 6;
			this.cbAvg.Text = "  数据平均";
			// 
			// cbMin
			// 
			this.cbMin.Location = new System.Drawing.Point(24, 48);
			this.cbMin.Name = "cbMin";
			this.cbMin.TabIndex = 5;
			this.cbMin.Text = "  最小值";
			// 
			// cbMax
			// 
			this.cbMax.Location = new System.Drawing.Point(24, 16);
			this.cbMax.Name = "cbMax";
			this.cbMax.TabIndex = 4;
			this.cbMax.Text = "  最大值";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmStatistic
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(258, 135);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmStatistic";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据统计";
			this.Load += new System.EventHandler(this.frmStatistic_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void button1_Click(object sender, System.EventArgs e)
		{
			if(cbMax.Checked)
				frmDataPrint.d_Max=true;
			if(cbMin.Checked)
				frmDataPrint.d_Min=true;
			if(cbAvg.Checked)
				frmDataPrint.d_Avg=true;
			if(cbAdd.Checked)
				frmDataPrint.d_Add=true;
			this.Close();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmStatistic_Load(object sender, System.EventArgs e)
		{
		
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
		
		}
	}
}
