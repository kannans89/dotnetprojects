using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagementSystemLibrary.Model;
using TaskManagementSystemLibrary.TaskMangementSystemRepository;
using System.Linq;

namespace TaskMangementSystemLibrary.PositiveTest.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void AddShouldAddUserIntoDatabase()
        {
            //Arrange
            IRepository<User> repository = new UserRepository();
            //Act
            var intialCount = repository.Get().ToList().Count;
            User user = new User
            {
                FirstName = "Raj",
                LastName = "Patel",
                MobileNumber = 9773852482,
                Email = "raj@gmail.com",
                UserName = "raj123",
                Password = "raj"
            };

            repository.Add(user);
            var afterCount = repository.Get().ToList().Count;
            //Assert
            Assert.IsTrue(intialCount<afterCount);
        }

        [TestMethod]
        public void GetByIdShouldReturnVlue()
        {
            //Arrange
            IRepository<User> repository = new UserRepository();
            //Act
            var user = repository.GetById(1);
            
            //Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void GetShouldReturnVlue()
        {
            //Arrange
            IRepository<User> repository = new UserRepository();
            //Act
            var user = repository.Get();

            //Assert
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UpdateShouldUpdateDatabaseEntity()
        {
            //Arrange
            IRepository<User> repository = new UserRepository();
            //Act
            User user = new User()
            {
                FirstName = "Rohit",
                LastName = "Randhive",
                MobileNumber = 9773852482,
                Email = "rohit123@gmail.com",
                UserName = "rohit123",
                Password = "rohit"
            };
            repository.Update(user,3);
            var userByName = repository.GetByName("Rohit");

            //Assert
            Assert.IsNotNull(userByName);
        }

        [TestMethod]
        public void DeleteShouldDeleteUserData()
        {
            //arrange
            IRepository<User> userRepository = new UserRepository();

            //act
            var initialCount = userRepository.Get().ToList().Count;
            userRepository.Delete(2);
            var afterCount = userRepository.Get().ToList().Count;

            //assert
            Assert.AreNotEqual(initialCount, afterCount);
        }
    }
}
