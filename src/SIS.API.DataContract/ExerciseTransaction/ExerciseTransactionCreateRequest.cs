using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.API.DataContract.ExerciseTransaction
{
    public class ExerciseTransactionCreateRequest
    {
        public int ExerciseEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
    }
}
