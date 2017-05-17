using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Xml.Serialization;
using System.IO;

namespace theVideoStore
{
    /// <summary>
    /// Логика взаимодействия для silenceOfTheLambs.xaml
    /// </summary>
    public partial class silenceOfTheLambs : Page
    {
        List<Client> clients = new List<Client>();

        public silenceOfTheLambs()
        {
            InitializeComponent();
            deserializeData();
            dataGrid.ItemsSource = clients;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow Window = new AddClientWindow();
            if(Window.ShowDialog().Value)
            {
                clients.Add(Window.newClient);
            }

            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = clients;
            serializeData();
        }

        private void serializeData()
        {
            using (FileStream fs = new FileStream("clients.xml", FileMode.Create))
            {
                XmlSerializer sr = new XmlSerializer(typeof(List<Client>));
                sr.Serialize(fs, clients);
            }
        }

        public void deserializeData()
        {
            if (File.Exists("clients.xml"))
            {
                using (FileStream fs = new FileStream("clients.xml", FileMode.Open))
                {
                    XmlSerializer dsr = new XmlSerializer(typeof(List<Client>));
                    clients = (List<Client>)dsr.Deserialize(fs);
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void selectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            buttonDelete.IsEnabled = (dataGrid.SelectedIndex != -1);
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            clients.RemoveAt(dataGrid.SelectedIndex);
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = clients;
            serializeData();
        }
    }
}
