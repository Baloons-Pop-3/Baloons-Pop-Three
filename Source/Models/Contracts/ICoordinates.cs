namespace BalloonsPop.Models.Contracts
{
    public interface ICoordinates
    {
         int X { get; set; }

         int Y { get; set; }

        bool TryParse(string input);
    }
}
