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
            if(!IsIpAddressValid(IPTextBox.Text))
            {
                MessageBox.Show("Please, enter a valid IPv4 address.", "Invalid IP Address", MessageBoxButton.OK);
                return;
            }

            if (int.TryParse(PortTextBox.Text, out port))
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

        private bool IsIpAddressValid(string ipAddress)
        {
            bool isValid = true;
            List<string> fragments = ipAddress.Split('.').ToList<string>();
            if (fragments.Count != 4)
                return false;
            foreach (var t in fragments)
            {
                int fragment;
                bool isFragmentInt = int.TryParse(t, out fragment);
                if (!isFragmentInt || (fragment > 255 || fragment < 0))
                    return false;
            }
            return isValid;
        }
    }
}