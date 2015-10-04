namespace BalloonsPop.Tests.Mocks
{
    using Models.Contracts;
    using Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;

    class MockGenericRepository<T> where T:IModel
    {
        public readonly Mock<IGenericRepository<T>> mockedRepo;

        public MockGenericRepository(IEnumerable<T> collection)
        {
            mockedRepo = new Mock<IGenericRepository<T>>();

            this.mockedRepo.Setup(r => r.Add(It.IsAny<T>())).Verifiable();
            this.mockedRepo.Setup(r => r.All()).Returns(collection);
            this.mockedRepo.Setup(r => r.Find(It.IsAny<string>())).Verifiable();
        }
    }
}
