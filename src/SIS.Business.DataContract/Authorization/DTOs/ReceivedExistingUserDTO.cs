﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WorkOut.Business.DataContract.Authorization.DTOs
{
    public class ReceivedExistingUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
