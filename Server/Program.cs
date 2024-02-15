using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args) => await Run();
        public static TcpListener listener;
        public static ICollection<TcpClient> clients = new List<TcpClient>();
        public static async Task Run()
        {
            listener = new TcpListener(IPAddress.Parse("192.168.1.130"), 2024);
            listener.Start();
            await Hinge.Acc_loop(listener, clients);
        }
    }
}