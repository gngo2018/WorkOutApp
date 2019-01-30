using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.ExerciseTransaction.RAOs
{
    public class ExerciseTransactionUpdateRAO
    {
        public int ExerciseTransactionEntityId { get; set; }
        public int ExerciseEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
    }
}
