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
using System.Threading.Tasks;

namespace XBMCRemoteWP
{
    public partial class ConnectionsPage : PhoneApplicationPage
    {
        private enum PageStates { Ready, Connecting}
        public ConnectionsPage()
        {
            InitializeComponent();
            DataContext = App.MainVM;
            string ip = (string)SettingsHelper.GetValue("RecentServerIP");
            if (ip != null)
            {
                var connectionItem = App.MainVM.ConnectionItems.FirstOrDefault(item => item.IpAddress == ip);
                if (connectionItem != null)
                    Connect(connectionItem);
            }
        }

        private void AddConnectionAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AddConnectionPage.xaml", UriKind.Relative));
        }

        private async void ConnectionItemWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ConnectionItem selectedConnection = (ConnectionItem)(sender as StackPanel).DataContext;
            await Connect(selectedConnection);
            
        }

        private void ContextMenuDeleteConnection_Click(object sender, RoutedEventArgs e)
        {
            var t = sender as MenuItem;
            if (t != null)
            {
                ConnectionItem connectionItem = t.DataContext as ConnectionItem;
                App.MainVM.RemoveConnectionItem(connectionItem);
            }
        }

        private void ContextMenuEditConnection_Click(object sender, RoutedEventArgs e)
        {
            var t = sender as MenuItem;
            if (t != null)
            {
                ConnectionItem connectionItem = t.DataContext as ConnectionItem;
                ConnectionManager.CurrentConnection = connectionItem;
                NavigationService.Navigate(new Uri("/Pages/EditConnectionPage.xaml", UriKind.Relative));
            }
        }

        private void SetPageState(PageStates state)
        {
            if (state == PageStates.Connecting)
            {
                ConnectingOverlay.Show();
                ApplicationBar.IsVisible = false;
            }
            else
            {
                ConnectingOverlay.Hide();
                ApplicationBar.IsVisible = true;
            }
        }

        private async Task Connect(ConnectionItem connectionItem)
        {
            SetPageState(PageStates.Connecting);

            bool isSuccessful = await JSONRPC.Ping(connectionItem);
            if (isSuccessful)
            {
                ConnectionManager.CurrentConnection = connectionItem;
                SettingsHelper.SetValue("RecentServerIP", connectionItem.IpAddress);
                NavigationService.Navigate(new Uri("/CoverPage.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Could not reach the server.", "Connection Unsuccessful", MessageBoxButton.OK);
            }
            SetPageState(PageStates.Ready);
        }
    }
}