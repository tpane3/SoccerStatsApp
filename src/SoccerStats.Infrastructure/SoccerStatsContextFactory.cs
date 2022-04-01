using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SoccerStats.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure;

// used for database migrations
public class SoccerStatsContextFactory : IDesignTimeDbContextFactory<SoccerStatsContext>
{
    public SoccerStatsContext CreateDbContext(string[] args)
    {
        string currDir = Environment.CurrentDirectory;
        var builder = new ConfigurationBuilder()
            .SetBasePath(currDir)
            .AddJsonFile("migrationsConfig.json", optional:false) ;

        var config = builder.Build();
            
        var optionsBuilder = new DbContextOptionsBuilder<SoccerStatsContext>();
        string connectionString = config.GetSection("sqlServer").GetSection("connectionString").Value;
        string migrationsAssembly = config.GetSection("sqlServer").GetSection("migrationsAssembly").Value;
        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));

        return new SoccerStatsContext(optionsBuilder.Options);
    }
}

