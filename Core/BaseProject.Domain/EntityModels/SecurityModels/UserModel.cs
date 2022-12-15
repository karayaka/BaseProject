using BaseProject.Domain.EntityModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Domain.EntityModels.SecurityModels
{
    public class UserModel:BaseEntityModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ProfileImage { get; set; }
    }
}
