using System;
using BaseProject.Application.Repositorys;
using BaseProject.Persistence.BaseContextes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Persistence
{
	public static class PersistenceRegistration
	{
        public static void AddNoteDbContext(this IServiceCollection services, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            services.AddDbContext<BaseDataContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    serverVersion,
                    options => options.EnableRetryOnFailure());
            });
        }      
    }
}

