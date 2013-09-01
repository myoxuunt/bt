namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using CFW;
    using Communication;
    using Communication.GRCtrl;


    #region frmControlProcess
	/// <summary>
	/// frmControlProcess 的摘要说明。
	/// </summary>
	public class frmControlProcess : System.Windows.Forms.Form
	{
        #region Members
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lblProcess;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        private bool _cancelClose;
        private Task _task;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        public frmControlProcess ( Task t )
            : this()
        {
            ArgumentChecker.CheckNotNull( t );
            _task = t;
//            t.BeforeExecuteTask += new EventHandler(t_BeforeExecuteTask);
//            t.AfterExecuteTask  += new EventHandler(t_AfterExecuteTask);
//            t.AfterProcessReceived += new EventHandler(t_AfterProcessReceived);
            RegisterTaskEvent ( _task );
        }
        #endregion //Constructor

        #region RegisterTaskEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        private void RegisterTaskEvent( Task t )
        {   
            ArgumentChecker.CheckNotNull( t );
            t.BeforeExecuteTask += new EventHandler(t_BeforeExecuteTask);
            t.AfterProcessReceived += new EventHandler(t_AfterProcessReceived);
        }
        #endregion //RegisterTaskEvent

		#region frmControlProcess
        /// <summary>
        /// 
        /// </summary>
		private frmControlProcess()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            // FormAdjust.SetFormAppearance ( this, false, false, false, false, true );
		}
		#endregion //frmControlProcess

		#region Dispose
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
		#endregion //Dispose

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCancle = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(464, 136);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcess.Location = new System.Drawing.Point(8, 8);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(528, 120);
            this.lblProcess.TabIndex = 1;
            // 
            // frmControlProcess
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(544, 165);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.btnCancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmControlProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmControlProcess_Closing);
            this.Load += new System.EventHandler(this.frmControlProcess_Load);
            this.ResumeLayout(false);

        }
		#endregion

        #region btnCancle_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, System.EventArgs e)
        {
            if ( _task != Singles.S.TaskScheduler.ActiveTask )
            {
                Singles.S.TaskScheduler.Tasks.Remove( _task );
                this.Close();
            }
        }
        #endregion //btnCancle_Click

        #region frmControlProcess_Closing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmControlProcess_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
//            e.Cancel = true;
            e.Cancel = _cancelClose;
        }
        #endregion //frmControlProcess_Closing

        #region ProcessText
        /// <summary>
        /// 
        /// </summary>
        public string ProcessText 
        {
            get { return this.lblProcess.Text; }
            set { this.lblProcess.Text = value; }
        }
        #endregion //ProcessText

        #region t_BeforeExecuteTask
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_BeforeExecuteTask(object sender, EventArgs e)
        {
//            ProcessText += "正在" + GetCommCmdName ( GetStationName() ) + ", 请稍等..." + Environment.NewLine;
            ProcessText += GetCommCmdName ( GetStationName() ) + Environment.NewLine;
            this.btnCancle.Enabled = false;
            this._cancelClose = true;
        }
        #endregion //t_BeforeExecuteTask

        #region t_AfterProcessReceived
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_AfterProcessReceived(object sender, EventArgs e)
        {
            string s = "执行" + GetCommResultText( _task.LastCommResultState );
            if ( _task.LastCommResultState != CommResultState.Correct )
            {
                s += "(" + GetCommResultTextDetail ( _task.LastCommResultState ) + ")";
                // 2007-10-21 Added comm fail bytes data
                //
                if ( _task.LastReceived != null &&
                    _task.LastReceived.Length > 0 )
                    s += Environment.NewLine + GetReceivedData( _task.LastReceived );
            }
            
            ProcessText += s ;
            this.btnCancle.Text = "关闭";
            this.btnCancle.Enabled = true;
            this._cancelClose = false;
        }
        #endregion //t_AfterProcessReceived

        #region GetReceivedData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private string GetReceivedData( byte[] bs )
        {
            return Utilities.CT.BytesToString( bs );
        }
        #endregion //GetReceivedData

        #region GetCommResultText
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string GetCommResultText ( CommResultState state )
        {
            return state == CommResultState.Correct ? "成功" : "失败";
        }
        #endregion //GetCommResultText

        #region GetCommResultTextDetail
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        private string GetCommResultTextDetail( CommResultState state )
        {
            string r = string.Empty;

            switch ( state  )
            {
                case CommResultState.CheckError:
                    r = "校验错";
                    break;

                case CommResultState.Correct:
                    r = "成功";
                    break;

                case CommResultState.DataError: 
                    r = "接收数据错误";
                    break;

                case CommResultState.LengthError: 
                    r = "接收数据长度错误";
                    break;

                case CommResultState.NullData: 
                    r = "未接收到数据";
                    break;

                default:
                    r = "未知错误";
                    break;
            }

            return r;
        }
        #endregion //GetCommResultTextDetail

        #region frmControlProcess_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmControlProcess_Load(object sender, System.EventArgs e)
        {
            this.lblProcess.BorderStyle = BorderStyle.None;
            this.ProcessText = "等待开始..." + Environment.NewLine;
        }
        #endregion //frmControlProcess_Load

        #region GetStationName
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetStationName ( )
        {
            return _task.CommCmd.Station.StationName;
        }
        #endregion //GetStationName

        #region GetCommCmdName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stName"></param>
        /// <returns></returns>
        private string GetCommCmdName (string stName) 
        {
            CommCmdBase cmd = _task.CommCmd ;

			return CommCmdText.GetCommCmdText( cmd );
        }
        #endregion //GetCommCmdName
    }
    #endregion //frmControlProcess
}
