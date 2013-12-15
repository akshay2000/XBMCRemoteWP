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
    public class ConnectionManager
    {
        /// <summary>
        /// Class for providing methods and members related to making and maintaining connections to the server.
        /// An object is created from this class at the app initiation time (see App.xaml.cs) and used universally across the app.
        /// </summary>
        /// 

        //consteuctor
        public ConnectionManager()
        { }

        //Property holding the connection address of currently connected server.
        private static string _currentConnection;
        public static string CurrentConnection
        {
            get
            {
                return _currentConnection;
            }
            set
            {
                if (_currentConnection != value)
                {
                    _currentConnection = value;
                }
            }
        }

        public async Task<HttpResponseMessage> ExecuteRequest(string requestData)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(ConnectionManager.CurrentConnection);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");

            request.Content = new StringContent(requestData);
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"); //Required to be recognized as valid JSON request.
            
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return response;            
        }

        ///Network service discovery is supposed to happen here.
        ///XBMC announces it's JSON-RPC availability over zeroconf and string is "_http._tcp"
        ///Pseudo code is written below. Zeroconf is nicely provided by project here: https://github.com/onovotny/Zeroconf
       
        //public async Task<List<string>> GetAvailableServers()
        //{
        //    var list = zaroconf.searchforservers("_http._tcp");
        //    return list;
        //}

        ///The Zeroconf there doesn't support Windows Phone 7 (bummer).
        ///Looks like we'll have to implement an UI to do the job.
    }
}
