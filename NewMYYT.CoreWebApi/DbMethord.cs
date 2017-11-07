using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewMYYT.CoreWebApi
{
    public static class DbMethord
    {
        public static DbContextOptionsBuilder UseFarmDatabase(this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            string provider = configuration.GetConnectionString("DataProvider"), connection = configuration.GetConnectionString("ConnectionString");
            if (provider.Equals("SqlServer", StringComparison.InvariantCultureIgnoreCase))
            {
                return optionsBuilder.UseSqlServer(connection);
            }
            else if (provider.Equals("MySql", StringComparison.InvariantCultureIgnoreCase))
            {
                return optionsBuilder.UseMySql(connection);
            }
            else
            {
                throw new BusinessException("No databaseProvider");
            }
        }
    }
}
