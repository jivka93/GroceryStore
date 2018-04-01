using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Models.UnitTests.User
{
    [TestClass]
    public class BankCardTests
    {
        [TestMethod]
        public void Number_ShouldHaveCorrectMaxLength()
        {
            //Arrange
            var NumberProperty = typeof(BankCard).GetProperty("Number");

            //Act
            var maxLengthAttribute = NumberProperty.GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(16, maxLengthAttribute.Length);
        }

        [TestMethod]
        public void Username_ShouldHaveCorrectMinLength()
        {
            //Arrange
            var NumberProperty = typeof(BankCard).GetProperty("Number");

            //Act
            var minLengthAttribute = NumberProperty.GetCustomAttributes(typeof(MinLengthAttribute), false)
                .Cast<MinLengthAttribute>()
                .FirstOrDefault();

            //Assert
            Assert.AreEqual(16, minLengthAttribute.Length);
        }

    }
}
