using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.Exercise
{
    public class ExerciseCreateDTO
    {
        public int OwnerId { get; set; }
        public string ExerciseName { get; set; }
    }
}
