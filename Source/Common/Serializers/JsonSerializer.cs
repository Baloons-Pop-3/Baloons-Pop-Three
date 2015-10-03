namespace BalloonsPop.Common.Serializer
{
    using BalloonsPop.Common.Serializer.Contracts;
    using Newtonsoft.Json;

    internal class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T entity) where T : class
        {
            return JsonConvert.SerializeObject(entity);
        }

        public T Deserialize<T>(string input) where T : class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}