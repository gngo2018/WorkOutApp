using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOut.Database.DataContract.WorkOut.RAOs;

namespace WorkOut.Database.DataContract.WorkOut.Interfaces
{
    public interface IWorkOutRepository
    {
        Task<bool> CreateWorkOut(WorkOutCreateRAO rao);
    }
}
