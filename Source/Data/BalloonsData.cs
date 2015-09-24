namespace BalloonsPop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class BalloonsData : IBalloonsData
    {
        public BalloonsData(IGenericRepository<Player> players, IGenericRepository<GameModel> games)
        {
            this.Players = players;
            this.Games = games;
        }

        public IGenericRepository<GameModel> Games { private set; get; }

        public IGenericRepository<Player> Players { private set;  get; }
    }
}
