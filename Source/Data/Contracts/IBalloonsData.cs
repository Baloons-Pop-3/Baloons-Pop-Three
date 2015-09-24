using System.Collections.Generic;

namespace BalloonsPop.Data
{
    interface IBalloonsData
    {
        IGenericRepository<Player> Players { get;  }
        
        //for saving and loading games
        IGenericRepository<GameModel> Games { get;  }
    }
}
