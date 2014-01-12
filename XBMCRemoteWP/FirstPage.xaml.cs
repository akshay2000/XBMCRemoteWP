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
using XBMCRemoteWP.Models;

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
            ConnectionManager.CurrentConnection = new ConnectionItem
            {
                ConnectionName = "Test",
                IpAddress = "10.0.0.3",
                Port = 8080
            };
        }
        private void Player_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void Navigation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/InputPage.xaml", UriKind.Relative));
        }

        private void Cover_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/CoverPage.xaml", UriKind.Relative));
        }

        private void Connections_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConnectionsPage.xaml", UriKind.Relative));
        }

        private void Album_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Audio/AlbumPage.xaml", UriKind.Relative));
        }
    }
}