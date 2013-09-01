using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace SocketServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //加载配置
            if (!xml_load())
            {
                return;
            }

            if (!Tool.DB.dbtest())
            {
                return;
            }

            //加载缓存
            Tool.Gprs.Load_GprsList();
            Tool.xd100x.Load_XD100xBuffer();
            Tool.xd300.Load_XD300Buffer();
            
            //打开监听
            Tool.SocketListenerManager slm;
            Tool.SocketListener sckListener = new Tool.SocketListener(port);
            sckListener.Start();
            slm = new Tool.SocketListenerManager();
            slm.Add(sckListener);

            //巡检任务
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;

            //启动页面
            Application.Run(new main());

        }

        public static void timer_Tick(object sender, EventArgs e)
        {
            //循环采集命令生成
            Tool.xd100x.Polling_XD100xCollect();
            //2012
            if (isseted == false)
            {
                isseted = true;
                Tool.xd100x.Polling_XD100xSetOutTemp();
            }
            Tool.xd300.Polling_XD300Collect();
            
            //发送任务
            Tool.xd100x.Polling_XD100xSend();
            Tool.xd300.Polling_XD300Send();
            Tool.Gprs.Polling_HeatbeatSend();
            //存储任务
            Tool.xd100x.Polling_XD100xSave();
            Tool.xd300.Polling_XD300Save();
            //更新缓存数据，用于实时显示
            if (DateTime.Now.Second == 0)
            {
                Tool.xd100x.load_lastdata();
            }
        }

        public static int port;
        //2012
        public static int basedeviceid;
        public static float baseouttemp;
        public static bool isseted;

        public static bool xml_load()
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("config.xml");
                //监听端口
                port = Convert.ToInt16(xDoc.DocumentElement.ChildNodes[1].Attributes.GetNamedItem("value").Value.Trim());
                //数据库联接字符串
                Tool.DB.sqlcon = xDoc.DocumentElement.ChildNodes[2].Attributes.GetNamedItem("value").Value.Trim();
                //2012
                basedeviceid = Convert.ToInt32(xDoc.DocumentElement.ChildNodes[7].Attributes.GetNamedItem("value").Value.Trim());

                return true;
            }
            catch 
            {
                MessageBox.Show("读取配置文件出错！请确定程序完整性！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

    }
}