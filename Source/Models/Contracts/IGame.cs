namespace BalloonsPop.Models.Contracts
{
    internal interface IGame
    {
        GameField Field { get; set; }

        int ShootCounter { get; set; }

        int RemainingBalloons { get; set; }
    }
}
