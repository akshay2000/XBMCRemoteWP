using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models.Video;

namespace XBMCRemoteWP.RPCWrappers
{
    public class VideoLibrary
    {
        public static async Task<List<Episode>> GetRecentlyAddedEpisodes()
        {
            JObject requestObject =
                    new JObject(
                        new JProperty("jsonrpc", "2.0"),
                        new JProperty("id", 234),
                        new JProperty("method", "VideoLibrary.GetRecentlyAddedEpisodes"),
                        new JProperty("params",
                            new JObject(
                                new JProperty("properties",
                                    new JArray("title", "plot", "votes", "rating", "writer", "firstaired", "playcount", "runtime", "director", "productioncode", "season", "episode", "originaltitle", "showtitle", "streamdetails", "lastplayed", "fanart", "thumbnail", "file", "resume", "tvshowid", "dateadded", "uniqueid", "art")
                                    ))));
            string requestData = requestObject.ToString();
            HttpResponseMessage response = await App.ConnManager.ExecuteRequest(requestData);
            string responseString = await response.Content.ReadAsStringAsync();
            JObject responseObject = JObject.Parse(responseString);
            JArray episodeListObject = (JArray)responseObject["result"]["episodes"];
            List<Episode> listToReturn = episodeListObject.ToObject<List<Episode>>();
            return listToReturn;
        }
    }
}
