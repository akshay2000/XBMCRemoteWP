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
        public static async Task<List<Album>> GetRecentlyAddedAlbums(Limits limits)
        {
            JObject requestObject = 
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234), 
                        new JProperty("method", "AudioLibrary.GetRecentlyAddedAlbums"),
                        new JProperty("params",
                            new JObject(
                                new JProperty("properties",
                                    new JArray("title", "description","artist", "genre", "theme", "mood","style","type","albumlabel","rating","year","musicbrainzalbumid","musicbrainzalbumartistid","fanart","thumbnail","playcount","genreid","artistid","displayartist")
                                    ),
                                    new JProperty("limits",
                                    new JObject(
                                        new JProperty("start", limits.Start),
                                        new JProperty("end", limits.End)
                                        )                                        
                                        ))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JArray albumListObject = (JArray)responseObject["result"]["albums"];
            List<Album> listToReturn = albumListObject.ToObject<List<Album>>();
            return listToReturn;
        }
    }
}
