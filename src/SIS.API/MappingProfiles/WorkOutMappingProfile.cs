using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOut.API.DataContract.WorkOut;
using WorkOut.Business.DataContract.WorkOut.DTOs;
using WorkOut.Database.DataContract.WorkOut.RAOs;
using WorkOut.Database.Entities.WorkOut;

namespace WorkOut.API.MappingProfiles
{
    public class WorkOutMappingProfile : Profile
    {
        public WorkOutMappingProfile()
        {
            //Create Mapping
            CreateMap<WorkOutCreateRequest, WorkOutCreateDTO>();
            CreateMap<WorkOutCreateDTO, WorkOutCreateRAO>();
            CreateMap<WorkOutCreateRAO, WorkOutEntity>();

            //Read Mapping
            CreateMap<WorkOutEntity, WorkOutListItemRAO>();
            CreateMap<WorkOutListItemRAO, WorkOutListItemDTO>();
            CreateMap<WorkOutListItemDTO, WorkOutListItemResponse>();

            //Update Mapping
            CreateMap<WorkOutUpdateRequest, WorkOutUpdateDTO>();
            CreateMap<WorkOutUpdateDTO, WorkOutUpdateRAO>();
            CreateMap<WorkOutUpdateRAO, WorkOutEntity>();
        }
        
    }
}
