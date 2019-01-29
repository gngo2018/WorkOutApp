using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.SetInfo.DTOs
{
    public class SetInfoListItemDTO
    {
        public string Set { get; set; }
        public int SetInfoEntityId { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }
    }
}
