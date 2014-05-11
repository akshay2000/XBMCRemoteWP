﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Helpers;

namespace XBMCRemoteWP.RPCWrappers
{
    public enum PlayelistType { Audio, Video, Picture}
    public class Playlist
    {
        public async static Task Add(PlayelistType playlistType, JObject item)
        {
            int playlistId = GetPlaylistId(playlistType);
            JObject parameters = new JObject(
                               new JProperty("item", item),
                               new JProperty("playlistid", playlistId));

            await ConnectionManager.ExecuteRPCRequest("Playlist.Add", parameters);
        }

        public async static Task Clear(PlayelistType playlistType)
        {
            int playlistId = GetPlaylistId(playlistType);
            JObject parameters = new JObject(
                                new JProperty("playlistid", playlistId));
            await ConnectionManager.ExecuteRPCRequest("Playlist.Clear", parameters);
        }

        private static int GetPlaylistId(PlayelistType playlistType)
        {
            int playlistId;
            switch (playlistType)
            {
                case PlayelistType.Video:
                    playlistId = 1;
                    break;
                case PlayelistType.Picture:
                    playlistId = 2;
                    break;
                case PlayelistType.Audio:
                default:
                    playlistId = 0;
                    break;
            }
            return playlistId;
        }
    }
}
