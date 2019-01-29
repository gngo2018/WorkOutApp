using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.WorkOut
{
    public class WorkOutListItemResponse
    {
        public int WorkOutEntityId { get; set; }
        public int OwnerId { get; set; }
        public string WorkOutName { get; set; }
    }
}
