using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Utilities;
namespace btGRMain
{
    /// <summary>
    /// InputExlPrint 的摘要说明。
    /// </summary>
    public class InputExlPrint
    {
        #region Members
        //		private ExcelTitle[] m_Title=null;
        private Excel.ApplicationClass m_exl=null;
        private DataTable m_dt=null;
        //        private DataView m_dt;
        private DateTime m_Begin;
        private DateTime m_End;
        private string m_AddWat;
        private string m_MissHeat;
        private bool m_bool=false;
        private object miss=System.Reflection.Missing.Value;
        #endregion //Members

        #region InputExlPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="d_bool"></param>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        public InputExlPrint(DataTable dt,bool d_bool,DateTime Begin,DateTime End)
            //		public InputExlPrint(DataView dt,bool d_bool,DateTime Begin,DateTime End)
        {
            m_dt=dt;
            m_bool=d_bool;
            m_Begin=Begin;
            m_End=End;
            InputExcel();
        }
        #endregion //InputExlPrint

        #region InputExlPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Dtime"></param>
        /// <param name="AllAddWat"></param>
        /// <param name="AllMissHeat"></param>
        public InputExlPrint(DataTable dt,DateTime Dtime,string AllAddWat,string AllMissHeat)
            //		public InputExlPrint(DataView dt,DateTime Dtime,string AllAddWat,string AllMissHeat)
        {
            m_dt=dt;
            m_Begin=Dtime;
            m_AddWat=AllAddWat;
            m_MissHeat=AllMissHeat;
            InputRmExcel();			
        }
        #endregion //InputExlPrint

        #region InputExlPrint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Begin"></param>
        /// <param name="End"></param>
        /// <param name="dt"></param>
        public InputExlPrint(DateTime Begin,DateTime End,DataTable dt)
        {
            m_dt=dt;
            m_Begin=Begin;
            m_End=End;
            InputGrossExcel();
        }
        #endregion //InputExlPrint

