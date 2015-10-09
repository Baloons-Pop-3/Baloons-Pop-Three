using BalloonsPop.Mementos;

namespace BalloonsPop.Models.Contracts
{
    public interface IGame:IModel,IPrototype<IGame>
    {
        GameField Field { get; set; }

        int ShootCounter { get; set; }

        GameMemento SaveMemento();

        void RestoreMemento(GameMemento memento);

        int RemainingBalloons { get; set; }
    }
}
