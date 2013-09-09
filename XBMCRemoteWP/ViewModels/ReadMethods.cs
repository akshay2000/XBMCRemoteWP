using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

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
        public async void GetActivePlayers()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(ConnManager.CurrentConnection);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
          
            request.Content = new StringContent( "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetActivePlayers\",\"id\":234345}"); //TODO: Need to find a better way to form requests.
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); //Required to be recognized as valid JSON request.

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var res = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(response.StatusCode);   //TODO: Do something fruitful with the response.
            Debug.WriteLine(res);
        }
    }
}
