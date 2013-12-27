using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBMCRemoteWP.Models
{
    [Table]
    public class ConnectionItem : NotifyBase
    {
        private int connectionId;
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int ConnectionId
        {
            get { return connectionId; }
            set { 
                if( connectionId != value)
                {
                    NotifyPropertyChanging("ConnectionId");
                    connectionId = value;
                    NotifyPropertyChanged("ConnectionId");
                }
            }
        }

        private string connectionName;
        [Column]
        public string ConnectionName
        {
            get { return connectionName; }
            set
            {
                if (connectionName != value)
                {
                    NotifyPropertyChanging("ConnectionName");
                    connectionName = value;
                    NotifyPropertyChanged("ConnectionName");
                }
            }
        }
        

        
        private string ipAddress;
        [Column]
        public string IpAddress
        {
            get { return ipAddress; }
            set {
                if (ipAddress != value)
                {
                    NotifyPropertyChanging("IpAddress");
                    ipAddress = value;
                    NotifyPropertyChanged("IpAddress");
                }
            }
        }

        private int port;
        [Column]
        public int Port
        {
            get { return port; }
            set
            {
                if (port != value)
                {
                    NotifyPropertyChanging("Port");
                    port = value;
                    NotifyPropertyChanged("Port");

                }
            }
        }

        private string username;
        [Column]
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    NotifyPropertyChanging("Username");
                    username = value;
                    NotifyPropertyChanged("Username");
                }
            }
        }

        private string password;
        [Column]
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    NotifyPropertyChanging("Password");
                    password = value;
                    NotifyPropertyChanged("Password");
                }
            }
        }      
    }
}

