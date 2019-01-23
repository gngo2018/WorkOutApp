using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WorkOut.Database.Entities.Application
{
    public class TrackChoiceEntity
    {
        [Key]
        public Guid ApplicationEntityId { get; set; }

        public int TrackChoiceEntityID { get; set; }
        public double DotNet { get; set; }
        public double JavaScript { get; set; }
        public double Python { get; set; }
        public double WordPress { get; set; }
    }
}
