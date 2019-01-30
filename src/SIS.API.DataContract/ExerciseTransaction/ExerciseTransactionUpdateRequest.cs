using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.ExerciseTransaction
{
    public class ExerciseTransactionUpdateRequest
    {
        public int ExerciseTransactionEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
        public int ExerciseEntityId { get; set; }
    }
}
