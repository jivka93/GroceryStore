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

namespace Services.UnitTests
{
    [TestClass]
    public class UserServiceTests
    {
        // mocking Entity framework
        //var mockContext = new Mock<IGroceryStoreContext>();
        //var data = new List<User> { }.AsQueryable();
        //var mockSet = new Mock<IDbSet<User>>();
        //mockSet.As<IQueryable<User>>().Setup(x => x.Provider).Returns(data.Provider);
        //mockSet.As<IQueryable<User>>().Setup(x => x.Expression).Returns(data.Expression);
        //mockSet.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(data.ElementType);
        //mockSet.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            // Arrange
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(null, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenHashingIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(mapperMock.Object, null, unitOfWorkMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserService(mapperMock.Object, hashingMock.Object, null, repoMock.Object));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenUsernameIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            var password = "password";
            var phone = "11111111";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(null, password, phone));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenPasswordIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            var username = "username";
            var phone = "11111111";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(username, null, phone));
        }

        [TestMethod]
        public void RegisterUser_ShouldThrowArgumentNullException_WhenPhoneIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            var username = "username";
            var password = "password";

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => userService.RegisterUser(username, password, null));
        }

        [TestMethod]
        public void GetAllUsers_ShouldCallRepoAllProjectTo()
        {

            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var collectionMock = new Mock<IQueryable<User>>();
            repoMock.Setup(x => x.All).Returns(collectionMock.Object);

            mapperMock.Setup(x => x.ProjectTo<User, UserModel>(collectionMock.Object)).Verifiable();

            // Act
            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
            var users = userService.GetAllUsers();

            // Assert
            mapperMock.Verify(x => x.ProjectTo<User, UserModel>(collectionMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetSpecificUserByID_ShouldWorkCorrectly()
        {
            //Arrange
            var stubMapper = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();
            var fakeUserService = new UserService(stubMapper.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            var data = new List<User>
            {
                new User { Id = 1},
                new User { Id = 3 ,FirstName="pesho"},
                new User { Id = 4 }
            }.AsQueryable();

            var returnedData = new List<UserModel>
            {
                new UserModel { Id = 1},
                new UserModel { Id = 3 ,FirstName="pesho"},
                new UserModel { Id = 4 }
            }.AsQueryable();

            repoMock.Setup(x => x.All).Returns(data);
            stubMapper.Setup(x => x.ProjectTo<User, UserModel>(data)).Returns(returnedData);
            //Act 
            var returnedUser = fakeUserService.GetSpecificUser(3);

            //Assert
            Assert.IsInstanceOfType(returnedUser, typeof(UserModel));
            Assert.AreEqual("pesho", returnedUser.FirstName);
            Assert.AreEqual(3, returnedUser.Id);
        }

        [TestMethod]
        public void GetSpecificUserByName_ShouldWorkCorrectly()
        {
            //Arrange
            var stubMapper = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();
            var fakeUserService = new UserService(stubMapper.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            var data = new List<User>
            {
                new User { Id = 1},
                new User { Id = 3 ,FirstName="pesho", Username="pesho123"},
                new User { Id = 4 }
            }.AsQueryable();

            var returnedData = new List<UserModel>
            {
                new UserModel { Id = 1},
                new UserModel { Id = 3 ,FirstName="pesho", Username="pesho123"},
                new UserModel { Id = 4 }
            }.AsQueryable();

            repoMock.Setup(x => x.All).Returns(data);
            stubMapper.Setup(x => x.ProjectTo<User, UserModel>(data)).Returns(returnedData);
            //Act 
            var returnedUser = fakeUserService.GetSpecificUser("pesho123");

            //Assert
            Assert.IsInstanceOfType(returnedUser, typeof(UserModel));
            Assert.AreEqual("pesho", returnedUser.FirstName);
            Assert.AreEqual(3, returnedUser.Id);
        }

    }
}
