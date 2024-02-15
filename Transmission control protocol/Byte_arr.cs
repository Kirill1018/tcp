using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Byte_arr
    {
        public static async Task Send_with_length(TcpClient client, byte[] buffer)
        {
            await Number.Send_int32(client, buffer.Length);
            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
        }
    }
}