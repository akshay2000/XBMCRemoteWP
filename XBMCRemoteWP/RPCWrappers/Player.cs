using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Helpers;
using XBMCRemoteWP.Models;

namespace XBMCRemoteWP.RPCWrappers
{
    class Player
    {
        private static JObject defaultPlayerOptions = new JObject(
            new JProperty("repeat", null),
            new JProperty("resume", false),
            new JProperty("shuffled", null));

        public async static Task Open(JObject item, JObject options = null)
        {
            if (options == null)
                options = defaultPlayerOptions;
            JObject parameters = new JObject(
                                           new JProperty("item", item),
                                           new JProperty("options", options));

            await ConnectionManager.ExecuteRPCRequest("Player.Open", parameters);
        }
    }
}
