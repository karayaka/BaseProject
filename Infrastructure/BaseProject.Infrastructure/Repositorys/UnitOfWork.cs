using System;
using BaseProject.Application.Repositorys;
using BaseProject.Application.Services.SecurityServices;
using BaseProject.Persistence.BaseContextes;

namespace BaseProject.Infrastructure.Repositorys
{
	public class UnitOfWork:IUnitOfWork
	{
        private readonly BaseDataContext context;
        private readonly Guid? userId;
        private readonly ISessionServices session;
        public UnitOfWork()
		{
		}

        public IUserRepository UserRepository => throw new NotImplementedException();
    }
}

