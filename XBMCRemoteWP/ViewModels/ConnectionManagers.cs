using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBMCRemoteWP.ViewModels
{
    public class ConnectionManagers
    {
        //Address of current connection
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
