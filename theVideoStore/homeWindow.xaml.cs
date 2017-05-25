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
    /// Логика взаимодействия для homeWindow.xaml
    /// </summary>
    public partial class homeWindow : Window
    {

        public homeWindow()
        {
            InitializeComponent();
            
        }

        

        private void newClient_Click(object sender, RoutedEventArgs e)
        {
            addFilm add = new addFilm();
            mainFrame.Content = new addClient(add.films);
        }

        private void newFilm_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new addFilm();
        }
    }
}
