using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPop.Data
{
    class TxtRepository<T> : IGenericRepository<T> where T :class
    {
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
