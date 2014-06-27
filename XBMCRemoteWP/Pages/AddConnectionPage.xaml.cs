using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XBMCRemoteWP.Models;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Pages
{
    public partial class AddConnectionPage : PhoneApplicationPage
    {
        public AddConnectionPage()
        {
            InitializeComponent();
        }

        private void SaveConnectionAppBarButton_Click(object sender, EventArgs e)
        {
            int port;

            if (!int.TryParse(PortTextBox.Text, out port))
            {
                MessageBox.Show("Please, enter a valid port number.", "Invalid Port", MessageBoxButton.OK);
                return;
            }

            var newConnection = new ConnectionItem
            {
                ConnectionName = NameTextBox.Text,
                IpAddress = IPTextBox.Text,
                Port = port,
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text
            };
            App.MainVM.AddConnectionItem(newConnection);
            NavigationService.GoBack();
        }

        private void CancelAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void IPTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IPTextBox.Text = IPTextBox.Text.Replace(',', '.');
        }
    }
}