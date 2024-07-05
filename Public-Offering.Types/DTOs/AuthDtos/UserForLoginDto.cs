

using Public_Offering.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Entity.DTOs.AuthDtos
{
    public class UserForLoginDto : IDto

    {

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
