using SoccerStats.Core.Interfaces.Repositories;
using SoccerStats.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data.Repositories;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    public PlayerRepository(SoccerStatsContext context) : base(context)
    {
    }

    public Player GetPlayer(int id)
    {
        return this._entity.Where(p => p.Id == id).SingleOrDefault();
    }

    public Player GetPlayer(string userName)
    {
        return this._entity.Where(p => p.UserName == userName).SingleOrDefault();

    }

    public Player GetPlayer(string firstName, string lastName)
    {
        return this._entity.Where(p => p.FirstName == firstName && p.LastName == lastName).FirstOrDefault();
    }

    public SoccerStatsContext SoccerStatsContext
    {
        get { return this._context as SoccerStatsContext; }
    }
}

