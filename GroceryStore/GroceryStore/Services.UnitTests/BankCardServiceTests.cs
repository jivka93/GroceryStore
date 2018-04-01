using AutoMapper;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services.Contacts;
using System;

namespace Services.UnitTests
{
    [TestClass]
    class BankCardServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(null, mapperMock.Object, userServiceMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenMapperIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(unitOfWorkMock.Object, null, userServiceMock.Object, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUserServiceIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(unitOfWorkMock.Object, mapperMock.Object, null, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenGenericRepoIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, null));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenNumberIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(null, It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenNumberIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard("", It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        //[TestMethod]
        //public void AddNewBankCard_ShouldThrowArgumentNullException_WhenExpDateIsNull()
        //{
        //    var unitOfWorkMock = new Mock<IEfUnitOfWork>();
        //    var mapperMock = new Mock<IMapper>();
        //    var userServiceMock = new Mock<IUserService>();
        //    var repoMock = new Mock<IEfGenericRepository<BankCard>>();

        //    var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

        //    Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(It.IsAny<string>(), null, It.IsAny<string>(), It.IsAny<int>()));
        //}

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenHolderNameIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(It.IsAny<string>(), It.IsAny<DateTime>(), null, It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenHolderNameIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMapper>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(It.IsAny<string>(), It.IsAny<DateTime>(), "", It.IsAny<int>()));
        }
    }
}

