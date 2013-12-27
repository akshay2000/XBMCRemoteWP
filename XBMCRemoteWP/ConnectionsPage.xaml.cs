using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

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
    }
}