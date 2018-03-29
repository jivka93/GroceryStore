using DAL;
using DAL.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Services.Contacts;
using System.Collections.Generic;
using System.Data.Entity;
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

            // Assert
            Assert.IsInstanceOfType(new ProductService(unitOfWorkMock.Object), typeof(ProductService));
        }



    }


}
