using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MiniChatServer
{
    class Server
    {
        private readonly int port = 7070;

        public void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, port);
            serverListener.Start();

            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();
                Task.Run(() => { TcpClient tempSocket = socket; DoClient(tempSocket); });
            }
        }

        public void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();

            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))

            {
                String line = null;
                String myLine = null;

                if (line != "STOP" || myLine != "STOP")
                {
                    line = sr.ReadLine();

                    Console.WriteLine(line);

                    myLine = Console.ReadLine();

                    sw.WriteLine(myLine);
                    sw.Flush();
                }
            }
        }
    }
}
