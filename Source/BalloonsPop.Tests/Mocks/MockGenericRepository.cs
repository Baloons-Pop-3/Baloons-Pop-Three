namespace BalloonsPop.Tests.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts;
    using Models.Contracts;
    using Moq;

    public class MockGenericRepository<T> where T : IModel
    {
        public readonly Mock<IGenericRepository<T>> MockedRepo;

        public MockGenericRepository(IEnumerable<T> collection)
        {
            this.MockedRepo = new Mock<IGenericRepository<T>>();

            this.MockedRepo.Setup(r => r.Add(It.IsAny<T>())).Verifiable();
            this.MockedRepo.Setup(r => r.All()).Returns(collection);
            this.MockedRepo.Setup(r => r.Find(It.IsAny<string>())).Returns((string id) => collection.FirstOrDefault(c=>c.Id==id));
        }
    }
}
