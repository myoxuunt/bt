using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Tool
{

    public class SocketListener : TcpListener
    {
        public event EventHandler ConnectedEvent;

        public Socket NewSocket
        {
            get { return _newSocket; }
        } private Socket _newSocket;

        public bool IsListening
        {
            get { return this.Active; }
        }

        public SocketListener(int port)
            : base(IPAddress.Parse("0.0.0.0"), port)
        {
        }

        public new void Start()
        {
            base.Start();
            this.BeginAcceptSocketHelper();
        }

        private void BeginAcceptSocketHelper()
        {
            AsyncCallback callback = new AsyncCallback(this.BeginAcceptSocketCallback);
            this.BeginAcceptSocket(callback,this);
        }

        private void BeginAcceptSocketCallback(IAsyncResult ar)
        {
            Socket socket = null;
            try
            {
                socket = this.EndAcceptSocket(ar);
            }
            catch
            {
            }

            if (socket != null)
            {
                this._newSocket = socket;
                if (ConnectedEvent != null)
                {
                    this.ConnectedEvent(this, EventArgs.Empty);
                }
            }
            this.BeginAcceptSocketHelper();
        }
    }

}
