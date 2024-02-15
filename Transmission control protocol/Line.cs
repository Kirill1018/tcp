using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Line { public static async Task Send_string(TcpClient client, string text) => await Byte_arr.Send_with_length(client, Encoding.Default.GetBytes(text)); }
}