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

        List<client> clients = new List<client>();

        public addClient(List<film> films)
        {
            InitializeComponent();
            deserializeData();

            listBoxClients.ItemsSource = clients;

            comboBoxFilms.ItemsSource = null;
            comboBoxFilms.ItemsSource = films;
              
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

            if (string.IsNullOrWhiteSpace(datePickerFrom.Text))
            {
                MessageBox.Show("Please, enter the start date", "Error");
                datePickerFrom.Focus();
                return;
            }

            DateTime value;

            if (DateTime.TryParseExact(datePickerFrom.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out value) == false)
            {
                MessageBox.Show("Please, enter the start date in dd/mm/yyyy format", "Error");
                datePickerFrom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(datePickerTill.Text))
            {
                MessageBox.Show("Please, enter the end date", "Error");
                datePickerTill.Focus();
                return;
            }

            if (DateTime.TryParseExact(datePickerTill.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out value) == false)
            {
                MessageBox.Show("Please, enter the end date in dd/mm/yyyy format", "Error");
                datePickerTill.Focus();
                return;
            }

            if (comboBoxFilms.SelectedItem == null)
            {
                MessageBox.Show("Please, choose a film");
                comboBoxFilms.Focus();
                return;
            }
            
            _newClient.Film = comboBoxFilms.SelectedItem as film;
            _newClient = new client(textBoxName.Text, textBoxSurname.Text, datePickerFrom.Text, datePickerTill.Text, _newClient.Film);
            
            clients.Add(_newClient);
            listBoxClients.ItemsSource = null;
            listBoxClients.ItemsSource = clients;
            seriliazeData();
            logger.Log($"Client {_newClient.Name} {_newClient.Surname} has been added");
            
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
                clients.RemoveAt(listBoxClients.SelectedIndex);
                listBoxClients.ItemsSource = null;
                listBoxClients.ItemsSource = clients;

                textBoxName.Clear();
                textBoxSurname.Clear();

                seriliazeData();
                logger.Log($"{_newClient.Name} {_newClient.Surname} has been deleted");
            }
            catch 
            {
                MessageBox.Show("Please, select a client you want to delete", "Error");
            }
        }

        public client _updatedClient = new client();

        public client updatedClient
        {
            get { return _updatedClient; }
        }

        private void updateClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clients.RemoveAt(listBoxClients.SelectedIndex);

                _updatedClient.Film = comboBoxFilms.SelectedItem as film;
                _updatedClient = new client(textBoxName.Text, textBoxSurname.Text, datePickerFrom.Text, datePickerTill.Text, _updatedClient.Film);
                clients.Add(_updatedClient);

                listBoxClients.ItemsSource = null;
                listBoxClients.ItemsSource = clients;
            }
            catch
            {
                MessageBox.Show("Please, select a film you want to update", "Error");
            }
        }

        private void listBoxClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                    {
                        textBoxName.Text = (e.AddedItems[0] as client).Name;
                        textBoxSurname.Text = (e.AddedItems[0] as client).Surname;
                        datePickerFrom.Text = (e.AddedItems[0] as client).From.ToString();
                        datePickerTill.Text = (e.AddedItems[0] as client).Till.ToString();
                        comboBoxFilms.Text = (e.AddedItems[0] as client).Film.Name;
                    }
                 }
            
            catch
            {
                MessageBox.Show("Please, choose a client", "Error");
            }
        }

        
    }
}
