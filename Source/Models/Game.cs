namespace BalloonsPop
{
    using Models;
    using System;

    internal class Game
    {
        public Game(GameField field)
        {
            this.Field = field;
            this.RemainingBaloons = field.FieldRows*field.FieldCols;
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