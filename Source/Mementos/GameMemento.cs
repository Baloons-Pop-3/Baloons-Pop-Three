namespace BalloonsPop.Mementos
{
    using BalloonsPop.Models;
    using BalloonsPop.Models.Contracts;

    internal class GameMemento : IGame
    {
        public GameMemento(GameField field, int shootCounter, int remainingBallons)
        {
            this.Field = field.Clone();
            this.ShootCounter = shootCounter;
            this.RemainingBalloons = remainingBallons;
        }

        public GameField Field { get; set; }

        public int ShootCounter { get; set; }

        public int RemainingBalloons { get; set; }
    }
}