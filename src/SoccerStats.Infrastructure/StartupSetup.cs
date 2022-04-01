using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoccerStats.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure;

public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetSection("sqlServer").GetSection("connectionString").Value;
        string migrationsAssembly = configuration.GetSection("sqlServer").GetSection("migrationsAssembly").Value;
        services.AddDbContext<SoccerStatsContext>(
            options => options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(migrationsAssembly)));
    }

}

