using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Transmission_control_protocol
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string file_cont = string.Empty, file_path = string.Empty;
        public static TcpListener listener;
        public static ICollection<TcpClient> clients = new List<TcpClient>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button__Click(object sender, RoutedEventArgs e)
        {
            TcpClient client = new TcpClient("192.168.1.130", 2024);
            int number = (int)new FileInfo(file_path).Length;
            byte[] buffer = new byte[1024];
            await Line.Send_string(client, file_path);
            int pos = 0, pos_ = 0;//прочитанная часть файла
            while (pos < number)
            {
                int read = await new FileStream(file_path, FileMode.Open).ReadAsync(buffer, 0, Math.Min(buffer.Length, number - pos));
                await client.GetStream().WriteAsync(buffer, 0, read);
                pos += read;
            }
            name.Text = Row.Rec_string(client).ToString();
            size.Text = Full_numb.Rec_int32(client).ToString();
            listener = new TcpListener(IPAddress.Parse("192.168.1.130"), 2024);
            listener.Start();
            await Hinge.Acc_loop(listener, clients);
            int length = await Full_numb.Rec_int32(client);
            while (pos_ < length)
            {
                int read = await client.GetStream().ReadAsync(buffer, 0, Math.Min(length - pos, buffer.Length));
                await new FileStream(Row.Rec_string(client).ToString(), FileMode.CreateNew).WriteAsync(buffer, 0, read);
                pos_ += read;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = Row.Rec_string(client).ToString();
            if (dialog.ShowDialog() == true) File.WriteAllText(dialog.FileName, file_cont);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "";
            dialog.Filter = "";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                file_path = dialog.FileName;
                var file_stream = dialog.OpenFile();
                using (StreamReader reader = new StreamReader(file_stream)) { file_cont = reader.ReadToEnd(); }
            }
        }
    }
}