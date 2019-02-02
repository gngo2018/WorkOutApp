using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.ExerciseTransaction.DTOs;

namespace WorkOut.Business.DataContract.ExerciseTransaction
{
    public interface IExerciseTransactionManager
    {
        Task<bool> CreateExerciseTransaction(ExerciseTransactionCreateDTO dto);
    }
}
