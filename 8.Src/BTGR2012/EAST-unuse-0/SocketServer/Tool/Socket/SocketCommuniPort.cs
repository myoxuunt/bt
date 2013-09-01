using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace Tool
{
    public class SocketCommuniPort : CommuniPort
    {

        private const int BUFFER_SIZE = 1024;

        private byte[] _receBuffer = new byte[BUFFER_SIZE];

        public event EventHandler ReceivedEvent;
        public event EventHandler ClosedEvent;

        public SocketCommuniPort(Socket socket)
        {
            if (socket == null)
            {
                return;
            }
            if (!socket.Connected)
            {
                return;
            }
            this._socket = socket;
            this.LocalEndPoint = this._socket.LocalEndPoint;
            this.RemoteEndPoint = this._socket.RemoteEndPoint;           
            BeginReceiveHelper();
        }


        public EndPoint LocalEndPoint
        {
            get { return _localEndPoint; }
            set { _localEndPoint = CloneEndPoint(value); }
        } private EndPoint _localEndPoint;

        public EndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
            set { _remoteEndPoint = CloneEndPoint(value); }
        } private EndPoint _remoteEndPoint;

        static private EndPoint CloneEndPoint(EndPoint ep)
        {
            IPEndPoint ipep = ep as IPEndPoint;
            IPEndPoint n = new IPEndPoint(ipep.Address, ipep.Port);
            return n;
        }



        public void BeginReceiveHelper()
        {
            try
            {
                AsyncCallback cb = this.ReceiveCallback;
                IAsyncResult ia = _socket.BeginReceive(_receBuffer, 0, BUFFER_SIZE, SocketFlags.None, cb, _socket);
            }
            catch
            {
            }
        }

        private AsyncCallback ReceiveCallback
        {
            get
            {
                if (_receiveCallback == null)
                    _receiveCallback = new AsyncCallback(BeginReceiveCallback);
                return _receiveCallback;
            }
        } private AsyncCallback _receiveCallback;

        private void BeginReceiveCallback(IAsyncResult ia)
        {
            Socket sck = ia.AsyncState as Socket;
            int n = 0;
            try
            {
                n = sck.EndReceive(ia);
            }
            catch
            {
                this.CloseHelper();
                return;
            }


            if (n > 0)
            {
                _memoryStream.Write(_receBuffer, 0, n);
                OnReceived();
                BeginReceiveHelper();
            }
            else
            {
                CloseHelper();
            }
        }

        public void OnReceived()
        {
            if (ReceivedEvent != null)
            {
                EventHandler t = this.ReceivedEvent;
                t(this, EventArgs.Empty);
            }
        }

        public bool Closed
        {
            get { return _closed; }
        } private bool _closed;

        private void CloseHelper()
        {
            if (!this._closed)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                this._closed = true;
                OnClosed();
            }
        }

        private void OnClosed()
        {
            if (this.ClosedEvent != null)
            {
                EventHandler t = ClosedEvent;
                t(this, EventArgs.Empty);
            }
        }

        public Socket Socket
        {
            get { return _socket; }
        } private Socket _socket;

        public override bool Write(byte[] bytes)
        {
            try
            {
                this._socket.Send(bytes);
                return true;
            }
            catch
            {
                CloseHelper();
            }

            return false;
        }

        private System.IO.MemoryStream _memoryStream = new System.IO.MemoryStream();

        public override byte[] Read()
        {
            byte[] bs = _memoryStream.ToArray();
            _memoryStream.SetLength(0);
            return bs;
        }

        public override void Remove()
        {
            this.CloseHelper();
            base.Remove();
        }

    }
}
