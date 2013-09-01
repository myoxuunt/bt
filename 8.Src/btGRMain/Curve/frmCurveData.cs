using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace btGRMain.Curve
{
    /// <summary>
    /// frmCurveData 的摘要说明。
    /// </summary>
    public class frmCurveData : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private string m_Station;
        // 2007.05.31
        //
        //private string[] m_Curve;
        private DateTime m_Begin;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private DateTime m_End;
        private string Title;
        private DataSet ds=null;
        private bool d_Type=false;

        public frmCurveData()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            d_Type=true;
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }
        public frmCurveData(string Name,string Station,DataSet Curve,DateTime Begin,DateTime End)
        {
            InitializeComponent();
            Title=Name;
            this.Text=Title+" 曲线数据";
            m_Station=Station;
            //			m_Curve=new string[Curve.Length];
            //			for(int i=0;i<Curve.Length;i++)
            //			{
            //				m_Curve[i]=Curve[i];
            //				MessageBox.Show(m_Curve[i]);
            //			}
            ds=Curve;
			
            m_Begin=Begin;
            m_End=End;
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
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(0, 0);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.ReadOnly = true;
            this.m_dataGrid.Size = new System.Drawing.Size(242, 431);
            this.m_dataGrid.TabIndex = 0;
            // 
            // frmCurveData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(242, 431);
            this.Controls.Add(this.m_dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCurveData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCurveData";
            this.Load += new System.EventHandler(this.frmCurveData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void frmCurveData_Load(object sender, System.EventArgs e)
        {
            InitGridDataTitle();
            RefreshDataGrid();
        }
        #region InitializeGrid
        private void InitGridDataTitle()
        {
            DataGridTableStyle tbs= new DataGridTableStyle();
            DataGridTextBoxColumn clmTime = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue3 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue4 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue5 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue6 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue7 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue8 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue9 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue10 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue11 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue12 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue13 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue14 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue15 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue16 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue17 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue18 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn clmValue19 = new DataGridTextBoxColumn();
            if(d_Type)
            {
                clmValue18.MappingName ="name";
                clmValue18.HeaderText  ="站名称";
                clmValue19.MappingName ="team";
                clmValue19.HeaderText  ="所属班组";
            }
            clmTime.MappingName ="time";
            clmTime.HeaderText  ="时间";
            clmValue1.MappingName ="oneGiveTemp";
            clmValue1.HeaderText  ="一次供水温度";
            clmValue2.MappingName ="oneBackTemp";
            clmValue2.HeaderText  ="一次回水温度";
            clmValue3.MappingName ="oneGivePress";
            clmValue3.HeaderText  ="一次供水压力";
            clmValue4.MappingName ="oneBackPress";
            clmValue4.HeaderText  ="一次回水压力";

            clmValue5.MappingName ="twoGiveTemp";
            clmValue5.HeaderText  ="二次供水温度";
            clmValue6.MappingName ="twoBackTemp";
            clmValue6.HeaderText  ="二次回水温度";
            clmValue7.MappingName ="twoGivePress";
            clmValue7.HeaderText  ="二次供水压力";
            clmValue8.MappingName ="twoBackPress";
            clmValue8.HeaderText  ="二次回水压力";

            clmValue9.MappingName ="outsideTemp";
            clmValue9.HeaderText  ="室外温度";

            clmValue10.MappingName ="oneInstant";
            clmValue10.HeaderText  ="一次瞬时流量";
            clmValue11.MappingName ="twoInstant";
            clmValue11.HeaderText  ="二次瞬时流量";
            clmValue12.MappingName ="oneAccum";
            clmValue12.HeaderText  ="一次累积流量";
            clmValue13.MappingName ="twoAccum";
            clmValue13.HeaderText  ="二次累积流量";

            clmValue14.MappingName ="openDegree";
            clmValue14.HeaderText  ="调节阀开度";
            clmValue15.MappingName ="twoPressCha";
            clmValue15.HeaderText  ="二次供回压差";
            clmValue16.MappingName ="WatBoxLevel";
            clmValue16.HeaderText  ="水箱水位";

            clmValue17.MappingName ="twoGiveBaseTemp";
            clmValue17.HeaderText  ="二次供水基准温度";

			

            tbs.GridColumnStyles.Add (clmTime);
            tbs.GridColumnStyles[0].Width=120;
            tbs.GridColumnStyles.Add (clmValue1);
            tbs.GridColumnStyles[1].Width=90;
            tbs.GridColumnStyles.Add (clmValue2);
            tbs.GridColumnStyles[2].Width=90;
            tbs.GridColumnStyles.Add (clmValue3);
            tbs.GridColumnStyles[3].Width=90;
            tbs.GridColumnStyles.Add (clmValue4);
            tbs.GridColumnStyles[4].Width=90;
            tbs.GridColumnStyles.Add (clmValue5);
            tbs.GridColumnStyles[5].Width=90;
            tbs.GridColumnStyles.Add (clmValue6);
            tbs.GridColumnStyles[6].Width=90;
            tbs.GridColumnStyles.Add (clmValue7);
            tbs.GridColumnStyles[7].Width=90;
            tbs.GridColumnStyles.Add (clmValue8);
            tbs.GridColumnStyles[8].Width=90;
            tbs.GridColumnStyles.Add (clmValue9);
            tbs.GridColumnStyles[9].Width=90;
            tbs.GridColumnStyles.Add (clmValue10);
            tbs.GridColumnStyles[10].Width=90;
            tbs.GridColumnStyles.Add (clmValue11);
            tbs.GridColumnStyles[11].Width=90;
            tbs.GridColumnStyles.Add (clmValue12);
            tbs.GridColumnStyles[12].Width=90;
            tbs.GridColumnStyles.Add (clmValue13);
            tbs.GridColumnStyles[13].Width=90;
            tbs.GridColumnStyles.Add (clmValue14);
            tbs.GridColumnStyles[14].Width=90;
            tbs.GridColumnStyles.Add (clmValue15);
            tbs.GridColumnStyles[15].Width=90;
            tbs.GridColumnStyles.Add (clmValue16);
            tbs.GridColumnStyles[16].Width=90;
            tbs.GridColumnStyles.Add (clmValue17);
            tbs.GridColumnStyles[17].Width=105;
			
            if(d_Type)
            {
                tbs.GridColumnStyles.Add (clmValue18);
                tbs.GridColumnStyles[18].Width=90;
                tbs.GridColumnStyles.Add (clmValue19);
                tbs.GridColumnStyles[19].Width=90;
            }
			
            tbs.MappingName ="Table";
            m_dataGrid.TableStyles.Add(tbs);
        }

        private DataTable CreatTable()
        {
            DataTable dt=new DataTable("Table");

            DataColumn dc=new DataColumn();
            dc.ColumnName="name";
            dc.DataType=System.Type.GetType("System.String");
            dt.Columns.Add(dc);

            dc=new DataColumn();
            dc.ColumnName="team";
            dc.DataType=System.Type.GetType("System.String");
            dt.Columns.Add(dc);
	
            dc=new DataColumn();
            dc.ColumnName="time";
            dc.DataType=System.Type.GetType("System.DateTime");
            dt.Columns.Add(dc);

            dc=new DataColumn();
            dc.ColumnName="oneBackTemp";
            dc.DataType=System.Type.GetType("System.Decimal");
            dt.Columns.Add(dc);
            return dt;
        }
        #endregion
        private void RefreshDataGrid()
        {
            try
            {
                if(!d_Type)
                {
                    m_dataGrid.DataSource=ds.Tables[0].DefaultView;
                    this.Width=170+90*(ds.Tables[0].Columns.Count-1);
                }
                else
                {
                    DataTable dt=CreatTable();
                    DBcon con=new DBcon();
                    int z=0;
                    string strName="select name from v_HeatDatas group by name";
                    SqlDataAdapter daName=new SqlDataAdapter(strName,con.GetConnection());
                    DataSet dsName=new DataSet();
                    daName.Fill(dsName,"Name");
                    daName.Dispose();
                    for(int i=0;i<dsName.Tables["Name"].Rows.Count;i++)
                    {
                        string str="select top 1 name,team,time,oneBackTemp from v_HeatDatas where name='"+dsName.Tables["Name"].Rows[i]["name"].ToString()+"' order by time desc";
                        SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
                        DataSet dsOBT=new DataSet();
                        da.Fill(dsOBT,"table");
                        for(int j=0;j<dsOBT.Tables["table"].Rows.Count;j++)
                        {
                            DataRow newrow =dt.NewRow();
                            dt.Rows.Add(newrow);
                            dt.Rows[z]["name"]=dsOBT.Tables["table"].Rows[j]["name"].ToString();
                            dt.Rows[z]["team"]=dsOBT.Tables["table"].Rows[j]["team"].ToString();
                            dt.Rows[z]["time"]=System.Convert.ToDateTime(dsOBT.Tables["table"].Rows[j]["time"].ToString());
                            dt.Rows[z]["oneBackTemp"]=System.Convert.ToDecimal(dsOBT.Tables["table"].Rows[j]["oneBackTemp"].ToString());
                            z=z+1;
                        }
						
                    }
                    m_dataGrid.DataSource=dt;
                    this.Width=184+90*(dt.Columns.Count-1);
					
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
