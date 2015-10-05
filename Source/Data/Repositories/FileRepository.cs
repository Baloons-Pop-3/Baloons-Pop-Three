namespace BalloonsPop.Data.Repositories
{
    using System.Collections.Generic;
    using System.IO;
    using BalloonsPop.Common.Serializer;
    using BalloonsPop.Common.Serializer.Contracts;
    using BalloonsPop.Data.Contracts;
    using BalloonsPop.Models.Contracts;

    /// <summary>
    /// This is a repository which save the data in a txt file(JSON format)
    /// </summary>
    /// <typeparam name="T">Type of the model object used to </typeparam>
    internal class TxtFileRepository<T> : IGenericRepository<T> where T : class, IModel
    {
        private readonly string pathOfTxtFile;
        private readonly ISerializer serializer;

        public TxtFileRepository(string path)
        {
            this.pathOfTxtFile = path;
            this.serializer = new JsonSerializer();
        }

        /// <summary>
        /// The objects are serialized internally and saved in the file in JSON format
        /// </summary>
        /// <param name="entity">Type of object to save in the repository</param>
        public void Add(T entity)
        {
            var jsonEntity = this.serializer.Serialize<T>(entity);

            using (StreamWriter writer = new StreamWriter(this.pathOfTxtFile, true))
            {
                writer.WriteLine(jsonEntity);
            }
        }

        /// <summary>
        /// The objects are deserialized internally after fetching
        /// </summary>
        /// <returns>Type of object to get from repository</returns>
        public IEnumerable<T> All()
        {
            var fetchedCollection = new List<T>();

            using (StreamReader reader = new StreamReader(this.pathOfTxtFile))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    T item = this.serializer.Deserialize<T>(line);
                    fetchedCollection.Add(item);

                    line = reader.ReadLine();
                }
            }

            return fetchedCollection;
        }

        public T Find(object id)
        {
            using (StreamReader reader = new StreamReader(this.pathOfTxtFile))
            {
                string currentId = null;

                string line = reader.ReadLine();
                while (line != null)
                {
                    T item = this.serializer.Deserialize<T>(line);

                    currentId = item.Id;

                    if (currentId.ToString() == id.ToString())
                    {
                        return item;
                    }

                    line = reader.ReadLine();
                }
            }

            return default(T);
        }
    }
}