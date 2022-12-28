using System;
using BaseProject.Application.Repositorys;
using BaseProject.Application.Services.SecurityServices;
using BaseProject.Infrastructure.Repositorys;
using BaseProject.Infrastructure.Services.SecurityServices;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infrastructure
{
	public static class InfrastructureRegistiration
	{
        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<ISecurityRepository, SecurityRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISessionServices, SessionServices>();
        }
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

