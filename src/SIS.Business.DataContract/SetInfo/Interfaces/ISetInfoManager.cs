using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.SetInfo.DTOs;

namespace WorkOut.Business.DataContract.SetInfo.Interfaces
{
    public interface ISetInfoManager
    {
        Task<bool> CreateSetInfo(SetInfoCreateDTO dto);
        Task<IEnumerable<SetInfoListItemDTO>> GetAllSetInfo();
    }
}
