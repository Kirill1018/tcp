using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Receiver
    {
        public static async void List_to(TcpClient client, ICollection<TcpClient> clients)
        {
            try
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int read = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                    string message = Encoding.Default.GetString(buffer, 0, read);
                    Archive.Send(message, clients);
                }
            }
            catch (Exception exception)
            {
                lock (clients) clients.Remove(client);
                client.Dispose();
            }
        }
    }
}