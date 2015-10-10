namespace BalloonsPop.Common.Serializer.Contracts
{
    /// <summary>
    /// Serializer interface.
    /// </summary>
    internal interface ISerializer
    {
        string Serialize<T>(T entity) where T : class;

        T Deserialize<T>(string input) where T : class;
    }
}