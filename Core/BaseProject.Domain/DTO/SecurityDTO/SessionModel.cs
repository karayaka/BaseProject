using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Domain.DTO.SecurityDTO
{
    public class SessionModel
    {
        //Mapper burda kotrol edileceks
        public Guid ID { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
