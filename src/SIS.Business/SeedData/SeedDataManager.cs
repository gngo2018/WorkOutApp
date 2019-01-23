using WorkOut.Business.DataContract.SeedData;
using WorkOut.Database.DataContract.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Business.SeedData
{
    public class SeedDataManager : ISeedDataManager
    {
        private ISeedRepository _seedRepository;

        public SeedDataManager(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        public void SeedUsers()
        {
            _seedRepository.SeedUsers();
        }
    }
}
