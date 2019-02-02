using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.Entities.ExerciseTransaction
{
    public class ExerciseTransactionEntity
    {
        public int ExerciseTransactionEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
        public int ExerciseEntityId { get; set; }
        public int OwnerId { get; set; }
    }
}
