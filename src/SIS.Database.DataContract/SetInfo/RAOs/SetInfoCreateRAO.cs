using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.SetInfo.RAOs
{
    public class SetInfoCreateRAO
    {
        public string Set { get; set; }
        public int OwnerId { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
    }
}
