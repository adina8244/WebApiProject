using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{


    public record UserDTO(int UserId, string UserName, string FirstName, string LastName, string Email, string PhoneNumber);

}