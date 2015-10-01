namespace BalloonsPop.Data
{
    using System.Collections.Generic;
    using BalloonsPop.Models.Contracts;

    // this repo ha the purpose to be used for testing.
    internal class TestRepository<T> : IGenericRepository<T> where T : IModel
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

        public T Find(object id)
        {
            foreach (var item in this.testingDataBase)
            {
                if (item.Id == id.ToString())
                {
                    return item;
                }
            }

            return default(T);
        }
    }
}