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
    public class BankCardServiceTests
    {
        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mapperMock = new Mock<IMappingProvider>();
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
            var mapperMock = new Mock<IMappingProvider>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(unitOfWorkMock.Object, mapperMock.Object, null, repoMock.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenGenericRepoIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() => new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, null));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenNumberIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(null, It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenNumberIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard("", It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenHolderNameIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(It.IsAny<string>(), It.IsAny<DateTime>(), null, It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldThrowArgumentNullException_WhenHolderNameIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var repoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCard = new BankCardService(unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, repoMock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => bankCard.AddNewBankCard(It.IsAny<string>(), It.IsAny<DateTime>(), "", It.IsAny<int>()));
        }

        [TestMethod]
        public void AddNewBankCard_ShouldWorkCorrectly()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCardService = new BankCardService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            genericRepoMock.Setup(x => x.Add(It.IsAny<BankCard>())).Verifiable();

            // Act
            bankCardService.AddNewBankCard("1111222233334444", DateTime.Today,"Pesho Peshev", 1);

            // Assert
            genericRepoMock.Verify(x => x.Add(It.IsAny<BankCard>()), Times.Once);
        }


        [TestMethod]
        public void DeleteCardById_ShouldWorkCorrectly()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();
            var userServiceMock = new Mock<IUserService>();
            var genericRepoMock = new Mock<IEfGenericRepository<BankCard>>();

            var bankCardService = new BankCardService
                (unitOfWorkMock.Object, mapperMock.Object, userServiceMock.Object, genericRepoMock.Object);

            var card = new BankCard();

            genericRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(card);
            genericRepoMock.Setup(x => x.Delete(It.IsAny<BankCard>())).Verifiable();
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            // Act
            bool result = bankCardService.DeleteCardById(1);

            // Assert
            genericRepoMock.Verify(x => x.Delete(It.IsAny<BankCard>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(true, result);
        }
    }
}

