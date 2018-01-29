using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class CustomerLoginDetailsRepositoryTest
    {
        //Arrange
        private readonly IRepository<CustomerLoginDetails> _repository;

        public CustomerLoginDetailsRepositoryTest()
        {
            _repository = new CustomerLoginDetailsRepository();
        }

        [TestMethod]
        public void AddShouldAddCustomerLoginDetailsIntoDatabase()
        {

            //Act
            var intialCount = _repository.Get().ToList().Count;

            CustomerLoginDetails customerLoginDetails = new CustomerLoginDetails
            {
                UserName = "AkhileshV",
                Password = "akhi"
            };

            _repository.Add(customerLoginDetails);
            var afterCount = _repository.Get().ToList().Count;

            //Assert
            Assert.IsTrue(intialCount < afterCount);

        }

        [TestMethod]
        public void UpdateShouldUpdateCustomerLoginDetailsIntoDatabase()
        {
            //Act
            var customerrLogin = _repository.GetById(new Guid("B182DCDC-2F6C-4726-9A2F-A70300D5FEFC"));

            CustomerLoginDetails customerLoginDetails = new CustomerLoginDetails
            {
                LoginId = customerrLogin.LoginId,
                UserName = "raju",
                Password = "raju123"

            };

            _repository.Update(customerLoginDetails);
            var customerLogin = _repository.GetByName("raju");
            //Assert
            Assert.IsNotNull(customerLogin);
        }

        [TestMethod]
        public void DeleteShouldDeleteValue()
        {
            var customerLogin = _repository.GetByName("raju");

            _repository.Delete(customerLogin.LoginId);

            var expectedValue = _repository.GetByName("raju");

            Assert.IsNull(expectedValue);
        }

    }
}
