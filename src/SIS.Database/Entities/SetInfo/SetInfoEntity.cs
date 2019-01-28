using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.SetInfo
{
    public class SetInfoEntity
    {
        public int SetInfoEntityId { get; set; }
        public string Set { get; set; }
        public int OwnerId { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
    }
}
