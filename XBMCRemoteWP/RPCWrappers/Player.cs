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
    public enum Players { Audio, Video, Picture}
    public enum GoTo{ Previous, Next}
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

        public async static Task<int> PlayPause(Players player)
        {
            int playerId = getIdFromPlayers(player);
            JObject parameters = new JObject(new JProperty("playerid", playerId));
            JObject responseObjet = await ConnectionManager.ExecuteRPCRequest("Player.PlayPause", parameters);
            int speed = (int)responseObjet["result"]["speed"];
            return speed;
        }

        public async static Task GoTo(Players player, GoTo goTo)
        {
            int playerId = getIdFromPlayers(player);
            JObject parameters = new JObject(
                new JProperty("playerid", playerId),
                new JProperty("to", goTo.ToString().ToLower()));
            await ConnectionManager.ExecuteRPCRequest("Player.GoTo", parameters);
        }

        public async static Task<List<Players>> GetActivePlayers()
        {
            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("Player.GetActivePlayers");
            List<Players> listToReturn = new List<Players>();
            JArray playersArray = (JArray)responseObject["result"];
            foreach (JObject t in playersArray)
            {
               listToReturn.Add(getPlayersFromId((int)t["playerid"]));
            }
            return listToReturn;
        }

        public async static Task<JObject> GetItem(Players player)
        {
            JObject parameters = new JObject(
                new JProperty("playerid", getIdFromPlayers(player)),
                new JProperty("properties",
                    new JArray("title", "artist", "fanart", "thumbnail", "showtitle")
                    ));
            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("Player.GetItem", parameters);
            return responseObject;
        }

        private static int getIdFromPlayers(Players player)
        {
            switch (player)
            {
                case Players.Audio:
                default:
                    return 0;
                case Players.Video:
                    return 1;
                case Players.Picture:
                    return 2;
            }
        }

        private static Players getPlayersFromId(int id)
        {
            switch (id)
            {
                case 0:
                default:
                    return Players.Audio;
                case 1:
                    return Players.Video;
                case 2:
                    return Players.Picture;
            }
        }
    }
}
