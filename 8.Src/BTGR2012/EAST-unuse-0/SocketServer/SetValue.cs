using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using ZedGraph;
using System.Text;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class SetValue : Form
    {
        public SetValue()
        {
            InitializeComponent();
        }

        private void SetValue_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2MinSize = 580;
            load_group();
            load_operate();
            timer2.Interval = 1000;
            timer2.Enabled = true;
        }

        //加载站点
        #region
        //选择站点分组
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            load_device(comboBox2.Text);
        }

        //加载站点列表
        private void load_device(string group)
        {
            string sql = "SELECT [DeviceID],[GroupName],[StationName],[IPAddress] FROM vDeviceGR ";
            if (comboBox2.Text == "全部")
            {
                sql += "where [Deleted]=0";
            }
            else
            {
                sql += " where [Deleted]=0 and [GroupName]='" + comboBox2.Text + "'";
            }
            dataGridView1.Columns.Clear();
            DataTable dt = Tool.DB.getDt(sql);
            dt.Columns.Add("iscon", typeof(String));
            dt.Columns.Add("isok", typeof(String));

            dataGridView1.DataSource = "";
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["DeviceID"].Visible = false;
            dataGridView1.Columns["IPAddress"].Visible = false;

            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.HeaderText = "";
            newColumn.Name = "select";
            newColumn.FalseValue = false;
            newColumn.TrueValue = true;
            dataGridView1.Columns.Add(newColumn);
            dataGridView1.Columns["select"].DisplayIndex = 0;
            dataGridView1.Columns["select"].Width = 40;

            dataGridView1.Columns["GroupName"].ReadOnly = true;
            dataGridView1.Columns["StationName"].ReadOnly = true;
            dataGridView1.Columns["iscon"].ReadOnly = true;
            dataGridView1.Columns["isok"].ReadOnly = true;

            string[] dgv_columns = { "DeviceID", "GroupName", "StationName", "IPAddress", "iscon", "isok" };
            string[] dgv_showname = { "站点标识","分组名称", "站点名称", "IP地址", "连接状态", "执行结果" };
            int[] dgv_columnswide = { 10,60,100,60, 60,250 };
            for (int i = 0; i < dgv_columns.Length; i++)
            {
                dataGridView1.Columns[dgv_columns[i]].HeaderText = dgv_showname[i];
                dataGridView1.Columns[dgv_columns[i]].Width = dgv_columnswide[i];
                dataGridView1.Columns[dgv_columns[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            reflashdv();
        }

        //加载分组信息
        private void load_group()
        {
            string sql = "SELECT GroupName FROM [tblGroup]";
            DataTable dt = Tool.DB.getDt(sql);
            comboBox2.Items.Clear();
            comboBox2.Items.Add("全部");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i]["GroupName"].ToString());
            }
            comboBox2.Text="全部";

        }

        //全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
          //  this.dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["select"].Value = checkBox1.Checked;
                if (dataGridView1.Rows[i].Cells["iscon"].Value.ToString() == "未连接")
                {
                    dataGridView1.Rows[i].Cells["select"].Value = false;
                } 
            }
        }
        #endregion

        //读取
        private void button1_Click(object sender, EventArgs e)
        {
            string stationname = string.Empty;
            int stationcount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["select"].FormattedValue)
                {
                    stationname = stationname + dataGridView1.Rows[i].Cells["StationName"].Value.ToString() + "  ";
                    stationcount++;
                }
            }
            if (stationcount == 0)
            {
                MessageBox.Show("请选择某个站点再进行读取！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.Yes != MessageBox.Show("确定对以下" + stationcount.ToString() + "个站点进行读取" + tabControl1.SelectedTab.Text + "操作？" + Environment.NewLine + stationname, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    return;
                }
            }
            byte[] cmdindex;
            switch (tabControl1.SelectedTab.Text)
            {
                case "供温模式":
                    cmdindex = new byte[]{1,2,3};
                    break;
                case "分时调整":
                    cmdindex = new byte[]{4};
                    break;
                case "温度修正":
                    cmdindex = new byte[] { 32, 33, 34, 35,36 };
                    if (checkBox2.Checked == false &&
                        checkBox3.Checked == false &&
                        checkBox4.Checked == false &&
                        checkBox5.Checked == false &&
                        checkBox6.Checked == false)
                    {
                        MessageBox.Show("请选择某个温度修正再进行设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    if (checkBox2.Checked == false)
                    {
                        cmdindex[0] = 255;
                    }
                    if (checkBox3.Checked == false)
                    {
                        cmdindex[1] = 255;
                    }
                    if (checkBox4.Checked == false)
                    {
                        cmdindex[2] = 255;
                    }
                    if (checkBox5.Checked == false)
                    {
                        cmdindex[3] = 255;
                    }
                    if (checkBox6.Checked == false)
                    {
                        cmdindex[4] = 255;
                    }
                    break;
                case "调节阀参数":
                    cmdindex = new byte[] {5};
                    break;
                case "循环泵参数":
                    cmdindex = new byte[] {7,8};
                    break;
                case "补水泵参数":
                    cmdindex = new byte[] {9,10};
                    break;
                case "报警值":
                    cmdindex = new byte[] {11,12};
                    break;
                case "泵启停控制":
                    cmdindex = new byte[]{};
                    break;        
                default: 
                    cmdindex = new byte[]{};
                    return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["select"].FormattedValue)
                {
                    int id = Convert.ToInt16(dataGridView1.Rows[i].Cells["DeviceID"].Value.ToString());
                    for (int j = 0; j < Tool.xd100x._XD100xBuffer.Length; j++)
                    {
                        if (id == Tool.xd100x._XD100xBuffer[j]._Info._id)
                        {
                            for (int k = 0; k < cmdindex.Length; k++)
                            {
                                if (cmdindex[k] == 255)
                                {
                                    continue;
                                }
                                Tool.xd100x._XD100xBuffer[j]._Command[cmdindex[k]]._onoff = true;
                            }
                        }
                    }
                }
            }

        }

        //设置
        private void button2_Click(object sender, EventArgs e)
        {
            string stationname = string.Empty;
            int stationcount = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["select"].FormattedValue)
                {
                    stationname = stationname + dataGridView1.Rows[i].Cells["StationName"].Value.ToString()+"  ";
                    stationcount++;
                }
            }
            if (stationcount == 0)
            {
                MessageBox.Show("请选择某个站点再进行设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.Yes != MessageBox.Show("确定对以下" + stationcount.ToString() + "个站点进行设置" + tabControl1.SelectedTab.Text + "操作？" + Environment.NewLine + stationname, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    return;
                }
            }

            byte[] cmdindex;
            switch (tabControl1.SelectedTab.Text)
            {
                case "供温模式":
                    cmdindex = new byte[] { 14, 15, 16 };
                    break;
                case "分时调整":
                    cmdindex = new byte[] { 17 };
                    break;
                case "温度修正":
                    cmdindex = new byte[] { 37, 38, 39, 40, 41};

                    if(checkBox2.Checked==false&&
                        checkBox3.Checked==false&&
                        checkBox4.Checked==false&&
                        checkBox5.Checked==false&&
                        checkBox6.Checked==false)
                    {
                        MessageBox.Show("请选择某个温度修正再进行设置！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                    if (checkBox2.Checked == false)
                    {
                        cmdindex[0] = 255;
                    }
                    if (checkBox3.Checked == false)
                    {
                        cmdindex[1] = 255;
                    }
                    if (checkBox4.Checked == false)
                    {
                        cmdindex[2] = 255;
                    }
                    if (checkBox5.Checked == false)
                    {
                        cmdindex[3] = 255;
                    }
                    if (checkBox6.Checked == false)
                    {
                        cmdindex[4] = 255;
                    }
                    break;
                case "调节阀参数":
                    cmdindex = new byte[] { 18 };
                    break;
                case "循环泵参数":
                    cmdindex = new byte[] { 20,21 }; //需要先发曲线 dtr rts需开启 20
                    break;
                case "补水泵参数":
                    cmdindex = new byte[] { 22, 23 };
                    break;
                case "报警值":
                    cmdindex = new byte[] { 24, 25 };
                    break;
                case "泵启停控制":
                    cmdindex = new byte[] { };
                    break;
                default:
                    cmdindex = new byte[] { };
                    return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells["select"].FormattedValue)
                {
                    int id = Convert.ToInt16(dataGridView1.Rows[i].Cells["DeviceID"].Value.ToString());
                    for (int j = 0; j < Tool.xd100x._XD100xBuffer.Length; j++)
                    {
                        if (id == Tool.xd100x._XD100xBuffer[j]._Info._id)
                        {
                            Tool.xd100x.Set _Set = ToSet(Tool.xd100x._XD100xBuffer[j]._Set,Tool.xd100x._XD100xBuffer[j]._Info._version);
                            Tool.xd100x._XD100xBuffer[j]._Set = _Set;
                            byte addr = Tool.xd100x._XD100xBuffer[j]._Info._addr;
                            //加载命令
                            if (Tool.xd100x._XD100xBuffer[j]._Info._version == "xd100n")
                            {
                                Tool.xd100x._XD100xBuffer[j]._Command[14]._cmd = Tool.xd100n.Set_valvecontrol(addr, _Set._valvecontrol);
                                Tool.xd100x._XD100xBuffer[j]._Command[15]._cmd = Tool.xd100n.Set_valvevalue(addr, _Set._valvevalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[16]._cmd = Tool.xd100n.Set_valveline(addr, _Set._valveline);
                                Tool.xd100x._XD100xBuffer[j]._Command[17]._cmd = Tool.xd100n.Set_valvetime(addr, _Set._valvetime);
                                Tool.xd100x._XD100xBuffer[j]._Command[18]._cmd = Tool.xd100n.Set_valvemm(addr, _Set._valvemm);
                                Tool.xd100x._XD100xBuffer[j]._Command[19]._cmd = Tool.xd100n.Set_valvelimit(addr, _Set._valvelimit);
                                Tool.xd100x._XD100xBuffer[j]._Command[20]._cmd = Tool.xd100n.Set_cycpumpline(addr, _Set._cycpumpline);
                                Tool.xd100x._XD100xBuffer[j]._Command[21]._cmd = Tool.xd100n.Set_cycpumpvalue(addr, _Set._cycpumpvalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[22]._cmd = Tool.xd100n.Set_addpumpvalue(addr, _Set._addpumpvalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[23]._cmd = Tool.xd100n.Set_addpumpmm(addr, _Set._addpumpmm);
                                Tool.xd100x._XD100xBuffer[j]._Command[24]._cmd = Tool.xd100n.Set_alarmp(addr, _Set._alarmp);
                                Tool.xd100x._XD100xBuffer[j]._Command[25]._cmd = Tool.xd100n.Set_alarmt(addr, _Set._alarmt);
                                Tool.xd100x._XD100xBuffer[j]._Command[26]._cmd = Tool.xd100n.Set_outmode(addr, _Set._outmode);
                                Tool.xd100x._XD100xBuffer[j]._Command[27]._cmd = Tool.xd100n.Set_outtemp(addr, _Set._outtemp);
                                Tool.xd100x._XD100xBuffer[j]._Command[37]._cmd = Tool.xd100n.Set_outrevise(addr, _Set._outrevise);
                                Tool.xd100x._XD100xBuffer[j]._Command[38]._cmd = Tool.xd100n.Set_GT1revise(addr, _Set._GT1revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[39]._cmd = Tool.xd100n.Set_BT1revise(addr, _Set._BT1revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[40]._cmd = Tool.xd100n.Set_GT2revise(addr, _Set._GT2revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[41]._cmd = Tool.xd100n.Set_BT2revise(addr, _Set._BT2revise);
                            }
                            else
                            {
                                Tool.xd100x._XD100xBuffer[j]._Command[14]._cmd = Tool.xd100.Set_valvecontrol(addr, _Set._valvecontrol, _Set._valvevalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[15]._cmd = Tool.xd100.Set_valvevalue(addr, _Set._valvecontrol, _Set._valvevalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[16]._cmd = Tool.xd100.Set_valveline(addr, _Set._valveline);
                                Tool.xd100x._XD100xBuffer[j]._Command[17]._cmd = Tool.xd100.Set_valvetime(addr, _Set._valvetime);
                                Tool.xd100x._XD100xBuffer[j]._Command[18]._cmd = Tool.xd100.Set_valvemm(addr, _Set._valvemm);
                                Tool.xd100x._XD100xBuffer[j]._Command[19]._cmd = Tool.xd100.Set_valvelimit(addr, _Set._valvelimit);
                                Tool.xd100x._XD100xBuffer[j]._Command[20]._cmd = Tool.xd100.Set_cycpumpline(addr, _Set._cycpumpline);
                                Tool.xd100x._XD100xBuffer[j]._Command[21]._cmd = Tool.xd100.Set_cycpumpvalue(addr, _Set._cycpumpvalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[22]._cmd = Tool.xd100.Set_addpumpvalue(addr, _Set._addpumpvalue);
                                Tool.xd100x._XD100xBuffer[j]._Command[23]._cmd = Tool.xd100.Set_addpumpmm(addr, _Set._addpumpmm);
                                Tool.xd100x._XD100xBuffer[j]._Command[24]._cmd = Tool.xd100.Set_alarmp(addr, _Set._alarmp);
                                Tool.xd100x._XD100xBuffer[j]._Command[25]._cmd = Tool.xd100.Set_alarmt(addr, _Set._alarmt);
                                Tool.xd100x._XD100xBuffer[j]._Command[26]._cmd = Tool.xd100.Set_outmode(addr, _Set._outmode);
                                Tool.xd100x._XD100xBuffer[j]._Command[27]._cmd = Tool.xd100.Set_outtemp(addr, _Set._outtemp);
                                Tool.xd100x._XD100xBuffer[j]._Command[37]._cmd = Tool.xd100.Set_outrevise(addr, _Set._outrevise);
                                Tool.xd100x._XD100xBuffer[j]._Command[38]._cmd = Tool.xd100.Set_GT1revise(addr, _Set._GT1revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[39]._cmd = Tool.xd100.Set_BT1revise(addr, _Set._BT1revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[40]._cmd = Tool.xd100.Set_GT2revise(addr, _Set._GT2revise);
                                Tool.xd100x._XD100xBuffer[j]._Command[41]._cmd = Tool.xd100.Set_BT2revise(addr, _Set._BT2revise);
                            }
                            for (int k = 0; k < cmdindex.Length; k++)
                            {
                                //若读取命令没有返回则不进行下设
                                switch (cmdindex[k])
                                {
                                    case 14: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[1]._backdt).TotalMinutes >60) continue; break;
                                    case 15: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[2]._backdt).TotalMinutes >60) continue; break;
                                    case 16: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[3]._backdt).TotalMinutes >60) continue; break;
                                    case 17: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[4]._backdt).TotalMinutes >60) continue; break;
                                    case 18: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[5]._backdt).TotalMinutes > 60) continue; break;
                                    case 20: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[7]._backdt).TotalMinutes > 60) continue; break;
                                    case 21: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[8]._backdt).TotalMinutes > 60) continue; break;
                                    case 22: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[9]._backdt).TotalMinutes > 60) continue; break;
                                    case 23: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[10]._backdt).TotalMinutes > 60) continue; break;
                                    case 24: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[11]._backdt).TotalMinutes > 60) continue; break;
                                    case 25: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[12]._backdt).TotalMinutes > 60) continue; break;
                                    case 26: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[13]._backdt).TotalMinutes > 60) continue; break;
                                    case 37: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[32]._backdt).TotalMinutes > 60) continue; break;
                                    case 38: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[33]._backdt).TotalMinutes > 60) continue; break;
                                    case 39: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[34]._backdt).TotalMinutes > 60) continue; break;
                                    case 40: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[35]._backdt).TotalMinutes > 60) continue; break;
                                    case 41: if ((DateTime.Now - Tool.xd100x._XD100xBuffer[j]._Command[36]._backdt).TotalMinutes > 60) continue; break;
                                    default: continue;
                                }
                                Tool.xd100x._XD100xBuffer[j]._Command[cmdindex[k]]._onoff = true;
                            }
                        }
                    }
                }
            }

        }

        //将_Set数据刷到界面
        private void FromSet(Tool.xd100x.Set _Set,string version)
        {
            //调节阀模式
            if (version == "xd100")
            {
                if (_Set._valvecontrol._control/16 == 0)
                {
                    this.radioButton1.Checked = true;
                }
                if (_Set._valvecontrol._control/16 == 1)
                {
                    this.radioButton2.Checked = true;
                }
            }
            if (version == "xd100n")
            {
                if (_Set._valvecontrol._control == 0)
                {
                    this.radioButton1.Checked = true;
                }
                if (_Set._valvecontrol._control == 3)
                {
                    this.radioButton2.Checked = true;
                }
            }
            //调节阀设定值
            numsv.Value = Convert.ToDecimal(_Set._valvevalue._value);
            //气候补偿曲线
            txtot1.Value = Convert.ToDecimal(_Set._valveline._ov1);
            txtot2.Value = Convert.ToDecimal(_Set._valveline._ov2);
            txtot3.Value = Convert.ToDecimal(_Set._valveline._ov3);
            txtot4.Value = Convert.ToDecimal(_Set._valveline._ov4);
            txtot5.Value = Convert.ToDecimal(_Set._valveline._ov5);
            txtot6.Value = Convert.ToDecimal(_Set._valveline._ov6);
            txtot7.Value = Convert.ToDecimal(_Set._valveline._ov7);
            txtot8.Value = Convert.ToDecimal(_Set._valveline._ov8);
            txtgt1.Value = Convert.ToDecimal(_Set._valveline._gv1);
            txtgt2.Value = Convert.ToDecimal(_Set._valveline._gv2);
            txtgt3.Value = Convert.ToDecimal(_Set._valveline._gv3);
            txtgt4.Value = Convert.ToDecimal(_Set._valveline._gv4);
            txtgt5.Value = Convert.ToDecimal(_Set._valveline._gv5);
            txtgt6.Value = Convert.ToDecimal(_Set._valveline._gv6);
            txtgt7.Value = Convert.ToDecimal(_Set._valveline._gv7);
            txtgt8.Value = Convert.ToDecimal(_Set._valveline._gv8);
            //分时调整
            txtV1.Value = Convert.ToDecimal(_Set._valvetime._v1);
            txtV2.Value = Convert.ToDecimal(_Set._valvetime._v2);
            txtV3.Value = Convert.ToDecimal(_Set._valvetime._v3);
            txtV4.Value = Convert.ToDecimal(_Set._valvetime._v4);
            txtV5.Value = Convert.ToDecimal(_Set._valvetime._v5);
            txtV6.Value = Convert.ToDecimal(_Set._valvetime._v6);
            txtV7.Value = Convert.ToDecimal(_Set._valvetime._v7);
            txtV8.Value = Convert.ToDecimal(_Set._valvetime._v8);
            txtV9.Value = Convert.ToDecimal(_Set._valvetime._v9);
            txtV10.Value = Convert.ToDecimal(_Set._valvetime._v10);
            txtV11.Value = Convert.ToDecimal(_Set._valvetime._v11);
            txtV12.Value = Convert.ToDecimal(_Set._valvetime._v12);
            //调节阀上下限
            txtmax.Value = Convert.ToDecimal(_Set._valvemm._max);
            txtmin.Value = Convert.ToDecimal(_Set._valvemm._min);
            //室外温度模式
            if (_Set._outmode._outmode == 0)
            {
                radioButton6.Checked = true;
            }
            if (_Set._outmode._outmode == 1)
            {
                radioButton5.Checked = true;
            }
            //室外温度修正
            numk.Value = Convert.ToDecimal(_Set._outrevise._k);
            numb.Value = Convert.ToDecimal(_Set._outrevise._b);
            textBox1.Text = _Set._outrevise._temp.ToString("0.0");
            if (_Set._outrevise._k == 0)
            {
                txtot.Text = "0.0";
            }
            else
            {
                txtot.Text = ((_Set._outrevise._temp - _Set._outrevise._b) / _Set._outrevise._k).ToString("0.0");
            }
            //一次供温度修正
            numericUpDown1.Value = Convert.ToDecimal(_Set._GT1revise._k);
            numericUpDown2.Value = Convert.ToDecimal(_Set._GT1revise._b);
            textBox2.Text = _Set._GT1revise._temp.ToString("0.0");
            if (_Set._GT1revise._k == 0)
            {
                txtOneGT.Text = "0.0";
            }
            else
            {
                txtOneGT.Text = ((_Set._GT1revise._temp - _Set._GT1revise._b) / _Set._GT1revise._k).ToString("0.0");
            }
            //一次回温度修正
            numericUpDown3.Value = Convert.ToDecimal(_Set._BT1revise._k);
            numericUpDown4.Value = Convert.ToDecimal(_Set._BT1revise._b);
            textBox3.Text = _Set._BT1revise._temp.ToString("0.0");
            if (_Set._BT1revise._k == 0)
            {
                txtOneBT.Text = "0.0";
            }
            else
            {
                txtOneBT.Text = ((_Set._BT1revise._temp - _Set._BT1revise._b) / _Set._BT1revise._k).ToString("0.0");
            }
            //二次供温度修正
            numericUpDown5.Value = Convert.ToDecimal(_Set._GT2revise._k);
            numericUpDown6.Value = Convert.ToDecimal(_Set._GT2revise._b);
            textBox4.Text = _Set._GT2revise._temp.ToString("0.0");
            if (_Set._GT2revise._k == 0)
            {
                txtTwoGT.Text = "0.0";
            }
            else
            {
                txtTwoGT.Text = ((_Set._GT2revise._temp - _Set._GT2revise._b) / _Set._GT2revise._k).ToString("0.0");
            }
            //二次回温度修正
            numericUpDown7.Value = Convert.ToDecimal(_Set._BT2revise._k);
            numericUpDown8.Value = Convert.ToDecimal(_Set._BT2revise._b);
            textBox5.Text = _Set._BT2revise._temp.ToString("0.0");
            if (_Set._BT2revise._k == 0)
            {
                txtTwoBT.Text = "0.0";
            }
            else
            {
                txtTwoBT.Text = ((_Set._BT2revise._temp - _Set._BT2revise._b) / _Set._BT2revise._k).ToString("0.0");
            }
            //循环泵压差曲线
            numot1.Value = Convert.ToDecimal(_Set._cycpumpline._ov1);
            numot2.Value = Convert.ToDecimal(_Set._cycpumpline._ov2);
            numot3.Value = Convert.ToDecimal(_Set._cycpumpline._ov3);
            numot4.Value = Convert.ToDecimal(_Set._cycpumpline._ov4);
            numot5.Value = Convert.ToDecimal(_Set._cycpumpline._ov5);
            numot6.Value = Convert.ToDecimal(_Set._cycpumpline._ov6);
            numot7.Value = Convert.ToDecimal(_Set._cycpumpline._ov7);
            numot8.Value = Convert.ToDecimal(_Set._cycpumpline._ov8);
            nump1.Value = Convert.ToDecimal(_Set._cycpumpline._pv1);
            nump2.Value = Convert.ToDecimal(_Set._cycpumpline._pv2);
            nump3.Value = Convert.ToDecimal(_Set._cycpumpline._pv3);
            nump4.Value = Convert.ToDecimal(_Set._cycpumpline._pv4);
            nump5.Value = Convert.ToDecimal(_Set._cycpumpline._pv5);
            nump6.Value = Convert.ToDecimal(_Set._cycpumpline._pv6);
            nump7.Value = Convert.ToDecimal(_Set._cycpumpline._pv7);
            nump8.Value = Convert.ToDecimal(_Set._cycpumpline._pv8);
            //循环泵压差设定
            numyc.Value = Convert.ToDecimal(_Set._cycpumpvalue._pressure);
            //补水泵模式及压力
            if (_Set._addpumpvalue._type == 0)
            {
                radioButton3.Checked = true;
            }
            if (version == "xd100")
            {
                if (_Set._addpumpvalue._type == 2)
                {
                    radioButton4.Checked = true;
                }
            }
            if (version == "xd100n")
            {
                if (_Set._addpumpvalue._type == 1)
                {
                    radioButton4.Checked = true;
                }
            }
            //补水压力设定
            numaddp.Value = Convert.ToDecimal(_Set._addpumpvalue._pressure);
            //补水泵压力上下限和液位上下限
            numaddmax.Value = Convert.ToDecimal(_Set._addpumpmm._presshight);
            numaddmin.Value = Convert.ToDecimal(_Set._addpumpmm._presslow);
            numaddlh.Value = Convert.ToDecimal(_Set._addpumpmm._levelhight);
            numaddll.Value = Convert.ToDecimal(_Set._addpumpmm._levellow);
            //压力报警
            txtygd.Value = Convert.ToDecimal(_Set._alarmp._yicigdiya);
            txtegg.Value = Convert.ToDecimal(_Set._alarmp._erciggaoya);
            txtehg.Value = Convert.ToDecimal(_Set._alarmp._ercihgaoya);
            txtehd.Value = Convert.ToDecimal(_Set._alarmp._ercihdiya);
            //温度液位报警值
            txtygdw.Value = Convert.ToDecimal(_Set._alarmt._yicigdiwen);
            txteggw.Value = Convert.ToDecimal(_Set._alarmt._erciggaowen);
            txtwd.Value = Convert.ToDecimal(_Set._alarmt._waterlow);
            txtwg.Value = Convert.ToDecimal(_Set._alarmt._waterhight);

        }
        //从界面上提取_Set数据
        private Tool.xd100x.Set ToSet(Tool.xd100x.Set _Set,string version)
        {
            //调节阀模式
            if (version == "xd100")
            {
                if (this.radioButton1.Checked == true)
                {
                    _Set._valvecontrol._control = _Set._valvecontrol._control&0x0f;
                }
                if (this.radioButton2.Checked == true)
                {
                    _Set._valvecontrol._control = _Set._valvecontrol._control | 0x10;
                }
            }
            if (version == "xd100n")
            {
                if (this.radioButton1.Checked == true)
                {
                    _Set._valvecontrol._control = 0;
                }
                if (this.radioButton2.Checked == true)
                {
                    _Set._valvecontrol._control = 3;
                }
            }
            //调节阀设定值
            _Set._valvevalue._value = Convert.ToSingle(numsv.Value);
            //气候补偿曲线
            _Set._valveline._ov1 = Convert.ToInt16(txtot1.Value);
            _Set._valveline._ov2 = Convert.ToInt16(txtot2.Value);
            _Set._valveline._ov3 = Convert.ToInt16(txtot3.Value);
            _Set._valveline._ov4 = Convert.ToInt16(txtot4.Value);
            _Set._valveline._ov5 = Convert.ToInt16(txtot5.Value);
            _Set._valveline._ov6 = Convert.ToInt16(txtot6.Value);
            _Set._valveline._ov7 = Convert.ToInt16(txtot7.Value);
            _Set._valveline._ov8 = Convert.ToInt16(txtot8.Value);
            _Set._valveline._gv1 = Convert.ToInt16(txtgt1.Value);
            _Set._valveline._gv2 = Convert.ToInt16(txtgt2.Value);
            _Set._valveline._gv3 = Convert.ToInt16(txtgt3.Value);
            _Set._valveline._gv4 = Convert.ToInt16(txtgt4.Value);
            _Set._valveline._gv5 = Convert.ToInt16(txtgt5.Value);
            _Set._valveline._gv6 = Convert.ToInt16(txtgt6.Value);
            _Set._valveline._gv7 = Convert.ToInt16(txtgt7.Value);
            _Set._valveline._gv8 = Convert.ToInt16(txtgt8.Value);
            //分时调整
            _Set._valvetime._v1 = Convert.ToSingle(txtV1.Value);
            _Set._valvetime._v2 = Convert.ToSingle(txtV2.Value);
            _Set._valvetime._v3 = Convert.ToSingle(txtV3.Value);
            _Set._valvetime._v4 = Convert.ToSingle(txtV4.Value);
            _Set._valvetime._v5 = Convert.ToSingle(txtV5.Value);
            _Set._valvetime._v6 = Convert.ToSingle(txtV6.Value);
            _Set._valvetime._v7 = Convert.ToSingle(txtV7.Value);
            _Set._valvetime._v8 = Convert.ToSingle(txtV8.Value);
            _Set._valvetime._v9 = Convert.ToSingle(txtV9.Value);
            _Set._valvetime._v10 = Convert.ToSingle(txtV10.Value);
            _Set._valvetime._v11 = Convert.ToSingle(txtV11.Value);
            _Set._valvetime._v12 = Convert.ToSingle(txtV12.Value);
            //调节阀上下限
            _Set._valvemm._max = Convert.ToInt16(txtmax.Value);
            _Set._valvemm._min = Convert.ToInt16(txtmin.Value);
            //室外温度模式
            if (radioButton6.Checked == true)
            {
                _Set._outmode._outmode = 0;
            }
            if (radioButton5.Checked == true)
            {
                _Set._outmode._outmode = 1;
            }
            //室外温度修正
            _Set._outrevise._k = Convert.ToSingle(numk.Value);
            _Set._outrevise._b = Convert.ToSingle(numb.Value);
            //一次供温度修正
            _Set._GT1revise._k = Convert.ToSingle(numericUpDown1.Value);
            _Set._GT1revise._b = Convert.ToSingle(numericUpDown2.Value);
            //一次回温度修正
            _Set._BT1revise._k = Convert.ToSingle(numericUpDown3.Value);
            _Set._BT1revise._b = Convert.ToSingle(numericUpDown4.Value);
            //二次供温度修正
            _Set._GT2revise._k = Convert.ToSingle(numericUpDown5.Value);
            _Set._GT2revise._b = Convert.ToSingle(numericUpDown6.Value);
            //二次回温度修正
            _Set._BT2revise._k = Convert.ToSingle(numericUpDown7.Value);
            _Set._BT2revise._b = Convert.ToSingle(numericUpDown8.Value);

            //循环泵压差曲线
            _Set._cycpumpline._ov1 = Convert.ToInt16(numot1.Value);
            _Set._cycpumpline._ov2 = Convert.ToInt16(numot2.Value);
            _Set._cycpumpline._ov3 = Convert.ToInt16(numot3.Value);
            _Set._cycpumpline._ov4 = Convert.ToInt16(numot4.Value);
            _Set._cycpumpline._ov5 = Convert.ToInt16(numot5.Value);
            _Set._cycpumpline._ov6 = Convert.ToInt16(numot6.Value);
            _Set._cycpumpline._ov7 = Convert.ToInt16(numot7.Value);
            _Set._cycpumpline._ov8 = Convert.ToInt16(numot8.Value);
            _Set._cycpumpline._pv1 = Convert.ToSingle(nump1.Value);
            _Set._cycpumpline._pv2 = Convert.ToSingle(nump2.Value);
            _Set._cycpumpline._pv3 = Convert.ToSingle(nump3.Value);
            _Set._cycpumpline._pv4 = Convert.ToSingle(nump4.Value);
            _Set._cycpumpline._pv5 = Convert.ToSingle(nump5.Value);
            _Set._cycpumpline._pv6 = Convert.ToSingle(nump6.Value);
            _Set._cycpumpline._pv7 = Convert.ToSingle(nump7.Value);
            _Set._cycpumpline._pv8 = Convert.ToSingle(nump8.Value);
            //循环泵压差设定
            _Set._cycpumpvalue._pressure = Convert.ToSingle(numyc.Value);
            //补水泵模式及压力
            if (radioButton3.Checked == true)
            {
                 _Set._addpumpvalue._type = 0;
            }
            if (version == "xd100")
            {
                if (radioButton4.Checked == true)
                {
                    _Set._addpumpvalue._type = 2;
                }
            }
            if (version == "xd100n")
            {
                if (radioButton4.Checked == true)
                {
                    _Set._addpumpvalue._type = 1;
                }
            }
            //补水压力设定
            _Set._addpumpvalue._pressure = Convert.ToSingle(numaddp.Value);
            //补水泵压力上下限和液位上下限
            _Set._addpumpmm._presshight = Convert.ToSingle(numaddmax.Value);
            _Set._addpumpmm._presslow = Convert.ToSingle(numaddmin.Value);
            _Set._addpumpmm._levelhight = Convert.ToSingle(numaddlh.Value);
            _Set._addpumpmm._levellow = Convert.ToSingle(numaddll.Value);
            //压力报警
            _Set._alarmp._yicigdiya = Convert.ToSingle(txtygd.Value);
            _Set._alarmp._erciggaoya = Convert.ToSingle(txtegg.Value);
            _Set._alarmp._ercihgaoya = Convert.ToSingle(txtehg.Value);
            _Set._alarmp._ercihdiya = Convert.ToSingle(txtehd.Value);
            //温度液位报警值
            _Set._alarmt._yicigdiwen = Convert.ToInt16(txtygdw.Value);
            _Set._alarmt._erciggaowen = Convert.ToInt16(txteggw.Value);
            _Set._alarmt._waterlow = Convert.ToSingle(txtwd.Value);
            _Set._alarmt._waterhight = Convert.ToSingle(txtwg.Value);

            return _Set;
        }

        //选择站点发生变化
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            reflashset();
        }
        //选择参数变化
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reflashset();
        }
        //刷新站点数据
        private void reflashset()
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["DeviceID"].Value);
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[i]._Info._id == id)
                {
                    FromSet(Tool.xd100x._XD100xBuffer[i]._Set, Tool.xd100x._XD100xBuffer[i]._Info._version);
                    reflash_vl();
                    reflash_vt();
                    reflash_pl();
                }
            }
        }
        //刷新设置数据
        private void reflashdv()
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < Tool.Gprs._GprsList.Length; j++)
                {
                    if (dt.Rows[i]["IPAddress"].ToString() == Tool.Gprs._GprsList[j]._ip)
                    {
                        if (Tool.Gprs._GprsList[j]._Iscon == true)
                        {
                            dt.Rows[i]["iscon"] = "已连接";
                        }
                        else
                        {
                            dt.Rows[i]["iscon"] = "未连接";
                        }
                        break;
                    }
                }
                for (int k = 0; k < Tool.xd100x._XD100xBuffer.Length; k++)
                {
                    if (dt.Rows[i]["DeviceID"].ToString() == Tool.xd100x._XD100xBuffer[k]._Info._id.ToString())
                    {
                        dt.Rows[i]["isok"] = Tool.xd100x._XD100xBuffer[k]._Info._result;
                        break;
                    }
                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["iscon"].Value.ToString() == "未连接")
                {
                    dataGridView1.Rows[i].Cells["select"].Value = false;
                }
            }

        }
        //刷新命令结果
        private bool reflashflag;
        private void reflashback()
        {
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[i]._Command[1]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[2]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[3]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读供温模式成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[1]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[2]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[3]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[4]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读分时调整成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[4]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[32]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读室外温度修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[32]._back = false;
                    reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[33]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读一次供温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[33]._back = false;
                    reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[34]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读一次回温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[34]._back = false;
                    reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[35]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读二次供温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[35]._back = false;
                    reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[36]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读二次回温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[36]._back = false;
                    reflashflag = true;
                }



                if (Tool.xd100x._XD100xBuffer[i]._Command[5]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读调节阀参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[5]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[7]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[8]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读循环泵参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[7]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[8]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[9]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[10]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读补水泵参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[9]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[10]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[11]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[12]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 读报警值成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[11]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[12]._back = false;
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[14]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[15]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[16]._back == true)
                {

                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置供温模式成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[14]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[15]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[16]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置供温模式成功");
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[17]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置分时调整成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[17]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置分时调整成功");
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[37]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置室外温度修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[37]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置室外温度修正成功");
                 //   reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[38]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置一次供温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[38]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置一次供温修正成功");
                 //   reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[39]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置一次回温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[39]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置一次回温修正成功");
                 //   reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[40]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置二次供温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[40]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置二次供温修正成功");
                 //   reflashflag = true;
                }
                if (Tool.xd100x._XD100xBuffer[i]._Command[41]._back == true )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置二次回温修正成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[41]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置二次回温修正成功");
                  //  reflashflag = true;
                }


                if (Tool.xd100x._XD100xBuffer[i]._Command[18]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置调节阀参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[18]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置调节阀参数成功");
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[21]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[20]._back == true
                    )
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置循环泵参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[21]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[20]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置循环泵参数成功");
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[22]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[23]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置补水泵参数成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[22]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[23]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置补水泵参数成功");
                    reflashflag = true;
                }

                if (Tool.xd100x._XD100xBuffer[i]._Command[24]._back == true &&
                    Tool.xd100x._XD100xBuffer[i]._Command[25]._back == true)
                {
                    Tool.xd100x._XD100xBuffer[i]._Info._result = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 设置报警值成功";
                    Tool.xd100x._XD100xBuffer[i]._Command[24]._back = false;
                    Tool.xd100x._XD100xBuffer[i]._Command[25]._back = false;
                    save_operate(Tool.xd100x._XD100xBuffer[i]._Info._id, "设置报警值成功");
                    reflashflag = true;
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            reflashback();
            reflashdv();
            if (reflashflag == true)
            {
                reflashflag = false;
                reflashset();
            }
            if (Tool.UersCheck.UserName == "Guest")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
            
        }
        //存储设定的操作记录
        private void save_operate(int stationid, string operate)
        {
            string sql = "INSERT INTO [tblOperate]([UserName],[DeviceID],[DT],[Operate]) VALUES ('" + Tool.UersCheck.UserName + "' ," + stationid + " ,'"+ DateTime.Now+"','" + operate + "')";
            Tool.DB.runCmd(sql);
        }
        //更新温度曲线
        private void reflash_vl()
        {
            PointPairList list1 = new PointPairList();
            double x;
            double y;
            x = Convert.ToDouble(txtot1.Value);
            y = Convert.ToDouble(txtgt1.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot2.Value);
            y = Convert.ToDouble(txtgt2.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot3.Value);
            y = Convert.ToDouble(txtgt3.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot4.Value);
            y = Convert.ToDouble(txtgt4.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot5.Value);
            y = Convert.ToDouble(txtgt5.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot6.Value);
            y = Convert.ToDouble(txtgt6.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot7.Value);
            y = Convert.ToDouble(txtgt7.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(txtot8.Value);
            y = Convert.ToDouble(txtgt8.Value);
            list1.Add(x, y);

            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl1.ZoomOutAll(myPane);
            myPane.Title.Text = "调节阀温度曲线";
            myPane.XAxis.Title.Text = "室外温度";
            myPane.YAxis.Title.Text = "预期供温";
            myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
            myPane.YAxis.MajorGrid.IsVisible = true;

            LineItem myCurve1 = myPane.AddCurve(myPane.Title.Text, list1, Color.Red, SymbolType.None);
            myCurve1.Symbol.Size = 2.0f;
            myCurve1.Line.Width = 2.0F;
            myCurve1.Line.IsAntiAlias = true; //抗锯齿

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            reflash_vl();
        }
        //更新分时调整曲线
        private void reflash_vt()
        {
            PointPairList list1 = new PointPairList();
            double x;
            double y;
            y = Convert.ToDouble(txtV1.Value);
            x = 0;
            list1.Add(x,y);
            x = 2;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV2.Value);
            x =2;
            list1.Add(x, y);
            x = 4;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV3.Value);
            x =4;
            list1.Add(x, y);
            x = 6;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV4.Value);
            x =6;
            list1.Add(x, y);
            x = 8;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV5.Value);
            x = 8;
            list1.Add(x, y);
            x = 10;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV6.Value);
            x = 10;
            list1.Add(x, y);
            x = 12;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV7.Value);
            x = 12;
            list1.Add(x, y);
            x = 14;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV8.Value);
            x = 14;
            list1.Add(x, y);
            x = 16;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV9.Value);
            x = 16;
            list1.Add(x, y);
            x = 18;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV10.Value);
            x = 18;
            list1.Add(x, y);
            x = 20;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV11.Value);
            x = 20;
            list1.Add(x, y);
            x = 22;
            list1.Add(x, y);

            y = Convert.ToDouble(txtV12.Value);
            x = 22;
            list1.Add(x, y);
            x = 24;
            list1.Add(x, y);

            GraphPane myPane = zedGraphControl3.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl1.ZoomOutAll(myPane);
            myPane.Title.Text = "调节阀温度分时调整";
            myPane.XAxis.Title.Text = "时段";
            myPane.YAxis.Title.Text = "温度修正";
            myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
            myPane.YAxis.MajorGrid.IsVisible = true;
            
            myPane.XAxis.Scale.Max = 24;
            myPane.XAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 10;
            myPane.YAxis.Scale.Min = -10;
            myPane.XAxis.Scale.MajorStep =2 ;
            myPane.YAxis.Scale.MajorStep = 2;


            LineItem myCurve1 = myPane.AddCurve(myPane.Title.Text, list1, Color.Red, SymbolType.None);
            myCurve1.Symbol.Size = 2.0f;
            myCurve1.Line.Width = 2.0F;
            myCurve1.Line.IsAntiAlias = true; //抗锯齿

            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            reflash_vt();
        }
        //更新循环泵曲线
        private void reflash_pl()
        {
            PointPairList list1 = new PointPairList();
            double x;
            double y;
            x = Convert.ToDouble(numot1.Value);
            y = Convert.ToDouble(nump1.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot2.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump2.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot3.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump3.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot4.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump4.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot5.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump5.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot6.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump6.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot7.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump7.Value);
            list1.Add(x, y);

            x = Convert.ToDouble(numot8.Value);
            list1.Add(x, y);
            y = Convert.ToDouble(nump8.Value);
            list1.Add(x, y);
            list1.Add(x+5, y);

            GraphPane myPane = zedGraphControl2.GraphPane;
            myPane.CurveList.Clear();
            this.zedGraphControl2.ZoomOutAll(myPane);
            myPane.Title.Text = "循环泵压差曲线";
            myPane.XAxis.Title.Text = "室外温度";
            myPane.YAxis.Title.Text = "压差修正";
            myPane.XAxis.MajorGrid.IsVisible = true;  //珊格子
            myPane.YAxis.MajorGrid.IsVisible = true;

            LineItem myCurve1 = myPane.AddCurve(myPane.Title.Text, list1, Color.Red, SymbolType.None);
            myCurve1.Symbol.Size = 2.0f;
            myCurve1.Line.Width = 2.0F;
            myCurve1.Line.IsAntiAlias = true; //抗锯齿
            myPane.YAxis.Scale.Max = 1;
            myPane.YAxis.Scale.Min = -1;

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            reflash_pl();
        }
        //室外温度限定条件
        #region
        private void txtot1_ValueChanged(object sender, EventArgs e)
        {
            txtot2.Minimum = txtot1.Value;
        }

        private void txtot2_ValueChanged(object sender, EventArgs e)
        {
            txtot3.Minimum = txtot2.Value;
        }

        private void txtot3_ValueChanged(object sender, EventArgs e)
        {
            txtot4.Minimum = txtot3.Value;
        }

        private void txtot4_ValueChanged(object sender, EventArgs e)
        {
            txtot5.Minimum = txtot4.Value;
        }

        private void txtot5_ValueChanged(object sender, EventArgs e)
        {
            txtot6.Minimum = txtot5.Value;
        }

        private void txtot6_ValueChanged(object sender, EventArgs e)
        {
            txtot7.Minimum = txtot6.Value;
        }

        private void txtot7_ValueChanged(object sender, EventArgs e)
        {
            txtot8.Minimum = txtot7.Value;
        }

        private void txtot8_ValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        //预期供温限定条件
        #region
        private void txtgt1_ValueChanged(object sender, EventArgs e)
        {
            txtgt2.Maximum = txtgt1.Value;
        }

        private void txtgt2_ValueChanged(object sender, EventArgs e)
        {
            txtgt3.Maximum = txtgt2.Value;
        }

        private void txtgt3_ValueChanged(object sender, EventArgs e)
        {
            txtgt4.Maximum = txtgt3.Value;
        }

        private void txtgt4_ValueChanged(object sender, EventArgs e)
        {
            txtgt5.Maximum = txtgt4.Value;
        }

        private void txtgt5_ValueChanged(object sender, EventArgs e)
        {
            txtgt6.Maximum = txtgt5.Value;
        }

        private void txtgt6_ValueChanged(object sender, EventArgs e)
        {
            txtgt7.Maximum = txtgt6.Value;
        }

        private void txtgt7_ValueChanged(object sender, EventArgs e)
        {
            txtgt8.Maximum = txtgt7.Value;
        }

        private void txtgt8_ValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        //室外温度限定条件
        #region
        private void numot1_ValueChanged(object sender, EventArgs e)
        {
          //  numot2.Minimum = numot1.Value;
        }

        private void numot2_ValueChanged(object sender, EventArgs e)
        {
          //  numot3.Minimum = numot2.Value;
        }

        private void numot3_ValueChanged(object sender, EventArgs e)
        {
          //  numot4.Minimum = numot3.Value;
        }

        private void numot4_ValueChanged(object sender, EventArgs e)
        {
         //   numot5.Minimum = numot4.Value;
        }

        private void numot5_ValueChanged(object sender, EventArgs e)
        {
          //  numot6.Minimum = numot5.Value;
        }

        private void numot6_ValueChanged(object sender, EventArgs e)
        {
         //   numot7.Minimum = numot6.Value;
        }

        private void numot7_ValueChanged(object sender, EventArgs e)
        {
         //   numot8.Minimum = numot7.Value;
        }

        private void numot8_ValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion
        //压差修正
        #region
        private void nump1_ValueChanged(object sender, EventArgs e)
        {
           // nump2.Minimum = nump1.Value;
        }

        private void nump2_ValueChanged(object sender, EventArgs e)
        {
          //  nump3.Minimum = nump2.Value;
        }

        private void nump3_ValueChanged(object sender, EventArgs e)
        {
           // nump4.Minimum = nump3.Value;
        }

        private void nump4_ValueChanged(object sender, EventArgs e)
        {
          //  nump5.Minimum = nump4.Value;
        }

        private void nump5_ValueChanged(object sender, EventArgs e)
        {
         //   nump6.Minimum = nump5.Value;
        }

        private void nump6_ValueChanged(object sender, EventArgs e)
        {
          //  nump7.Minimum = nump6.Value;
        }

        private void nump7_ValueChanged(object sender, EventArgs e)
        {
          //  nump8.Minimum = nump7.Value;
        }

        private void nump8_ValueChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        //供温模是更改
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                numsv.Enabled = false;
                groupBox2.Enabled = true;
                button10.Enabled = true;
            }
            else
            {
                numsv.Enabled = true;
                groupBox2.Enabled =false;
                button10.Enabled = false;
            }
        }
        //补水泵模式更改
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                groupBox9.Enabled = true;
                groupBox10.Enabled = false;
            }
            else
            {
                groupBox9.Enabled = false;
                groupBox10.Enabled = true;
            }
        }

        //操作记录查询
        #region
        private void load_operate()
        {
            string sql = "select DeviceID,StationName from vDeviceGR  where [Deleted]=0 order by [DeviceID]";
            DataTable dt = Tool.DB.getDt(sql);
            DataTable dt2 =new DataTable();
            dt2=dt.Clone();
            dt2.Rows.Add();
            dt2.Rows[0]["DeviceID"]=-1;
            dt2.Rows[0]["StationName"]="全部";
            for(int i=0;i<dt.Rows.Count;i++)
            {
                dt2.Rows.Add(dt.Rows[i].ItemArray);
            }
            comboBox3.DataSource = dt2;
            comboBox3.DisplayMember = "StationName";
            comboBox3.ValueMember = "DeviceID";
            comboBox3.SelectedIndex = 0;
        }
        //切换更新
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker4.Value = DateTime.Now;
            dateTimePicker3.Value = dateTimePicker4.Value.AddDays(-1);
        }
        
        //查询
        private void button12_Click(object sender, EventArgs e)
        {
            string sql = "SELECT [OperateID] as [操作编号],[UserName] as [操作员],[StationName] as [站点名称],[DT] as [操作时间],[Operate] as [执行操作] FROM [vOperate] where [DT]>='" + dateTimePicker3.Value.ToString() + "' and [DT]<='" + dateTimePicker4.Value.ToString() + "'";
            if((int)comboBox3.SelectedValue!=-1)
            {
                sql += " and DeviceID= " + comboBox3.SelectedValue.ToString();
            }
            int[] dgv_columnswith ={70,100,120,140,200} ;
            DataTable dt = Tool.DB.getDt(sql);
            dataGridView3.DataSource = dt;
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                dataGridView3.Columns[i].Width = dgv_columnswith[i];
            }
        }
        //导出
        private void button11_Click(object sender, EventArgs e)
        {
            Tool.Export.saveAs(dataGridView3,  " " + dateTimePicker3.Value.ToString() + "至" + dateTimePicker4.Value.ToString() + "操作记录");
        }
        #endregion

        //温度修正
        #region
        //室外温度修正
        private void numk_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToDecimal(txtot.Text) * numk.Value + numb.Value).ToString("0.0");
        }
        private void numb_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToDecimal(txtot.Text) * numk.Value + numb.Value).ToString("0.0");
        }
        //一次供温修正
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (Convert.ToDecimal(txtOneGT.Text) * numericUpDown1.Value + numericUpDown2.Value).ToString("0.0");
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = (Convert.ToDecimal(txtOneGT.Text) * numericUpDown1.Value + numericUpDown2.Value).ToString("0.0");
        }
        //一次回温修正
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToDecimal(txtOneBT.Text) * numericUpDown3.Value + numericUpDown4.Value).ToString("0.0");
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToDecimal(txtOneBT.Text) * numericUpDown3.Value + numericUpDown4.Value).ToString("0.0");
        }
        //二次供温修正
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = (Convert.ToDecimal(txtTwoGT.Text) * numericUpDown5.Value + numericUpDown6.Value).ToString("0.0");
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            textBox4.Text = (Convert.ToDecimal(txtTwoGT.Text) * numericUpDown5.Value + numericUpDown6.Value).ToString("0.0");
        }
        //二次回温修正
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = (Convert.ToDecimal(txtTwoBT.Text) * numericUpDown7.Value + numericUpDown8.Value).ToString("0.0");
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = (Convert.ToDecimal(txtTwoBT.Text) * numericUpDown7.Value + numericUpDown8.Value).ToString("0.0");
        }
        #endregion

        //未连接禁止选择
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    return;
                }
                if (dataGridView1.CurrentRow.Cells["iscon"].Value.ToString() == "未连接")
                {
                    dataGridView1.CurrentRow.Cells["select"].Value = false;
                }
                dataGridView1.RefreshEdit();
            }
        }
        //未连接禁止选择
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dataGridView1.IsCurrentCellDirty) //有未提交的更//改
            {
                this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

        }


    }   
}
