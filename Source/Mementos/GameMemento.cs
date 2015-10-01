namespace BalloonsPop.Mementos
{
    internal class GameMemento
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