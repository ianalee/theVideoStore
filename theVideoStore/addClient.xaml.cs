using System;
using System.Collections.Generic;
using System.IO;
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

namespace theVideoStore
{
    /// <summary>
    /// Логика взаимодействия для addClient.xaml
    /// </summary>
    public partial class addClient : Page
    {
        private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                textBoxName.Visibility = System.Windows.Visibility.Collapsed;
                textBoxNameHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxNameHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxNameHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxName.Visibility = System.Windows.Visibility.Visible;
            textBoxName.Focus();
        }

        private void textBoxSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSurname.Text))
            {
                textBoxSurname.Visibility = System.Windows.Visibility.Collapsed;
                textBoxSurnameHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxSurnameHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxSurnameHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxSurname.Visibility = System.Windows.Visibility.Visible;
            textBoxSurname.Focus();
        }

        private void textBoxFrom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFrom.Text))
            {
                textBoxFrom.Visibility = System.Windows.Visibility.Collapsed;
                textBoxFromHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxFromHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxFromHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxFrom.Visibility = System.Windows.Visibility.Visible;
            textBoxFrom.Focus();
        }

        private void textBoxTill_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTill.Text))
            {
                textBoxTill.Visibility = System.Windows.Visibility.Collapsed;
                textBoxTillHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxTillHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxTillHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxTill.Visibility = System.Windows.Visibility.Visible;
            textBoxTill.Focus();
        }

        List<client> clients = new List<client>();

        public addClient()
        {
            InitializeComponent();
            deserializeData();
            dataGridClients.ItemsSource = clients;
        }

        client _newClient = new client();

        public client newClient
        {
            get { return _newClient; }
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the client's name", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Please, enter the client's surname", "Error");
                textBoxSurname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFrom.Text))
            {
                MessageBox.Show("Please, enter the start date", "Error");
                textBoxFrom.Focus();
                return;
            }

            DateTime value;

            if (DateTime.TryParseExact(textBoxFrom.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out value) == false)
            {
                MessageBox.Show("Please, enter the start date in dd/mm/yyyy format", "Error");
                textBoxFrom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTill.Text))
            {
                MessageBox.Show("Please, enter the end date", "Error");
                textBoxTill.Focus();
                return;
            }

            if (DateTime.TryParseExact(textBoxTill.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out value) == false)
            {
                MessageBox.Show("Please, enter the end date in dd/mm/yyyy format", "Error");
                textBoxTill.Focus();
                return;
            }

            _newClient = new client(textBoxName.Text, textBoxSurname.Text, textBoxFrom.Text, textBoxTill.Text);
            clients.Add(_newClient);
            dataGridClients.ItemsSource = null;
            dataGridClients.ItemsSource = clients;
            seriliazeData();
            Logger.Log($"Client {_newClient.Name} {_newClient.Surname} has been added");
        }


        private void seriliazeData()
        {
            using (FileStream fs = new FileStream("clients.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<client>));
                ser.Serialize(fs, clients);
            }
        }

        private void deserializeData()
        {
            if (File.Exists("clients.xml"))
            {
                using (FileStream fs = new FileStream("clients.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<client>));
                    clients = (List<client>)deser.Deserialize(fs);
                }
            }
        }

        private void deleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clients.RemoveAt(dataGridClients.SelectedIndex);
                dataGridClients.ItemsSource = null;
                dataGridClients.ItemsSource = clients;
            }
            catch
            {
                MessageBox.Show("Please, select a client you want to delete", "Error");
            }
            seriliazeData();

            Logger.Log($"{_newClient.Name} {_newClient.Surname} has been deleted");
        }

        private void updateClient_Click(object sender, RoutedEventArgs e)
        {
        }

        private void dataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                textBoxName.Text = (e.AddedItems[0] as client).Name;
                textBoxSurname.Text = (e.AddedItems[0] as client).Surname;
                textBoxFrom.Text = (e.AddedItems[0] as client).From.ToString();
                textBoxTill.Text = (e.AddedItems[0] as client).Till.ToString();
            }
        }

        
        public void comboBoxFilms_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxFilms.ItemsSource = 
        }

        private void comboBoxFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
