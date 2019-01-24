using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Business.DataContract.WorkOut.DTOs;

namespace WorkOut.Business.DataContract.WorkOut.Interfacees
{
    public interface IWorkOutManager
    {
        Task<bool> CreateWorkOut(WorkOutCreateDTO dto);
        Task<IEnumerable<WorkOutListItemDTO>> GetWorkOuts();
        Task<WorkOutListItemDTO> GetWorkOutById(int id);
        Task<bool> UpdateWorkOut(WorkOutUpdateDTO dto);
        Task<bool> DeleteWorkOut(int id);
    }
}
