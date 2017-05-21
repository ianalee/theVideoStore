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
            
                buttonEdit.IsEnabled = false;
                buttonDelete.IsEnabled = false;
            
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
            Logger.Log($"Client {Window.textBoxName.Text} {Window.textBoxSurname.Text} has been added");
        }

        private void serializeData()
        {
            using (FileStream fs = new FileStream("clientsSilenceOfTheLambs.xml", FileMode.Create))
            {
                XmlSerializer sr = new XmlSerializer(typeof(List<Client>));
                sr.Serialize(fs, clients);
            }
        }

        public void deserializeData()
        {
            if (File.Exists("clientsSilenceOfTheLambs.xml"))
            {
                using (FileStream fs = new FileStream("clientsSilenceOfTheLambs.xml", FileMode.Open))
                {
                    XmlSerializer dsr = new XmlSerializer(typeof(List<Client>));
                    clients = (List<Client>)dsr.Deserialize(fs);
                }
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonDelete.IsEnabled = true;
            buttonEdit.IsEnabled = true;
        }

        private void selectionChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Client cli = clients[dataGrid.SelectedIndex];
            clients.RemoveAt(dataGrid.SelectedIndex);
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = clients;
            serializeData();
            Logger.Log($"Client {cli.Name} {cli.Surname} has been deleted");
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Client cli = clients[dataGrid.SelectedIndex];
            AddClientWindow edit = new AddClientWindow(cli.Name, cli.Surname, cli.From, cli.Till);
            cli.Name = edit.textBoxName.Text;
            cli.Surname = edit.textBoxSurname.Text;
            cli.From = edit.textBoxFrom.Text;
            cli.Till = edit.textBoxTill.Text;
            Logger.Log($"Client {cli.Name} {cli.Surname}'s info has been changed");
        }
    }
}
