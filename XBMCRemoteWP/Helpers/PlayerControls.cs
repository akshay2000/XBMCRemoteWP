using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models;

namespace XBMCRemoteWP.Helpers
{
    class PlayerControls
    {
        /// <summary>
        /// Calls Player.PlayPause to toggle all active players
        /// </summary>
        /// <returns>Player's speed after the operation</returns>
        public async static Task<int?> PlayPausePlayer()
        {
            List<Player> ActivePlayers = await App.ReadMethods.GetActivePlayers();
            int? speed = null; //If no player was active
            foreach (Player p in ActivePlayers)
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
                HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
                string responseString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseString);
                dynamic responseObject = JObject.Parse(responseString);
                speed = responseObject.result.speed;               
            }
            return speed;
        }

        public async static void GoTo(string goTo)
        {
            List<Player> ActivePlayers = await App.ReadMethods.GetActivePlayers();
            foreach (Player p in ActivePlayers)
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
                HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
                string responseString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseString);
                dynamic responseObject = JObject.Parse(responseString);
            }
        }
    }
}
