using Common;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;

namespace Services.UnitTests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void ShouldHaveConstructorThatDependsOnUnitOfWork()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            // Assert
            Assert.IsInstanceOfType(new ProductService(unitOfWorkMock.Object,repoMock.Object, mapperMock.Object), typeof(ProductService));
        }
        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhenUnitOfWorkIsNull()
        {
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            Assert.ThrowsException<ArgumentNullException>(() => new ProductService(null, repoMock.Object, mapperMock.Object));
        }
        [TestMethod]
        public void Constructor_ShouldThrowArgumentIsNullException_WhenGenericRepoIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var mapperMock = new Mock<IMappingProvider>();

            Assert.ThrowsException<ArgumentNullException>(() => new ProductService(unitOfWorkMock.Object, null, mapperMock.Object));
        }
        [TestMethod]
        public void Constructor_ShouldThrowArgmentIsNullException_WhenMapperIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();

            Assert.ThrowsException<ArgumentNullException>(() => new ProductService(unitOfWorkMock.Object, repoMock.Object, null));
        }
        [TestMethod]
        public void SearchByName_ShouldThrowArgumentNullException_WhenProductNameIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            Assert.ThrowsException<ArgumentNullException>(() => productService.SearchByName(null));
        }
        [TestMethod]
        public void SearchByName_ShouldThrowArgumentException_WhenProductNameIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            Assert.ThrowsException<ArgumentException>(() => productService.SearchByName(""));
        }
        [TestMethod]
        public void SerachByCategory_ShouldThrowArgumentNullException_WhenCategoryIsNull()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            Assert.ThrowsException<ArgumentNullException>(() => productService.SearchByCategory(null));
        }
        [TestMethod]
        public void SerachByCategory_ShouldThrowArgumentException_WhenCategoryIsEmpty()
        {
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var mapperMock = new Mock<IMappingProvider>();

            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            Assert.ThrowsException<ArgumentException>(() => productService.SearchByCategory(""));
        }


    }


}
