using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.Exercise
{
    public class ExerciseEntity
    {
        public int ExerciseEntityId { get; set; }
        public string ExerciseName { get; set; }
        public int OwnerId { get; set; }
    }
}
