using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.ExerciseTransaction
{
    public class ExerciseTransactionListItemResponse
    {
        public int ExerciseTransactionEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
        public int ExerciseEntityId { get; set; }
    }
}
