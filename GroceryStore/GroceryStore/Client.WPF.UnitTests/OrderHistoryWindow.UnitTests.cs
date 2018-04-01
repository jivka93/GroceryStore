using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Contacts;

namespace Client.WPF.UnitTests
{
    [TestClass]
    public class OrderHistoryWindowUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var orderServiceMock = new Mock<IOrderService>();
            var userContextMock = new Mock<IUserContext>();


            var orderHistoryWindow = new OrderHistoryWindow(orderServiceMock.Object, userContextMock.Object);

            Assert.IsInstanceOfType(orderHistoryWindow, GetType(OrderHistoryWindow));
            Assert.

        }
    }
}
