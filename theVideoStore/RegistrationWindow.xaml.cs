﻿using System;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void UserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UserName.Text))
            {
                UserName.Visibility = System.Windows.Visibility.Collapsed;
                UserNameHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void UserNameHint_GotFocus(object sender, RoutedEventArgs e)
        {
            UserNameHint.Visibility = System.Windows.Visibility.Collapsed;
            UserName.Visibility = System.Windows.Visibility.Visible;
            UserName.Focus();
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text))
            {
                Password.Visibility = System.Windows.Visibility.Collapsed;
                PasswordHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void PasswordHint_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordHint.Visibility = System.Windows.Visibility.Collapsed;
            Password.Visibility = System.Windows.Visibility.Visible;
            Password.Focus();
        }
    }
}
