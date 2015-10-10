namespace BalloonsPop.Models.Contracts
{
    using BalloonsPop.Mementos;

    public interface IGame : IModel, IPrototype<IGame>
    {
        GameField Field { get; set; }

        int ShootCounter { get; set; }

        int RemainingBalloons { get; set; }

        GameMemento SaveMemento();

        void RestoreMemento(GameMemento memento);
    }
}
