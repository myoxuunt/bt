using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace xg
{
    public partial class xg_main : Form
    {
        public xg_main()
        {
            InitializeComponent();
        }

        private int lessspace;
        private DataTable dttemp;
        private DataTable dthis;

        private void xg_main_Load(object sender, EventArgs e)
        {
            load_xml();
            //实时数据相关
            loadreal();
            //站点历史
            loadhis();
        }
        //加载配置
        private void load_xml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            lessspace = Convert.ToInt32(xDoc.DocumentElement.ChildNodes[6].Attributes.GetNamedItem("value").Value.Trim());
            numericUpDown2.Value = lessspace;
        }

        //dgv隔行颜色
        private void DGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (i % 2 == 1)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
        //更新巡更站点缓存表
        private DataTable Reflashtemp(DateTime date1, DateTime date2, string condition)
        {
            string sql = "SELECT [DT] as [时间],[DeviceID],[StationName] as [站点名称],[Person] as [巡更人员] FROM vXGData  WHERE [DT]>='" + date1 + "' and [DT]<'" + date2 + "' " + condition + "  order by [DT]";
            return  Tool.DB.getDt(sql);
        }
        //翻页更新时间
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Value = DateTime.Now.Date.AddDays(-1).AddHours(8);
            dateTimePicker4.Value = DateTime.Now.Date.AddHours(8);
        }
        //获取某个站点的有效列表
        private DataTable Getcount(int DeviceID, DataTable dt, int space,string name)
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("站点名称");
            dt2.Columns.Add("时间");
            dt2.Columns.Add("巡更人员");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DeviceID"].ToString()) == DeviceID)
                {
                    dt2.Rows.Add();
                    dt2.Rows[dt2.Rows.Count - 1]["站点名称"] = name;
                    dt2.Rows[dt2.Rows.Count - 1]["时间"] = dt.Rows[i]["时间"];
                    dt2.Rows[dt2.Rows.Count - 1]["巡更人员"] = dt.Rows[i]["巡更人员"];
                }
            }

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("站点名称");
            dt3.Columns.Add("时间");
            dt3.Columns.Add("巡更人员");

            if (dt2.Rows.Count == 0)
            {
                return dt3;
            }
            DateTime old = Convert.ToDateTime(dt2.Rows[0]["时间"]);
            dt3.Rows.Add();
            dt3.Rows[0]["站点名称"] = dt2.Rows[0]["站点名称"];
            dt3.Rows[0]["时间"] = dt2.Rows[0]["时间"];
            dt3.Rows[0]["巡更人员"] = dt2.Rows[0]["巡更人员"];
            for (int k = 1; k < dt2.Rows.Count; k++)
            {
                if ((Convert.ToDateTime(dt2.Rows[k]["时间"]) - old).TotalMinutes > space)
                {
                    old = Convert.ToDateTime(dt2.Rows[k]["时间"]);
                    dt3.Rows.Add();
                    dt3.Rows[dt3.Rows.Count - 1]["站点名称"] = dt2.Rows[k]["站点名称"];
                    dt3.Rows[dt3.Rows.Count-1]["时间"] = dt2.Rows[k]["时间"];
                    dt3.Rows[dt3.Rows.Count-1]["巡更人员"] = dt2.Rows[k]["巡更人员"];
                }
            }
            return dt3;
        }
        //校时
        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.CurrentRow == null)
        //    {
        //        return;
        //    }

        //    for (int i = 0; i < Tool.xd300._XD300Buffer.Length; i++)
        //    {
        //        if (Tool.xd300._XD300Buffer[i]._Info._id == Convert.ToInt32(dataGridView1["DeviceID", dataGridView1.CurrentRow.Index].Value))
        //        {
        //            Tool.xd300._XD300Buffer[i]._Command[3]._cmd = Tool.xd300.Set_date(Tool.xd300._XD300Buffer[i]._Info._addr);
        //            Tool.xd300._XD300Buffer[i]._Command[3]._onoff = true;
        //            Tool.xd300._XD300Buffer[i]._Command[4]._cmd = Tool.xd300.Set_time(Tool.xd300._XD300Buffer[i]._Info._addr);
        //            Tool.xd300._XD300Buffer[i]._Command[4]._onoff = true;
        //            MessageBox.Show("成功添加校时任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}
        //采集
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            for (int i = 0; i < Tool.xd300._XD300Buffer.Length; i++)
            {
                if (Tool.xd300._XD300Buffer[i]._Info._id == Convert.ToInt32(dataGridView1["DeviceID", dataGridView1.CurrentRow.Index].Value))
                {
                    Tool.xd300._XD300Buffer[i]._Command[0]._cmd = Tool.xd300.Get_recordcount(Tool.xd300._XD300Buffer[i]._Info._addr);
                    Tool.xd300._XD300Buffer[i]._Command[0]._onoff = true;
                    MessageBox.Show("成功添加即时采集任务！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //保存间隔
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            xDoc.DocumentElement.ChildNodes[6].Attributes.GetNamedItem("value").Value = Convert.ToInt32(numericUpDown2.Value).ToString();
            xDoc.Save("config.xml");
            lessspace = Convert.ToInt32(numericUpDown2.Value);
        }

        #region real
        //加载实时数据列表
        private void loadreal()
        {
            DateTime dt = DateTime.Now;
            if (DateTime.Now.Hour >= 8)
            {
                dt = DateTime.Now.Date.AddHours(8);
            }
            else
            {
                dt = DateTime.Now.Date.AddDays(-1).AddHours(8);
            }
            dttemp = Reflashtemp(dt, DateTime.Now," ");
            loadreallist(dataGridView1);
            timer1.Interval = 60000;
            timer1.Enabled = true;
        }
        //加载实时站点数据列表
        private void loadreallist(DataGridView dgv)
        {
            string sql = "select DeviceID,GroupName,StationName from vDevice where [DeviceType]='xd300' and [Deleted]=0";
            DataTable dt = Tool.DB.getDt(sql);
            sql = "SELECT [DeviceID],[GroupName],[StationName],[DT], [Person] FROM [vXGDataLast] ";
            DataTable dt2 = Tool.DB.getDt(sql);

            dt2.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i]["DeviceID"] = dt.Rows[i]["DeviceID"];
                dt2.Rows[i]["GroupName"] = dt.Rows[i]["GroupName"];
                dt2.Rows[i]["StationName"] = dt.Rows[i]["StationName"];
            }

            dt2.Columns.Add("count", typeof(string));

            dgv.DataSource = dt2;
            dgv.Columns["DeviceID"].Visible = false;

            string[] dgv_columns = { "DeviceID","GroupName" , "StationName","DT", "Person", "count" };
            string[] dgv_showname = { "设备标识", "分组名称","站点名称", "时间", "巡更人员", "当日巡更次数" };
            //    int[] dgv_columnswide = {10,100,150,170,100};
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dgv.Columns[dgv_columns[i]].HeaderText = dgv_showname[i];
                //       dataGridView1.Columns[dgv_columns[i]].Width = dgv_columnswide[i];
            }
            reflashreal();
        }
        //定时更新数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            reflashreal();
        }
        //刷新按钮
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            reflashreal();
        }

        //刷新数据
        private void reflashreal()
        {
            DateTime date = DateTime.Now;
            if (DateTime.Now.Hour >= 8)
            {
                date = DateTime.Now.Date.AddHours(8);
            }
            else
            {
                date = DateTime.Now.Date.AddDays(-1).AddHours(8);
            }
            dttemp = Reflashtemp(date, DateTime.Now, " ");
            for (int i = 0; i < Tool.xd300._XD300Buffer.Length; i++)
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (Tool.xd300._XD300Buffer[i]._Info._id == Convert.ToInt32(dt.Rows[j]["DeviceID"]))
                    {
                        DataTable dt2 = Getcount(Tool.xd300._XD300Buffer[i]._Info._id, dttemp, lessspace, Tool.xd300._XD300Buffer[i]._Info._name);
                        if (Tool.xd300._XD300Buffer[i]._Data._dt == null)
                        {
                            continue;
                        }
                        dt.Rows[j]["DT"] = Tool.xd300._XD300Buffer[i]._Data._dt;
                        dt.Rows[j]["Person"] = Tool.xd300._XD300Buffer[i]._Data._person;
                        dt.Rows[j]["count"] = dt2.Rows.Count;
                    }
                }
            }
        }
        //显示详细内容
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            DataTable dt = Getcount(Convert.ToInt32(dataGridView1.CurrentRow.Cells["DeviceID"].Value), dttemp, lessspace, dataGridView1.CurrentRow.Cells["StationName"].Value.ToString());
            dataGridView4.DataSource = dt;
        }

        //导出
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView1, "巡更实时数据");
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView4, "巡更实时数据");
        }
        

        #endregion

        #region his
        //历史查询
        private void loadhis()
        {
            //加载分组信息
            string sql = "select GroupName, GroupID from tblGroup where [Deleted]=0 order by GroupID";
            DataTable dt3 = Tool.DB.getDt(sql);
            DataTable dt4 = new DataTable();
            dt4 = dt3.Clone();
            dt4.Rows.Add();
            dt4.Rows[0]["GroupID"] = -1;
            dt4.Rows[0]["GroupName"] = "全部";
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                dt4.Rows.Add(dt3.Rows[i].ItemArray);
            }
            comboBox2.DataSource = dt4;
            comboBox2.DisplayMember = "GroupName";
            comboBox2.ValueMember = "GroupID";
            comboBox2.SelectedIndex = 0;

            //加载站点列表
            sql = "select StationID,StationName from vDeviceGR  where [Deleted]=0 order by [StationID]";
            DataTable dt1 = Tool.DB.getDt(sql);
            DataTable dt2 = new DataTable();
            dt2 = dt1.Clone();
            dt2.Rows.Add();
            dt2.Rows[0]["StationID"] = -1;
            dt2.Rows[0]["StationName"] = "全部";
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dt2.Rows.Add(dt1.Rows[i].ItemArray);
            }
            comboBox4.DataSource = dt2;
            comboBox4.DisplayMember = "StationName";
            comboBox4.ValueMember = "StationID";
            comboBox4.SelectedIndex = 0;

            //加载人员列表
            sql = "SELECT [CardID],[Person] FROM [vCard]";
            DataTable dt5 = Tool.DB.getDt(sql);
            DataTable dt6 = new DataTable();
            dt6 = dt5.Clone();
            dt6.Rows.Add();
            dt6.Rows[0]["CardID"] = -1;
            dt6.Rows[0]["Person"] = "全部";
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                dt6.Rows.Add(dt5.Rows[i].ItemArray);
            }
            comboBox1.DataSource = dt6;
            comboBox1.DisplayMember = "Person";
            comboBox1.ValueMember = "CardID";
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string condition1 = "";
            string condition2 = "";
            if ((int)comboBox2.SelectedValue>0)
            {
                condition1 +=" and [GroupID]="+comboBox2.SelectedValue;
                condition2 += " and [GroupID]=" + comboBox2.SelectedValue;
            }
            if ((int)comboBox4.SelectedValue>0)
            {
                condition1 += " and [StationID]=" + comboBox4.SelectedValue;
                condition2 += " and [StationID]=" + comboBox4.SelectedValue;
            }
            if ((int)comboBox1.SelectedValue>0)
            {
                condition1 += " and [Person]='" + comboBox1.Text + "'";
            }

            dthis = Reflashtemp(dateTimePicker3.Value, dateTimePicker4.Value, condition1);
            loadhislist(dataGridView3, condition2);
            if (checkBox2.Checked == true)
            {
                DataTable dt = dataGridView3.DataSource as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["count"]) >= numericUpDown1.Value)
                    {                      
                        for (int j = 0; j < dthis.Rows.Count; j++)
                        {
                            if (dthis.Rows[j]["DeviceID"].ToString() == dt.Rows[i]["DeviceID"].ToString())
                            {
                                dthis.Rows.RemoveAt(j);
                                j--;
                            }
                        }
                        dt.Rows.RemoveAt(i);
                        i--;
                    }
                }

            }
        }
        private void loadhislist(DataGridView dgv, string condition)
        {
            string sql = "select DeviceID,GroupName,StationName from vDevice where [DeviceType]='xd300' and [Deleted]=0 " + condition;
           
            DataTable dt = Tool.DB.getDt(sql);

            dt.Columns.Add("count", typeof(string));

            dgv.DataSource = dt;
            dgv.Columns["DeviceID"].Visible = false;

            string[] dgv_columns = { "DeviceID", "GroupName", "StationName", "count" };
            string[] dgv_showname = { "设备标识","分组名称", "站点名称", "巡更次数" };
            //    int[] dgv_columnswide = {10,100,150,170,100};
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dgv.Columns[dgv_columns[i]].HeaderText = dgv_showname[i];
                //       dataGridView1.Columns[dgv_columns[i]].Width = dgv_columnswide[i];
            }

            for (int i = 0; i < Tool.xd300._XD300Buffer.Length; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (Tool.xd300._XD300Buffer[i]._Info._id == Convert.ToInt32(dt.Rows[j]["DeviceID"]))
                    {
                        DataTable dt2 = Getcount(Tool.xd300._XD300Buffer[i]._Info._id, dthis, lessspace, Tool.xd300._XD300Buffer[i]._Info._name);
                        dt.Rows[j]["count"] = dt2.Rows.Count;
                    }
                }
            }
        }
        //private void loadprelist(DateTime date1, DateTime date2, string name, DataGridView dgv)
        //{
        //    DataTable dt = Tool.DB.getDt("select DISTINCT([DeviceID]) FROM tblXGData  WHERE [Person] ='" + name + "'and [DT]>='" + date1 + "' and [DT]<'" + date2 + "'");
        //    //  dt.Columns.Add("分组名称");
        //    dt.Columns.Add("站点名称");
        //    dt.Columns.Add("打卡次数");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < Tool.xd300._XD300Buffer.Length; j++)
        //        {
        //            string cc = dt.Rows[i]["DeviceID"].ToString();
        //            if (dt.Rows[i]["DeviceID"].ToString() == Tool.xd300._XD300Buffer[j]._Info._id.ToString())
        //            {
        //                // dt.Rows[i]["分组名称"] = Tool.xd300._XD300Buffer[i];
        //                dt.Rows[i]["站点名称"] = Tool.xd300._XD300Buffer[j]._Info._name;
        //                DataTable dt2 = Getcount(Tool.xd300._XD300Buffer[j]._Info._id, dtpre, lessspace, Tool.xd300._XD300Buffer[j]._Info._name);
        //                dt.Rows[i]["打卡次数"] = dt2.Rows.Count;
        //            }
        //        }
        //    }
        //    dgv.DataSource = dt;
        //    dgv.Columns["DeviceID"].Visible = false;

        //}

        //导出左表
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView3, "巡更历史数据  " + dateTimePicker3.Value + "-" + dateTimePicker4.Value);
        }
        //导出右表
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }
            Tool.Export.saveAs(dataGridView2, dataGridView2.CurrentRow.Cells["站点名称"]+ " 巡更历史数据  " + dateTimePicker3.Value + "-" + dateTimePicker4.Value);
        }
        //显示详细内容
        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                return;
            }
            DataTable dt = Getcount(Convert.ToInt32(dataGridView3.CurrentRow.Cells["DeviceID"].Value), dthis, lessspace, dataGridView3.CurrentRow.Cells["StationName"].Value.ToString());
            dataGridView2.DataSource = dt;
        }

        //显示全部
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            DataTable dt = dthis.Clone();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string name = dataGridView3.Rows[i].Cells["StationName"].Value.ToString();
                DataTable dt1 = Getcount(Convert.ToInt32(dataGridView3.Rows[i].Cells["DeviceID"].Value), dthis, Convert.ToInt32(numericUpDown2.Value), name);
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    dt.Rows.Add();
                    dt.Rows[dt.Rows.Count - 1]["站点名称"] = name;
                    dt.Rows[dt.Rows.Count - 1]["时间"] = dt1.Rows[j]["时间"];
                    dt.Rows[dt.Rows.Count - 1]["巡更人员"] = dt1.Rows[j]["巡更人员"];
                }
            }
            dataGridView2.DataSource = dt;
            dataGridView2.Columns["DeviceID"].Visible = false;
        }
        #endregion



        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            dataGridView1.RowHeadersWidth - 4,
            e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
            dataGridView1.RowHeadersDefaultCellStyle.Font,
            rectangle,
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }



    }
}
