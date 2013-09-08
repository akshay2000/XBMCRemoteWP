using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XBMCRemoteWP.Models
{
    public class StringReturn : RPCBase
    {
        public string Result { get; set; }
    }

    public class BoolReturn : RPCBase
    {
        public bool Result { get; set; }
    }

    public class IntReturn : RPCBase
    {
        public int Result { get; set; }
    }
}
