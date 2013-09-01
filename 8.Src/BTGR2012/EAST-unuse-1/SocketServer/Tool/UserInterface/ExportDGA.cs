using System;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;
using System.Drawing;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using System.Runtime.InteropServices;

namespace Tool
{
    public class Export
    {
        public static void saveAs(DataGridView dgv,string name)
        {
            if (dgv.RowCount < 1)
            {
                MessageBox.Show("没有可导出的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = "Excel(*.xls)|*.xls|All Files(*.*)|*.*";
            dialog.FileName = DateTime.Now.Date.ToString("yyyyMMdd")+ ".xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                XlsFile xls = new XlsFile(true);
                xls.NewFile(1);    //Create a new Excel file with 1 sheet.
                xls.ActiveSheet = 1;    //Set the sheet we are working in.
                xls.SheetName = "Sheet1"; //Sheet Options 

                //Styles.默认单元格格式
                TFlxFormat StyleFmt;
                StyleFmt = xls.GetStyle("Normal");
                StyleFmt.Font.Name = "宋体";
                StyleFmt.Font.Size20 = 240;
                StyleFmt.Font.CharSet = 134;
                xls.SetStyle("Normal", StyleFmt);

                //Printer Settings 默认打印设置
                xls.SetPrintMargins(new TXlsMargins(0.7, 0.75, 0.7, 0.75, 0.3, 0.3));
                xls.PrintXResolution = 600;
                xls.PrintYResolution = 600;
                xls.PrintOptions = TPrintOptions.Orientation;
                xls.PrintPaperSize = TPaperSize.A4;

                //Set up rows and columns 默认单元格大小
                //11.88为100像素 
                xls.DefaultColWidth = 2340;
                xls.DefaultRowHeight = 285;

                //Set the cell values 设置单元格风格
                TFlxFormat fmt;
                fmt = xls.GetCellVisibleFormatDef(1, 1);
                fmt.Borders.Left.Style = TFlxBorderStyle.Thin;
                fmt.Borders.Left.ColorIndex = xls.NearestColorIndex(Color.Black);
                fmt.Borders.Right.Style = TFlxBorderStyle.Thin;
                fmt.Borders.Right.ColorIndex = xls.NearestColorIndex(Color.Black);
                fmt.Borders.Top.Style = TFlxBorderStyle.Thin;
                fmt.Borders.Top.ColorIndex = xls.NearestColorIndex(Color.Black);
                fmt.Borders.Bottom.Style = TFlxBorderStyle.Thin;
                fmt.Borders.Bottom.ColorIndex = xls.NearestColorIndex(Color.Black);
                fmt.HAlignment = THFlxAlignment.center;
                fmt.VAlignment = TVFlxAlignment.center;


                //设置表格值 加载数据
                //字体10号
                fmt.Font.Size20 = 200;
                int k = -1;
                for (int i=0;i<dgv.Columns.Count;i++)
                {
                    k++;
                    object cd = dgv.Columns[i].GetType();
                    if (dgv.Columns[i].Visible == false || dgv.Columns[i].GetType() == typeof(DataGridViewImageColumn))
                    {
                        k--;
                        continue;
                    }
                    xls.SetColWidth(k+1, Convert.ToInt32(0.1188 * dgv.Columns[i].Width*255)); 
                    xls.SetCellFormat(3, k + 1, xls.AddFormat(fmt));
                    xls.SetCellValue(3, k + 1, dgv.Columns[i].HeaderText);
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        xls.SetCellFormat(j + 4, k + 1, xls.AddFormat(fmt));
                        if (dgv.Rows[j].Cells[i].Value.GetType() == typeof(DateTime))
                        {
                            xls.SetCellValue(j + 4, k + 1, Convert.ToDateTime(dgv.Rows[j].Cells[i].Value).ToString("yyyy/MM/dd HH:mm"));
                        }
                        else 
                        {
                            if (dgv.Rows[j].Cells[i].Value.GetType() == typeof(Single))
                            {
                                xls.SetCellValue(j + 4, k + 1, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells[i].Value),2));
                            }
                            else
                            {
                                xls.SetCellValue(j + 4, k + 1, dgv.Rows[j].Cells[i].Value);
                            }
                        }
                        
                    }
                }

