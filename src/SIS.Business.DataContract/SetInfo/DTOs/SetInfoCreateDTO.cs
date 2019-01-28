using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.SetInfo.DTOs
{
    public class SetInfoCreateDTO
    {
        public string Set { get; set; }
        public int OwnerId { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
    }
}
