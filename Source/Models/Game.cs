namespace BalloonsPop
{
    using System;

    internal class Game
    {
        public Game(GameField field)
        {
            this.Field = field;
            this.RemainingBaloons = field.BalloonsCols*field.BalloonsRows;
            this.ShootCounter = 0;
        }

        public GameField Field { get; set; }

        public int ShootCounter
        {
            internal set; get;
        }
        public int RemainingBaloons
        {
            internal set; get;
        }
    }
}