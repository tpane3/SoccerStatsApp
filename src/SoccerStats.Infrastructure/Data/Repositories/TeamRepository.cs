using Microsoft.EntityFrameworkCore;
using SoccerStats.Core.Interfaces.Repositories;
using SoccerStats.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data.Repositories;

public class TeamRepository : Repository<Team>, ITeamRepository
{
    public TeamRepository(SoccerStatsContext context) : base(context)
    {
    }

    public IEnumerable<Player> GetPlayers(string teamName)
    {
        var result = this._entity
            .Include(t => t.Players)
            .Where(t => t.Name == teamName)
            .SingleOrDefault();

        if (result == null)
            return null;
        return result.Players;
    }

    public Team GetTeam(string teamName)
    {
        throw new NotImplementedException();
    }

    public SoccerStatsContext SoccerStatsContext 
    { 
        get { return this._context as SoccerStatsContext; } 
    }
}