                //设置表头
                //字体12号
                fmt.Font.Size20 = 240;
                //Merged Cells 合并单元格
                xls.MergeCells(1, 1, 2, k+1);
                xls.SetCellFormat(1, 1, xls.AddFormat(fmt));
                xls.SetCellValue(1, 1, name);

                //Cell selection and scroll position.默认单元格
                xls.SelectCell(1, 1, true);

                //Protection
                TSheetProtectionOptions SheetProtectionOptions;
                SheetProtectionOptions = new TSheetProtectionOptions(false);
                SheetProtectionOptions.SelectLockedCells = true;
                SheetProtectionOptions.SelectUnlockedCells = true;
                xls.Protection.SetSheetProtection(null, SheetProtectionOptions);

                xls.Save(dialog.FileName);
                try
                {
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("文件已打开无法覆盖！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void saveAs2(DataGridView dgv, string dt)
        {
            if (dgv.RowCount < 1)
            {
                MessageBox.Show("没有可导出的数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = "Excel(*.xls)|*.xls|All Files(*.*)|*.*";
            dialog.FileName = DateTime.Now.Date.ToString("yyyyMMdd") + ".xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                XlsFile xls = new XlsFile(true);
                xls.NewFile(1);    //Create a new Excel file with 1 sheet.
                xls.ActiveSheet = 1;    //Set the sheet we are working in.
                xls.SheetName = "Sheet1"; //Sheet Options 

                //Styles.默认单元格格式
                TFlxFormat StyleFmt;
                StyleFmt = xls.GetStyle("Normal");
                StyleFmt.Font.Name = "宋体";
                StyleFmt.Font.Size20 = 160;
                StyleFmt.Font.CharSet = 134;
                StyleFmt.Borders.Left.Style = TFlxBorderStyle.Thin;
                StyleFmt.Borders.Left.ColorIndex = xls.NearestColorIndex(Color.Black);
                StyleFmt.Borders.Right.Style = TFlxBorderStyle.Thin;
                StyleFmt.Borders.Right.ColorIndex = xls.NearestColorIndex(Color.Black);
                StyleFmt.Borders.Top.Style = TFlxBorderStyle.Thin;
                StyleFmt.Borders.Top.ColorIndex = xls.NearestColorIndex(Color.Black);
                StyleFmt.Borders.Bottom.Style = TFlxBorderStyle.Thin;
                StyleFmt.Borders.Bottom.ColorIndex = xls.NearestColorIndex(Color.Black);
                StyleFmt.HAlignment = THFlxAlignment.center;
                StyleFmt.VAlignment = TVFlxAlignment.center;
                xls.SetStyle("Normal", StyleFmt);

                //Printer Settings 默认打印设置
                xls.SetPrintMargins(new TXlsMargins(0.7, 0.75, 0.7, 0.75, 0.3, 0.3));
                xls.PrintXResolution = 600;
                xls.PrintYResolution = 600;
                xls.PrintOptions = TPrintOptions.None;
                xls.PrintPaperSize = TPaperSize.A4;
                xls.PrintHCentered=true;
                

                //Set up rows and columns 默认单元格大小
                //11.88为100像素 
                xls.DefaultColWidth = 2400;
                xls.DefaultRowHeight = 160;

                //设置表格值 加载数据
                StyleFmt.Font.Size20 = 160;

                //分组
                xls.SetColWidth(3, 1500);
                xls.MergeCells(3, 1, 4, 1);
                xls.SetCellValue(3, 1, "分组");
                //站点名称
                xls.SetColWidth(2, 3200);
                xls.MergeCells(3, 2, 4,2);
                xls.SetCellValue(3,2, "站点名称");
                //时间
                xls.SetColWidth(3, 4700);
                xls.MergeCells(3, 3, 4, 3);
                xls.SetCellValue(3, 3, "时间");
                //供水压力
                xls.SetCellValue(4, 4, "供水压力");
                //回水压力
                xls.SetCellValue(4, 5, "回水压力");
                //供水温度
                xls.SetCellValue(4, 6, "供水温度");
                //回水温度
                xls.SetCellValue(4, 7, "回水温度");
                //瞬时流量
                xls.SetCellValue(4, 8, "瞬时流量");
                //累计流量
                xls.SetCellValue(4, 9, "累计流量");
                //一次参数
                xls.MergeCells(3, 4, 3, 9);
                xls.SetCellValue(3, 4, "一次参数");

                //供水压力
                xls.SetCellValue(4, 10, "供水压力");
                //回水压力
                xls.SetCellValue(4, 11, "回水压力");
                //供水温度
                xls.SetCellValue(4, 12, "供水温度");
                //回水温度
                xls.SetCellValue(4, 13, "回水温度");
                //供水温度基准
                xls.SetCellValue(4, 14, "供温基准");
                //压差设定
                xls.SetCellValue(4, 15, "供压基准");
                //二次参数
                xls.MergeCells(3, 10, 3, 15);
                xls.SetCellValue(3, 10, "二次参数");

                //室外温度
                xls.MergeCells(3, 16, 4, 16);
                xls.SetCellValue(3, 16, "室外温度");
                //调节阀开度
                xls.MergeCells(3, 17, 4, 17);
                xls.SetCellValue(3, 17, "调节阀开度");
                //水箱水位
                xls.MergeCells(3, 18, 4, 18);
                xls.SetCellValue(3, 18, "水箱水位");

                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                  //  xls.SetCellFormat(j + 5, 1, xls.AddFormat(fmt));
                    xls.SetCellValue(j + 5, 1, dgv.Rows[j].Cells["GroupName"].Value);
                    xls.SetCellValue(j + 5, 2, dgv.Rows[j].Cells["StationName"].Value);
                    xls.SetCellValue(j + 5, 3, Convert.ToDateTime(dgv.Rows[j].Cells["DT"].Value).ToString("yyyy/MM/dd HH:mm"));
                    xls.SetCellValue(j + 5, 4, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["GP1"].Value), 2));
                    xls.SetCellValue(j + 5, 5, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["BP1"].Value), 2));
                    xls.SetCellValue(j + 5, 6, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["GT1"].Value), 2));
                    xls.SetCellValue(j + 5, 7, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["BT1"].Value), 2));
                    xls.SetCellValue(j + 5, 8, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["WI1"].Value), 2));
                    xls.SetCellValue(j + 5, 9, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["WS1"].Value), 2));

                    xls.SetCellValue(j + 5, 10, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["GP2"].Value), 2));
                    xls.SetCellValue(j + 5, 11, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["BP2"].Value), 2));
                    xls.SetCellValue(j + 5, 12, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["GT2"].Value), 2));
                    xls.SetCellValue(j + 5, 13, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["BT2"].Value), 2));
                    xls.SetCellValue(j + 5, 14, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["GTB2"].Value), 2));
                    xls.SetCellValue(j + 5, 15, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["BPB2"].Value), 2));

                    xls.SetCellValue(j + 5, 16, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["OT"].Value), 2));
                    xls.SetCellValue(j + 5, 17, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["OD"].Value), 2));
                    xls.SetCellValue(j + 5, 18, Math.Round(Convert.ToSingle(dgv.Rows[j].Cells["WL"].Value), 2));

                }

                //Merged Cells 合并单元格
                xls.MergeCells(1, 1,2,18);
                xls.SetCellValue(1, 1, "供热报表"+dt);

                //Cell selection and scroll position.默认单元格
                xls.SelectCell(1, 1, true);

                //Protection
                TSheetProtectionOptions SheetProtectionOptions;
                SheetProtectionOptions = new TSheetProtectionOptions(false);
                SheetProtectionOptions.SelectLockedCells = true;
                SheetProtectionOptions.SelectUnlockedCells = true;
                xls.Protection.SetSheetProtection(null, SheetProtectionOptions);

                xls.Save(dialog.FileName);
                try
                {
                    System.Diagnostics.Process.Start(dialog.FileName);
                }
                catch
                {
                    MessageBox.Show("文件已打开无法覆盖！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }


}
