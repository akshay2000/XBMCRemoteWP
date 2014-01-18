using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XBMCRemoteWP.RPCWrappers;
using XBMCRemoteWP.Models;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP
{
    public partial class ConnectionsPage : PhoneApplicationPage
    {
        public ConnectionsPage()
        {
            InitializeComponent();
            DataContext = App.MainVM;
        }

        private void AddConnectionAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddConnectionPage.xaml", UriKind.Relative));
        }

        private async void ConnectionItemWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ConnectionItem selectedConnection = (ConnectionItem)(sender as StackPanel).DataContext;
            bool isSuccessful = await JSONRPC.Ping(selectedConnection);
            if(isSuccessful)
            {
                ConnectionManager.CurrentConnection = selectedConnection;
                NavigationService.Navigate(new Uri("/CoverPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Could not reach the server.", "Connection Unsuccessful", MessageBoxButton.OK);
            }
        }
    }
}