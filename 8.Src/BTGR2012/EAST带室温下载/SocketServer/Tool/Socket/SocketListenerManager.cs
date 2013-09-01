using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Tool
{
    public class SocketListenerManager
    {
        public SocketListenerManager()
        {
            
        }
        
        public System.Collections.ObjectModel.Collection<SocketListener> SocketListeners
        {
            get
            {
                if (this._socketListenerCollection == null)
                    this._socketListenerCollection = new System.Collections.ObjectModel.Collection<SocketListener>();
                return _socketListenerCollection;
            }
        } private System.Collections.ObjectModel.Collection<SocketListener> _socketListenerCollection;

       
        public void Add(SocketListener item)
        {
            this.SocketListeners.Add(item);
            ReginsterEvents(item);
        }

        public bool Remove(SocketListener item)
        {
            if (this.SocketListeners.Remove(item))
            {
                UnregisterEvents(item);
                return true;
            }
            return false;
        }

        private void ReginsterEvents(SocketListener item)
        {
            item.ConnectedEvent += new EventHandler(item_ConnectedEvent);
        }

        private void UnregisterEvents(SocketListener item)
        {
            item.ConnectedEvent -= new EventHandler(item_ConnectedEvent);
        }

        private void CloseSocket(Socket sck)
        {
            try
            {
                sck.Shutdown(SocketShutdown.Both);
                sck.Close();
            }
            catch
            {

            }
        }

        public CommuniPortManager CommuniPortManager
        {
            get
            {
                if (this._communiPortManager == null)
                    this._communiPortManager = new CommuniPortManager();
                return this._communiPortManager;
            }
        } private CommuniPortManager _communiPortManager;

        //新建连接事件
        private void item_ConnectedEvent(object sender, EventArgs e)
        {
            SocketListener sl = sender as SocketListener;
            Socket newsocket = sl.NewSocket;
            if (newsocket == null)
                return;
            if (!newsocket.Connected)
            {
                return;
            }

            SocketCommuniPort scp = null;
            try
            {
                scp = new SocketCommuniPort(newsocket);
            }
            catch
            {
                CloseSocket(newsocket);
                return;
            }
            this.CommuniPortManager.Add(scp);

        }

    }
}
