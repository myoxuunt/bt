using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using Utilities;

namespace btGR
{
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class frmGisMain : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        public Info mapLayer=null;
        private DataSet ds=null;
        private System.Windows.Forms.ToolBar tbGis;
        private System.Windows.Forms.ToolBarButton tBarZoomIn;
        private System.Windows.Forms.ToolBarButton tBarZoomOut;
        private System.Windows.Forms.ToolBarButton tBarFull;
        private System.Windows.Forms.ToolBarButton tBarPan;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton tBarRe;
        private System.Windows.Forms.ToolBarButton tBarExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private AxMapObjects2.AxMap mapMain;
        // 2007.05.31
        //
        //private ContextMenu GisMapMenu;
        //		private MapObjects2.Point STAT=null;

        // 2007.05.31
        //
        //private MenuItem menuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private AxMapObjects2.AxMap mapEye;
        private System.Windows.Forms.ImageList imageList1;
        private MapObjects2.Rectangle zoomRect;
        private int tBarIndex;
        private double sr;
        private PointInfo[] s_Info=null;
        private double MAX_SCALE=2000;
        // 2007.05.31
        //
        //private int POSITIONY=65;

        // 2007.05.31
        //
        //private int POSITIONX=12;
        private string STATIONNAME="热力站";
        private MapObjects2.Symbol symE=null;
        //		private int GisMapToolsID;
        private string GisMapSName;
        private string GisMapSNo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Timer timer1;
        private long iScale;
        private double SC=0.4;

