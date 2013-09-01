using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Communication.GRCtrl;
using CFW;
using System.Diagnostics;

namespace Communication
{
	/// <summary>
	/// frmXGDateTimeSetting ��ժҪ˵����
	/// </summary>
	public class frmXGDateTimeSetting : System.Windows.Forms.Form
	{
        #region Delegate
        private delegate CFW.CommCmdBase CommCmdMakerDelegate( XGStation xgst);
        private delegate void CommCmdProcessDelegate( CommCmdBase cmd );
        #endregion //Delegate

        #region Members
        private System.Windows.Forms.ColumnHeader chXgName;
        private System.Windows.Forms.ColumnHeader chXgDate;
        private System.Windows.Forms.ColumnHeader chXgTime;
        private System.Windows.Forms.ColumnHeader chCollTime;
        private System.Windows.Forms.Button btnReadSelXgDt;
        private System.Windows.Forms.Button btnReadAllXgDt;
        private System.Windows.Forms.Button btnSetSelXgDt;
        private System.Windows.Forms.Button btnSetAllXgDt;
        private System.Windows.Forms.ListView lvXg;
        private System.Windows.Forms.Button btnReadSelXgTime;
        private System.Windows.Forms.Button btnReadAllXgTime;
        private System.Windows.Forms.Button btnSetAllXgTime;
        private System.Windows.Forms.Button btnSetSelXgTime;

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
        #endregion //Members

