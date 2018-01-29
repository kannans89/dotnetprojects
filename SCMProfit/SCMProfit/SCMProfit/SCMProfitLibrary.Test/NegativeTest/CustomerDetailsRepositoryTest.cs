using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.NegativeTest
{
    [TestClass]
    public class CustomerDetailsRepositoryTest
    {
        private readonly IRepository<Customer> _customeRepository;

        public CustomerDetailsRepositoryTest()
        {
            _customeRepository=new CustomerDetailsRepository();
        }

        [TestMethod]
        public void PassingNullCustomerShortNameToAddMethod()
        {
            //arrange
            Exception expectedException = null;
            IRepository<Customer> userRepository =new CustomerDetailsRepository();

            //act
            Customer customer = new Customer
            {
                CompanyName = "akhilesh",
                PrimaryContact = 8291404841,
                Currency = CurrencyType.EUR,
                Email = "akhi8291@gmail.com"
            };
            try
            {
                userRepository.Add(customer);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }

            //assert
            Assert.IsNotNull(expectedException);
        }
    }
}
