using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Entites
{

    public class UserLogin
    {
        public required string UserName { get; init; }
        public required string Password { get; init; }



        //public LoginRequest()
        //{

        //}
    }
}