		#region frmXGDateTimeSetting
		public frmXGDateTimeSetting()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}
		#endregion //frmXGDateTimeSetting

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
            this.lvXg = new System.Windows.Forms.ListView();
            this.chXgName = new System.Windows.Forms.ColumnHeader();
            this.chXgDate = new System.Windows.Forms.ColumnHeader();
            this.chXgTime = new System.Windows.Forms.ColumnHeader();
            this.chCollTime = new System.Windows.Forms.ColumnHeader();
            this.btnReadSelXgDt = new System.Windows.Forms.Button();
            this.btnReadAllXgDt = new System.Windows.Forms.Button();
            this.btnSetSelXgDt = new System.Windows.Forms.Button();
            this.btnSetAllXgDt = new System.Windows.Forms.Button();
            this.btnReadSelXgTime = new System.Windows.Forms.Button();
            this.btnReadAllXgTime = new System.Windows.Forms.Button();
            this.btnSetAllXgTime = new System.Windows.Forms.Button();
            this.btnSetSelXgTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvXg
            // 
            this.lvXg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                   this.chXgName,
                                                                                   this.chXgDate,
                                                                                   this.chXgTime,
                                                                                   this.chCollTime});
            this.lvXg.FullRowSelect = true;
            this.lvXg.GridLines = true;
            this.lvXg.Location = new System.Drawing.Point(4, 4);
            this.lvXg.Name = "lvXg";
            this.lvXg.Size = new System.Drawing.Size(472, 424);
            this.lvXg.TabIndex = 0;
            this.lvXg.View = System.Windows.Forms.View.Details;
            // 
            // chXgName
            // 
            this.chXgName.Text = "����";
            this.chXgName.Width = 90;
            // 
            // chXgDate
            // 
            this.chXgDate.Text = "����������";
            this.chXgDate.Width = 120;
            // 
            // chXgTime
            // 
            this.chXgTime.Text = "������ʱ��";
            this.chXgTime.Width = 120;
            // 
            // chCollTime
            // 
            this.chCollTime.Text = "�ɼ�ʱ��";
            this.chCollTime.Width = 130;
            // 
            // btnReadSelXgDt
            // 
            this.btnReadSelXgDt.Location = new System.Drawing.Point(488, 160);
            this.btnReadSelXgDt.Name = "btnReadSelXgDt";
            this.btnReadSelXgDt.Size = new System.Drawing.Size(88, 24);
            this.btnReadSelXgDt.TabIndex = 5;
            this.btnReadSelXgDt.Text = "��ȡ����";
            this.btnReadSelXgDt.Click += new System.EventHandler(this.btnReadSelXgDt_Click);
            // 
            // btnReadAllXgDt
            // 
            this.btnReadAllXgDt.Location = new System.Drawing.Point(488, 216);
            this.btnReadAllXgDt.Name = "btnReadAllXgDt";
            this.btnReadAllXgDt.Size = new System.Drawing.Size(88, 24);
            this.btnReadAllXgDt.TabIndex = 7;
            this.btnReadAllXgDt.Text = "��ȡȫ������";
            this.btnReadAllXgDt.Click += new System.EventHandler(this.btnReadAllXgDt_Click);
            // 
            // btnSetSelXgDt
            // 
            this.btnSetSelXgDt.Location = new System.Drawing.Point(488, 188);
            this.btnSetSelXgDt.Name = "btnSetSelXgDt";
            this.btnSetSelXgDt.Size = new System.Drawing.Size(88, 24);
            this.btnSetSelXgDt.TabIndex = 6;
            this.btnSetSelXgDt.Text = "��������";
            this.btnSetSelXgDt.Click += new System.EventHandler(this.btnSetSelXgDt_Click);
            // 
            // btnSetAllXgDt
            // 
            this.btnSetAllXgDt.Location = new System.Drawing.Point(488, 244);
            this.btnSetAllXgDt.Name = "btnSetAllXgDt";
            this.btnSetAllXgDt.Size = new System.Drawing.Size(88, 24);
            this.btnSetAllXgDt.TabIndex = 8;
            this.btnSetAllXgDt.Text = "����ȫ������";
            this.btnSetAllXgDt.Visible = false;
            // 
            // btnReadSelXgTime
            // 
            this.btnReadSelXgTime.Location = new System.Drawing.Point(488, 12);
            this.btnReadSelXgTime.Name = "btnReadSelXgTime";
            this.btnReadSelXgTime.Size = new System.Drawing.Size(88, 24);
            this.btnReadSelXgTime.TabIndex = 1;
            this.btnReadSelXgTime.Text = "��ȡʱ��";
            this.btnReadSelXgTime.Click += new System.EventHandler(this.btnReadSelXgTime_Click);
            // 
            // btnReadAllXgTime
            // 
            this.btnReadAllXgTime.Location = new System.Drawing.Point(488, 68);
            this.btnReadAllXgTime.Name = "btnReadAllXgTime";
            this.btnReadAllXgTime.Size = new System.Drawing.Size(88, 24);
            this.btnReadAllXgTime.TabIndex = 3;
            this.btnReadAllXgTime.Text = "��ȡȫ��ʱ��";
            this.btnReadAllXgTime.Click += new System.EventHandler(this.btnReadAllXgTime_Click);
            // 
            // btnSetAllXgTime
            // 
            this.btnSetAllXgTime.Location = new System.Drawing.Point(488, 96);
            this.btnSetAllXgTime.Name = "btnSetAllXgTime";
            this.btnSetAllXgTime.Size = new System.Drawing.Size(88, 24);
            this.btnSetAllXgTime.TabIndex = 4;
            this.btnSetAllXgTime.Text = "����ȫ��ʱ��";
            this.btnSetAllXgTime.Visible = false;
            // 
            // btnSetSelXgTime
            // 
            this.btnSetSelXgTime.Location = new System.Drawing.Point(488, 40);
            this.btnSetSelXgTime.Name = "btnSetSelXgTime";
            this.btnSetSelXgTime.Size = new System.Drawing.Size(88, 24);
            this.btnSetSelXgTime.TabIndex = 2;
            this.btnSetSelXgTime.Text = "����ʱ��";
            this.btnSetSelXgTime.Click += new System.EventHandler(this.btnSetSelXgTime_Click);
            // 
            // frmXGDateTimeSetting
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(582, 433);
            this.Controls.Add(this.btnSetAllXgTime);
            this.Controls.Add(this.btnSetSelXgTime);
            this.Controls.Add(this.btnReadAllXgTime);
            this.Controls.Add(this.btnReadSelXgTime);
            this.Controls.Add(this.btnSetAllXgDt);
            this.Controls.Add(this.btnSetSelXgDt);
            this.Controls.Add(this.btnReadAllXgDt);
            this.Controls.Add(this.btnReadSelXgDt);
            this.Controls.Add(this.lvXg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXGDateTimeSetting";
            this.Text = "Ѳ��ʱ�����";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmXGDateTimeSetting_Closing);
            this.Load += new System.EventHandler(this.frmXGDateTimeSetting_Load);
            this.ResumeLayout(false);

        }
		#endregion

        #region frmXGDateTimeSetting_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXGDateTimeSetting_Load(object sender, System.EventArgs e)
        {
            lvXg.Items.Clear();
            FillXgListView();
            RegisterXgChangedEvent();
        }
        #endregion //frmXGDateTimeSetting_Load

        #region RegisterXgChangedEvent
        /// <summary>
        /// 
        /// </summary>
        private void RegisterXgChangedEvent()
        {
            XGStationsCollection xgs = Singles.S.XGStsCollection;
            for( int i=0; i<xgs.Count; i++ )
            {
                XGStation xg = xgs[i];
                xg.XgCtrlDateChanged += new EventHandler(xg_XgCtrlDateChanged);
                xg.XgCtrlTimeChanged += new EventHandler(xg_XgCtrlTimeChanged);
            }
        }
        #endregion //RegisterXgChangedEvent

        #region UnregisterXgChangedEvent
        /// <summary>
        /// 
        /// </summary>
        private void UnregisterXgChangedEvent()
        {
            XGStationsCollection xgs = Singles.S.XGStsCollection;
            for( int i=0; i<xgs.Count; i++ )
            {
                XGStation xg = xgs[i];
                xg.XgCtrlDateChanged -= new EventHandler(xg_XgCtrlDateChanged);
                xg.XgCtrlTimeChanged -= new EventHandler(xg_XgCtrlTimeChanged);
            }
        }
        #endregion //UnregisterXgChangedEvent
        
        #region FillXgListView
        /// <summary>
        /// 
        /// </summary>
        private void FillXgListView()
        {
            XGStationsCollection xgStations = Singles.S.XGStsCollection;
            for( int i=0; i<xgStations.Count; i++ )
            {
                XGStation xgst = xgStations[ i ];
                if ( xgst.ServerIP == XGConfig.Default.ServerIP )
                {
                    // for test
                    //
//                    xgst.XgCtrlDate = DateTime.Now;
//                    xgst.XgCtrlTime = DateTime.Now.TimeOfDay;
//                    xgst.DtCollXgCtrlTime = DateTime.Now;
                    ListViewItem lvi = lvXg.Items.Add( xgst.StationName );
                    if( xgst.XgCtrlDate != DateTime.MinValue )
                        lvi.SubItems.Add( xgst.XgCtrlDate.Date.ToShortDateString() );
                    else
                        lvi.SubItems.Add(string.Empty);

                    if( xgst.XgCtrlTime != TimeSpan.MinValue )
                        lvi.SubItems.Add(
                            //xgst.XgCtrlTime.ToString()
                            GetTimeSpanString( xgst.XgCtrlTime) );
                    else
                        lvi.SubItems.Add(string.Empty);

                    if( xgst.DtCollXgCtrlTime != DateTime.MinValue )
                        lvi.SubItems.Add( xgst.DtCollXgCtrlTime.ToString());
                    else
                        lvi.SubItems.Add(string.Empty);

                    lvi.Tag = xgst;
                }
            }
        }
        #endregion //FillXgListView

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        private string GetTimeSpanString( TimeSpan ts )
        {
            return string.Format(
                "{0}:{1}:{2}",
                ts.Hours,
                ts.Minutes,
                ts.Seconds
                );
        }
        

        #region IsSelectedXgStation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsSelectedXgStation()
        {
            if( this.lvXg.SelectedItems.Count > 0 )
                return true;
            else
                return false;
        }
        #endregion //IsSelectedXgStation

        #region GetSelectedXg
        /// <summary>
        /// ��ȡ��ѡ�е�ListViewItem��ص�XgStation
        /// </summary>
        /// <returns></returns>
        private XGStation GetSelectedXg()
        {
            ListViewItem lvi = lvXg.SelectedItems[0];
            return lvi.Tag as XGStation;
        }
        #endregion //GetSelectedXg

        #region ShowNoStationSelected
        /// <summary>
        /// 
        /// </summary>
        private void ShowNoStationSelected()
        {
            MsgBox.Show("����ѡ��Ѳ��վ��!");
        }
        #endregion //ShowNoStationSelected

        #region ShowNotConnect
        /// <summary>
        /// 
        /// </summary>
        private void ShowNotConnect()
        {
            MsgBox.Show("��δ���վ�㽨������!");
        }
        #endregion //ShowNotConnect

        #region IsGprsConnected
        /// <summary>
        /// �жϸ�Ѳ��վ���Ƿ�������
        /// </summary>
        /// <param name="xgName"></param>
        /// <returns></returns>
        private bool IsGprsConnected( XGStation xgst )
        {
            CommPortProxysCollection cpps = Singles.S.TaskScheduler.CppsCollection;
            for( int i=0; i<cpps.Count; i++ )
            {
                CommPortProxy cpp = cpps[i];
                if ( cpp.RemoteIP == xgst.DestinationIP )
                {
                    if( cpp.IsConnected )
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        #endregion //IsGprsConnected

        #region btnReadSelXgDt_Click
        /// <summary>
        /// ��ȡѡ�е�Ѳ��������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSelXgDt_Click(object sender, System.EventArgs e)
        {
            Exe( new CommCmdMakerDelegate (GetReadDateCmd), 
                new CommCmdProcessDelegate(ProcessReadDateCmd) );
        }
        #endregion //btnReadSelXgDt_Click

        #region GetReadDateCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xgst"></param>
        /// <returns></returns>
        private CommCmdBase GetReadDateCmd( XGStation xgst )
        {
            Debug.Assert( xgst != null );
            return new ReadDateCommand( xgst );
        }
        #endregion //GetReadDateCmd

        #region ProcessReadDateCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessReadDateCmd( CommCmdBase cmd )
        {
            ReadDateCommand rdcmd = cmd as ReadDateCommand;
            Debug.Assert( rdcmd != null );

            ListViewItem lvi = this.lvXg.SelectedItems[0];
            lvi.SubItems[1].Text = string.Format(
                "20{0}-{1}-{2}",
                rdcmd.Year.ToString("d2"),
                rdcmd.Month,
                rdcmd.Day
                );
        }
        #endregion //ProcessReadDateCmd

        #region GetReadTimeCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xgst"></param>
        /// <returns></returns>
        private CommCmdBase GetReadTimeCmd( XGStation xgst )
        {
            Debug.Assert( xgst != null );
            return new ReadTimeCommand( xgst );
        }
        #endregion //GetReadTimeCmd

        #region ProcessReadTimeCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessReadTimeCmd( CommCmdBase cmd )
        {
            ReadTimeCommand rtcmd = cmd as ReadTimeCommand;
            Debug.Assert( rtcmd != null );

            ListViewItem lvi = lvXg.SelectedItems[0];
            lvi.SubItems[2].Text = string.Format(
                "{0}:{1}:{2}",
                rtcmd.Hour,
                rtcmd.Minute,
                rtcmd.Second
                );

            lvi.SubItems[3].Text = DateTime.Now.ToString();

        }
        #endregion //ProcessReadTimeCmd

        #region Exe
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccmd"></param>
        /// <param name="ccpd"></param>
        private void Exe( CommCmdMakerDelegate ccmd, CommCmdProcessDelegate ccpd )
        {
            System.Diagnostics.Debug.Assert( ccmd != null &&
                ccpd != null );

            if ( IsSelectedXgStation() )
            {
                XGStation xgst = GetSelectedXg();
                if ( IsGprsConnected( xgst ) )
                {
                    CommCmdBase cmd = ccmd( xgst );
                    TaskStrategy strategy = new ImmediateTaskStrategy();

                    Task t = new Task( cmd, strategy );
                    frmControlProcess f = new frmControlProcess( t );
                    Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( t );
                    f.ShowDialog();

                    if ( t.LastCommResultState == CommResultState.Correct )
                    {
                        ccpd( cmd );
                    }
                }
                else
                {
                    ShowNotConnect();
                }
            }
            else
            {
                ShowNoStationSelected();
            }
        }
        #endregion //Exe

        #region btnReadSelXgTime_Click
        /// <summary>
        /// ��ȡѡ�е�Ѳ����������ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadSelXgTime_Click(object sender, System.EventArgs e)
        {
            Exe( new CommCmdMakerDelegate( GetReadTimeCmd ),
                new CommCmdProcessDelegate( ProcessReadTimeCmd ) );
        }
        #endregion //btnReadSelXgTime_Click

        #region GetSetTimeCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xgst"></param>
        /// <returns></returns>
        private CommCmdBase GetSetTimeCmd( XGStation xgst )
        {
            Debug.Assert( xgst != null );
            DateTime now = DateTime.Now;

            int h = now.Hour,
                m = now.Minute,
                s = now.Second;

            return new ModifyTimeCommand( xgst, h, m, s );
        }
        #endregion //GetSetTimeCmd

        #region ProcessSetTimeCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessSetTimeCmd( CommCmdBase cmd )
        {
            // Do nothing
        }
        #endregion //ProcessSetTimeCmd

        #region GetSetDateCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xgst"></param>
        /// <returns></returns>
        private CommCmdBase GetSetDateCmd( XGStation xgst )
        {
            Debug.Assert( xgst != null );
            DateTime now = DateTime.Now;

            int y = now.Year,
                m = now.Month,
                d = now.Day;

            // 2007-11-7 Modify
            // return new ModifyTimeCommand( xgst, y, m, d );
            return new ModifyDateCommand( xgst, y, m, d );
        }
        #endregion //GetSetDateCmd

        #region ProcessSetDateCmd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        private void ProcessSetDateCmd( CommCmdBase cmd )
        {
            // Do nothing
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetSelXgTime_Click(object sender, System.EventArgs e)
        {
            Exe( new CommCmdMakerDelegate(GetSetTimeCmd),
                new CommCmdProcessDelegate(ProcessSetTimeCmd) );
        }
        #endregion //ProcessSetDateCmd

        #region btnSetSelXgDt_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetSelXgDt_Click(object sender, System.EventArgs e)
        {
            Exe( new CommCmdMakerDelegate(GetSetDateCmd),
                new CommCmdProcessDelegate(ProcessSetDateCmd) );
        }
        #endregion //btnSetSelXgDt_Click

        #region btnReadAllXgDt_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadAllXgDt_Click(object sender, System.EventArgs e)
        {
            ExeAll( new CommCmdMakerDelegate( GetReadDateCmd ) );

        }
        #endregion //btnReadAllXgDt_Click

        #region ExeAll
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccmd"></param>
        /// <param name="ccmp"></param>
        private void ExeAll( CommCmdMakerDelegate ccmd )//, CommCmdProcessDelegate ccmp )
        {
            XGStationsCollection xgstColl = Singles.S.XGStsCollection;
            for( int i=0; i<xgstColl.Count; i++ )
            {
                XGStation xgst = xgstColl[ i ];
                if ( xgst.ServerIP == XGConfig.Default.ServerIP )
                {
                    // CommCmdBase cmd = new ReadDateCommand( xgst );
                    CommCmdBase cmd = ccmd( xgst );
                    Task t = new Task( cmd, new ImmediateTaskStrategy() );
                    t.AfterProcessReceived += new EventHandler(t_AfterProcessReceived);
                    Singles.S.TaskScheduler.Tasks.Add( t );
                }
            }
            MsgBox.Show("�������ύ!");
        }
        #endregion //ExeAll

        // TODO: 2007-11-2 �ɼ���Ѳ�����������ڡ�ʱ���ǵ���ʾ
        //
        //

        #region t_AfterProcessReceived
        /// <summary>
        /// Read all xgstation Time or Date process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_AfterProcessReceived(object sender, EventArgs e)
        {
            Task t = sender as Task;

            if( t.LastCommResultState == CommResultState.Correct )
            {
                XGStation xgst = t.CommCmd.Station as XGStation;
                if ( t.CommCmd is ReadTimeCommand )
                {
                    ReadTimeCommand rtCmd = t.CommCmd as ReadTimeCommand;
                    TimeSpan xgTime = new TimeSpan(
                        0,
                        rtCmd.Hour,
                        rtCmd.Minute,
                        rtCmd.Second
                        );
                    // TODO: 2007-11-8 Ӧ������xgst.DtCollXgCtrlTime, �������
                    //      xgCtrlTimeʱ��ˢ��listview�ؼ���ʹ�õ����ϴεĲɼ�ʱ��
                    //
                    //xgst.XgCtrlTime = xgTime;
                    //xgst.DtCollXgCtrlTime = DateTime.Now;
                    xgst.DtCollXgCtrlTime = DateTime.Now;
                    xgst.XgCtrlTime = xgTime;
                }    
                else if( t.CommCmd is ReadDateCommand )
                {
                    ReadDateCommand rdCmd = t.CommCmd as ReadDateCommand;
                    DateTime xgDate = new DateTime( 
                        // 2007-11-8 Modify rdCmd.Year,
                        //
                        2000 + rdCmd.Year,
                        rdCmd.Month,
                        rdCmd.Day
                        );
                    xgst.XgCtrlDate = xgDate;
                }
            }
        }
        #endregion //t_AfterProcessReceived

        #region btnReadAllXgTime_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadAllXgTime_Click(object sender, System.EventArgs e)
        {
            ExeAll( new CommCmdMakerDelegate( GetReadTimeCmd ) );
        }
        #endregion //btnReadAllXgTime_Click

        #region FindListViewItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xg"></param>
        /// <returns></returns>
        private ListViewItem FindListViewItem( XGStation xg )
        {
            foreach( ListViewItem lvi in this.lvXg.Items )
            {
                if ( lvi.Text == xg.StationName )
                    return lvi;
            }
            return null;
        }
        #endregion //FindListViewItem

        #region xg_XgCtrlDateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xg_XgCtrlDateChanged(object sender, EventArgs e)
        {
            XGStation xg = sender as XGStation;
            ListViewItem lvi = FindListViewItem( xg );
            if ( lvi != null )
            {
                // TODO: 2007-11-8 Modify xgCtrlDate format
                lvi.SubItems[1].Text = xg.XgCtrlDate.ToString();
            }
        }
        #endregion //xg_XgCtrlDateChanged

        #region xg_XgCtrlTimeChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xg_XgCtrlTimeChanged(object sender, EventArgs e)
        {
            XGStation xg = sender as XGStation;
            ListViewItem lvi = FindListViewItem( xg );
            if (lvi != null )
            {
                // TODO: 2007-11-8 Modify xgCtrlTime format
                //
                lvi.SubItems[2].Text = xg.XgCtrlTime.ToString();
                lvi.SubItems[3].Text = xg.DtCollXgCtrlTime.ToString();
            }
        }
        #endregion //xg_XgCtrlTimeChanged

        #region frmXGDateTimeSetting_Closing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXGDateTimeSetting_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UnregisterXgChangedEvent();
        }
        #endregion //frmXGDateTimeSetting_Closing
    }
}
