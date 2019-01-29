using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkOut.Business.DataContract.Exercise
{
    public interface IExerciseManager
    {
        Task<bool> CreateExercise(ExerciseCreateDTO dto);
    }
}
