using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace btGR
{
    /// <summary>
    /// frmDataNow 的摘要说明。
    /// </summary>
    public class frmDataNow : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        private string s_name;
        private System.Windows.Forms.Label labOneGT;
        private System.Windows.Forms.Label labOneGP;
        private System.Windows.Forms.Label labOneBT;
        private System.Windows.Forms.Label labOneBP;
        private System.Windows.Forms.Label labOpenDegree;
        private System.Windows.Forms.Label labOneInstant;
        private System.Windows.Forms.Label labTwoGT;
        private System.Windows.Forms.Label labTwoGP;
        private System.Windows.Forms.Label labTwoBT;
        private System.Windows.Forms.Label labTwoBP;
        private System.Windows.Forms.Label labOutT;
        private System.Windows.Forms.Label labWatBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel xunhua;
        private System.Windows.Forms.StatusBarPanel bushui;
        private string S_TITLE="热力站实时监控-单循环泵";
		

        public frmDataNow(string StationName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            s_name=StationName;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataNow));
            this.labOneGT = new System.Windows.Forms.Label();
            this.labOneGP = new System.Windows.Forms.Label();
            this.labOneBT = new System.Windows.Forms.Label();
            this.labOneBP = new System.Windows.Forms.Label();
            this.labOpenDegree = new System.Windows.Forms.Label();
            this.labOneInstant = new System.Windows.Forms.Label();
            this.labTwoGT = new System.Windows.Forms.Label();
            this.labTwoGP = new System.Windows.Forms.Label();
            this.labTwoBT = new System.Windows.Forms.Label();
            this.labTwoBP = new System.Windows.Forms.Label();
            this.labOutT = new System.Windows.Forms.Label();
            this.labWatBox = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.xunhua = new System.Windows.Forms.StatusBarPanel();
            this.bushui = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.xunhua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushui)).BeginInit();
            this.SuspendLayout();
            // 
            // labOneGT
            // 
            this.labOneGT.Location = new System.Drawing.Point(44, 106);
            this.labOneGT.Name = "labOneGT";
            this.labOneGT.Size = new System.Drawing.Size(78, 18);
            this.labOneGT.TabIndex = 0;
            this.labOneGT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOneGP
            // 
            this.labOneGP.Location = new System.Drawing.Point(190, 106);
            this.labOneGP.Name = "labOneGP";
            this.labOneGP.Size = new System.Drawing.Size(78, 18);
            this.labOneGP.TabIndex = 1;
            this.labOneGP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOneBT
            // 
            this.labOneBT.Location = new System.Drawing.Point(44, 214);
            this.labOneBT.Name = "labOneBT";
            this.labOneBT.Size = new System.Drawing.Size(78, 18);
            this.labOneBT.TabIndex = 2;
            this.labOneBT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOneBP
            // 
            this.labOneBP.Location = new System.Drawing.Point(190, 214);
            this.labOneBP.Name = "labOneBP";
            this.labOneBP.Size = new System.Drawing.Size(78, 18);
            this.labOneBP.TabIndex = 3;
            this.labOneBP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOpenDegree
            // 
            this.labOpenDegree.Location = new System.Drawing.Point(44, 292);
            this.labOpenDegree.Name = "labOpenDegree";
            this.labOpenDegree.Size = new System.Drawing.Size(78, 18);
            this.labOpenDegree.TabIndex = 4;
            this.labOpenDegree.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOneInstant
            // 
            this.labOneInstant.Location = new System.Drawing.Point(190, 292);
            this.labOneInstant.Name = "labOneInstant";
            this.labOneInstant.Size = new System.Drawing.Size(78, 18);
            this.labOneInstant.TabIndex = 5;
            this.labOneInstant.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labTwoGT
            // 
            this.labTwoGT.Location = new System.Drawing.Point(476, 106);
            this.labTwoGT.Name = "labTwoGT";
            this.labTwoGT.Size = new System.Drawing.Size(78, 18);
            this.labTwoGT.TabIndex = 6;
            this.labTwoGT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labTwoGP
            // 
            this.labTwoGP.Location = new System.Drawing.Point(606, 106);
            this.labTwoGP.Name = "labTwoGP";
            this.labTwoGP.Size = new System.Drawing.Size(78, 18);
            this.labTwoGP.TabIndex = 7;
            this.labTwoGP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labTwoBT
            // 
            this.labTwoBT.Location = new System.Drawing.Point(476, 214);
            this.labTwoBT.Name = "labTwoBT";
            this.labTwoBT.Size = new System.Drawing.Size(78, 18);
            this.labTwoBT.TabIndex = 8;
            this.labTwoBT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labTwoBP
            // 
            this.labTwoBP.Location = new System.Drawing.Point(606, 216);
            this.labTwoBP.Name = "labTwoBP";
            this.labTwoBP.Size = new System.Drawing.Size(78, 18);
            this.labTwoBP.TabIndex = 9;
            this.labTwoBP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labOutT
            // 
            this.labOutT.Location = new System.Drawing.Point(296, 360);
            this.labOutT.Name = "labOutT";
            this.labOutT.Size = new System.Drawing.Size(78, 18);
            this.labOutT.TabIndex = 10;
            this.labOutT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labWatBox
            // 
            this.labWatBox.Location = new System.Drawing.Point(572, 360);
            this.labWatBox.Name = "labWatBox";
            this.labWatBox.Size = new System.Drawing.Size(78, 18);
            this.labWatBox.TabIndex = 11;
            this.labWatBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 449);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                          this.xunhua,
                                                                                          this.bushui});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(906, 22);
            this.statusBar1.TabIndex = 12;
            this.statusBar1.Text = "statusBar1";
            // 
            // xunhua
            // 
            this.xunhua.Text = "循环泵状态：";
            this.xunhua.Width = 450;
            // 
            // bushui
            // 
            this.bushui.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.bushui.Text = "补水泵状态：";
            this.bushui.Width = 440;
            // 
            // frmDataNow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(906, 471);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.labWatBox);
            this.Controls.Add(this.labOutT);
            this.Controls.Add(this.labTwoBP);
            this.Controls.Add(this.labTwoBT);
            this.Controls.Add(this.labTwoGP);
            this.Controls.Add(this.labTwoGT);
            this.Controls.Add(this.labOneInstant);
            this.Controls.Add(this.labOpenDegree);
            this.Controls.Add(this.labOneBP);
            this.Controls.Add(this.labOneBT);
            this.Controls.Add(this.labOneGP);
            this.Controls.Add(this.labOneGT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataNow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDataNow";
            this.Load += new System.EventHandler(this.frmDataNow_Load);
            this.Closed += new System.EventHandler(this.frmDataNow_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.xunhua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bushui)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmDataNow_Load(object sender, System.EventArgs e)
        {
            this.Text=s_name+S_TITLE;
            LoadDatas();
            if(timer1.Enabled==false)
                this.timer1.Enabled=true;
        }
        private void LoadDatas()
        {
            try
            {
                DBcon con=new DBcon();
                SqlCommand cmd=new SqlCommand("SELECT top 1 * FROM v_grstlastrd where name='"+s_name+"' order by time desc",con.GetConnection());
                SqlDataReader dr=cmd.ExecuteReader();
                if(!dr.Read())
                {
                    MessageBox.Show("该站点暂无数据！");
                    dr.Close();
                    cmd.Dispose();
                    return;
                }
                dr.Close();
                cmd.Dispose();
                SqlDataAdapter da=new SqlDataAdapter("SELECT top 1 * FROM V_HeatDatas where name='"+s_name+"' order by time desc",con.GetConnection());
                DataSet ds=new DataSet();
                da.Fill(ds,"GRValue");
                this.labOneGT.Text=ds.Tables["GRValue"].Rows[0]["oneGiveTemp"].ToString()+" C";
                this.labOneGP.Text=ds.Tables["GRValue"].Rows[0]["oneGivePress"].ToString()+" Mpa";
                this.labOneBT.Text=ds.Tables["GRValue"].Rows[0]["oneBackTemp"].ToString()+" C";
                this.labOneBP.Text=ds.Tables["GRValue"].Rows[0]["oneBackPress"].ToString()+" Mpa";
                this.labOneInstant.Text=ds.Tables["GRValue"].Rows[0]["oneAccum"].ToString()+" T";
                this.labOpenDegree.Text=ds.Tables["GRValue"].Rows[0]["openDegree"].ToString()+" %";
                this.labOutT.Text=ds.Tables["GRValue"].Rows[0]["outsideTemp"].ToString()+" C";
                this.labTwoBP.Text=ds.Tables["GRValue"].Rows[0]["twoBackPress"].ToString()+" Mpa";
                this.labTwoBT.Text=ds.Tables["GRValue"].Rows[0]["twoBackTemp"].ToString()+" C";
                this.labTwoGP.Text=ds.Tables["GRValue"].Rows[0]["twoGivePress"].ToString()+" Mpa";
                this.labTwoGT.Text=ds.Tables["GRValue"].Rows[0]["twoGiveTemp"].ToString()+" C";
                this.labWatBox.Text=ds.Tables["GRValue"].Rows[0]["WatBoxLevel"].ToString()+" M";
                string NowT=ds.Tables["GRValue"].Rows[0]["Time"].ToString();
                string dsd=ds.Tables["GRValue"].Rows[0]["addPumpState1"].ToString();
                if(ds.Tables["GRValue"].Rows[0]["pumpState1"].ToString()=="True")
                    this.xunhua.Text="循环泵状态：启动";
                else if(ds.Tables["GRValue"].Rows[0]["pumpState2"].ToString()=="True")
                    this.xunhua.Text="循环泵状态：启动";
                else if(ds.Tables["GRValue"].Rows[0]["pumpState3"].ToString()=="True")
                    this.xunhua.Text="循环泵状态：启动";
                else
                    this.xunhua.Text="循环泵状态：停止";
                if(ds.Tables["GRValue"].Rows[0]["addPumpState1"].ToString()=="True")
                    this.bushui.Text="补水泵状态：启动";
                else if(ds.Tables["GRValue"].Rows[0]["addPumpState2"].ToString()=="True")
                    this.bushui.Text="补水泵状态：启动";
                else
                    this.bushui.Text="补水泵状态：停止";
                //				if(ds.Tables["GRValue"].Rows[0]["addPumpState1"].ToString()=="Ture"||ds.Tables["GRValue"].Rows[0]["addPumpState1"].ToString()=="Ture")
                //					this.bushui.Text="补水泵状态：启动";
                //				else
                //					this.bushui.Text="补水泵状态：停止";
                da.Dispose();
            }
            catch(Exception ex)
            {
                //MessageBox.Show("实时数据读取失败!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("实时数据读取失败!", ex );
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            LoadDatas();
        }

        private void frmDataNow_Closed(object sender, System.EventArgs e)
        {
            if(timer1.Enabled==true)
                this.timer1.Enabled=false;
        }
    }
}
