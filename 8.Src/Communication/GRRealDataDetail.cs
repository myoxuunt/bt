using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Communication
{
	/// <summary>
	/// GRRealDataDetail 的摘要说明。
	/// </summary>
    public class GRRealDataDetail : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtDateTime;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.TextBox txtOpenDegree;
        private System.Windows.Forms.TextBox txtTwoGiveTempBase;
        private System.Windows.Forms.TextBox txtWatBoxLevel;
        private System.Windows.Forms.TextBox txtTwoSum;
        private System.Windows.Forms.TextBox txtTwoInst;
        private System.Windows.Forms.TextBox txtOneSum;
        private System.Windows.Forms.TextBox txtOneInst;
        private System.Windows.Forms.TextBox txtTwoBackTemp;
        private System.Windows.Forms.TextBox txtOneBackTemp;
        private System.Windows.Forms.TextBox txtOneGiveTemp;
        private System.Windows.Forms.TextBox txtTwoBackPress;
        private System.Windows.Forms.TextBox txtOneBackPress;
        private System.Windows.Forms.TextBox txtOneGivePress;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtOutsideTemp;
        private System.Windows.Forms.TextBox txtCyclePump1;
        private System.Windows.Forms.TextBox txtCyclePump2;
        private System.Windows.Forms.TextBox txtCyclePump3;
        private System.Windows.Forms.TextBox txtRePressSet;
        private System.Windows.Forms.TextBox txtTwoGiveTemp;
        private System.Windows.Forms.TextBox txtTwoGivePress;
        private System.Windows.Forms.TextBox txtPressSubSet;
        private System.Windows.Forms.TextBox txtRePump1;
        private System.Windows.Forms.TextBox txtRePump2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public GRRealDataDetail()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();

            // TODO: 在 InitializeComponent 调用后添加任何初始化

			_boldFont = new Font( this.txtCyclePump1.Font.FontFamily,
				this.txtCyclePump1.Font.Size,
				this.txtCyclePump1.Font.Style | FontStyle.Bold,
				this.txtCyclePump1.Font.Unit);
			_Font = this.txtCyclePump1.Font;
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

        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtCyclePump1 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtRePump2 = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.txtRePump1 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtCyclePump3 = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtCyclePump2 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDateTime = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtStationName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtOneInst = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtOneSum = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtOneGiveTemp = new System.Windows.Forms.TextBox();
			this.txtOneBackTemp = new System.Windows.Forms.TextBox();
			this.txtOneGivePress = new System.Windows.Forms.TextBox();
			this.txtOneBackPress = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtTwoGiveTemp = new System.Windows.Forms.TextBox();
			this.txtTwoBackPress = new System.Windows.Forms.TextBox();
			this.txtTwoInst = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTwoBackTemp = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtTwoGivePress = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTwoSum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtOutsideTemp = new System.Windows.Forms.TextBox();
			this.txtPressSubSet = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtOpenDegree = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtTwoGiveTempBase = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtRePressSet = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtWatBoxLevel = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.txtServerIP);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtIP);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtDateTime);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtStationName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(784, 388);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "细节";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtCyclePump1);
			this.groupBox5.Controls.Add(this.label23);
			this.groupBox5.Controls.Add(this.txtRePump2);
			this.groupBox5.Controls.Add(this.label27);
			this.groupBox5.Controls.Add(this.txtRePump1);
			this.groupBox5.Controls.Add(this.label26);
			this.groupBox5.Controls.Add(this.txtCyclePump3);
			this.groupBox5.Controls.Add(this.label25);
			this.groupBox5.Controls.Add(this.txtCyclePump2);
			this.groupBox5.Controls.Add(this.label24);
			this.groupBox5.Location = new System.Drawing.Point(8, 316);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(768, 64);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "泵状态";
			// 
			// txtCyclePump1
			// 
			this.txtCyclePump1.BackColor = System.Drawing.SystemColors.Control;
			this.txtCyclePump1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCyclePump1.ForeColor = System.Drawing.Color.Red;
			this.txtCyclePump1.Location = new System.Drawing.Point(102, 20);
			this.txtCyclePump1.Name = "txtCyclePump1";
			this.txtCyclePump1.ReadOnly = true;
			this.txtCyclePump1.TabIndex = 41;
			this.txtCyclePump1.Text = "";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(32, 20);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(64, 23);
			this.label23.TabIndex = 40;
			this.label23.Text = "循环泵1：";
			// 
			// txtRePump2
			// 
			this.txtRePump2.BackColor = System.Drawing.SystemColors.Control;
			this.txtRePump2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRePump2.Location = new System.Drawing.Point(600, 44);
			this.txtRePump2.Name = "txtRePump2";
			this.txtRePump2.ReadOnly = true;
			this.txtRePump2.TabIndex = 49;
			this.txtRePump2.Text = "";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(536, 44);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(64, 16);
			this.label27.TabIndex = 48;
			this.label27.Text = "补水泵2：";
			// 
			// txtRePump1
			// 
			this.txtRePump1.BackColor = System.Drawing.SystemColors.Control;
			this.txtRePump1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRePump1.Location = new System.Drawing.Point(600, 20);
			this.txtRePump1.Name = "txtRePump1";
			this.txtRePump1.ReadOnly = true;
			this.txtRePump1.TabIndex = 47;
			this.txtRePump1.Text = "";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(536, 20);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 23);
			this.label26.TabIndex = 46;
			this.label26.Text = "补水泵1：";
			// 
			// txtCyclePump3
			// 
			this.txtCyclePump3.BackColor = System.Drawing.SystemColors.Control;
			this.txtCyclePump3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCyclePump3.ForeColor = System.Drawing.Color.IndianRed;
			this.txtCyclePump3.Location = new System.Drawing.Point(336, 20);
			this.txtCyclePump3.Name = "txtCyclePump3";
			this.txtCyclePump3.ReadOnly = true;
			this.txtCyclePump3.TabIndex = 45;
			this.txtCyclePump3.Text = "";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(272, 20);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(64, 23);
			this.label25.TabIndex = 44;
			this.label25.Text = "循环泵3：";
			// 
			// txtCyclePump2
			// 
			this.txtCyclePump2.BackColor = System.Drawing.SystemColors.Control;
			this.txtCyclePump2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCyclePump2.Location = new System.Drawing.Point(102, 44);
			this.txtCyclePump2.Name = "txtCyclePump2";
			this.txtCyclePump2.ReadOnly = true;
			this.txtCyclePump2.TabIndex = 43;
			this.txtCyclePump2.Text = "";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(32, 44);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(64, 16);
			this.label24.TabIndex = 42;
			this.label24.Text = "循环泵2：";
			// 
			// txtServerIP
			// 
			this.txtServerIP.BackColor = System.Drawing.SystemColors.Control;
			this.txtServerIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtServerIP.Location = new System.Drawing.Point(504, 48);
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.ReadOnly = true;
			this.txtServerIP.Size = new System.Drawing.Size(256, 14);
			this.txtServerIP.TabIndex = 7;
			this.txtServerIP.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(400, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "服务器IP地址：";
			// 
			// txtIP
			// 
			this.txtIP.BackColor = System.Drawing.SystemColors.Control;
			this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtIP.Location = new System.Drawing.Point(504, 24);
			this.txtIP.Name = "txtIP";
			this.txtIP.ReadOnly = true;
			this.txtIP.Size = new System.Drawing.Size(256, 14);
			this.txtIP.TabIndex = 5;
			this.txtIP.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(400, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "IP地址：";
			// 
			// txtDateTime
			// 
			this.txtDateTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDateTime.Location = new System.Drawing.Point(84, 48);
			this.txtDateTime.Name = "txtDateTime";
			this.txtDateTime.ReadOnly = true;
			this.txtDateTime.Size = new System.Drawing.Size(280, 14);
			this.txtDateTime.TabIndex = 3;
			this.txtDateTime.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(28, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "时间：";
			// 
			// txtStationName
			// 
			this.txtStationName.BackColor = System.Drawing.SystemColors.Control;
			this.txtStationName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtStationName.Location = new System.Drawing.Point(84, 24);
			this.txtStationName.Name = "txtStationName";
			this.txtStationName.ReadOnly = true;
			this.txtStationName.Size = new System.Drawing.Size(278, 14);
			this.txtStationName.TabIndex = 1;
			this.txtStationName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(28, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "站名：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtOneInst);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.txtOneSum);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label16);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtOneGiveTemp);
			this.groupBox2.Controls.Add(this.txtOneBackTemp);
			this.groupBox2.Controls.Add(this.txtOneGivePress);
			this.groupBox2.Controls.Add(this.txtOneBackPress);
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Location = new System.Drawing.Point(8, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(768, 72);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "一次侧参数";
			// 
			// txtOneInst
			// 
			this.txtOneInst.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneInst.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneInst.Location = new System.Drawing.Point(648, 20);
			this.txtOneInst.Name = "txtOneInst";
			this.txtOneInst.ReadOnly = true;
			this.txtOneInst.TabIndex = 25;
			this.txtOneInst.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(272, 20);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(104, 23);
			this.label12.TabIndex = 16;
			this.label12.Text = "供水温度(℃)：";
			// 
			// txtOneSum
			// 
			this.txtOneSum.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneSum.Location = new System.Drawing.Point(648, 44);
			this.txtOneSum.Name = "txtOneSum";
			this.txtOneSum.ReadOnly = true;
			this.txtOneSum.TabIndex = 27;
			this.txtOneSum.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(30, 20);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "供水压力(MPa)：";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(536, 20);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(104, 23);
			this.label16.TabIndex = 24;
			this.label16.Text = "瞬时流量(T)：";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(30, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 23);
			this.label5.TabIndex = 10;
			this.label5.Text = "回水压力(MPa)：";
			// 
			// txtOneGiveTemp
			// 
			this.txtOneGiveTemp.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneGiveTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneGiveTemp.Location = new System.Drawing.Point(392, 20);
			this.txtOneGiveTemp.Name = "txtOneGiveTemp";
			this.txtOneGiveTemp.ReadOnly = true;
			this.txtOneGiveTemp.TabIndex = 17;
			this.txtOneGiveTemp.Text = "";
			// 
			// txtOneBackTemp
			// 
			this.txtOneBackTemp.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneBackTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneBackTemp.Location = new System.Drawing.Point(392, 44);
			this.txtOneBackTemp.Name = "txtOneBackTemp";
			this.txtOneBackTemp.ReadOnly = true;
			this.txtOneBackTemp.TabIndex = 19;
			this.txtOneBackTemp.Text = "";
			// 
			// txtOneGivePress
			// 
			this.txtOneGivePress.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneGivePress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneGivePress.Location = new System.Drawing.Point(142, 20);
			this.txtOneGivePress.Name = "txtOneGivePress";
			this.txtOneGivePress.ReadOnly = true;
			this.txtOneGivePress.TabIndex = 9;
			this.txtOneGivePress.Text = "";
			// 
			// txtOneBackPress
			// 
			this.txtOneBackPress.BackColor = System.Drawing.SystemColors.Control;
			this.txtOneBackPress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOneBackPress.Location = new System.Drawing.Point(142, 44);
			this.txtOneBackPress.Name = "txtOneBackPress";
			this.txtOneBackPress.ReadOnly = true;
			this.txtOneBackPress.TabIndex = 11;
			this.txtOneBackPress.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(536, 44);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(104, 23);
			this.label15.TabIndex = 26;
			this.label15.Text = "累计流量(T)：";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(272, 44);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(104, 23);
			this.label11.TabIndex = 18;
			this.label11.Text = "回水温度(℃)：";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtTwoGiveTemp);
			this.groupBox3.Controls.Add(this.txtTwoBackPress);
			this.groupBox3.Controls.Add(this.txtTwoInst);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.txtTwoBackTemp);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.txtTwoGivePress);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.txtTwoSum);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Location = new System.Drawing.Point(8, 152);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(768, 72);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "二次侧参数";
			// 
			// txtTwoGiveTemp
			// 
			this.txtTwoGiveTemp.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoGiveTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoGiveTemp.Location = new System.Drawing.Point(392, 20);
			this.txtTwoGiveTemp.Name = "txtTwoGiveTemp";
			this.txtTwoGiveTemp.ReadOnly = true;
			this.txtTwoGiveTemp.TabIndex = 21;
			this.txtTwoGiveTemp.Text = "";
			// 
			// txtTwoBackPress
			// 
			this.txtTwoBackPress.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoBackPress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoBackPress.Location = new System.Drawing.Point(142, 44);
			this.txtTwoBackPress.Name = "txtTwoBackPress";
			this.txtTwoBackPress.ReadOnly = true;
			this.txtTwoBackPress.TabIndex = 15;
			this.txtTwoBackPress.Text = "";
			// 
			// txtTwoInst
			// 
			this.txtTwoInst.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoInst.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoInst.Location = new System.Drawing.Point(648, 20);
			this.txtTwoInst.Name = "txtTwoInst";
			this.txtTwoInst.ReadOnly = true;
			this.txtTwoInst.TabIndex = 29;
			this.txtTwoInst.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(536, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(104, 23);
			this.label14.TabIndex = 28;
			this.label14.Text = "瞬时流量(T)：";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(272, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(104, 23);
			this.label10.TabIndex = 20;
			this.label10.Text = "供水温度(℃)：";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(30, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 23);
			this.label7.TabIndex = 14;
			this.label7.Text = "回水压力(MPa)：";
			// 
			// txtTwoBackTemp
			// 
			this.txtTwoBackTemp.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoBackTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoBackTemp.Location = new System.Drawing.Point(392, 44);
			this.txtTwoBackTemp.Name = "txtTwoBackTemp";
			this.txtTwoBackTemp.ReadOnly = true;
			this.txtTwoBackTemp.TabIndex = 23;
			this.txtTwoBackTemp.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(272, 44);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(104, 23);
			this.label9.TabIndex = 22;
			this.label9.Text = "回水温度(℃)：";
			// 
			// txtTwoGivePress
			// 
			this.txtTwoGivePress.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoGivePress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoGivePress.Location = new System.Drawing.Point(142, 20);
			this.txtTwoGivePress.Name = "txtTwoGivePress";
			this.txtTwoGivePress.ReadOnly = true;
			this.txtTwoGivePress.TabIndex = 13;
			this.txtTwoGivePress.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(30, 20);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 23);
			this.label8.TabIndex = 12;
			this.label8.Text = "供水压力(MPa)：";
			// 
			// txtTwoSum
			// 
			this.txtTwoSum.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoSum.Location = new System.Drawing.Point(648, 44);
			this.txtTwoSum.Name = "txtTwoSum";
			this.txtTwoSum.ReadOnly = true;
			this.txtTwoSum.TabIndex = 31;
			this.txtTwoSum.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(536, 44);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 23);
			this.label13.TabIndex = 30;
			this.label13.Text = "累计流量(T)：";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.txtOutsideTemp);
			this.groupBox4.Controls.Add(this.txtPressSubSet);
			this.groupBox4.Controls.Add(this.label22);
			this.groupBox4.Controls.Add(this.txtOpenDegree);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.txtTwoGiveTempBase);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.txtRePressSet);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.txtWatBoxLevel);
			this.groupBox4.Controls.Add(this.label20);
			this.groupBox4.Location = new System.Drawing.Point(8, 234);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(768, 72);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "其他参数";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(272, 44);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(120, 23);
			this.label21.TabIndex = 36;
			this.label21.Text = "室外温度(℃)：";
			// 
			// txtOutsideTemp
			// 
			this.txtOutsideTemp.BackColor = System.Drawing.SystemColors.Control;
			this.txtOutsideTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutsideTemp.Location = new System.Drawing.Point(392, 44);
			this.txtOutsideTemp.Name = "txtOutsideTemp";
			this.txtOutsideTemp.ReadOnly = true;
			this.txtOutsideTemp.TabIndex = 37;
			this.txtOutsideTemp.Text = "";
			// 
			// txtPressSubSet
			// 
			this.txtPressSubSet.BackColor = System.Drawing.SystemColors.Control;
			this.txtPressSubSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPressSubSet.Location = new System.Drawing.Point(158, 20);
			this.txtPressSubSet.Name = "txtPressSubSet";
			this.txtPressSubSet.ReadOnly = true;
			this.txtPressSubSet.TabIndex = 41;
			this.txtPressSubSet.Text = "";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(32, 20);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(122, 23);
			this.label22.TabIndex = 40;
			this.label22.Text = "压差设定(MPa)：";
			// 
			// txtOpenDegree
			// 
			this.txtOpenDegree.BackColor = System.Drawing.SystemColors.Control;
			this.txtOpenDegree.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOpenDegree.Location = new System.Drawing.Point(640, 44);
			this.txtOpenDegree.Name = "txtOpenDegree";
			this.txtOpenDegree.ReadOnly = true;
			this.txtOpenDegree.TabIndex = 39;
			this.txtOpenDegree.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(536, 44);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(104, 23);
			this.label17.TabIndex = 38;
			this.label17.Text = "调节阀开度(%)：";
			// 
			// txtTwoGiveTempBase
			// 
			this.txtTwoGiveTempBase.BackColor = System.Drawing.SystemColors.Control;
			this.txtTwoGiveTempBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTwoGiveTempBase.Location = new System.Drawing.Point(392, 20);
			this.txtTwoGiveTempBase.Name = "txtTwoGiveTempBase";
			this.txtTwoGiveTempBase.ReadOnly = true;
			this.txtTwoGiveTempBase.TabIndex = 37;
			this.txtTwoGiveTempBase.Text = "";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(272, 20);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(120, 23);
			this.label18.TabIndex = 36;
			this.label18.Text = "二次供温基准(℃)：";
			// 
			// txtRePressSet
			// 
			this.txtRePressSet.BackColor = System.Drawing.SystemColors.Control;
			this.txtRePressSet.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRePressSet.Location = new System.Drawing.Point(158, 44);
			this.txtRePressSet.Name = "txtRePressSet";
			this.txtRePressSet.ReadOnly = true;
			this.txtRePressSet.TabIndex = 35;
			this.txtRePressSet.Text = "";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(32, 44);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(122, 23);
			this.label19.TabIndex = 34;
			this.label19.Text = "补水压力设定(MPa)：";
			// 
			// txtWatBoxLevel
			// 
			this.txtWatBoxLevel.BackColor = System.Drawing.SystemColors.Control;
			this.txtWatBoxLevel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtWatBoxLevel.Location = new System.Drawing.Point(640, 20);
			this.txtWatBoxLevel.Name = "txtWatBoxLevel";
			this.txtWatBoxLevel.ReadOnly = true;
			this.txtWatBoxLevel.TabIndex = 33;
			this.txtWatBoxLevel.Text = "";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(536, 20);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(96, 23);
			this.label20.TabIndex = 32;
			this.label20.Text = "水箱水位(m)：";
			// 
			// GRRealDataDetail
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "GRRealDataDetail";
			this.Size = new System.Drawing.Size(792, 396);
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
        #endregion

        private void groupBox1_Enter(object sender, System.EventArgs e)
        {
        
        }

        public string StationName 
        {
            get { return this.txtStationName.Text; }
            set { this.txtStationName.Text = value;}
        }

        public DateTime DateTime
        {
            set { txtDateTime.Text  = value.ToString() ; }
        }

        public string IP
        {
            set { txtIP.Text = value; }
        }

        public string ServerIP
        {
            set { txtServerIP.Text = value; }
        }

        public float WaterLevel
        {
            set {txtWatBoxLevel.Text = value.ToString(); }
        }

        public int OpenDegree
        {
            set { txtOpenDegree.Text = value.ToString(); }
        }

        public float OneGivePress
        {
            set { txtOneGivePress.Text = value.ToString(); }
        }

        public float OneGiveTemp
        {
            set { txtOneGiveTemp.Text = value.ToString(); }
        }

        public float OneBackPress
        {
            set { txtOneBackPress.Text = value.ToString(); }
        }

        public float OneBackTemp
        {
            set { txtOneBackTemp.Text = value.ToString(); }
        }
        public float OneInst
        {
            set { txtOneInst.Text = value.ToString(); }
        }

        public int OneSum
        {
            set { txtOneSum.Text = value.ToString(); }
        }

        public float TwoGivePress
        {
            set { txtTwoGivePress.Text = value.ToString(); }
        }

        public float TwoGiveTemp
        {
            set { txtTwoGiveTemp.Text = value.ToString(); }
        }

        public float TwoBackPress
        {
            set { txtTwoBackPress.Text = value.ToString(); }
        }

        public float TwoBackTemp
        {
            set { txtTwoBackTemp.Text = value.ToString(); }
        }
        public float TwoInst
        {
            set { txtTwoInst.Text = value.ToString(); }
        }

        public int TwoSum
        {
            set { txtTwoSum.Text = value.ToString(); }
        }

        public float PressSubSet 
        {
            set { txtPressSubSet.Text = value.ToString(); }
        }

        public float RePressSet
        {
            set { txtRePressSet.Text = value.ToString(); }
        }

        public float TwoGiveTempBase
        {
            set { txtTwoGiveTempBase.Text = value.ToString(); }
        }

        public float OutsideTemp
        {
            set { txtOutsideTemp.Text = value.ToString(); }
        }
        
        public string CyclePump1
        {
            set { txtCyclePump1.Text = value; }
        }

        public string CyclePump2
        {
            set { txtCyclePump2.Text = value; }
        }

        public string CyclePump3
        {
           set { txtCyclePump3.Text = value; }
        }

        public string RePump1
        {
            set { txtRePump1.Text = value; } 
        }

        public string RePump2
        {
            set { txtRePump2.Text = value; } 
        }

        public void Clear()
        {
            txtStationName.Text = string.Empty;
            txtDateTime.Text = string.Empty;
            txtIP.Text = string.Empty;
            txtServerIP.Text = string.Empty;
            txtWatBoxLevel.Text = string.Empty;
            txtOpenDegree.Text = string.Empty;
            txtOneGivePress.Text = string.Empty;
            txtOneGiveTemp.Text = string.Empty;
            txtOneBackPress.Text = string.Empty;
            txtOneBackTemp.Text = string.Empty;
            txtOneInst.Text  = string.Empty;
            txtOneSum.Text = string.Empty;
            txtTwoGivePress.Text = string.Empty;
            txtTwoGiveTemp.Text  = string.Empty;
            txtTwoBackPress.Text = string.Empty;
            txtTwoBackTemp.Text = string.Empty;
            txtTwoInst.Text = string.Empty;
            txtTwoSum.Text = string.Empty;
            txtPressSubSet.Text = string.Empty;
            txtRePressSet.Text  = string.Empty;
            txtTwoGiveTempBase.Text = string.Empty;
            txtOutsideTemp.Text = string.Empty;
            txtCyclePump1.Text = string.Empty;
            txtCyclePump2.Text = string.Empty;
            txtCyclePump3.Text = string.Empty;
            txtRePump1.Text = string.Empty;
            txtRePump2.Text = string.Empty;
        }


        private void Check( TextBox t, ALUL a )
        {
            if( t.Text == null || t.Text.Length == 0 )
                return ;

            if ( ! a.Enabled )
            {
                t.ForeColor = nc;
                return;
            }

            float f = 0;
            try
            {
                f = float.Parse(t.Text);
            }
            catch
            {
                return;
            }

            if ( f < a.L || f > a.U )
            {
                t.ForeColor = ec;
            }
            else
            {
                t.ForeColor = nc;
            }
        }

		Font _boldFont = null;//new Font();
		Font _Font;
		
        Color ec = Color.Red;
        Color nc = Color.Black;
        public void CheckException()
        {
			// TODO: check exception data and show exception msg
            //
            if ( this.txtCyclePump1.Text == GT.TEXT_STOP &&
                this.txtCyclePump2.Text == GT.TEXT_STOP && 
                this.txtCyclePump3.Text == GT.TEXT_STOP )
            {
                this.txtCyclePump1.ForeColor = ec;
				this.txtCyclePump1.Font = this._boldFont ;
                this.txtCyclePump2.ForeColor = ec;
				this.txtCyclePump2.Font = this._boldFont ;
                this.txtCyclePump3.ForeColor = ec;
				this.txtCyclePump3.Font = this._boldFont;
            }
            else
            {
                this.txtCyclePump1.ForeColor = nc;
				this.txtCyclePump1.Font = this._Font ;
                this.txtCyclePump2.ForeColor = nc;
				this.txtCyclePump2.Font = this._Font;
                this.txtCyclePump3.ForeColor = nc;
				this.txtCyclePump3.Font = this._Font;;
            }

            // press
            if ( this.txtOneGivePress.Text != "" &&
                this.txtOneBackPress.Text != "")
            {
                float p1 = Convert.ToSingle( this.txtOneGivePress.Text );    
                float p2 = Convert.ToSingle( this.txtOneBackPress.Text );    
                if( p1 <= p2 )
                {
                    this.txtOneGivePress.ForeColor = ec;
					this.txtOneGivePress.Font = _boldFont;
                    this.txtOneBackPress.ForeColor = ec;
					this.txtOneBackPress.Font = _boldFont;
                }
                else
                {
                    this.txtOneGivePress.ForeColor = nc;
					this.txtOneGivePress.Font = _Font;
                    this.txtOneBackPress.ForeColor = nc;
					this.txtOneBackPress.Font = _Font;
                }
            }

            if ( this.txtTwoGivePress.Text != "" &&
                this.txtTwoBackPress.Text != "" )
            {
                float p1 = Convert.ToSingle( this.txtTwoGivePress.Text );    
                float p2 = Convert.ToSingle( this.txtTwoBackPress.Text );    
                if( p1 <= p2 )
                {
                    this.txtTwoGivePress.ForeColor = ec;
					this.txtTwoGivePress.Font = _boldFont;
                    this.txtTwoBackPress.ForeColor = ec;
					this.txtTwoBackPress.Font = _boldFont;
                }
                else
                {
                    this.txtTwoGivePress.ForeColor = nc;
					this.txtTwoGivePress.Font = _Font;
                    this.txtTwoBackPress.ForeColor = nc;
					this.txtTwoBackPress.Font = _Font;
                }
            }

            // temp
            if ( this.txtOneGiveTemp.Text != "" &&
                this.txtOneBackTemp.Text != "")
            {
                float p1 = Convert.ToSingle( this.txtOneGiveTemp.Text );    
                float p2 = Convert.ToSingle( this.txtOneBackTemp.Text );    
                if( p1 <= p2 )
                {
                    this.txtOneGiveTemp.ForeColor = ec;
					this.txtOneGiveTemp.Font = _boldFont;
                    this.txtOneBackTemp.ForeColor = ec;
					this.txtOneBackTemp.Font = _boldFont;
                }
                else
                {
                    this.txtOneGiveTemp.ForeColor = nc;
					this.txtOneGiveTemp.Font = _Font;
                    this.txtOneBackTemp.ForeColor = nc;
					this.txtOneBackTemp.Font = _Font;
                }
            }

            if ( this.txtTwoGiveTemp.Text != "" &&
                this.txtTwoBackTemp.Text != "" )
            {
                float p1 = Convert.ToSingle( this.txtTwoGiveTemp.Text );    
                float p2 = Convert.ToSingle( this.txtTwoBackTemp.Text );    
                if( p1 <= p2 )
                {
                    this.txtTwoGiveTemp.ForeColor = ec;
					this.txtTwoGiveTemp.Font = _boldFont;
                    this.txtTwoBackTemp.ForeColor = ec;
					this.txtTwoBackTemp.Font = _boldFont;
                }
                else
                {
                    this.txtTwoGiveTemp.ForeColor = nc;
					this.txtTwoGiveTemp.Font = _Font;
                    this.txtTwoBackTemp.ForeColor = nc;
					this.txtTwoBackTemp.Font = _Font;
                }
            }

			if ( this.txtOpenDegree.Text != "" )
			{
				float od = float.Parse(this.txtOpenDegree.Text );
				if( od <= 0 )
				{
					this.txtOpenDegree.ForeColor = ec;
					this.txtOpenDegree.Font  = _boldFont;
				}
				else
				{
					this.txtOpenDegree.ForeColor = nc;
					this.txtOpenDegree.Font = _Font;
				}
			}

			if ( this.txtWatBoxLevel.Text != "" )
			{
				float wl = float.Parse( this.txtWatBoxLevel.Text );
				if ( wl <= 0 )
				{
					this.txtWatBoxLevel.ForeColor = ec;
					this.txtWatBoxLevel.Font = _boldFont;
				}
				else
				{
					this.txtWatBoxLevel.ForeColor = nc;
					this.txtWatBoxLevel.Font = _Font;
				
				}
			}

		//            XGConfig c = XGConfig.Default;
		//
		//            Check( this.txtOneGivePress, c.a1gp );
		//            Check( this.txtOneBackPress, c.a1bp );
		//            Check( this.txtTwoGivePress, c.a2gp );
		//            Check( this.txtTwoBackPress, c.a2bp );
		//
		//            Check( this.txtOneGiveTemp, c.a1gt );
		//            Check( this.txtOneBackTemp, c.a1bt );
		//            Check( this.txtTwoGiveTemp, c.a2gt );
		//            Check( this.txtTwoBackTemp, c.a2bt );
	}
	}

}
