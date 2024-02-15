using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Row
    {
        public static async Task<string> Rec_string(TcpClient client)
        {
            byte[] string_buff = await Block.Rec_var(client);
            string buffer = Encoding.Default.GetString(string_buff);
            return buffer;
        }
    }
}