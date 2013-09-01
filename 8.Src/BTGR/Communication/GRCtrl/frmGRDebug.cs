using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using CFW;
using Utilities;

namespace Communication.GRCtrl
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
    public class frmGRDebug: System.Windows.Forms.Form
    {
        
        #region InnerClass
        public delegate void UICmdDelegate();
        
        public class UICmdItem
        {
            private string _uiCmd;
            private string _description;
            UICmdDelegate  _invoke;

            public UICmdItem(string uiCommand, string description, UICmdDelegate cmdDelegate)
            {
                ArgumentChecker.CheckNotNull( cmdDelegate );
                _uiCmd = uiCommand;
                _description = description;
                _invoke = cmdDelegate;
            }

            public string UICmd
            {
                get { return _uiCmd;}
            }
            public string Description
            {
                get { return _description; }
            }
            public UICmdDelegate CmdDelegate
            {
                get { return _invoke; } 
            }
        }

        public class UICmdsCollection : IEnumerable 
        {
            ArrayList _list;

            public UICmdsCollection()
            {
                _list = new ArrayList( 10 );
            }

            public void Add( UICmdItem item )
            {
                ArgumentChecker.CheckNotNull( item );
                _list.Add( item );
            }

            public void RemoveAt ( int index )
            {
                _list.RemoveAt( index );
            }

            public int Count
            {
                get { return _list.Count; }
            }

            public UICmdItem this[ int index ]
            {
                get { return (UICmdItem)_list[ index ]; }
            }
            #region IEnumerable 成员

            public IEnumerator GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            #endregion
        }
        #endregion //InnerClass
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private UICmdsCollection _cmds = new UICmdsCollection();
        public frmGRDebug()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            InitCmds();

        }
        private void InitCmds()
        {
            _cmds.Add( new UICmdItem( "h", "help", new UICmdDelegate(Help) ) );
            _cmds.Add( new UICmdItem( "c", "clear output", new UICmdDelegate(ClearOutput) ) );
            //_cmds.Add( new UICmdItem( "real", "real coll cmd", new UICmdDelegate(CollRealData) ) );
            //_cmds.Add( new UICmdItem( "setTemp", "set temp", new UICmdDelegate(SetTemp) ) );
            //_cmds.Add( new UICmdItem( "setMode", "set mode", new UICmdDelegate(this.SetOutSideMode) ) );
            _cmds.Add( new UICmdItem( "showGPst", "gprs station manager", new UICmdDelegate(showGprsStation )));
            _cmds.Add( new UICmdItem( "showXgCfg", " show xg config", new UICmdDelegate( showXgCfg ) ) );
            _cmds.Add( new UICmdItem( "showTashSchs", " show task scheduler collection", new UICmdDelegate( showTaskSchs ) ) );
            _cmds.Add( new UICmdItem( "showS", " show singles", new UICmdDelegate( showSingles ) ) );
            _cmds.Add( new UICmdItem( "showCpps", "", new UICmdDelegate( showCpps ) ) );
            _cmds.Add( new UICmdItem( "StopTaskScheduler", "", new UICmdDelegate( StopTaskScheduler ) ) );
            _cmds.Add( new UICmdItem( "StartTaskScheduler", "", new UICmdDelegate( StartTaskScheduler ) ) );
            _cmds.Add( new UICmdItem( "SetCollCycle", "", new UICmdDelegate( SetCollCycle ) ) );
            _cmds.Add( new UICmdItem( "showTaskSch", "", new UICmdDelegate( ShowTaskscheduler ) ) );
            _cmds.Add( new UICmdItem( "showSchState", "", new UICmdDelegate( ShowSchState ) ) );
            _cmds.Add( new UICmdItem( "showGRRealDatas", "", new UICmdDelegate( ShowGRRealDatas ) ) );
        }

        private Singles _singles = Singles.S;

        private void ShowGRRealDatas()
        {
//            Singles.S.GRStRds.
            frmAllGRRealDatas f = new frmAllGRRealDatas();
            f.Show();
        }
        private void ShowTaskscheduler()
        {
            frmPropertiesGrid f = new frmPropertiesGrid();
            f.ShowMe( Singles.S.TaskScheduler );
        }

        private string[] _args;

        private TimeSpan GetCycle()
        {
            int m = Convert.ToInt32(_args[0]);
            return new TimeSpan( 0,0,m,0,0 );
        }

        private void ShowSchState()
        {
//            frmGprsCollState f = new frmGprsCollState( Singles.S.TaskScheduler );
//            f.Show();
            frmGprsCollState.Default.Show();
        }
        private void SetCollCycle()
        {
            TasksCollection tasks = Singles.S.TaskScheduler.Tasks;
            foreach( Task t in tasks )
            {
                TaskStrategy s = t.TaskStrategy;
                if ( s is CycleTaskStrategy )
                {
                    CycleTaskStrategy cyc = s as CycleTaskStrategy ;
                    cyc.Cycle = GetCycle();
                }
            }
        }

        private void StopTaskScheduler()
        {
            TaskScheduler sch = Singles.S.TaskScheduler;
            sch.Enabled = false;
        }

        private void StartTaskScheduler()
        {
            TaskScheduler sch = Singles.S.TaskScheduler;
            sch.Enabled = true;
        }

        private void showCpps()
        {
            frmGprsConnectionManager f = new frmGprsConnectionManager();
            f.Show();
        }
        private void showSingles()
        {
            frmPropertiesGrid f =new frmPropertiesGrid();
            f.ShowMe( Singles.S );
        }

        private void showTaskSchs()
        {
            MsgBox.Show("nothing");
            //frmPropertiesGrid f = new frmPropertiesGrid();
            //f.ShowMe( Singles.S.TaskSchCollection );
        }
        private void showXgCfg()
        {   
            frmPropertiesGrid f = new frmPropertiesGrid();
            f.ShowMe( XGConfig.Default );
        }

        private void ClearOutput()
        {
            this.txtOutput.Clear();
        }

        private void Help()
        {
            int i = 0;
            foreach ( UICmdItem c in _cmds )
            {
                i ++;
                AddLog ( i.ToString() + ": " + c.UICmd + " / " + c.Description );
            }
        }

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.cmbCommand = new System.Windows.Forms.ComboBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(224, 368);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(72, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // cmbCommand
            // 
            this.cmbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommand.Location = new System.Drawing.Point(8, 368);
            this.cmbCommand.Name = "cmbCommand";
            this.cmbCommand.Size = new System.Drawing.Size(208, 20);
            this.cmbCommand.TabIndex = 0;
            this.cmbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCommand_KeyDown);
            this.cmbCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCommand_KeyPress);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.txtOutput.Location = new System.Drawing.Point(8, 8);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(912, 352);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "";
            this.txtOutput.WordWrap = false;
            // 
            // frmGRDebug
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(928, 397);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.cmbCommand);
            this.Controls.Add(this.btnSubmit);
            this.Name = "frmGRDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGRDebug_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
		#endregion


        #region old
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ComboBox cmbCommand;
        private System.Windows.Forms.TextBox txtOutput;

        TestXGSystemCommand _test = null;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            initGr();
