using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.DataContract.ExerciseTransaction.DTOs
{
    public class ExerciseTransactionCreateDTO
    {
        public int OwnerId { get; set; }
        public int ExerciseEntityId { get; set; }
        public int SetInfoEntityId { get; set; }
    }
}
