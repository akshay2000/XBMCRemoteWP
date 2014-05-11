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
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Pages.Video
{
    public partial class MovieDetailsPanorama : PhoneApplicationPage
    {
        public MovieDetailsPanorama()
        {
            InitializeComponent();
            DataContext = GlobalVariables.CurrentMovie;
        }

        private void PlayMovieAppBarButton_Click(object sender, EventArgs e)
        {
            JObject movieToPlay = new JObject(new JProperty("movieid", GlobalVariables.CurrentMovie.MovieId));
            Player.Open(movieToPlay);
        }
    }
}