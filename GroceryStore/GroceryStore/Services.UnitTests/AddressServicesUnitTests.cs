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
    public class AddressServicesUnitTests
    {

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var mapper = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var addressesMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, null, userServiceMock.Object, addressesMock.Object));
        }
        public void Constructor_ShouldThrowArgumentNullException_WhenUserServiceIsNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var mapper = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var addressesMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, mapper.Object, null, addressesMock.Object));
        }
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var mapper = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var addressesMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(null, mapper.Object, userServiceMock.Object, addressesMock.Object));
        }
        public void Constructor_ShouldThrowArgumentNullException_WhenAddressesIsNull()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var mapper = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var addressesMock = new Mock<IEfGenericRepository<Address>>();

            Assert.ThrowsException<ArgumentNullException>(() => new AddressService(unitOfWorkMock.Object, mapper.Object, userServiceMock.Object, null));
        }

    }
}
