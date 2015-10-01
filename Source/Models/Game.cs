﻿namespace BalloonsPop
{
    using Mementos;
    using Models.Contracts;

    internal class Game : IPrototype<Game>, IModel, IGame
    {
        public Game(GameField field)
        {
            this.Field = field;
            this.RemainingBalloons = field.FieldRows * field.FieldCols;
            this.ShootCounter = 0;
        }

        public string Id { get; set; }

        public GameField Field { get; set; }

        public int ShootCounter
        {
            set; get;
        }

        public int RemainingBalloons
        {
            set; get;
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

        public Game Clone()
        {
            var game = new Game(this.Field);
            game.RemainingBalloons = this.RemainingBalloons;
            game.ShootCounter = this.ShootCounter;

            return game;
        }
    }
}