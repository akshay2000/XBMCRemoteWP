﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Helpers;
using XBMCRemoteWP.Models.Audio;
using XBMCRemoteWP.Models.Common;

namespace XBMCRemoteWP.RPCWrappers
{
    public class AudioLibrary
    {
        public static async Task<Album> GetAlbumDetails(int albumid)
        {
            JObject parameters = new JObject(
                new JProperty("albumid", albumid),
                new JProperty("properties",
                    new JArray("title", "description", "artist", "genre", "theme", "mood", "style", "type", "albumlabel", "rating", "year", "musicbrainzalbumid", "musicbrainzalbumartistid", "fanart", "thumbnail", "playcount", "genreid", "artistid", "displayartist")
                    ));

            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("AudioLibrary.GetAlbumDetails", parameters);

            JObject albumJSON = (JObject)responseObject["result"]["albumdetails"];
            Album albumToRetun = albumJSON.ToObject<Album>();
            return albumToRetun;

        }

        public static async Task<List<Album>> GetRecentlyAddedAlbums(Limits limits = null, JObject sort = null)
        {
            JObject parameters = new JObject(
                                new JProperty("properties",
                                    new JArray("title", "description", "artist", "genre", "theme", "mood", "style", "type", "albumlabel", "rating", "year", "musicbrainzalbumid", "musicbrainzalbumartistid", "fanart", "thumbnail", "playcount", "genreid", "artistid", "displayartist")
                                    ));

            if (limits != null)
            {
                parameters["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if (sort != null)
            {
                parameters["sort"] = sort;
            }

            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("AudioLibrary.GetRecentlyAddedAlbums", parameters);

            JArray albumListObject = (JArray)responseObject["result"]["albums"];
            List<Album> listToReturn = albumListObject != null ? albumListObject.ToObject<List<Album>>() : new List<Album>();
            return listToReturn;
        }

        public static async Task<List<Song>> GetSongs(JObject filter = null, Limits limits = null, JObject sort = null)
        {
            JObject parameters = new JObject(
                                     new JProperty("properties",
                                         new JArray("album", "albumartist", "albumartistid", "albumid", "comment", "disc", "duration", "file", "lastplayed", "lyrics", "musicbrainzartistid", "musicbrainztrackid", "playcount", "track"))
                                             );

            if (limits != null)
            {
                parameters["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if (filter != null)
            {
                parameters["filter"] = filter;
            }

            if (sort != null)
            {
                parameters["sort"] = sort;
            }

            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("AudioLibrary.GetSongs", parameters);

            JArray songListObject = (JArray)responseObject["result"]["songs"];
            List<Song> listToReturn = songListObject != null ? songListObject.ToObject<List<Song>>() : new List<Song>();
            return listToReturn;
        }

        public static async Task<List<Artist>> GetArtists(JObject filter = null, Limits limits = null, JObject sort = null)
        {
            JObject parameters = new JObject(
                                     new JProperty("properties",
                                         new JArray("born", "description", "died", "disbanded", "formed", "instrument", "mood", "musicbrainzartistid", "style", "yearsactive", "thumbnail", "fanart"))
                                             );

            if (limits != null)
            {
                parameters["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if (filter != null)
            {
                parameters["filter"] = filter;
            }

            if (sort != null)
            {
                parameters["sort"] = sort;
            }

            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("AudioLibrary.GetArtists", parameters);

            JArray artistListObject = (JArray)responseObject["result"]["artists"];
            List<Artist> listToReturn = artistListObject != null ? artistListObject.ToObject<List<Artist>>() : new List<Artist>();
            return listToReturn;
        }

        public static async Task<List<Album>> GetAlbums(JObject filter = null, Limits limits = null, JObject sort = null)
        {
            JObject parameters =
                                new JObject(
                                    new JProperty("properties",
                                        new JArray("title", "description", "artist", "genre", "theme", "mood", "style", "type", "albumlabel", "rating", "year", "musicbrainzalbumid", "musicbrainzalbumartistid", "fanart", "thumbnail", "playcount", "genreid", "artistid", "displayartist"))
                                            );

            if (limits != null)
            {
                parameters["limits"] = new JObject(
                                            new JProperty("start", limits.Start),
                                            new JProperty("end", limits.End));
            }

            if (filter != null)
            {
                parameters["filter"] = filter;
            }

            if (sort != null)
            {
                parameters["sort"] = sort;
            }


            JObject responseObject = await ConnectionManager.ExecuteRPCRequest("AudioLibrary.GetAlbums", parameters);

            JArray albumListObject = (JArray)responseObject["result"]["albums"];
            List<Album> listToReturn = albumListObject != null ? albumListObject.ToObject<List<Album>>() : new List<Album>();
            return listToReturn;
        }
    }
}
