using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;
using TaskManagementSystemLibrary.TaskMangementSystemRepository;

namespace TaskMangementSystemLibrary.PositiveTest.PositiveTest
{
    [TestClass]
    public class MainTaskRepositoryTest
    {
        [TestMethod]
        public void AddMethodShouldAddEntity()
        {
            //arrange
            IRepository<MainTask> mainTaskRepository = new MainTaskRepository();
            IRepository<User> userRepository = new UserRepository();

            //act
            var intialCountMainTask = mainTaskRepository.Get().ToList().Count;
            User user = userRepository.GetById(1);
            MainTask mainTask = new MainTask
            {
                Name = "plyaing",
                Date = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy")),
                StartTime = DateTime.Parse(DateTime.Now.ToString("HH tt")),
                EndTime = DateTime.Parse(DateTime.Today.ToString("HH tt")),
                Priority = PriorityType.LOW,
                User = user
            };
            mainTaskRepository.Add(mainTask);
            user.MainTasks.Add(mainTask);
            var afterCountMainTask = mainTaskRepository.Get().ToList().Count;

            //assert
            Assert.IsTrue(afterCountMainTask > intialCountMainTask);
        }

        [TestMethod]
        public void UpdateShouldUpdateDatabaseEntity()
        {
            //Arrange
            IRepository<MainTask> mainTaskRepository = new MainTaskRepository();
            IRepository<User> userRepository = new UserRepository();
            //Act
            User user = userRepository.GetById(1);
            MainTask mainTask = new MainTask
            {
                Name = "study",
                Date = DateTime.Parse(DateTime.Now.Date.ToShortDateString()),
                StartTime = DateTime.Parse(DateTime.Now.ToShortTimeString()),
                EndTime = DateTime.Parse(DateTime.Today.ToShortTimeString()),
                Priority = PriorityType.LOW,
                User = user
            };
            mainTaskRepository.Update(mainTask, 1);
            var mainTaskByName = mainTaskRepository.GetByName("study");

            //Assert
            Assert.IsNotNull(mainTaskByName);
        }


        [TestMethod]
        public void GetMethodShouldReturnValue()
        {
            //arrange
            IRepository<MainTask> repository = new MainTaskRepository();

            //act
            var result = repository.Get();

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByIdShouldBeReturnValue()
        {
            //arrange
            IRepository<MainTask> repository = new MainTaskRepository();

            //act
            var result = repository.GetById(1);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByNameShouldBeReturnValue()
        {
            //arrange
            IRepository<MainTask> repository = new MainTaskRepository();

            //act
            var result = repository.GetByName("plyaing");

            //assert
            Assert.IsNotNull(result);
        }
    }
}
