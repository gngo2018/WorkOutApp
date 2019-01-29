using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.SetInfo.RAOs
{
    public class SetInfoUpdateRAO
    {
        public int SetInfoEntityId { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
        public string Set { get; set; }
    }
}
