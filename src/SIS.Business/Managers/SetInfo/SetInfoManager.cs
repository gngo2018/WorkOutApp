using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.SetInfo.DTOs;
using WorkOut.Business.DataContract.SetInfo.Interfaces;
using WorkOut.Database.DataContract.SetInfo.Interfaces;
using WorkOut.Database.DataContract.SetInfo.RAOs;

namespace WorkOut.Business.Managers.SetInfo
{
    public class SetInfoManager : ISetInfoManager
    {
        private readonly IMapper _mapper;
        private readonly ISetInfoRepository _repository;

        public SetInfoManager(IMapper mapper, ISetInfoRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateSetInfo(SetInfoCreateDTO dto)
        {
            var rao = _mapper.Map<SetInfoCreateRAO>(dto);

            if (await _repository.CreateSetInfo(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SetInfoListItemDTO>> GetAllSetInfo()
        {
            var rao = await _repository.GetAllSetInfo();
            var dto = _mapper.Map<IEnumerable<SetInfoListItemDTO>>(rao);

            return dto;
        }

        public async Task<SetInfoListItemDTO> GetSetInfoById(int id)
        {
            var rao = await _repository.GetSetInfoById(id);
            var dto = _mapper.Map<SetInfoListItemDTO>(rao);

            return dto;
        }

        public async Task<bool> UpdateSetInfo(SetInfoUpdateDTO dto)
        {
            var rao = _mapper.Map<SetInfoUpdateRAO>(dto);

            if (await _repository.UpdateSetInfo(rao))
                return true;

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSetInfo(int id)
        {
            if (await _repository.DeleteSetInfo(id))
                return true;

            throw new NotImplementedException();
        }
    }
}
