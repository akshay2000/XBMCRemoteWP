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
        { }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        { }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        { }
    }
}