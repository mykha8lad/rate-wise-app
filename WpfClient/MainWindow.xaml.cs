using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // Важно! Это связывает XAML с кодом.
        }

        private void OnSendClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string message = MessageInput.Text; // Получаем текст из TextBox.

                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    ResponseBlock.Text = response; // Отображаем ответ.
                }
            }
            catch (Exception ex)
            {
                ResponseBlock.Text = $"Ошибка: {ex.Message}";
            }
        }
    }
}
