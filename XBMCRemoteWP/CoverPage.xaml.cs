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

namespace XBMCRemoteWP
{
    public partial class CoverPage : PhoneApplicationPage
    {
        public CoverPage()
        {
            InitializeComponent();
            if (GlobalVariables.NowPlaying == null)
                GlobalVariables.NowPlaying = new NowPlayingItem();
            NowPlayingGrid.DataContext = GlobalVariables.NowPlaying;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            PlayerHelper.RefreshNowPlaying();

            var albums = await AudioLibrary.GetRecentlyAddedAlbums(new Limits { Start = 0, End = 8 });
            MusicLLS.ItemsSource = albums;

            var episodes = await VideoLibrary.GetRecentlyAddedEpisodes(new Limits { Start = 0, End = 8 });
            TVShowsLLS.ItemsSource = episodes;

            var movies = await VideoLibrary.GetRecentlyAddedMovies(new Limits { Start = 0, End = 6 });
            MoviesLLS.ItemsSource = movies;
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
            NavigationService.Navigate(new Uri("/Pages/Video/AllMoviesPage.xaml", UriKind.Relative));
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

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo(GlobalVariables.NowPlaying.PlayerType, GoTo.Previous);
            PlayerHelper.RefreshNowPlaying();
        }

        private async void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            int speed = await Player.PlayPause(GlobalVariables.NowPlaying.PlayerType);
            if (speed == 0)
                PlayPauseButton.ImageSource = new BitmapImage(new Uri("/Assets/Glyphs/appbar.transport.play.rest.png", UriKind.Relative));
            else
                PlayPauseButton.ImageSource = new BitmapImage(new Uri("/Assets/Glyphs/appbar.transport.pause.rest.png", UriKind.Relative));
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo(GlobalVariables.NowPlaying.PlayerType, GoTo.Next);
            PlayerHelper.RefreshNowPlaying();
        }
    }
}