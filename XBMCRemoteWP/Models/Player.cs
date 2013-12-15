using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBMCRemoteWP.Models
{
    /// <summary>
    /// This class provides basic Player object. Usually return in response to GetActivePlayers method of XBMC API.
    /// </summary>
    public class Player
    {
        public int PlayerId { get; set; }
        public string Type { get; set; }
    }
}
