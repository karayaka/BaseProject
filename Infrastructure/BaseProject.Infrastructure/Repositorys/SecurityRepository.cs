using System;
using BaseProject.Application.Repositorys;
using BaseProject.Application.Services.SecurityServices;
using BaseProject.Domain.DTO.SecurityDTO;
using BaseProject.Domain.EntityModels.SecurityModels;
using BaseProject.Persistence.BaseContextes;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Repositorys
{
	public class SecurityRepository: ISecurityRepository
    {
        private readonly BaseDataContext context;

        public SecurityRepository(BaseDataContext _context)
		{
            context = _context;
		}

        public async Task<UserModel?>Login(LoginDTO model)
        {
            try
            {
                return await context.Users.FirstOrDefaultAsync(t => (t.UserName == model.UserName || t.Email == model.UserName)
                && t.Password == model.Password);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

