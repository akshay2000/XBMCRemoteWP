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

namespace XBMCRemoteWP
{
    public partial class FirstPage : PhoneApplicationPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ConnectionManager.CurrentConnection = "http://192.168.1.3:8080/jsonrpc?request=";
        }
        private void Player_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Navigation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InputPage.xaml", UriKind.Relative));
        }
    }
}