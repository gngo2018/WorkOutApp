using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOut.API.DataContract.Exercise;
using WorkOut.Business.DataContract.Exercise;
using WorkOut.Database.DataContract.Exercise.RAOs;
using WorkOut.Database.Entities.Exercise;

namespace WorkOut.API.MappingProfiles
{
    public class ExerciseMappingProfile : Profile
    {
        public ExerciseMappingProfile()
        {
            //Create Exercise Mapping
            CreateMap<ExerciseCreateRequest, ExerciseCreateDTO>();
            CreateMap<ExerciseCreateDTO, ExerciseCreateRAO>();
            CreateMap<ExerciseCreateRAO, ExerciseEntity>();

            //Read Exercise Mapping
        }

    }
}