//            frmXGStationManager f = new frmXGStationManager();
//            f.ShowDialog();o
//            frmAllGRRealDatas f = new frmAllGRRealDatas();
//            f.Show();

//            frmGRAlarmDataPopUp f2 = new frmGRAlarmDataPopUp();
//            f2.Show();
            frmGRAlarmDataPopUp.Default.Show();
        }


        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string cmd = cmbCommand.Text.Trim().ToLower();
            SubmitCommand( cmd );
        }

        private void SubmitCommand( string cmd )
        {
            ExecuteUICmd( cmd );
        }

        private void ExecuteUICmd( string cmd )
        {
            string[] cmdParts = cmd.Trim().Split(' ');
            if (cmdParts.Length == 1 )
            {
                string cmdCopy = cmd.Trim();
                foreach ( UICmdItem c in _cmds )
                {
                    if ( string.Compare ( cmdCopy, c.UICmd, true ) == 0 )
                    {
                        AddLog ( "> " + cmdCopy );
                        c.CmdDelegate();
                    }
                }
            }
            else
            {
                _args = new string[ cmdParts.Length - 1 ];
                for ( int i=_args.Length - 1; i>=0; i-- )
                {
                    _args[i] = cmdParts[i+1];
                }
                string cmdCopy = cmdParts[0].Trim();
                foreach ( UICmdItem c in _cmds )
                {
                    if ( string.Compare ( cmdCopy, c.UICmd, true ) == 0 )
                    {
                        AddLog ( "> " + cmdCopy );
                        c.CmdDelegate();
                    }
                }
            }
        }


        private void cmbCommand_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch( e.KeyChar)
            {
                case (char)0x0D:
                    btnSubmit_Click(null, null);
                    break;
            }
        }


        private void AddLog( string s )
        {
            txtOutput.AppendText( s + System.Environment.NewLine) ; 
        }

        private void cmbCommand_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Escape )
                this.cmbCommand.Text = string.Empty;
        }

        /// <summary>
        /// 处理执行完毕的命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskScheduler_Executed(object sender, EventArgs e)
        {
            TaskScheduler sch = sender as TaskScheduler ;
            if ( sch == null )
                Debug.Fail( "TaskScheduler_Executed(), sender == null" );
            AddLog ( "TC: " + sch.Tasks.Count );
            Task at = sch.ActiveTask;
            string s = string.Format( "send: {0}, {1}\r\nrece: {2}, {3}",
                at.LastSendDateTime, CT.BytesToString( at.LastSendDatas ), 
                at.LastReceivedDateTime, CT.BytesToString( at.LastReceived) );

            AddLog ( s );
            s = at.LastCommResultState.ToString();
            AddLog( s );
            CommCmdBase cmd = sch.ActiveTask.CommCmd;

            // read total count cmd
            //
            if ( cmd is ReadTotalCountCommand )
            {
                
                ReadTotalCountCommand c = cmd as ReadTotalCountCommand;
                
                AddLog( "LocalTotalCount: " + c.TotalCount );
                AddLog ( c.Station.StationName + c.Station.Address );
                
                // need read all record and clear xg ctrler data
                //
                if (at.Tag != null)
                {//&& 
                   // (string)at.Tag == TagType.OP_ReadAndClearXgData.ToString() )
                //{
                    object[] tags = (object[]) at.Tag;
                    TagType tagType = (TagType)tags[0];
                    XGTask xgtask = (XGTask) tags[1];
                    
                    RemoveAllCommand clearCmd = new RemoveAllCommand( c.Station as XGStation );
                    Task clearTask = new Task( clearCmd, new ImmediateTaskStrategy () );
                    Singles.S.TaskScheduler.Tasks.Add( clearTask );

                    for ( int i=0; i<c.TotalCount; i++ )
                    {
                        ReadRecordCommand rdcmd = new ReadRecordCommand( c.Station as XGStation, i+1 );
                        Task t = new Task(rdcmd, new ImmediateTaskStrategy() );
                        Singles.S.TaskScheduler.Tasks.Add( t );
                    }

                    // ???
                    //
                    //RemoveAllCommand rac = new RemoveAllCommand( c.Station as XGStation );
                    //Task trac = new Task( "rdall", rac, new ImmediateTaskStrategy() );
                    //trac.Tag = xgtask;
                    //trac.BeforeExecuteTask +=new EventHandler(trac_BeforeExecuteTask);
                    //Singles.S.TaskScheduler.Tasks.Add( trac );
                }
            }

            // read record cmd
            //
            if ( cmd is ReadRecordCommand )
            {
                ReadRecordCommand rdcmd = cmd as ReadRecordCommand;
                AddLog ( "record index: " +  rdcmd.RecordIndex );
 
                if ( rdcmd.XGData != null )
                {
                    // 2007.03.11 Modify
                    //
                    //XGDB.InsertXGData( rdcmd.XGData );
                    XGDB.InsertXGData( cmd.Station.DestinationIP, rdcmd.XGData );
                }

                XGTask[] tasks = Singles.S.XGScheduler.Tasks.MatchXGData( rdcmd.XGData );
                foreach ( XGTask task in tasks )
                {
                    task.IsComplete = true;
                }
            }
        }

        private void trac_BeforeExecuteTask(object sender, EventArgs e)
        {
            // 通知XGTask Read xg local data complete.
            //
            Task t = (Task)sender;
            if ( t.Tag != null )
            {
                XGTask xgtask = (XGTask)t.Tag;
                xgtask.ReadLocalXgDataComplete();
            }
        }

        #endregion old


        //private TaskScheduler _grTaskSch = new TaskScheduler( new CommPortProxy() );
        //private GRStation _defGrStation = new GRStation( "def gr st", 0 );

        private void initGr()
        {
            //_grTaskSch.CommPortProxy.Open();
            //_grTaskSch.Enabled = true;
            //_grTaskSch.CommPortProxy.IsEnableAutoReport = true;
            //_grTaskSch.CommPortProxy.RThreshold = 10;
            //_grTaskSch.CommPortProxy.ReceiveAutoReport +=new EventHandler(CommPortProxy_ReceiveAutoReport);
            //Debug.Assert ( _grTaskSch.Tasks != null );
            //_grTaskSch = Singles.S.TaskSchCollection[0];

        }

        //private void CollRealData()
        //{
        //    GRRealDataCommand realCmd = new GRRealDataCommand(_defGrStation);
        //    Task realTask = new Task(realCmd, new ImmediateTaskStrategy() );
        //    _grTaskSch.Tasks.Add( realTask );
        //}
        //private void SetTemp()
        //{
        //    GRSetOutSideTempCommand c = new GRSetOutSideTempCommand( _defGrStation, 21.9F );
        //    Task t = new Task( c, new ImmediateTaskStrategy() );
        //    _grTaskSch.Tasks.Add( t );
        //}
        //private void SetOutSideMode()
        //{
        //    GRSetOutSideTempModeCommand c = new GRSetOutSideTempModeCommand( _defGrStation, OutSideTempWorkMode.SetByComputer );
        //    Task t = new Task( c, new ImmediateTaskStrategy() );
        //    _grTaskSch.Tasks.Add( t );
        //}
        private void CommPortProxy_ReceiveAutoReport(object sender, EventArgs e)
        {
            //try
            //{
                CommPortProxy cpp = (CommPortProxy)sender;
                byte[] bs = cpp.AutoReportData;
                string s = CT.BytesToString ( bs ) + Environment.NewLine + bs.Length;
                //MsgBox.Show (s );o
                AddLog( s );
                GRAlarmData ad;

                if (GRAlarmData.ProcessAutoReport( bs, out ad ) == CommResultState.Correct )
                {
                    frmPropertiesGrid f = new frmPropertiesGrid();
                    f.ShowMe( ad,"" );
                }
            //}
            //catch(Exception ex)
            //{
            //    MsgBox.Show( ex.ToString() );
            //}
        }

        void showGprsStation()
        {
            frmXGStationManager f = new frmXGStationManager();
            f.ShowDialog();
        }

        private void frmGRDebug_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult r = MessageBox.Show( this, "close ? ","cap",MessageBoxButtons.YesNo );

            bool bClose = ( r == DialogResult.No );
            e.Cancel = bClose;
        }
    }
}
