using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.Exercise.DTOs
{
    public class ExerciseListItemDTO
    {
        public int ExerciseEntityId { get; set; }
        public int OwnerId { get; set; }
        public string ExerciseName { get; set; }
    }
}
