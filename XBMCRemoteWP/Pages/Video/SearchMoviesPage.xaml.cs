using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using XBMCRemoteWP.Models.Video;
using XBMCRemoteWP.RPCWrappers;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Pages.Video
{
    public partial class SearchMoviesPage : PhoneApplicationPage
    {
        private List<Movie> allMovies;
        private List<Movie> filteredMovies;
        public SearchMoviesPage()
        {
            InitializeComponent();
        }
        
        private void SearchMoviesTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchMoviesLLS.Focus();
                SearchAndReload(SearchMoviesTextBox.Text);
            }
        }

        private async void SearchAndReload(string query)
        {
            ConnectionManager.ManageSystemTray(true);
            if(allMovies == null)
                allMovies = await VideoLibrary.GetMovies();

            filteredMovies = allMovies.Where(t => t.Title.ToLower().Contains(query.ToLower())).ToList();
            SearchMoviesLLS.ItemsSource = filteredMovies;
            ConnectionManager.ManageSystemTray(false);
        }

        private void SearchMoviesTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            SearchMoviesTextBox.Focus();
        }

        private void MovieWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Movie tappedMovie = (sender as Grid).DataContext as Movie;
            GlobalVariables.CurrentMovie = tappedMovie;
            NavigationService.Navigate(new Uri("/Pages/Video/MovieDetailsPanorama.xaml", UriKind.Relative));
        }
    }
}