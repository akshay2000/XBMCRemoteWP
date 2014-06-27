using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Pages
{
    public partial class EditConnectionPage : PhoneApplicationPage
    {
        public EditConnectionPage()
        {
            InitializeComponent();
            DataContext = ConnectionManager.CurrentConnection;
        }

        private void CancelAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveConnectionAppBarButton_Click(object sender, EventArgs e)
        {
            int port;
           
            if (!int.TryParse(PortTextBox.Text, out port))
            {
                MessageBox.Show("Please, enter a valid port number.", "Invalid Port", MessageBoxButton.OK);
                return;
            }

            var connection = ConnectionManager.CurrentConnection;
            connection.ConnectionName = NameTextBox.Text;
            connection.IpAddress = IPTextBox.Text;
            connection.Port = int.Parse(PortTextBox.Text);
            connection.Username = UsernameTextBox.Text;
            connection.Password = PasswordTextBox.Text;
            App.MainVM.SubmitChanges();
            NavigationService.GoBack();
        }
    }
}