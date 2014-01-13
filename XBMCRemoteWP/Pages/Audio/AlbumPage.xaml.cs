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
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.Models.Audio;

namespace XBMCRemoteWP.Pages.Audio
{
    public partial class AlbumPage : PhoneApplicationPage
    {
        public AlbumPage()
        {
            InitializeComponent();
        }

        private List<Song> songsInAlbum;
        private Album currentAlbum;

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string albumId;
            if(NavigationContext.QueryString.TryGetValue("albumId", out albumId))
            {
                JObject filter = new JObject(new JProperty("albumid", int.Parse(albumId)));
                songsInAlbum = await AudioLibrary.GetSongs(filter);
                SongsLLS.ItemsSource = songsInAlbum;

                currentAlbum = await AudioLibrary.GetAlbumDetails(int.Parse(albumId));
                AlbumInfoGrid.DataContext = currentAlbum;
            }
            base.OnNavigatedTo(e);
        }

        private async void SongItemWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Song tappedSong = (sender as StackPanel).DataContext as Song;
            int tappedIndex = songsInAlbum.IndexOf(tappedSong);

            await Playlist.Clear(PlayelistType.Audio);
            JObject itemToAdd = new JObject(
                new JProperty("albumid", currentAlbum.AlbumId));
            await Playlist.Add(PlayelistType.Audio, itemToAdd);

            JObject itemToOpen = new JObject(
                new JProperty("playlistid", 0),
                new JProperty("position", tappedIndex));
            Player.Open(itemToOpen);
        }
    }
}