using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models.Audio;
using XBMCRemoteWP.Models.Common;

namespace XBMCRemoteWP.RPCWrappers
{
    public class AudioLibrary
    {
        private static Limits defaultLimits = new Limits { Start = 0, End = 2147483647 };

        public static async Task<Album> GetAlbumDetails(int albumid)
        {
            JObject requestObject =
                   new JObject(
                       new JProperty("jsonrpc", "2.0"),
                       new JProperty("id", 234),
                       new JProperty("method", "AudioLibrary.GetAlbumDetails"),
                       new JProperty("params",
                           new JObject(
                               new JProperty("albumid", albumid),
                               new JProperty("properties",
                                   new JArray("title", "description", "artist", "genre", "theme", "mood", "style", "type", "albumlabel", "rating", "year", "musicbrainzalbumid", "musicbrainzalbumartistid", "fanart", "thumbnail", "playcount", "genreid", "artistid", "displayartist")
                                   )
                                       )));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JObject albumJSON = (JObject)responseObject["result"]["albumdetails"];
            Album albumToRetun = albumJSON.ToObject<Album>();
            return albumToRetun;

        }
        public static async Task<List<Album>> GetRecentlyAddedAlbums(Limits limits = null)
        {
            JObject requestObject =
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234),
                        new JProperty("method", "AudioLibrary.GetRecentlyAddedAlbums"),
                        new JProperty("params",
                            new JObject(
                                new JProperty("properties",
                                    new JArray("title", "description", "artist", "genre", "theme", "mood", "style", "type", "albumlabel", "rating", "year", "musicbrainzalbumid", "musicbrainzalbumartistid", "fanart", "thumbnail", "playcount", "genreid", "artistid", "displayartist")
                                    ))));

            if (limits != null)
            {
                requestObject["params"]["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JArray albumListObject = (JArray)responseObject["result"]["albums"];
            List<Album> listToReturn = albumListObject.ToObject<List<Album>>();
            return listToReturn;
        }

        public static async Task<List<Song>> GetSongs(JObject filter = null, Limits limits = null)
        {    
            JObject requestObject =
                        new JObject(
                            new JProperty("jsonrpc", "2.0"),
                            new JProperty("id", 234),
                            new JProperty("method", "AudioLibrary.GetSongs"),
                            new JProperty("params",
                                new JObject(
                                    new JProperty("properties",
                                        new JArray("album", "albumartist", "albumartistid", "albumid", "comment", "disc", "duration", "file", "lastplayed", "lyrics", "musicbrainzartistid", "musicbrainztrackid", "playcount", "track"))
                                            )));

            if (limits != null)
            {
                requestObject["params"]["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if(filter!=null)
            {
                requestObject["params"]["filter"] = filter;
            }
       
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JArray songListObject = (JArray)responseObject["result"]["songs"];
            List<Song> listToReturn = songListObject.ToObject<List<Song>>();
            return listToReturn;
        }

        public static async Task<List<Artist>> GetArtists(JObject filter = null, Limits limits = null)
        {
            JObject requestObject =
                        new JObject(
                            new JProperty("jsonrpc", "2.0"),
                            new JProperty("id", 234),
                            new JProperty("method", "AudioLibrary.GetArtists"),
                            new JProperty("params",
                                new JObject(
                                    new JProperty("properties",
                                        new JArray("born", "description", "died", "disbanded", "formed", "instrument", "mood", "musicbrainzartistid", "style", "yearsactive"))
                                            )));

            if (limits != null)
            {
                requestObject["params"]["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if (filter != null)
            {
                requestObject["params"]["filter"] = filter;
            }

            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);

            JArray artistListObject = (JArray)responseObject["result"]["artists"];
            List<Artist> listToReturn = artistListObject.ToObject<List<Artist>>();
            return listToReturn;
        }
    }
}
