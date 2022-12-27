using System;
using BaseProject.Domain.EntityModels.SecurityModels;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Persistence.BaseContextes
{
	public class BaseDataContext:DbContext
	{
		public BaseDataContext(DbContextOptions options) : base(options)
        {
		}
		public DbSet<UserModel> Users { get; set; }
	}
}

 