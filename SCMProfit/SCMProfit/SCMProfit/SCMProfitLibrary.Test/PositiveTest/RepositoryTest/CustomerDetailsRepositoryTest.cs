using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class CustomerDetailsRepositoryTest
    {
        //Arrange
        private readonly IRepository<Customer> _repository;
        private readonly List<Module> _listOfModules;
        private readonly List<Service> _listOfServices;
        private readonly IRepository<CustomerLoginDetails> _logInRepository;
        private readonly IRepository<CustomerSubscriptionDetails> _subscriptionRepository;
        private readonly IRepository<Partner> _partnerRepository;
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly List<CustomerSubscriptionDetails> _listOfSubscription;

        public CustomerDetailsRepositoryTest()
        {
            _repository = new CustomerDetailsRepository();
            _listOfModules = new List<Module>();
            _listOfServices = new List<Service>();
            _logInRepository = new CustomerLoginDetailsRepository();
            _subscriptionRepository = new CustomerSubscriptionDetailsRepository();
            _partnerRepository = new PartnerRepository();
            _moduleRepository = new ModuleRepository();
            _serviceRepository = new ServicesRepository();
            _listOfSubscription = new List<CustomerSubscriptionDetails>();
        }
        [TestMethod]
        public void AddShouldAddCustomerCompanyDetailsIntoDatabase()
        {
            //Act
            var intialCount = _repository.Get().ToList().Count;

            Partner partner = _partnerRepository.GetById(new Guid("BDBBD5EF-62E7-40B0-8A28-A70A00FDDBE1"));
            Module module = _moduleRepository.GetById(new Guid("117522B3-EBC1-4A9A-AA8E-A70A00FE001B"));
            Service service = _serviceRepository.GetById(new Guid("4DD8E082-5071-499C-8914-A70A00FE1C57"));

            CustomerLoginDetails loginDetails = new CustomerLoginDetails
            {
                UserName = "akhi",
                Password = "akhi"
            };
            CustomerAddress address = new CustomerAddress
            {
                AddressLine1 = "Mulund",
                AddressLine2 = "B.R.Road",
                City = "Mumbai",
                State = "Maharashtra",
                ZipCode = "400080",
                Country = "India"
            };

            _listOfModules.Add(module);
            _listOfServices.Add(service);
            CustomerSubscriptionDetails subscriptionDetails = new CustomerSubscriptionDetails
            {
                NumberOfNamedUsers = 18,
                Subscription = CustomerSubscriptionType.Saas,
                Modules = _listOfModules,
                Services = _listOfServices
            };

            _listOfSubscription.Add(subscriptionDetails);
            Customer customerDetails = new Customer
            {
                CompanyName = "xyz",
                FirstName = "Akhilesh",
                LastName = "Vishwakarma",
                PrimaryContact = 8291404841,
                Currency = CurrencyType.INR,
                ShortName = "XPO",
                Email = "akhi8291@gmal.com",
                WebsiteUrl = "https://app.vsaex.visualstudio.com",
                Role = "user",
                Partner = partner,
                LoginDetails = loginDetails,
                CustomerAddress = address,
                Subscriptions = _listOfSubscription
            };

            _repository.Add(customerDetails);

            var afterCount = _repository.Get().ToList().Count;

            //Assert
            Assert.IsTrue(intialCount < afterCount);

        }

        [TestMethod]
        public void UpdateShouldUpdateCustomerDetailsIntoDatabase()
        {
            //Act
            var customerr = _repository.GetById(new Guid("7F7921EB-5265-468D-9812-A70300D5FEFE"));

            Customer customerCompanyDetails = new Customer
            {
                CustomerId = customerr.CustomerId,
                CompanyName = "akhilesh",
                PrimaryContact = 8291404841,
                Currency = CurrencyType.INR,
                ShortName = "XPO",
                Email = "akhi8291@gmail.com"
            };

            _repository.Update(customerCompanyDetails);
            var customer = _repository.GetByName("XPO");
            //Assert
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void GetByIdShouldReturnValue()
        {
            var returnValue = _repository.GetById(new Guid("7F7921EB-5265-468D-9812-A70300D5FEFE"));

            Assert.IsNotNull(returnValue);
        }

        [TestMethod]
        public void GetByNameShouldReturnValue()
        {
            var returnValue = _repository.GetByName("XPO");

            Assert.IsNotNull(returnValue);
        }


        [TestMethod]
        public void DeleteShouldDeleteValue()
        {
            var customer = _repository.GetById(new Guid("799E18DC-71B1-4E55-B45D-A70300D64A68"));

            _repository.Delete(customer.CustomerId);

            var expectedValue = _repository.GetById(new Guid("799E18DC-71B1-4E55-B45D-A70300D64A68"));

            Assert.IsNull(expectedValue);
        }

    }
}
