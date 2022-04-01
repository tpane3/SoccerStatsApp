using SoccerStats.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Core.Interfaces.Repositories;

public interface IPlayerRepository : IRepository<Player>
{
    public Player GetPlayer(int id);
    public Player GetPlayer(string userName);
    public Player GetPlayer(string firstName, string lastName);
}

