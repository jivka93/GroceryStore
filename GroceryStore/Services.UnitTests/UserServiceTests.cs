using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Contracts;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services.Contacts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services.UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            // Arrange
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(null, hashingMock.Object, unitOfWorkMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenHashingIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(mapperMock.Object, null, unitOfWorkMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(mapperMock.Object, hashingMock.Object, null));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenUsernameIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object);

            var password = "password";
            var phone = "11111111";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(null, password, phone));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenPasswordIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object);

            var username = "username";
            var phone = "11111111";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(username, null, phone));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenPhoneIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object);

            var username = "username";
            var password = "password";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(username, password, null));
        }

        //[TestMethod]
        //public void GetAllUsers_Should()
        //{
        //    // mocking Entity framework
        //    var mockContext = new Mock<IGroceryStoreContext>();
        //    var data = new List<User> { }.AsQueryable();
        //    var mockSet = new Mock<IDbSet<User>>();
        //    mockSet.As<IQueryable<User>>().Setup(x => x.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<User>>().Setup(x => x.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

        //    // Arrange
        //    var mapperMock = new Mock<IMapper>();
        //    var hashingMock = new Mock<IHashingPassword>();
        //    var unitOfWorkMock = new Mock<IEfUnitOfWork>();

        //    unitOfWorkMock.Setup(x => x.Users.All.ProjectTo<UserModel>()).Verifiable();

        //    //unitOfWorkMock.Setup(x => x.Users.All.ProjectTo<IUserModel>().Where(y => y.Username == "userName").FirstOrDefault())
        //    //    .Returns(userMock.Object);

        //    var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object);

        //    var actual = userService.GetAllUsers().Count();

        //    // Assert
        //    unitOfWorkMock.Verify(x => x.Users.All.ProjectTo<UserModel>(), Times.Once);
        //}
    }
}
