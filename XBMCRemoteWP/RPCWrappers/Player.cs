using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Helpers;
using XBMCRemoteWP.Models;

namespace XBMCRemoteWP.RPCWrappers
{
    class Player
    {
        private static JObject defaultPlayerOptions = new JObject(
            new JProperty("repeat", null),
            new JProperty("resume", false),
            new JProperty("shuffled", null));

        /// <summary>
        /// Calls Player.PlayPause to toggle all active players
        /// </summary>
        /// <returns>Player's speed after the operation</returns>
        public async static Task<int?> PlayPausePlayer()
        {
            List<PlayerItem> ActivePlayers = await Player.GetActivePlayers();
            int? speed = null; //If no player was active
            foreach (PlayerItem p in ActivePlayers)
            {
                JObject requestObject =
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234),
                        new JProperty("method", "Player.PlayPause"),
                        new JProperty("params",
                            new JObject(
                            new JProperty("playerid", p.PlayerId))));
                string requestData = requestObject.ToString();
                HttpResponseMessage response = await ConnectionManager.ExecuteRequest(requestData);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JObject.Parse(responseString);
                speed = responseObject.result.speed;               
            }
            return speed;
        }

        public static async Task<dynamic> GetItem(int playerId)
        {
            JObject requestObject =
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234),
                        new JProperty("method", "Player.GetItem"),
                        new JProperty("params",
                            new JObject(
                            new JProperty("playerid", playerId),
                            new JProperty("properties",
                                new JArray("title", "album", "artist", "season", "episode", "duration", "showtitle", "tvshowid", "thumbnail", "file", "fanart", "streamdetails")))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await ConnectionManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseString);
            dynamic responseObject = JObject.Parse(responseString);
            return responseObject;
        }

        public async static Task<List<PlayerItem>> GetActivePlayers()
        {
            JObject requestObject =
                new JObject(
                    new JProperty("jsonrpc", "2.0"),
                    new JProperty("id", 234),
                    new JProperty("method", "Player.GetActivePlayers"));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await ConnectionManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JArray activePlayersList = (JArray)responseObject["result"];
            List<PlayerItem> listToReturn = activePlayersList.ToObject<List<PlayerItem>>();
            return listToReturn;
        }

        public async static void GoTo(string goTo)
        {
            List<PlayerItem> ActivePlayers = await Player.GetActivePlayers();
            foreach (PlayerItem p in ActivePlayers)
            {
                JObject requestObject = 
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234),
                        new JProperty("method", "Player.GoTo"),
                        new JProperty("params",
                            new JObject(
                            new JProperty("playerid", p.PlayerId),
                            new JProperty("to", goTo))));
                string requestData = requestObject.ToString();
                HttpResponseMessage response = await ConnectionManager.ExecuteRequest(requestData);
                string responseString = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JObject.Parse(responseString);
            }
        }

        public async static Task Open(JObject item, JObject options = null)
        {
            if (options == null)
                options = defaultPlayerOptions;

            JObject requestObject =
                   new JObject(
                       new JProperty("jsonrpc", "2.0"),
                       new JProperty("id", 234),
                       new JProperty("method", "Player.Open"),
                       new JProperty("params",
                           new JObject(
                               new JProperty("item", item),
                               new JProperty("options", options))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await ConnectionManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            dynamic responseObject = JObject.Parse(responseString);
        }
    }
}
