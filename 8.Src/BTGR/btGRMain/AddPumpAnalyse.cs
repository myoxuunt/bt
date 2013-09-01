using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace btGRMain
{
	/// <summary>
	/// AddPumpAnalyse 的摘要说明。
	/// </summary>
	public class AddPumpAnalyse
	{
		private DateTime m_Bdt;
		private DateTime m_Edt;
		private DateTime m_BTime;
		private DateTime m_ETime;
		private DateTime m_dtTitle;
		private string m_Name=null;
		private SqlDataAdapter da=null;
		private DBcon con=null;
		private HeatParameter ValueFlux=null;
		

		public AddPumpAnalyse(DateTime Begin,DateTime End,string StationName,DateTime dtTitle)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_Bdt=Begin.Date;
			m_Edt=End.Date;
			m_BTime=Begin;
			m_ETime=End;
			m_dtTitle=dtTitle;
			m_Name=StationName;
			con=new DBcon();
			ValueFlux=new HeatParameter();
//			LoadDatas();
		}


		public DataTable GetTableDatas()
		{
			try
			{
				int day=GetSpen(m_Bdt,m_Edt);
				string strB,strE;
				if(IFAllStation(m_Name))
				{
					strB="select * from v_AddPumpDatas where time = '"+m_Bdt+"' order by team desc";//+"' and '"+m_Bdt.AddDays(1)+"'";
					strE="select * from v_AddPumpDatas where time = '"+m_Edt+"' order by team desc";//+"' and '"+m_Edt.AddDays(1)+"'";
				}
				else
				{
					strB="select * from v_AddPumpDatas where name='"+m_Name+"' and time = '"+m_Bdt+"'";// and '"+m_Bdt.AddDays(1)+"'";
					strE="select * from v_AddPumpDatas where name='"+m_Name+"' and time = '"+m_Edt+"'";// and '"+m_Edt.AddDays(1)+"'";
				}
				DataTable dt=CreatTable();
				da=new SqlDataAdapter(strE,con.GetConnection());
				DataSet ds=new DataSet();
				da.Fill(ds,"End");
				da.Dispose();
				for(int i=0;i<ds.Tables["End"].Rows.Count;i++)
				{
					DataRow newrow = dt.NewRow();
					dt.Rows.Add(newrow);
					dt.Rows[i]["name"]=ds.Tables["End"].Rows[i]["name"].ToString();
					dt.Rows[i]["team"]=ds.Tables["End"].Rows[i]["team"].ToString();
					dt.Rows[i]["ValueEnd"]=System.Convert.ToDecimal(ds.Tables["End"].Rows[i]["addPumpValue"]);
				}
				da=new SqlDataAdapter(strB,con.GetConnection());
				ds=new DataSet();
				da.Fill(ds,"Begin");
				da.Dispose();
				for(int j=0;j<ds.Tables["Begin"].Rows.Count;j++)
				{
					for(int z=0;z<dt.Rows.Count;z++)
					{
						if(dt.Rows[z]["name"].ToString()==ds.Tables["Begin"].Rows[j]["name"].ToString())
						{
							string bnn=ds.Tables["Begin"].Rows[j]["addPumpValue"].ToString();
							dt.Rows[z]["ValueBegin"]=System.Convert.ToDecimal(ds.Tables["Begin"].Rows[j]["addPumpValue"]);
							dt.Rows[z]["AddWat"]=System.Convert.ToDecimal(dt.Rows[z]["ValueEnd"])-System.Convert.ToDecimal(dt.Rows[z]["ValueBegin"]);
							dt.Rows[z]["AverageWat"]=Math.Round(System.Convert.ToDecimal(dt.Rows[z]["AddWat"])/day,2);
							if(GetFluxJob(dt.Rows[z]["name"].ToString())==0)
								continue;
							dt.Rows[z]["MissWat"]=Math.Round(System.Convert.ToDecimal(dt.Rows[z]["AddWat"])/ GetFluxJob(dt.Rows[z]["name"].ToString()),2);
						}

					}
				}
				return dt;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
				return null;
			}
		}

		private int GetSpen(DateTime Begin,DateTime End)
		{
			for(int i=0;i<1000;i++)
			{
				if(Begin.AddDays(i)==End)
				{
					return i;
				}
			}
			return -1;
		}

		private DataTable CreatTable()
		{
			DataTable dt=new DataTable("AddPumpTrimTable");

			DataColumn dc=new DataColumn();
			dc.ColumnName="name";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="team";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="ValueBegin";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="ValueEnd";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="AddWat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="AverageWat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="MissWat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);
		
			return dt;
		}

		private Decimal GetFluxJob(string StationName)
		{
			HeatParameter hp=new HeatParameter();
			decimal FluxNow=hp.GetFlux(StationName,m_ETime);
			decimal FluxYest=hp.GetFlux(StationName ,m_BTime);
			decimal Flux=FluxNow-FluxYest;
			return Flux;

		}
		private bool IFAllStation(string name)
		{
			if(name=="<全部站>")
				return true;
			else
				return false;
		}
		private int ChangeID(string name)
		{
			int id;
			if(name=="<全部站>")
				return -1;
			else
			{
				string str="select grstation_id from tbl_grstation where name='"+name+"'";
				SqlCommand cmd=new SqlCommand(str,con.GetConnection());
				SqlDataReader dr=cmd.ExecuteReader();
				while(dr.Read())
				{
					id=System.Convert.ToInt32(dr.GetValue(0).ToString().Trim());
					return id;
				}
				dr.Close();
				cmd.Dispose();
				return -2;
			}
		}
	}
}
