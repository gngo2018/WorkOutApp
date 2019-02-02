using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.Contexts;
using WorkOut.Database.DataContract.ExerciseTransaction;
using WorkOut.Database.DataContract.ExerciseTransaction.RAOs;
using WorkOut.Database.Entities.ExerciseTransaction;

namespace WorkOut.Database.ExerciseTransaction
{
    public class ExerciseTransactionRepository : IExerciseTransactionRepository
    {
        private readonly IMapper _mapper;
        private readonly SISContext _ctx;

        public ExerciseTransactionRepository (IMapper mapper, SISContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<bool> CreateExerciseTransaction(ExerciseTransactionCreateRAO rao)
        {
            var entity = _mapper.Map<ExerciseTransactionEntity>(rao);

            await _ctx.ExerciseTransactionTableAccess.AddAsync(entity);

            return await _ctx.SaveChangesAsync() == 1;

            throw new NotImplementedException();
        }
    }
}
