using System;
using System.Collections.Generic;

namespace BalloonsPop.Data
{
    //this repo ha the purpose to be used for testing.
    class TestRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IList<T> testingDataBase;

        public TestRepository(IList<T> testingDataBase)
        {
            this.testingDataBase = testingDataBase;
        }
        public void Add(T entity)
        {
            this.testingDataBase.Add(entity);
        }

        public IEnumerable<T> All()
        {
            return this.testingDataBase;
        }

        public T Find(object property)
        {
            throw new NotImplementedException();
        }
    }
}
