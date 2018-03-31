using AutoMapper;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitTests
{
    [TestClass]
    class InventoryServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        { 
            var mapperMock = new Mock<IMapper>();
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
            var mapperMock = new Mock<IMapper>();

            Assert.ThrowsException<ArgumentNullException>(() => new InventoryService(unitOfWorkMock.Object, mapperMock.Object, null));
        }
    }
}
