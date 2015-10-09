namespace BalloonsPop.Models.Contracts
{
    public interface IPlayer: IModel
    {
         int Score { get; set; }

         string Name { get; set; }
    }
}
