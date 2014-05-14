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

namespace XBMCRemoteWP
{
    public partial class InputPage : PhoneApplicationPage
    {
        int[] Speeds = { -32, -16, -8, -4, -2, -1, 1, 2, 4, 8, 16, 32 };
        public InputPage()
        {
            InitializeComponent();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Left);
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Up);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Right);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Down);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Home);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.ContextMenu);
        }

        private void OSDButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.ShowOSD);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Info);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Select);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Back);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo(GlobalVariables.NowPlaying.PlayerType, GoTo.Next);
        }

        private async void SpeedDownButton_Click(object sender, RoutedEventArgs e)
        {
            JObject result = await Player.GetProperties(GlobalVariables.NowPlaying.PlayerType, new JArray("speed"));
            int speed = (int)result["speed"];

            if (speed != 0 && speed != -32)
            {
                int index = Array.IndexOf(Speeds, speed);
                int newSpeed = Speeds[index - 1];
                await Player.SetSpeed(GlobalVariables.NowPlaying.PlayerType, newSpeed);
            }

        }
        
        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            Player.PlayPause(GlobalVariables.NowPlaying.PlayerType);
        }

        private async void SpeedUpButton_Click(object sender, RoutedEventArgs e)
        {
            JObject result = await Player.GetProperties(GlobalVariables.NowPlaying.PlayerType, new JArray("speed"));
            int speed = (int)result["speed"];

            if (speed != 0 && speed != 32)
            {
                int index = Array.IndexOf(Speeds, speed);
                int newSpeed = Speeds[index + 1];
                await Player.SetSpeed(GlobalVariables.NowPlaying.PlayerType, newSpeed);
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Player.GoTo(GlobalVariables.NowPlaying.PlayerType, GoTo.Next);
        }

        private async void VolumeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            JObject result = await Applikation.GetProperties();
            int volume = (int)result["volume"];
            VolumeSlider.Value = volume;
        }

        private async void VolumeSlider_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            double doubleValue = VolumeSlider.Value;
            int value = (int)Math.Round(doubleValue);
            int newValue = await Applikation.SetVolume(value);
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}