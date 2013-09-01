using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Excel;
using System.IO;
using Point = System.Drawing.Point;

namespace Communication
{
	/// <summary>
	/// 将巡更数据到出到Excel表中
	/// </summary>
	public class XgDataExport
	{
        #region Members
        private DateTime _beginDt;
        private DateTime _endDt;
        private System.Data.DataTable _table;

        private Point ptTitle = new Point( 1, 1 );
        private Point ptXgDataBegin = new Point(1, 4 );

        #endregion //Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDt"></param>
        /// <param name="endDt"></param>
        /// <param name="table"></param>
        public XgDataExport(
            DateTime beginDt,
            DateTime endDt,
            System.Data.DataTable table
            )
        {
            _beginDt = beginDt;
            _endDt = endDt;

            Debug.Assert( table != null );
            _table = table;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            Excel.ApplicationClass e = Open( GetXlsFileName() );
            if ( e != null )
            {
                e.Cells[ ptTitle.Y, ptTitle.X ] = MakeTitle();
                int rowOffset = 0;
                foreach( DataRow row in _table.Rows )
                {
                    string team   = row[1].ToString().Trim();
                    string stName = row[2].ToString().Trim();
                    string person = row[3].ToString().Trim();
                    string dt     = row[5].ToString().Trim();
                    
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 0 ] = team;
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 1 ] = stName;
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 2 ] = person;
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 3 ] = dt;
                    rowOffset ++;
                }
                e.Visible = true;
//                e.Workbooks.Close();
                e = null;
                GC.Collect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MakeTitle()
        {
            string s = string.Format(
                "{0} 至 {1} 巡更数据",
                _beginDt,
                _endDt
                );
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetXlsFileName()
        {
            string str = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
                "\\report\\rptXgData.xls";

            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlsFileName"></param>
        /// <returns></returns>
        private Excel.ApplicationClass Open( string xlsFileName )
        {
            try
            {
                Excel.ApplicationClass excelCls = new ApplicationClass();
                Excel.Workbook excelWb = excelCls.Workbooks.Add( xlsFileName );
                return excelCls;
            }
            catch( Exception ex )
            {
                MsgBox.Show(
                    ex.ToString(),
                    "错误",
                    MessageBoxIcon.Error
                    );
                return null;
            }
        }
	}

    /// <summary>
    /// 
    /// </summary>
    public class XgCountExport
    {
        #region Members
        private DateTime _beginDt;
        private DateTime _endDt;
        private System.Data.DataTable _table;

        private Point ptTitle = new Point( 1, 1 );
        private Point ptXgDataBegin = new Point(1, 4 );

        #endregion //Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDt"></param>
        /// <param name="endDt"></param>
        /// <param name="table"></param>
        public XgCountExport(
            DateTime beginDt,
            DateTime endDt,
            System.Data.DataTable table
            )
        {
            _beginDt = beginDt;
            _endDt = endDt;

            Debug.Assert( table != null );
            _table = table;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            Excel.ApplicationClass e = Open( GetXlsFileName() );
            if ( e != null )
            {
                e.Cells[ ptTitle.Y, ptTitle.X ] = MakeTitle();
                int rowOffset = 0;
                foreach( DataRow row in _table.Rows )
                {
                    string team   = row[0].ToString().Trim();
                    string stName = row[1].ToString().Trim();
                    string count  = row[2].ToString().Trim();
                    
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 0 ] = team;
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 1 ] = stName;
                    e.Cells[ ptXgDataBegin.Y + rowOffset, ptXgDataBegin.X + 2 ] = count;
                    rowOffset ++;
                }
                e.Visible = true;
//                e.Workbooks.Close();
                e = null;
                GC.Collect();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MakeTitle()
        {
            string s = string.Format(
                "{0} 至 {1} 巡更次数",
                _beginDt,
                _endDt
                );
            return s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetXlsFileName()
        {
            string str = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
                "\\report\\rptXgCount.xls";

            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xlsFileName"></param>
        /// <returns></returns>
        private Excel.ApplicationClass Open( string xlsFileName )
        {
            try
            {
                Excel.ApplicationClass excelCls = new ApplicationClass();
                Excel.Workbook excelWb = excelCls.Workbooks.Add( xlsFileName );
                return excelCls;
            }
            catch( Exception ex )
            {
                MsgBox.Show(
                    ex.ToString(),
                    "错误",
                    MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
