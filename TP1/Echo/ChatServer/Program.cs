using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace Echo
{
    class EchoServer
    {
        [Obsolete]
        static void Main(string[] args)
        {

            Console.CancelKeyPress += delegate
            {
                System.Environment.Exit(0);
            };

            TcpListener ServerSocket = new TcpListener(5000);
            ServerSocket.Start();

            Console.WriteLine("Server started.");
            while (true)
            {
                TcpClient clientSocket = ServerSocket.AcceptTcpClient();
                handleClient client = new handleClient();
                client.startClient(clientSocket);
            }


        }
    }

    public class handleClient
    {
        static readonly string HTTP_ROOT = @"D:\Ecole\SI4\S8\SOC\TP\eiin839\TP1\Echo\www\pub";
        TcpClient clientSocket;
        public void startClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(Echo);
            ctThread.Start();
        }



        private void Echo()
        {
            NetworkStream stream = clientSocket.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);


            while (true)
            {

                string str = reader.ReadString();
                if (str.StartsWith("GET"))
                {
                    Console.WriteLine("Request : " + str);
                    string[] tab = str.Split(" ");
                    string requestPath = tab.FirstOrDefault(input => input.StartsWith('/'));
                    requestPath = string.IsNullOrEmpty(requestPath) ? HTTP_ROOT + requestPath.Replace("/", "\\") : HTTP_ROOT + "\\index.html"; string response = "";
                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(requestPath))
                    {
                        response += "http/1.0 200 OK \n\n";
                        response += sr.ReadToEnd();
                    }
                    Console.WriteLine("Response : " + response);
                    writer.Write(response);
                }
            }
        }



    }

}