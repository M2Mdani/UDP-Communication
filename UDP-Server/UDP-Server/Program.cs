using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(8888);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("UDP Server is listening...");

            while (true)
            {
                byte[] data = udpServer.Receive(ref remoteEndPoint);
                string message = Encoding.UTF8.GetString(data);

                Console.WriteLine($"Received from {remoteEndPoint}: {message}");

                // Echo back to the client
                udpServer.Send(data, data.Length, remoteEndPoint);
            }
        }
    }
}
