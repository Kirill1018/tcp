using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Hinge
    {
        public static async Task Acc_loop(TcpListener listener, ICollection<TcpClient> clients)
        {
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                lock (clients) clients.Add(client);
                Archive.Send(client.Client.RemoteEndPoint
                    .ToString(), clients);

            }
        }
    }
}