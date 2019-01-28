using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOut.API.DataContract.SetInfo;
using WorkOut.Business.DataContract.SetInfo.DTOs;
using WorkOut.Database.DataContract.SetInfo.RAOs;
using WorkOut.Database.Entities.SetInfo;

namespace WorkOut.API.MappingProfiles
{
    public class SetInfoMappingProfile : Profile
    {
        public SetInfoMappingProfile()
        {
            //Create Mapping
            CreateMap<SetInfoCreateRequest, SetInfoCreateDTO>();
            CreateMap<SetInfoCreateDTO, SetInfoCreateRAO>();
            CreateMap<SetInfoCreateRAO, SetInfoEntity>();

            //Read Mapping
            CreateMap<SetInfoEntity, SetInfoListItemRAO>();
            CreateMap<SetInfoListItemRAO, SetInfoListItemDTO>();
            CreateMap<SetInfoListItemDTO, SetInfoListItemResponse>();
        }
    }
}
