using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.Exercise;
using WorkOut.Business.DataContract.Exercise.DTOs;
using WorkOut.Database.DataContract.Exercise;
using WorkOut.Database.DataContract.Exercise.RAOs;

namespace WorkOut.Business.Managers.Exercise
{
    public class ExerciseManager : IExerciseManager
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _repository;

        public ExerciseManager(IMapper mapper, IExerciseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateExercise(ExerciseCreateDTO dto)
        {
            var rao = _mapper.Map<ExerciseCreateRAO>(dto);
            if (await _repository.CreateExercise(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExerciseListItemDTO>> GetExercises()
        {
            var rao = await _repository.GetExercises();
            var dto = _mapper.Map<IEnumerable<ExerciseListItemDTO>>(rao);

            return dto;
        }

        public async Task<ExerciseListItemDTO> GetExerciseById(int id)
        {
            var rao = await _repository.GetExerciseById(id);
            var dto = _mapper.Map<ExerciseListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateExercise(ExerciseUpdateDTO dto)
        {
            var rao = _mapper.Map<ExerciseUpdateRAO>(dto);
            if (await _repository.UpdateExercise(rao))
                return true;

            throw new NotImplementedException();
        }
    }
}
