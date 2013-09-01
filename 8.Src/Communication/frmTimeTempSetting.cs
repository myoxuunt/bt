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
	/// frmXGDateTimeSetting 的摘要说明。
	/// </summary>
	public class frmTimeTempSetting : System.Windows.Forms.Form
	{
		#region Delegate
		private delegate CFW.CommCmdBase CommCmdMakerDelegate( XGStation xgst);
		private delegate void CommCmdProcessDelegate( CommCmdBase cmd );
		#endregion //Delegate

		#region Members
		private System.Windows.Forms.ColumnHeader chXgName;
		private System.Windows.Forms.ListView lvXg;
		private System.Windows.Forms.ColumnHeader chTimeTempLine;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnWrite;
		private System.Windows.Forms.ColumnHeader chState;

		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion //Members

		public frmTimeTempSetting()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

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
			this.lvXg = new System.Windows.Forms.ListView();
			this.chXgName = new System.Windows.Forms.ColumnHeader();
			this.chTimeTempLine = new System.Windows.Forms.ColumnHeader();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnWrite = new System.Windows.Forms.Button();
			this.chState = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvXg
			// 
			this.lvXg.CheckBoxes = true;
			this.lvXg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																				   this.chXgName,
																				   this.chTimeTempLine,
																				   this.chState});
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
			this.chXgName.Text = "名称";
			this.chXgName.Width = 90;
			// 
			// chTimeTempLine
			// 
			this.chTimeTempLine.Text = "分时供热";
			this.chTimeTempLine.Width = 294;
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(488, 8);
			this.btnRead.Name = "btnRead";
			this.btnRead.Size = new System.Drawing.Size(88, 23);
			this.btnRead.TabIndex = 9;
			this.btnRead.Text = "读取分时数据";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnWrite
			// 
			this.btnWrite.Location = new System.Drawing.Point(488, 40);
			this.btnWrite.Name = "btnWrite";
			this.btnWrite.Size = new System.Drawing.Size(88, 23);
			this.btnWrite.TabIndex = 10;
			this.btnWrite.Text = "设置分时数据";
			this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
			// 
			// chState
			// 
			this.chState.Text = "状态";
			this.chState.Width = 76;
			// 
			// frmTimeTempSetting
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(582, 433);
			this.Controls.Add(this.btnWrite);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.lvXg);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmTimeTempSetting";
			this.Text = "分时供热设置";
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
					lvi.SubItems.Add(""); // time - temp value
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
		/// 获取与选中的ListViewItem相关的XgStation
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
			MsgBox.Show("请先选择巡更站点!");
		}
		#endregion //ShowNoStationSelected

		#region ShowNotConnect
		/// <summary>
		/// 
		/// </summary>
		private void ShowNotConnect()
		{
			MsgBox.Show("尚未与该站点建立连接!");
		}
		#endregion //ShowNotConnect

		#region IsGprsConnected
		/// <summary>
		/// 判断该巡更站点是否已连接
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
		/// 读取选中的巡更控制器的日期
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
		/// 读取选中的巡更控制器的时间
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
			MsgBox.Show("命令已提交!");
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
					// TODO: 2007-11-8 应先设置xgst.DtCollXgCtrlTime, 否则更新
					//      xgCtrlTime时候，刷新listview控件是使用的是上次的采集时间
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
				MessageBox.Show( "命令已提交", "提示",
					MessageBoxButtons.OK, MessageBoxIcon.Information );
			}
			else
			{
				MessageBox.Show("请先选择站点", "提示", 
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
					GRReadTLCommand grreadtlcmd = t.CommCmd as GRReadTLCommand;
					if( grreadtlcmd != null )
					{
						lvi.SubItems[1].Text = grreadtlcmd.TimeTempLine.ToString();
						lvi.SubItems[2].Text = "读取成功";
					}

					GRWriteTimeTempLine grwritetimetemplinecmd = t.CommCmd as GRWriteTimeTempLine ;
					if( grwritetimetemplinecmd != null )
					{
						lvi.SubItems[1].Text = grwritetimetemplinecmd.TimeTempLine.ToString();
						lvi.SubItems[2].Text = "设置成功";
					}
				}
				else
				{
					lvi.SubItems[1].Text = "";
					lvi.SubItems[2].Text = GetCommResultTextDetail( t.LastCommResultState );
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
					MessageBox.Show( "命令已提交", "提示",
						MessageBoxButtons.OK, MessageBoxIcon.Information );
				}
			}
			else
			{
				MessageBox.Show("请先选择站点", "提示", 
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}
}
