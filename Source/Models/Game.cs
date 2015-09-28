namespace BalloonsPop
{
    using Mementos;

    internal class Game
    {
        public Game(GameField field)
        {
            this.Field = field;
            this.RemainingBalloons = field.FieldRows*field.FieldCols;
            this.ShootCounter = 0;
        }

        public GameField Field { get; set; }

        public int ShootCounter
        {
            internal set; get;
        }
        public int RemainingBalloons
        {
            internal set; get;
        }

        public GameMemento SaveMemento()
        {
            return new GameMemento(this.Field, this.ShootCounter, this.RemainingBalloons);
        }

        public void RestoreMemento(GameMemento memento)
        {
            this.Field = memento.Field;
            this.ShootCounter = memento.ShootCounter;
            this.RemainingBalloons = memento.RemainingBalloons;
        }
    }
}