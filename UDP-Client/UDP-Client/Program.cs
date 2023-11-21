using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();

            // Change the server IP and port to match your server
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("212.116.138.116"), 4545);

            while (true)
            {
                Console.Write("Enter a message to send (or 'exit' to quit): ");
                string message = Console.ReadLine();

                if (message.ToLower() == "exit")
                    break;

                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, serverEndPoint);

                // Receive the echoed message from the server
                byte[] receivedData = udpClient.Receive(ref serverEndPoint);
                string receivedMessage = Encoding.UTF8.GetString(receivedData);

                Console.WriteLine($"Received from server: {receivedMessage}");
            }

            udpClient.Close();
        }
    }
}
