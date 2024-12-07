using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        static Socket sck;

        static void Main(string[] args)
        {
            Console.Write("Ecrivez l'adresse IP: ");
            string ipadd = Console.ReadLine();

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(ipadd), 1234);

            try
            {
                sck.Connect(localEndPoint);
            }
            catch
            {
                Console.Write("La connexion est impossible pour l'instant.\r\n");
                Main(args);
            }
            Console.Write("Ecrivez un message: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);
            sck.Send(data);

            Console.Write("Données envoyées !");
            Console.Read();
            sck.Close();
        }
    }
}