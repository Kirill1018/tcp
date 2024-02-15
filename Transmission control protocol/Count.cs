using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Count
    {
        public static async Task<byte[]> Rec_fix(TcpClient client, int length)
        {
            byte[] buffer = new byte[length];
            await client.GetStream().ReadAsync(buffer, 0, length);
            return buffer;
        }
    }
}