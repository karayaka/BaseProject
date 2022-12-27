using System;
using BaseProject.Application.Repositorys;
using BaseProject.Persistence.BaseContextes;

namespace BaseProject.Infrastructure.Repositorys
{
	public class UserRepository:Repository, IUserRepository
	{
        private readonly BaseDataContext context;
        private readonly Guid? userId;
		private readonly IUnitOfWork uow;

        public UserRepository(BaseDataContext _context, Guid? _userId, IUnitOfWork _uow):base(_context,_userId)
		{
            context = _context;
            userId = _userId;
            uow = _uow;
        }
        ///user repository devam eder
	}
}

