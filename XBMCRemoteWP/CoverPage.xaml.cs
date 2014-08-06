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
using XBMCRemoteWP.Models.Common;
using XBMCRemoteWP.Models.Audio;
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.Helpers;
using XBMCRemoteWP.Models.Video;
using System.Windows.Media.Imaging;
using XBMCRemoteWP.Models;
using System.Windows.Threading;

namespace XBMCRemoteWP
{
    public partial class CoverPage : PhoneApplicationPage
    {
        private List<Album> albums;
        private List<Episode> episodes;
        private List<Movie> movies;

        private DispatcherTimer timer;

        public CoverPage()
        {
            InitializeComponent();
            if (GlobalVariables.CurrentPlayerState == null)
                GlobalVariables.CurrentPlayerState = new PlayerState();
            DataContext = GlobalVariables.CurrentPlayerState;

            PlayerHelper.RefreshPlayerState();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Start();
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            PlayerHelper.RefreshPlayerState();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {

            if (albums == null)
            {
                albums = await AudioLibrary.GetRecentlyAddedAlbums(new Limits { Start = 0, End = 12 });
                MusicLLS.ItemsSource = albums;
            }

            if (episodes == null)
            {
                episodes = await VideoLibrary.GetRecentlyAddedEpisodes(new Limits { Start = 0, End = 10 });
                TVShowsLLS.ItemsSource = episodes;
            }

            if (movies == null)
            {
                movies = await VideoLibrary.GetRecentlyAddedMovies(new Limits { Start = 0, End = 15 });
                MoviesLLS.ItemsSource = movies;
            }

            base.OnNavigatedTo(e);
        }

        private void AlbumWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Album tappedAlbum = (sender as Grid).DataContext as Album;
            int tappedAlbumId = tappedAlbum.AlbumId;
            GlobalVariables.CurrentAlbumId = tappedAlbumId;
            NavigationService.Navigate(new Uri("/Pages/Audio/AlbumPage.xaml", UriKind.Relative));
        }

        private void AllMusicTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Audio/AllMusicPivot.xaml", UriKind.Relative));
        }

        private void EpisodeWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Episode tappedEpisode = (sender as Grid).DataContext as Episode;
            JObject episodeToOpen = new JObject(new JProperty("episodeid", tappedEpisode.EpisodeId));
            Player.Open(episodeToOpen);
        }

        private void AllTVTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Video/AllTVShowsPage.xaml", UriKind.Relative));
        }

        private void MovieWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Movie tappedMovie = (sender as Grid).DataContext as Movie;
            GlobalVariables.CurrentMovie = tappedMovie;
            NavigationService.Navigate(new Uri("/Pages/Video/MovieDetailsPanorama.xaml", UriKind.Relative));
        }

        private void AllMoviesTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Video/AllMoviesPivot.xaml", UriKind.Relative));
        }

        private void RemoteMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/InputPage.xaml", UriKind.Relative));
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
        }

        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            await Player.GoTo(GlobalVariables.CurrentPlayerState.PlayerType, GoTo.Previous);
            await PlayerHelper.RefreshPlayerState();
        }

        private async void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            await Player.PlayPause(GlobalVariables.CurrentPlayerState.PlayerType);
            await PlayerHelper.RefreshPlayerState();
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            await Player.GoTo(GlobalVariables.CurrentPlayerState.PlayerType, GoTo.Next);
            await PlayerHelper.RefreshPlayerState();
        }
    }
}