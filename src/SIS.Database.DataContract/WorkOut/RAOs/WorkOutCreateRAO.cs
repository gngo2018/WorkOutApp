using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.WorkOut.RAOs
{
    public class WorkOutCreateRAO
    {
        public int OwnerId { get; set; }
        public string ExerciseName { get; set; }
    }
}
