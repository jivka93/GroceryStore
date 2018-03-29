using Common;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;

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



    }


}
