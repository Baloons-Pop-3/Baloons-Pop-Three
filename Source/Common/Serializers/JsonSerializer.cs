namespace BalloonsPop.Common.Serializer
{
    using BalloonsPop.Common.Serializer.Contracts;
    using Newtonsoft.Json;

    internal class JsonSerializer : ISerializer
    {
        /// <summary>
        /// Serializes object to JSON.
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="entity">Object of class T</param>
        /// <returns>Serialized object as string.</returns>
        public string Serialize<T>(T entity) where T : class
        {
            return JsonConvert.SerializeObject(entity);
        }

        /// <summary>
        /// De-serializes object from JSON. 
        /// </summary>
        /// <typeparam name="T">Class name</typeparam>
        /// <param name="input">String input to be de-serialized</param>
        /// <returns>De-serialized object from string.</returns>
        public T Deserialize<T>(string input) where T : class
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}