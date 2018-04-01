using AutoMapper;
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
    class UserContextTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            //var loggedUserId = It.IsAny<int>();
            //var mapperMock = new Mock<IMappingProvider>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new UserContext(null, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object));
        }
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenHashingIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new UserContext(mapperMock.Object, null, unitOfWorkMock.Object, repoMock.Object));
        }
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            Assert.ThrowsException<ArgumentNullException>(() => new UserContext(mapperMock.Object, hashingMock.Object, null, repoMock.Object));
        }
        [TestMethod]
        public void Constructor_ShouldthrowArgumentNullException_WhenGenericRepoIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();

            Assert.ThrowsException<ArgumentNullException>(() => new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, null));
        }
        [TestMethod]
        public void Login_ShouldSetLoginUserId_WhenCalled()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
            userContext.Login(1234);
            Assert.AreEqual(1234, userContext.LoggedUserId);
        }
        [TestMethod]
        public void Logout_ShouldSetLoginUserIdToNull_WhenCalled()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);
            userContext.Login(1234);
            Assert.AreEqual(1234, userContext.LoggedUserId);
            userContext.Logout();
            Assert.AreEqual(null, userContext.LoggedUserId);
        }
        [TestMethod]
        public void CheckLogin_ShouldThrowArgumentNullException_WhenUsernameIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => userContext.CheckLogin(null, It.IsAny<string>()));
        }
        [TestMethod]
        public void CheckLogin_ShouldThrowArgumentNullException_WhenUsernameIsEmpty()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => userContext.CheckLogin("", It.IsAny<string>()));
        }
        [TestMethod]
        public void CheckLogin_ShouldThrowArgumentNullException_WhenPasswordIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => userContext.CheckLogin(It.IsAny<string>(), null));
        }
        [TestMethod]
        public void CheckLogin_ShouldThrowArgumentNullException_WhenPasswordIsEmpty()
        {
            var mapperMock = new Mock<IMapper>();
            var hashingMock = new Mock<IHashingPassword>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<User>>();

            var userContext = new UserContext(mapperMock.Object, hashingMock.Object, unitOfWorkMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => userContext.CheckLogin(It.IsAny<string>(), ""));
        }
    }
}
