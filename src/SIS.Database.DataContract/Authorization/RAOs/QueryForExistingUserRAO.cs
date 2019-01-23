using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOut.Database.DataContract.Authorization.RAOs
{
    public class QueryForExistingUserRAO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
