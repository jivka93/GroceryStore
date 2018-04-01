using Common;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.UnitTests
{
    [TestClass]
    class OrderServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            Assert.ThrowsException<ArgumentNullException>(() => new OrderService(unitOfWorkMock.Object, null, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitsOfWorkIsNull()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            Assert.ThrowsException<ArgumentNullException>(() => new OrderService(null, mapperMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenGenericRepositoryIsNull()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            Assert.ThrowsException<ArgumentNullException>(() => new OrderService(unitOfWorkMock.Object, mapperMock.Object, null));
        }

        [TestMethod]
        public void AddMethod_ShouldThrowArgumentNullException_WhenNullIsPassed()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => orderService.Add(null));
        }

        [TestMethod]
        public void AddWithoutMappingMethod_ShouldThrowArgumentNullException_WhenNullIsPassed()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => orderService.AddWithoutMapping(null));
        }

        //[TestMethod]
        //public void GetAllByIdMethod_ShouldThrowArgumentException_WhenZeroIsPassed()
        //{
        //    var mapperMock = new Mock<IMappingProvider>();
        //    var unitOfWorkMock = new Mock<IEfUnitOfWork>();
        //    var repoMock = new Mock<IEfGenericRepository<Order>>();

        //    var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

        //    Assert.ThrowsException<ArgumentNullException>(() => orderService.GetAllById(0));
        //}
    }
}
