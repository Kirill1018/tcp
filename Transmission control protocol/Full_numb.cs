using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Transmission_control_protocol
{
    internal class Full_numb
    {
        public static async Task<int> Rec_int32(TcpClient client)
        {
            byte[] length_buff = await Count.Rec_fix(client, sizeof(int));
            return BitConverter.ToInt32(length_buff, 0);
        }
    }
}