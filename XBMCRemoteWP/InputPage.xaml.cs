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

namespace XBMCRemoteWP
{
    public partial class InputPage : PhoneApplicationPage
    {
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

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Select);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Home);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Back);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.ShowCodec);
        }

        private void OSDButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.ShowOSD);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommands.Info);
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Input.ExecuteAction(InputCommand.Text);
        }
    }
}