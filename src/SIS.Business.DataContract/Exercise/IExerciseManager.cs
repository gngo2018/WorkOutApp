using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.Exercise.DTOs;

namespace WorkOut.Business.DataContract.Exercise
{
    public interface IExerciseManager
    {
        Task<bool> CreateExercise(ExerciseCreateDTO dto);
        Task<IEnumerable<ExerciseListItemDTO>> GetExercises();
        Task<ExerciseListItemDTO> GetExerciseById(int id);
        Task<bool> UpdateExercise(ExerciseUpdateDTO dto);
        Task<bool> DeleteExercise(int id);
    }
}
