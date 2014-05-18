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
using XBMCRemoteWP.Models.Audio;
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.Pages.Audio
{
    public partial class AllMusicPivot : PhoneApplicationPage
    {
        private List<Artist> allArtists;
        private List<Album> allAlbums;
        private List<Song> allSongs;
        public AllMusicPivot()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (allArtists == null || allAlbums == null || allSongs == null)
                ReloadAll();
            base.OnNavigatedTo(e);
        }

        private void PlayArtistBorder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Artist tappedArtist = (sender as Border).DataContext as Artist;
            JObject artistToPlay = new JObject(new JProperty("artistid", tappedArtist.ArtistId));
            Player.Open(artistToPlay);
        }

        private void ArtistNameTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Artist tappedArtist = (sender as TextBlock).DataContext as Artist;
            GlobalVariables.CurrentArtist = tappedArtist;
            NavigationService.Navigate(new Uri("/Pages/Audio/ArtistDetailsPanorama.xaml", UriKind.Relative));
        }

        private void AlbumArtWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Album tappedAlbum = (sender as Grid).DataContext as Album;
            JObject albumToPlay = new JObject(new JProperty("albumid", tappedAlbum.AlbumId));
            Player.Open(albumToPlay);
        }

        private void AlbumDetailsWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Album tappedAlbum = (sender as StackPanel).DataContext as Album;
            GlobalVariables.CurrentAlbumId = tappedAlbum.AlbumId;
            NavigationService.Navigate(new Uri("/Pages/Audio/AlbumPage.xaml", UriKind.Relative));
        }

        private void RefreshMusiccAppBarButton_Click(object sender, EventArgs e)
        {
            ReloadAll();
        }

        private async void ReloadAll()
        {

            allArtists = await AudioLibrary.GetArtists();
            AllArtistsLLS.ItemsSource = allArtists;

            JObject sortWith = new JObject(new JProperty("method", "label"));
            allAlbums = await AudioLibrary.GetAlbums(sort: sortWith);
            AllAlbumsLLS.ItemsSource = allAlbums;

            allSongs = await AudioLibrary.GetSongs(sort: sortWith);
            AllSongsLLS.ItemsSource = allSongs;
        }

        private void SongItemWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var tappedSong = (Song)(sender as StackPanel).DataContext;
            JObject item = new JObject(new JProperty("songid", tappedSong.SongId));
            Player.Open(item);
        }

        private async void PartyMusicAppBarButton_Click(object sender, EventArgs e)
        {
            //We need to make sure that the audio player is active before setting partymode on it
            List<Players> activePlayers = await Player.GetActivePlayers();
            if (!activePlayers.Contains(Players.Audio))
            {
                JObject item = new JObject(new JProperty("songid", 1));
                await Player.Open(item);
            }
            await Player.SetPartyMode(Players.Audio, true);
        }
    }
}