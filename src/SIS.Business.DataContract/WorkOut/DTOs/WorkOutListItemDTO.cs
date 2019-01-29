using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.WorkOut.DTOs
{
    public class WorkOutListItemDTO
    {
        public int WorkOutEntityId { get; set; }
        public int OwnerId { get; set; }
        public string WorkOutName { get; set; }
    }
}
