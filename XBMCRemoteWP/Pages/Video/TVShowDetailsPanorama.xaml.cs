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

namespace XBMCRemoteWP.Pages.Video
{
    public partial class TVShowDetailsPanorama : PhoneApplicationPage
    {
        public TVShowDetailsPanorama()
        {
            InitializeComponent();
            DataContext = GlobalVariables.CurrentTVShow;
        }
    }
}