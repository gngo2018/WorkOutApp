using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.Contexts;
using WorkOut.Database.DataContract.WorkOut.Interfaces;
using WorkOut.Database.DataContract.WorkOut.RAOs;
using WorkOut.Database.Entities.WorkOut;

namespace WorkOut.Database.WorkOut
{
    public class WorkOutRepository : IWorkOutRepository
    {
        private readonly SISContext _ctx;
        private readonly IMapper _mapper;

        public WorkOutRepository(SISContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<bool> CreateWorkOut(WorkOutCreateRAO rao)
        {
            var entity = _mapper.Map<WorkOutEntity>(rao);

            await _ctx.WorkOutTableAccess.AddAsync(entity);

            return await _ctx.SaveChangesAsync() == 1;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WorkOutListItemRAO>> GetWorkOuts()
        {
            var query = await _ctx.WorkOutTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<WorkOutListItemRAO>>(query);

            return rao;
        }

        public async Task<WorkOutListItemRAO> GetWorkOutById(int id)
        {
            var query = await _ctx.WorkOutTableAccess.SingleAsync(q => q.WorkOutEntityId == id);
            var rao = _mapper.Map<WorkOutListItemRAO>(query);

            return rao;
        }
    }
}
