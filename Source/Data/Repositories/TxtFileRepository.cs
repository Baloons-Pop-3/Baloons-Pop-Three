using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Data
{
    class TxtFileRepository<T> : IGenericRepository<T> where T :class
    {
        private readonly string pathOfTxtFile;

        public TxtFileRepository(string path)
        {
            this.pathOfTxtFile = path;
        }
        // Get the logic from TopScore.cs
        public void Add(T entity)
        {
            // TODO: implement logic of StreamWriter and adding new entity
            throw new NotImplementedException();
        }

        public IEnumerable<T> All()
        {
            // TODO: implement logic of StreamReader and getting all entities
            throw new NotImplementedException();
        }
    }
}
