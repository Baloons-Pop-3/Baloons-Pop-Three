namespace BalloonsPop.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;

    /// <summary>
    /// This is a repository which save the data in a txt file(JSON format)
    /// </summary>
    /// <typeparam name="T">Type of the model object used to </typeparam>
    class TxtFileRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string pathOfTxtFile;
        private readonly JavaScriptSerializer jsonSerializer;

        public TxtFileRepository(string path)
        {
            this.pathOfTxtFile = path;
            this.jsonSerializer = new JavaScriptSerializer();
        }

        /// <summary>
        ///The objects are serialized internally and saved in the file in JSON format
        /// </summary>
        /// <param name="entity">Type of object to save in the repository</param>
        public void Add(T entity)
        {
            var jsonEntity = jsonSerializer.Serialize(entity);

            using (StreamWriter TopScoreStreamWriter = new StreamWriter(this.pathOfTxtFile,true))
            {
                TopScoreStreamWriter.WriteLine(jsonEntity);
            }
        }

        /// <summary>
        ///The objects are deserialized internally after fetching
        /// </summary>
        /// <returns>Type of object to get from repository</returns>
        public IEnumerable<T> All()
        {
            var fetchedCollection = new List<T>();

             using (StreamReader TopScoreStreamReader = new StreamReader(this.pathOfTxtFile))
            {
                string line = TopScoreStreamReader.ReadLine();
                while (line != null)
                {
                    T item = jsonSerializer.Deserialize<T>(line);
                    fetchedCollection.Add(item);

                    line = TopScoreStreamReader.ReadLine();
                }
            }

            return fetchedCollection;
        }
    }
}
