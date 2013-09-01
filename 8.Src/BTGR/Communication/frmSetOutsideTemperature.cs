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
	/// frmSetOutsideTemperature 的摘要说明。
	/// </summary>
	public class frmSetOutsideTemperature : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtOutsideTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.ListView lvGRStation;
        private System.Windows.Forms.RadioButton rdoCollByGRCtrl;
        private System.Windows.Forms.RadioButton rdoSetByComputer;
        private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSetOutsideTemperature()
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("aaaa");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("qweqq");
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtOutsideTemp = new System.Windows.Forms.TextBox();
            this.lvGRStation = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.rdoCollByGRCtrl = new System.Windows.Forms.RadioButton();
            this.rdoSetByComputer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(224, 416);
            this.btnOK.Name = "btnOK";
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(304, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtOutsideTemp
            // 
            this.txtOutsideTemp.Enabled = false;
            this.txtOutsideTemp.Location = new System.Drawing.Point(208, 24);
            this.txtOutsideTemp.Name = "txtOutsideTemp";
            this.txtOutsideTemp.TabIndex = 3;
            this.txtOutsideTemp.Text = "";
            // 
            // lvGRStation
            // 
            this.lvGRStation.CheckBoxes = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.lvGRStation.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
                                                                                        listViewItem1,
                                                                                        listViewItem2});
            this.lvGRStation.Location = new System.Drawing.Point(8, 32);
            this.lvGRStation.Name = "lvGRStation";
            this.lvGRStation.Size = new System.Drawing.Size(376, 248);
            this.lvGRStation.TabIndex = 4;
            this.lvGRStation.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.TabIndex = 5;
            this.label2.Text = "选择站点：";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Location = new System.Drawing.Point(16, 288);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "选择所有站点";
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // rdoCollByGRCtrl
            // 
            this.rdoCollByGRCtrl.Checked = true;
            this.rdoCollByGRCtrl.Location = new System.Drawing.Point(16, 56);
            this.rdoCollByGRCtrl.Name = "rdoCollByGRCtrl";
            this.rdoCollByGRCtrl.Size = new System.Drawing.Size(184, 24);
            this.rdoCollByGRCtrl.TabIndex = 7;
            this.rdoCollByGRCtrl.TabStop = true;
            this.rdoCollByGRCtrl.Text = "通过现场控制器采集室外温度";
            this.rdoCollByGRCtrl.CheckedChanged += new System.EventHandler(this.rdoCollByGRCtrl_CheckedChanged);
            // 
            // rdoSetByComputer
            // 
            this.rdoSetByComputer.Location = new System.Drawing.Point(16, 24);
            this.rdoSetByComputer.Name = "rdoSetByComputer";
            this.rdoSetByComputer.Size = new System.Drawing.Size(192, 24);
            this.rdoSetByComputer.TabIndex = 8;
            this.rdoSetByComputer.Text = "通过计算机设置室外温度";
            this.rdoSetByComputer.CheckedChanged += new System.EventHandler(this.rdoSetByComputer_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOutsideTemp);
            this.groupBox1.Controls.Add(this.rdoCollByGRCtrl);
            this.groupBox1.Controls.Add(this.rdoSetByComputer);
            this.groupBox1.Location = new System.Drawing.Point(8, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 88);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "室外温度工作模式";
            // 
            // frmSetOutsideTemperature
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(394, 447);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvGRStation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetOutsideTemperature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "室外温度设定";
            this.Load += new System.EventHandler(this.frmSetOutsideTemperature_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                if ( rdoSetByComputer.Checked )
                {
                    float temp = float.Parse( txtOutsideTemp.Text );
                }
            }
            catch
            {
                MsgBox.Show ( "设定室外温度错误" );
                return ;
            }

            if ( ! IsHasSelected() )
            {
                MsgBox.Show( "没有选择站点" );
                return ;
            }
            CreateSetTempCommand();
        }


        private bool IsHasSelected ()
        {
            foreach ( ListViewItem lvi in this.lvGRStation.Items )
            {
                if ( lvi.Checked )
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillGRStationLV()
        {
            this.lvGRStation.Items.Clear();

            //CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;
            GRStationsCollection grSts = Singles.S.GRStsCollection;

            foreach ( GRStation st in grSts )
            {
                if ( IsConnected ( st.DestinationIP ) )
                {
                    this.lvGRStation.Items.Add( st.StationName );
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GRStation[] GetSelectedGRStation()
        {
            ArrayList al = new ArrayList();
            foreach ( ListViewItem lvi in lvGRStation.Items )
            {
                if ( lvi.Checked )
                {
                    al.Add( lvi.Text );
                }
            }

            GRStation[] sts = new GRStation[al.Count] ;

            for ( int i=0; i<al.Count; i++ )
            {
                string stname = (string)al[ i ];
                sts[i] = GetGRStation( stname );
            }

            return sts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stname"></param>
        /// <returns></returns>
        private GRStation GetGRStation( string stname )
        {
            return Singles.S.GRStsCollection.GetGRStation( stname );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteIP"></param>
        /// <returns></returns>
        private bool IsConnected( string remoteIP )
        {
            CommPortProxysCollection  cpps = Singles.S.TaskScheduler.CppsCollection;
            foreach ( CommPortProxy c in cpps )
            {
                if ( c.RemoteHostIP == remoteIP &&
                    c.IsConnected )
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void CreateSetTempCommand()
        {
            GRStation[] sts = GetSelectedGRStation();
            if ( sts == null || sts.Length == 0 )
                return ;
//            sts.Length * 
            int times = sts.Length * 2 * ( XGConfig.Default.XgCmdLatencyTime / 1000 + 1 ) ;
            foreach( GRStation st in sts )
            {
                if ( st != null )
                {
                    if ( rdoSetByComputer.Checked )
                    {
                        GRSetOutSideTempCommand tempCmd = new GRSetOutSideTempCommand( st, this.OutsideTemperature );
                        Task tempTask = new Task( tempCmd, new ImmediateTaskStrategy() );
                        Singles.S.TaskScheduler.Tasks.Add( tempTask );

                        GRSetOutSideTempModeCommand modeCmd = new GRSetOutSideTempModeCommand ( st, 
                            OutSideTempWorkMode.SetByComputer );
                        Task modeTask = new Task( modeCmd, new ImmediateTaskStrategy() );
                        Singles.S.TaskScheduler.Tasks.Add( modeTask );
                    }
                    else if ( rdoCollByGRCtrl.Checked )
                    {
                        GRSetOutSideTempModeCommand modecmd = new GRSetOutSideTempModeCommand( st,
                            OutSideTempWorkMode.CollByControllor );
                        Task modeTask = new Task ( modecmd, new ImmediateTaskStrategy() );
                        Singles.S.TaskScheduler.Tasks.Add( modeTask );
                        times = times / 2;
                    }

                }
            }
            MsgBox.Show( "设置室外温度命令已提交, 执行完成需要大约 " + times + "秒" );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSelectAll_CheckedChanged(object sender, System.EventArgs e)
        {

            if ( this.chkSelectAll.Checked )
            {
                foreach ( ListViewItem lvi in lvGRStation.Items )
                {
                    lvi.Checked = true;
                }
            }
        }

        private void rdoSetByComputer_CheckedChanged(object sender, System.EventArgs e)
        {
            if ( rdoSetByComputer.Checked )
            {
                this.txtOutsideTemp.Enabled = true; 
            }
        }

        private void rdoCollByGRCtrl_CheckedChanged(object sender, System.EventArgs e)
        {
            if ( this.rdoCollByGRCtrl.Checked )
            {
                txtOutsideTemp.Enabled = false;
            }
        }

        private void frmSetOutsideTemperature_Load(object sender, System.EventArgs e)
        {
            this.FillGRStationLV();
        }

        /// <summary>
        /// 
        /// </summary>
        public float OutsideTemperature
        {
            get { return float.Parse( this.txtOutsideTemp.Text ); }
            set { this.txtOutsideTemp.Text = value.ToString(); }
        }

	}
}
