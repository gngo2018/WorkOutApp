using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.Exercise
{
    public class ExerciseUpdateRequest
    {
        public int ExerciseEntityId { get; set; }
        public string ExerciseName { get; set; }
    }
}
