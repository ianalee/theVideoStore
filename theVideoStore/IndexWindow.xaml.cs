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
using theVideoStore.Pages;

namespace theVideoStore
{
    /// <summary>
    /// Логика взаимодействия для IndexWindow.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow()
        {
            InitializeComponent();
        }

        private void BtnClick1(object sender, RoutedEventArgs e)
        {
            Home.Content = new silenceOfTheLambs();
        }

        private void BtnClick2(object sender, RoutedEventArgs e)
        {
            Home.Content = new forrestGump();
        }
    }
}
