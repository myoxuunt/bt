using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Communication.GRCtrl;
using CFW;
using ZedGraph;
namespace Communication
{
	/// <summary>
	/// 读取、设置二次供水温度曲线窗体
	/// </summary>
	public class frmTempLine : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutsideTemp;
        private System.Windows.Forms.TextBox txtTwoGiveTemp;
        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;

        private GRStation _grSt;
		public frmTempLine( GRStation grSt )
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            ArgumentChecker.CheckNotNull( grSt );
            _grSt = grSt; 
            this.dataGrid1.DataSource = CreateDataTable();
            this.txtStationName.Text = grSt.StationName;
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutsideTemp = new System.Windows.Forms.TextBox();
            this.txtTwoGiveTemp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(704, 472);
            this.btnRead.Name = "btnRead";
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "读取";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(784, 472);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "设置";
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowSorting = false;
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 48);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(176, 232);
            this.dataGrid1.TabIndex = 2;
            this.dataGrid1.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                                  this.dataGridTableStyle1});
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            this.dataGrid1.CurrentCellChanged += new System.EventHandler(this.dataGrid1_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AllowSorting = false;
            this.dataGridTableStyle1.DataGrid = this.dataGrid1;
            this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
                                                                                                                  this.dataGridTextBoxColumn1,
                                                                                                                  this.dataGridTextBoxColumn2,
                                                                                                                  this.dataGridTextBoxColumn3});
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Table";
            this.dataGridTableStyle1.ReadOnly = true;
            this.dataGridTableStyle1.RowHeadersVisible = false;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "序号";
            this.dataGridTextBoxColumn1.MappingName = "序号";
            this.dataGridTextBoxColumn1.Width = 40;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "室外温度";
            this.dataGridTextBoxColumn2.MappingName = "室外温度";
            this.dataGridTextBoxColumn2.Width = 60;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "二次供温";
            this.dataGridTextBoxColumn3.MappingName = "二次供温";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "室外温度：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "二次供温：";
            // 
            // txtOutsideTemp
            // 
            this.txtOutsideTemp.Location = new System.Drawing.Point(80, 288);
            this.txtOutsideTemp.Name = "txtOutsideTemp";
            this.txtOutsideTemp.Size = new System.Drawing.Size(104, 21);
            this.txtOutsideTemp.TabIndex = 5;
            this.txtOutsideTemp.Text = "";
            // 
            // txtTwoGiveTemp
            // 
            this.txtTwoGiveTemp.Location = new System.Drawing.Point(80, 312);
            this.txtTwoGiveTemp.Name = "txtTwoGiveTemp";
            this.txtTwoGiveTemp.Size = new System.Drawing.Size(104, 21);
            this.txtTwoGiveTemp.TabIndex = 6;
            this.txtTwoGiveTemp.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 344);
            this.button1.Name = "button1";
            this.button1.TabIndex = 7;
            this.button1.Text = "修改";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsAutoScrollRange = false;
            this.zedGraphControl1.IsEnableHPan = true;
            this.zedGraphControl1.IsEnableHZoom = false;
            this.zedGraphControl1.IsEnableVPan = true;
            this.zedGraphControl1.IsEnableVZoom = false;
            this.zedGraphControl1.IsPrintFillPage = true;
            this.zedGraphControl1.IsPrintKeepAspectRatio = true;
            this.zedGraphControl1.IsScrollY2 = false;
            this.zedGraphControl1.IsShowContextMenu = false;
            this.zedGraphControl1.IsShowCopyMessage = true;
            this.zedGraphControl1.IsShowCursorValues = false;
            this.zedGraphControl1.IsShowHScrollBar = false;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.IsShowVScrollBar = false;
            this.zedGraphControl1.IsZoomOnMouseCenter = false;
            this.zedGraphControl1.Location = new System.Drawing.Point(192, 8);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.PointDateFormat = "g";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(680, 448);
            this.zedGraphControl1.TabIndex = 8;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomStepFraction = 0.1;
            // 
            // txtStationName
            // 
            this.txtStationName.Location = new System.Drawing.Point(56, 16);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.ReadOnly = true;
            this.txtStationName.Size = new System.Drawing.Size(128, 21);
            this.txtStationName.TabIndex = 10;
            this.txtStationName.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "站名：";
            // 
            // frmTempLine
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(880, 501);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTwoGiveTemp);
            this.Controls.Add(this.txtOutsideTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTempLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "二次供温曲线";
            this.Load += new System.EventHandler(this.frmTempLine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion
        
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable("Table");
            dt.Columns.Add ( "序号", typeof( int ) );
            dt.Columns.Add ( "室外温度", typeof ( int ) );
            dt.Columns.Add ( "二次供温", typeof ( int ) );
            for ( int i = 1; 
				i < TemperatureLine.TemperaturePointNumber + 1; 
				i ++ )
                dt.Rows.Add(new object[]{ i,null,null });
            return dt;
        }

        private void initGraph()
        {
            ZedGraph.GraphPane gp = this.zedGraphControl1.GraphPane;
            gp.IsShowTitle = false;
            gp.XAxis.Title = "室外温度";
//            gp.XAxis.MinAuto = false;
//            gp.XAxis.MaxAuto = false;
            gp.XAxis.Min = TemperatureLinePoint.MIN_OUTSIDE_TEMPERATURE;
            gp.XAxis.Max = TemperatureLinePoint.MAX_OUTSIDE_TEMPERATURE;
            gp.XAxis.Step = 10;
            gp.XAxis.MinorStep = 5;
            gp.XAxis.ScaleFormat = "f0";

            gp.YAxis.Title = "供水温度";
            gp.XAxis.IsZeroLine = true;
//            gp.YAxis.MinAuto = false;
//            gp.YAxis.MaxAuto = false;
//            gp.YAxis.StepAuto = true;
            gp.YAxis.Min = TemperatureLinePoint.MIN_TWOGIVE_TEMPERATURE;
            gp.YAxis.Max = TemperatureLinePoint.MAX_TWOGIVE_TEMPERATURE;
            //gp.YAxis.IsTicsBetweenLabels = false;
            gp.YAxis.Step = 10;
            gp.YAxis.MinorStep = 5;
            gp.YAxis.ScaleFormat = "f0";

        }
        private void frmTempLine_Load(object sender, System.EventArgs e)
        {
           
            this.initGraph();
            TemperatureLine defLine = TemperatureLine.GetDefaultTemperatureLine();
            if ( defLine != null )
                this.ShowTL( defLine );
            this.refreshGP();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnRead_Click(object sender, System.EventArgs e)
        {
            GRReadTLCommand cmd = new GRReadTLCommand( _grSt );
            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add( t );

            frmControlProcess f = new frmControlProcess( t );
            f.ShowDialog( this );
            if ( t.LastCommResultState == CommResultState.Correct )
            {
				this._isReadTempLineSuccess = true;
				this._timeTempLine = cmd.TimeTempLine;
                ShowTL ( cmd.TemperatureLine );
            }
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tl"></param>
        public void ShowTL( TemperatureLine tl )
        {
            LineItem li = new LineItem("室外温度 - 二次供温曲线");
            DataTable tbl = this.dataGrid1.DataSource as DataTable;
            tbl.Rows.Clear();
            for ( int i=0; i<TemperatureLine.TemperaturePointNumber; i++ )
            {
                tbl.Rows.Add( new object[] {(i+1), 
                                           tl[i].OutSideTemperature, 
                                           tl[i].TwoGiveTemperature} );
                li.AddPoint( tl[i].OutSideTemperature, tl[i].TwoGiveTemperature );
            }
            
            this.zedGraphControl1.GraphPane.CurveList.Clear();
            this.zedGraphControl1.GraphPane.CurveList.Add( li );
            this.zedGraphControl1.Invalidate();
            
        }

		bool _isReadTempLineSuccess = false;
		private TimeTempLine _timeTempLine=null;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnWrite_Click(object sender, System.EventArgs e)
        {
//			if( ! _isReadTempLineSuccess )
//			{
//				MessageBox.Show( "请先读取曲线数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error );
//				return ;
//			}

            TemperatureLine line = new TemperatureLine();
            try
            {
                for ( int i=0; i<TemperatureLine.TemperaturePointNumber; i++ )
                {
                    int ot  = Convert.ToInt32( dataGrid1[ i, 1 ] );
                    int gt2 = Convert.ToInt32( dataGrid1[ i, 2 ] );
                    //                line[0] = new TemperatureLinePoint( 
                    line[i] = new TemperatureLinePoint( ot, gt2 );
                }
            }
            catch( Exception ex )
            {
                MsgBox.Show( ex.ToString() );
                return;
            }

            if ( !line.Check() )
            {
                MsgBox.Show( "输入数据错误，室外温度、二次供温必须依次序增减" );
                return ;
            }

//            GRWriteTLCommand cmd = new GRWriteTLCommand( _grSt ,line, _timeTempLine );
			GRWriteOTGT2Line cmd = new GRWriteOTGT2Line( _grSt, line );
            Task t = new Task( cmd, new ImmediateTaskStrategy () );
            Singles.S.TaskScheduler.Tasks.Add( t );
            frmControlProcess f = new frmControlProcess( t );
            f.ShowDialog();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="ne"></param>
        private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
        {
            
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
        {
            int row = this.dataGrid1.CurrentRowIndex;
            if ( row == -1 )
                return ;
            txtOutsideTemp.Text = this.dataGrid1[row, 1].ToString();
            txtTwoGiveTemp.Text = this.dataGrid1[row, 2].ToString();
        }
        
        private int INV = 999;
        private bool getNear( int row, out int otPre, out int otNext, out int twogpPre, out int twogpNext )
        {
            otPre = INV;
            otNext = INV;
            twogpPre = INV;
            twogpNext = INV;

            if ( row  ==  0 )
            {
                otNext = getOt( row + 1, 1 );
                twogpNext = getTwogp ( row + 1, 2 );
            }
            else if ( row == 7 )
            {
                otPre = getOt ( row - 1, 1 );
                twogpPre = getTwogp( row - 1, 2 );
            }
            else 
            {
                otNext = getOt( row + 1, 1 );
                twogpNext = getTwogp ( row + 1, 2 );
                otPre = getOt ( row - 1, 1 );
                twogpPre = getTwogp( row - 1, 2 );
            }
            return true;
        }

        private int getOt( int row, int col )
        {
            return Convert.ToInt32( this.dataGrid1[ row, col ] );
        }

        private int getTwogp( int row, int col )
        {
            return Convert.ToInt32( this.dataGrid1[ row, col ] );
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            int ot, twogp;

            try
            {
                ot = Convert.ToInt32( txtOutsideTemp.Text );
            }
            catch
            {
                MsgBox.Show("室外温度输入错误");
                return;
            }
            try
            {
                twogp = Convert.ToInt32( txtTwoGiveTemp.Text );
            }
            catch
            {
                MsgBox.Show( "二次供温输入错误" );
                return ;
            }

//            if (!( ot >= -50 && ot <= 10 ))
			if( !TemperatureLinePoint.IsValidOutsideTemperature( ot ) )
            {
				string s = string.Format("室外温度必须介于 {0} 到 {1} 之间",
					TemperatureLinePoint.MIN_OUTSIDE_TEMPERATURE,
					TemperatureLinePoint.MAX_OUTSIDE_TEMPERATURE );
                MsgBox.Show(s);
                return;
            }

//            if (!( twogp >= 40 && twogp <= 90 ) )
			if( !TemperatureLinePoint.IsValidTwoGiveTemperature(twogp) )
            {
				string s=string.Format(      "二次供温必须介于 {0} 到 {1} 之间",
					TemperatureLinePoint.MIN_TWOGIVE_TEMPERATURE,
					TemperatureLinePoint.MAX_TWOGIVE_TEMPERATURE);
				MsgBox.Show(s );
                return ;
            }

            int row = dataGrid1.CurrentRowIndex;
            if ( row == -1 )
                return ;

            int otP, otN, twogpP, twogpN;
            getNear( row, out otP, out otN, out twogpP, out twogpN );

            if ( otP != INV && ot < otP )
            {
                m();
                return ;
            }

            if ( otN != INV && ot > otN )
            {
                m();
                return ;
            }

            if ( twogpP != INV && twogp > twogpP )
            {
                m();
                return ;
            }

            if ( twogpN != INV && twogp < twogpN )
            {
                m();
                return;
            }

            
            dataGrid1 [ row, 1 ] = ot;
            dataGrid1 [ row, 2 ] = twogp;
            refreshGP();
        }

        private void m()
        {
            MsgBox.Show("室外温度或二次供水温度必须依次增大或减小");
        }

        private void refreshGP()
        {
            LineItem li = this.zedGraphControl1.GraphPane.CurveList[ 0 ] as LineItem;
            li.Clear();
            for ( int i=0; i<TemperatureLine.TemperaturePointNumber; i++ )
            {
                li.AddPoint( Convert.ToInt32( this.dataGrid1[ i, 1 ]),
                    Convert.ToInt32( this.dataGrid1 [ i, 2 ] ) );
            }
            this.zedGraphControl1.Invalidate();

        }
	}
}
