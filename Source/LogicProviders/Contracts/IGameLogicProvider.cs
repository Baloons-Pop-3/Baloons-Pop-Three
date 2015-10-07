namespace BalloonsPop.LogicProviders.Contracts
{
    using System;
    using System.Linq;
    using BalloonsPop.Models;

    public interface IGameLogicProvider
    {
        Game Game { get; set; }

        void ShootBalloonAtPosition(Coordinates positionToShoot);
    }
}
