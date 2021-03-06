﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace SocketServer
{
    public partial class curve : Form
    {
        public curve()
        {
            InitializeComponent();
        }

        private void line_data_Load(object sender, EventArgs e)
        {
            from_ini();
        }

        private void from_ini()
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(-1);
            dateTimePicker4.Value = dateTimePicker3.Value.AddDays(-1);

            string sql = "select DeviceID,StationName from vDeviceGR where [Deleted]=0 order by [DeviceID]";
            DataTable dt = Tool.DB.getDt(sql);

            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "StationName";
            comboBox3.ValueMember = "DeviceID";
            comboBox3.SelectedIndex = 0;

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "StationName";
            comboBox1.ValueMember = "DeviceID";
            comboBox1.SelectedIndex = 0;

            panel7.BackColor=Color.Red;
            panel9.BackColor=ColorTranslator.FromHtml("0xffff80ff");
            panel11.BackColor=Color.Blue;
            panel13.BackColor = ColorTranslator.FromHtml("0xff80ffff");
            panel15.BackColor = ColorTranslator.FromHtml("0xffff8000");
            panel17.BackColor = ColorTranslator.FromHtml("0xff8000ff");

            panel3.BackColor = Color.Red;
            panel20.BackColor = ColorTranslator.FromHtml("0xffff80ff");
            panel24.BackColor = Color.Blue;
            panel26.BackColor = ColorTranslator.FromHtml("0xff80ffff");
            panel22.BackColor = ColorTranslator.FromHtml("0xffff8000");
            panel18.BackColor = ColorTranslator.FromHtml("0xff8000ff");
            panel29.BackColor = Color.Lime;
            panel37.BackColor = Color.Yellow;


        }
        
        //显示点
        private string MyPointValueHandler(ZedGraphControl control, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            return curve.Label.Text.Substring(0, 4) + ": " + pt.Y.ToString() + " " + curve.Label.Text.Substring(4, curve.Label.Text.Length-4) + " " + XDate.XLDateToDateTime(pt.X).ToString();
        }
  
        //压力曲线
        #region
        private void button9_Click(object sender, EventArgs e)
        {
            drawpressline((string)comboBox3.SelectedText, (int)comboBox3.SelectedValue);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            zedGraphControl2.DoPrint();
        }

        private void drawpressline(string name,int ID)
        {
            string sql = "select dt,GP1,BP1 ,GP2,BP2,PA2,BPB2 from tblGRData where DeviceID =" + ID + " and dt>='" + this.dateTimePicker2.Value.ToString() + "' and dt<'" + dateTimePicker1.Value.ToString() + "' order by dt ";
            DataTable dt = Tool.DB.getDt(sql);

            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                DateTime time = (DateTime)dt.Rows[j][0];
                double x = new XDate(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
                double y = Convert.ToDouble(dt.Rows[j][1]);
                list1.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][2]);
                list2.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][3]);
                list3.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][4]);
                list4.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][5]);
                list5.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][6]);
                list6.Add(x, y);
            }

            GraphPane myPane = zedGraphControl2.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl2.ZoomOutAll(myPane);
            myPane.Title.Text = name + " " + dateTimePicker2.Value.ToString() + " 至 " + dateTimePicker1.Value.ToString() + " 压力曲线";
            myPane.XAxis.Title.Text = "时间(h)";
            myPane.YAxis.Title.Text = "压力(MPa)";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.Scale.Max = 1;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.MajorStep = 0.1;
            myPane.XAxis.Scale.Format = "MM/dd HH:mm";

            LineItem myCurve1=null;
            if (checkBox3.Checked == true)
            {
                myCurve1 = myPane.AddCurve("一次供压MPa", list1, panel7.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox4.Checked == true)
            {
                myCurve1 = myPane.AddCurve("一次回压MPa", list2, panel9.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox5.Checked == true)
            {
                myCurve1 = myPane.AddCurve("二供次压MPa", list3, panel11.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox6.Checked == true)
            {
                myCurve1 = myPane.AddCurve("二次回压MPa", list4, panel13.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox7.Checked == true)
            {
                myCurve1 = myPane.AddCurve("压差设定MPa", list5, panel15.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox8.Checked == true)
            {
                myCurve1 = myPane.AddCurve("补水设定MPa", list6, panel17.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (myCurve1 == null)
            {
                MessageBox.Show("请选择某条曲线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            zedGraphControl2.IsShowPointValues = true;
            zedGraphControl2.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        #endregion


        //温度曲线
        #region
        private void button1_Click(object sender, EventArgs e)
        {
            drawtempline((string)comboBox1.SelectedText, (int)comboBox1.SelectedValue);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            zedGraphControl2.DoPrint();
        }

        private void drawtempline(string name, int ID)
        {
            string sql = "select dt,GT1,BT1,GT2,BT2,GTB2,OT,WI1,OD from tblGRData where DeviceID =" + ID + " and dt>='" + this.dateTimePicker4.Value.ToString() + "' and dt<'" + dateTimePicker3.Value.ToString() + "' order by dt ";
            DataTable dt = Tool.DB.getDt(sql);

            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();
            PointPairList list7 = new PointPairList();
            PointPairList list8 = new PointPairList();

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                DateTime time = (DateTime)dt.Rows[j][0];
                double x = new XDate(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
                double y = Convert.ToDouble(dt.Rows[j][1]);
                list1.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][2]);
                list2.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][3]);
                list3.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][4]);
                list4.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][5]);
                list5.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][6]);
                list6.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][7]);
                list7.Add(x, y);
                y = Convert.ToDouble(dt.Rows[j][8]);
                list8.Add(x, y);

            }

            GraphPane myPane = zedGraphControl3.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl3.ZoomOutAll(myPane);
            myPane.Title.Text = name + " " + dateTimePicker4.Value.ToString() + " 至 " + dateTimePicker3.Value.ToString() + " 温度曲线";
            myPane.XAxis.Title.Text = "时间(h)";
            myPane.YAxis.Title.Text = "温度(℃)";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.Scale.Format = "MM/dd HH:mm";

            LineItem myCurve1 = null;
            if (checkBox2.Checked == true)
            {
                myCurve1 = myPane.AddCurve("一次供温℃", list1, panel3.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox10.Checked == true)
            {
                myCurve1 = myPane.AddCurve("一次回温℃", list2, panel20.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox12.Checked == true)
            {
                myCurve1 = myPane.AddCurve("二次供温℃", list3, panel24.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox11.Checked == true)
            {
                myCurve1 = myPane.AddCurve("二次回温℃", list4, panel26.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox9.Checked == true)
            {
                myCurve1 = myPane.AddCurve("供温基准℃", list5, panel22.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox1.Checked == true)
            {
                myCurve1 = myPane.AddCurve("室外温度℃", list6, panel18.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox14.Checked == true)
            {
                myCurve1 = myPane.AddCurve("一次流量m3/h", list7, panel29.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (checkBox18.Checked == true)
            {
                myCurve1 = myPane.AddCurve("阀位反馈%", list8, panel37.BackColor, SymbolType.None);
                myCurve1.Symbol.Size = 2.5f;
                myCurve1.Line.Width = 2.0F;
                myCurve1.Line.IsAntiAlias = true; //抗锯齿
            }
            if (myCurve1 == null)
            {
                MessageBox.Show("请选择某条曲线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            zedGraphControl3.IsShowPointValues = true;
            zedGraphControl3.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }
        #endregion

        //流量曲线
        //#region
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    drawfluxline((string)comboBox2.SelectedText, (int)comboBox2.SelectedValue);
        //}
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    zedGraphControl2.DoPrint();
        //}

        //private void drawfluxline(string name, int ID)
        //{
        //    string sql = "select dt,WS1,OD from tblGRData where DeviceID =" + ID + " and dt>='" + this.dateTimePicker6.Value.ToString() + "' and dt<'" + dateTimePicker5.Value.ToString() + "' order by dt ";
        //    DataTable dt = Tool.DB.getDt(sql);

        //    PointPairList list1 = new PointPairList();
        //    PointPairList list2 = new PointPairList();

        //    for (int j = 0; j < dt.Rows.Count; j++)
        //    {
        //        DateTime time = (DateTime)dt.Rows[j][0];
        //        double x = new XDate(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
        //        double y = Convert.ToDouble(dt.Rows[j][1]);
        //        list1.Add(x, y);
        //        y = Convert.ToDouble(dt.Rows[j][2]);
        //        list2.Add(x, y);
        //    }

        //    GraphPane myPane = zedGraphControl1.GraphPane;
        //    myPane.CurveList.Clear();
        //    this.zedGraphControl1.ZoomOutAll(myPane);
        //    myPane.Title.Text = name + " " + dateTimePicker4.Value.ToString() + " 至 " + dateTimePicker3.Value.ToString() + " 流量曲线";
        //    myPane.XAxis.Title.Text = "时间(h)";
        //    myPane.YAxis.Title.Text = "流量(℃)";
        //    myPane.XAxis.Type = AxisType.Date;
        //    myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
        //    myPane.YAxis.MajorGrid.IsVisible = true;
        //    myPane.XAxis.Scale.Format = "MM/dd HH:mm";

        //    LineItem myCurve1 = null;
        //    if (checkBox14.Checked == true)
        //    {
        //        myCurve1 = myPane.AddCurve("一次流量m3/h", list1, panel29.BackColor, SymbolType.None);
        //        myCurve1.Symbol.Size = 2.5f;
        //        myCurve1.Line.Width = 2.0F;
        //        myCurve1.Line.IsAntiAlias = true; //抗锯齿
        //    }
        //    if (checkBox18.Checked == true)
        //    {
        //        myCurve1 = myPane.AddCurve("阀位反馈%", list2, panel37.BackColor, SymbolType.None);
        //        myCurve1.Symbol.Size = 2.5f;
        //        myCurve1.Line.Width = 2.0F;
        //        myCurve1.Line.IsAntiAlias = true; //抗锯齿
        //    }

        //    if (myCurve1 == null)
        //    {
        //        MessageBox.Show("请选择某条曲线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        //        return;
        //    }

        //    zedGraphControl1.IsShowPointValues = true;
        //    zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);

        //    zedGraphControl1.AxisChange();
        //    zedGraphControl1.Invalidate();
        //}
        //#endregion

        private void panel7_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Panel pl = sender as Panel;
            pl.BackColor = colorDialog1.Color;
        }


    }
}
