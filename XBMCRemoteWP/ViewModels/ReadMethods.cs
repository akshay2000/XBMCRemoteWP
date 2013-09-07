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
        private ConnectionManagers ConnManager = App.ConnManager;

        public async void GetActivePlayers()
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(ConnManager.CurrentConnection);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
          
            request.Content = new StringContent( "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetActivePlayers\",\"id\":234345}");
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var res = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(response.StatusCode);
            Debug.WriteLine(res);
        }
    }
}
