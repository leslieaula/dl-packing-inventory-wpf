﻿using DLInventoryPacking.WinApps.Pages;
using DLInventoryPacking.WinApps.Services;
using DLInventoryPacking.WinApps.Services.ResponseModel;
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

namespace DLInventoryPacking.WinApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MenuGrid.Visibility = Visibility.Hidden;
            LoginGrid.Visibility = Visibility.Visible;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                MessageBox.Show("Username atau Password harus diisi!");
            }
            else
            {
                UserCredentials.Token = await AuthService.Authenticate(UsernameTextBox.Text, PasswordTextBox.Password);

                if (string.IsNullOrWhiteSpace(UserCredentials.Token))
                {
                    MessageBox.Show("Username atau Password salah!");
                }
                else
                {
                    LoginGrid.Visibility = Visibility.Hidden;
                    MenuGrid.Visibility = Visibility.Visible;
                    _NavigationFrame.Navigate(new HomePage());
                }
            }

            
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new HomePage());
        }

        private void YarnBarcodeButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new YarnBarcodePage());
        }

        private void FabricBarcodeButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new FabricBarcodePage());
        }

        private void GreigeBarcodeButton_Click(object sender, RoutedEventArgs e)
        {
            _NavigationFrame.Navigate(new GreigeBarcodePage());
        }
    }
}
