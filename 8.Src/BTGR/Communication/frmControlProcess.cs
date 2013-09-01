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
	/// frmControlProcess ��ժҪ˵����
	/// </summary>
	public class frmControlProcess : System.Windows.Forms.Form
	{
        #region Members
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label lblProcess;
		/// <summary>
		/// ����������������
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
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
            // FormAdjust.SetFormAppearance ( this, false, false, false, false, true );
		}
		#endregion //frmControlProcess

		#region Dispose
		/// <summary>
		/// ������������ʹ�õ���Դ��
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

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
            this.btnCancle.Text = "ȡ��";
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
//            ProcessText += "����" + GetCommCmdName ( GetStationName() ) + ", ���Ե�..." + Environment.NewLine;
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
            string s = "ִ��" + GetCommResultText( _task.LastCommResultState );
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
            this.btnCancle.Text = "�ر�";
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
            return state == CommResultState.Correct ? "�ɹ�" : "ʧ��";
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
                    r = "У���";
                    break;

                case CommResultState.Correct:
                    r = "�ɹ�";
                    break;

                case CommResultState.DataError: 
                    r = "�������ݴ���";
                    break;

                case CommResultState.LengthError: 
                    r = "�������ݳ��ȴ���";
                    break;

                case CommResultState.NullData: 
                    r = "δ���յ�����";
                    break;

                default:
                    r = "δ֪����";
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
            this.ProcessText = "�ȴ���ʼ..." + Environment.NewLine;
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
