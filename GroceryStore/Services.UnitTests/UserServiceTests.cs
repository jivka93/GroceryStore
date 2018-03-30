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

            var collectionMock = new Mock <IQueryable<User>>();
            repoMock.Setup(x => x.All).Returns(collectionMock.Object);

            mapperMock.Setup(x => x.ProjectTo<User, UserModel>(collectionMock.Object)).Verifiable();

            // Act
            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
            var users = userService.GetAllUsers();

            // Assert
            mapperMock.Verify(x => x.ProjectTo<User, UserModel>(collectionMock.Object), Times.Once);
        }

        //[TestMethod]
        //public void UpdatePassword_ShouldCallRepoUpdate()
        //{
        //    // Arrange
        //    var mapperMock = new Mock<IMappingProvider>();
        //    var hashingMock = new Mock<IHashingPassword>();
        //    var unitOfWorkMock = new Mock<IEfUnitOfWork>();
        //    var repoMock = new Mock<IEfGenericRepository<User>>();

        //    int userId = 1;
        //    string password = "11111";

        //    var userMock = new Mock<User>();
        //    userMock.Setup(x => x.Id).Returns(userId);
        //    userMock.Setup(x => x.Password).Returns("");

        //    var collection = new List<User>() { userMock.Object};
        //    repoMock.Setup(x => x.All).Returns(collection.AsQueryable);

        //    hashingMock.Setup(x => x.GetSHA1HashData(It.IsAny<string>())).Returns(password);

        //    repoMock.Setup(x => x.Update(userMock.Object)).Verifiable();

        //    // Act
        //    var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
        //    userService.UpdatePassword(userId,password);

        //    // Assert
        //    repoMock.Verify(x => x.Update(userMock.Object), Times.Once);
        //}

        //[TestMethod]
        //public void UpdatePassword_ShouldCallUnitOfWorkSaveChanges()
        //{
        //    // Arrange
        //    var mapperMock = new Mock<IMappingProvider>();
        //    var hashingMock = new Mock<IHashingPassword>();
        //    var unitOfWorkMock = new Mock<IEfUnitOfWork>();
        //    var repoMock = new Mock<IEfGenericRepository<User>>();

        //    int userId = 1;
        //    string password = "11111";

        //    var userMock = new Mock<User>();
        //    userMock.Setup(x => x.Id).Returns(userId);
        //    userMock.Setup(x => x.Password).Returns("");

        //    var collection = new List<User>() { userMock.Object };
        //    repoMock.Setup(x => x.All).Returns(collection.AsQueryable);

        //    hashingMock.Setup(x => x.GetSHA1HashData(It.IsAny<string>())).Returns(password);

        //    unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

        //    // Act
        //    var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
        //    userService.UpdatePassword(userId, password);

        //    // Assert
        //    unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        //}

        [TestMethod]
        public void UpdateProfileInfo_ShouldCallUnitOfWorkSaveChanges()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            int userId = 1;
            string password = "11111";

            var userMock = new Mock<User>();
            userMock.Setup(x => x.Id).Returns(userId);
            userMock.Setup(x => x.FirstName).Returns("");

            var collection = new List<User>() { userMock.Object };
            repoMock.Setup(x => x.All).Returns(collection.AsQueryable);

            hashingMock.Setup(x => x.GetSHA1HashData(It.IsAny<string>())).Returns(password);

            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            // Act
            var userService = new UserService(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
            userService.UpdateProfileInfo(userId, "Pesho");

            // Assert
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
