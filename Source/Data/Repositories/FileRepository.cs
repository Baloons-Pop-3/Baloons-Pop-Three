namespace BalloonsPop.Data
{
    using Common.Serializer;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;
    using System;
    using System.Linq;

    /// <summary>
    /// This is a repository which save the data in a txt file(JSON format)
    /// </summary>
    /// <typeparam name="T">Type of the model object used to </typeparam>
    class TxtFileRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string pathOfTxtFile;
        private readonly ISerializer serializer;

        public TxtFileRepository(string path)
        {
            this.pathOfTxtFile = path;
            this.serializer = new JsonSerializer();
        }

        /// <summary>
        ///The objects are serialized internally and saved in the file in JSON format
        /// </summary>
        /// <param name="entity">Type of object to save in the repository</param>
        public void Add(T entity)
        {
            var jsonEntity = serializer.Serialize<T>(entity);

            using (StreamWriter writer = new StreamWriter(this.pathOfTxtFile,true))
            {
                writer.WriteLine(jsonEntity);
            }
        }

        /// <summary>
        ///The objects are deserialized internally after fetching
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
                    T item = serializer.Deserialize<T>(line);
                    fetchedCollection.Add(item);

                    line = reader.ReadLine();
                }
            }

            return fetchedCollection;
        }

        public T Find(object property)
        {
            using (StreamReader reader = new StreamReader(this.pathOfTxtFile))
            {
                object id = null;

                string line = reader.ReadLine();
                while (line != null)
                {
                    T item = serializer.Deserialize<T>(line);

                    id=item.GetType().GetProperty("Id").GetValue(item,null);

                    if (property.ToString()==id.ToString())
                    {
                        return item; 
                    }

                    line = reader.ReadLine();
                }
            }

            return null;
        }
    }
}
