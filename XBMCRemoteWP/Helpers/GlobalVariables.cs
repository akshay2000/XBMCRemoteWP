using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBMCRemoteWP.Models;
using XBMCRemoteWP.Models.Audio;

namespace XBMCRemoteWP.Helpers
{
    public static class GlobalVariables
    {
        public static int CurrentAlbumId { get; set; }

        public static Album CurrentAlbum { get; set; }

        public static Artist CurrentArtist { get; set; }

    }
}
