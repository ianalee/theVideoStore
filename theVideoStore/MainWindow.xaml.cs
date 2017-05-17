using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {

            var hash = CalculateHash("ilovechocolate");

            if (textLogin.Text == "Iana" && CalculateHash(Password.Password) == hash)
                {
                    IndexWindow home = new IndexWindow();
                    this.Close();
                    home.Show();
                }
            else
                MessageBox.Show("Incorrect login/password");
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg = new RegistrationWindow();
            this.Close();
            reg.Show();

        }
    }
}
