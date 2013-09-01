using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CFW;

namespace Communication
{
	/// <summary>
	/// frmGprsCollState 的摘要说明。
	/// </summary>
	public class frmGprsCollState : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCollState;
        private System.Windows.Forms.TextBox txtCollCycle;
        private System.Windows.Forms.TextBox txtTasksNum;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtRunState;
        private System.Windows.Forms.Label label4;


        private TaskScheduler _taskScheduler;


        static private frmGprsCollState s_default = new frmGprsCollState( Singles.S.TaskScheduler );
        static public frmGprsCollState Default
        {
            get { return s_default; }
        }

		public frmGprsCollState( TaskScheduler taskSch )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//

            _taskScheduler = taskSch;
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCollState = new System.Windows.Forms.TextBox();
            this.txtCollCycle = new System.Windows.Forms.TextBox();
            this.txtTasksNum = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtRunState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = "采集状态:";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.TabIndex = 1;
            this.label2.Text = "采集周期:";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.TabIndex = 2;
            this.label3.Text = "任务数量:";
            // 
            // txtCollState
            // 
            this.txtCollState.Location = new System.Drawing.Point(128, 40);
            this.txtCollState.Name = "txtCollState";
            this.txtCollState.Size = new System.Drawing.Size(152, 21);
            this.txtCollState.TabIndex = 3;
            this.txtCollState.Text = "";
            // 
            // txtCollCycle
            // 
            this.txtCollCycle.Location = new System.Drawing.Point(128, 80);
            this.txtCollCycle.Name = "txtCollCycle";
            this.txtCollCycle.Size = new System.Drawing.Size(152, 21);
            this.txtCollCycle.TabIndex = 4;
            this.txtCollCycle.Text = "";
            // 
            // txtTasksNum
            // 
            this.txtTasksNum.Location = new System.Drawing.Point(128, 120);
            this.txtTasksNum.Name = "txtTasksNum";
            this.txtTasksNum.Size = new System.Drawing.Size(152, 21);
            this.txtTasksNum.TabIndex = 5;
            this.txtTasksNum.Text = "";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(560, 128);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtRunState
            // 
            this.txtRunState.Location = new System.Drawing.Point(400, 40);
            this.txtRunState.Multiline = true;
            this.txtRunState.Name = "txtRunState";
            this.txtRunState.Size = new System.Drawing.Size(232, 56);
            this.txtRunState.TabIndex = 7;
            this.txtRunState.Text = "";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(296, 40);
            this.label4.Name = "label4";
            this.label4.TabIndex = 8;
            this.label4.Text = "运行状态:";
            // 
            // frmGprsCollState
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(640, 157);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRunState);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtTasksNum);
            this.Controls.Add(this.txtCollCycle);
            this.Controls.Add(this.txtCollState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGprsCollState";
            this.Text = "frmGprsCollState";
            this.Load += new System.EventHandler(this.frmGprsCollState_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void frmGprsCollState_Load(object sender, System.EventArgs e)
        {
            RefreshTaskScheduler();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshTaskScheduler();
        }

        private void RefreshTaskScheduler()
        {
            txtCollState.Text = EnableColl ? "已启动" : "已停止";
            txtCollCycle.Text = CollCycle.ToString(); 
            txtTasksNum.Text  = TaskNumber.ToString();
        }

        public bool EnableColl
        {
            get { return _taskScheduler.Enabled; }
            set 
            { 
                _taskScheduler.Enabled = value; 
            }
        }

        public int CollCycle
        {
            get { return XGConfig.Default.GrRealDataCollCycle; }
            set 
            { 
                XGConfig.Default.GrRealDataCollCycle = value; 
                // TODO: set taskscheduler.tasks while taskStratehy is cycleTask and 
                // cmdType is grRealDataCommand
                //
            }
        }

        public int TaskNumber
        {
            get { return _taskScheduler.Tasks.Count; }
        }

        public string RunState
        {
            set 
            { 
                if ( value == null )
                    return ;
                txtRunState.Text = value;
            }
        }
	}
}
