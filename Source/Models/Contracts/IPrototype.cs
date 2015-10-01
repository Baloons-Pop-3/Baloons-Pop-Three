namespace BalloonsPop.Models.Contracts
{
    internal interface IPrototype<T> where T : class
    {
        T Clone();
    }
}