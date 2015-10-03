using BalloonsPop.Models;
using BalloonsPop.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPop.LogicProviders.Contracts
{
    interface IGameLogicProvider
    {
        Game Game { get; set; }

        void ShootBalloonAtPosition(Coordinates positionToShoot);
    }
}
