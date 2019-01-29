using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.Exercise;
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
    }
}
