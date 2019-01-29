using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.SetInfo
{
    public class SetInfoCreateRequest
    {
        public string Set { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
    }
}
