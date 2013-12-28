using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBMCRemoteWP.Models
{
    /// <summary>
    /// This file contains basic classes corresponding to basic types returned by XBMC.
    /// Those JSON objects can be cast into these classes.
    /// </summary>

    //String type
    public class StringReturn : RPCBase
    {
        public string Result { get; set; }
    }

    //Boolean type
    public class BoolReturn : RPCBase
    {
        public bool Result { get; set; }
    }

    //Integer type
    public class IntReturn : RPCBase
    {
        public int Result { get; set; }
    }

    //List type
    public class PlayerListReturn : RPCBase
    {
        public List<PlayerItem> Result { get; set; }
    }

}
