using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bshoes.Data.EF
{
    class dbfactory : IDesignTimeDbContextFactory<dbcontext>
    {
        public dbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Bshoes");

            var optionsBuilder = new DbContextOptionsBuilder<dbcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new dbcontext(optionsBuilder.Options);
        }
    }
}
