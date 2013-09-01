using System;
using System.Windows.Forms;
using System.Xml;

namespace SocketServer
{
    public partial class systemmanage : Form
    {
        public systemmanage()
        {
            InitializeComponent();
        }

        private void systemmanage_Load(object sender, EventArgs e)
        {
            //站点管理相关
            load_station();
            //控制器管理
            load_xd100x();
            //巡更模块管理
            load_xd300();
            //分组管理
            load_group();
            //巡更卡管理
            load_card();
        }

        private void loadg(ComboBox c)
        {
            string sql = "SELECT [GroupID],[GroupName] FROM [tblGroup]  where [Deleted]=0";
            c.DataSource = Tool.DB.getDt(sql);
            c.DisplayMember = "GroupName";
            c.ValueMember = "GroupID";
        }

        private void loads(ComboBox c)
        {
            string sql = "SELECT  [StationID],[StationName] FROM [tblStation] where [Deleted]=0 order by [StationID]";
            c.DataSource = Tool.DB.getDt(sql);
            c.DisplayMember = "StationName";
            c.ValueMember = "StationID";
        }

        //站点管理
        #region
        private void load_station()
        {
            string sql = "SELECT  [StationID] as [站点标识], [StationName] as [站点名称],[GroupName] as [所属分组], [IPAddress] as [IP地址],[locationx] as [X坐标],[locationy] as [Y坐标], [Remark] as [备注] FROM [vStation] where [Deleted]=0";
            dataGridView2.DataSource = Tool.DB.getDt(sql);
            groupBox9.Visible = false;
        }
        //添加
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadg(comboBox2);          
            groupBox9.Text = "添加";
            textBox2.Text = "";
            textBox10.Text = "";
            comboBox2.Text = "";
            textBox12.Text = "";
            groupBox9.Visible = true;
        }
        //修改
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            groupBox9.Text = "修改";
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }
            loadg(comboBox2);

            int row = dataGridView2.CurrentRow.Index;
            textBox2.Text = dataGridView2["站点名称", row].Value.ToString();
            textBox10.Text = dataGridView2["IP地址", row].Value.ToString();
            comboBox2.Text = dataGridView2["所属分组", row].Value.ToString();
            numericUpDown8.Value = Convert.ToDecimal(dataGridView2["X坐标", row].Value.ToString());
            numericUpDown5.Value = Convert.ToDecimal(dataGridView2["Y坐标", row].Value.ToString());
            textBox12.Text = dataGridView2["备注", row].Value.ToString();
            groupBox9.Visible = true;
        }
        //删除
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定删除站点：" + dataGridView2["站点名称", dataGridView2.CurrentCell.RowIndex].Value.ToString() + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                string sql = "UPDATE [tblStation] SET [Deleted]=1 WHERE [StationID]=" + Convert.ToInt32(dataGridView2["站点标识", dataGridView2.CurrentCell.RowIndex].Value);
                Tool.DB.runCmd(sql);
                load_station();
            }        
        }
        //确定
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("站点名称不能为空！");
                return;
            }
            
            

            bool checkpass = checkdata();
            if (checkpass == true)
            {
                groupBox9.Visible = false;
                string sql = "";
                if (groupBox9.Text == "添加")
                {
                    sql = "INSERT INTO [tblStation]([StationName],[IPAddress], [GroupID],[locationx],[locationy],[lablex],[labley],  [Remark],[Deleted])" +
                           "VALUES('" + textBox2.Text + "','" + textBox10.Text + "',  '" + comboBox2.SelectedValue.ToString() + "'," + numericUpDown8.Value.ToString() + "," + numericUpDown5.Value.ToString() + "," + numericUpDown8.Value.ToString() + "," + numericUpDown5.Value.ToString() + ",  '" + textBox12.Text + "',0)";
                
                }
                
                if (groupBox9.Text == "修改")
                {
                    sql = "UPDATE [tblStation] SET [StationName]='" + textBox2.Text + "', [GroupID]='" + comboBox2.SelectedValue.ToString() + "', [IPAddress]='" + textBox10.Text + "',[locationx]=" + numericUpDown8.Value.ToString() + ",[locationy] =" + numericUpDown5.Value.ToString() + ",[lablex]=" + numericUpDown8.Value.ToString() + ",[labley] =" + numericUpDown5.Value.ToString() + " [Remark]='" + textBox12.Text + "' " +
                        " WHERE [StationID]=" + Convert.ToInt32(dataGridView2["站点标识", dataGridView2.CurrentCell.RowIndex].Value) + "";
                }
                Tool.DB.runCmd(sql);
                load_station();
            }
        }
        //取消
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox9.Visible = false;
        }
        #endregion

        //控制器管理
        #region
        private void load_xd100x()
        {
            string sta_dgv_sql = "SELECT [DeviceID] as [设备标识],[StationName] as [所属站点], [DeviceAddress] as [设备地址], [HeatArea] as [供热面积], [Cycle] as [采集周期], [Version] as [设备版本], [Remark] as [备注] FROM [vDeviceGR] WHERE [Deleted]=0";
            dataGridView3.DataSource = Tool.DB.getDt(sta_dgv_sql);
            comboBox4.Items.Clear();
            comboBox4.Items.Add("xd100");
            comboBox4.Items.Add("xd100n");
            
            groupBox4.Visible = false;
        }
        //添加
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            loads(comboBox1);
            groupBox4.Text = "添加";
            comboBox1.Text = "";
            comboBox4.Text = "xd100";
            numericUpDown4.Value = 1;
            numericUpDown6.Value = 1;
       //   numericUpDown7.Value = 1;
            numericUpDown3.Value = 10;
            textremark.Text = "";
            groupBox4.Visible = true;
            
        }
        //修改
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            groupBox4.Text = "修改";           
            if (dataGridView3.CurrentRow == null)
            {
                return;
            }
            loads(comboBox1);
            int row = dataGridView3.CurrentRow.Index;
            this.comboBox1.Text = dataGridView3["所属站点", row].Value.ToString();
            numericUpDown6.Value = Convert.ToDecimal(dataGridView3["供热面积", row].Value);
          //  numericUpDown7.Value = Convert.ToDecimal(dataGridView3["供热基准", row].Value);
            numericUpDown4.Value = Convert.ToInt16(dataGridView3["设备地址", row].Value);
            numericUpDown3.Value = Convert.ToInt16(dataGridView3["采集周期", row].Value);
            comboBox4.Text = dataGridView3["设备版本", row].Value.ToString();
            this.textremark.Text = dataGridView3["备注", row].Value.ToString();
            groupBox4.Visible = true;
        }
        //删除
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定删除设备：" + dataGridView3["设备标识", dataGridView3.CurrentCell.RowIndex].Value.ToString() + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                string sql = "UPDATE [tblDevice] SET [Deleted]=1 WHERE [DeviceID]=" + Convert.ToInt32(dataGridView3["设备标识", dataGridView3.CurrentCell.RowIndex].Value) + "";
                Tool.DB.runCmd(sql);
                load_xd100x();
            }
        }
        //添加修改的取消
        private void button4_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
        }
        //添加修改的确定
        private void button5_Click(object sender, EventArgs e)
        {
            bool checkpass = checkdata();
            if (checkpass == true)
            {
                groupBox4.Visible = false;
                string sql = "";
                if (groupBox4.Text == "添加")
                {
                    sql = "INSERT INTO [tblDevice]([StationID], [DeviceAddress], [Remark], [Cycle], [TimeOut], [RetryTimes],[Deleted],[DeviceType])" +
                           "VALUES(" + comboBox1.SelectedValue.ToString() + "," + numericUpDown4.Value.ToString() + ", '" + textremark.Text + "', " + numericUpDown3.Value + ",12,2,0,'xd100x')";
                    Tool.DB.runCmd(sql);
                    string DeviceID = Tool.DB.getStr("SELECT max([DeviceID]) FROM [tblDevice]");
                    sql = "INSERT INTO [tblDeviceGR]([DeviceID],[HeatArea],[Version])" +
                           "VALUES(" + DeviceID + "," + numericUpDown6.Value.ToString() + ",'" + comboBox4.Text + "')";
                    Tool.DB.runCmd(sql);
                }
                if (groupBox4.Text == "修改")
                {
                    sql = "UPDATE [tblDevice] SET [StationID]=" + comboBox1.SelectedValue.ToString() + ", [DeviceAddress]= " + numericUpDown4.Value.ToString() + ", [Remark]='" + textremark.Text + "', " +
                        "[Cycle]=" + numericUpDown3.Value + " WHERE [DeviceID]=" + Convert.ToInt32(dataGridView3["设备标识", dataGridView3.CurrentCell.RowIndex].Value) + "";
                    Tool.DB.runCmd(sql);
                    sql = "UPDATE [tblDeviceGR] SET [HeatArea]=" + numericUpDown6.Value.ToString() + ", [Version]='" + comboBox4.Text + "' WHERE [DeviceID]=" + Convert.ToInt32(dataGridView3["设备标识", dataGridView3.CurrentCell.RowIndex].Value) + "";
                    Tool.DB.runCmd(sql);
                }
                load_xd100x();
            }
        }
        //数据合法性判断
        private bool checkdata()
        {
            return true;
        }
        //新老版本验证地址
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox4.Text=="xd100")
            {
                numericUpDown4.Minimum = 0;
            }
            if (comboBox4.Text == "xd100n")
            {
                numericUpDown4.Minimum = 1;
            }
        }
        //修改全部采集周期
        private void button13_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [tblDevice] SET [Cycle]="+numericUpDown9.Value.ToString()+" where [DeviceType]='xd100x'" ;
            Tool.DB.runCmd(sql);
            load_xd100x();
        }
        #endregion

        //巡更模块管理
        #region
        private void load_xd300()
        {
            string sql = "SELECT [DeviceID] as [设备标识],[StationName] as [所属站点], [DeviceAddress] as [设备地址], [Cycle] as [采集周期], [Remark] as [备注] FROM [vDevice] WHERE [Deleted]=0 and [DeviceType]='xd300'";
            dataGridView1.DataSource = Tool.DB.getDt(sql);

        }
        //添加
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loads(comboBox3);
            groupBox1.Text = "添加";
            comboBox3.Text = "";
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 10;
            textBox1.Text = "";
            groupBox1.Visible = true;

        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "修改";          
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            loads(comboBox3);
            int row = dataGridView1.CurrentRow.Index;
            this.comboBox3.Text = dataGridView1["所属站点", row].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1["设备地址", row].Value);
            numericUpDown2.Value = Convert.ToDecimal(dataGridView1["采集周期", row].Value);
            textBox1.Text = dataGridView1["备注", row].Value.ToString();
            groupBox1.Visible = true;
        }
        //删除
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定删除设备：" + dataGridView1["设备标识", dataGridView1.CurrentCell.RowIndex].Value.ToString() + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                string sql = "UPDATE [tblDevice] SET [Deleted]=1 WHERE [DeviceID]=" + Convert.ToInt32(dataGridView1["设备标识", dataGridView1.CurrentCell.RowIndex].Value) + "";
                Tool.DB.runCmd(sql);
                load_xd300();
            }
        }
        //添加修改的取消
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
        //添加修改的确定
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            string sql = "";
            if (groupBox1.Text == "添加")
            {
                sql = "INSERT INTO [tblDevice]([StationID], [DeviceAddress], [Remark], [Cycle], [TimeOut], [RetryTimes],[Deleted],[DeviceType])" +
                       "VALUES(" + comboBox3.SelectedValue.ToString() + "," + numericUpDown1.Value.ToString() + ", '" + textBox1.Text + "', " + numericUpDown2.Value.ToString() + ",12,1,0,'xd300')";
                Tool.DB.runCmd(sql);
            }
            if (groupBox1.Text == "修改")
            {
                sql = "UPDATE [tblDevice] SET [StationID]=" + comboBox3.SelectedValue.ToString() +",[DeviceAddress]= " + numericUpDown1.Value.ToString() + ",[Remark]='" + textBox1.Text + 
                    "',[Cycle]=" + numericUpDown2.Value.ToString() + " WHERE [DeviceID]=" + Convert.ToInt32(dataGridView1["设备标识", dataGridView1.CurrentCell.RowIndex].Value) + "";
                Tool.DB.runCmd(sql);
            }
            load_xd300();
        }
        //修改全部采集周期
        private void button14_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [tblDevice] SET [Cycle]=" + numericUpDown10.Value.ToString() + " where [DeviceType]='xd300'";
            Tool.DB.runCmd(sql);
            load_xd300();
        }
        #endregion

        //分组管理
        #region
        private void load_group()
        {
            string sql = "SELECT [GroupID] as [分组标识],[GroupName] as [分组名称], [GroupLeader] as [负责人], [Contact] as [联系方式], [Remark] as [备注] FROM [tblGroup] where [Deleted]=0";
            dataGridView4.DataSource = Tool.DB.getDt(sql);
            groupBox3.Visible = false;
        }
        //添加
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            groupBox3.Text = "添加";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox15.Text = "";
            textBox5.Text = "";
            groupBox3.Visible = true;
        }
        //修改
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            groupBox3.Text = "修改";
            if (dataGridView4.CurrentRow == null)
            {
                return;
            }
            int row = dataGridView4.CurrentRow.Index;
            textBox3.Text = dataGridView4["分组名称", row].Value.ToString();
            textBox4.Text = dataGridView4["负责人", row].Value.ToString();
            textBox15.Text = dataGridView4["联系方式", row].Value.ToString();
            textBox5.Text = dataGridView4["备注", row].Value.ToString();
            groupBox3.Visible = true;
        }
        //删除
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow == null)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定删除分组：" + dataGridView4["分组标识", dataGridView4.CurrentCell.RowIndex].Value.ToString() + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                string sql = "UPDATE [tblGroup] SET [Deleted]=1 WHERE [GroupID]=" + Convert.ToInt32(dataGridView4["分组标识", dataGridView4.CurrentCell.RowIndex].Value) + "";
                Tool.DB.runCmd(sql);
                load_group();
            }
        }
        //添加修改的取消
        private void button5_Click_1(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }
        //添加修改的确定
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            string sql = "";
            if (groupBox3.Text == "添加")
            {
                sql = "INSERT INTO [tblGroup]([GroupName], [GroupLeader], [Contact], [Remark],[Deleted])" +
                       "VALUES('" + textBox3.Text + "','" + textBox4.Text + "', '" + textBox15.Text + "', '" + textBox5.Text + "',0)";
                Tool.DB.runCmd(sql);
            }
            if (groupBox3.Text == "修改")
            {
                sql = "UPDATE [tblGroup] SET [GroupName]='" + textBox3.Text + "',[GroupLeader]= '" + textBox4.Text + "',[Contact]='" + textBox5.Text+" ',[Remark]='" + textBox5.Text+"'"+
                     " WHERE [GroupID]=" + Convert.ToInt32(dataGridView4["分组标识", dataGridView4.CurrentCell.RowIndex].Value) + "";
                Tool.DB.runCmd(sql);
            }
            load_group();
        }
        #endregion

        //TM卡管理
        #region
        private void load_card()
        {
            string sql = "SELECT  [CardID] as [卡标识], [GroupName] as [所属分组], [CardSN] as [卡号],[Person] as [人名], [Remark] as [备注] FROM [vCard]";
            dataGridView5.DataSource = Tool.DB.getDt(sql);
            dataGridView5.Columns["卡号"].Width = 150;
            sql = "SELECT [GroupID],[GroupName] FROM [tblGroup]";
            comboBox6.DataSource = Tool.DB.getDt(sql);
            comboBox6.DisplayMember = "GroupName";
            comboBox6.ValueMember = "GroupID";
            groupBox5.Visible = false;
        }
        //添加
        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            groupBox5.Text = "添加";
            textBox11.Text = "";
            textBox13.Text = "";
            comboBox6.Text = "";
            textBox14.Text = "";
            groupBox5.Visible = true;
        }
        //修改
        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            groupBox5.Text = "修改";
            if (dataGridView5.CurrentRow == null)
            {
                return;
            }
            int row = dataGridView5.CurrentRow.Index;
            textBox11.Text = dataGridView5["卡号", row].Value.ToString();
            textBox13.Text = dataGridView5["人名", row].Value.ToString();
            comboBox6.Text = dataGridView5["所属分组", row].Value.ToString();
            textBox14.Text = dataGridView5["备注", row].Value.ToString();
            groupBox5.Visible = true;
        }
        //删除
        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("确定删除卡：" + dataGridView5["卡标识", dataGridView5.CurrentCell.RowIndex].Value.ToString() + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                string sql = "DELETE FROM [tblCard]  WHERE [CardID]=" + Convert.ToInt32(dataGridView5["卡标识", dataGridView2.CurrentCell.RowIndex].Value);
                Tool.DB.runCmd(sql);
                load_card();
            }
        }
        //确定
        private void button10_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            string sql = "";
            if (groupBox5.Text == "添加")
            {
                sql = "INSERT INTO [tblCard]([CardSN],[Person], [GroupID],[Remark])" +
                       "VALUES('" + textBox11.Text + "','" + textBox13.Text + "',  '" + comboBox6.SelectedValue.ToString() + "',  '" + textBox15.Text + "')";
            }
            if (groupBox5.Text == "修改")
            {
                sql = "UPDATE [tblCard] SET [CardSN]='" + textBox11.Text + "', [GroupID]='" + comboBox6.SelectedValue.ToString() + "', [Person]='" + textBox13.Text + "', [Remark]='" + textBox14.Text + "' " +
                    " WHERE [CardID]=" + Convert.ToInt32(dataGridView5["卡标识", dataGridView5.CurrentCell.RowIndex].Value) + "";
            }
            Tool.DB.runCmd(sql);
            load_card();
        }
        //取消
        private void button9_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
        }
        #endregion

        //用户管理
        private void button12_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            string name = xDoc.DocumentElement.ChildNodes[0].Attributes.GetNamedItem("name").Value.Trim();
            string word = xDoc.DocumentElement.ChildNodes[0].Attributes.GetNamedItem("word").Value.Trim();

            if (textBox6.Text.Trim() == name && textBox16.Text.Trim() == word)
            {
                if (textBox17.Text.Trim() != textBox18.Text.Trim())
                {
                    MessageBox.Show("两次输入的新密码不相同！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    xDoc.DocumentElement.ChildNodes[0].Attributes.GetNamedItem("word").Value = textBox17.Text.Trim();
                    xDoc.Save("config.xml");
                    MessageBox.Show("新修改成功！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("旧密码不正确！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }

        }







    }
}
