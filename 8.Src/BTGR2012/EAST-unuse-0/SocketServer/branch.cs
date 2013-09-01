using System;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;//提供高级的二维和矢量图形功能 

namespace SocketServer
{
    public partial class branch : Form
    {
        public branch()
        {
            InitializeComponent();
        }

        private void branch_Load(object sender, EventArgs e)
        {
            point_load();
        }
        //测点分布
        #region

        //数据显示
        private System.Drawing.Point mousePosition;
        private string pointset = "00000";
        private Color linecolor = Color.White;
        private Color lablecolor = Color.White;
        private Point intpic;
        private int transparency;
        private bool datadisplay;

        //缩放
        private int picmultiple = 10;
        private int picstepx;
        private int picstepy;

        private void point_load()
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\qx.png");
            picstepx = (pictureBox2.Width - this.Width) / 10;
            picstepy = (pictureBox2.Height - this.Height) / 10;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            pointset = xDoc.DocumentElement.ChildNodes[3].Attributes.GetNamedItem("value").Value.Trim();
            lablecolor = ColorTranslator.FromHtml(xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("color").Value.Trim());
            transparency = Convert.ToInt32(xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("transparent").Value.Trim());
            linecolor = ColorTranslator.FromHtml(xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("line").Value.Trim());
            intpic.X = Convert.ToInt32(xDoc.DocumentElement.ChildNodes[5].Attributes.GetNamedItem("x").Value.Trim());
            intpic.Y = Convert.ToInt32(xDoc.DocumentElement.ChildNodes[5].Attributes.GetNamedItem("y").Value.Trim());
            datadisplay = Convert.ToBoolean(xDoc.DocumentElement.ChildNodes[5].Attributes.GetNamedItem("data").Value.Trim());


            groupBox3.Visible = false;

            checkedListBox3.Items.Clear();
            checkedListBox3.Items.Add("时间");
            checkedListBox3.Items.Add("一次供温");
            checkedListBox3.Items.Add("一次回温");
            checkedListBox3.Items.Add("一次供压");
            checkedListBox3.Items.Add("一次回压");
            checkedListBox3.Items.Add("一次流量");
            checkedListBox3.Items.Add("阀位反馈");

            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (pointset.Substring(i, 1) == "1")
                {
                    checkedListBox3.SetItemChecked(i, true);
                }
            }

            pictureBox2.Location = intpic;

            panel16.BackColor = lablecolor;
            panel18.BackColor = linecolor;
            trackBar1.Value = transparency;
            label32.Text = trackBar1.Value.ToString() + "%";
            checkBox1.Checked = datadisplay;
            lable_ini(pictureBox2, lablecolor, transparency);

