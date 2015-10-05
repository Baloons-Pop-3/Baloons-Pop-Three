using BalloonsPop.Data.Contracts;
using BalloonsPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.Controllers
{
    interface IGamesController
    {
        void AddGame(Game game);

        IEnumerable<Game> All();

        Game SearchById(string id);
    }
}
