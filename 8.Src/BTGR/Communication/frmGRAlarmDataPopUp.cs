

namespace Communication
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Communication.GRCtrl ;

    #region frmGRAlarmDataPopUp
	/// <summary>
	/// 实时报警数据弹出窗口，当收到供热控制器发出的报警数据时，弹出此窗体，并显示相应的报警信息.
	/// </summary>
	public class frmGRAlarmDataPopUp : System.Windows.Forms.Form
	{
        #region Members
        static private frmGRAlarmDataPopUp s_default = new frmGRAlarmDataPopUp();
        private System.Windows.Forms.ListView lvGRAD;
        private System.Windows.Forms.ColumnHeader chGRStationName;
        private System.Windows.Forms.ColumnHeader chDateTime;
        private System.Windows.Forms.ColumnHeader chAlarmName;
        private System.Windows.Forms.ColumnHeader chAlarmDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader chGRStationAddress;
        private System.Windows.Forms.ColumnHeader chGRStationIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblGrStationName;
        private System.Windows.Forms.Label lblGrStationIP;
        private System.Windows.Forms.Label lblGrStationAddress;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblGrAlarmName;
        private System.Windows.Forms.Label lblGrAlarmDescription;

        private string _grStName;
        private string _remoteIP;
        private int    _address; 

        /// <summary>
        /// 自动上报的报警数据可能包含两种形式的内容，报警产生和报警解除，报警解除类的数据中部没有报警
        /// </summary>
        private bool _isIncludeAlarm = false;

        private System.Windows.Forms.CheckBox chkTopMost;
        private System.ComponentModel.Container components = null;
        private int _alarmCount;
        private System.Windows.Forms.CheckBox checkBox1;
        private AxMCI.AxMMControl axMMControl1;
        private int MAX_COUNT = 100;


        private const string OPEN       = "open";
        private const string CLOSE      = "close";
        private const string PLAY       = "play";
        #endregion //Members
        
        #region Default
        static public frmGRAlarmDataPopUp Default
        {
            get { return s_default; }
        }
        #endregion //Default

        #region Constructor
		public frmGRAlarmDataPopUp()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
        #endregion //Constructor

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGRAlarmDataPopUp));
            this.lvGRAD = new System.Windows.Forms.ListView();
            this.chGRStationName = new System.Windows.Forms.ColumnHeader();
            this.chGRStationIP = new System.Windows.Forms.ColumnHeader();
            this.chGRStationAddress = new System.Windows.Forms.ColumnHeader();
            this.chDateTime = new System.Windows.Forms.ColumnHeader();
            this.chAlarmName = new System.Windows.Forms.ColumnHeader();
            this.chAlarmDescription = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGrStationName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGrStationIP = new System.Windows.Forms.Label();
            this.lblGrStationAddress = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblGrAlarmName = new System.Windows.Forms.Label();
            this.lblGrAlarmDescription = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.axMMControl1 = new AxMCI.AxMMControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMMControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvGRAD
            // 
            this.lvGRAD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                     this.chGRStationName,
                                                                                     this.chGRStationIP,
                                                                                     this.chGRStationAddress,
                                                                                     this.chDateTime,
                                                                                     this.chAlarmName,
                                                                                     this.chAlarmDescription});
            this.lvGRAD.FullRowSelect = true;
            this.lvGRAD.GridLines = true;
            this.lvGRAD.Location = new System.Drawing.Point(0, 0);
            this.lvGRAD.MultiSelect = false;
            this.lvGRAD.Name = "lvGRAD";
            this.lvGRAD.Size = new System.Drawing.Size(688, 216);
            this.lvGRAD.TabIndex = 0;
            this.lvGRAD.View = System.Windows.Forms.View.Details;
            this.lvGRAD.SelectedIndexChanged += new System.EventHandler(this.lvGRAD_SelectedIndexChanged);
            // 
            // chGRStationName
            // 
            this.chGRStationName.Text = "站名";
            this.chGRStationName.Width = 90;
            // 
            // chGRStationIP
            // 
            this.chGRStationIP.Text = "站点IP";
            this.chGRStationIP.Width = 90;
            // 
            // chGRStationAddress
            // 
            this.chGRStationAddress.Text = "站点地址";
            // 
            // chDateTime
            // 
            this.chDateTime.Text = "时间";
            this.chDateTime.Width = 120;
            // 
            // chAlarmName
            // 
            this.chAlarmName.Text = "报警名称";
            this.chAlarmName.Width = 90;
            // 
            // chAlarmDescription
            // 
            this.chAlarmDescription.Text = "报警描述";
            this.chAlarmDescription.Width = 230;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblGrStationName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblGrStationIP);
            this.groupBox1.Controls.Add(this.lblGrStationAddress);
            this.groupBox1.Controls.Add(this.lblDateTime);
            this.groupBox1.Controls.Add(this.lblGrAlarmName);
            this.groupBox1.Controls.Add(this.lblGrAlarmDescription);
            this.groupBox1.Location = new System.Drawing.Point(8, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // lblGrStationName
            // 
            this.lblGrStationName.Location = new System.Drawing.Point(88, 24);
            this.lblGrStationName.Name = "lblGrStationName";
            this.lblGrStationName.Size = new System.Drawing.Size(192, 23);
            this.lblGrStationName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(288, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "报警描述：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(288, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "时间：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(288, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "报警名称：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "站点地址：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "站点IP：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "站名：";
            // 
            // lblGrStationIP
            // 
            this.lblGrStationIP.Location = new System.Drawing.Point(88, 56);
            this.lblGrStationIP.Name = "lblGrStationIP";
            this.lblGrStationIP.Size = new System.Drawing.Size(192, 23);
            this.lblGrStationIP.TabIndex = 6;
            // 
            // lblGrStationAddress
            // 
            this.lblGrStationAddress.Location = new System.Drawing.Point(88, 88);
            this.lblGrStationAddress.Name = "lblGrStationAddress";
            this.lblGrStationAddress.Size = new System.Drawing.Size(192, 23);
            this.lblGrStationAddress.TabIndex = 6;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(360, 24);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(280, 23);
            this.lblDateTime.TabIndex = 6;
            // 
            // lblGrAlarmName
            // 
            this.lblGrAlarmName.Location = new System.Drawing.Point(360, 56);
            this.lblGrAlarmName.Name = "lblGrAlarmName";
            this.lblGrAlarmName.Size = new System.Drawing.Size(280, 23);
            this.lblGrAlarmName.TabIndex = 6;
            // 
            // lblGrAlarmDescription
            // 
            this.lblGrAlarmDescription.Location = new System.Drawing.Point(360, 88);
            this.lblGrAlarmDescription.Name = "lblGrAlarmDescription";
            this.lblGrAlarmDescription.Size = new System.Drawing.Size(280, 23);
            this.lblGrAlarmDescription.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(608, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(520, 368);
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.Location = new System.Drawing.Point(16, 368);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.TabIndex = 4;
            this.chkTopMost.Text = "总在最前";
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(144, 368);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "报警时激活";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // axMMControl1
            // 
            this.axMMControl1.Enabled = true;
            this.axMMControl1.Location = new System.Drawing.Point(368, 16);
            this.axMMControl1.Name = "axMMControl1";
            this.axMMControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMMControl1.OcxState")));
            this.axMMControl1.Size = new System.Drawing.Size(236, 23);
            this.axMMControl1.TabIndex = 6;
            this.axMMControl1.Visible = false;
            // 
            // frmGRAlarmDataPopUp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(690, 402);
            this.Controls.Add(this.axMMControl1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvGRAD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGRAlarmDataPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实时报警数据";
            this.TopMost = true;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmGRAlarmDataPopUp_Closing);
            this.Load += new System.EventHandler(this.frmGRAlarmDataPopUp_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMMControl1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        #region frmGRAlarmDataPopUp_Load
        private void frmGRAlarmDataPopUp_Load(object sender, System.EventArgs e)
        {
            this.TopMost = false;
            this.chkTopMost.Checked = this.TopMost;
            this.checkBox1.Checked = this._activeWhenAlarm;
            this.axMMControl1.Done += new AxMCI.DmciEvents_DoneEventHandler(axMMControl1_Done);
        }
        #endregion //frmGRAlarmDataPopUp_Load
        
        #region CONST TEXT
        private const string N1 = "1";
        private const string N2 = "2";
        private const string N3 = "3";

        private const string CYCLE_PUMP         = "循环泵";
        private const string CYCLE_PUMP_1       = CYCLE_PUMP + N1; 
        private const string CYCLE_PUMP_2       = CYCLE_PUMP + N2; 
        private const string CYCLE_PUMP_3       = CYCLE_PUMP + N3; 

        private const string RECRUIT_PUMP       = "补水泵";
        private const string RECRUIT_PUMP_1     = RECRUIT_PUMP + N1;
        private const string RECRUIT_PUMP_2     = RECRUIT_PUMP + N2;


        private const string ALARM_FAULT        = "故障报警";
        private const string ALARM_LO_PRESS     = "低压报警";
        private const string ALARM_HI_PRESS     = "高压报警";
        private const string ALARM_LO_TEMP      = "低温报警";
        private const string ALARM_HI_TEMP      = "高温报警";
        private const string ALARM_LO_WL        = "水位低报警";
        private const string ALARM_HI_WL        = "水位高报警";
        private const string ALARM_POWEROFF     = "掉电报警";

        private const string POWER              = "电源";
        private const string PRESS              = "压力";
        private const string TEMP               = "温度";
        private const string WATER_BOX          = "水箱";
        private const string WL                 = "水位";
        private const string WATER_BOX_WL       = WATER_BOX + WL;


        private const string ONE                = "一次";
        private const string TWO                = "二次";

        private const string GIVE               = "供水";
        private const string BACK               = "回水";
        private const string ONE_GIVE_PRESS     = ONE + GIVE + PRESS;
        private const string ONE_BACK_PRESS     = ONE + BACK + PRESS;
        private const string ONE_GIVE_TEMP      = ONE + GIVE + TEMP;
        private const string ONE_BACK_TEMP      = ONE + BACK + TEMP;

        private const string TWO_GIVE_PRESS     = TWO + GIVE + PRESS;
        private const string TWO_BACK_PRESS     = TWO + BACK + PRESS;
        private const string TWO_GIVE_TEMP      = TWO + GIVE + TEMP;
        private const string TWO_BACK_TEMP      = TWO + BACK + TEMP;
        #endregion //CONST TEXT

        #region AddGrAlarmData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grStName"></param>
        /// <param name="rd"></param>
        public void AddGrAlarmData ( string grStName, string remoteIP, int address, GRAlarmData ad )
        {
            //假定上报报警数据中不包含报警
            //
            this._isIncludeAlarm = false;

            ArgumentChecker.CheckNotNull( ad );
            _grStName = grStName ;
            _remoteIP = remoteIP;
            _address = address;

            if ( ad.cycPump1  )
                AddLvi( CYCLE_PUMP_1 , ALARM_FAULT ); 
            if ( ad.cycPump2 )
                AddLvi( CYCLE_PUMP_2 , ALARM_FAULT );    
            if ( ad.cycPump3 )
                AddLvi( CYCLE_PUMP_3 , ALARM_FAULT ); 
            if ( ad.oneGivePress_lo )
                AddLvi( ONE_GIVE_PRESS, ALARM_LO_PRESS );
            if ( ad.oneGiveTemp_lo )
                AddLvi( ONE_GIVE_TEMP, ALARM_LO_TEMP ); 
            if ( ad.powerOff )
                AddLvi( POWER, ALARM_POWEROFF );
            if ( ad.recruitPump1 )
                AddLvi ( RECRUIT_PUMP_1 , ALARM_FAULT );
            if ( ad.recruitPump2 )
                AddLvi ( RECRUIT_PUMP_2 , ALARM_FAULT );
            if ( ad.twoBackPress_hi )
                AddLvi ( TWO_BACK_PRESS, ALARM_HI_PRESS );
            if ( ad.twoBackPress_lo )
                AddLvi(  TWO_BACK_PRESS, ALARM_LO_PRESS );
            if ( ad.twoGivePress_hi )
                AddLvi( TWO_GIVE_PRESS, ALARM_HI_PRESS );
            if ( ad.twoGiveTemp_hi )
                AddLvi( TWO_GIVE_TEMP, ALARM_HI_TEMP );
            if ( ad.watLevel_hi )
                AddLvi( WATER_BOX_WL, ALARM_HI_WL );
            if ( ad.watLevel_lo )
                AddLvi( WATER_BOX_WL,  ALARM_LO_WL );


            if ( !_isIncludeAlarm )
            {
                AddLviNoAlarm( "无", "报警解除" );
            }

            if ( !this.Visible )
            {
                this.Show();
            }

            if ( _activeWhenAlarm )
                this.Activate();

            if ( _isIncludeAlarm )
                PlaySound();
        }
        #endregion //AddGrAlarmData

        #region PlaySound
        /// <summary>
        /// 
        /// </summary>
        private void PlaySound()
        {
            try
            {
                this.axMMControl1.DeviceType = "WaveAudio";
                string wavFile = XGConfig.Default.AlarmPopupWavFile;

                //this.axMMControl1.FileName = XGConfig.Default.AlarmPopupWavFile;
                if ( wavFile != null && wavFile != string.Empty )
                {
                    axMMControl1.FileName = wavFile ;
                    axMMControl1.Command = OPEN;
                    axMMControl1.Command = PLAY ;
                }
            }
            catch ( Exception ex )
            {
                MsgBox.Show(ex.ToString() );
                this.axMMControl1.Command = CLOSE;
            }
        }
        #endregion //PlaySound

        #region AddLvi
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarmName"></param>
        /// <param name="description"></param>
        private void AddLvi( string alarmName, string description )
        {
            if ( _alarmCount >= MAX_COUNT )
                this.btnClear_Click( this, EventArgs.Empty );
            IncreaseAlarmCount();

            ListViewItem lvi = lvGRAD.Items.Add( _grStName );
            string [] s = new string[] {_remoteIP,
                _address.ToString(), DateTime.Now.ToString(), alarmName, description };

            lvi.SubItems.AddRange( s );

            // 2007.03.06 Added 
            //
            this._isIncludeAlarm = true;
        }
        #endregion //AddLvi

        #region AddLviNoAlarm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarmName"></param>
        /// <param name="description"></param>
        private void AddLviNoAlarm( string alarmName, string description )
        {
            if ( _alarmCount >= MAX_COUNT )
                this.btnClear_Click( this, EventArgs.Empty );
            IncreaseAlarmCount();


            ListViewItem lvi = lvGRAD.Items.Add( _grStName );
            string [] s = new string[] {_remoteIP,
                                           _address.ToString(), DateTime.Now.ToString(), alarmName, description };

            lvi.SubItems.AddRange( s );
        }
        #endregion //AddLviNoAlarm

        #region IncreaseAlarmCount
        private void IncreaseAlarmCount()
        {
            _alarmCount++;
        }
        #endregion //IncreaseAlarmCount

        #region btnClear_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, System.EventArgs e)
        {
            ClearListView();
            ClearDetail();
            _alarmCount = 0;
        }
        #endregion //btnClear_Click

        #region ClearListView
        /// <summary>
        /// 
        /// </summary>
        private void ClearListView()
        {
            this.lvGRAD.Items.Clear();
        }
        #endregion //ClearListView

        #region ClearDetail
        /// <summary>
        /// 
        /// </summary>
        private void ClearDetail()
        {
            this.lblGrStationName.Text      = string.Empty;
            this.lblGrStationIP.Text        = string.Empty;
            this.lblGrStationAddress.Text   = string.Empty;
            this.lblDateTime.Text           = string.Empty;
            this.lblGrAlarmName.Text        = string.Empty;
            this.lblGrAlarmDescription.Text = string.Empty;
        }
        #endregion //ClearDetail

        #region btnClose_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, System.EventArgs e)
        {
            ClearListView();
            ClearDetail();
            CloseMedia();
            this.Hide();
            
        }
        #endregion //btnClose_Click

        #region CloseMedia
        /// <summary>
        /// 
        /// </summary>
        private void CloseMedia()
        {
            this.axMMControl1.Command = CLOSE; 
        }
        #endregion //CloseMedia

        #region lvGRAD_SelectedIndexChanged
        private void lvGRAD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ( lvGRAD.SelectedItems.Count > 0 )
            {
                int i=1;
                ListViewItem lvi = lvGRAD.SelectedItems[0];
                this.lblGrStationName.Text = lvi.Text;

                this.lblGrStationIP.Text        = lvi.SubItems[i++].Text;
                this.lblGrStationAddress.Text   = lvi.SubItems[i++].Text;
                this.lblDateTime.Text           = lvi.SubItems[i++].Text ;
                this.lblGrAlarmName.Text        = lvi.SubItems[i++].Text;
                this.lblGrAlarmDescription.Text = lvi.SubItems[i++].Text;
            }
        }
        #endregion //lvGRAD_SelectedIndexChanged

        #region chkTopMost_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTopMost_CheckedChanged(object sender, System.EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;        
        }
        #endregion //chkTopMost_CheckedChanged

        #region frmGRAlarmDataPopUp_Closing
        private void frmGRAlarmDataPopUp_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.CloseMedia();
            this.Hide();
        }
        #endregion //frmGRAlarmDataPopUp_Closing

        bool _activeWhenAlarm = true;

        #region checkBox1_CheckedChanged
        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            _activeWhenAlarm = this.checkBox1.Checked;
        }
        #endregion //checkBox1_CheckedChanged

        #region axMMControl1_Done
        private void axMMControl1_Done(object sender, AxMCI.DmciEvents_DoneEvent e)
        {
            short noifyValue = axMMControl1.NotifyValue;
            if ( noifyValue == 1 )
            {
                //this.axMMControl1.Command = CLOSE;
                CloseMedia();
            }
            //if ( notify
        }
        #endregion //axMMControl1_Done

        // for test wav play
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.AddGrAlarmData("T","1.1.1.1", 1, GRAlarmData.s_test );
        }
    }
    #endregion //frmGRAlarmDataPopUp
}
