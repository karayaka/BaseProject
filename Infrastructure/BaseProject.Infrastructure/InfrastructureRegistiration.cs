using System;
using BaseProject.Application.Repositorys;
using BaseProject.Infrastructure.Repositorys;
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
            //services.AddTransient<IMailServices, MailServices>();//register eski usul yazılacak ve devam edecek
        }
    }
}

