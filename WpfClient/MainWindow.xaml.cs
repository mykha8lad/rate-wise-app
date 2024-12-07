using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        private readonly CurrencyApiClient _apiClient = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                // Получаем данные от сервера
                Dictionary<string, decimal> rates = await _apiClient.GetExchangeRatesAsync();
                
                // Отображаем данные в DataGrid
                CurrencyGrid.ItemsSource = new List<KeyValuePair<string, decimal>>(rates);
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить данные.");
            }
        }
    }
}
