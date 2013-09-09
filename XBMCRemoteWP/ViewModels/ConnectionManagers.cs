using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
