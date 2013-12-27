using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XBMCRemoteWP.Models.Video
{
    public class Art
    {
        public string Thumb { get; set; }

        [JsonProperty(PropertyName="tvshow.banner")]
        public string Banner { get; set; }

        [JsonProperty(PropertyName="tvshow.fanart")]
        public string Fanart { get; set; }

        [JsonProperty(PropertyName="tvshow.poster")]
        public string Poster { get; set; }
    }

    public class Resume
    {
        public int Position { get; set; }
        public int Total { get; set; }
    }

    public class StreamDetails
    {
        public List<object> Audio { get; set; }
        public List<object> Subtitle { get; set; }
        public List<object> Video { get; set; }
    }

    public class Uniqueid
    {
        public string Unknown { get; set; }
    }

    public class Episode
    {
        public Art Art { get; set; }
        public string DateAdded { get; set; }

        [JsonProperty(PropertyName="director")]
        public List<string> Directors { get; set; }

        [JsonProperty(PropertyName="episode")]
        public int EpisodeNumber { get; set; }
        public int EpisodeId { get; set; }
        public string Fanart { get; set; }
        public string File { get; set; }
        public string FirstAired { get; set; }
        public string Label { get; set; }
        public string LastPlayed { get; set; }
        public string OriginalTitle { get; set; }
        public int PlayCount { get; set; }
        public string Plot { get; set; }
        public string ProductionCode { get; set; }
        public double Rating { get; set; }
        public Resume Resume { get; set; }
        public int Runtime { get; set; }
        public int Season { get; set; }
        public string ShowTitle { get; set; }
        public StreamDetails StreamDetails { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public int TvShowId { get; set; }
        public Uniqueid UniqueId { get; set; }
        public string Votes { get; set; }

        [JsonProperty(PropertyName = "writer")]
        public List<string> Writers { get; set; }
    }
}
