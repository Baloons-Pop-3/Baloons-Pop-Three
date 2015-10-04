namespace BalloonsPop.Models.Contracts
{
    public interface IGame
    {
        GameField Field { get; set; }

        int ShootCounter { get; set; }

        int RemainingBalloons { get; set; }
    }
}
