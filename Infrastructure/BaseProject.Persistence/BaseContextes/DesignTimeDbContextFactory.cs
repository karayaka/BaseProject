using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BaseProject.Persistence.BaseContextes
{
	public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<BaseDataContext>
    {
		public DesignTimeDbContextFactory()
		{
		}

        public BaseDataContext CreateDbContext(string[] args)
        {
            //connectişon stringler burdan yönetilecek
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            var builder = new DbContextOptionsBuilder<BaseDataContext>();
            var connectionString = "server=213.238.183.40;port=3306;database=cagnazco_testdb;user=noteToUser;password=$Vhk69c67;";//server
            //update database yapılacak
            builder.UseMySql(
                connectionString,
                serverVersion,
                options => options.EnableRetryOnFailure()
                );
            return new BaseDataContext(builder.Options);
        }
    }
}

