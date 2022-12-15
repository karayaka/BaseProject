using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.Repositorys
{
    public interface ISecurityRepository
    {
        Task<UserModel> Login(LoginDTO model);
    }
}
