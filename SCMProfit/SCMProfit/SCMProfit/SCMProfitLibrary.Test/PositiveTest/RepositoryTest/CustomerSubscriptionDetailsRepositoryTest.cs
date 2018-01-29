using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class CustomerSubscriptionDetailsRepositoryTest
    {
        //Arrange
        private readonly IRepository<CustomerSubscriptionDetails> _repository;
        private readonly IRepository<Customer> _customerRepository; 

        public CustomerSubscriptionDetailsRepositoryTest()
        {
            _repository = new CustomerSubscriptionDetailsRepository();
            _customerRepository=new CustomerDetailsRepository();
        }

        [TestMethod]
        public void AddShouldAddCustomerSubscriptionDetailsIntoDatabase()
        {

            //Act
            Customer customer = _customerRepository.GetById(new Guid("799E18DC-71B1-4E55-B45D-A70300D64A68"));
            var intialCount = _repository.Get().ToList().Count;

            CustomerSubscriptionDetails customerSubscriptionDetails = new CustomerSubscriptionDetails
            {
                Subscription = CustomerSubscriptionType.Saas,
                NumberOfNamedUsers = 15,
                Customer = customer
            };

            _repository.Add(customerSubscriptionDetails);
            var afterCount = _repository.Get().ToList().Count;

            //Assert
            Assert.IsTrue(intialCount < afterCount);

        }

        [TestMethod]
        public void GetByNameShouldReturnValue()
        {
            var returnValue = _repository.GetByName(CustomerSubscriptionType.OnPremise.ToString());

            Assert.IsNotNull(returnValue);
        }

        [TestMethod]
        public void UpdateShouldUpdateCustomerSubscriptionDetailsIntoDatabase()
        {
            //Act
            var customerrSubscription = _repository.GetById(new Guid("CAD8F319-6D25-426A-BFB0-A70300DDDEA0"));

            CustomerSubscriptionDetails customerLoginDetails = new CustomerSubscriptionDetails
            {
               SubscriptionId =customerrSubscription.SubscriptionId,
               Subscription = CustomerSubscriptionType.OnPremise,
               NumberOfNamedUsers = 15,
            };

            _repository.Update(customerLoginDetails);
            var customerLogin = _repository.GetByName(CustomerSubscriptionType.OnPremise.ToString());
            //Assert
            Assert.IsNotNull(customerLogin);
        }

        [TestMethod]
        public void DeleteShouldDeleteValue()
        {
            var customerSubscription = _repository.GetById(new Guid("8F86C009-C608-47E3-974E-A70300DD49E7"));

            _repository.Delete(customerSubscription.SubscriptionId);

            var expectedValue = _repository.GetById(new Guid("8F86C009-C608-47E3-974E-A70300DD49E7"));

            Assert.IsNull(expectedValue);
        }
    }
}
