﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.Contexts;
using WorkOut.Database.DataContract.Exercise;
using WorkOut.Database.DataContract.Exercise.RAOs;
using WorkOut.Database.Entities.Exercise;

namespace WorkOut.Database.Exercise
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly SISContext _ctx;
        private readonly IMapper _mapper;

        public ExerciseRepository(SISContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> CreateExercise(ExerciseCreateRAO rao)
        {
            var entity = _mapper.Map<ExerciseEntity>(rao);

            await _ctx.ExerciseTableAccess.AddAsync(entity);

            return await _ctx.SaveChangesAsync() == 1;

            throw new NotImplementedException();

        }
    }
}