using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;
namespace btGRMain.Grid
{
	/// <summary>
	/// ExcelInput 的摘要说明。
	/// </summary>
	public class ExcelInput
	{
		private ExcelTitle[] m_Title=null;
		private Excel.ApplicationClass m_exl=null;
		private DataTable m_dt=null;
		private bool m_bool=false;
		private object miss=System.Reflection.Missing.Value;
		private string m_time;
		public ExcelInput(DataTable dt,bool d_bool,string time)
		{
			m_dt=dt;
			m_bool=d_bool;
			m_time=time;
			ReadTitle();
			InputExcel();
		}

		/// <summary>
		/// 
		/// </summary>
		private void ReadTitle()
		{
			if(m_bool)
			{
				XmlDocument xDoc=new XmlDocument();
				xDoc.Load("DataInfo.xml");
				XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table");
				m_Title=new ExcelTitle[m_dt.Columns.Count];
				for(int i=0;i<xNode.ChildNodes.Count;i++)
				{
					for(int j=0;j<m_dt.Columns.Count;j++)
					{
						if(m_dt.Columns[j].ColumnName==xNode.ChildNodes[i].Attributes.GetNamedItem("name").Value.ToString().Trim())
						{
							m_Title[j].title=xNode.ChildNodes[i].InnerText.Trim();
							m_Title[j].name=xNode.ChildNodes[i].Attributes.GetNamedItem("name").Value.ToString().Trim();
						}
					}
				}
			}
			else
			{
				XmlDocument xDoc=new XmlDocument();
				xDoc.Load("DataInfo.xml");
				XmlNode xNode=xDoc.DocumentElement.SelectSingleNode("./table");
				m_Title=new ExcelTitle[xNode.ChildNodes.Count];
				for(int i=0;i<xNode.ChildNodes.Count;i++)
				{
					m_Title[i].title=xNode.ChildNodes[i].InnerText.Trim();
					m_Title[i].name=xNode.ChildNodes[i].Attributes.GetNamedItem("name").Value.ToString().Trim();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		private void InputExcel()
		{
			//			if(m_dt.Rows.Count==0)
			//			else
			//			{
			//				m_exl=new Excel.ApplicationClass();
			//				m_exl.Workbooks.Add ( true );
			//				for(int j=0;j<m_dt.Columns.Count;j++)
			//				{
			//					for(int z=0;z<m_Title.Length;z++)
			//					{
			//						if(m_dt.Columns[j].ColumnName==m_Title[z].name)
			//						{
			//							m_exl.Cells[2,j+1]=m_Title[z].title;
			//							for(int i=0;i<m_dt.Rows.Count;i++)
			//							{
			//								m_exl.Cells[i+3,j+1]=m_dt.Rows[i][j];
			//							}
			//							break;
			//						}
			//						
			//					}
			//					continue;
			//				}
			//				m_exl.Visible=true;
			//			}
			//			else
			//			{
			string str=Path.GetDirectoryName(Application.ExecutablePath)+"\\report\\GRDB.xls";
			m_exl=new Excel.ApplicationClass();
			//				m_exl.Workbooks.Add(true);
			Excel.Workbook eWork=m_exl.Workbooks.Add(str);//true)
				
				
			eWork.SaveCopyAs("ll");
			m_exl.Cells[2,1]=m_time;
			for(int i=1;i<m_Title.Length;i++)
			{
				for(int j=0;j<m_dt.Columns.Count;j++)
				{
					if(m_dt.Columns[j].ColumnName==m_Title[i].name)
					{
						//							m_exl.Cells[2,i]=m_Title[i].title;
						for(int z=0;z<m_dt.Rows.Count;z++)
						{
							m_exl.Cells[z+5,i]=m_dt.Rows[z][j];
						}
					}
				}
			}
			m_exl.Visible=true;
				
			//			}
		}

	}
	public struct ExcelTitle
	{
		public string name;
		public string title;
	}
}