            timer2.Interval = 5000;
            timer2.Enabled = true;

        }

        // 拖动图片
        int mouseX;
        int mouseY;
        int picX;
        int picY;

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = Cursor.Position.X;
            mouseY = Cursor.Position.Y;
            picX = this.pictureBox2.Left;
            picY = this.pictureBox2.Top;
            pictureBox2.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int y = Cursor.Position.Y - mouseY + picY;
            int x = Cursor.Position.X - mouseX + picX;
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox2.Top = y;
                this.pictureBox2.Left = x;
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Cursor = Cursors.Default;
            if (this.pictureBox2.Location.X > 0)
            {
                this.pictureBox2.Left = 0;
            }
            if (this.pictureBox2.Location.Y > 0)
            {
                this.pictureBox2.Top = 0;
            }
            if (this.pictureBox2.Location.X < panel13.Width - pictureBox2.Width)
            {
                this.pictureBox2.Left = panel13.Width - pictureBox2.Width;
            }
            if (this.pictureBox2.Location.Y < panel13.Height - pictureBox2.Height)
            {
                this.pictureBox2.Top = panel13.Height - pictureBox2.Height;
            }
        }

        private void lable_ini(Control parent, Color color, int transparent)
        {
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                int lx = Tool.xd100x._XD100xBuffer[i]._Info.lablex;
                int ly = Tool.xd100x._XD100xBuffer[i]._Info.labley;

                //画标注
                System.Windows.Forms.Label info = new System.Windows.Forms.Label();
                info.AutoSize = true;
                info.BackColor = System.Drawing.Color.FromArgb((100 - transparent) * 255 / 100, color);//说明：1-（128/255）=1-0.5=0.5 透明度为0.5，即50%

                info.Parent = parent;
                info.Location = new System.Drawing.Point(lx, ly);
                info.Name = "info" + Tool.xd100x._XD100xBuffer[i]._Info._id.ToString();
                info.MouseDown += new MouseEventHandler(info_MouseDown);
                info.MouseMove += new MouseEventHandler(info_MouseMove);
                info.MouseUp += new MouseEventHandler(info_MouseUp);
                info.Resize += new EventHandler(info_Resize);
                info.Show();
            }
        }

        private void info_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.Cursor = Cursors.Default;
        }

        private void info_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control Ctrl = (sender as Control);
                mousePosition.Y = e.Y;
                mousePosition.X = e.X;
                pictureBox2.Cursor = Cursors.Hand;
            }
        }

        private void info_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control Ctrl = (sender as Control);
                Ctrl.Top += e.Y - mousePosition.Y;
                Ctrl.Left += e.X - mousePosition.X;

                for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
                {
                    if (Ctrl.Name == "info" + Tool.xd100x._XD100xBuffer[i]._Info._id.ToString())
                    {
                        Tool.xd100x._XD100xBuffer[i]._Info.lablex = Ctrl.Left;
                        Tool.xd100x._XD100xBuffer[i]._Info.labley = Ctrl.Top;
                    }
                }
                Ctrl.Parent.Refresh();
            }
        }

        private void info_Resize(object sender, EventArgs e)
        {
            Control Ctrl = (sender as Control);
            Ctrl.Parent.Refresh();
        }
        //标签内容显示
        private void pinstring(Control parent, int busfferlistID, string set)
        {
            string labletext = Tool.xd100x._XD100xBuffer[busfferlistID]._Info._name + Environment.NewLine;

            if (set.Substring(0, 1) == "1")
            {
                labletext += "时间: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._dt.ToString("yyyy-MM-dd") + Environment.NewLine
                    + "      " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._dt.ToString("HH:mm:ss") + Environment.NewLine;
            }
            if (set.Substring(1, 1) == "1")
            {
                labletext += "一次供温: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GT1.ToString("0.0") + " ℃" + Environment.NewLine;
            }
            if (set.Substring(2, 1) == "1")
            {
                labletext += "一次回温: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BT1.ToString("0.0") + " ℃" + Environment.NewLine;
            }
            if (set.Substring(3, 1) == "1")
            {
                labletext += "一次供压: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._GP2.ToString("0.00") + " MPa" + Environment.NewLine;
            }
            if (set.Substring(4, 1) == "1")
            {
                labletext += "一次回压: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._BP2.ToString("0.00") + " MPa" + Environment.NewLine;
            }
            if (set.Substring(5, 1) == "1")
            {
                labletext += "一次流量: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._WI1.ToString("0.00") + " m3/h" + Environment.NewLine;
            }
            if (set.Substring(6, 1) == "1")
            {
                labletext += "阀位反馈: " + Tool.xd100x._XD100xBuffer[busfferlistID]._Data._OD.ToString("0.00") + " %";
            }
            foreach (Control cs in parent.Controls)
            {
                if (cs is System.Windows.Forms.Label && cs.Name == "info" + Tool.xd100x._XD100xBuffer[busfferlistID]._Info._id.ToString())
                {
                    cs.Text = labletext;
                }
            }
        }


        //定时更新测点分布数据
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (datadisplay && picmultiple == 10)
            {
                for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
                {
                    pinstring(pictureBox2, i, pointset);
                }
            }
        }
        //画标注线
        private void Graphics(Control parent, Color color)
        {
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                int px = Tool.xd100x._XD100xBuffer[i]._Info.locationx;
                int py = Tool.xd100x._XD100xBuffer[i]._Info.locationy;
                int lx = Tool.xd100x._XD100xBuffer[i]._Info.lablex;
                int ly = Tool.xd100x._XD100xBuffer[i]._Info.labley;

                Graphics g = parent.CreateGraphics();

                Control info = new Control();
                foreach (Control cs in parent.Controls)
                {
                    if (cs is System.Windows.Forms.Label && cs.Name == "info" + Tool.xd100x._XD100xBuffer[i]._Info._id.ToString())
                    {
                        info = cs;
                    }
                }
                ////画lable的虚线框
                //Pen ftqGoal = new Pen(Color.Black, 2);
                //ftqGoal.DashStyle = DashStyle.Dot;
                //g.DrawLine(ftqGoal, lx,ly,lx+info.Width,ly);
                //g.DrawLine(ftqGoal, lx + info.Width, ly, lx + info.Width, ly+info.Height);
                //g.DrawLine(ftqGoal, lx, ly + info.Height, lx + info.Width, ly + info.Height);
                //g.DrawLine(ftqGoal, lx, ly + info.Height, lx, ly);

                //画连接线
                Pen p = new Pen(color);
                p.Width = 2;

                Point p1 = new Point(px, py);

                //lable在测点右侧
                if (lx > px)
                {
                    Point p2 = new Point(px + (lx - px) / 2, ly + info.Height * 2 / 3);
                    g.DrawLine(p, p1, p2);
                    Point p3 = new Point(lx, ly + info.Height * 2 / 3);
                    g.DrawLine(p, p2, p3);

                    Point p4 = new Point(lx, ly);
                    Point p5 = new Point(lx, ly + info.Height);
                    p.Width = 4;
                    g.DrawLine(p, p4, p5);

                }
                //lable在侧点正上方或下方
                if (lx <= px && lx >= px - info.Width)
                {
                    //上方
                    if (ly + info.Height <= py)
                    {
                        Point p6 = new Point(lx, ly + info.Height);
                        Point p7 = new Point(lx + info.Width, ly + info.Height);
                        p.Width = 4;
                        g.DrawLine(p, p6, p7);

                        Point p8 = new Point(px, ly + info.Height);
                        p.Width = 2;
                        g.DrawLine(p, p1, p8);
                    }
                    //下方
                    if (ly + info.Height > py)
                    {
                        Point p13 = new Point(lx, ly);
                        Point p14 = new Point(lx + info.Width, ly);
                        p.Width = 4;
                        g.DrawLine(p, p13, p14);
                        Point p15 = new Point(px, ly);
                        p.Width = 2;
                        g.DrawLine(p, p1, p15);
                    }
                }
                //lable在测点左侧
                if (lx < px - info.Width)
                {
                    Point p9 = new Point(px - (px - lx - info.Width) / 2, ly + info.Height * 2 / 3);
                    g.DrawLine(p, p1, p9);
                    Point p10 = new Point(lx + info.Width, ly + info.Height * 2 / 3);
                    g.DrawLine(p, p9, p10);
                    Point p11 = new Point(lx + info.Width, ly);
                    Point p12 = new Point(lx + info.Width, ly + info.Height);
                    p.Width = 4;
                    g.DrawLine(p, p11, p12);

                }

                //画测点方形带边框
                //Rectangle myTabRect = new Rectangle();
                //myTabRect.Offset(px - 4, py - 4);
                //myTabRect.Width = 8;
                //myTabRect.Height = 8;
                //p.Color = Color.Red;
                //p.Width = 2;
                //g.DrawRectangle(p, myTabRect);
                //Brush b = new SolidBrush(Color.Red);
                //g.FillRectangle(b, myTabRect);
            }
        }
        //连线和测点刷新
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            //if (datadisplay && picmultiple == 10)
            //{
            //    Graphics(pictureBox2, linecolor);
            //}
        }
        //更改该测点信息　选回
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                foreach (Control cs in pictureBox2.Controls)
                {
                    if (cs is System.Windows.Forms.Label && cs.Name == "info" + Tool.xd100x._XD100xBuffer[i]._Info._id.ToString())
                    {
                        int lx = Tool.xd100x._XD100xBuffer[i]._Info.lablex;
                        int ly = Tool.xd100x._XD100xBuffer[i]._Info.labley;
                        cs.Location = new System.Drawing.Point(lx, ly);
                    }
                }

            }
        }
        //标注背景颜色
        private void panel16_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog2 = new System.Windows.Forms.ColorDialog();
            colorDialog2.ShowDialog();
            panel16.BackColor = colorDialog2.Color;
        }
        //透明度
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label32.Text = trackBar1.Value.ToString() + "%";
        }
        //保存屏幕注释位置
        private void Save_lable(int id, int x, int y)
        {
            string sql = "select [StationID] from [vDeviceGR] where DeviceID = " + id.ToString();
            string stationid = Tool.DB.getStr(sql);
            sql = "UPDATE [tblStation] SET [lablex] = " + x.ToString() + ",[labley] = " + y.ToString() + " WHERE [StationID]=" + stationid;
            Tool.DB.getStr(sql);
        }

        //连线颜色
        private void panel18_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog2 = new System.Windows.Forms.ColorDialog();
            colorDialog2.ShowDialog();
            panel18.BackColor = colorDialog2.Color;
        }
        #endregion

        //高级
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == true)
            {
                groupBox3.Visible = false;
                return;
            }
            else
            {
                groupBox3.Visible = true;
            }
        }

        //保存设置
        private void button24_Click(object sender, EventArgs e)
        {
            transparency = trackBar1.Value;
            datadisplay = checkBox1.Checked;
            linecolor = panel18.BackColor;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("config.xml");
            xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("color").Value = ColorTranslator.ToHtml(panel16.BackColor);
            xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("transparent").Value = transparency.ToString();
            xDoc.DocumentElement.ChildNodes[4].Attributes.GetNamedItem("line").Value = ColorTranslator.ToHtml(panel18.BackColor);
            xDoc.DocumentElement.ChildNodes[5].Attributes.GetNamedItem("data").Value = datadisplay.ToString();
            pointset = "";
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                if (checkedListBox3.GetItemCheckState(i) == CheckState.Checked)
                {
                    pointset += "1";
                }
                else
                {
                    pointset += "0";
                }
            }
            xDoc.DocumentElement.ChildNodes[3].Attributes.GetNamedItem("value").Value = pointset;
            xDoc.Save("config.xml");

            foreach (Control cs in pictureBox2.Controls)
            {
                if (cs is System.Windows.Forms.Label && cs.Name.Substring(0, 4) == "info")
                {
                    cs.BackColor = System.Drawing.Color.FromArgb((100 - transparency) * 255 / 100, panel16.BackColor);
                    cs.Visible = checkBox1.Checked;
                }
            }
            //保存桌面上标签位置
            if (checkBox4.Checked == true)
            {
                for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
                {
                    Save_lable(Tool.xd100x._XD100xBuffer[i]._Info._id, Tool.xd100x._XD100xBuffer[i]._Info.lablex, Tool.xd100x._XD100xBuffer[i]._Info.labley);
                }
            }

            groupBox3.Visible = false;
            pictureBox2.Refresh();
        }
        //高级取消
        private void button1_Click_1(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }
        //缩略图
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            datadisplay = false;
            picmultiple = 0;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Size = new Size(this.Width, this.Height);
            pictureBox2.Location = new Point(0, 0);
            foreach (Control cs in pictureBox2.Controls)
            {
                if (cs is System.Windows.Forms.Label)
                {
                    cs.Visible = false;
                }
            }
        }
        //原图
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            picmultiple = 10;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.Location = intpic;
            if (datadisplay)
            {
                foreach (Control cs in pictureBox2.Controls)
                {
                    if (cs is System.Windows.Forms.Label)
                    {
                        cs.Visible = true;
                    }
                }
            }
        }
        //放大
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            picmultiple++;
            if (picmultiple > 10)
            {
                picmultiple = 10;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                if (datadisplay)
                {
                    foreach (Control cs in pictureBox2.Controls)
                    {
                        if (cs is System.Windows.Forms.Label)
                        {
                            cs.Visible = true;
                        }
                    }
                }
                return;
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Size = new Size(pictureBox2.Width + picstepx, pictureBox2.Height + picstepy);
            pictureBox2.Location = new Point(pictureBox2.Location.X - (this.Width / 2 - pictureBox2.Location.X) * picstepx / (pictureBox2.Width - picstepx), pictureBox2.Location.Y - (this.Height / 2 - pictureBox2.Location.Y) * picstepy / (pictureBox2.Height - picstepy));

        }
        //缩小
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (datadisplay && picmultiple == 10)
            {
                foreach (Control cs in pictureBox2.Controls)
                {
                    if (cs is System.Windows.Forms.Label)
                    {
                        cs.Visible = false;
                    }
                }
            }
            picmultiple--;
            if (picmultiple < 0)
            {
                picmultiple = 0;
                return;
            }
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Size = new Size(pictureBox2.Width - picstepx, pictureBox2.Height - picstepy);
            pictureBox2.Location = new Point(pictureBox2.Location.X + (this.Width / 2 - pictureBox2.Location.X) * picstepx / (pictureBox2.Width + picstepx), pictureBox2.Location.Y + (this.Height / 2 - pictureBox2.Location.Y) * picstepy / (pictureBox2.Height + picstepy));

        }

    }
}
