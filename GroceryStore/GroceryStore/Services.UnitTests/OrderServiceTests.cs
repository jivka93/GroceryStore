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
        public void AddMethod_ShouldCallMapperMap()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.Add(new OrderModel());

            // Assert
            mapperMock.Verify(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>()), Times.Once);
        }

        [TestMethod]
        public void AddMethod_ShouldCallRepoAdd()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            repoMock.Setup(x => x.Add(It.IsAny<Order>())).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.Add(new OrderModel());

            // Assert
            repoMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
        }

        [TestMethod]
        public void AddMethod_ShouldCallSaveChanges()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.Add(new OrderModel());

            // Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddWithoutMappingMethod_ShouldCallRepoAdd()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            repoMock.Setup(x => x.Add(It.IsAny<Order>())).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.AddWithoutMapping(new Order());

            // Assert
            repoMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
        }

        [TestMethod]
        public void AddWithoutMappingMethod_ShouldCallSaveChanges()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order = new Order();

            mapperMock.Setup(x => x.Map<OrderModel, Order>(It.IsAny<OrderModel>())).Returns(order);
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            orderService.AddWithoutMapping(new Order());

            // Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void GetAllById_ShouldGetCorrectOrders()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order1 = new Order() { UserId = 1};
            var order2 = new Order() { UserId = 1 };
            var order3 = new Order() { UserId = 2 };
            var order4 = new Order() { UserId = 2 };
            var list = new List<Order>() { order1, order2, order3, order4 }.AsQueryable();

            repoMock.Setup(x => x.All).Returns(list.AsQueryable());

            var om1 = new OrderModel() { UserId = 1 };
            var om2 = new OrderModel() { UserId = 1 };
            var mapped = new List<OrderModel>() { om1, om2 }.AsQueryable();

            mapperMock.Setup(x => x.ProjectTo<Order, OrderModel>(It.IsAny<IQueryable<Order>>())).Returns(mapped);

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            var result = orderService.GetAllById(1);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        public void GetAllById_ShouldCallRepoAll()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order1 = new Order() { UserId = 1 };
            var order2 = new Order() { UserId = 1 };
            var order3 = new Order() { UserId = 2 };
            var order4 = new Order() { UserId = 2 };
            var list = new List<Order>() { order1, order2, order3, order4 }.AsQueryable();

            repoMock.Setup(x => x.All).Returns(list.AsQueryable());

            var om1 = new OrderModel() { UserId = 1 };
            var om2 = new OrderModel() { UserId = 1 };
            var mapped = new List<OrderModel>() { om1, om2 }.AsQueryable();

            mapperMock.Setup(x => x.ProjectTo<Order, OrderModel>(It.IsAny<IQueryable<Order>>())).Returns(mapped);

            repoMock.Setup(x => x.All).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            var result = orderService.GetAllById(1);

            // Assert
            repoMock.Verify(x => x.All, Times.Once);
        }

        public void GetAllById_ShouldCallMapperProjectTo()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Order>>();

            var order1 = new Order() { UserId = 1 };
            var order2 = new Order() { UserId = 1 };
            var order3 = new Order() { UserId = 2 };
            var order4 = new Order() { UserId = 2 };
            var list = new List<Order>() { order1, order2, order3, order4 }.AsQueryable();

            repoMock.Setup(x => x.All).Returns(list.AsQueryable());

            var om1 = new OrderModel() { UserId = 1 };
            var om2 = new OrderModel() { UserId = 1 };
            var mapped = new List<OrderModel>() { om1, om2 }.AsQueryable();

            mapperMock.Setup(x => x.ProjectTo<Order, OrderModel>(It.IsAny<IQueryable<Order>>())).Returns(mapped);
            mapperMock.Setup(x => x.ProjectTo<Order, OrderModel>(It.IsAny<IQueryable<Order>>())).Verifiable();

            var orderService = new OrderService(unitOfWorkMock.Object, mapperMock.Object, repoMock.Object);

            // Act
            var result = orderService.GetAllById(1);

            // Assert
            mapperMock.Verify(x => x.ProjectTo<Order, OrderModel>(It.IsAny<IQueryable<Order>>()), Times.Once);
        }
    }
}
