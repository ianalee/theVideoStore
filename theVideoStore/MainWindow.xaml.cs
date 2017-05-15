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
using System.Data.SQLite;

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

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                Password.Visibility = System.Windows.Visibility.Collapsed;
                textPasswordHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textPasswordHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textPasswordHint.Visibility = System.Windows.Visibility.Collapsed;
            Password.Visibility = System.Windows.Visibility.Visible;
            Password.Focus();
        }

        private void textPasswordHint_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (textLogin.Text == "admin")
            {
                if (Password.Password == "admin")
                {
                    IndexWindow inx = new IndexWindow();
                    this.Close();
                    inx.Show();
                }
            }
            else
                MessageBox.Show("Неправильный логин или пароль");
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            this.Close();
            reg.Show();

        }
    }
}
