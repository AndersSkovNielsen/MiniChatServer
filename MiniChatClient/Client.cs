using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace MiniChatClient
{
    class Client
    {
        public Client()
        {

        }

        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7070))

            using (NetworkStream ns = socket.GetStream())

            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))

            {
                String incomingLine = null;
                String line = null;

                if (line != "STOP" || incomingLine != "STOP")
                {
                    incomingLine = Console.ReadLine();

                    sw.WriteLine(incomingLine);
                    sw.Flush();

                    line = sr.ReadLine();

                    Console.WriteLine(line);
                }
            }
        }
    }
}
