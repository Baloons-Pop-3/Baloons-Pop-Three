namespace BalloonsPop.Data.Contracts
{
    using BalloonsPop.Models; 

    public interface IBalloonsData
    {
        IGenericRepository<Player> Players { get; }

        // for saving and loading games
        IGenericRepository<Game> Games { get; }
    }
}