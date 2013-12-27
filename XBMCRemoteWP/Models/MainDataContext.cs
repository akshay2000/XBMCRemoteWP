using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBMCRemoteWP.Models
{
    public class MainDataContext : DataContext
    {
        public MainDataContext(string connectionString) : base(connectionString) { }

        public Table<ConnectionItem> ConnectionItems;
    }
}