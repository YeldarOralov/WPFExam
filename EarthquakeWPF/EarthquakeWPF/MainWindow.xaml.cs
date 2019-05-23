using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace EarthquakeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        List<Property> GetData()
        {
            List<Property> Events = new List<Property>();
            WebClient client = new WebClient();
            string url = "https://earthquake.usgs.gov/fdsnws/event/1/query?format=geojson&limit=";
            url += eventsCount.Text;
            var jsonEvent = client.DownloadString($"{url}");
            var result = JsonConvert.DeserializeObject<RootObject>(jsonEvent);
            foreach (var feature in result.Features)
            {
                Events.Add(feature.Properties);
            }
            eventsGrid.ItemsSource = Events;
            return Events;
        }
    }
}
