using System;
using System.Data;
using System.Windows.Forms;


namespace SocketServer
{
    public partial class main : Form
    {            
        public main()
        {
            InitializeComponent();
        }      

        //界面功能
        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            Form f = new login();
            if (f.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
            this.notifyIcon1.Visible = true;
            
            //窗体初始化
            from_ini();
            //加载站点菜单
            LoadTreeNodes();
        }
        //界面的初始化
        private void from_ini()
        {
            pictureBox6.Parent = pictureBox7;
            toolStrip1.Parent = pictureBox7;
            toolStrip1.Location = new System.Drawing.Point(this.Width - toolStrip1.Width + 2, 0);
            label6.Parent = pictureBox7;
            label10.Parent = pictureBox7;
            label11.Parent = pictureBox7;
            label12.Parent = pictureBox7;
            
            pictureBox6_DoubleClick(null, null);
        }
        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确定要退出程序吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                notifyIcon1.Visible = false;
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
        }



        #endregion

        //功能菜单
        #region
        //检测子窗体是否运行
        private bool checkChildFrmExist(string childFrmText)
        {
            try
            {
                foreach (Form childFrm in this.MdiChildren)
                {
                    if (childFrm.Text == childFrmText)
                    {
                        if (childFrm.WindowState == FormWindowState.Minimized)
                            childFrm.WindowState = FormWindowState.Maximized;
                        childFrm.Show();
                        childFrm.Activate();
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                MessageBox.Show("程序导入错误,请重新启动程序!");
                return false;
            }
        }
        //背景
        private void show_background()
        {
            if (this.checkChildFrmExist("背景") == true)
            {
                return;
            }
            Form f = new background();
            f.Text = "背景";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        //地理信息
        private void show_dili()
        {
            if (this.checkChildFrmExist("管网图") == true)
            {
                return;
            }
            Form f = new Form();
            f = new branch();
            f.Text = "管网图";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();

        }
        //参数设置
        private void show_guanwang()
        {
            if (this.checkChildFrmExist("参数设置") == true)
            {
                return;
            }
            Form f = new Form();
            f = new SetValue();
            f.Text = "参数设置";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();

        }
        //供热系统
        private void show_gongre()
        {
            if (this.checkChildFrmExist("供热系统") == true)
            {
                return;
            }
            Form f = new Form();
            f = new rz.rz_main();
            f.Text = "供热系统";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        //巡更系统
        private void show_xungeng()
        {
            if (this.checkChildFrmExist("巡更系统") == true)
            {
                return;
            }
            Form f = new Form();
            f = new xg.xg_main();
            f.Text = "巡更系统";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        //曲线
        private void show_line()
        {
            if (this.checkChildFrmExist("曲线分析") == true)
            {
                return;
            }
            Form f = new Form();
            f = new curve();
            f.Text = "曲线分析";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        //系统管理
        private void show_system()
        {
            if (Tool.UersCheck.UserName=="Guest")
            {
                MessageBox.Show("权限不足！请用管理员权限登录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.checkChildFrmExist("系统管理") == true)
            {
                return;
            }
            Form f = new systemmanage();
            f.Text = "系统管理";
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        //背景
        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            show_background();
        }
        //地理信息
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            show_dili();
        }
        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {
            show_dili();
        }
        //管网示意
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            show_guanwang();
        }
        private void toolStripDropDownButton5_Click(object sender, EventArgs e)
        {
            show_guanwang();
        }
        //供热系统
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            show_gongre();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            show_gongre();
        }
        //巡更系统
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            show_xungeng();
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            show_xungeng();
        }
        //曲线
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            show_line();
        }
        private void toolStripDropDownButton6_Click(object sender, EventArgs e)
        {
            show_line();
        }
        //系统管理
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            show_system();
        }      
        private void toolStripDropDownButton7_Click(object sender, EventArgs e)
        {
            show_system();
        }


        #endregion

        //窗口移动
        #region move
        private System.Drawing.Point mousePosition;
        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mousePosition.X = e.X;
                this.mousePosition.Y = e.Y;
            }
        }
        private void pictureBox7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - mousePosition.Y;
                this.Left = Control.MousePosition.X - mousePosition.X;
            }
        }

        //模拟系统最大小化和关闭按钮
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Maximized;
            //}         
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //树形结构选择显示的站点
        #region
        private void LoadTreeNodes()
        {
            string sql = "select GroupName from tblGroup  where [Deleted]=0 order by GroupID";
            DataTable dt = Tool.DB.getDt(sql);
            if (dt == null)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode(dt.Rows[i]["GroupName"].ToString());
                treeView1.Nodes.Add(tn);
                LoadTreeNodes2(tn);
            }
            treeView1.ExpandAll();
        }
        private void LoadTreeNodes2(TreeNode tn)
        {
            string sql = "select StationName,DeviceID from vDeviceGR where [Deleted]=0 and GroupName= '" + tn.Text + "'";
            DataTable dt = Tool.DB.getDt(sql);
            if (dt == null)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn1 = new TreeNode(dt.Rows[i]["StationName"].ToString());
                tn1.Tag = dt.Rows[i]["DeviceID"].ToString();
                tn.Nodes.Add(tn1);
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //数据按站DeviceID定时刷新
            if (treeView1.SelectedNode.Tag != null)
            {
                rz_flowchart.ID = Convert.ToInt32(treeView1.SelectedNode.Tag);
            }
            else
            {
                return;
            }

            if (this.checkChildFrmExist("流程图") == true)
            {
                return;
            }
            Form f = new rz_flowchart();
            f.MdiParent = this;
            f.Text = "流程图";
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                treeView1.SelectedNode = treeView1.TopNode;
            }
        }
        #endregion

        //系统托盘及报警
        #region
        //托盘图标单击
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            int alarm_Count = -1;
            string alarm_string = "";
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[i]._Data._alarm._all == Tool.xd100x.GRAlarm.有)
                {
                    alarm_Count++;
                    alarm_string += Tool.xd100x._XD100xBuffer[i]._Info._name + Environment.NewLine;
                }
            }

            if (alarm_Count == -1)
            {
                alarm_string = "无报警信息，所有机组运行正常！";
                this.notifyIcon1.ShowBalloonTip(1000, "提示", alarm_string, ToolTipIcon.Info);
            }
            else
            {
                alarm_Count++;
                alarm_string += "共计有 " + alarm_Count.ToString() + " 套机组报警！";
                this.notifyIcon1.ShowBalloonTip(1000, "警告！", alarm_string, ToolTipIcon.Warning);
            } 
        }
        //托盘图标双击
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        //显示报警提示
        private void timer4_Tick(object sender, EventArgs e)
        {
            label11.Text = Tool.UersCheck.UserName;
            if (自动显示报警ToolStripMenuItem.Checked == false)
            {
                return;
            }
            int alarm_Count = -1;
            string alarm_string = "";
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                if (Tool.xd100x._XD100xBuffer[i]._Data._alarm._all == Tool.xd100x.GRAlarm.有)
                {
                    alarm_Count++;
                    alarm_string += Tool.xd100x._XD100xBuffer[i]._Info._name + Environment.NewLine;
                }
            }

            if (alarm_Count == -1)
            {
                return;
            }
            else
            {
                alarm_Count++;
                alarm_string +=  "共计有 " + alarm_Count.ToString() + " 套机组报警！";
                this.notifyIcon1.ShowBalloonTip(1000, "警告！", alarm_string, ToolTipIcon.Warning);
            } 
        }
        //报警提示开关 鼠标右击
        private void 自动显示报警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动显示报警ToolStripMenuItem.Checked == false)
            {
                自动显示报警ToolStripMenuItem.Checked = true;
                return;
            }
            if (自动显示报警ToolStripMenuItem.Checked == true)
            {
                自动显示报警ToolStripMenuItem.Checked = false;
                return;
            }
        }
        #endregion

        private void label12_Click(object sender, EventArgs e)
        {
            Form f1 = new message();
            f1.Show();
        }








    }
}

