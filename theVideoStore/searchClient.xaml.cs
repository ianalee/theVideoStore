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
    /// Логика взаимодействия для searchClient.xaml
    /// </summary>
    public partial class searchClient : Page
    {
        List<client> searchedClients = new List<client>();

        public searchClient(List<client> clients)
        {
            InitializeComponent();

            searchedClients = clients;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (client c in searchedClients)
                            {
                                if (textBoxName.Text == c.Name)
                                {
                                    if (textBoxSurname.Text == c.Surname)
                                    {
                                        listBoxSearch.Items.Add(c.Info);
                                    }
                                }
                            }
            }
            catch
            {
                MessageBox.Show("Client has not been found", "Error");
            }
            
        }

    }
}

