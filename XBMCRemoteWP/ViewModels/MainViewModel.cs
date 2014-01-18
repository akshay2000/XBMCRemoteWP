using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models;

namespace XBMCRemoteWP.ViewModels
{
    public class MainViewModel : NotifyBase
    {
        private MainDataContext mainDB;
        public MainViewModel(string dbConnectionString)
        { 
            mainDB = new MainDataContext(dbConnectionString);
            LoadConnections();
        }

        private ObservableCollection<ConnectionItem> _connectionItems;
        public ObservableCollection<ConnectionItem> ConnectionItems
        {
            get { return _connectionItems; }
            set
            {
                if (_connectionItems != value)
                {
                    _connectionItems = value;
                    NotifyPropertyChanged("ConnectionItems");
                }
            }
        }

        public void LoadConnections()
        {
            var connectionsInDb = from ConnectionItem conn in mainDB.ConnectionItems
                                  select conn;
            ConnectionItems = new ObservableCollection<ConnectionItem>(connectionsInDb);
        }

        public void SubmitChanges()
        {
            mainDB.SubmitChanges();
        }

        public void AddConnectionItem(ConnectionItem itemToAdd)
        {
            mainDB.ConnectionItems.InsertOnSubmit(itemToAdd);
            mainDB.SubmitChanges();
            ConnectionItems.Add(itemToAdd);
        }

        public void RemoveConnectionItem(ConnectionItem itemToRemove)
        {
            mainDB.ConnectionItems.DeleteOnSubmit(itemToRemove);
            mainDB.SubmitChanges();
            ConnectionItems.Remove(itemToRemove);
        }

        public void UpdateConnectionItem(ConnectionItem itemToUpdate)
        {
            mainDB.SubmitChanges();
        }
    }
}
