using System;
using System.Net;

namespace Tool
{

    public class CommuniPortManager
    {
        public System.Collections.ObjectModel.Collection<CommuniPort> CommuniPorts
        {
            get 
            {
                if (this._communiPorts ==null)
                    _communiPorts = new System.Collections.ObjectModel.Collection<CommuniPort>();
                return _communiPorts;
            }
        } private System.Collections.ObjectModel.Collection<CommuniPort> _communiPorts;


        public void Add(CommuniPort cp)
        {
            BeforeAdd(cp);
            this.CommuniPorts.Add(cp);
            RegisterEvents(cp);
        }

        //删除集合中已经存在的，相同远程地址的SocketCommuniPort
        private void BeforeAdd(CommuniPort cp)
        {
            if (cp is SocketCommuniPort)
            {
                SocketCommuniPort scp = cp as SocketCommuniPort;
                for (int i = this.CommuniPorts.Count - 1; i >= 0; i--)
                {
                    CommuniPort cp2 = this.CommuniPorts[i];
                    if (cp2 is SocketCommuniPort)
                    {
                        SocketCommuniPort scp2 = cp2 as SocketCommuniPort;
                        IPEndPoint ipep = scp.Socket.RemoteEndPoint as IPEndPoint;
                        IPEndPoint ipep2 = scp2.Socket.RemoteEndPoint as IPEndPoint;
                        if (ipep.Address.Equals(ipep2.Address))
                        {
                            Remove(cp2);
                        }
                    }
                }
            }
        }

        public bool Remove(CommuniPort cp)
        {
            if (this.CommuniPorts.Remove(cp))
            {
                UnreginsterEvents(cp);
                return true;
            }
            return false;
        }
        //新建连接事件
        private void RegisterEvents(CommuniPort cp)
        {
            SocketCommuniPort sckcp = cp as SocketCommuniPort;
            if (sckcp != null)
            {
                sckcp.ClosedEvent += new EventHandler(sckcp_ClosedEvent);
                sckcp.ReceivedEvent += new EventHandler(sckcp_ReceivedEvent);

                string ip = ((IPEndPoint)sckcp.RemoteEndPoint).Address.ToString();
                for (int i = 0; i < Gprs._GprsList.Length; i++)
                {
                    if (Gprs._GprsList[i]._ip == ip)
                    {
                        Gprs._GprsList[i]._socket = sckcp.Socket;
                        Gprs._GprsList[i]._Iscon = true;
                        Gprs._GprsList[i]._Isbusy = false;
                        //测试
                        Gprs._GprsList[i]._activate = true;
                        break;
                    }
                }
            }
        }
        
        private void UnreginsterEvents(CommuniPort cp)
        {
            SocketCommuniPort sckcp = cp as SocketCommuniPort;         
            sckcp.ClosedEvent -= new EventHandler(sckcp_ClosedEvent);
            sckcp.ReceivedEvent -= new EventHandler(sckcp_ReceivedEvent);

        }
        //接收事件
        private void sckcp_ReceivedEvent(object sender, EventArgs e)
        {
            SocketCommuniPort sckcp = sender as SocketCommuniPort;
            byte[] bytes = sckcp.Read();
            string ip = ((IPEndPoint)sckcp.RemoteEndPoint).Address.ToString();
            Tool.Gprs.Gprs_activate(ip);
            Tool.xd100n.Deal_XD100nData(bytes, ip);
            Tool.xd300.Deal_XD300Data(bytes, ip);
            Tool.xd100.Deal_XD100Data(bytes, ip);
        }
        //关闭事件
        void sckcp_ClosedEvent(object sender, EventArgs e)
        {
            SocketCommuniPort sckcp = sender as SocketCommuniPort;
            string ip = ((IPEndPoint)sckcp.RemoteEndPoint).Address.ToString();
            for (int i = 0; i < Gprs._GprsList.Length; i++)
            {
                if (Gprs._GprsList[i]._ip == ip)
                {
                    Gprs._GprsList[i]._socket = sckcp.Socket;
                    Gprs._GprsList[i]._Iscon = false;
                    Gprs._GprsList[i]._Isbusy = false;
                    Gprs._GprsList[i]._activate = false;
                    break;
                }
            }
            this.Remove((CommuniPort)sender);
        }



    }
}
