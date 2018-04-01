using Common;
using DAL.Contracts;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void GetAll_ShouldCallRepoAllProjectTo()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();


            var collectionMock = new Mock<IQueryable<Product>>();
            repoMock.Setup(x => x.All).Returns(collectionMock.Object);

            mapperMock.Setup(x => x.ProjectTo<Product, ProductModel>(collectionMock.Object)).Verifiable();

            // Act
            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            var products = productService.GetAll();

            // Assert
            mapperMock.Verify(x => x.ProjectTo<Product, ProductModel>(collectionMock.Object), Times.Once);
        }

        [TestMethod]
        public void GetProductDirectlyFromDB_ShouldCallRepoGetById()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();

            repoMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();

            // Act
            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            var product = productService.GetProductDirectlyFromDB(5);

            // Assert
            repoMock.Verify(x => x.GetById(5), Times.Once);
        }

        [TestMethod]
        public void AddProducts_ShouldCallRepoAdd()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();
            var collection = new List<Product>();
            repoMock.Setup(x => x.Add(It.IsAny<ICollection<Product>>())).Verifiable();

            // Act
            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            productService.AddProducts(collection);

            // Assert
            repoMock.Verify(x => x.Add(It.IsAny<ICollection<Product>>()), Times.Once);
        }

        [TestMethod]
        public void AddProducts_ShouldCallUnitOfWorkSaveChanges()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();

            var collection = new List<Product>();

            repoMock.Setup(x => x.Add(It.IsAny<ICollection<Product>>())).Verifiable();
            unitOfWorkMock.Setup(x => x.SaveChanges()).Verifiable();

            // Act
            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);
            productService.AddProducts(collection);

            // Assert
            repoMock.Verify(x => x.Add(It.IsAny<ICollection<Product>>()), Times.Once);
            unitOfWorkMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void SearchByCategory_ShouldThrowNullArgumentException_WhenCategoryIsNull()
        {
            // Arrange
            var mapperMock = new Mock<IMappingProvider>();
            var unitOfWorkMock = new Mock<IEfUnitOfWork>();
            var repoMock = new Mock<IEfGenericRepository<Product>>();

            var productService = new ProductService(unitOfWorkMock.Object, repoMock.Object, mapperMock.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => productService.SearchByCategory(null));
        }
    }

}
