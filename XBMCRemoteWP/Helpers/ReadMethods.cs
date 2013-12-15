using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models;

namespace XBMCRemoteWP.Helpers
{
    public class ReadMethods
    {
        /// <summary>
        /// This class contains methods for obtaining or 'reading' data from the server.
        /// </summary>

        //Just a shorter representation of ConnectionManager object.
        private static ConnectionManager ConnManager = App.ConnManager;

        //Method returns the active players on the server.
        public async Task<List<Player>> GetActivePlayers()
        {
            JObject requestObject = JObject.FromObject(new
                {
                    jsonrpc = "2.0",
                    id = 234,
                    method = "Player.GetActivePlayers"
                });
            string requestData = requestObject.ToString();

            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            
            string res = await response.Content.ReadAsStringAsync();
                        
            Debug.WriteLine("Status Code:" + response.StatusCode);
            Debug.WriteLine("Response String:" + res);

            PlayerListReturn jsonResponse = JsonConvert.DeserializeObject<PlayerListReturn>(res);
            return jsonResponse.Result;
            //List<Player> templist = new List<Player>();
            //foreach (var element in jsonResponse.Result)
            //{
            //    var s = Convert.ToString(element);
            //    var t = JsonConvert.DeserializeObject<Player>(s);
            //    templist.Add(t);
            //}
            //foreach (var element in templist)
            //{
            //    Debug.WriteLine(element.Type);
            //}
        }

        public static async Task<dynamic> GetNowPlaying(int playerId)
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
                HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
                string responseString = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseString);
                dynamic responseObject = JObject.Parse(responseString);
                return responseObject;
        }
    }
}
