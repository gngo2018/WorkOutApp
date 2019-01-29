using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.DataContract.SetInfo.RAOs;

namespace WorkOut.Database.DataContract.SetInfo.Interfaces
{
    public interface ISetInfoRepository
    {
        Task<bool>CreateSetInfo(SetInfoCreateRAO rao);
        Task<IEnumerable<SetInfoListItemRAO>> GetAllSetInfo();
        Task<SetInfoListItemRAO> GetSetInfoById(int id);
        Task<bool> UpdateSetInfo(SetInfoUpdateRAO rao);
    }
}
