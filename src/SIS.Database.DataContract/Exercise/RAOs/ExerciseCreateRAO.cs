using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.Exercise.RAOs
{
    public class ExerciseCreateRAO
    {
        public int OwnerId { get; set; }
        public string ExerciseName { get; set; }
    }
}
