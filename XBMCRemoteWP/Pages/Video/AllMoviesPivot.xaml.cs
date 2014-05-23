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
    public partial class AllMoviesPivot : PhoneApplicationPage
    {    
        private List<Movie> allMovies;
        private List<Movie> unwatchedMovies;
        private List<Movie> watchedMovies;

        public AllMoviesPivot()
        {
            InitializeComponent();
            if (allMovies == null)
                LoadMovies();

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

        private void SearchAppBarButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Video/SearchMoviesPage.xaml", UriKind.Relative));
        }

        private async void LoadMovies()
        {
            allMovies = await VideoLibrary.GetMovies();
            AllMoviesLLS.ItemsSource = allMovies;

            unwatchedMovies = allMovies.Where(movie => movie.PlayCount == 0).ToList<Movie>();
            UnwatchedMoviesLLS.ItemsSource = unwatchedMovies;

            watchedMovies = allMovies.Where(movie => movie.PlayCount > 0).ToList<Movie>();
            WatchedMoviesLLS.ItemsSource = watchedMovies;
        }
    }
}