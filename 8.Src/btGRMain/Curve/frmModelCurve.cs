using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ZedGraph;
using Utilities;

namespace btGRMain.Curve
{
	/// <summary>
	/// frmModelCurve 的摘要说明。
	/// </summary>
	public class frmModelCurve : System.Windows.Forms.Form
	{
        #region Members
		private System.Windows.Forms.GroupBox groupBox4;
		private ZedGraph.ZedGraphControl zgCurve;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown numDown;
		private System.Windows.Forms.NumericUpDown numUp;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtEnd;
		private System.Windows.Forms.DateTimePicker dtBegin;
		private System.Windows.Forms.GroupBox groupBox1;
		private Decimal m_MaxTemp;
		private Decimal m_MaxIndex;
		private Decimal m_MinTemp;
		private Decimal m_MinIndex;
		private Decimal m_Heat;
		private Decimal m_Area;
		private CurveValue[] m_Curvefact=null;
		private CurveXY[] m_IdeaDatas=null;
		private CurveXY[] m_FactDatas=null;
		private System.Windows.Forms.ComboBox cmbStation;
		private System.Drawing.Color[] m_Color=null;
		private GraphPane myPane =new GraphPane();
		private PointPairList list=null;
		private DBcon con=null;
		/// <summary>
		/// 站点名称
		/// </summary>
		private string m_name;
		private Decimal m_pa;
		private DateTime m_dtBegin;
		private DateTime m_dtEnd;
        private System.Windows.Forms.Button button1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        #endregion //Members

