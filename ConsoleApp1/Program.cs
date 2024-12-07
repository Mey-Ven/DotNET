using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    internal class Program
    {
        static byte[] Buffer {  get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Any, 1234));
            sck.Listen(100);

            Socket accepted = sck.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int bytesread = accepted.Receive(Buffer);
            byte[] formatted = new byte[bytesread];
            for(int i = 0; i < bytesread; i++)
            {
                formatted[i] = Buffer[i];
            }
            string strData = Encoding .ASCII.GetString(formatted);
            Console.Write(strData + "\r\n");
            Console.Read();
            sck.Close();
            accepted.Close();
        }
    }
}
