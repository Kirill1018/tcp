using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Archive
    {
        public static async void Send(string message, ICollection<TcpClient> clients)
        {
            IReadOnlyList<TcpClient> customers;
            lock(clients) customers = clients.ToList();
            await Task.WhenAll(customers.Select(client => Archives.Send_one(client, message)));
        }
    }
}