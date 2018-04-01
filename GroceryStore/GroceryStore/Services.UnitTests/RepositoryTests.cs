using DAL;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.UnitTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepositoryAddEntity()
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
        public void RepositoryAddCollection()
        {
            //arrange
            var connection = DbConnectionFactory.CreateTransient();
            var stubDB = new GroceryStoreContext(connection);
            var userRepo = new EfGenericRepository<User>(stubDB);

            var user1 = new User
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                Username = "pesho123",
                Password = "pesho",
                PhoneNumber = "12345678"
            };

            var user2 = new User
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Username = "gosho123",
                Password = "gosho",
                PhoneNumber = "09876543"
            };

            var collection = new List<User>() { user1, user2 };
            //act
            userRepo.Add(collection);
            stubDB.SaveChanges();

            //assert
            Assert.AreEqual(2, stubDB.Users.Count());
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

        [TestMethod]
        public void RepositoryGetById()
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

            userRepo.Add(userToAdd);
            stubDB.SaveChanges();

            //act
            var actual = userRepo.GetById(1);

            //assert
            Assert.AreEqual(userToAdd.Username, actual.Username);
        }

        [TestMethod]
        public void RepositoryUpdate()
        {
            //arrange
            var connection = DbConnectionFactory.CreateTransient();
            var stubDB = new GroceryStoreContext(connection);
            var userRepo = new EfGenericRepository<User>(stubDB);

            var user = new User
            {
                FirstName = "Pesho",
                LastName = "Pesho",
                Username = "Pesho",
                Password = "oldPassord",
                PhoneNumber = "Pesho"
            };

            userRepo.Add(user);
            stubDB.SaveChanges();

            //act
            user.Password = "newPassword";
            userRepo.Update(user);

            string actual = userRepo.GetById(1).Password;

            //assert
            Assert.AreEqual("newPassword", actual);
        }
    }
}
