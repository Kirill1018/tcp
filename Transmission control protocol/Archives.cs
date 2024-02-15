using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Archives
    {
        public static async Task Send_one(TcpClient client, string message)
        {
            byte[] buffer = Encoding.Default.GetBytes(message);
            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }
    }
}