using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XBMCRemoteWP.Models.Video;
using XBMCRemoteWP.RPCWrappers;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Pages.Video
{
    public partial class AllMoviesPage : PhoneApplicationPage
    {
        private List<Movie> allMovies;
        public AllMoviesPage()
        {
            InitializeComponent();
            if(allMovies == null)
                LoadMovies();
        }

        private async void LoadMovies()
        {
            allMovies = await VideoLibrary.GetMovies();
            AllMoviesLLS.ItemsSource = allMovies;
        }

        private void MovieWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Movie tappedMovie = (sender as Grid).DataContext as Movie;
            GlobalVariables.CurrentMovie = tappedMovie;
            NavigationService.Navigate(new Uri("/Pages/Video/MovieDetailsPanorama.xaml", UriKind.Relative));
        }

        private void RefreshAppBarButton_Click(object sender, EventArgs e)
        {
            LoadMovies();
        }
    }
}