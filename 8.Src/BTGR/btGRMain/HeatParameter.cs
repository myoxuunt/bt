using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace btGRMain
{
	/// <summary>
	/// HeatParameter 的摘要说明。
	/// </summary>
	public class HeatParameter
	{
		private DBcon con=null;
		public HeatParameter()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			con=new DBcon();
		}
		public Decimal GetFlux(string StationName,DateTime dt)
		{
			decimal ValueFlux;
			string str=GetQuestion(StationName,dt);
			SqlCommand cmd=new SqlCommand(str,con.GetConnection());
			SqlDataReader dr=cmd.ExecuteReader();
			while(dr.Read())
			{
				ValueFlux=System.Convert.ToDecimal(dr.GetValue(0));
				dr.Close();
				return ValueFlux;
			}
			dr.Close();
			return 0;
		}

		private string GetQuestion(string StationName,DateTime dt)
		{
			DateTime dtStop=dt.Date.AddDays(1);
			string str="select top 1 oneAccum from v_HeatDatas where name='";
			str=str+StationName+"' and time between '";
			str=str+dt+"' and '";
			str=str+dtStop+"' order by time asc";
			return str;
		}
	}
}
