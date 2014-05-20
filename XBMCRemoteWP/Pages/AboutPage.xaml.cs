using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace XBMCRemoteWP.Pages
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void DevProfile_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "akshay2000";
            marketplaceSearchTask.Show();
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Subject = "XBMC Assist for Windows Phone";
            emailTask.To = "appsupport@indestructible.in";
            emailTask.Show();
        }

        private void RateApp_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask rateApp = new MarketplaceReviewTask();
            rateApp.Show();
        }
    }
}