using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class messagebox : Form
    {
        public messagebox(int DeviceID)
        {
            InitializeComponent();

            listID = DeviceID;
            scount = Tool.xd100x._XD100xBuffer[listID]._Info._timeout * Tool.xd100x._XD100xBuffer[listID]._Info._retrytimes;
            timer1.Interval=1000;
            timer2.Interval = 200;
            lasttime = Tool.xd100x._XD100xBuffer[listID]._Data._dt;

            Tool.Gprs.GprsList gl = Tool.Gprs.Get_GprsList(Tool.xd100x._XD100xBuffer[listID]._Info._ip);
            if (gl._Iscon == false)
            {
                label1.Text="该站点不在线！";
                timer2.Enabled = true;
                return;
            }
            if (gl._Isbusy == true)
            {
                label1.Text="该站点正在通讯！";
                timer2.Enabled = true;
                return;
            }
            Tool.xd100x._XD100xBuffer[listID]._Command[0]._onoff = true;
            label1.Text = "成功添加采集任务，任务执行中请等待......";
            timer1.Enabled = true;
        }

        private int listID=-1;
        private int scount;
        private DateTime lasttime;

        private void messagebox_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scount--;
            if (lasttime != Tool.xd100x._XD100xBuffer[listID]._Data._dt)
            {
                label1.Text = "采集任务执行成功！";
                timer2.Enabled = true;
                return;
            }
            if (scount % Tool.xd100x._XD100xBuffer[listID]._Info._timeout == 0&&scount>0)
            {
                label1.Text = "正在进行第" + Tool.xd100x._XD100xBuffer[listID]._Info._retrytimes + "次重试，任务执行中请等待......";
            }
            if (scount <= 0)
            {
                label1.Text = "采集任务执行失败！";
                timer2.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity - 0.02;
            if (this.Opacity <= 0.7)
            {
                timer2.Enabled = false;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
