using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Domain.DTO.SecurityDTO
{
    //test note
    public class LoginDTO
    {
        public Guid ID { get; set; }

        public string UserModel { get; set; }

        public string Password { get; set; }
    }
}
