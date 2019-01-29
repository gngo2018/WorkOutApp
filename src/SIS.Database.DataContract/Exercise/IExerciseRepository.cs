using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.DataContract.Exercise.RAOs;

namespace WorkOut.Database.DataContract.Exercise
{
    public interface IExerciseRepository
    {
        Task<bool> CreateExercise(ExerciseCreateRAO rao);
        Task<IEnumerable<ExerciseListItemRAO>> GetExercises();
        Task<ExerciseListItemRAO> GetExerciseById(int id);
    }
}
