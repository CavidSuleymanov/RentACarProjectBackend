﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public  interface ITokenHelper
    {

        AccessToken CreateToken(User user,List<OperationClaim> operationClaim);
    }
}
