using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.DataContract.ExerciseTransaction.RAOs;

namespace WorkOut.Database.DataContract.ExerciseTransaction
{
    public interface IExerciseTransactionRepository
    {
        Task<bool> CreateExerciseTransaction(ExerciseTransactionCreateRAO rao);
        Task<IEnumerable<ExerciseTransactionListItemRAO>> GetExerciseTransactions();
    }
}
