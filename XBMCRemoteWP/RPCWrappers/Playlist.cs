using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XBMCRemoteWP.RPCWrappers
{
    public enum PlayelistType { Audio, Video, Picture}
    public class Playlist
    {
        public async static Task Add(PlayelistType playlistType, JObject item)
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
            JObject requestObject =
                   new JObject(
                       new JProperty("jsonrpc", "2.0"),
                       new JProperty("id", 234),
                       new JProperty("method", "Playlist.Add"),
                       new JProperty("params",
                           new JObject(
                               new JProperty("item", item),
                               new JProperty("playlistid", playlistId))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JObject.Parse(responseString);
        }

        public async static Task Clear(PlayelistType playlistType)
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
            JObject requestObject =
                   new JObject(
                       new JProperty("jsonrpc", "2.0"),
                       new JProperty("id", 234),
                       new JProperty("method", "Playlist.Clear"),
                       new JProperty("params",
                           new JObject(
                               new JProperty("playlistid", playlistId))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JObject.Parse(responseString);
        }
    }
}
