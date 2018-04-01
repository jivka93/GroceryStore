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
    class AddressServiceTests
    {
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
        public void TryingToSetup_AddAddress()
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
            addressService.AddNewAddress(someAddressText, someUserId);
            // Assert
            genericRepoMock.Verify(x => x.Add(It.IsAny<Address>()), Times.Once);
        }
    }
}
