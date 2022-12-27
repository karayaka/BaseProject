using System;
using BaseProject.Application.Repositorys;
using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;

namespace BaseProject.Infrastructure.Repositorys
{
	public class SecurityRepository: ISecurityRepository
    {
		public SecurityRepository()
		{
		}

        public Task<UserModel> Login(LoginDTO model)
        {
            throw new NotImplementedException();
        }
    }
}

