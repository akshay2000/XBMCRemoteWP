using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using XBMCRemoteWP.Models;
using XBMCRemoteWP.Helpers;
using System.Windows.Media.Imaging;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP
{
    public partial class MainPage : PhoneApplicationPage
    {

        static ImageSource PlayIcon = new BitmapImage(new Uri("/Assets/Glyphs/appbar.transport.play.rest.png", UriKind.Relative));
        static ImageSource PauseIcon = new BitmapImage(new Uri("/Assets/Glyphs/appbar.transport.pause.rest.png", UriKind.Relative));
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           
        }

        #region Overrides

        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);            
            List<PlayerItem> ActivePlayers = await Player.GetActivePlayers();
            dynamic nowPlaying = await Player.GetItem(ActivePlayers[0].PlayerId);

            //Let's update UI.
            string imgPath = nowPlaying.result.item.thumbnail;
            var t = imgPath.Substring(8);
            var encodedt = HttpUtility.UrlEncode(t);
            var thumbnailUrl = "http://192.168.1.4:8080/image/image://" + encodedt;
            AlbumArtImage.Source = new BitmapImage(new Uri(thumbnailUrl));
        }

        #endregion

        #region Appbar buttons and menus

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SettingsPage.xaml", UriKind.Relative));
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
        }

        #endregion

        private async void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            int? playerSpeed = await Player.PlayPausePlayer();
            switch (playerSpeed)
            {
                case 0:
                    PlayPauseButton.ImageSource = PlayIcon;
                    break;
                case 1:
                    PlayPauseButton.ImageSource = PauseIcon;
                    break;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo("previous");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo("next");
        }
    }
}