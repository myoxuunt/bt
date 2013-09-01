namespace SocketServer
{
    partial class rz_flowchart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labname = new System.Windows.Forms.Label();
            this.labdt = new System.Windows.Forms.Label();
            this.labcoms = new System.Windows.Forms.Label();
            this.labdevs = new System.Windows.Forms.Label();
            this.labwl = new System.Windows.Forms.Label();
            this.labcb = new System.Windows.Forms.Label();
            this.labogt = new System.Windows.Forms.Label();
            this.labobt = new System.Windows.Forms.Label();
            this.labtgt = new System.Windows.Forms.Label();
            this.labtbt = new System.Windows.Forms.Label();
            this.labogp = new System.Windows.Forms.Label();
            this.labobp = new System.Windows.Forms.Label();
            this.labtgp = new System.Windows.Forms.Label();
            this.labtbp = new System.Windows.Forms.Label();
            this.labof = new System.Windows.Forms.Label();
            this.labsf = new System.Windows.Forms.Label();
            this.labsaf = new System.Windows.Forms.Label();
            this.laboaf = new System.Windows.Forms.Label();
            this.labx1 = new System.Windows.Forms.Label();
            this.labx2 = new System.Windows.Forms.Label();
            this.labx3 = new System.Windows.Forms.Label();
            this.labb1 = new System.Windows.Forms.Label();
            this.labb2 = new System.Windows.Forms.Label();
            this.labtgtb = new System.Windows.Forms.Label();
            this.labtgpb = new System.Windows.Forms.Label();
            this.labot = new System.Windows.Forms.Label();
            this.labdegree = new System.Windows.Forms.Label();
            this.laboh = new System.Windows.Forms.Label();
            this.laboah = new System.Windows.Forms.Label();
            this.labth = new System.Windows.Forms.Label();
            this.labtaf = new System.Windows.Forms.Label();
            this.labtf = new System.Windows.Forms.Label();
            this.labtah = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SocketListener.Properties.Resources.yuanli;
            this.pictureBox1.Location = new System.Drawing.Point(-11, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 672);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 90;
            this.pictureBox1.TabStop = false;
            // 
            // labname
            // 
            this.labname.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labname.Location = new System.Drawing.Point(374, 113);
            this.labname.Name = "labname";
            this.labname.Size = new System.Drawing.Size(220, 21);
            this.labname.TabIndex = 82;
            this.labname.Text = "站点名称";
            this.labname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labdt
            // 
            this.labdt.AutoSize = true;
            this.labdt.Location = new System.Drawing.Point(632, 122);
            this.labdt.Name = "labdt";
            this.labdt.Size = new System.Drawing.Size(41, 12);
            this.labdt.TabIndex = 83;
            this.labdt.Text = "时间：";
            this.labdt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labcoms
            // 
            this.labcoms.AutoSize = true;
            this.labcoms.Location = new System.Drawing.Point(757, 123);
            this.labcoms.Name = "labcoms";
            this.labcoms.Size = new System.Drawing.Size(65, 12);
            this.labcoms.TabIndex = 84;
            this.labcoms.Text = "通讯状态：";
            // 
            // labdevs
            // 
            this.labdevs.AutoSize = true;
            this.labdevs.Location = new System.Drawing.Point(880, 123);
            this.labdevs.Name = "labdevs";
            this.labdevs.Size = new System.Drawing.Size(65, 12);
            this.labdevs.TabIndex = 85;
            this.labdevs.Text = "设备状态：";
            this.labdevs.Visible = false;
            // 
            // labwl
            // 
            this.labwl.AutoSize = true;
            this.labwl.Location = new System.Drawing.Point(703, 630);
            this.labwl.Name = "labwl";
            this.labwl.Size = new System.Drawing.Size(65, 12);
            this.labwl.TabIndex = 56;
            this.labwl.Text = "水箱水位：";
            this.labwl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labcb
            // 
            this.labcb.AutoSize = true;
            this.labcb.Location = new System.Drawing.Point(414, 689);
            this.labcb.Name = "labcb";
            this.labcb.Size = new System.Drawing.Size(89, 12);
            this.labcb.TabIndex = 75;
            this.labcb.Text = "供回压差设定：";
            this.labcb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labogt
            // 
            this.labogt.AutoSize = true;
            this.labogt.Location = new System.Drawing.Point(80, 283);
            this.labogt.Name = "labogt";
            this.labogt.Size = new System.Drawing.Size(89, 12);
            this.labogt.TabIndex = 41;
            this.labogt.Text = "一次供水温度：";
            this.labogt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labobt
            // 
            this.labobt.AutoSize = true;
            this.labobt.Location = new System.Drawing.Point(80, 431);
            this.labobt.Name = "labobt";
            this.labobt.Size = new System.Drawing.Size(89, 12);
            this.labobt.TabIndex = 42;
            this.labobt.Text = "一次回水温度：";
            this.labobt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtgt
            // 
            this.labtgt.AutoSize = true;
            this.labtgt.Location = new System.Drawing.Point(672, 289);
            this.labtgt.Name = "labtgt";
            this.labtgt.Size = new System.Drawing.Size(89, 12);
            this.labtgt.TabIndex = 43;
            this.labtgt.Text = "二次供水温度：";
            this.labtgt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtbt
            // 
            this.labtbt.AutoSize = true;
            this.labtbt.Location = new System.Drawing.Point(918, 570);
            this.labtbt.Name = "labtbt";
            this.labtbt.Size = new System.Drawing.Size(89, 12);
            this.labtbt.TabIndex = 44;
            this.labtbt.Text = "二次回水温度：";
            this.labtbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labogp
            // 
            this.labogp.AutoSize = true;
            this.labogp.Location = new System.Drawing.Point(80, 310);
            this.labogp.Name = "labogp";
            this.labogp.Size = new System.Drawing.Size(89, 12);
            this.labogp.TabIndex = 45;
            this.labogp.Text = "一次供水压力：";
            this.labogp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labobp
            // 
            this.labobp.AutoSize = true;
            this.labobp.Location = new System.Drawing.Point(80, 454);
            this.labobp.Name = "labobp";
            this.labobp.Size = new System.Drawing.Size(89, 12);
            this.labobp.TabIndex = 46;
            this.labobp.Text = "一次回水压力：";
            this.labobp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtgp
            // 
            this.labtgp.AutoSize = true;
            this.labtgp.Location = new System.Drawing.Point(672, 311);
            this.labtgp.Name = "labtgp";
            this.labtgp.Size = new System.Drawing.Size(89, 12);
            this.labtgp.TabIndex = 47;
            this.labtgp.Text = "二次供水压力：";
            this.labtgp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtbp
            // 
            this.labtbp.AutoSize = true;
            this.labtbp.Location = new System.Drawing.Point(918, 593);
            this.labtbp.Name = "labtbp";
            this.labtbp.Size = new System.Drawing.Size(89, 12);
            this.labtbp.TabIndex = 48;
            this.labtbp.Text = "二次回水压力：";
            this.labtbp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labof
            // 
            this.labof.AutoSize = true;
            this.labof.Location = new System.Drawing.Point(203, 614);
            this.labof.Name = "labof";
            this.labof.Size = new System.Drawing.Size(89, 12);
            this.labof.TabIndex = 49;
            this.labof.Text = "一次瞬时流量：";
            this.labof.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labsf
            // 
            this.labsf.AutoSize = true;
            this.labsf.Location = new System.Drawing.Point(885, 384);
            this.labsf.Name = "labsf";
            this.labsf.Size = new System.Drawing.Size(89, 12);
            this.labsf.TabIndex = 53;
            this.labsf.Text = "补水瞬时流量：";
            this.labsf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labsf.Visible = false;
            // 
            // labsaf
            // 
            this.labsaf.AutoSize = true;
            this.labsaf.Location = new System.Drawing.Point(885, 407);
            this.labsaf.Name = "labsaf";
            this.labsaf.Size = new System.Drawing.Size(89, 12);
            this.labsaf.TabIndex = 54;
            this.labsaf.Text = "补水累计流量：";
            this.labsaf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labsaf.Visible = false;
            // 
            // laboaf
            // 
            this.laboaf.AutoSize = true;
            this.laboaf.Location = new System.Drawing.Point(203, 639);
            this.laboaf.Name = "laboaf";
            this.laboaf.Size = new System.Drawing.Size(89, 12);
            this.laboaf.TabIndex = 50;
            this.laboaf.Text = "一次累计流量：";
            this.laboaf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labx1
            // 
            this.labx1.AutoSize = true;
            this.labx1.Location = new System.Drawing.Point(672, 431);
            this.labx1.Name = "labx1";
            this.labx1.Size = new System.Drawing.Size(83, 12);
            this.labx1.TabIndex = 76;
            this.labx1.Text = "循环泵1状态：";
            this.labx1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labx2
            // 
            this.labx2.AutoSize = true;
            this.labx2.Location = new System.Drawing.Point(672, 454);
            this.labx2.Name = "labx2";
            this.labx2.Size = new System.Drawing.Size(83, 12);
            this.labx2.TabIndex = 77;
            this.labx2.Text = "循环泵2状态：";
            this.labx2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labx3
            // 
            this.labx3.AutoSize = true;
            this.labx3.Location = new System.Drawing.Point(672, 477);
            this.labx3.Name = "labx3";
            this.labx3.Size = new System.Drawing.Size(83, 12);
            this.labx3.TabIndex = 78;
            this.labx3.Text = "循环泵3状态：";
            this.labx3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labb1
            // 
            this.labb1.AutoSize = true;
            this.labb1.Location = new System.Drawing.Point(703, 652);
            this.labb1.Name = "labb1";
            this.labb1.Size = new System.Drawing.Size(83, 12);
            this.labb1.TabIndex = 79;
            this.labb1.Text = "补水泵1状态：";
            this.labb1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labb2
            // 
            this.labb2.AutoSize = true;
            this.labb2.Location = new System.Drawing.Point(703, 674);
            this.labb2.Name = "labb2";
            this.labb2.Size = new System.Drawing.Size(83, 12);
            this.labb2.TabIndex = 80;
            this.labb2.Text = "补水泵2状态：";
            this.labb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtgtb
            // 
            this.labtgtb.AutoSize = true;
            this.labtgtb.Location = new System.Drawing.Point(414, 633);
            this.labtgtb.Name = "labtgtb";
            this.labtgtb.Size = new System.Drawing.Size(89, 12);
            this.labtgtb.TabIndex = 73;
            this.labtgtb.Text = "二次供温设定：";
            this.labtgtb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labtgpb
            // 
            this.labtgpb.AutoSize = true;
            this.labtgpb.Location = new System.Drawing.Point(414, 663);
            this.labtgpb.Name = "labtgpb";
            this.labtgpb.Size = new System.Drawing.Size(89, 12);
            this.labtgpb.TabIndex = 74;
            this.labtgpb.Text = "二次回压设定：";
            this.labtgpb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labot
            // 
            this.labot.AutoSize = true;
            this.labot.Location = new System.Drawing.Point(414, 603);
            this.labot.Name = "labot";
            this.labot.Size = new System.Drawing.Size(65, 12);
            this.labot.TabIndex = 81;
            this.labot.Text = "室外温度：";
            this.labot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labdegree
            // 
            this.labdegree.AutoSize = true;
            this.labdegree.Location = new System.Drawing.Point(250, 163);
            this.labdegree.Name = "labdegree";
            this.labdegree.Size = new System.Drawing.Size(65, 12);
            this.labdegree.TabIndex = 92;
            this.labdegree.Text = "阀位反馈：";
            this.labdegree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laboh
            // 
            this.laboh.AutoSize = true;
            this.laboh.Location = new System.Drawing.Point(203, 663);
            this.laboh.Name = "laboh";
            this.laboh.Size = new System.Drawing.Size(89, 12);
            this.laboh.TabIndex = 51;
            this.laboh.Text = "一次瞬时热量：";
            this.laboh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.laboh.Visible = false;
            // 
            // laboah
            // 
            this.laboah.AutoSize = true;
            this.laboah.Location = new System.Drawing.Point(203, 686);
            this.laboah.Name = "laboah";
            this.laboah.Size = new System.Drawing.Size(89, 12);
            this.laboah.TabIndex = 52;
            this.laboah.Text = "一次累计热量：";
            this.laboah.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.laboah.Visible = false;
            // 
            // labth
            // 
            this.labth.AutoSize = true;
            this.labth.Location = new System.Drawing.Point(884, 337);
            this.labth.Name = "labth";
            this.labth.Size = new System.Drawing.Size(89, 12);
            this.labth.TabIndex = 90;
            this.labth.Text = "二次瞬时热量：";
            this.labth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labth.Visible = false;
            // 
            // labtaf
            // 
            this.labtaf.AutoSize = true;
            this.labtaf.Location = new System.Drawing.Point(884, 313);
            this.labtaf.Name = "labtaf";
            this.labtaf.Size = new System.Drawing.Size(89, 12);
            this.labtaf.TabIndex = 89;
            this.labtaf.Text = "二次累计流量：";
            this.labtaf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labtaf.Visible = false;
            // 
            // labtf
            // 
            this.labtf.AutoSize = true;
            this.labtf.Location = new System.Drawing.Point(884, 289);
            this.labtf.Name = "labtf";
            this.labtf.Size = new System.Drawing.Size(89, 12);
            this.labtf.TabIndex = 88;
            this.labtf.Text = "二次瞬时流量：";
            this.labtf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labtf.Visible = false;
            // 
            // labtah
            // 
            this.labtah.AutoSize = true;
            this.labtah.Location = new System.Drawing.Point(884, 360);
            this.labtah.Name = "labtah";
            this.labtah.Size = new System.Drawing.Size(89, 12);
            this.labtah.TabIndex = 91;
            this.labtah.Text = "二次累计热量：";
            this.labtah.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labtah.Visible = false;
            // 
            // rz_flowchart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1118, 788);
            this.Controls.Add(this.labdegree);
            this.Controls.Add(this.labtah);
            this.Controls.Add(this.labth);
            this.Controls.Add(this.labtaf);
            this.Controls.Add(this.labwl);
            this.Controls.Add(this.labtf);
            this.Controls.Add(this.labcb);
            this.Controls.Add(this.labdevs);
            this.Controls.Add(this.labogt);
            this.Controls.Add(this.labcoms);
            this.Controls.Add(this.labobt);
            this.Controls.Add(this.labdt);
            this.Controls.Add(this.labtgt);
            this.Controls.Add(this.labname);
            this.Controls.Add(this.labtbt);
            this.Controls.Add(this.labot);
            this.Controls.Add(this.labogp);
            this.Controls.Add(this.labtgpb);
            this.Controls.Add(this.labobp);
            this.Controls.Add(this.labtgtb);
            this.Controls.Add(this.labtgp);
            this.Controls.Add(this.labb2);
            this.Controls.Add(this.labtbp);
            this.Controls.Add(this.labb1);
            this.Controls.Add(this.labof);
            this.Controls.Add(this.labx3);
            this.Controls.Add(this.labsf);
            this.Controls.Add(this.labx2);
            this.Controls.Add(this.labsaf);
            this.Controls.Add(this.labx1);
            this.Controls.Add(this.laboaf);
            this.Controls.Add(this.laboah);
            this.Controls.Add(this.laboh);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "rz_flowchart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rz_flowchart";
            this.Load += new System.EventHandler(this.rz_flowchart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labname;
        private System.Windows.Forms.Label labdt;
        private System.Windows.Forms.Label labcoms;
        private System.Windows.Forms.Label labdevs;
        private System.Windows.Forms.Label labwl;
        private System.Windows.Forms.Label labcb;
        private System.Windows.Forms.Label labogt;
        private System.Windows.Forms.Label labobt;
        private System.Windows.Forms.Label labtgt;
        private System.Windows.Forms.Label labtbt;
        private System.Windows.Forms.Label labogp;
        private System.Windows.Forms.Label labobp;
        private System.Windows.Forms.Label labtgp;
        private System.Windows.Forms.Label labtbp;
        private System.Windows.Forms.Label labof;
        private System.Windows.Forms.Label labsf;
        private System.Windows.Forms.Label labsaf;
        private System.Windows.Forms.Label laboaf;
        private System.Windows.Forms.Label labx1;
        private System.Windows.Forms.Label labx2;
        private System.Windows.Forms.Label labx3;
        private System.Windows.Forms.Label labb1;
        private System.Windows.Forms.Label labb2;
        private System.Windows.Forms.Label labtgtb;
        private System.Windows.Forms.Label labtgpb;
        private System.Windows.Forms.Label labot;
        private System.Windows.Forms.Label labdegree;
        private System.Windows.Forms.Label laboh;
        private System.Windows.Forms.Label laboah;
        private System.Windows.Forms.Label labth;
        private System.Windows.Forms.Label labtaf;
        private System.Windows.Forms.Label labtf;
        private System.Windows.Forms.Label labtah;
    }
}