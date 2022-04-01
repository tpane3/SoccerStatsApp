﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Core.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Player> Players { get; set; }
}