        #region InputGrossExcel
        /// <summary>
        /// 
        /// </summary>
        private void InputGrossExcel()
        {
            try
            {
                if(m_dt.Rows.Count==0)
                {
                    MessageBox.Show(
                        "没有可导入的数据！"
                        ,"错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else
                {
                    string str=Path.GetDirectoryName(Application.ExecutablePath)+"\\report\\Gross.xls";
                    m_exl=new Excel.ApplicationClass();
                    Excel.Workbook eWork=m_exl.Workbooks.Add(str);
                    //					eWork.SaveCopyAs("ll");
                    m_exl.Cells[1,1]="厂统计室数据分析报表";
                    m_exl.Cells[2,1]=m_Begin.ToShortDateString()+" 至 "+m_End.ToShortDateString();
                    for(int i=0;i<m_dt.Columns.Count;i++)
                    {
                        if(m_dt.Columns[i].ColumnName=="time")
                        {
                            for(int j=0;j<m_dt.Rows.Count;j++)
                            {	
                                m_exl.Cells[j+4,i+1]=System.Convert.ToDateTime(m_dt.Rows[j][i]).ToShortDateString();
                            }
                        }
                        else
                        {
                            for(int j=0;j<m_dt.Rows.Count;j++)
                            {	
                                m_exl.Cells[j+4,i+1]=m_dt.Rows[j][i].ToString();
                            }
                        }
                    }
                    m_exl.Visible=true;
                    m_exl=null;
                    eWork=null;
                    GC.Collect();
                }
            }
            catch(Exception ex)
            {
                ExceptionHandler.Handle(ex );
                return;
            }
        }
        #endregion //InputGrossExcel

        #region ReadTitle
        /// <summary>
        /// 
        /// </summary>
        private void ReadTitle()
        {

        }
        #endregion //ReadTitle

        #region InputRmExcel
        /// <summary>
        /// 
        /// </summary>
        private void InputRmExcel()
        {
            try
            {
                if(m_dt.Rows.Count==0)
                {
                    MessageBox.Show(
                        "没有可导入的数据！",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                }
                else
                {
                    string str=Path.GetDirectoryName(Application.ExecutablePath)+"\\report\\DayParameter.xls";
                    m_exl=new Excel.ApplicationClass();
                    Excel.Workbook eWork=m_exl.Workbooks.Add(str);
                    //					eWork.SaveCopyAs("ll");
                    m_exl.Cells[1,1]=m_Begin.Year.ToString()+"年"+m_Begin.Month.ToString()+"月"+m_Begin.Day.ToString()+"日热力泵站热媒参数统计表";
                    for(int i=0;i<m_dt.Columns.Count;i++)
                    {
                        for(int j=0;j<m_dt.Rows.Count;j++)
                        {	
                            m_exl.Cells[j+4,i+1]=m_dt.Rows[j][i].ToString();
                        }
                    }
                    Excel.Range m_Range;
                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+4,1],m_exl.Cells[m_dt.Rows.Count+4,19]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;

                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,1],m_exl.Cells[m_dt.Rows.Count+5,5]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,1]="总补水量";
                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,6],m_exl.Cells[m_dt.Rows.Count+5,10]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,6]=m_AddWat;

                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,12],m_exl.Cells[m_dt.Rows.Count+5,15]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,12]="总耗热量";
                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,16],m_exl.Cells[m_dt.Rows.Count+5,19]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,16]=m_MissHeat;
					
                    m_exl.Visible=true;
                    m_exl=null;
                    eWork=null;
                    GC.Collect();
                }
            }
            catch(Exception ex)
            {
                ExceptionHandler.Handle( ex );
                return;
            }
        }
        #endregion //InputRmExcel

        #region InputExcel
        /// <summary>
        /// 
        /// </summary>
        private void InputExcel()
        {
            if(m_dt.Rows.Count==0)
            {
                MessageBox.Show(
                    "没有可导入的数据！",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                if(m_bool)
                {
                    Decimal AllValue = 0;
                    string str = Path.GetDirectoryName(Application.ExecutablePath)
                        + "\\report\\BSFX.xls";
                    m_exl = new Excel.ApplicationClass();
                    //					m_exl.Workbooks.Add(true);
                    Excel.Workbook eWork=m_exl.Workbooks.Add(str);//添加格式
                    //					Excel.Workbook wok=m_exl.Workbooks.Open(str);//打开路径已有;
	
					
                    if(m_End.Month-m_Begin.Month>0)
                        m_exl.Cells[1,1]=m_End.Year.ToString()+"年度热力泵站补水系统参数分析表";
                    else
                        m_exl.Cells[1,1]=m_End.Year.ToString()+"年"+m_End.Month.ToString()+"月份热力泵站补水系统参数分析表";
                    m_exl.Cells[2,3]=m_Begin.Month.ToString()+"月"+m_Begin.Day.ToString()+"日";
                    m_exl.Cells[2,4]=m_End.Month.ToString()+"月"+m_End.Day.ToString()+"日";
                    for(int i=0;i<m_dt.Columns.Count;i++)
                    {
                        for(int j=0;j<m_dt.Rows.Count;j++)
                        {	
                            m_exl.Cells[j+4,i+1]=m_dt.Rows[j][i].ToString();
                            string sss=m_dt.Columns[i].ColumnName.ToString();
                            if(m_dt.Columns[i].ColumnName.ToString()=="AddWat")
                            {
                                if(m_dt.Rows[j][i]!=System.DBNull.Value)
                                {
                                    AllValue=AllValue+System.Convert.ToDecimal(m_dt.Rows[j][i]);
                                }
                            }
                        }
                    }
                    Excel.Range m_Range;
                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+4,1],m_exl.Cells[m_dt.Rows.Count+4,7]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;

                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,1],m_exl.Cells[m_dt.Rows.Count+5,3]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,1]="总补水量";
                    m_Range=m_exl.get_Range(m_exl.Cells[m_dt.Rows.Count+5,4],m_exl.Cells[m_dt.Rows.Count+5,7]);
                    m_Range.Merge(System.Reflection.Missing.Value);
                    m_Range.Font.Size=12;
                    m_exl.Cells[m_dt.Rows.Count+5,4]=AllValue;
                    m_exl.DisplayAlerts=true;
                    m_exl.Visible=true;
                    //					eWork.SaveCopyAs("d:\\Report\\补水分析表.xls");
                    m_exl=null;
                    eWork=null;
                    GC.Collect();
                }
                else
                {
                    string str=Path.GetDirectoryName(Application.ExecutablePath)+"\\report\\BSDB.xls";
                    m_exl=new Excel.ApplicationClass();
                    //m_exl.Workbooks.Add(true);
                    Excel.Workbook eWork=m_exl.Workbooks.Add(str);//true)
                    //eWork.SaveCopyAs("ll");
                    //if(m_End.Month-m_Begin.Month>0)
                    //{
                    //m_exl.Cells[1,1]=m_End.Year.ToString()+"年度热力泵站补水数据表";
                    //}
                    //else
                    //{
                    //m_exl.Cells[1,1]=m_End.Year.ToString()+"年"+m_End.Month.ToString()+"月份热力泵站补水数据表";
                    //}
                    m_exl.Cells[1, 1] = "热力站补水数据表";
                    m_exl.Cells[2,1]  //m_Begin.Month.ToString()+"月"+m_Begin.Day.ToString()+"日 至 "+m_End.Month.ToString()+"月"+m_End.Day.ToString()+"日";
                        = string.Format( "{0} 至 {1}", m_Begin.ToShortDateString(), m_End.ToShortDateString() );

                    for(int i=0;i<m_dt.Columns.Count;i++)
                    {
                        for(int j=0;j<m_dt.Rows.Count;j++)
                        {	
                            m_exl.Cells[j+4,i+1]=m_dt.Rows[j][i].ToString();
                        }
                    }
                    m_exl.Visible=true;
                    m_exl=null;
                    eWork=null;
                    GC.Collect();
                }
            }
        }
        #endregion //InputExcel
    }
}
