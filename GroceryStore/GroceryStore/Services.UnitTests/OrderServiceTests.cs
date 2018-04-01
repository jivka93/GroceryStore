using Common;
using DAL.Contracts;
using DTO;
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
    public class OrderServiceTests
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

        [TestMethod]
        public void AddMethod_ShouldWorkCorrectly()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Verifiable();
            repoMock.Setup(x => x.Add(It.IsAny<Order>())).Verifiable();
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.Add(new OrderModel());

            // Assert
            mapperMock.Verify(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>()), Times.Once);
            repoMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

    }
}
