using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Block
    {
        public static async Task<byte[]> Rec_var(TcpClient client)
        {
            int length = await Full_numb.Rec_int32(client);
            return await Count.Rec_fix(client, length);
        }
    }
}