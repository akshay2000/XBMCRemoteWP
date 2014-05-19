﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Helpers
{
    public class PlayerHelper
    {
        public static async Task RefreshPlayerState()
        {
            var activePlayers = await Player.GetActivePlayers();
            if (activePlayers.Count == 1)
            {
                GlobalVariables.CurrentPlayerState.PlayerType = activePlayers[0];
                await RefreshPlayerItem(activePlayers[0]);
                await RefreshPlayerProperties(activePlayers[0]);
            }
            else if (activePlayers.Count == 0)
            {
                GlobalVariables.CurrentPlayerState.CurrentPlayerItem = new PlayerItem { Title = "nothing is playing" };
                GlobalVariables.CurrentPlayerState.PlayerType = Players.None;
            }
        }

        private static async Task RefreshPlayerItem(Players player)
        {
            PlayerItem item = await Player.GetItem(player);
            GlobalVariables.CurrentPlayerState.CurrentPlayerItem = item;
        }

        private static async Task RefreshPlayerProperties(Players player)
        {
            PlayerProperties properties = await Player.GetProperties(player);
            GlobalVariables.CurrentPlayerState.CurrentPlayerProperties = properties;
        }
    }
}
