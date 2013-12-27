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
            var newConnection = new ConnectionItem
            {
                ConnectionName = NameTextBox.Text,
                IpAddress = IPTextBox.Text,
                Port = int.Parse(PortTextBox.Text),
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
    }
}