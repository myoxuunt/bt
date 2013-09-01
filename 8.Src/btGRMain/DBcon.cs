using System;
using System.Xml ;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Utilities;

namespace btGRMain
{
	/// <summary>
	/// DBcon 的摘要说明。
	/// </summary>
	public class DBcon
	{
//		private SqlConnection con;
//		string str=null;

        /// <summary>
        /// 
        /// </summary>
		public DBcon()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
//			XmlDocument XDoc=new XmlDocument();
//			XDoc.Load("Server.xml");
//			XmlNode XNode=XDoc.DocumentElement.SelectSingleNode("./SqlCon");
//			for(int i=0;i<XNode.ChildNodes.Count;i++)
//			{
//				str=str+XNode.ChildNodes[i].Name;
//				str=str+"=";
//				str=str+XNode.ChildNodes[i].InnerText.Trim();
//				str=str+";";
//			}
//			con=new SqlConnection(str);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public SqlConnection GetConnection()
		{
//			try
//			{
//				if(con.State!=ConnectionState.Open)
//				{
//					con.Open();
//				}
//				return con;
//			}				
//			catch(Exception ex)
//			{
//                ExceptionHandler.Handle("打开连接失败！", ex );
//				return null;
//			}
			return Utilities.Database.DbClient.Default.Connection as SqlConnection;
		}
	}

    /// <summary>
    /// 
    /// </summary>
	public struct CurveInfo
	{
		public string m_Chart;
		public string m_Sqlname;
		public string m_Type;
		public string m_Y;
	}

    /// <summary>
    /// 
    /// </summary>
	public struct DataGridTitle
	{
		public string m_GName;
		public string m_GTitle;
		public string m_GWidth;
		public string m_GUnit;
	}

    /// <summary>
    /// 
    /// </summary>
	public struct TypeInfo
	{
		public string m_TNum;
		public string m_TName;
	}
}
