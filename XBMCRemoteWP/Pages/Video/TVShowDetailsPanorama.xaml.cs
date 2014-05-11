using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using XBMCRemoteWP.Helpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using XBMCRemoteWP.Models.Video;
using XBMCRemoteWP.RPCWrappers;

namespace XBMCRemoteWP.Pages.Video
{
    public partial class TVShowDetailsPanorama : PhoneApplicationPage
    {     
        public TVShowDetailsPanorama()
        {
            InitializeComponent();
            DataContext = GlobalVariables.CurrentTVShow;

            LoadEpisodes();
        }

        private async void LoadEpisodes()
        {
            JObject filter = new JObject(new JProperty("tvshowid", GlobalVariables.CurrentTVShow.TvShowId));
            List<Episode> episodes = await VideoLibrary.GetEpisodes(tvShowID: GlobalVariables.CurrentTVShow.TvShowId);

            List<SeasonItem<Episode>> seasons = GroupEpisodes<Episode>(episodes, epi => epi.Season);         
            SeasonsLLS.ItemsSource = seasons;
        }

        private List<SeasonItem<T>> GroupEpisodes<T>(IEnumerable<T> items, Func<T, int> getKeyFunc)
        {
            IEnumerable<SeasonItem<T>> group = from item in items
                                                   group item by getKeyFunc(item) into g
                                                   orderby g.Key
                                                   select new SeasonItem<T>(g.Key, g);
            return group.ToList();
        }

        private class SeasonItem<T> : List<T>
        {
            public SeasonItem(int key, IEnumerable<T> items)
                : base(items)
            {
                this.SeasonKey = key;
            }
            public int SeasonKey { get; private set; }
        }

        private void EpisodeWrapper_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var tappedEpisode = (sender as StackPanel).DataContext as Episode;
            JObject episodeToPlay = new JObject(new JProperty("episodeid", tappedEpisode.EpisodeId));
            Player.Open(episodeToPlay);
        }
    }
}