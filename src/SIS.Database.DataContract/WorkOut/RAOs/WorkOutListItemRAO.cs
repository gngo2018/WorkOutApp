using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.WorkOut.RAOs
{
    public class WorkOutListItemRAO
    {
        public int WorkOutEntityId { get; set; }
        public int OwnerId { get; set; }
        public string WorkOutName { get; set; }
    }
}
