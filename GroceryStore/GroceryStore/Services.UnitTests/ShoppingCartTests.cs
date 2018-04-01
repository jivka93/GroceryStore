using DTO;
using DTO.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using System;

namespace Services.UnitTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProducts()
        {
            // Arrange && Act
            var shoppingCart = new ShoppingCart();

            //Assert
            Assert.IsNotNull(shoppingCart.Products);          
        }

        [TestMethod]
        public void Total_ShouldReturnZero_WhenNoProducts()
        {
            // Arrange && Act
            var shoppingCart = new ShoppingCart();

            //Assert
            Assert.IsTrue(shoppingCart.Total == 0.0m);
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void AddProduct_ShouldThrowException_WhenProductIsNull()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => shoppingCart.AddProduct(null));
        }

        [TestMethod]
        public void RemoveProduct_ShouldThrowException_WhenProductIsNull()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            var product = new Mock<IProductModel>();
            product.SetupGet(x => x.Price).Returns(10.0m);

            shoppingCart.AddProduct(product.Object);

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => shoppingCart.RemoveProduct(null));
        }

        [TestMethod]
        public void Total_ShouldReturnCorrectValue_WhenProductsAdded()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();

            var product1 = new Mock<IProductModel>();
            product1.SetupGet(x => x.Price).Returns(10.0m);

            var product2 = new Mock<IProductModel>();
            product2.SetupGet(x => x.Price).Returns(5.1m);

            // Act
            shoppingCart.AddProduct(product1.Object);
            shoppingCart.AddProduct(product2.Object);

            //Assert
            Assert.AreEqual(15.1m, shoppingCart.Total);
            Assert.AreEqual(2, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void Total_ShouldReturnCorrectValue_WhenProductsRemoved()
        {
            // Arrange 
            var shoppingCart = new ShoppingCart();

            var product1 = new Mock<IProductModel>();
            product1.SetupGet(x => x.Price).Returns(10.0m);
            product1.SetupGet(x => x.Id).Returns(1);

            var product2 = new Mock<IProductModel>();
            product2.SetupGet(x => x.Price).Returns(5.1m);
            product1.SetupGet(x => x.Price).Returns(10.0m);
            product2.SetupGet(x => x.Id).Returns(2);

            // Act
            shoppingCart.AddProduct(product1.Object);
            shoppingCart.AddProduct(product2.Object);
            shoppingCart.RemoveProduct(product2.Object);

            //Assert
            Assert.AreEqual(10.0m,shoppingCart.Total);
            Assert.AreEqual(1, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void Clear_RemoveAllProductsFromShoppingCart()
        {
            // Arrange
            var shoppingCart = new ShoppingCart();

            var product = new Mock<IProductModel>();
            product.SetupGet(x => x.Price).Returns(10.0m);

            shoppingCart.AddProduct(product.Object);

            // Act
            shoppingCart.Clear();

            //Assert
            Assert.AreEqual(0.0m, shoppingCart.Total);
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }
    }
}
