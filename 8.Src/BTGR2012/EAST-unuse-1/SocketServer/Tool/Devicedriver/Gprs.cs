using System.Data;
using System.Windows.Forms;
using System.Net.Sockets;
using System;
using System.Text;

namespace Tool
{
    class Gprs
    {
        public struct GprsList
        {
            public Socket _socket;
            public string _ip;
            public bool _Iscon;
            public bool _Isbusy;
            public string _heatbeat;
            public DateTime _lasttime;
            public bool _activate;
            public string _name;
        }

        public static GprsList[] _GprsList;
        
        //建立ISocketRS列表
        public static void Load_GprsList()
        {
            try
            {
                string sql = "select DISTINCT [IPAddress],[StationName] from tblStation where [Deleted]=0";
                DataTable dt = Tool.DB.getDt(sql);
                _GprsList = new GprsList[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    _GprsList[i]._ip = dt.Rows[i]["IPAddress"].ToString();
                    _GprsList[i]._name = dt.Rows[i]["StationName"].ToString();
                    _GprsList[i]._heatbeat = "hello";
                }
            }
            catch
            {
                MessageBox.Show("建立ISocketRS列表失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //通过ip获取ISocketRSlist
        public static GprsList Get_GprsList(string ip)
        {
            GprsList sl = new GprsList();
            for (int i = 0; i < _GprsList.Length; i++)
            {
                if (_GprsList[i]._ip == ip)
                {
                    sl = _GprsList[i];
                    break;
                }
            }
            return sl;
        }

        //ISocketRS占用/解除
        public static void Gprs_IsOccupy(string ip, bool onoff)
        {
            for (int k = 0; k < _GprsList.Length; k++)
            {
                if (_GprsList[k]._ip == ip)
                {
                    _GprsList[k]._Isbusy = onoff;
                    break;
                }
            }
        }

        //发送数据
        public static bool Gprs_send(GprsList gl,byte[] buffer)
        {
            try
            {
                gl._socket.Send(buffer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //激活或取消激活 GPRS即收到Gprs注册信息或心跳之后 开启Gprs通讯
        public static void Gprs_activate(string ip)
        {
            for (int i = 0; i < _GprsList.Length; i++)
            {
                if (_GprsList[i]._ip == ip)
                {
                    _GprsList[i]._activate = true;
                }
            }
        }

        //发送心跳包
        public static void Polling_HeatbeatSend()
        {
            for (int i = 0; i < _GprsList.Length; i++)
            {
                //检测是否到达心跳周期
                if ((DateTime.Now-_GprsList[i]._lasttime).TotalSeconds >= 300)
                {
                    //检测ISocketRS是否被占用和是否连接 
                    if (_GprsList[i]._Iscon == false || _GprsList[i]._Isbusy == true || _GprsList[i]._activate == false)
                    {
                        continue;
                    }
                    byte[] buffer = new System.Text.UnicodeEncoding().GetBytes(_GprsList[i]._heatbeat);
                    bool send_flg = Gprs.Gprs_send(_GprsList[i],buffer);
                    if (send_flg == true)
                    {
                        _GprsList[i]._lasttime = DateTime.Now;
                    }
                }
            }

        }
    }
}
