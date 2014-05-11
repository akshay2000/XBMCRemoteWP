using Newtonsoft.Json.Linq;
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
        public async static void RefreshNowPlaying()
        {
            var activePlayers = await Player.GetActivePlayers();
            if (activePlayers.Count == 1)
            {
                if (GlobalVariables.NowPlaying == null)
                    GlobalVariables.NowPlaying = new NowPlayingItem();

                JObject player = await Player.GetItem(activePlayers[0]);
                JObject playerResult = (JObject)player["result"]["item"];

                GlobalVariables.NowPlaying.PlayerType = activePlayers[0];
                GlobalVariables.NowPlaying.Title = playerResult["title"].ToString();
                GlobalVariables.NowPlaying.Thumbnail = playerResult["thumbnail"].ToString();
                GlobalVariables.NowPlaying.Fanart = playerResult["fanart"].ToString();
                if (playerResult["type"].ToString() == "movie")
                {
                    GlobalVariables.NowPlaying.Subtitle = playerResult["tagline"].ToString();
                }
                else if (playerResult["type"].ToString() == "episode")
                {
                    GlobalVariables.NowPlaying.Subtitle = playerResult["showtitle"].ToString();
                }
                else if (playerResult["type"].ToString() == "song")
                {
                    GlobalVariables.NowPlaying.Subtitle = ((JArray)playerResult["artist"])[0].ToString();
                }
            }
        }
    }
}
