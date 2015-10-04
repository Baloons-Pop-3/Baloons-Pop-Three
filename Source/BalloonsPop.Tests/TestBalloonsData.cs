using BalloonsPop.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalloonsPop.Models;

namespace BalloonsPop.Tests.Mocks
{
    class TestBalloonsData : IBalloonsData
    {
        public TestBalloonsData(IGenericRepository<Player> players, IGenericRepository<Game> games)
        {
            this.Players = players;
            this.Games = games;
        }

        public IGenericRepository<Game> Games { get; private set;}

        public IGenericRepository<Player> Players  {get; private set; }
    }
}
