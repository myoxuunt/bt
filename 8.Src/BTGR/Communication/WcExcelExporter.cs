using System;
using Excel;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Communication
{
    #region WcExcelExporter
    /// <summary>
    /// 
    /// </summary>
    public class WcExcelExporter
    {
        #region Members
        private DateTime _beginDate,
            _endDate;
        private WccResultSet _wccrSet;

        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="wccrSet"></param>
        public WcExcelExporter(DateTime beginDate, DateTime endDate, WccResultSet wccrSet)
        {
            _beginDate = beginDate.Date;
            _endDate = endDate.Date;
            _wccrSet = wccrSet;
            MsgBox.Show("new wcexce;exporter");
        }
        #endregion //Constructor

        #region Properties
        #endregion //Properties

        #region Method

        #region OpenExcel
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Excel.ApplicationClass OpenExcel()
        {
            try
            {
                string xlsFileName = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) +
                    "\\report\\rptWcMonth.xls";
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
        #endregion //OpenExcel

        #region GetReportTitle
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetReportTitle()
        {
            string s = string.Format( 
                "{0} 至 {1} 耗热量统计表",
                this._beginDate.ToShortDateString(),
                this._endDate.ToShortDateString()
                );

            return s;
        }
        #endregion //GetReportTitle

        #region Export
        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            // (row, col)
            //
            // StationName form (4,1)  row ++
            // Date        from (3,2)  col ++
            DateTime dt1 = DateTime.Now;
            Excel.ApplicationClass excel = OpenExcel();
            DateTime dt2 = DateTime.Now;
            MsgBox.Show("open excel: ", (dt2 - dt1).ToString() );
            if (excel == null)
                return ;

            excel.Cells[ 1, 1 ] = GetReportTitle();
            WriteDate( excel, this._beginDate, this._endDate ); 

            int rowOffset = 4;
            int colOffset = 2;

            for( int i=0; i<_wccrSet.Count; i++ )
            {
                WccResultsCollection wccs = _wccrSet[i];
                string stname = wccs.StationName;
                int row = rowOffset + i;
                excel.Cells[ row, 1 ] = stname;

                for( int j=0; j<wccs.Count; j++ )
                {
                    WccResult wccr = wccs[j];
                    DateTime dt = wccr.Date;
                    int wc = wccr.WastingCaloric;
                    //int col = colOffset + j + 1;
                    int col = GetDateCol( dt ) + colOffset;

                    // 0 - 无数据
                    // 1 - 只有一条记录无法计算
                    //
                    if ( wccr.WastingCaloric > 0 &&
                        wccr.WastingCaloric != 0 && 
                        wccr.WastingCaloric != 1 )
                        excel.Cells[ row, col ] = wccr.WastingCaloric;
                }
            }

            excel.Visible = true;
        }
        #endregion //Export

        #region GetDateCol
        /// <summary>
        /// 获取dt到beginDate的天数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int GetDateCol( DateTime dt )
        {
            TimeSpan ts = dt.Date - this._beginDate;
            int days = (int)ts.TotalDays;
            return days;
            
        }
        #endregion //GetDateCol

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="excel"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private void WriteDate( 
            Excel.ApplicationClass excel, 
            DateTime begin, 
            DateTime end 
            )
        {
            // date begin pos: row 3, col 2
            int row = 3;
            int col = 2;

            Debug.Assert( begin.Date < end.Date );
            
            DateTime dt = begin.Date;
            int colOffset = 0;

            while( dt <= end.Date )
            {
                string strDate = string.Format( "{0}月{1}日", dt.Month, dt.Day );
                excel.Cells[ row, col + colOffset ] = strDate;
                colOffset++;
                dt = dt.AddDays( 1 );
            }
        }
        #endregion //

        #endregion //Method
    }
    #endregion //WcExcelExporter
}