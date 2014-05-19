using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Models
{
    public class PlayerItem : NotifyBase
    {
        private string thumbnail;
        public string Thumbnail
        {
            get { return thumbnail; }
            set
            {
                NotifyPropertyChanging("Thumbnail");
                thumbnail = value;
                NotifyPropertyChanged("Thumbnail");
            }
        }

        private string fanart;
        public string Fanart
        {
            get { return fanart; }
            set
            {
                NotifyPropertyChanging("Fanart");
                fanart = value;
                NotifyPropertyChanged("Fanart");
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set 
            {
                NotifyPropertyChanging("Title");
                title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string showTitle; 
        public string ShowTitle
        {
            get { return showTitle; }
            set 
            {
                NotifyPropertyChanging("ShowTitle");
                showTitle = value;
                NotifyPropertyChanged("ShowTitle");
            }
        }

        private string tagline;
        public string Tagline
        {
            get { return tagline; }
            set
            {
                NotifyPropertyChanging("Tagline");
                tagline = value;
                NotifyPropertyChanged("Tagline");
            }
        }

        private List<string> artist;
        public List<string> Artist
        {
            get { return artist; }
            set {
                NotifyPropertyChanging("Artist");
                artist = value;
                NotifyPropertyChanged("Artist");
            }
        }
        public string Label { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }        

    }
}
