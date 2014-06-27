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
using XBMCRemoteWP.Helpers;
using XBMCRemoteWP.Models.Video;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Pages.Video
{
    public partial class SearchTVShowsPage : PhoneApplicationPage
    {
        private List<TVShow> AllTVShows;
        private List<TVShow> FilteredTVShows;
        public SearchTVShowsPage()
        {
            InitializeComponent();
        }

        private void SearchTVShowsTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            SearchTVShowsTextBox.Focus();
        }

        private void SearchTVShowsTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchTVShowsLLS.Focus();
                SearchAndReload(SearchTVShowsTextBox.Text);
            }
        }

        private async void SearchAndReload(string query)
        {
            ConnectionManager.ManageSystemTray(true);
            if (AllTVShows == null)
                AllTVShows = await VideoLibrary.GetTVShows();

            FilteredTVShows = AllTVShows.Where(t => t.Title.ToLower().Contains(query.ToLower())).ToList();
            SearchTVShowsLLS.ItemsSource = FilteredTVShows;
            ConnectionManager.ManageSystemTray(false);
        }

        private void TVShowWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TVShow tappedTVShow = (sender as Grid).DataContext as TVShow;
            GlobalVariables.CurrentTVShow = tappedTVShow;
            NavigationService.Navigate(new Uri("/Pages/Video/TVShowDetailsPanorama.xaml", UriKind.Relative));
        }
    }
}