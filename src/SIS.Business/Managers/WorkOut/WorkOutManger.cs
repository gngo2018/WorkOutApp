using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.WorkOut.DTOs;
using WorkOut.Business.DataContract.WorkOut.Interfacees;
using WorkOut.Database.DataContract.WorkOut.Interfaces;
using WorkOut.Database.DataContract.WorkOut.RAOs;

namespace WorkOut.Business.Managers.WorkOut
{
    public class WorkOutManager : IWorkOutManager
    {
        private readonly IMapper _mapper;
        private readonly IWorkOutRepository _repository;

        public WorkOutManager(IMapper mapper, IWorkOutRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateWorkOut(WorkOutCreateDTO dto)
        {
            var rao = _mapper.Map<WorkOutCreateRAO>(dto);

            if (await _repository.CreateWorkOut(rao))
                return true;
           
                throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkOutListItemDTO>> GetWorkOuts()
        {
            var rao = await _repository.GetWorkOuts();
            var dto = _mapper.Map<IEnumerable<WorkOutListItemDTO>>(rao);

            return dto;
        }
    }
}
