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
            base.OnNavigatedTo(e);
        }

        private async void AlbumWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Album tappedAlbum = (sender as Grid).DataContext as Album;
            string tappedAlbumId = tappedAlbum.AlbumId.ToString();
            NavigationService.Navigate(new Uri("/Pages/Audio/AlbumPage.xaml?albumId=" + tappedAlbumId, UriKind.Relative));
        }
    }
}