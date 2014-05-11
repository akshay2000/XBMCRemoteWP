using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Models
{
    public class NowPlayingItem : NotifyBase
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

        private string subtitle; 
        public string Subtitle
        {
            get { return subtitle; }
            set 
            {
                NotifyPropertyChanging("Subitle");
                subtitle = value;
                NotifyPropertyChanged("Subtitle");
            }
        }

        public Players PlayerType { get; set; }
    }
}
