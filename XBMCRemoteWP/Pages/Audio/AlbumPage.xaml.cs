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

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            string albumId;
            if(NavigationContext.QueryString.TryGetValue("albumId", out albumId))
            {
                JObject filter = new JObject(new JProperty("albumid", int.Parse(albumId)));
                List<Song> songsInAlbum = await AudioLibrary.GetSongs(filter);
                SongsLLS.ItemsSource = songsInAlbum;

                Album currentAlbum = await AudioLibrary.GetAlbumDetails(int.Parse(albumId));
                AlbumInfoGrid.DataContext = currentAlbum;
            }
            base.OnNavigatedTo(e);
        }
    }
}