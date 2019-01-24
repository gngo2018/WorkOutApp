using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.WorkOut
{
    public class WorkOutEntity
    {
        public int WorkOutEntityId { get; set; }
        public int OwnerId { get; set; }
        public string ExerciseName { get; set; }
    }
}
