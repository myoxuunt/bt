

namespace Communication
{

    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using Communication.GRCtrl;

    #region frmXGStationManager
	/// <summary>
	/// frmXGStationManager 的摘要说明。
	/// </summary>
	public class frmXGStationManager : System.Windows.Forms.Form
	{
        #region Members

        private System.Windows.Forms.DataGrid dataGridGPRSStation;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton tbbAdd;
        private System.Windows.Forms.ToolBarButton tbbEdit;
        private System.Windows.Forms.ToolBarButton tbbDelete;
        private System.Windows.Forms.ToolBarButton tbbExit;
        private System.ComponentModel.IContainer components;
        #endregion //Members

        #region frmXGStationManager
		public frmXGStationManager()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
//            this.btnAdd.Visible = false;
//            this.btnEdit.Visible = false;
//            this.btnDelete.Visible = false;
            this.dataGridGPRSStation.Dock = DockStyle.Fill;
		}
        #endregion //frmXGStationManager

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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmXGStationManager));
            this.dataGridGPRSStation = new System.Windows.Forms.DataGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbbAdd = new System.Windows.Forms.ToolBarButton();
            this.tbbEdit = new System.Windows.Forms.ToolBarButton();
            this.tbbDelete = new System.Windows.Forms.ToolBarButton();
            this.tbbExit = new System.Windows.Forms.ToolBarButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGPRSStation)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridGPRSStation
            // 
            this.dataGridGPRSStation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridGPRSStation.DataMember = "";
            this.dataGridGPRSStation.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridGPRSStation.Location = new System.Drawing.Point(96, 128);
            this.dataGridGPRSStation.Name = "dataGridGPRSStation";
            this.dataGridGPRSStation.Size = new System.Drawing.Size(624, 372);
            this.dataGridGPRSStation.TabIndex = 4;
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                        this.tbbAdd,
                                                                                        this.tbbEdit,
                                                                                        this.tbbDelete,
                                                                                        this.tbbExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(872, 41);
            this.toolBar1.TabIndex = 8;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbbAdd
            // 
            this.tbbAdd.ImageIndex = 0;
            this.tbbAdd.Text = "添加";
            // 
            // tbbEdit
            // 
            this.tbbEdit.ImageIndex = 1;
            this.tbbEdit.Text = "修改";
            // 
            // tbbDelete
            // 
            this.tbbDelete.ImageIndex = 2;
            this.tbbDelete.Text = "删除";
            // 
            // tbbExit
            // 
            this.tbbExit.ImageIndex = 3;
            this.tbbExit.Text = "退出";
            // 
            // frmXGStationManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(872, 597);
            this.Controls.Add(this.dataGridGPRSStation);
            this.Controls.Add(this.toolBar1);
            this.Name = "frmXGStationManager";
            this.Text = "站点管理";
            this.Load += new System.EventHandler(this.frmXGStationManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGPRSStation)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion


        #region InitForm
        private void InitForm()
        {
            dataGridGPRSStation.ReadOnly = true;
//            string[] colNames = new string[] {"grstation_id", "name", "team", "addDrug", "heatArea", "ip", "gr_address", "xg_address", "serverIp", "remark", };
            string[] colNames = new string[] {"gprs_station_id", "name", "team", "addDrug", "heatArea", "ip", "gr_address", "xg_address", "serverIp", "remark", };
            string[] showNames = new string[] {"编号", "站名", "所属班组", "加药方式", "供热面积", "IP地址","供热控制器地址","巡更控制器地址","服务器IP地址","备注"};
            int [] columnWidth = new int[] {50, 100, 60,60,60, 100, 120, 120, 100, 100 };
            DataGridTableStyle dgts = Misc.CreateDataGridTableStyle ( "Table", colNames, showNames, null, columnWidth );
            this.dataGridGPRSStation.TableStyles.Add( dgts );

            LoadXGStationFromDB();
        }
        #endregion //InitForm

        #region LoadXGStationFromDB
        private void LoadXGStationFromDB()
        {
            // TODO: is gprs_station_id ?
            //
            //string sql = string.Format(@"SELECT grstation_id, name, ip,  commport, gr_address, xg_address, remark 
//            string sql = string.Format(@"SELECT grstation_id, name, team, addDrug, heatArea, ip,  gr_address, xg_address, serverIp, remark 
            string sql = string.Format(@"SELECT gprs_station_id, name, team, addDrug, heatArea, ip,  gr_address, xg_address, serverIp, remark 
                FROM v_gprs_gr_xg where client = {0} order by teamorder", XGConfig.Default.ClientAorB );
           
            DataSet ds = XGDB.DbClient.Execute( sql );
            this.dataGridGPRSStation.DataSource = ds.Tables[0];
        }
        #endregion //LoadXGStationFromDB

        #region frmXGStationManager_Load
        private void frmXGStationManager_Load(object sender, System.EventArgs e)
        {
            InitForm();
        }
        #endregion //frmXGStationManager_Load

        #region GetTeamOrder
        private int GetTeamOrder( string team )
        {
            int NOTFIND_ORDER = 99;
            string[] TeamText = new string [] {
                 "（无）", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十"  };
            
            team = team.Trim();
            for ( int i=0; i<TeamText.Length; i++ )
            {
                if ( team == TeamText[i] )
                    return i;
            }

            return NOTFIND_ORDER;

        }
        #endregion //GetTeamOrder

        #region btnAdd_Click
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            frmGprsStationItem  f = new frmGprsStationItem();
            if ( f.ShowDialog( this ) == DialogResult.OK )
            {
                string stName = f.StationName;
                int gr_addr = f.GrAddress;
                int xg_addr = f.XgAddress;
//                int cp = f.CommPort;
                int cp = 0;
                string remark = f.Remark;
                int client = XGConfig.Default.ClientAorB;
                string ipAddr = f.IpAddress;
                string team = f.Team;
                string addDrug = f.AddDrug;
                float heatArea = f.Area;
                string serverIP = f.ServerIpAddress;
                int  teamOrder = GetTeamOrder( f.Team );


                string insertGprsStationSql = string.Format( 
                    @"insert into tbl_gprs_station (name, commport, 
                    client, remark, ip, team, addDrug, heatArea, serverIp, teamorder ) 
                    values( '{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', {7}, '{8}', {9})",
                    stName, cp, client, remark, ipAddr, team, addDrug, heatArea, serverIP, teamOrder );

                XGDB.DbClient.ExecuteNonQuery( insertGprsStationSql );
                int gprsStationId = XGDB.QueryLastId( "tbl_gprs_station", "gprs_station_id" );

                XGStation st = new XGStation( stName, ipAddr, xg_addr );
                st.Tag = gprsStationId;
                XGDB.InsertXGStation ( st );
    
                //int xgStationId = XGDB.QueryLastId("tbl_xgstation","xgstation_id");
                
                GRStation grSt = new GRStation( stName, gr_addr, ipAddr );
                grSt.Tag = gprsStationId;
                XGDB.InsertGRStation( grSt ) ;
                //int grStationId = XGDB.QueryLastId("tbl_grstation", "grstation_id" );

                

                LoadXGStationFromDB();
                //XGDB.Resolve();

                
            }
        }
        #endregion //btnAdd_Click

        #region btnDelete_Click
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            int row = dataGridGPRSStation.CurrentRowIndex;
            if ( row == -1 )
                return ;

            if ( ! XGConfig.Default.IsEnableMCS )
            {
                MsgBox.Show( "删除功能已被禁用!" );
                return ;
            }
            DialogResult dr = MsgBox.ShowQuestion( GT.TIP_DELELE_DATAGRID_ROW );
            if ( dr == DialogResult.Yes )
            {
                int id = int.Parse(dataGridGPRSStation[ row, 0 ].ToString() );
                XGDB.DeleteGPRSStation( id );
                LoadXGStationFromDB();
            
                //XGDB.Resolve();
            }
        }
        #endregion //btnDelete_Click

        #region GetArea
        /// <summary>
        /// 
        /// </summary>
        /// <param name="areaText"></param>
        /// <returns></returns>
        private float GetArea( string areaText )
        {
            try
            {
                if ( areaText.Length == 0 )
                    return 1;
                else
                    return float.Parse( areaText );
            }
            catch
            {
                return 1;
            }

        }
        #endregion //GetArea

        #region btnEdit_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, System.EventArgs e)
        {           
            int row = dataGridGPRSStation.CurrentRowIndex;
            if ( row == -1 )
                return ;
            
            int id          = int.Parse ( dataGridGPRSStation[ row, 0 ].ToString() );
            string name     = dataGridGPRSStation[ row, 1 ].ToString();
            string team     = dataGridGPRSStation[ row, 2 ].ToString();
            string addDrag  = dataGridGPRSStation[ row, 3 ].ToString();
            float area       = GetArea( dataGridGPRSStation[ row, 4 ].ToString() );
                //int.Parse ( dataGridGPRSStation[ row, 4 ].ToString() );
            string ip       = dataGridGPRSStation[ row, 5 ].ToString();

            int grAddr      = int.Parse ( dataGridGPRSStation[ row, 6 ].ToString() );
            int xgAddr      = int.Parse ( dataGridGPRSStation[ row, 7 ].ToString() );
            string serverIP = dataGridGPRSStation[ row, 8 ].ToString();

            string remark   = dataGridGPRSStation[ row, 9 ].ToString();

            
            //frmXGStationItem f = new frmXGStationItem();
            frmGprsStationItem f = new frmGprsStationItem();
            f.AdeState = ADEState.Edit;
            
            f.EditId = id;
            f.StationName = name;
            f.IpAddress = ip;
            f.GrAddress = grAddr;
            f.XgAddress = xgAddr;
            f.Remark = remark;
            f.Team = team;
            f.Area = area;
            f.AddDrug = addDrag;
            f.ServerIpAddress = serverIP;
            
            if ( f.ShowDialog( this ) == DialogResult.OK )
            {
                // edit gprs station
                //
                int grId, xgId;

                // get grstaion id
                //
                bool b = getGrXgID( id, out grId, out xgId );
                System.Diagnostics.Debug.Assert( b , "read gr xg id");

                // update grstation name graddress with id
                //
                XGDB.UpdateGrStation ( grId, f.StationName, grAddr );

                // get xgstation id
                //
                // update xgstation name xgaddress with xgid
                //
                XGDB.UpdateXGStation( xgId, f.StationName, xgAddr );

                // update gprs station name, ip ,commport, remark ,client
                //
                XGDB.UpdateGprsStation( id, f.StationName, f.IpAddress, f.Remark , f.Team,  f.AddDrug, f.Area, f.ServerIpAddress,
                    this.GetTeamOrder( f.Team ) );

                LoadXGStationFromDB();
            }
        }

        #endregion //btnEdit_Click 


        #region getGrXgID
        private bool getGrXgID( int gprsStId, out int grId, out int xgId )
        {
            string sql = string.Format( "select * from v_gprs_gr_xg where client = {0} ",
                XGConfig.Default.ClientAorB );
            DataSet ds = XGDB.DbClient.Execute( sql );
            DataTable tbl = ds.Tables[0];
            
            grId = int.Parse ( tbl.Rows[0]["grstation_id"].ToString() );
            xgId = int.Parse ( tbl.Rows[0]["xgstation_id"].ToString() );

            return true;
        }
        #endregion //getGrXgID

        #region toolBar1_ButtonClick
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            ToolBarButton b = e.Button;
            if ( b == this.tbbAdd )
                this.btnAdd_Click( this, EventArgs.Empty );

            else if ( b == this.tbbEdit )
                this.btnEdit_Click( this, EventArgs.Empty );

            else if ( b == this.tbbDelete )
                this.btnDelete_Click( this, EventArgs.Empty );

            else if ( b == this.tbbExit )
                Close();

        }
        #endregion //toolBar1_ButtonClick
	}

    #endregion //frmXGStationManager
}