        #region Constructor
		public frmModelCurve()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			myPane=zgCurve.GraphPane;
			m_pa=System.Convert.ToDecimal(4.1868);
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
        #endregion //

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zgCurve = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numDown = new System.Windows.Forms.NumericUpDown();
            this.numUp = new System.Windows.Forms.NumericUpDown();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.zgCurve);
            this.groupBox4.Location = new System.Drawing.Point(8, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(920, 544);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // zgCurve
            // 
            this.zgCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgCurve.IsAutoScrollRange = false;
            this.zgCurve.IsEnableHPan = true;
            this.zgCurve.IsEnableHZoom = true;
            this.zgCurve.IsEnableVPan = true;
            this.zgCurve.IsEnableVZoom = true;
            this.zgCurve.IsPrintFillPage = true;
            this.zgCurve.IsPrintKeepAspectRatio = true;
            this.zgCurve.IsScrollY2 = false;
            this.zgCurve.IsShowContextMenu = true;
            this.zgCurve.IsShowCopyMessage = true;
            this.zgCurve.IsShowCursorValues = false;
            this.zgCurve.IsShowHScrollBar = false;
            this.zgCurve.IsShowPointValues = false;
            this.zgCurve.IsShowVScrollBar = false;
            this.zgCurve.IsZoomOnMouseCenter = false;
            this.zgCurve.Location = new System.Drawing.Point(3, 17);
            this.zgCurve.Name = "zgCurve";
            this.zgCurve.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgCurve.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zgCurve.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgCurve.PointDateFormat = "g";
            this.zgCurve.PointValueFormat = "G";
            this.zgCurve.ScrollMaxX = 0;
            this.zgCurve.ScrollMaxY = 0;
            this.zgCurve.ScrollMaxY2 = 0;
            this.zgCurve.ScrollMinX = 0;
            this.zgCurve.ScrollMinY = 0;
            this.zgCurve.ScrollMinY2 = 0;
            this.zgCurve.Size = new System.Drawing.Size(914, 524);
            this.zgCurve.TabIndex = 0;
            this.zgCurve.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgCurve.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zgCurve.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zgCurve.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgCurve.ZoomStepFraction = 0.1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.numDown);
            this.groupBox2.Controls.Add(this.numUp);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dtEnd);
            this.groupBox2.Controls.Add(this.dtBegin);
            this.groupBox2.Location = new System.Drawing.Point(172, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(490, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "参数编辑";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numDown
            // 
            this.numDown.Location = new System.Drawing.Point(332, 18);
            this.numDown.Maximum = new System.Decimal(new int[] {
                                                                    24,
                                                                    0,
                                                                    0,
                                                                    0});
            this.numDown.Name = "numDown";
            this.numDown.Size = new System.Drawing.Size(36, 21);
            this.numDown.TabIndex = 8;
            this.numDown.Value = new System.Decimal(new int[] {
                                                                  8,
                                                                  0,
                                                                  0,
                                                                  0});
            // 
            // numUp
            // 
            this.numUp.Location = new System.Drawing.Point(128, 18);
            this.numUp.Maximum = new System.Decimal(new int[] {
                                                                  24,
                                                                  0,
                                                                  0,
                                                                  0});
            this.numUp.Name = "numUp";
            this.numUp.Size = new System.Drawing.Size(36, 21);
            this.numUp.TabIndex = 7;
            this.numUp.Value = new System.Decimal(new int[] {
                                                                8,
                                                                0,
                                                                0,
                                                                0});
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(666, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 24);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(578, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 24);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "绘制曲线";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(172, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "至";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(196, 18);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(132, 21);
            this.dtEnd.TabIndex = 1;
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(12, 18);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(114, 21);
            this.dtBegin.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbStation);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 52);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择站点";
            // 
            // cmbStation
            // 
            this.cmbStation.Location = new System.Drawing.Point(8, 20);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(144, 20);
            this.cmbStation.TabIndex = 10;
            // 
            // frmModelCurve
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(936, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmModelCurve";
            this.Text = "frmModelCurve";
            this.Load += new System.EventHandler(this.frmModelCurve_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		#region frmModelCurve_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void frmModelCurve_Load(object sender, System.EventArgs e)
		{
			con=new DBcon();
			ReadStations();
			cmbStation.Focus();
		}
		#endregion //frmModelCurve_Load

		#region ReadStations
        /// <summary>
        /// 
        /// </summary>
		private void ReadStations()
		{
			try
			{
				dtEnd.Value=dtBegin.Value.AddDays(1);
                string str=//"select Name from V_heatDatas Group by name";  //筛选以存站点 
                    "select distinct name from tbl_gprs_station order by name";

				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					cmbStation.Items.Add(dr.GetValue(0).ToString());
				}
				dr.Close();
				InitializeColor();
				InitializeCurve();
				ReadIndex();
			}
			catch(Exception ex)
			{
                // 2007.05.30
                //
                //MessageBox.Show("读取站点失败！");
                ExceptionHandler.Handle("读取站点失败！" , ex );
			}
		}
		#endregion //ReadStations
		
		#region DrawCurve
        /// <summary>
        /// 
        /// </summary>
		private void DrawCurve()
		{
			if(LoadDatas())
			{
				list=new PointPairList();
				myPane.CurveList.Clear();
                myPane.Title=
                    //m_dtBegin.ToShortDateString()+
                    //"日 至"+m_dtEnd.ToShortDateString()+"日 "+
                    //m_name+" 热能曲线图";
                    string.Format("{0} 至 {1} {2} 热能曲线图",
                    m_dtBegin.ToShortDateString(),
                    m_dtEnd.ToShortDateString(),
                    m_name
                    );

				myPane.XAxis.Title="时间";
				myPane.YAxis.Title="";
				myPane.XAxis.Type = AxisType.Date;
				myPane.XAxis.ScaleFontSpec.Size=8;
				myPane.YAxis.ScaleFontSpec.Size=8;
				for(int i=0;i<m_FactDatas.Length;i++)
				{
					string time=m_FactDatas[i].x.ToString();
					int yearlast=time.IndexOf("-",0);
					int monthlast=time.IndexOf("-",yearlast+1);
					int daylast=time.IndexOf(" ", monthlast+1);
					int hourlast=time.IndexOf(":",daylast+1);
					int minituelast=time.IndexOf(":",hourlast+1);
	                
					string year=time.Substring(0,4);
					string month=time.Substring(yearlast+1,monthlast-yearlast-1);
					string day=time.Substring(monthlast+1,daylast-monthlast-1);
					string hour=time.Substring(daylast+1,hourlast-daylast-1);
					string minitue=time.Substring(hourlast+1,minituelast-hourlast-1);
					string second=time.Substring(minituelast+1);
					double x=new  XDate(Convert.ToInt32(year),Convert.ToInt32(month),Convert.ToInt32(day),Convert.ToInt32(hour),Convert.ToInt32(minitue),Convert.ToInt32(second));
							
					double y=System.Convert.ToDouble(m_FactDatas[i].y);
					list.Add(x,y);
				}
				LineItem myCurve = myPane.AddCurve("实际曲线",list,Color.Blue,SymbolType.Circle );
				myCurve.Symbol.Fill = new Fill( Color.White );
				myCurve.Symbol.Size = 3;
				myPane.XAxis.Title="时间";
				myPane.YAxis.Title="GJ";
				myPane.AxisFill = new Fill( Color.White,Color.LightGray,45F );
				zgCurve.IsShowPointValues = true;
				zgCurve.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler );
				zgCurve.AxisChange();
				zgCurve.Invalidate();
				list=new PointPairList();
				for(int i=0;i<m_FactDatas.Length;i++)
				{
					string time=m_IdeaDatas[i].x.ToString();
					int yearlast=time.IndexOf("-",0);
					int monthlast=time.IndexOf("-",yearlast+1);
					int daylast=time.IndexOf(" ", monthlast+1);
					int hourlast=time.IndexOf(":",daylast+1);
					int minituelast=time.IndexOf(":",hourlast+1);
	                
					string year=time.Substring(0,4);
					string month=time.Substring(yearlast+1,monthlast-yearlast-1);
					string day=time.Substring(monthlast+1,daylast-monthlast-1);
					string hour=time.Substring(daylast+1,hourlast-daylast-1);
					string minitue=time.Substring(hourlast+1,minituelast-hourlast-1);
					string second=time.Substring(minituelast+1);
					double x=new  XDate(Convert.ToInt32(year),Convert.ToInt32(month),Convert.ToInt32(day),Convert.ToInt32(hour),Convert.ToInt32(minitue),Convert.ToInt32(second));
							
					double y=System.Convert.ToDouble(m_IdeaDatas[i].y);
					list.Add(x,y);
				}
				myCurve = myPane.AddCurve("理想曲线",list,Color.Red,SymbolType.Circle );
				myCurve.Symbol.Fill = new Fill( Color.White );
				myCurve.Symbol.Size = 3;
				myPane.XAxis.Title="时间";
				myPane.YAxis.Title="GJ";
				myPane.AxisFill = new Fill( Color.White,Color.LightGray,45F );
				zgCurve.IsShowPointValues = true;
				zgCurve.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler );
				zgCurve.AxisChange();
				zgCurve.Invalidate();
			}
			else
			{
				MessageBox.Show("该站满足条件的数据不存在","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		#endregion //DrawCurve

		#region checkDatas
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		private bool checkDatas()
		{
			if(this.cmbStation.Text=="")
			{
				MessageBox.Show("请选择站点名称","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(dtBegin.Value.Date>dtEnd.Value.Date)
			{
				MessageBox.Show("时间条件无效!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
			if(dtBegin.Value.Date==dtEnd.Value.Date)
			{
				if(numUp.Value>=numDown.Value)
				{
					MessageBox.Show("时间条件无效!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return false;
				}
			}
			m_name=cmbStation.Text.Trim();
//			m_dtBegin=System.Convert.ToDateTime(dtBegin.Value.ToShortDateString()+" "+numUp.Value.ToString()+":00:00");
//			m_dtEnd=System.Convert.ToDateTime(dtEnd.Value.ToShortDateString()+" "+numDown.Value.ToString()+":00:00");

			m_dtBegin=System.Convert.ToDateTime(dtBegin.Value.ToShortDateString()+" " + 
                GetTimeString( numUp ) );
			m_dtEnd=System.Convert.ToDateTime(dtEnd.Value.ToShortDateString()+" " + 
                GetTimeString ( numDown ) );

			return true;
		}
		#endregion //checkDatas

        #region GetTimeString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string GetTimeString( NumericUpDown num )
        {
            if ( num == null )
                throw new ArgumentNullException ();

            if ( num.Value == 24 )
            {
                return "23:59:59";
            }
            return num.Value.ToString() + ":00:00";
        }
        #endregion //GetTimeString

		#region MyPointValueHandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="pane"></param>
        /// <param name="curve"></param>
        /// <param name="iPt"></param>
        /// <returns></returns>
		private string MyPointValueHandler( 
            ZedGraphControl control, 
            GraphPane pane,
			CurveItem curve, 
            int iPt
            )
		{
			PointPair pt = curve[iPt];
//			return curve.Label + "： " + 
//                pt.Y.ToString("f2") + 
//                " " + "GJ" + "，在 " +
//                XDate.XLDateToDateTime(pt.X).ToString() + " 时刻";

            Decimal outSideTemp = this.m_Curvefact[ iPt ].avgOutTemp;
            DateTime dt = XDate.XLDateToDateTime( pt.X );
            string heat = pt.Y.ToString("f2");
            
//			return curve.Label + 
//                "： " + pt.Y.ToString("f2") + 
//                " "+"GJ"+"，在 " +  
//                XDate.XLDateToDateTime(pt.X).ToString()+ " 时刻" +
//                Environment.NewLine + "室外温度：" + outSideTemp + " ℃";
            return string.Format("{0}\r\n{1}\r\n热        量: {2} GJ\r\n室外温度: {3} ℃",
                curve.Label,
                dt,
                heat,
                outSideTemp
                );
		}
		#endregion //MyPointValueHandler

		#region ReadIndex
        /// <summary>
        /// 
        /// </summary>
		private void ReadIndex()
		{
			string str="select top 1 OutTemp,HeatIndex from tbl_HeatIndex order by outTemp desc";
			SqlCommand cmd=new SqlCommand(str,con.GetConnection());
			SqlDataReader dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				m_MaxIndex=System.Convert.ToDecimal(dr["HeatIndex"]);
				m_MaxTemp=System.Convert.ToDecimal(dr["outTemp"]);
			}
			dr.Close();
			cmd.Dispose();
			str="select top 1 OutTemp,HeatIndex from tbl_HeatIndex order by outTemp asc";
			cmd=new SqlCommand(str,con.GetConnection());
			dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				m_MinIndex=System.Convert.ToDecimal(dr["HeatIndex"]);
				m_MinTemp=System.Convert.ToDecimal(dr["outTemp"]);
			}
			dr.Close();
			cmd.Dispose();
		}
		#endregion //ReadIndex

		#region LoadDatas
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		private bool LoadDatas()
		{
			try
			{
				string str="select heatArea from tbl_gprs_station where name='"+m_name+"'";
				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					m_Area=System.Convert.ToDecimal(dr["heatArea"]);
				}
				dr.Close();
				cmd.Dispose();

				str="select time,oneGiveTemp,oneBackTemp,oneAccum,outsideTemp from v_heatDatas where name='";
				str=str+m_name;
				str=str+"' and time between '";
				str=str+m_dtBegin;
				str=str+"' and '";
				str=str+m_dtEnd;
				str=str+"' order by time asc";
				SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
				DataSet ds=new DataSet();
				da.Fill(ds,"table");
				da.Dispose();
				if(ds.Tables["table"].Rows.Count-1<=0)
					return false;
				m_FactDatas=new CurveXY[ds.Tables["table"].Rows.Count-1];
				m_IdeaDatas=new CurveXY[ds.Tables["table"].Rows.Count-1];
				m_Curvefact=new CurveValue[ds.Tables["table"].Rows.Count-1];
				Decimal oldValue;
				DateTime oldTime;
				TimeSpan avgI;
				int ts;
				for(int i=0;i<ds.Tables["table"].Rows.Count-1;i++)
				{
					oldValue=System.Convert.ToDecimal(ds.Tables["table"].Rows[i]["oneGiveTemp"]);
					oldValue=oldValue+System.Convert.ToDecimal(ds.Tables["table"].Rows[i+1]["oneGiveTemp"]);
					m_Curvefact[i].AvgGiveTemp=oldValue/2;

					oldValue=System.Convert.ToDecimal(ds.Tables["table"].Rows[i]["oneBackTemp"]);
					oldValue=oldValue+System.Convert.ToDecimal(ds.Tables["table"].Rows[i+1]["oneBackTemp"]);
					m_Curvefact[i].AvgBackTemp=oldValue/2;
					
					oldValue=System.Convert.ToDecimal(ds.Tables["table"].Rows[i]["outsideTemp"]);
					oldValue=oldValue+System.Convert.ToDecimal(ds.Tables["table"].Rows[i+1]["outsideTemp"]);
					m_Curvefact[i].avgOutTemp=Math.Round(oldValue/2,0);

					oldValue=System.Convert.ToDecimal(ds.Tables["table"].Rows[i]["oneAccum"]);
					m_Curvefact[i].FluxValue=System.Convert.ToDecimal(ds.Tables["table"].Rows[i+1]["oneAccum"])-oldValue;
					
					oldTime=System.Convert.ToDateTime(ds.Tables["table"].Rows[i]["time"]);
					avgI=System.Convert.ToDateTime(ds.Tables["table"].Rows[i+1]["time"])-oldTime;
					ts=System.Convert.ToInt32(avgI.TotalSeconds);
					m_Curvefact[i].timeSpan=ts;
					m_Curvefact[i].time=System.Convert.ToDateTime(ds.Tables["table"].Rows[i+1]["time"]);
				}
				for(int j=0;j<m_Curvefact.Length;j++)
				{
					m_FactDatas[j].y =m_Curvefact[j].AvgGiveTemp-m_Curvefact[j].AvgBackTemp;
					m_FactDatas[j].y =m_FactDatas[j].y*m_Curvefact[j].FluxValue;
					m_FactDatas[j].y =m_FactDatas[j].y*m_pa/1000;
					m_FactDatas[j].x=m_Curvefact[j].time;
					
					if(m_Curvefact[j].avgOutTemp>=m_MaxTemp)
					{
						m_Heat=m_MaxIndex;
						m_IdeaDatas[j].y=m_Heat*m_Area;
						m_IdeaDatas[j].y=m_IdeaDatas[j].y*m_Curvefact[j].timeSpan;
						m_IdeaDatas[j].y=m_IdeaDatas[j].y/100000;
						m_IdeaDatas[j].x=m_Curvefact[j].time;
					}
					else if(m_Curvefact[j].avgOutTemp<=m_MinTemp)
					{
						m_Heat=m_MinIndex;
						m_IdeaDatas[j].y=m_Heat*m_Area;
						m_IdeaDatas[j].y=m_IdeaDatas[j].y*m_Curvefact[j].timeSpan;
						m_IdeaDatas[j].y=m_IdeaDatas[j].y/100000;
						m_IdeaDatas[j].x=m_Curvefact[j].time;
					}
					else
					{
						str="select HeatIndex from tbl_HeatIndex where OutTemp=";
						str=str+m_Curvefact[j].avgOutTemp;
						cmd=new SqlCommand(str,con.GetConnection());
						dr=cmd.ExecuteReader();
						while(dr.Read())
						{
							m_Heat=System.Convert.ToDecimal(dr["heatindex"]);
							m_IdeaDatas[j].y=m_Heat*m_Area;
							m_IdeaDatas[j].y=m_IdeaDatas[j].y*m_Curvefact[j].timeSpan;
							m_IdeaDatas[j].y=m_IdeaDatas[j].y/100000;
							m_IdeaDatas[j].x=m_Curvefact[j].time;
						}
						dr.Close();
						cmd.Dispose();
					}
				}
				
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return false;
			}
		}
		#endregion //LoadDatas

		#region InitializeColor
        /// <summary>
        /// 
        /// </summary>
		private void InitializeColor()
		{
			m_Color=new Color[2];
			m_Color[0]=Color.Blue;
			m_Color[1]=Color.Red;
		}	
		#endregion //InitializeColor
	 
		#region InitializeCurve
        /// <summary>
        /// 
        /// </summary>
		private void InitializeCurve()
		{
			myPane.CurveList.Clear();
			myPane.Title="趋势曲线图";
			myPane.XAxis.Title="时间";
			myPane.YAxis.Title="";
			myPane.XAxis.Type = AxisType.Date;
			myPane.XAxis.ScaleFontSpec.Size=8;
			myPane.YAxis.ScaleFontSpec.Size=8;
		}
		#endregion //InitializeCurve

		#region btnPrint_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if(checkDatas())
			{
				DrawCurve();
			}
			else
				return;
		}
		#endregion //btnPrint_Click

		#region btnExit_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion //btnExit_Click

        #region button1_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            frmHeatItem f=new frmHeatItem();
            f.ShowDialog();
        }
        #endregion //button1_Click
	}

	#region CurveValue
    /// <summary>
    /// 
    /// </summary>
	public struct CurveValue
	{
		public DateTime time;
		public int timeSpan;
		public Decimal avgOutTemp;
		public Decimal AvgGiveTemp;
		public Decimal AvgBackTemp;
		public Decimal FluxValue;
	}
	#endregion //CurveValue

	#region CurveXY
    /// <summary>
    /// 
    /// </summary>
	public struct CurveXY
	{
		public DateTime x;
		public Decimal y;
	}
	#endregion //CurveXY
}
