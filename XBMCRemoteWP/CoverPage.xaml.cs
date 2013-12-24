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

namespace XBMCRemoteWP
{
    public partial class CoverPage : PhoneApplicationPage
    {
        public CoverPage()
        {
            InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var t = await AudioLibrary.GetRecentlyAddedAlbums();
            MusicLLS.ItemsSource = t;
            base.OnNavigatedTo(e);
        }
    }
}