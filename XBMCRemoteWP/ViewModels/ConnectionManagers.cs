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
    public class ConnectionManagers
    {
        /// <summary>
        /// Class for providing methods and members related to making and maintaining connections to the server.
        /// An object is created from this class at the app initiation time (see App.xaml.cs) and used universally across the app.
        /// </summary>

        //Property holding the connection address of currently connected server.
        private string _currentConnection;
        public string CurrentConnection
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

        ///Network service discovery is supposed to happen here.
        ///XBMC announces it's JSON-RPC availability over zeroconf and string is "_http._tcp"
        ///Pseudo code is written below. Zeroconf is nicely provided by project here: https://github.com/onovotny/Zeroconf
       
        //public async Task<List<string>> GetAvailableServers()
        //{
        //    var list = zaroconf.searchforservers("_http._tcp");
        //    return list;
        //}
    }
}
