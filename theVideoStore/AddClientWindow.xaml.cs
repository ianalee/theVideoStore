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
using System.Windows.Shapes;

namespace theVideoStore
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        Client _newClient = new Client();

        public Client newClient
        {
            get { return _newClient; }
        }
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите имя клиента", "Ошибка");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Введите фамилию клиента", "Ошибка");
                textBoxSurname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxFrom.Text))
            {
                MessageBox.Show("Введите дату начала аренды", "Ошибка");
                textBoxFrom.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTill.Text))
            {
                MessageBox.Show("Введите дату окнчания аренды", "Ошибка");
                textBoxTill.Focus();
                return;
            }
            _newClient = new Client(textBoxName.Text, textBoxSurname.Text, textBoxFrom.Text, textBoxTill.Text);

            DialogResult = true;
        }
    }
}
