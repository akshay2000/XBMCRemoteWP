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
using XBMCRemoteWP.RPCWrappers;
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.Models.Audio;

namespace XBMCRemoteWP.Pages.Audio
{
    public partial class ArtistDetailsPanorama : PhoneApplicationPage
    {
        private List<Song> songsList;
        private List<Album> albumsList;
        public ArtistDetailsPanorama()
        {
            InitializeComponent();
            DataContext = GlobalVariables.CurrentArtist;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            JObject filter = new JObject(new JProperty("artistid", GlobalVariables.CurrentArtist.ArtistId));
            songsList = await AudioLibrary.GetSongs(filter);
            SongsLLS.ItemsSource = songsList;
            albumsList = await AudioLibrary.GetAlbums(filter);
            AlbumsLLS.ItemsSource = albumsList;
            base.OnNavigatedTo(e);
        }

        private void AlbumWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Album tappedAlbum = (sender as Grid).DataContext as Album;
            JObject albumToPlay = new JObject(new JProperty("albumid", tappedAlbum.AlbumId));
            Player.Open(albumToPlay);
        }

        private async void SongItemWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Song tappedSong = (sender as StackPanel).DataContext as Song;
            int tappedIndex = songsList.IndexOf(tappedSong);

            await Playlist.Clear(PlayelistType.Audio);
            JObject itemToAdd = new JObject(
                new JProperty("artistid", GlobalVariables.CurrentArtist.ArtistId));
            await Playlist.Add(PlayelistType.Audio, itemToAdd);

            JObject itemToOpen = new JObject(
                new JProperty("playlistid", 0),
                new JProperty("position", tappedIndex));
            await Player.Open(itemToOpen);
        }
    }
}