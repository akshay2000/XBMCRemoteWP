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
            List<Player> ActivePlayers = await App.ReadMethods.GetActivePlayers(); //TODO do something with this list.
            dynamic nowPlaying = await ReadMethods.GetNowPlaying(0);

            //Let's update UI.
            string imgPath = nowPlaying.result.item.thumbnail;
            var t = imgPath.Substring(8);
            var encodedt = HttpUtility.UrlEncode(t);
            var thumbnailUrl = "http://192.168.1.3:8080/image/image://" + encodedt;
            AlbumArtImage.Source = new BitmapImage(new Uri(thumbnailUrl));

            //App.ReadMethods.GetNowPlaying();
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
            int? playerSpeed = await PlayerControls.PlayPausePlayer();
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
            PlayerControls.GoTo("previous");
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerControls.GoTo("next");
        }
    }
}