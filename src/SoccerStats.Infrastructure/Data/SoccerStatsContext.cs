using Microsoft.EntityFrameworkCore;
using SoccerStats.Core.Models;
using SoccerStats.Infrastructure.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data;

public class SoccerStatsContext: DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }

    public SoccerStatsContext(DbContextOptions<SoccerStatsContext> options)
            : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBulder)
    {
        modelBulder.ApplyConfiguration(new TeamConfiguration());
        modelBulder.ApplyConfiguration(new PlayerConfiguration());
    }
}

