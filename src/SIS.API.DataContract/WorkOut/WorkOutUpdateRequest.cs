using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.WorkOut
{
    public class WorkOutUpdateRequest
    {
        public int WorkOutEntityId { get; set; }
        public string WorkOutName { get; set; }
    }
}