        /// <summary>
        /// 
        /// </summary>
        public frmGisMain()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmGisMain));
            this.tbGis = new System.Windows.Forms.ToolBar();
            this.tBarZoomIn = new System.Windows.Forms.ToolBarButton();
            this.tBarZoomOut = new System.Windows.Forms.ToolBarButton();
            this.tBarFull = new System.Windows.Forms.ToolBarButton();
            this.tBarPan = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tBarRe = new System.Windows.Forms.ToolBarButton();
            this.tBarExit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mapMain = new AxMapObjects2.AxMap();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mapEye = new AxMapObjects2.AxMap();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapMain)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapEye)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbGis
            // 
            this.tbGis.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.tbGis.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                     this.tBarZoomIn,
                                                                                     this.tBarZoomOut,
                                                                                     this.tBarFull,
                                                                                     this.tBarPan,
                                                                                     this.toolBarButton1,
                                                                                     this.tBarRe,
                                                                                     this.tBarExit});
            this.tbGis.DropDownArrows = true;
            this.tbGis.ImageList = this.imageList1;
            this.tbGis.Location = new System.Drawing.Point(0, 0);
            this.tbGis.Name = "tbGis";
            this.tbGis.ShowToolTips = true;
            this.tbGis.Size = new System.Drawing.Size(720, 41);
            this.tbGis.TabIndex = 1;
            this.tbGis.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbGis_ButtonClick);
            // 
            // tBarZoomIn
            // 
            this.tBarZoomIn.ImageIndex = 0;
            this.tBarZoomIn.Text = "放大";
            // 
            // tBarZoomOut
            // 
            this.tBarZoomOut.ImageIndex = 1;
            this.tBarZoomOut.Text = "缩小";
            // 
            // tBarFull
            // 
            this.tBarFull.ImageIndex = 2;
            this.tBarFull.Text = "全图";
            // 
            // tBarPan
            // 
            this.tBarPan.ImageIndex = 3;
            this.tBarPan.Text = "漫游";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tBarRe
            // 
            this.tBarRe.ImageIndex = 4;
            this.tBarRe.Text = "查询";
            // 
            // tBarExit
            // 
            this.tBarExit.ImageIndex = 5;
            this.tBarExit.Text = "退出";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.mapMain);
            this.groupBox1.Location = new System.Drawing.Point(8, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 452);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图信息";
            // 
            // mapMain
            // 
            this.mapMain.ContainingControl = this;
            this.mapMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapMain.Location = new System.Drawing.Point(3, 17);
            this.mapMain.Name = "mapMain";
            this.mapMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mapMain.OcxState")));
            this.mapMain.Size = new System.Drawing.Size(482, 432);
            this.mapMain.TabIndex = 0;
            this.mapMain.MouseDownEvent += new AxMapObjects2._DMapEvents_MouseDownEventHandler(this.mapMain_MouseDownEvent);
            this.mapMain.DblClick += new System.EventHandler(this.mapMain_DblClick);
            this.mapMain.DrawingCanceled += new System.EventHandler(this.mapMain_DrawingCanceled);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listBox);
            this.groupBox3.Location = new System.Drawing.Point(504, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 172);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "站点信息";
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(3, 17);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(202, 148);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.mapEye);
            this.groupBox2.Location = new System.Drawing.Point(504, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 148);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "鸟瞰地图";
            // 
            // mapEye
            // 
            this.mapEye.ContainingControl = this;
            this.mapEye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapEye.Location = new System.Drawing.Point(3, 17);
            this.mapEye.Name = "mapEye";
            this.mapEye.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mapEye.OcxState")));
            this.mapEye.Size = new System.Drawing.Size(202, 128);
            this.mapEye.TabIndex = 0;
            this.mapEye.AfterLayerDraw += new AxMapObjects2._DMapEvents_AfterLayerDrawEventHandler(this.mapEye_AfterLayerDraw);
            this.mapEye.MouseUpEvent += new AxMapObjects2._DMapEvents_MouseUpEventHandler(this.mapEye_MouseUpEvent);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Location = new System.Drawing.Point(504, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 124);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "用户管理";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(24, 84);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(128, 32);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "  热网监控层";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(24, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(152, 24);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "  供热管网层";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(24, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(144, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "  地图层";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 4500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGisMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(720, 509);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbGis);
            this.Name = "frmGisMain";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmGisMain_MouseDown);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapMain)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapEye)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new frmGisMain());
        }
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, System.EventArgs e)
        {	
            mapLayer=new Info();
            LoadMapInfo();
            InitializeMainMap();
            InitializeEyeMap();
            InitializeTools();
        }

        //		public delegate void ContextMenuEventHandler(object sender,string name,int type);
        //		public event ContextMenuEventHandler Menu_XDClick;		

        #region InitializeGis
        /// <summary>
        /// load layer info from .\mapLayers.mdb to Info::m_layers
        /// </summary>
        private void LoadMapInfo()
        {
            try
            {
                OleDbDataAdapter acs=new OleDbDataAdapter("SELECT * FROM mapInfo",mapLayer.GetAccessCon());
                ds=new DataSet();
                acs.Fill(ds,"layersInfo");
                int i=ds.Tables["layersInfo"].Rows.Count;
                mapLayer.m_layers=null;
                mapLayer.m_layers=new LayerInfo[i];

                for(int j=0;j<i;j++)
                {
                    mapLayer.m_layers[j].dtName=ds.Tables["layersInfo"].Rows[j]["Layer"].ToString();
                    mapLayer.m_layers[j].dtFile=ds.Tables["layersInfo"].Rows[j]["LayerName"].ToString();
                    mapLayer.m_layers[j].dtScale=System.Convert.ToDouble(ds.Tables["layersInfo"].Rows[j]["LayerScale"]);
                    mapLayer.m_layers[j].dtSize=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LayerSize"]);
                    mapLayer.m_layers[j].dtColor=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LayerColor"]);
                    mapLayer.m_layers[j].dtSymbol=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LayerSymbol"]);

                    mapLayer.m_layers[j].bzScale=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LabelScale"]);
                    mapLayer.m_layers[j].bzSize=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LabelSize"]);
                    mapLayer.m_layers[j].bzColor=System.Convert.ToInt64(ds.Tables["layersInfo"].Rows[j]["LabelColor"]);

                    mapLayer.m_layers[j].typeName=ds.Tables["layersInfo"].Rows[j]["TypeName"].ToString();
                }
                //				STAT.X=47699;
                //				STAT.Y=31331;
            }
            catch( Exception ex )
            {
                //MessageBox.Show("加载图层信息失败,请重新起动软件!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("加载图层信息失败,请重新起动软件!", ex );
            }
        }

        /// <summary>
        /// load layer from file, layer -> mapMain ocx
        /// </summary>
        private void InitializeMainMap()
        {
            mapMain.Layers.Clear();
            mapMain.ScrollBars=false;
            MapObjects2.DataConnection mapCon=new MapObjects2.DataConnectionClass();
            try
            {
                mapCon.Database=Path.GetDirectoryName(Application.ExecutablePath)+"\\shaps\\";
                for(int m=0;m<3;m++)
                {
                    for(int i=0;i<mapLayer.m_layers.Length;i++)
                    {
                        MapObjects2.MapLayer layer;
                        layer = new MapObjects2.MapLayer();
                        layer.GeoDataset=mapCon.FindGeoDataset(mapLayer.m_layers[i].dtFile);				
                        switch (m)
                        {
                            case 0:
                                if (layer.shapeType != MapObjects2.ShapeTypeConstants.moShapeTypePolygon)
                                    continue;
                                break;
                            case 1:
                                if (layer.shapeType != MapObjects2.ShapeTypeConstants.moShapeTypeLine)
                                    continue;
                                break;
                            case 2:
                                if (layer.shapeType != MapObjects2.ShapeTypeConstants.moShapeTypePoint)
                                    continue;
                                break;
                            default:
                                continue;
                        }
                        mapLayer.m_layers[i].layer=layer;
                        mapMain.Layers.Add(mapLayer.m_layers[i].layer);
                        mapLayer.m_layers[i].layer.Symbol.Style=(short)mapLayer.m_layers[i].dtSymbol;
                        mapLayer.m_layers[i].layer.Symbol.Color=System.Convert.ToUInt32(mapLayer.m_layers[i].dtColor);
                        mapLayer.m_layers[i].layer.Symbol.Size=(short)mapLayer.m_layers[i].dtSize;
                        if(mapLayer.m_layers[i].layer.shapeType==MapObjects2.ShapeTypeConstants.moShapeTypePolygon)
                            mapLayer.m_layers[i].layer.Symbol.OutlineColor=System.Convert.ToUInt32(mapLayer.m_layers[i].dtColor);	
                    }
                }
		
                zoomRect=mapMain.Extent;
                zoomRect.ScaleRectangle(SC);
                //				mapMain.CenterAt(STAT.X,STAT.Y);
                mapMain.Extent=zoomRect;
                mapMain.Refresh();				
            }
            catch (Exception ex)
            {
                //MessageBox.Show("加载图层失败,请重新起动软件!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("加载图层失败,请重新起动软件!", ex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowLayers()
        {
            try
            {
                iScale=System.Convert.ToInt64(mapLayer.CalcScale(this.mapMain));
                for(int i=0;i<mapLayer.m_layers.Length;i++)
                {
                    if(mapLayer.m_layers[i].layer.Visible==true)
                    {
                        string name=mapLayer.m_layers[i].dtName;
                        if(mapLayer.m_layers[i].bzScale>iScale)
                        {
                            MapObjects2.LabelPlacer myRD=(MapObjects2.LabelPlacer)mapLayer.m_layers[i].layer.Renderer;
                            if (!(myRD != null && myRD.Field != ""))
                            {
                                myRD = new MapObjects2.LabelPlacer();
                                myRD.Field = "NAME";
                                myRD.DrawBackground =true;
                                myRD.AllowDuplicates =false;
                                myRD.MaskLabels =false;
                                if (mapLayer.m_layers[i].layer.shapeType == MapObjects2.ShapeTypeConstants.moShapeTypeLine)   
                                    myRD.PlaceAbove = true;
                                else
                                    myRD.PlaceAbove = false;
                                myRD.PlaceOn  = true;
                                myRD.DefaultSymbol.Font.Name="宋体";
                                myRD.DefaultSymbol.Font.Bold=false;
                                myRD.DefaultSymbol.Font.Size=System.Convert.ToDecimal(mapLayer.m_layers[i].bzSize);
                                mapLayer.m_layers[i].layer.Renderer = myRD;
                            }
                        }
                        else
                        {
                            MapObjects2.LabelPlacer myRD=(MapObjects2.LabelPlacer)mapLayer.m_layers[i].layer.Renderer;
                            if (myRD != null)
                                myRD.Field = "";
                        }
                    }
                }
                mapMain.Extent=mapMain.Extent;
                mapMain.Refresh();
            }
            catch(Exception ex)
            {
                //MessageBox.Show("图层信息加载失败,请重新起动软件!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("图层信息加载失败,请重新起动软件!", ex );
            }
        }

        /// <summary>
        /// di tu ceng = eyemap
        /// </summary>
        private void InitializeEyeMap()
        {
            MapObjects2.DataConnection mapCon=new MapObjects2.DataConnectionClass();
            MapObjects2.MapLayer EyeLayer=null; 
            try
            {
                mapCon.Database=Path.GetDirectoryName(Application.ExecutablePath)+"\\shaps\\";
                for(int i=0;i<mapLayer.m_layers.Length;i++)
                {
                    if(mapLayer.m_layers[i].typeName=="地图层")
                    {
                        EyeLayer=new MapObjects2.MapLayerClass();
                        EyeLayer.GeoDataset=mapCon.FindGeoDataset(mapLayer.m_layers[i].dtFile);
                        EyeLayer.Symbol.Color=System.Convert.ToUInt32(mapLayer.m_layers[i].dtColor);
                        EyeLayer.Symbol.Size=1;
                        if(EyeLayer.shapeType==MapObjects2.ShapeTypeConstants.moShapeTypePolygon)
                            EyeLayer.Symbol.OutlineColor=System.Convert.ToUInt32(mapLayer.m_layers[i].dtColor);
                        mapEye.Layers.Add(EyeLayer);
                        mapEye.Refresh();
                    }
                }
            }
            catch( Exception ex )
            {
                //MessageBox.Show("加载图层失败,请重新起动软件!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                ExceptionHandler.Handle("加载图层失败,请重新起动软件!", ex );
            }
        }
        #endregion

        #region GisControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapEye_AfterLayerDraw(object sender, AxMapObjects2._DMapEvents_AfterLayerDrawEvent e)
        {
            if(e.index!=0)
                return;
            symE=new MapObjects2.SymbolClass();
            symE.OutlineColor=(uint)MapObjects2.ColorConstants.moRed;
            symE.Outline=true;
            symE.SymbolType=MapObjects2.SymbolTypeConstants.moFillSymbol;
            symE.Style=(short)MapObjects2.FillStyleConstants.moTransparentFill;
            mapEye.DrawShape(mapMain.Extent,symE);
            MapObjects2.TextSymbol tsy=new MapObjects2.TextSymbolClass();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapEye_MouseUpEvent(object sender, AxMapObjects2._DMapEvents_MouseUpEvent e)
        {
            MapObjects2.Point pointE;
            pointE = mapEye.ToMapPoint(e.x, e.y);
            mapMain.CenterAt(pointE.X,pointE.Y);
            mapEye.Extent =mapEye.Extent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbGis_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button ==this.tBarZoomIn)
                zoomIn();
            if (e.Button==this.tBarZoomOut)
                zoomOut();
            if (e.Button==this.tBarPan)
                zoomPan();
            if(e.Button==this.tBarFull)
                zoomFull();
            if(e.Button==this.tBarRe)
                zoomRe();
            if(e.Button==this.tBarExit)
                this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void zoomIn()
        {
            tBarIndex=1;
            mapMain.MousePointer=MapObjects2.MousePointerConstants.moZoomIn;
        }

        /// <summary>
        /// 
        /// </summary>
        private void zoomOut()
        {
            tBarIndex=2;
            mapMain.MousePointer=MapObjects2.MousePointerConstants.moZoomOut;
        }

        /// <summary>
        /// 
        /// </summary>
        private void zoomPan()
        {
            tBarIndex=3;
            mapMain.MousePointer=MapObjects2.MousePointerConstants.moPan;
        }

        /// <summary>
        /// 
        /// </summary>
        private void zoomFull()
        {			
            mapMain.Extent=mapMain.FullExtent ;
            mapMain.Extent=mapMain.Extent;
            zoomRect=mapMain.Extent;
            zoomRect.ScaleRectangle(SC);
            //			mapMain.CenterAt(STAT.X,STAT.Y);
            mapMain.Extent=zoomRect;
            mapMain.Extent=mapMain.Extent;
            mapMain.Refresh();
            mapEye.Extent=mapEye.Extent;
            mapMain.MousePointer=MapObjects2.MousePointerConstants.moDefault;
            tBarIndex=0;
            ShowLayers();
        }

        /// <summary>
        /// 
        /// </summary>
        private void zoomRe()
        {
            tBarIndex=0;
            mapMain.MousePointer=MapObjects2.MousePointerConstants.moDefault;
        }

        /// <summary>
        /// mapMain mouse down event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapMain_MouseDownEvent(object sender, AxMapObjects2._DMapEvents_MouseDownEvent e)
        {			
            switch(tBarIndex)
            {
                case 1:
                {
                    MapObjects2.Rectangle zoomInRect=new MapObjects2.RectangleClass();
                    MapObjects2.Point zoomInPt=new MapObjects2.PointClass();
                    zoomInRect=this.mapMain.TrackRectangle();
                    if (zoomInRect.Height>0 && zoomInRect.Width>0)
                    {
                        mapMain.Extent=zoomInRect;
                        mapMain.Extent=mapMain.Extent;		
                    }
                    else
                    {
                        zoomInPt=mapMain.ToMapPoint(e.x,e.y);
                        mapMain.CenterAt(zoomInPt.X,zoomInPt.Y);
                        zoomRect=mapMain.Extent;
                        sr=0.5;
                        zoomRect.ScaleRectangle(sr);
                        mapMain.Extent=zoomRect;
                        mapMain.Extent=mapMain.Extent;
                    }

                    ShowLayers();
                    mapEye.Extent=mapEye.Extent;
                    iScale=System.Convert.ToInt64(mapLayer.CalcScale(this.mapMain));
                    if(iScale<=MAX_SCALE)
                    {
                        MessageBox.Show("选择图形比例过小，请重新选择!","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        zoomFull();
                        return;
                    }
                    break;
                }

                case 2:
                {
                    MapObjects2.Rectangle zoomOutRect=new MapObjects2.RectangleClass();
                    MapObjects2.Point zoomOutPt=new MapObjects2.PointClass();
                    zoomOutRect=mapMain.TrackRectangle();
                    if(zoomOutRect.Height>0 && zoomOutRect.Width>0)
                    {
                        sr=mapMain.Extent.Width/zoomOutRect.Width;
                        mapMain.CenterAt(zoomOutRect.Center.X,zoomOutRect.Center.Y);
                    }
                    else
                    {
                        zoomOutPt=mapMain.ToMapPoint(e.x,e.y);
                        mapMain.CenterAt(zoomOutPt.X,zoomOutPt.Y);
                        sr=2;
                    }
                    zoomRect=mapMain.Extent;
                    zoomRect.ScaleRectangle(sr);
                    mapMain.Extent=zoomRect;
                    mapMain.Extent=mapMain.Extent;

                    ShowLayers();
                    mapEye.Extent=mapEye.Extent;
                    break;
                }

                case 3:
                {
                    mapMain.Pan();	
                    mapEye.Extent=mapEye.Extent;
                    break;
                }

                default:
                {   		
                    if(radioButton1.Checked==false)
                    {
                        MapObjects2.Point point;
                        point=mapMain.ToMapPoint(e.x,e.y);
                        for(int i=0;i<s_Info.Length;i++)
                        {
                            if(point.X>System.Convert.ToDouble(
                                s_Info[i].s_East)-5 &&
                                point.X<System.Convert.ToDouble(s_Info[i].s_East)+5 &&
                                point.Y>System.Convert.ToDouble(s_Info[i].s_West)-5 && 
                                point.Y<System.Convert.ToDouble(s_Info[i].s_West)+5
                                )
                            {
                                Point position=new Point();
                                GisMapSName=s_Info[i].s_Name;
                                GisMapSNo=s_Info[i].s_No;
                                //								position.X=e.x+POSITIONX;
                                //								position.Y=e.y+POSITIONY;
                                //								GisMapMenu.Show(this,position);
                                if(GisMapSNo=="2")
                                {
                                    frmDataNowD f=new frmDataNowD(GisMapSName);
                                    f.ShowDialog();
                                }
                                else
                                {
                                    frmDataNow f=new frmDataNow(GisMapSName);
                                    f.ShowDialog();
                                }
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if(mapMain.TrackingLayer.EventCount>0)
                mapMain.TrackingLayer.RemoveEvent(0);
        }

        /// <summary>
        /// 
        /// </summary>
        private void DTLoadLayers()
        {
            for(int i=0;i<mapLayer.m_layers.Length;i++)
            {
                if(mapLayer.m_layers[i].typeName=="地图层"|mapLayer.m_layers[i].typeName=="全显层")
                    mapLayer.m_layers[i].layer.Visible=true;
                else
                    mapLayer.m_layers[i].layer.Visible=false;
            }
            if(mapMain.TrackingLayer.EventCount>0)
                mapMain.TrackingLayer.RemoveEvent(0);
            ShowLayers();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GWLoadLayers()
        {
            for(int i=0;i<mapLayer.m_layers.Length;i++)
            {
                //				if(mapLayer.m_layers[i].typeName=="背景层")
                //					mapLayer.m_layers[i].layer.Visible=false;
                //				else
                mapLayer.m_layers[i].layer.Visible=true;
            }
            ShowLayers();
        }

        /// <summary>
        /// 
        /// </summary>
        private void JKLoadLayers()
        {
            for(int i=0;i<mapLayer.m_layers.Length;i++)
            {
                if(mapLayer.m_layers[i].typeName=="地图层")
                    mapLayer.m_layers[i].layer.Visible=false;
                else
                    mapLayer.m_layers[i].layer.Visible=true;
            }
            ShowLayers();
        }
        #endregion

        #region ToolsControl
        /// <summary>
        /// 
        /// </summary>
        private void InitializeTools()
        {
            radioButton1.Checked=true;
            InitList();
            InitMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                DTLoadLayers();
                InitList();
            }
            if(radioButton2.Checked==true)
            {
                GWLoadLayers();
                InitList();
            }
            if(radioButton3.Checked==true)
            {
                JKLoadLayers();
                InitList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                DTLoadLayers();
                InitList();
            }
            if(radioButton2.Checked==true)
            {
                GWLoadLayers();
                InitList();
            }
            if(radioButton3.Checked==true)
            {
                JKLoadLayers();
                InitList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitList()
        {
            listBox.Items.Clear();
            if(radioButton1.Checked==false)
            {
                listBox.Enabled=true;
                StationInfo sDataInfo=new StationInfo();
                s_Info=sDataInfo.GetPointInfo();
                string sn;
                for(int i=0;i<s_Info.Length;i++)
                {
                    sn=	s_Info[i].s_Name+STATIONNAME;	
                    listBox.Items.Add(sn);
                }
            }
            else
                listBox.Enabled=false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if(mapMain.TrackingLayer.EventCount>0)
                mapMain.TrackingLayer.RemoveEvent(0);
            if(listBox.SelectedItems.Count>0)
            {
                string slName=listBox.SelectedItem.ToString();
                string s;
                MapObjects2.Point selectP=new MapObjects2.PointClass();
                for(int i=0;i<s_Info.Length;i++)
                {
                    s=s_Info[i].s_Name+"热力站";
                    if(slName==s)
                    {
                        selectP.X=System.Convert.ToDouble(s_Info[i].s_East);
                        selectP.Y=System.Convert.ToDouble(s_Info[i].s_West);
                        mapMain.CenterAt(selectP.X,selectP.Y);
                        MapObjects2.Symbol selectS=mapMain.TrackingLayer.get_Symbol(0);
                        selectS.Color=System.Convert.ToUInt32(MapObjects2.ColorConstants.moBlue);
                        selectS.Size=10;
                        mapMain.TrackingLayer.AddEvent(selectP,0);
                    }
                }
            }
            if(this.timer1.Enabled==false)
                this.timer1.Enabled=true;
            else
            {
                this.timer1.Enabled=false;
                this.timer1.Enabled=true;
            }
        }
        #endregion

        #region MenuControl
        private void InitMenu()//(Point m)//
        {
            ////			Point position=new Point();
            //			GisMapMenu=new System.Windows.Forms.ContextMenu();
            //			this.GisMapMenu=this.GisMapMenu;
            //			MenuItem[] heatMenus=new MenuItem[4];
            //			MenuItem heatMenuItem1=new MenuItem("实时数据",new System.EventHandler(this.MenuClick_HeatNow));
            //			MenuItem heatMenuItem2=new MenuItem("数据查询",new System.EventHandler(this.MenuClick_HeatOld));
            //			MenuItem heatMenuItem3=new MenuItem("曲线查询",new System.EventHandler(this.MenuClick_HeatCurve));
            //			MenuItem heatMenuItem4=new MenuItem("报警查询",new System.EventHandler(this.MenuClick_HeatAlarm));
            //			heatMenus[0]=heatMenuItem1;
            //			heatMenus[1]=heatMenuItem2;
            //			heatMenus[2]=heatMenuItem3;
            //			heatMenus[3]=heatMenuItem4;
            ////			menuItem=new MenuItem("供热系统",heatMenus);
            ////			menuItem.Enabled=true;
            ////			GisMapMenu.MenuItems.Add( menuItem );
            ////			MenuItem[] subMenus=new MenuItem[2];
            ////			MenuItem subMenuItem1=new MenuItem("TM管理");
            ////			MenuItem subMenuItem2=new MenuItem("数据管理");
            ////			MenuItem subMenuItem3=new MenuItem("任务执行结果");
            ////			MenuItem subMenuItem4=new MenuItem("参数设置");
            //			subMenus[0]=subMenuItem1;
            //			subMenus[1]=subMenuItem2;
            //			subMenus[2]=subMenuItem3;
            ////			subMenus[3]=subMenuItem4;
            //			menuItem=new MenuItem("巡更系统",subMenus);
            //			GisMapMenu.MenuItems.Add( menuItem );	
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick_HeatNow(System.Object sender, System.EventArgs e)
        {
            if(GisMapSNo=="2")
            {
                frmDataNowD f=new frmDataNowD(GisMapSName);
                f.ShowDialog();
            }
            else
            {
                frmDataNow f=new frmDataNow(GisMapSName);
                f.ShowDialog();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick_HeatOld(System.Object sender, System.EventArgs e)
        {
            //			Grid.frmDataPrint f=new DataCurve.Grid.frmDataPrint(GisMapSName);
            //			f.Text=GisMapSName+"热力站数据查询";
            //			f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick_HeatCurve(System.Object sender, System.EventArgs e)
        {
            //			Curve.frmCurve f=new DataCurve.Curve.frmCurve(GisMapSName);
            //			f.Text=GisMapSName+"热力站曲线查询";
            //			f.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuClick_HeatAlarm(System.Object sender, System.EventArgs e)
        {
			
        }
        #endregion

        #region Other

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGisMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {		
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapMain_DrawingCanceled(object sender, System.EventArgs e)
        {
			
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mapMain_DblClick(object sender, System.EventArgs e)
        {
            //			if(tBarIndex==0)
            //			{
            //				if(radioButton1.Checked==false)
            //				{
            //					MapObjects2.Point point;
            //					point=mapMain.ToMapPoint(e.x,e.y);
            //					for(int i=0;i<s_Info.Length;i++)
            //					{
            //						if(point.X>System.Convert.ToDouble(s_Info[i].s_East)-5 &&point.X<System.Convert.ToDouble(s_Info[i].s_East)+5&&point.Y>System.Convert.ToDouble(s_Info[i].s_West)-5 && point.Y<System.Convert.ToDouble(s_Info[i].s_West)+5)
            //						{
            //							GisMapSName=s_Info[i].s_Name;
            //							GisMapSNo=s_Info[i].s_No;
            //							if(GisMapSNo=="2")
            //							{
            //								frmDataNowD f=new frmDataNowD(GisMapSName);
            //								f.ShowDialog();
            //							}
            //							else
            //							{
            //								frmDataNow f=new frmDataNow(GisMapSName);
            //								f.ShowDialog();
            //							}
            //						}
            //					}
            //				}
            //			}
        }
    }
}
