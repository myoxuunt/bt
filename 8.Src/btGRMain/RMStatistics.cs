using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace btGRMain
{
	/// <summary>
	/// RMStatistics 的摘要说明。
	/// </summary>
	public class RMStatistics
	{
		private string m_Name;
		private DateTime m_DTime;
		private DataTable m_dt=null;
		private DBcon con=null;

		public RMStatistics(DateTime DT,string StationName)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_DTime=DT;
			m_Name=StationName;
			con=new DBcon();
			
		}

		public DataTable GetRMDataTable()
		{
			m_dt=CreatDataTable();
			InsertGatherValue();
			InsertYestValue();
			InsertAddPump();
			InsertYestAddPump();
			InsertValueCount();
			return m_dt;
		}

		private void InsertGatherValue()
		{
			try
			{
				string strName="select name,team from tbl_gprs_station order by team desc";
				SqlDataAdapter daName=new SqlDataAdapter(strName,con.GetConnection());
				DataSet dsName=new DataSet();
				daName.Fill(dsName,"Name");
				daName.Dispose();
				int z=0;
				for(int i=0;i<dsName.Tables["Name"].Rows.Count;i++)
				{
					string str=@"select top 1 name,team,oneGiveTemp,oneBackTemp,twoGiveTemp,twoBackTemp,
                        oneGivePress,oneBackPress,twoGivePress,twoBackPress,oneAccum,heatArea, teamorder 
                        from v_HeatDatas where name='";

					str=str+dsName.Tables["Name"].Rows[i]["name"].ToString();
					str=str+"' and time between '";
					str=str+m_DTime;
					str=str+"' and '";
					str=str+m_DTime.AddHours(12);
					str=str+"' order by time asc";
			
					SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
					DataSet ds=new DataSet();
					da.Fill(ds,"T");
					da.Dispose();
					for(int j=0;j<ds.Tables["T"].Rows.Count;j++)
					{
						DataRow newrow =m_dt.NewRow();
						m_dt.Rows.Add(newrow);
						m_dt.Rows[z]["name"]=ds.Tables["T"].Rows[j]["name"].ToString();
						m_dt.Rows[z]["name1"]=ds.Tables["T"].Rows[j]["name"].ToString();
						m_dt.Rows[z]["team"]=ds.Tables["T"].Rows[j]["team"].ToString();
						m_dt.Rows[z]["oneGiveTemp"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneGiveTemp"]);
						m_dt.Rows[z]["oneBackTemp"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneBackTemp"]);
						m_dt.Rows[z]["twoGiveTemp"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["twoGiveTemp"]);
						m_dt.Rows[z]["twoBackTemp"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["twoBackTemp"]);
						m_dt.Rows[z]["oneGivePress"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneGivePress"]);
						m_dt.Rows[z]["oneBackPress"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneBackPress"]);
						m_dt.Rows[z]["twoGivePress"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["twoGivePress"]);
						m_dt.Rows[z]["twoBackPress"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["twoBackPress"]);
						m_dt.Rows[z]["oneAccum"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneAccum"]);
//						m_dt.Rows[z]["heatArea"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["heatArea"]);
                        m_dt.Rows[z]["teamorder"] = Convert.ToInt32( ds.Tables["T"].Rows[j]["teamorder"] );
						z=z+1;
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void InsertYestValue()
		{
			try
			{
				DateTime dtime=m_DTime.AddDays(-1);
				string strName="select name from v_HeatDatas group by name";
				SqlDataAdapter daName=new SqlDataAdapter(strName,con.GetConnection());
				DataSet dsName=new DataSet();
				daName.Fill(dsName,"Name");
				daName.Dispose();
				for(int i=0;i<dsName.Tables["Name"].Rows.Count;i++)
				{
					string str="select top 1 name,oneAccum from v_HeatDatas where name='";
					str=str+dsName.Tables["Name"].Rows[i]["name"].ToString();
					str=str+"' and time between '";
					str=str+dtime;
					str=str+"' and '";
					str=str+dtime.AddHours(12);
					str=str+"' order by time asc";
			
					SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
					DataSet ds=new DataSet();
					da.Fill(ds,"T");
					da.Dispose();
					for(int j=0;j<ds.Tables["T"].Rows.Count;j++)
					{
						for(int z=0;z<m_dt.Rows.Count;z++)
						{
							if(m_dt.Rows[z]["name"].ToString()==ds.Tables["T"].Rows[j]["name"].ToString())
							{
								m_dt.Rows[z]["YestOneAccum"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["oneAccum"]);
								continue;
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void InsertAddPump()
		{
			try
			{
				DateTime dtime=m_DTime.Date;
				string strName="select name from v_AddPumpDatas group by name";
				SqlDataAdapter daName=new SqlDataAdapter(strName,con.GetConnection());
				DataSet dsName=new DataSet();
				daName.Fill(dsName,"Name");
				daName.Dispose();
				for(int i=0;i<dsName.Tables["Name"].Rows.Count;i++)
				{
					string str="select top 1 name,addPumpValue from v_AddPumpDatas where name='";
					str=str+dsName.Tables["Name"].Rows[i]["name"].ToString();
					str=str+"' and time between '";
					str=str+dtime;
					str=str+"' and '";
					str=str+dtime.AddHours(12);
					str=str+"' order by time asc";
			
					SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
					DataSet ds=new DataSet();
					da.Fill(ds,"T");
					da.Dispose();
					for(int j=0;j<ds.Tables["T"].Rows.Count;j++)
					{
						for(int z=0;z<m_dt.Rows.Count;z++)
						{
							if(m_dt.Rows[z]["name"].ToString()==ds.Tables["T"].Rows[j]["name"].ToString())
							{
								m_dt.Rows[z]["addPumpValue"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["addPumpValue"]);
								continue;
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void InsertYestAddPump()
		{
			try
			{
				DateTime dtime=m_DTime.Date.AddDays(-1);
				string strName="select name from v_AddPumpDatas group by name";
				SqlDataAdapter daName=new SqlDataAdapter(strName,con.GetConnection());
				DataSet dsName=new DataSet();
				daName.Fill(dsName,"Name");
				daName.Dispose();
				for(int i=0;i<dsName.Tables["Name"].Rows.Count;i++)
				{
					string str="select top 1 name,addPumpValue from v_AddPumpDatas where name='";
					str=str+dsName.Tables["Name"].Rows[i]["name"].ToString();
					str=str+"' and time between '";
					str=str+dtime;
					str=str+"' and '";
					str=str+dtime.AddHours(12);
					str=str+"' order by time asc";
			
					SqlDataAdapter da=new SqlDataAdapter(str,con.GetConnection());
					DataSet ds=new DataSet();
					da.Fill(ds,"T");
					da.Dispose();
					for(int j=0;j<ds.Tables["T"].Rows.Count;j++)
					{
						for(int z=0;z<m_dt.Rows.Count;z++)
						{
							if(m_dt.Rows[z]["name"].ToString()==ds.Tables["T"].Rows[j]["name"].ToString())
							{
								m_dt.Rows[z]["YestAddPumpValue"]=System.Convert.ToDecimal(ds.Tables["T"].Rows[j]["addPumpValue"]);
								continue;
							}
						}
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
			
		private void InsertValueCount()
		{
			Decimal addWat;
			Decimal missWat;
			Decimal oneTempCha;
			Decimal dayHeat;
			Decimal avgHeat;
			for(int i=0;i<m_dt.Rows.Count;i++)
			{
				//bu
				if(m_dt.Rows[i]["YestAddPumpValue"]==DBNull.Value)
					addWat=0;
				else
					addWat=System.Convert.ToDecimal(m_dt.Rows[i]["YestAddPumpValue"]);
				if(m_dt.Rows[i]["AddPumpValue"]==DBNull.Value)
					addWat=0-addWat;
				else
					addWat=System.Convert.ToDecimal(m_dt.Rows[i]["addPumpValue"])-addWat;
				m_dt.Rows[i]["AddWat"]=addWat;
				//shi
				if(m_dt.Rows[i]["YestoneAccum"]==DBNull.Value)
					missWat=0;
				else
					missWat=System.Convert.ToDecimal(m_dt.Rows[i]["YestoneAccum"]);
				if(m_dt.Rows[i]["oneAccum"]==DBNull.Value)
					missWat=0-missWat;
				else
					missWat=System.Convert.ToDecimal(m_dt.Rows[i]["oneAccum"])-missWat;
				if(missWat==0)
					m_dt.Rows[i]["MissWat"]=DBNull.Value;
				else
					m_dt.Rows[i]["MissWat"]=Math.Round(addWat/missWat,2);
				//wencha
				if(m_dt.Rows[i]["oneBackTemp"]==DBNull.Value)
					oneTempCha=0;
				else
					oneTempCha=System.Convert.ToDecimal(m_dt.Rows[i]["oneBackTemp"]);
				if(m_dt.Rows[i]["oneGiveTemp"]==DBNull.Value)
					oneTempCha=0-oneTempCha;
				else
					oneTempCha=System.Convert.ToDecimal(m_dt.Rows[i]["oneGiveTemp"])-oneTempCha;
				m_dt.Rows[i]["oneTempCha"]=oneTempCha;
				//rihao
				dayHeat=missWat*oneTempCha;
				Decimal chan=System.Convert.ToDecimal(4.1868);
				dayHeat=dayHeat*chan/1000;
				m_dt.Rows[i]["dayHeat"]=Math.Round(dayHeat,2);
				//wanpingmire
				avgHeat=GetArea(m_dt.Rows[i]["Name"].ToString());
				m_dt.Rows[i]["heatArea"]=avgHeat;
				avgHeat=dayHeat/avgHeat;
				m_dt.Rows[i]["avgHeat"]=Math.Round(avgHeat,2);
			}
		}

		private Decimal GetArea(string stationName)
		{
			Decimal avgHeat;
			string str="select heatArea from tbl_gprs_station where name='"+stationName+"'";
			SqlDataAdapter daArea=new SqlDataAdapter(str,con.GetConnection());
			DataSet dsArea=new DataSet();
			daArea.Fill(dsArea,"Area");
			for(int i=0;i<dsArea.Tables["Area"].Rows.Count;i++)
			{
				if(dsArea.Tables["Area"].Rows[i]["heatArea"]==DBNull.Value)
					avgHeat=1;
				if(System.Convert.ToDecimal(dsArea.Tables["Area"].Rows[i]["heatArea"])<=0)
					avgHeat=1;
				else
				{
					avgHeat=System.Convert.ToDecimal(dsArea.Tables["Area"].Rows[i]["heatArea"]);
					return avgHeat;
				}
			}
			return 1;
		}

		private DataTable CreatDataTable()
		{
			DataTable dt=new DataTable("RMDayReport");

			DataColumn dc=new DataColumn();
			dc.ColumnName="name";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="team";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="heatArea";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

			//one

			dc=new DataColumn();
			dc.ColumnName="oneGivePress";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="oneBackPress";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="oneGiveTemp";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="oneBackTemp";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="oneTempCha";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="oneAccum";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="YestOneAccum";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			//er

			dc=new DataColumn();
			dc.ColumnName="twoGivePress";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="twoBackPress";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="twoGiveTemp";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="twoBackTemp";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			//other

			dc=new DataColumn();
			dc.ColumnName="addPumpValue";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="YestAddPumpValue";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="AddWat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="MissWat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="DayHeat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="AvgHeat";
			dc.DataType=System.Type.GetType("System.Decimal");
			dt.Columns.Add(dc);

			dc=new DataColumn();
			dc.ColumnName="name1";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);

            dc = new DataColumn("teamorder", typeof( int ) );
            dt.Columns.Add( dc );

            // TODO: add team order column
            //
			return dt;
		}
	
	}
}
