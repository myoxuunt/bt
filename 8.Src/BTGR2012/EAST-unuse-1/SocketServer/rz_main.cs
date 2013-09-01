using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace rz
{
    public partial class rz_main : Form
    {
        public rz_main()
        {
            InitializeComponent();
        }

        private void rz_main_Load(object sender, EventArgs e)
        {
            //实时数据相关 
            real_load("where [Deleted]=0 ");
            //历史数据相关
            dateTimePicker1.Value = dateTimePicker2.Value.AddDays(-1);
            load_field();
            //报警数据相关
            dateTimePicker5.Value = dateTimePicker6.Value.AddDays(-1);
            load_field_alarm();

            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        #region real
        //加设备列表
        private void real_load(string condition)
        {
            string sql = "select DeviceID,GroupName,StationName,HeatArea from vDeviceGR " + condition + "  order by [GroupID],[DeviceID] ";            
            DataTable dt = Tool.DB.getDt(sql);

            string[] dgv_columns = {"DeviceID","alarm","GroupName","StationName","HeatArea", "DT","avg", 
                                       "GT1", "BT1", "GT2","BT2", "OT","OD","GTB2", 
                                       "GP1", "BP1",  "GP2", "BP2", "pcha", "PA2","BPB2",
                                       "WI1", "WS1", 
                                       //"HS1", "HI1",
                                       //"WI2", "WS2", "HS2", "HI2",
                                       //"WI3", "WS3",  
                                       "WL", "CM1", "CM2", "CM3", "RM1", "RM2"};
            string[] dgv_showname = {"站点标识","报警"," 分组","站点名称","供热面积","时间","单位流量",
                                        "一次供温","一次回温","二次供温","二次回温","室外温度","调节阀反馈","二次供温基准",
                                        "一次供压","一次回压","二次供压","二次回压","二次实际压差","二次压差设定","二次回压设定",
                                        "一次瞬时流量","一次累积流量",
                                        //"一次瞬时热量","一次累积热量",
                                        //"二次瞬时流量","二次累积流量","二次瞬时热量","二次累积热量",
                                        //"补水瞬时流量","补水累积流量",
                                        "水箱水位","循环泵1状态","循环泵2状态","循环泵3状态","补水泵1状态","补水泵2状态"};

            int[] dgv_columnswide = {40,40,60,110,70,135,70,
                                        70,70,70,70,70,80,90,
                                        70,70,70,70,90, 90,90,
                                    90,100,
                                    //包头
                                  //80,100,
                                  //80,100,80,100,
                                  //  80,100,
                                   70,80,80,80,80,80};
            Type[] dgv_type = { typeof(Int32), typeof(Image), typeof(String), typeof(String), typeof(Single), typeof(DateTime), typeof(Single),
                             typeof(Single),typeof(Single),typeof(Single),typeof(Single),typeof(Single),typeof(Int32),typeof(Single), 
                              typeof(Single),typeof(Single),typeof(Single),typeof(Single),typeof(Single),typeof(Single),typeof(Single),
                              typeof(Single),typeof(UInt32),
                              typeof(Single), typeof(String), typeof(String), typeof(String), typeof(String), typeof(String)};
            DataTable dt2 = new DataTable();
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dt2.Columns.Add(dgv_columns[i],dgv_type[i]);
            }
            dt2.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i]["DeviceID"] = dt.Rows[i]["DeviceID"];
                dt2.Rows[i]["GroupName"] = dt.Rows[i]["GroupName"];
                dt2.Rows[i]["StationName"] = dt.Rows[i]["StationName"];
                dt2.Rows[i]["HeatArea"] = dt.Rows[i]["HeatArea"];
            }          
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt2;
            dataGridView1.Columns["DeviceID"].Visible=false;
            dataGridView1.Columns["DT"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm";

            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dataGridView1.Columns[dgv_columns[i]].HeaderText = dgv_showname[i];
                dataGridView1.Columns[dgv_columns[i]].Width = dgv_columnswide[i];
            }

            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["alarm"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imageColumn.DefaultCellStyle.NullValue = null;

            //加载分组信息
            if (toolStripComboBox1.Items.Count == 0)
            {
                sql = "select GroupName from tblGroup where [Deleted]=0 order by GroupID";
                DataTable dt3 = Tool.DB.getDt(sql);
                toolStripComboBox1.Items.Clear();
                toolStripComboBox1.Items.Add("全部");
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    toolStripComboBox1.Items.Add(dt3.Rows[i]["GroupName"].ToString());
                }
                toolStripComboBox1.SelectedText = "全部";
            }
            

            //报警
            foreach (Control cs in groupBox10.Controls)
            {
                if (cs is System.Windows.Forms.CheckBox)
                {
                    ((CheckBox)cs).AutoCheck=false;
                }
            }
            //for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            //{
            //    Tool.xd100x._XD100xBuffer[i]._Command[0]._back = true;
            //}
            reflashdata();
            ShowDatas();
        }
        //分组显示
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condition = "";
            if (toolStripComboBox1.Text == "全部")
            {
                condition = "where [Deleted]=0 ";
            }
            else
            {
                condition = " where GroupName='" + toolStripComboBox1.Text  + "' and [Deleted]=0 ";
            }
            real_load(condition);
        }
        //更新数据
        private void reflashdata()
        {
            int DeviceID = -1;
            if (dataGridView1.CurrentCell == null)
            {
            }
            else
            {
                DeviceID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DeviceID"].Value);
            }
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                DataTable dt = dataGridView1.DataSource as DataTable;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (Tool.xd100x._XD100xBuffer[i]._Info._id == Convert.ToInt32(dt.Rows[j]["DeviceID"]))
                    {
                        //if (Tool.xd100x._XD100xBuffer[i]._Command[0]._back == false)
                        //{
                        //    continue;
                        //}
                        if (Tool.xd100x._XD100xBuffer[i]._Data._dt.ToString() == dt.Rows[j]["DT"].ToString())
                        {
                            continue;
                        }
                     //   Tool.xd100x._XD100xBuffer[i]._Command[0]._back = false;
                        if (Tool.xd100x._XD100xBuffer[i]._Info._HeatArea == 0)
                        {
                            dt.Rows[j]["avg"] = "0";
                        }
                        else
                        {
                            dt.Rows[j]["avg"] = (Tool.xd100x._XD100xBuffer[i]._Data._WI1 / Tool.xd100x._XD100xBuffer[i]._Info._HeatArea).ToString("0.00");
                        }
                        dt.Rows[j]["pcha"] = Math.Round((Tool.xd100x._XD100xBuffer[i]._Data._GP2 - Tool.xd100x._XD100xBuffer[i]._Data._BP2), 2);
                        dt.Rows[j]["DT"] = Tool.xd100x._XD100xBuffer[i]._Data._dt;
                        dt.Rows[j]["GT1"] = Tool.xd100x._XD100xBuffer[i]._Data._GT1;
                        dt.Rows[j]["BT1"] = Tool.xd100x._XD100xBuffer[i]._Data._BT1;
                        dt.Rows[j]["GT2"] = Tool.xd100x._XD100xBuffer[i]._Data._GT2;
                        dt.Rows[j]["BT2"] = Tool.xd100x._XD100xBuffer[i]._Data._BT2;
                        dt.Rows[j]["OT"] = Tool.xd100x._XD100xBuffer[i]._Data._OT;
                        dt.Rows[j]["GTB2"] = Tool.xd100x._XD100xBuffer[i]._Data._GTB2;
                        dt.Rows[j]["GP1"] = Math.Round(Tool.xd100x._XD100xBuffer[i]._Data._GP1, 2);
                        dt.Rows[j]["BP1"] = Math.Round(Tool.xd100x._XD100xBuffer[i]._Data._BP1, 2);
                        dt.Rows[j]["WL"] = Tool.xd100x._XD100xBuffer[i]._Data._WL;
                        dt.Rows[j]["GP2"] = Math.Round(Tool.xd100x._XD100xBuffer[i]._Data._GP2, 2);
                        dt.Rows[j]["BPB2"] = Tool.xd100x._XD100xBuffer[i]._Data._BPB2;
                        dt.Rows[j]["BP2"] = Math.Round(Tool.xd100x._XD100xBuffer[i]._Data._BP2, 2);
                        dt.Rows[j]["WI1"] = Tool.xd100x._XD100xBuffer[i]._Data._WI1;
                        dt.Rows[j]["WS1"] = Tool.xd100x._XD100xBuffer[i]._Data._WS1;
                        //dt.Rows[j]["WS3"] = Tool.xd100x._XD100xBuffer[i]._Data._WS3;
                        //dt.Rows[j]["WI3"] = Tool.xd100x._XD100xBuffer[i]._Data._WI3;
                        //dt.Rows[j]["HS1"] = Tool.xd100x._XD100xBuffer[i]._Data._HS1;
                        //dt.Rows[j]["HI1"] = Tool.xd100x._XD100xBuffer[i]._Data._HI1;
                        //dt.Rows[j]["WI2"] = Tool.xd100x._XD100xBuffer[i]._Data._WI2;
                        //dt.Rows[j]["WS2"] = Tool.xd100x._XD100xBuffer[i]._Data._WS2;
                        //dt.Rows[j]["HS2"] = Tool.xd100x._XD100xBuffer[i]._Data._HS2;
                        //dt.Rows[j]["HI2"] = Tool.xd100x._XD100xBuffer[i]._Data._HI2;
                        dt.Rows[j]["OD"] = Tool.xd100x._XD100xBuffer[i]._Data._OD;
                        dt.Rows[j]["PA2"] = Tool.xd100x._XD100xBuffer[i]._Data._PA2;
                        dt.Rows[j]["CM1"] = Tool.xd100x._XD100xBuffer[i]._Data._pump._CM1;
                        dt.Rows[j]["CM2"] = Tool.xd100x._XD100xBuffer[i]._Data._pump._CM2;
                        dt.Rows[j]["CM3"] = Tool.xd100x._XD100xBuffer[i]._Data._pump._CM3;
                        dt.Rows[j]["RM1"] = Tool.xd100x._XD100xBuffer[i]._Data._pump._RM1;
                        dt.Rows[j]["RM2"] = Tool.xd100x._XD100xBuffer[i]._Data._pump._RM2;
                        try
                        {
                            if (Tool.xd100x._XD100xBuffer[i]._Data._alarm._word > 0)
                            {
                                dt.Rows[j]["alarm"] = Image.FromFile(Application.StartupPath + "\\报警.png");
                            }
                            if (Tool.xd100x._XD100xBuffer[i]._Data._alarm._word == 0)
                            {
                                dt.Rows[j]["alarm"] = null;
                            }
                        }
                        catch
                        {
                            dt.Rows[j]["alarm"] = null;
                        }
                        if (Tool.xd100x._XD100xBuffer[i]._Info._id == DeviceID)
                        {
                            ShowDatas();
                        }
                    }

                }
            }
        }
        //定时更新数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            reflashdata();
        }
        //刷新详细信息
        private void ShowDatas()
        {
            int dgrow = 0;
            if (dataGridView1.CurrentCell == null)
            {
            }
            else
            {
                dgrow = dataGridView1.CurrentRow.Index;
            }
            int row = 0;

            int DeviceID = Convert.ToInt32(dataGridView1["DeviceID", dgrow].Value);
            DataTable dt = dataGridView1.DataSource as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DeviceID"]) == DeviceID)
                {
                    row = i;
                    break;
                }
            }
            groupBox8.Text = dt.Rows[row]["StationName"].ToString() + " " + dt.Rows[row]["DT"].ToString();
            if (groupBox8.Text == dt.Rows[row]["StationName"].ToString() + " ")
            {
                return;
            }
            textarea.Text = dt.Rows[row]["HeatArea"].ToString();
            textavg.Text = dt.Rows[row]["avg"].ToString();
            txtot.Text = dt.Rows[row]["OT"].ToString();
            txtTwoCha.Text = dt.Rows[row]["pcha"].ToString();
          
            float f1 = Convert.ToSingle(dt.Rows[row]["GT1"].ToString());
            float f2 = Convert.ToSingle(dt.Rows[row]["BT1"].ToString());
            if (f1 <= f2)
            {
                txtOneGT.ForeColor = Color.Red;
                txtOneBT.ForeColor = Color.Red;
                label18.ForeColor = Color.Red;
                label19.ForeColor = Color.Red;
            }
            else
            {
                txtOneGT.ForeColor = Color.Black;
                txtOneBT.ForeColor = Color.Black;
                label18.ForeColor = Color.Black;
                label19.ForeColor = Color.Black;
            }
            txtOneGT.Text = dt.Rows[row]["GT1"].ToString();
            txtOneBT.Text = dt.Rows[row]["BT1"].ToString();

            f1 = Convert.ToSingle(dt.Rows[row]["GT2"].ToString());
            f2 = Convert.ToSingle(dt.Rows[row]["BT2"].ToString());
            if (f1 <= f2)
            {
                txtTwoGT.ForeColor = Color.Red;
                txtTwoBT.ForeColor = Color.Red;
                label20.ForeColor = Color.Red;
                label21.ForeColor = Color.Red;
            }
            else
            {
                txtTwoGT.ForeColor = Color.Black;
                txtTwoBT.ForeColor = Color.Black;
                label20.ForeColor = Color.Black;
                label21.ForeColor = Color.Black;
            }
            txtTwoGT.Text = dt.Rows[row]["GT2"].ToString();
            txtTwoBT.Text = dt.Rows[row]["BT2"].ToString();

            f1 = Convert.ToSingle(dt.Rows[row]["GP1"].ToString());
            f2 = Convert.ToSingle(dt.Rows[row]["BP1"].ToString());
            if (f1 <= f2)
            {
                txtOneGP.ForeColor = Color.Red;
                txtOneBP.ForeColor = Color.Red;
                label44.ForeColor = Color.Red;
                label50.ForeColor = Color.Red;
            }
            else
            {
                txtOneGP.ForeColor = Color.Black;
                txtOneBP.ForeColor = Color.Black;
                label44.ForeColor = Color.Black;
                label50.ForeColor = Color.Black;
            }
            txtOneGP.Text = dt.Rows[row]["GP1"].ToString();
            txtOneBP.Text = dt.Rows[row]["BP1"].ToString();

            f1 = Convert.ToSingle(dt.Rows[row]["GP2"].ToString());
            f2 = Convert.ToSingle(dt.Rows[row]["BP2"].ToString());
            if (f1 <= f2)
            {
                txtTwoGP.ForeColor = Color.Red;
                txtTwoBP.ForeColor = Color.Red;
                label52.ForeColor = Color.Red;
                label47.ForeColor = Color.Red;
            }
            else
            {
                txtTwoGP.ForeColor = Color.Black;
                txtTwoBP.ForeColor = Color.Black;
                label52.ForeColor = Color.Black;
                label47.ForeColor = Color.Black;
            }
            txtTwoGP.Text = dt.Rows[row]["GP2"].ToString();
            txtTwoBP.Text = dt.Rows[row]["BP2"].ToString();

            f1 = Convert.ToSingle(dt.Rows[row]["OD"].ToString());
            if (f1 ==0f)
            {
                txtOpen.ForeColor = Color.Red;
                label16.ForeColor = Color.Red;
            }
            else
            {
                txtOpen.ForeColor = Color.Black;
                label16.ForeColor = Color.Black;
            }
            txtOpen.Text = dt.Rows[row]["OD"].ToString();
            txtWat.Text = dt.Rows[row]["WL"].ToString();
            txtOneFlux.Text = dt.Rows[row]["WI1"].ToString();
            txtOneAddFlux.Text = dt.Rows[row]["WS1"].ToString();
            //txtHeat.Text = dt.Rows[row]["HS1"].ToString();
            //txtAddHeat.Text = dt.Rows[row]["HI1"].ToString();
            //txtSubFlux.Text = dt.Rows[row]["WI3"].ToString();
            //txtSubAddFlux.Text = dt.Rows[row]["WS3"].ToString();
            //txtTwoFlux.Text = dt.Rows[row]["WI2"].ToString();
            //txtTwoAddFlux.Text = dt.Rows[row]["WS2"].ToString();
            //txtHeat1.Text = dt.Rows[row]["HS2"].ToString();
            //txtAddHeat1.Text = dt.Rows[row]["HI2"].ToString();
            txtPump1.Text = dt.Rows[row]["CM1"].ToString();
            txtPump2.Text = dt.Rows[row]["CM2"].ToString();
            txtPump3.Text = dt.Rows[row]["CM3"].ToString();
            if (txtPump1.Text == "停止" && txtPump2.Text == "停止" && txtPump2.Text == "停止")
            {
                txtPump1.ForeColor = Color.Red;
                txtPump2.ForeColor = Color.Red;
                txtPump3.ForeColor = Color.Red;
                label4.ForeColor = Color.Red;
                label5.ForeColor = Color.Red;
                label6.ForeColor = Color.Red;
            }
            else
            {
                txtPump1.ForeColor = Color.Black;
                txtPump2.ForeColor = Color.Black;
                txtPump3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
            }

            txtSubPump1.Text = dt.Rows[row]["RM1"].ToString();
            txtSubPump2.Text = dt.Rows[row]["RM2"].ToString();
            txtTwoGTS.Text = dt.Rows[row]["GTB2"].ToString();
            txtTwoBPS.Text = dt.Rows[row]["BPB2"].ToString();
            txtTwoPCha.Text = dt.Rows[row]["PA2"].ToString();
            //因包头 报警
            displayalarm();
        }
        //导出
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView1, this.tabPage1.Text);
        }
        //打印
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Tool.PrintDGV.Print_DataGridView(dataGridView1, "实时数据");
        }
        //明细
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }
        //明细显示
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowDatas();
        }
       
        //显示报警包头版去除热量流量 将报警设置为长期显示
        private void displayalarm()
        {
            //因包头屏蔽
            //  groupBox10.Visible = true;

            int dgvcr = 0;
            if (dataGridView1.CurrentCell == null)
            {
            }
            else
            {
                dgvcr = dataGridView1.CurrentRow.Index;
            }
            int busfferlistID = -1;
            int DeviceID = Convert.ToInt32(dataGridView1["DeviceID", dgvcr].Value);
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (DeviceID == Tool.xd100x._XD100xBuffer[i]._Info._id)
                {
                    busfferlistID = i;
                    break;
                }
            }
            if (busfferlistID == -1)
            {
                return;
            }

            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox6.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;

            checkBox2.ForeColor = Color.Black;
            checkBox4.ForeColor = Color.Black;
            checkBox5.ForeColor = Color.Black;
            checkBox7.ForeColor = Color.Black;
            checkBox8.ForeColor = Color.Black;
            checkBox9.ForeColor = Color.Black;
            checkBox10.ForeColor = Color.Black;
            checkBox11.ForeColor = Color.Black;
            checkBox12.ForeColor = Color.Black;
            checkBox6.ForeColor = Color.Black;
            checkBox13.ForeColor = Color.Black;
            checkBox14.ForeColor = Color.Black;
            checkBox15.ForeColor = Color.Black;
            checkBox16.ForeColor = Color.Black;

            if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._word > 0)
            {              
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._diaodian == Tool.xd100x.GRAlarm.有)
                {
                    checkBox12.Checked = true;
                    checkBox12.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._yicigongdiya == Tool.xd100x.GRAlarm.有)
                {
                    checkBox2.Checked = true;
                    checkBox2.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._ercigonggaoya == Tool.xd100x.GRAlarm.有)
                {
                    checkBox4.Checked = true;
                    checkBox4.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._ercihuigaoya == Tool.xd100x.GRAlarm.有)
                {
                    checkBox5.Checked = true;
                    checkBox5.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._ercihuidiya == Tool.xd100x.GRAlarm.有)
                {
                    checkBox7.Checked = true;
                    checkBox7.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._yicigongdiwen == Tool.xd100x.GRAlarm.有)
                {
                    checkBox8.Checked = true;
                    checkBox8.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._ercigonggaowen == Tool.xd100x.GRAlarm.有)
                {
                    checkBox9.Checked = true;
                    checkBox9.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._kaiguandi == Tool.xd100x.GRAlarm.有)
                {
                    checkBox10.Checked = true;
                    checkBox10.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._shuiweidi == Tool.xd100x.GRAlarm.有)
                {
                    checkBox10.Checked = true;
                    checkBox10.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._kaiguangao == Tool.xd100x.GRAlarm.有)
                {
                    checkBox11.Checked = true;
                    checkBox11.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._shuiweigao == Tool.xd100x.GRAlarm.有)
                {
                    checkBox11.Checked = true;
                    checkBox11.ForeColor = Color.Red;
                }

                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._xunhuanbeng1 == Tool.xd100x.GRAlarm.有)
                {
                    checkBox6.Checked = true;
                    checkBox6.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._xunhuanbeng2 == Tool.xd100x.GRAlarm.有)
                {
                    checkBox13.Checked = true;
                    checkBox13.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._xunhuanbeng3 == Tool.xd100x.GRAlarm.有)
                {
                    checkBox14.Checked = true;
                    checkBox14.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._bushuibeng1 == Tool.xd100x.GRAlarm.有)
                {
                    checkBox15.Checked = true;
                    checkBox15.ForeColor = Color.Red;
                }
                if (Tool.xd100x._XD100xBuffer[busfferlistID]._Data._alarm._bushuibeng2 == Tool.xd100x.GRAlarm.有)
                {
                    checkBox16.Checked = true;
                    checkBox16.ForeColor = Color.Red;
                }

            }

        }
        //关闭报警
        private void label63_Click(object sender, EventArgs e)
        {
            groupBox10.Visible = false;
        }
        //dgv隔行颜色
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
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
        //采集
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[i]._Info._id == Convert.ToInt32(dataGridView1["DeviceID", dataGridView1.CurrentRow.Index].Value))
                {
                    Form f1 = new SocketServer.messagebox(i);
                    f1.Show();
                    f1.Text = Tool.xd100x._XD100xBuffer[i]._Info._name;
                }
            }
        }
        //非采集站点更新缓存
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Tool.xd100x.load_lastdata();
            //for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            //{
            //    Tool.xd100x._XD100xBuffer[i]._Command[0]._back = true;
            //}
        }
        ////关闭排序方式
        //private void dataGridView1_Sorted(object sender, EventArgs e)
        //{
        //    if (checkBox17.Checked == false)
        //    {
        //        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //        {
        //            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        //        }
        //    }
        //}
        ////开启排序方式
        //private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //    {
        //        dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Automatic;
        //    }
        //}
        #endregion
        
        #region his
        //加载字段
        private void load_field()
        {
            string[] dgv_showname = {"时间","一次供温","一次回温","二次供温","二次回温","室外温度","二次供温基准","调节阀反馈",
                                        "一次供压","一次回压","水箱水位","二次供压","二次回压","二次压差设定","二次回压设定",
                                        "一次瞬时流量","一次累积流量",
                                        //包头
                                        //"一次瞬时热量","一次累积热量",
                                        //"二次瞬时流量","二次累积流量","二次瞬时热量","二次累积热量",
                                        //"补水瞬时流量","补水累积流量",
                                        "循环泵1状态","循环泵2状态","循环泵3状态","补水泵1状态","补水泵2状态"};
            for (int i = 0; i < dgv_showname.Length; i++)
            {
                checkedListBox1.Items.Add(dgv_showname[i]);
            }
            string sql = "select DeviceID,StationName from vDeviceGR where [Deleted]=0 order by [DeviceID]";
            DataTable dt = Tool.DB.getDt(sql);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "StationName";
            comboBox3.ValueMember = "DeviceID";
            comboBox3.SelectedIndex = 0;

            checkBox1.Checked = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }
        //字段全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox1.SelectedIndex = -1;
            if (checkBox1.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i,true);
                }
            }
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i,false);
                }
            }
        }
        //字段选择
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex == -1)
            {
                return;
            }
            checkBox1.CheckState = CheckState.Indeterminate;
        }
        //刷新显示
        private void his_date_ref()
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("请选择某个站点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string his_dgv_sql = "select ";
            string[] dgv_columns = { "DT", "GT1", "BT1", "GT2","BT2", "OT","GTB2","OD",
                                        "GP1", "BP1", "WL", "GP2", "BP2","PA2", "BPB2", 
                                       "WI1", "WS1", 
                                       //包头
                                       //"HS1", "HI1", 
                                       //"WI2", "WS2",  "HS2", "HI2",
                                       //"WI3", "WS3",
                                         "CM1", "CM2", "CM3", "RM1", "RM2"};


            int[] dgv_columnswide = {135,70,70,70,70,70,90,80,
                                        70, 70,70,70,70,90, 90,
                                        90,90,
                                    //包头
                                  //80,100,
                                  //80,100,80,100,
                                  //  80,100,
                                  80,80,80,80,80};

            if (checkedListBox1.CheckedItems.Count==0)
            {
                MessageBox.Show("请选择某个字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                his_dgv_sql = his_dgv_sql + dgv_columns[i] + ",";
            }
            his_dgv_sql = his_dgv_sql.TrimEnd(',') + " from tblGRData";
            
            DataTable dt = Tool.DB.getDt(his_dgv_sql + " where [DT]>='" + dateTimePicker1.Value.ToString() + "' and [DT]<='" + dateTimePicker2.Value.ToString() + "' and DeviceID= "+comboBox3.SelectedValue.ToString());
            dataGridView2.DataSource = "";
            dataGridView2.DataSource = dt;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                dataGridView2.Columns[i].HeaderText = checkedListBox1.Items[i].ToString();
                dataGridView2.Columns[i].Width = dgv_columnswide[i];
                if (checkedListBox1.GetItemChecked(i) != true)
                {
                    dataGridView2.Columns[i].Visible = false;
                }
            }
        }
        //查询
        private void button1_Click(object sender, EventArgs e)
        {
            his_date_ref();
            statistics();
        }
        //导出
        private void button2_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView2,comboBox3.Text+" "+ dateTimePicker1.Value.ToString() + "至" + dateTimePicker2.Value.ToString() + "报表");
        }
        //打印
        private void button3_Click(object sender, EventArgs e)
        {
            string inTitle = "    " + comboBox3.Text +" "+ dateTimePicker1.Value.ToString() + "至" + dateTimePicker2.Value.ToString() + "报表";
            Tool.PrintDGV.Print_DataGridView(dataGridView2, inTitle);
        }
        //计算
        private void statistics()
        {
            string sql = "select [HeatArea]  FROM vDeviceGR where [DeviceID] = "+comboBox3.SelectedValue.ToString();
            DataTable dt =Tool.DB.getDt(sql);
            textBox1.Text = dt.Rows[0]["HeatArea"].ToString();
            DataTable dt2 = dataGridView1.DataSource as DataTable;
            try
            {
                double liuliang=Convert.ToDouble(dt2.Compute("max(WI1)", "")) - Convert.ToDouble(dt2.Compute("min(WI1)", ""));
                textBox6.Text = liuliang.ToString("0");
                double wencha = Convert.ToDouble(dt2.Compute("max(GT1)", "")) - Convert.ToDouble(dt2.Compute("min(BT1)", ""));
                if (wencha < 0)
                    wencha = 0;
                textBox5.Text = (wencha * liuliang*4.1868/1000).ToString("0.0000");
            }
            catch
            {
            }
        }

        #endregion

        #region arlm
        //加载字段
        private void load_field_alarm()
        {
            string[] dgv_showname = {"站点名称","时间",
                                        //包头
                                       // "水位开关低","水位开关高",
                                        "一次供压低","二次供高压","二次回压高","二次回压低","一次供温低","二次供温高","水箱水位高","水箱水位低","循环泵1故障","循环泵2故障","循环泵3故障","补水泵1故障","补水泵2故障","掉电"};
            for (int i = 0; i < dgv_showname.Length; i++)
            {
                checkedListBox3.Items.Add(dgv_showname[i]);
            }
            string sql = "select DeviceID,StationName from vDeviceGR  where [Deleted]=0 order by [DeviceID]";
            DataTable dt = Tool.DB.getDt(sql);
            DataTable dt2 = new DataTable();
            dt2 = dt.Clone();
            dt2.Rows.Add();
            dt2.Rows[0]["DeviceID"] = -1;
            dt2.Rows[0]["StationName"] = "全部";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt2.Rows.Add(dt.Rows[i].ItemArray);
            }
            comboBox4.DataSource = dt2;
            comboBox4.DisplayMember = "StationName";
            comboBox4.ValueMember = "DeviceID";
            comboBox4.SelectedIndex = 0;
            checkBox3.Checked = true;
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, true);
            }
        }
        //字段全选
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBox3.SelectedIndex = -1;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, true);
                }
            }
            if (checkBox3.CheckState == CheckState.Unchecked)
            {
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, false);
                }
            }
        }
        //字段选择
        private void checkedListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox3.SelectedIndex == -1)
            {
                return;
            }
            checkBox3.CheckState = CheckState.Indeterminate;
        }
        //刷新显示
        private void alarm_date_ref()
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("请选择某个站点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string alarm_dgv_sql = "select ";
            string[] dgv_columns = { "StationName","DT",  
                                       //包头
                                      // "watboxdlow", "watboxdhight", 
                                       "oneGivePressL", "twoGivePressH" ,"twoBackPressH", "twoBackPressL","oneGiveTempL", "twoGiveTempH", "watboxahight", "watboxalow", "Pump1break", "Pump2break", "Pump3break", "addPump1break", "addPump2break","powercut" };
            int[] dgv_columnswide = { 110,140, 80, 
                                       //包头
                                      // "watboxdlow", "watboxdhight", 
                                       80,80,80,80,80,80,80,80, 80, 80,80,80,80 };
 
            if (checkedListBox3.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择某个字段！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                alarm_dgv_sql = alarm_dgv_sql + dgv_columns[i] + ",";            
            }
            alarm_dgv_sql = alarm_dgv_sql.TrimEnd(',') + " ,AW  from vGRAlarmData where [DT]>='" + dateTimePicker5.Value.ToString() + "' and [DT]<='" + dateTimePicker6.Value.ToString() + "'";
            if((int)comboBox4.SelectedValue!=-1) 
            {
                alarm_dgv_sql += " and DeviceID= '" + comboBox4.SelectedValue+"'";
            }
            DataTable dt = Tool.DB.getDt(alarm_dgv_sql);
            dataGridView7.DataSource = "";
            dataGridView7.DataSource = dt;
            dataGridView7.Columns["AW"].Visible = false;
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                dataGridView7.Columns[i].HeaderText = checkedListBox3.Items[i].ToString();
                dataGridView7.Columns[i].Width = dgv_columnswide[i];
                if (checkedListBox3.GetItemChecked(i) != true)
                {
                    dataGridView7.Columns[i].Visible = false;
                }
            }

        }
        //查询
        private void button6_Click(object sender, EventArgs e)
        {
            alarm_date_ref();
        }
        //打印表
        private void button7_Click(object sender, EventArgs e)
        {
            string inTitle = "    "+comboBox4.Text  +" "+ dateTimePicker5.Value.ToString() + "至" + dateTimePicker6.Value.ToString() + "报表";
            Tool.PrintDGV.Print_DataGridView(dataGridView7, inTitle);
        }
        //导出表
        private void button8_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView7,comboBox4.Text +" "+dateTimePicker5.Value.ToString() + "至" + dateTimePicker6.Value.ToString() + "报表");
        }

        //显示历史详细报警
        private void hdisplayalarm()
        {
            int dgvcr = 0;
            if (dataGridView7.CurrentCell == null)
            {
            }
            else
            {
                dgvcr = dataGridView7.CurrentRow.Index;
            }

            checkBox18.Checked = false;
            checkBox30.Checked = false;
            checkBox29.Checked = false;
            checkBox28.Checked = false;
            checkBox27.Checked = false;
            checkBox26.Checked = false;
            checkBox25.Checked = false;
            checkBox23.Checked = false;
            checkBox21.Checked = false;
            checkBox24.Checked = false;
            checkBox22.Checked = false;
            checkBox20.Checked = false;
            checkBox19.Checked = false;
            checkBox17.Checked = false;

            checkBox18.ForeColor = Color.Black;
            checkBox30.ForeColor = Color.Black;
            checkBox29.ForeColor = Color.Black;
            checkBox28.ForeColor = Color.Black;
            checkBox27.ForeColor = Color.Black;
            checkBox26.ForeColor = Color.Black;
            checkBox25.ForeColor = Color.Black;
            checkBox23.ForeColor = Color.Black;
            checkBox21.ForeColor = Color.Black;
            checkBox24.ForeColor = Color.Black;
            checkBox22.ForeColor = Color.Black;
            checkBox20.ForeColor = Color.Black;
            checkBox19.ForeColor = Color.Black;
            checkBox17.ForeColor = Color.Black;

            if (dataGridView7["powercut", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox18.Checked = true;
                checkBox18.ForeColor = Color.Red;
            }

            if (dataGridView7["oneGivePressL", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox30.Checked = true;
                checkBox30.ForeColor = Color.Red;
            }
            if (dataGridView7["twoGivePressH", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox29.Checked = true;
                checkBox29.ForeColor = Color.Red;
            }
            if (dataGridView7["twoBackPressH", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox28.Checked = true;
                checkBox28.ForeColor = Color.Red;
            }
            if (dataGridView7["twoBackPressL", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox27.Checked = true;
                checkBox27.ForeColor = Color.Red;
            }
            if (dataGridView7["oneGiveTempL", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox26.Checked = true;
                checkBox26.ForeColor = Color.Red;
            }
            if (dataGridView7["twoGiveTempH", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox25.Checked = true;
                checkBox25.ForeColor = Color.Red;
            }

            if (dataGridView7["watboxalow", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox23.Checked = true;
                checkBox23.ForeColor = Color.Red;
            }
            if (dataGridView7["watboxahight", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox21.Checked = true;
                checkBox21.ForeColor = Color.Red;
            }
            if (dataGridView7["Pump1break", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox24.Checked = true;
                checkBox24.ForeColor = Color.Red;
            }
            if (dataGridView7["Pump2break", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox22.Checked = true;
                checkBox22.ForeColor = Color.Red;
            }
            if (dataGridView7["Pump3break", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox20.Checked = true;
                checkBox20.ForeColor = Color.Red;
            }
            if (dataGridView7["addPump1break", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox19.Checked = true;
                checkBox19.ForeColor = Color.Red;
            }
            if (dataGridView7["addPump2break", dgvcr].Value.ToString().TrimEnd(' ') == Tool.xd100x.GRAlarm.有.ToString())
            {
                checkBox17.Checked = true;
                checkBox17.ForeColor = Color.Red;
            }


        }
        #endregion

        //历史时刻
        #region
        //刷新显示
        private void his_time_ref()
        {
            string sql = "SELECT [GRDataID],[DeviceID],[GroupName],[StationName],[HeatArea], [DT], [GT1], [BT1], [GT2], [BT2],[OT], [GTB2], [OD], [GP1], [BP1], [GP2], [BP2],  [PA2],[BPB2],[WL], [WI1], [WS1],  [CM1], [CM2], [CM3], [RM1], [RM2] FROM [vGRData]  where [DT]>='" + dateTimePicker3.Value.AddMinutes(Convert.ToDouble(-numericUpDown1.Value)).ToString() + "' and [DT]<='" + dateTimePicker3.Value.AddMinutes(Convert.ToDouble(numericUpDown1.Value)).ToString() + "'  order by [GroupID] ";
            DataTable dt = Tool.DB.getDt(sql);
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("没有符合条件的数据！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    return;
            //}
            
            //过滤重复后的DataTable
            DataTable newDt = new DataTable();
            newDt = dt.Clone();
            newDt.Rows.Clear();
            //每条数据的唯一标识ID
            string strValue = string.Empty;

            //循环源数据的DataTable
            foreach (DataRow dr in dt.Rows)
            {
                //过滤重复后的DataTable没有申明，不做操作。
                if (newDt == null)
                {
                    return;
                }
                //过滤重复后的DataTable第一次添加数据
                //那么跳出这次循环
                if (newDt.Rows.Count == 0)
                {
                    newDt.Rows.Add(dr.ItemArray);
                    continue;
                }
                //源数据中某条数据的唯一标识名（列名）
                strValue = Convert.ToString(dr["DeviceID"]);

                //如果过滤重复后的DataTable中有数据，
                //那么用从源数据中取出的数据在过滤重复后的DataTable中查找，如果存在（Length > 0）
                //那么跳出这次循环
                if (newDt.Rows.Count > 0 && newDt.Select("DeviceID=" + strValue).Length > 0)
                {
                    continue;
                }
                //无条件添加，因为肯定不是重复的数据
                newDt.Rows.Add(dr.ItemArray);
            }

            newDt.Columns.Remove(newDt.Columns["GRDataID"]);
            newDt.Columns.Remove(newDt.Columns["DeviceID"]);
            newDt.Columns.Add("avg");
          //  newDt.Columns["avg"].
            for (int i = 0; i < newDt.Rows.Count; i++)
            {
                if (Convert.ToDecimal(newDt.Rows[i]["HeatArea"].ToString()) == 0)
                {
                    newDt.Rows[i]["avg"] = "0";
                }
                else
                {
                    newDt.Rows[i]["avg"] =Math.Round(Convert.ToDecimal(newDt.Rows[i]["WI1"].ToString()) / Convert.ToDecimal(newDt.Rows[i]["HeatArea"].ToString()),2);
                }
            }

            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = newDt;
            dataGridView3.Columns["avg"].DisplayIndex = 4;

            string[] dgv_columns = {"GroupName","StationName","HeatArea", "DT","avg", "GT1", "BT1", "GT2","BT2", "OT",
                                       "GTB2", "GP1", "BP1", "WL", "GP2", "BP2", "BPB2", 
                                       "WI1", "WS1", 
                                       //"HS1", "HI1",
                                       //"WI2", "WS2", "HS2", "HI2",
                                       //"WI3", "WS3",  
                                       "PA2", "OD", "CM1", "CM2", "CM3", "RM1", "RM2"};
            string[] dgv_showname = {" 分组","站点名称","供热面积","时间","单位流量","一次供温","一次回温","二次供温","二次回温","室外温度",
                                        "二次供温基准","一次供压","一次回压","水箱水位","二次供压","二次回压","二次回压设定",
                                        "一次瞬时流量","一次累积流量",
                                        //"一次瞬时热量","一次累积热量",
                                        //"二次瞬时流量","二次累积流量","二次瞬时热量","二次累积热量",
                                        //"补水瞬时流量","补水累积流量",
                                        "二次压差设定","调节阀反馈","循环泵1状态","循环泵2状态","循环泵3状态","补水泵1状态","补水泵2状态"};

            int[] dgv_columnswide = {60,110,70,135,70,
                                        70,70,70,70,70,80,90,
                                        70,70,70,70,90, 90,90,
                                    90,100,
                                    //包头
                                  //80,100,
                                  //80,100,80,100,
                                  //  80,100,
                                   80,80,80,80,80,80};


            //包头
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dataGridView3.Columns[dgv_columns[i]].HeaderText = dgv_showname[i];
                dataGridView3.Columns[dgv_columns[i]].Width = dgv_columnswide[i];
            }
        }
        //查询
        private void button4_Click(object sender, EventArgs e)
        {
            his_time_ref();
        }
        //导出
        private void button1_Click_1(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView3,  "  " + dateTimePicker3.Value.ToString()  + " 数据");
        }
        //打印
        private void button2_Click_1(object sender, EventArgs e)
        {
            Tool.PrintDGV.Print_DataGridView(dataGridView3, "    " +  dateTimePicker3.Value.ToString() + " 数据");
        }
        //定制导出
        private void button5_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs2(dataGridView3, "  " + dateTimePicker3.Value.ToString() + " 数据");
        }



        #endregion
        //显示序号
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

        private void dataGridView7_CurrentCellChanged(object sender, EventArgs e)
        {
            hdisplayalarm();
        }

    }
}
