using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data;

public static class DbContextOptionsFactory
{
    public static DbContextOptions<SoccerStatsContext> GetOptions(IConfiguration configuration)
    {
        var builder = new DbContextOptionsBuilder<SoccerStatsContext>();

        DbContextConfigurer.Configure(builder, configuration);
        return builder.Options;
    }

    public static DbContextOptions<SoccerStatsContext> GetOptions(string connectionString, string migrationsAssembly)
    {
        var builder = new DbContextOptionsBuilder<SoccerStatsContext>();

        DbContextConfigurer.Configure(builder, connectionString, migrationsAssembly);
        return builder.Options;
    }
}

public static class DbContextConfigurer
{
    public static void Configure(
        DbContextOptionsBuilder<SoccerStatsContext> builder,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetSection("sqlServer").GetSection("connectionString").Value;
        string migrationsAssembly = configuration.GetSection("sqlServer").GetSection("migrationsAssembly").Value;
        builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
    }

    public static void Configure(
        DbContextOptionsBuilder<SoccerStatsContext> builder,
        string connectionString,
        string migrationsAssembly)
    {
        builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
    }
}

