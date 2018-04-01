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
        public void AddAddress_ShouldWorkCorrectly()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();
            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            genericRepoMock.Setup(x => x.Add(It.IsAny<Address>())).Verifiable();

            var someAddressText = "Pesho";
            var someUserId = 5;

            // Act
            addressService.AddNewAddress(someAddressText,someUserId);

            // Assert
            genericRepoMock.Verify(x => x.Add(It.IsAny<Address>()), Times.Once);
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
<<<<<<< HEAD:GroceryStore/GroceryStore/Services.UnitTests/AddressServiceTests.cs
        public void DeleteAddressById_ShouldWorkCorrectly()
=======
        public void TryingToSetup_AddAddress()
>>>>>>> 0f0e76c26fcf8fa5b0f9d9e2f96f8a232e544439:GroceryStore/Services.UnitTests/AddressServiceTests.cs
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<Address>>();
<<<<<<< HEAD:GroceryStore/GroceryStore/Services.UnitTests/AddressServiceTests.cs

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
            Assert.AreEqual(true, result);
=======
            var addressService = new AddressService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            genericRepoMock.Setup(x => x.Add(It.IsAny<Address>())).Verifiable();

            var someAddressText = "Pesho";
            var someUserId = 5;

            // Act
            addressService.AddNewAddress(someAddressText, someUserId);
            // Assert
            genericRepoMock.Verify(x => x.Add(It.IsAny<Address>()), Times.Once);
>>>>>>> 0f0e76c26fcf8fa5b0f9d9e2f96f8a232e544439:GroceryStore/Services.UnitTests/AddressServiceTests.cs
        }
    }
}
