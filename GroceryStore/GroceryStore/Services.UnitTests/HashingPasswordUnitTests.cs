using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Contacts;

namespace Services.UnitTests
{
    [TestClass]
    public class HashingPasswordUnitTests
    {
        [TestMethod]
        public void GetSHA1HashData_ShouldChangeTheInputValue()
        {
            var hasher = new Mock<IHashingPassword>();
            var inputedPassword = "555555";

            var output = hasher.Object.GetSHA1HashData(inputedPassword);

            Assert.AreNotEqual(inputedPassword, output);
        }
    }
}
