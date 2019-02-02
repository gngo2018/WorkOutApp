using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.ExerciseTransaction;
using WorkOut.Business.DataContract.ExerciseTransaction.DTOs;
using WorkOut.Database.DataContract.ExerciseTransaction;
using WorkOut.Database.DataContract.ExerciseTransaction.RAOs;

namespace WorkOut.Business.Managers.ExerciseTransaction
{
    public class ExerciseTransactionManager : IExerciseTransactionManager
    {
        private readonly IMapper _mapper;
        private readonly IExerciseTransactionRepository _repository;

        public ExerciseTransactionManager (IMapper mapper, IExerciseTransactionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateExerciseTransaction(ExerciseTransactionCreateDTO dto)
        {
            var rao = _mapper.Map<ExerciseTransactionCreateRAO>(dto);
            if (await _repository.CreateExerciseTransaction(rao))
                return true;

            throw new NotImplementedException();
        }
    }
}
