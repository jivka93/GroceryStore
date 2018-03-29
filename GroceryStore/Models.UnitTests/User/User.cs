using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models.UnitTests.Users
{
    [TestClass]
    public class User
    {
        [TestMethod]
        public void ShouldHaveParameterlessConstructor()
        {
            Assert.IsInstanceOfType(new User(), typeof(User));
        }

        [TestMethod]
        [DataRow("MyNameIs")]
        [DataRow("123456789")]
        public void FirstName_ShouldBeSetAndGottenCorrectly(string firstName)
        {
            //Arrange && Act
            var user = new Models.User() { FirstName = firstName };

            //Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [TestMethod]
        public void FirstName_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var nameProperty = typeof(Models.User).GetProperty("FirstName");

            //Act
            var maxLengthAttribute = nameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.NameMaxLength, maxLengthAttribute.Length);
        }

        [TestMethod]
        public void Username_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var userNameProperty = typeof(Models.User).GetProperty("Username");

            //Act
            var maxLengthAttribute = userNameProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UserNameMaxLength, maxLengthAttribute.Length);
        }

        [TestMethod]
        public void Username_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var nameProperty = typeof(Models.User).GetProperty("Username");

            //Act
            var minLengthAttribute = nameProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.UserNameMinLength, minLengthAttribute.Length);
        }

        [TestMethod]
        public void PhoneNumber_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var phoneNumberProperty = typeof(Models.User).GetProperty("PhoneNumber");

            //Act
            var maxLengthAttribute = phoneNumberProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.PhoneNumberMaxLength, maxLengthAttribute.Length);
        }

        [TestMethod]
        public void PhoneNumber_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var phoneNumberProperty = typeof(Models.User).GetProperty("PhoneNumber");

            //Act
            var minLengthAttribute = phoneNumberProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(Constants.PhoneNumberMinLength, minLengthAttribute.Length);
        }


        [TestMethod]
        public void Test1()
        {
            var shoppingCart = new ShoppingCart();
        }
    }
}
