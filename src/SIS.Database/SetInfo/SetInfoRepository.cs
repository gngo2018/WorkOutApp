﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.Contexts;
using WorkOut.Database.DataContract.SetInfo.Interfaces;
using WorkOut.Database.DataContract.SetInfo.RAOs;
using WorkOut.Database.Entities.SetInfo;

namespace WorkOut.Database.SetInfo
{
    public class SetInfoRepository : ISetInfoRepository
    {
        private readonly SISContext _ctx;
        private readonly IMapper _mapper;

        public SetInfoRepository(IMapper mapper, SISContext ctx)
        {
            _mapper = mapper;
            _ctx = ctx;
        }

        public async Task<bool> CreateSetInfo(SetInfoCreateRAO rao)
        {
            var entity = _mapper.Map<SetInfoEntity>(rao);

            await _ctx.SetInfoTableAccess.AddAsync(entity);

            return await _ctx.SaveChangesAsync() == 1;

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SetInfoListItemRAO>> GetAllSetInfo()
        {
            var query = await _ctx.SetInfoTableAccess.ToArrayAsync();
            var rao = _mapper.Map<IEnumerable<SetInfoListItemRAO>>(query);

            return rao;
        }

        public async Task<SetInfoListItemRAO> GetSetInfoById(int id)
        {
            var query = await _ctx.SetInfoTableAccess.SingleAsync(q => q.SetInfoEntityId == id);
            var rao = _mapper.Map<SetInfoListItemRAO>(query);

            return rao;
        }

        public async Task<bool> UpdateSetInfo(SetInfoUpdateRAO rao)
        {
            var entity = await _ctx.SetInfoTableAccess.SingleAsync(e => e.SetInfoEntityId == rao.SetInfoEntityId);

            entity.Set = rao.Set;
            entity.Rep = rao.Rep;
            entity.Weight = rao.Weight;

            return await _ctx.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteSetInfo(int id)
        {
            var query = await _ctx.SetInfoTableAccess.SingleAsync(q => q.SetInfoEntityId == id);
            _ctx.SetInfoTableAccess.Remove(query);

            return await _ctx.SaveChangesAsync() == 1;
        }
    }
}
