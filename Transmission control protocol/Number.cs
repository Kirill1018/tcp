using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Number { public static async Task Send_int32(TcpClient client, int number) => await client.GetStream().WriteAsync(BitConverter.GetBytes(number), 0, 4); }
}