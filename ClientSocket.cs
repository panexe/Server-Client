﻿using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace __ClientSocket__
{
    class ClientSocket
    {
    	// Test Kommentar
        private string host = "";
        private int port = 0;
        private Socket socket = null;
        private System.Net.IPEndPoint ep = null;
        IPHostEntry hostInfo = null;

        public ClientSocket(string host, int port)
        {
            hostInfo = Dns.GetHostByName(host);
            ep = new IPEndPoint(hostInfo.AddressList[0], port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public ClientSocket(Socket socket)
        {
            this.socket = socket;
        }
        public bool connect()
        {
            bool rc = false;

            try
            {
                socket.Connect(ep);
                rc = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rc;
        }
        public int dataAvailable()
        {
            return socket.Available;
        }
        public void write(int b)
        {
            byte[] msg = new byte[1];
            msg[0] = (byte)b;
            socket.Send(msg);
        }
        public void write(byte[] b, int len)
        {
            socket.Send(b, len, SocketFlags.None);
        }
        public void write(string s)
        {
            byte[] msg = Encoding.Unicode.GetBytes(s);
            socket.Send(msg);
        }
        public int read()
        {
            byte[] rcvbuffer = new byte[1];
            socket.Receive(rcvbuffer, 1, SocketFlags.None);
            return Convert.ToInt32(rcvbuffer[0]);
        }
        public int read(byte[] b, int len)
        {
            return socket.Receive(b, len, SocketFlags.None);
        }
        public string readLine()
        {
            byte[] rcvbuffer = new byte[256];
            socket.Receive(rcvbuffer);
            ASCIIEncoding enc = new ASCIIEncoding();
            
            string rcv = "";

            foreach (byte b in rcvbuffer)
            {
                if (b != '\0')
                    rcv += (char)b;
            }

            if (rcv.Substring(rcv.Length - 1) == "\n")
                rcv = rcv.Remove(rcv.Length - 1, 1);

            return rcv;
        }
        public void close()
        {
            socket.Close();
            socket = null;
        }
    }
}
