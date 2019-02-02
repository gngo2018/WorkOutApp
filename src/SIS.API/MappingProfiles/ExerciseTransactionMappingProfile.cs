using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOut.API.DataContract.ExerciseTransaction;
using WorkOut.Business.DataContract.ExerciseTransaction.DTOs;
using WorkOut.Database.DataContract.ExerciseTransaction.RAOs;
using WorkOut.Database.Entities.ExerciseTransaction;

namespace WorkOut.API.MappingProfiles
{
    public class ExerciseTransactionMappingProfile : Profile
    {
        public ExerciseTransactionMappingProfile()
        {
            //Create Mapping
            CreateMap<ExerciseTransactionCreateRequest, ExerciseTransactionCreateDTO>();
            CreateMap<ExerciseTransactionCreateDTO, ExerciseTransactionCreateRAO>();
            CreateMap<ExerciseTransactionCreateRAO, ExerciseTransactionEntity>();

            //Read Mapping
        }

    }
}
