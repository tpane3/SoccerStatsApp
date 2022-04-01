using SoccerStats.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Core.Interfaces.Repositories;

public interface ITeamRepository : IRepository<Team>
{
    // Return collection of players that belong to team
    public IEnumerable<Player> GetPlayers(string teamName);

    // Return team corresponding to the team name provided
    public Team GetTeam(string teamName);
}

