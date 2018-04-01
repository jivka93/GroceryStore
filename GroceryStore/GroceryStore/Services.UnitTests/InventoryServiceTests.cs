using Common;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;

namespace Services.UnitTests
{
    [TestClass]
    public class InventoryServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        { 
            var mapperMock = new Mock<IMappingProvider>();
            var repoMock = new Mock<IEfGenericRepository<Inventory>>();

            Assert.ThrowsException<ArgumentNullException>(() => new InventoryService(null, mapperMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Inventory>>();

            Assert.ThrowsException<ArgumentNullException>(() => new InventoryService(unitOfWorkMock.Object, null, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNulException_WhenGenericRepoIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();

            Assert.ThrowsException<ArgumentNullException>(() => new InventoryService(unitOfWorkMock.Object, mapperMock.Object, null));
        }
    }
}
