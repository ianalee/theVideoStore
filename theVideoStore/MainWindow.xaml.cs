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

namespace theVideoStore
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

        private void textLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textLogin.Text))
            {
                textLogin.Visibility = System.Windows.Visibility.Collapsed;
                textLoginHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textLoginHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textLoginHint.Visibility = System.Windows.Visibility.Collapsed;
            textLogin.Visibility = System.Windows.Visibility.Visible;
            textLogin.Focus();
        }

        private void textPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textPassword.Text))
            {
                textPassword.Visibility = System.Windows.Visibility.Collapsed;
                textPasswordHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textPasswordHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textPasswordHint.Visibility = System.Windows.Visibility.Collapsed;
            textPassword.Visibility = System.Windows.Visibility.Visible;
            textPassword.Focus();
        }
    }
}
