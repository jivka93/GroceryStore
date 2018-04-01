using DAL;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;

namespace Services.UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepositoryAdd()
        {
            // Arrange
            var connection = DbConnectionFactory.CreateTransient();
            var mockDB = new GroceryStoreContext(connection);

            var userRepo = new EfGenericRepository<User>(mockDB);
            var addressRepo = new EfGenericRepository<Address>(mockDB);

            var user = new User { Username = "pesho123", Password = "123456", PhoneNumber = "1234567890"};
            var addressToAdd = new Address { AddressText = "Pesho", UserId = 1};

            // Act
            userRepo.Add(user);
            //addressRepo.Add(addressToAdd);

            // Assert
            Assert.AreEqual(1, mockDB.Users.Count());
            //Assert.AreEqual(1, mockDB.Addresses.Count());
        }

        [TestMethod]
        public void RepositorAdd()
        {
            //arrange
            var connection = DbConnectionFactory.CreateTransient();
            var stubDB = new GroceryStoreContext(connection);
            var userRepo = new EfGenericRepository<User>(stubDB);

            var userToAdd = new User
            {
                FirstName = "Pesho",
                LastName = "Pesho",
                Username = "Pesho",
                Password = "Pesho",
                PhoneNumber = "Pesho"
            };

            //act
            userRepo.Add(userToAdd);
            stubDB.SaveChanges();

            //assert
            Assert.AreEqual(1, stubDB.Users.Count());
        }

        [TestMethod]
        public void RepositoryAll()
        {
            //arrange
            var connection = DbConnectionFactory.CreateTransient();
            var stubDB = new GroceryStoreContext(connection);
            var userRepo = new EfGenericRepository<User>(stubDB);

            var userToAdd = new User
            {
                FirstName = "Pesho",
                LastName = "Pesho",
                Username = "Pesho",
                Password = "Pesho",
                PhoneNumber = "Pesho"
            };
            var userToAdd1 = new User
            {
                FirstName = "Pesho1",
                LastName = "Pesho1",
                Username = "Pesho1",
                Password = "Pesho1",
                PhoneNumber = "Pesho1"
            };
            var userToAdd2 = new User
            {
                FirstName = "Pesho2",
                LastName = "Pesho2",
                Username = "Pesho2",
                Password = "Pesho2",
                PhoneNumber = "Pesho2"
            };
            stubDB.Users.Add(userToAdd);
            stubDB.Users.Add(userToAdd1);
            stubDB.Users.Add(userToAdd2);
            stubDB.SaveChanges();

            //act
            var allUsers = userRepo.All;

            //assert
            Assert.AreEqual(3, allUsers.Count());
            Assert.IsInstanceOfType(allUsers, typeof(IQueryable));
        }
    }
}
