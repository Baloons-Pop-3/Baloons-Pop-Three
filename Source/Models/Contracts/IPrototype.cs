namespace BalloonsPop.Models.Contracts
{
    public interface IPrototype<T> where T : class
    {
        T Clone();
    }
}