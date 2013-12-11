﻿using System;
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

namespace XBMCRemoteWP
{
    public partial class MainPage : PhoneApplicationPage
    {
	//Just a dumb comment!
        // Constructor
        public MainPage()
        {
            InitializeComponent();
           
        }

        #region Overrides

        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.ConnManager.CurrentConnection = "http://10.0.0.3:8080/jsonrpc?request=";
            List<Player> ActivePlayers = await App.ReadMethods.GetActivePlayers(); //TODO do something with this list.

            App.ReadMethods.GetNowPlaying();
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
    }
}