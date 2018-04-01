using Common;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services.Contacts;
using System;

namespace Services.UnitTests
{
    [TestClass]
    public class AddressServiceTests
    {
        [TestMethod]
        public void AddAddress_ShouldCallRepoAdd()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();
            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            genericRepoMock.Setup(x => x.Add(It.IsAny<Address>())).Verifiable();
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            var someAddressText = "Pesho";
            var someUserId = 5;

            // Act
            addressService.AddNewAddress(someAddressText,someUserId);

            // Assert
            genericRepoMock.Verify(x => x.Add(It.IsAny<Address>()), Times.Once);
        }

        [TestMethod]
        public void AddAddress_ShouldCallSaveChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();
            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            var someAddressText = "Pesho";
            var someUserId = 5;

            // Act
            addressService.AddNewAddress(someAddressText, someUserId);

            // Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhenUnitOfWorkIsNull()
        {
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(null, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhenMapperIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, null, userServiceMock.Object, genericRepoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhenUserServiceIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, mapperMock.Object, null, genericRepoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhengenericRepoIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, null));
        }

        [TestMethod]
        public void AddNewAddressMethod_ShouldTrowArgumentNullException_WhenStringIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            var addressService = new AddressService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => addressService.AddNewAddress(null, It.IsAny<int>()));
        }

        [TestMethod]
        public void DeleteAddressById_ShouldReturnCorrectValue()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            var address = new Address();

            genericRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(address);

            // Act
            bool result = addressService.DeleteAddressById(1);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeleteAddressById_ShouldCallRepoGetById()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            var address = new Address();

            genericRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(address);
            genericRepoMock.Setup(x => x.Delete(It.IsAny<Address>())).Verifiable();
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            // Act
            bool result = addressService.DeleteAddressById(1);

            // Assert
            genericRepoMock.Verify(x => x.Delete(It.IsAny<Address>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteAddressById_ShouldCallSaveChanges()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();

            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            var address = new Address();

            genericRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(address);
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            // Act
            bool result = addressService.DeleteAddressById(1);

            // Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
