using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ZedGraph;

namespace btGRMain.Curve
{
	/// <summary>
	/// frmCurve 的摘要说明。
	/// </summary>
	public class frmCurve : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox4;
		private ZedGraph.ZedGraphControl zgCurve;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown numDown;
		private System.Windows.Forms.NumericUpDown numUp;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtEnd;
		private System.Windows.Forms.DateTimePicker dtBegin;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbStation;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListView lvCurve;
		private CurveInfo[] curveInfo=null;
		private PointPairList list=null;
		private string TYPE_DISPLAY="1";
		private string m_Station=null;
		private GraphPane myPane =new GraphPane();
		private string m_Curve;
//		private string m_curve;
		private string chartInfo;
		private bool bolCurve=false;
		private int typeSign=0;
		private TypeInfo[] typeInfo;
		private DateTime m_Begin;
		private DateTime m_End;
		private System.Drawing.Color[] m_Color=null;
		private DataSet ds=null;
		private string UStr=null;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
	
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCurve()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			myPane=zgCurve.GraphPane;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public frmCurve(string GRStation)
		{
			InitializeComponent();
			m_Station=GRStation;
			myPane=zgCurve.GraphPane;
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.zgCurve = new ZedGraph.ZedGraphControl();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numDown = new System.Windows.Forms.NumericUpDown();
			this.numUp = new System.Windows.Forms.NumericUpDown();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnData = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dtEnd = new System.Windows.Forms.DateTimePicker();
			this.dtBegin = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbStation = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lvCurve = new System.Windows.Forms.ListView();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.zgCurve);
			this.groupBox4.Location = new System.Drawing.Point(168, 60);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(640, 408);
			this.groupBox4.TabIndex = 12;
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
			this.zgCurve.Size = new System.Drawing.Size(634, 388);
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
			this.groupBox2.Controls.Add(this.numDown);
			this.groupBox2.Controls.Add(this.numUp);
			this.groupBox2.Controls.Add(this.btnExit);
			this.groupBox2.Controls.Add(this.btnPrint);
			this.groupBox2.Controls.Add(this.btnData);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.dtEnd);
			this.groupBox2.Controls.Add(this.dtBegin);
			this.groupBox2.Location = new System.Drawing.Point(168, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(640, 52);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			// 
			// numDown
			// 
			this.numDown.Location = new System.Drawing.Point(328, 18);
			this.numDown.Maximum = new System.Decimal(new int[] {
																	24,
																	0,
																	0,
																	0});
			this.numDown.Minimum = new System.Decimal(new int[] {
																	1,
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
			this.numUp.Minimum = new System.Decimal(new int[] {
																  1,
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
			this.btnExit.Location = new System.Drawing.Point(544, 18);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(84, 24);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "退出";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Location = new System.Drawing.Point(456, 18);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(84, 24);
			this.btnPrint.TabIndex = 4;
			this.btnPrint.Text = "打印曲线";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnData
			// 
			this.btnData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnData.Location = new System.Drawing.Point(368, 18);
			this.btnData.Name = "btnData";
			this.btnData.Size = new System.Drawing.Size(84, 24);
			this.btnData.TabIndex = 3;
			this.btnData.Text = "查看数据";
			this.btnData.Click += new System.EventHandler(this.btnData_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 20);
			this.label1.TabIndex = 2;
			this.label1.Text = "至";
			// 
			// dtEnd
			// 
			this.dtEnd.Location = new System.Drawing.Point(192, 18);
			this.dtEnd.Name = "dtEnd";
			this.dtEnd.Size = new System.Drawing.Size(132, 21);
			this.dtEnd.TabIndex = 1;
			// 
			// dtBegin
			// 
			this.dtBegin.Location = new System.Drawing.Point(8, 18);
			this.dtBegin.Name = "dtBegin";
			this.dtBegin.Size = new System.Drawing.Size(114, 21);
			this.dtBegin.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmbStation);
			this.groupBox1.Location = new System.Drawing.Point(8, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 52);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "站点选择";
			// 
			// cmbStation
			// 
			this.cmbStation.Location = new System.Drawing.Point(6, 20);
			this.cmbStation.Name = "cmbStation";
			this.cmbStation.Size = new System.Drawing.Size(144, 20);
			this.cmbStation.TabIndex = 0;
			this.cmbStation.SelectedIndexChanged += new System.EventHandler(this.cmbStation_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.lvCurve);
			this.groupBox3.Location = new System.Drawing.Point(8, 60);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(156, 404);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "曲线选择";
			// 
			// lvCurve
			// 
			this.lvCurve.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvCurve.Location = new System.Drawing.Point(3, 17);
			this.lvCurve.Name = "lvCurve";
			this.lvCurve.Size = new System.Drawing.Size(150, 384);
			this.lvCurve.TabIndex = 3;
			this.lvCurve.View = System.Windows.Forms.View.List;
			this.lvCurve.DoubleClick += new System.EventHandler(this.lvCurve_DoubleClick);
			this.lvCurve.SelectedIndexChanged += new System.EventHandler(this.lvCurve_SelectedIndexChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton2);
			this.groupBox5.Controls.Add(this.radioButton1);
			this.groupBox5.Location = new System.Drawing.Point(8, 68);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(156, 84);
			this.groupBox5.TabIndex = 14;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "曲线类型";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(16, 52);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(132, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "     类型趋势图";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(16, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(132, 20);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.Text = "     单项趋势图";
			// 
			// frmCurve
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(816, 477);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.Name = "frmCurve";
			this.Text = "frmCurve";
			this.Load += new System.EventHandler(this.frmCurve_Load);
			this.groupBox4.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCurve_Load(object sender, System.EventArgs e)
		{
//			this.Text="曲线查询";
			this.radioButton1.Checked=true;
			ReadFunction();
			DataCurvePrint();
		}
		#region InitializeCurve
		private void ReadFunction()
		{
			try
			{
				dtEnd.Value=dtBegin.Value.AddDays(1);
				string str="select Name from V_heatDatas Group by name";  //筛选以存站点
				DBcon con=new DBcon();
				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					cmbStation.Items.Add(dr.GetValue(0).ToString());
				}
				dr.Close();
				InitializeColor();

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void InitializeColor()
		{
			m_Color=new Color[4];
			m_Color[0]=Color.Blue;
			m_Color[1]=Color.Red;
			m_Color[2]=Color.Green;
			m_Color[3]=Color.Black;
		}

		private void DataCurvePrint()
		{
			try
			{
				typeSign=1;
				lvCurve.Items.Clear();
				XmlDocument xDoc=new XmlDocument();  //筛选曲线类型
				xDoc.Load("DataInfo.xml");
				XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table[@Name='DataInfo']");
				curveInfo=new CurveInfo[xNode.ChildNodes.Count];
				for(int i=0;i<xNode.ChildNodes.Count;i++)
				{
					XmlNode cNode=xNode.ChildNodes[i];
					if(cNode.Attributes.GetNamedItem("nu").Value.ToString().Trim()!=TYPE_DISPLAY)
					{
						curveInfo[i].m_Chart=cNode.InnerText.Trim();
						curveInfo[i].m_Sqlname=cNode.Attributes.GetNamedItem("name").Value.ToString().Trim();
						curveInfo[i].m_Type=cNode.Attributes.GetNamedItem("type").Value.ToString().Trim();
						curveInfo[i].m_Y=cNode.Attributes.GetNamedItem("ytitle").Value.ToString().Trim();
						lvCurve.Items.Add(curveInfo[i].m_Chart);
					}
				}
				cmbStation.Text=m_Station;
				DrawCurve("","",0);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void TypeCurvePrint()
		{
			try
			{
				typeSign=2;
				lvCurve.Items.Clear();
				XmlDocument xDoc=new XmlDocument(); 
				xDoc.Load("DataInfo.xml");
				XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table[@Name='TypeInfo']");
				typeInfo=new TypeInfo[xNode.ChildNodes.Count];
				for(int i=0;i<xNode.ChildNodes.Count;i++)
				{
					XmlNode cNode=xNode.ChildNodes[i];
					typeInfo[i].m_TNum=cNode.Attributes.GetNamedItem("type").Value.ToString().Trim();
					typeInfo[i].m_TName=cNode.InnerText.Trim();
					lvCurve.Items.Add(typeInfo[i].m_TName);				
				}
				DrawCurve("","",0);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		private void DrawCurve(string Station,string Curve,int Sign)
		{
			try
			{
				ds=new DataSet();
				list=new PointPairList();
				myPane.CurveList.Clear();
				if(Curve!="")
				{
					myPane.Title=m_Begin.ToShortDateString()+"日 至"+m_End.ToShortDateString()+"日 "+Station+" "+Curve+" 趋势曲线图";
					bolCurve=true;
				}
				else
				myPane.Title="趋势曲线图";
				myPane.XAxis.Title="时间";
				myPane.YAxis.Title="";
				myPane.XAxis.Type = AxisType.Date;
				myPane.XAxis.ScaleFontSpec.Size=8;
				myPane.YAxis.ScaleFontSpec.Size=8;
				string Yaxis;
				if(Sign==1)
				{
					for(int i=0;i<lvCurve.Items.Count+3;i++)
					{
						if(curveInfo[i].m_Chart==Curve)
						{
							chartInfo=curveInfo[i].m_Sqlname;
							Yaxis=curveInfo[i].m_Y;
							UStr=Yaxis;
							DBcon con=new DBcon();
							string str="select "+chartInfo+",time from V_heatDatas where Name='"+Station+"' and time between '"+m_Begin+"' and '"+m_End+"' order by time";
							SqlCommand cmd=new SqlCommand(str,con.GetConnection());
							SqlDataAdapter adp=new SqlDataAdapter (str,con.GetConnection());
							adp.Fill(ds);
							adp.Dispose();
							SqlDataReader dr=cmd.ExecuteReader();
							if(!dr.Read())
								return;
							while(dr.Read())
							{
								string time=dr.GetValue(1).ToString();
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
							
								double y=System.Convert.ToDouble(dr.GetValue(0));
								list.Add(x,y);
							}
							dr.Close();
							myPane.YAxis.Title=Yaxis;
							break;
						}
					}
					LineItem myCurve = myPane.AddCurve(Curve,list,Color.Blue,SymbolType.Circle );
					myCurve.Symbol.Fill = new Fill( Color.White );
					myCurve.Symbol.Size = 3;
					myPane.XAxis.Title="时间（小时）";
					myPane.AxisFill = new Fill( Color.White,Color.LightGray,45F );
					zgCurve.IsShowPointValues = true;
					zgCurve.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler );
					zgCurve.AxisChange();
					zgCurve.Invalidate();
				}
				else if(Sign==2)
				{
					for(int i=0;i<lvCurve.Items.Count;i++)
					{
						if(typeInfo[i].m_TName==Curve)
						{
							string cID=typeInfo[i].m_TNum;
							string m_curve="";
							int z=0;
							for(int j=0;j<curveInfo.Length;j++)
							{
								if(System.Convert.ToInt32(cID)<3)
								{
									if(curveInfo[j].m_Type==cID||curveInfo[j].m_Type=="5")
									{
										list=new PointPairList();
										chartInfo=curveInfo[j].m_Sqlname;
										m_curve=m_curve+chartInfo+",";
										Yaxis=curveInfo[j].m_Y;
										UStr=Yaxis;
										DBcon con=new DBcon();
										string str="select "+chartInfo+",time from V_heatDatas where Name='"+Station+"' and time between '"+m_Begin+"' and '"+m_End+"' order by time";
										SqlCommand cmd=new SqlCommand(str,con.GetConnection());
										SqlDataReader dr=cmd.ExecuteReader();
										while(dr.Read())
										{
											string time=dr.GetValue(1).ToString();
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
							
											double y=System.Convert.ToDouble(dr.GetValue(0));
											list.Add(x,y);
										}
										//									break;

										LineItem myCurve = myPane.AddCurve(curveInfo[j].m_Chart,list,m_Color[z],SymbolType.Circle );
										myCurve.Symbol.Fill = new Fill( Color.White );
										myCurve.Symbol.Size = 3;
										myPane.XAxis.Title="时间（小时）";
										myPane.YAxis.Title=Yaxis;
										myPane.AxisFill = new Fill( Color.White,Color.LightGray,45F );
										zgCurve.IsShowPointValues = true;
										zgCurve.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler );
										zgCurve.AxisChange();
										zgCurve.Invalidate();
										z=++z;
									}
								}

								else
								{
									if(curveInfo[j].m_Type==cID)
									{
										list=new PointPairList();
										chartInfo=curveInfo[j].m_Sqlname;
										m_curve=m_curve+chartInfo+",";
										Yaxis=curveInfo[j].m_Y;
										UStr=Yaxis;
										DBcon con=new DBcon();
										string str="select "+chartInfo+",time from V_heatDatas where Name='"+Station+"' and time between '"+m_Begin+"' and '"+m_End+"' order by time";
										SqlCommand cmd=new SqlCommand(str,con.GetConnection());
										SqlDataReader dr=cmd.ExecuteReader();
										while(dr.Read())
										{
											string time=dr.GetValue(1).ToString();
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
							
											double y=System.Convert.ToDouble(dr.GetValue(0));
											list.Add(x,y);
										}
										//									break;

										LineItem myCurve = myPane.AddCurve(curveInfo[j].m_Chart,list,m_Color[z],SymbolType.Circle );
										myCurve.Symbol.Fill = new Fill( Color.White );
										myCurve.Symbol.Size = 3;
										myPane.XAxis.Title="时间（小时）";
										myPane.YAxis.Title=Yaxis;
										myPane.AxisFill = new Fill( Color.White,Color.LightGray,45F );
										zgCurve.IsShowPointValues = true;
										zgCurve.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler );
										zgCurve.AxisChange();
										zgCurve.Invalidate();
										z=++z;
									}
								}
							}
							m_curve=m_curve+"time";
							DBcon cond=new DBcon();
							string strd="select "+m_curve+" from V_heatDatas where Name='"+Station+"' and time between '"+m_Begin+"' and '"+m_End+"' order by time";
							SqlDataAdapter adpd=new SqlDataAdapter (strd,cond.GetConnection());
							adpd.Fill(ds);
						}
					}
				}
				lvCurve.SelectedItems.Clear();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private string MyPointValueHandler( ZedGraphControl control, GraphPane pane,
			CurveItem curve, int iPt )
		{
			PointPair pt = curve[iPt];
			return curve.Label + "： " + pt.Y.ToString("f2") + " "+UStr+"，在 " +  XDate.XLDateToDateTime(pt.X).ToString()+ " 时刻";
		}
		#endregion

		#region toolsControl
		private void btnData_Click(object sender, System.EventArgs e)
		{
			if(bolCurve)
			{
				frmCurveData f=new frmCurveData(m_Curve,cmbStation.Text,ds,m_Begin,m_End);
				f.ShowDialog();
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			zgCurve.DoPageSetup();
//			zgCurve.DoPrint();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void lvCurve_DoubleClick(object sender, System.EventArgs e)
		{
			if(cmbStation.Text=="")
			{
				MessageBox.Show("选择站点不能为空","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				lvCurve.SelectedItems.Clear();
				return;
			}
			m_Station=cmbStation.Text.Trim();
			if(lvCurve.SelectedItems.Count==0)
			{
				MessageBox.Show("选择曲线类型没有成功，请重新选择！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				lvCurve.SelectedItems.Clear();
				return;
			}
			m_Curve=lvCurve.SelectedItems[0].Text.Trim();
			if(dtBegin.Value.Date>dtEnd.Value.Date)
			{
				MessageBox.Show("时间条件无效!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				lvCurve.SelectedItems.Clear();
				return;
			}
			if(dtBegin.Value.Date==dtEnd.Value.Date)
			{
				if(numUp.Value>=numDown.Value)
				{
					MessageBox.Show("时间条件无效!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
				lvCurve.SelectedItems.Clear();
				return;
				}
			}
			m_Begin=System.Convert.ToDateTime(dtBegin.Value.ToShortDateString()+" "+numUp.Value.ToString()+":00:00");
			m_End=System.Convert.ToDateTime(dtEnd.Value.ToShortDateString()+" "+numDown.Value.ToString()+":00:00");
			DrawCurve(m_Station,m_Curve,typeSign);
		}

		private void cmbStation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		#endregion

		private void lvCurve_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton2.Checked==true)
			{
				TypeCurvePrint();
			}
			else
			{
				DataCurvePrint();
			}
		}

	}
}
