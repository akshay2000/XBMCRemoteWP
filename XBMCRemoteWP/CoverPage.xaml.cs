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
    }
}