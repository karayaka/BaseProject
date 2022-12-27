using System;
namespace BaseProject.Application.Repositorys
{
	public interface IUnitOfWork
	{
		IUserRepository UserRepository { get; }
	}
}

