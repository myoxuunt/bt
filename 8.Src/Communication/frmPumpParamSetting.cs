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
	public class frmPumpParamSetting : System.Windows.Forms.Form
	{
		#region Delegate
		private delegate CFW.CommCmdBase CommCmdMakerDelegate( XGStation xgst);
		private delegate void CommCmdProcessDelegate( CommCmdBase cmd );
		#endregion //Delegate

		#region Members

		private System.Windows.Forms.ColumnHeader chXgName;
		private System.Windows.Forms.ListView lvXg;
		private System.Windows.Forms.ColumnHeader chCycleMode;
		private System.Windows.Forms.ColumnHeader chCyclePressCha;
		private System.Windows.Forms.ColumnHeader chReMode;
		private System.Windows.Forms.ColumnHeader chRePress;
		private System.Windows.Forms.ColumnHeader chState;
		private System.Windows.Forms.Button btnReadCycle;
		private System.Windows.Forms.Button btnWriteCycle;
		private System.Windows.Forms.Button btnWriteRe;
		private System.Windows.Forms.Button btnReadRe;

		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion //Members

		public frmPumpParamSetting()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

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
			this.chXgName = new System.Windows.Forms.ColumnHeader();
			this.lvXg = new System.Windows.Forms.ListView();
			this.chCycleMode = new System.Windows.Forms.ColumnHeader();
			this.chCyclePressCha = new System.Windows.Forms.ColumnHeader();
			this.chReMode = new System.Windows.Forms.ColumnHeader();
			this.chRePress = new System.Windows.Forms.ColumnHeader();
			this.chState = new System.Windows.Forms.ColumnHeader();
			this.btnReadCycle = new System.Windows.Forms.Button();
			this.btnWriteCycle = new System.Windows.Forms.Button();
			this.btnWriteRe = new System.Windows.Forms.Button();
			this.btnReadRe = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// chXgName
			// 
			this.chXgName.Text = "����";
			this.chXgName.Width = 90;
			// 
			// lvXg
			// 
			this.lvXg.CheckBoxes = true;
			this.lvXg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																				   this.chXgName,
																				   this.chCycleMode,
																				   this.chCyclePressCha,
																				   this.chReMode,
																				   this.chRePress,
																				   this.chState});
			this.lvXg.FullRowSelect = true;
			this.lvXg.GridLines = true;
			this.lvXg.Location = new System.Drawing.Point(4, 4);
			this.lvXg.Name = "lvXg";
			this.lvXg.Size = new System.Drawing.Size(524, 424);
			this.lvXg.TabIndex = 0;
			this.lvXg.View = System.Windows.Forms.View.Details;
			// 
			// chCycleMode
			// 
			this.chCycleMode.Text = "ѭ����ģʽ";
			this.chCycleMode.Width = 94;
			// 
			// chCyclePressCha
			// 
			this.chCyclePressCha.Text = "����ѹ��";
			this.chCyclePressCha.Width = 93;
			// 
			// chReMode
			// 
			this.chReMode.Text = "��ˮ��ģʽ";
			this.chReMode.Width = 98;
			// 
			// chRePress
			// 
			this.chRePress.Text = "��ˮѹ��";
			this.chRePress.Width = 83;
			// 
			// chState
			// 
			this.chState.Text = "״̬";
			// 
			// btnReadCycle
			// 
			this.btnReadCycle.Location = new System.Drawing.Point(544, 8);
			this.btnReadCycle.Name = "btnReadCycle";
			this.btnReadCycle.Size = new System.Drawing.Size(104, 23);
			this.btnReadCycle.TabIndex = 11;
			this.btnReadCycle.Text = "��ȡѭ���ò���";
			this.btnReadCycle.Click += new System.EventHandler(this.btnReadCycle_Click);
			// 
			// btnWriteCycle
			// 
			this.btnWriteCycle.Location = new System.Drawing.Point(544, 40);
			this.btnWriteCycle.Name = "btnWriteCycle";
			this.btnWriteCycle.Size = new System.Drawing.Size(104, 23);
			this.btnWriteCycle.TabIndex = 12;
			this.btnWriteCycle.Text = "����ѭ���ò���";
			this.btnWriteCycle.Click += new System.EventHandler(this.btnWriteCycle_Click);
			// 
			// btnWriteRe
			// 
			this.btnWriteRe.Location = new System.Drawing.Point(544, 104);
			this.btnWriteRe.Name = "btnWriteRe";
			this.btnWriteRe.Size = new System.Drawing.Size(104, 23);
			this.btnWriteRe.TabIndex = 14;
			this.btnWriteRe.Text = "���ò�ˮ�ò���";
			this.btnWriteRe.Click += new System.EventHandler(this.btnWriteRe_Click);
			// 
			// btnReadRe
			// 
			this.btnReadRe.Location = new System.Drawing.Point(544, 72);
			this.btnReadRe.Name = "btnReadRe";
			this.btnReadRe.Size = new System.Drawing.Size(104, 23);
			this.btnReadRe.TabIndex = 13;
			this.btnReadRe.Text = "��ȡ��ˮ�ò���";
			this.btnReadRe.Click += new System.EventHandler(this.btnReadRe_Click);
			// 
			// frmPumpParamSetting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(658, 433);
			this.Controls.Add(this.btnWriteRe);
			this.Controls.Add(this.btnReadRe);
			this.Controls.Add(this.btnWriteCycle);
			this.Controls.Add(this.btnReadCycle);
			this.Controls.Add(this.lvXg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPumpParamSetting";
			this.Text = "��ʱ��������";
			this.Load += new System.EventHandler(this.frmTimeTempSetting_Load);
			this.ResumeLayout(false);

		}
		#endregion



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
			GRStationsCollection grStations = Singles.S.GRStsCollection;
			for( int i=0; i<grStations.Count; i++ )
			{
				GRStation grst = grStations[ i ];
				if( Singles.S.CommPortProxyCollection.IsConnected ( grst.DestinationIP ) )
					//                if ( grst.ServerIP == XGConfig.Default.ServerIP )
				{
					ListViewItem lvi = lvXg.Items.Add( grst.StationName );
					lvi.SubItems.Add(""); // cycle mode
					lvi.SubItems.Add(""); // cycle param
					lvi.SubItems.Add(""); // re mode
					lvi.SubItems.Add(""); // re param
					lvi.SubItems.Add(""); // state
					
					lvi.Tag = grst;
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmTimeTempSetting_Load(object sender, System.EventArgs e)
		{
			lvXg.Items.Clear();
			FillXgListView();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRead_Click(object sender, System.EventArgs e)
		{
			ArrayList list = new ArrayList();
			foreach( ListViewItem lvi in this.lvXg.Items )
			{
				if( lvi.Checked )
				{
					list.Add( lvi.Tag as GRStation );
				}
			}

			if( list.Count > 0 )
			{
				for( int i=0; i<list.Count; i++ )
				{
					GRStation grst = list[i] as GRStation;
					GRReadTLCommand cmd = new GRReadTLCommand( grst );
					Task task = new Task( cmd, new ImmediateTaskStrategy () );
					
					Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
					task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
				}
				MessageBox.Show( "�������ύ", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
			else
			{
				MessageBox.Show("����ѡ��վ��", "��ʾ", 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnReadSelXgDt_Click_1(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void task_AfterProcessReceived(object sender, EventArgs e)
		{
			Task t =  sender as Task;
			GRStation grst = t.CommCmd.Station as GRStation;
			if( grst != null )
			{			
				ListViewItem lvi = GetLviByGRStation( grst );

				if( t.LastCommResultState == CommResultState.Correct )
				{
//					GRReadTLCommand grreadtlcmd = t.CommCmd as GRReadTLCommand;
//					if( grreadtlcmd != null )
//					{
//						lvi.SubItems[1].Text = grreadtlcmd.TimeTempLine.ToString();
//						lvi.SubItems[2].Text = "��ȡ�ɹ�";
//					}
//
//					GRWriteTimeTempLine grwritetimetemplinecmd = t.CommCmd as GRWriteTimeTempLine ;
//					if( grwritetimetemplinecmd != null )
//					{
//						lvi.SubItems[1].Text = grwritetimetemplinecmd.TimeTempLine.ToString();
//						lvi.SubItems[2].Text = "���óɹ�";
//					}
					GRReadTwoPressChaCommand grreadtwopresscha = t.CommCmd as GRReadTwoPressChaCommand;
					if( grreadtwopresscha != null )
					{
						lvi.SubItems[1].Text = grreadtwopresscha.CyclePumpCtrlMode.ToString();
						lvi.SubItems[2].Text = grreadtwopresscha.PressChaSet.ToString();
						lvi.SubItems[5].Text = "��ȡ�ɹ�";
					}

					GRWriteTwoPressChaCommand grwritetwopresscha = t.CommCmd as GRWriteTwoPressChaCommand;
					if( grwritetwopresscha != null )
					{
						lvi.SubItems[1].Text = grwritetwopresscha.CyclePumpCtrlMode.ToString();
						lvi.SubItems[2].Text = grwritetwopresscha.PressChaSet.ToString();
						lvi.SubItems[5].Text = "���óɹ�";
					}

					GRReadRepumpPressSettings grreadrepumppresssetting = t.CommCmd as GRReadRepumpPressSettings;
					if( grreadrepumppresssetting != null )
					{
						lvi.SubItems[3].Text = grreadrepumppresssetting.Mode.ToString();
						lvi.SubItems[4].Text = grreadrepumppresssetting.RePressSet.ToString();
						lvi.SubItems[5].Text = "��ȡ�ɹ�";
					}

					GRWriteRepumpPressSettings grwriterepumppressseting = t.CommCmd as GRWriteRepumpPressSettings;
					if( grwriterepumppressseting != null )
					{
						lvi.SubItems[3].Text = grwriterepumppressseting.RepumpMode.ToString();
						lvi.SubItems[4].Text = grwriterepumppressseting.PressSet.ToString();
						lvi.SubItems[5].Text = "���óɹ�";
					}
				}
				else
				{
					lvi.SubItems[5].Text = GetCommResultTextDetail( t.LastCommResultState );
				}
			}
		}

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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="st"></param>
		/// <returns></returns>
		private ListViewItem GetLviByGRStation ( GRStation st )
		{
			if( st == null )
				throw new ArgumentNullException("st");
			foreach( ListViewItem lvi in this.lvXg.Items )
			{
				if( lvi.Tag == st )
				{
					return lvi;
				}
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnWrite_Click(object sender, System.EventArgs e)
		{
			ArrayList list = new ArrayList();
			foreach( ListViewItem lvi in this.lvXg.Items )
			{
				if( lvi.Checked )
				{
					list.Add( lvi.Tag as GRStation );
				}
			}

			if( list.Count > 0 )
			{
				frmTimeTempPointSetting frmTtps = new frmTimeTempPointSetting();
				DialogResult dr = frmTtps.ShowDialog( this );
				if( dr == DialogResult.OK )
				{
					for( int i=0; i<list.Count; i++ )
					{
						GRStation grst = list[i] as GRStation;
						//						GRReadTLCommand cmd = new GRReadTLCommand( grst );
						//						GRWriteTLCommand cmd = new GRWriteTLCommand( grst,
						//							null,
						//							frmTtps.TimeTempLine );
						GRWriteTimeTempLine cmd = new GRWriteTimeTempLine( grst,
							frmTtps.TimeTempLine );
						Task task = new Task( cmd, new ImmediateTaskStrategy () );
					
						Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
						task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
					}
					MessageBox.Show( "�������ύ", "��ʾ",
						MessageBoxButtons.OK, MessageBoxIcon.Information );
				}
			}
			else
			{
				MessageBox.Show("����ѡ��վ��", "��ʾ", 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}



		// ===============================================
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReadCycle_Click(object sender, System.EventArgs e)
		{
			GRStation[] sts = this.GetSelectGRStations();
			if( sts.Length > 0 )
			{
				foreach( GRStation st in sts )
				{
					GRReadTwoPressChaCommand cmd = new GRReadTwoPressChaCommand( st );
					Task task = new Task( cmd, new ImmediateTaskStrategy() );
					task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
					Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
				}
				MessageBox.Show( "�������ύ", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Information );

			}
			else
			{
				MessageBox.Show("��ѡ��վ��", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		private GRStation[] GetSelectGRStations()
		{
			ArrayList list = new ArrayList();
			foreach( ListViewItem lvi in this.lvXg.Items )
			{
				if( lvi.Checked )
				{
					list.Add( lvi.Tag );
				}
			}
			
			if( list.Count > 0 )
			{
				return (GRStation[])list.ToArray( typeof(GRStation) );
			}
			else
			{
				return new GRStation[0];
			}
			
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnWriteCycle_Click(object sender, System.EventArgs e)
		{
			GRStation[] sts = this.GetSelectGRStations();
			if( sts.Length > 0 )
			{
				CyclePumpMode mode = CyclePumpMode.PID����;
				float pressChaSet = 0;

				frmCycleParam f = new frmCycleParam();
				DialogResult dr = f.ShowDialog( this );
				if( dr == DialogResult.OK )
				{
					mode = f.Mode;
					pressChaSet = f.PressCha;

					foreach( GRStation st in sts )
					{
						//					GRReadTwoPressChaCommand cmd = new GRReadTwoPressChaCommand( st );
						GRWriteTwoPressChaCommand cmd = new GRWriteTwoPressChaCommand( st, 
							mode,
							pressChaSet,
							0 );
						Task task = new Task( cmd, new ImmediateTaskStrategy() );
						task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
						Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
					}
					MessageBox.Show( "�������ύ", "��ʾ",
						MessageBoxButtons.OK, MessageBoxIcon.Information );
				}
			}
			else
			{
				MessageBox.Show("��ѡ��վ��", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReadRe_Click(object sender, System.EventArgs e)
		{
			GRStation[] sts = this.GetSelectGRStations();
			if( sts.Length > 0 )
			{
				foreach( GRStation st in sts )
				{
					//GRReadTwoPressChaCommand cmd = new GRReadTwoPressChaCommand( st );
					GRReadRepumpPressSettings cmd = new GRReadRepumpPressSettings(st );
					Task task = new Task( cmd, new ImmediateTaskStrategy() );
					task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
					Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
				}
				MessageBox.Show( "�������ύ", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
			else
			{
				MessageBox.Show("��ѡ��վ��", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnWriteRe_Click(object sender, System.EventArgs e)
		{
			GRStation[] sts = this.GetSelectGRStations();
			if( sts.Length > 0 )
			{
				frmReParam f = new frmReParam();
				DialogResult dr = f.ShowDialog(this);
				if( dr == DialogResult.OK )
				{
					RePumpMode mode = f.Mode;
					float pressset = f.Pressset;

					foreach( GRStation st in sts )
					{
						//GRReadTwoPressChaCommand cmd = new GRReadTwoPressChaCommand( st );
						//					GRReadRepumpPressSettings cmd = new GRReadRepumpPressSettings(st );
						GRWriteRepumpPressSettings cmd = new GRWriteRepumpPressSettings( st,
							mode,
							pressset );
						Task task = new Task( cmd, new ImmediateTaskStrategy() );
						task.AfterProcessReceived += new EventHandler(task_AfterProcessReceived);
						Singles.S.TaskScheduler.Tasks.AddFirstExectueTask( task );
					}
				
					MessageBox.Show( "�������ύ", "��ʾ",
						MessageBoxButtons.OK, MessageBoxIcon.Information );
				}
			}
			else
			{
				MessageBox.Show("��ѡ��վ��", "��ʾ",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
			}
		}
	}
}
