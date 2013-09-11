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

namespace XBMCRemoteWP.ViewModels
{
    public class ReadMethods
    {
        /// <summary>
        /// This class contains methods for obtaining or 'reading' data from the server.
        /// </summary>

        //Just a shorter representation of ConnectionManager object.
        private ConnectionManagers ConnManager = App.ConnManager;

        //Method returns the active players on the server.
        public async Task<List<Player>> GetActivePlayers()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(ConnManager.CurrentConnection);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
          
            request.Content = new StringContent( "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetActivePlayers\",\"id\":234345}"); //TODO: Need to find a better way to form requests.
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); //Required to be recognized as valid JSON request.

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var res = await response.Content.ReadAsStringAsync();
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

        public async void GetNowPlaying()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(ConnManager.CurrentConnection);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");

            request.Content = new StringContent("{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"artist\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"thumbnail\", \"file\", \"fanart\", \"streamdetails\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}"); //TODO: Need to find a better way to form requests.
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); //Required to be recognized as valid JSON request.

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var res = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Status Code:" + response.StatusCode);
            Debug.WriteLine("Response String:" + res);
        }
    }
}
