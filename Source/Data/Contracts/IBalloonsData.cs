namespace BalloonsPop.Data
{
    internal interface IBalloonsData
    {
        IGenericRepository<Player> Players { get; }

        // for saving and loading games
        IGenericRepository<Game> Games { get; }
    }
}