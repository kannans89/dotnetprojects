using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfit.Controllers.Customer;
using SCMProfit.Controllers.Login;
using SCMProfit.Models;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.ControllerTest
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void CustomerShouldBeRegisteredAndRedirectToSignIn()
        {
            //arrange
            NewRegistrationViewModel viewModel = new NewRegistrationViewModel();
            IRepository<Customer> _customerRepository = new CustomerDetailsRepository();
            IRepository<CustomerLoginDetails> _customerLoginDetailsRepository = new CustomerLoginDetailsRepository();
            IRepository<CustomerSubscriptionDetails> _customerSubscriptionRepository = new CustomerSubscriptionDetailsRepository();
            IRepository<Partner> _partnerRepository = new PartnerRepository();
            IRepository<Module> _moduleRepository = new ModuleRepository();
            IRepository<Service> _serviceRepository = new ServicesRepository();
            Module _module = new Module();
            Service _service = new Service();
            CustomerController customerController = new CustomerController(_customerRepository, _customerLoginDetailsRepository, _customerSubscriptionRepository, _partnerRepository, _moduleRepository, _serviceRepository);

            //act
            Partner partner = new Partner
            {
                PartnerName = "TechLabs"
            };

            CustomerLoginDetails loginDetails = new CustomerLoginDetails
            {
                UserName = "raju",
                Password = "raju"
            };


            viewModel.Modules.Add("Warehouse"); 

            foreach (var list in viewModel.Modules[0].Split(','))
            {
                _module = new Module
                {
                    ModuleName = list
                };
            }

            viewModel.Services.Add("Online Support");

            foreach (var list in viewModel.ServiceList)
            {
                _service = new Service
                {
                    ServiceName = list.ServiceName
                };
            }

            CustomerSubscriptionDetails subscriptionDetails = new CustomerSubscriptionDetails
            {
                NumberOfNamedUsers = 15,
                Subscription = CustomerSubscriptionType.OnPremise,
                //Modules = viewModel.Modules[0],
                //Services = viewModel.Services[0]
            };

            Customer customer = new Customer
            {
                CompanyName = "Raju Company",
                FirstName = "Raju",
                LastName = "Vishwakarma",
                PrimaryContact =7788256485,
                Currency = CurrencyType.EUR,
                ShortName = "BPO",
                Email = "rajuv0703@gmail.com",
                WebsiteUrl = "https://mail.google.com",
                Role = "user"
            };

            customer.Partner = partner;
            customer.LoginDetails = loginDetails;

            subscriptionDetails.Customer = customer;
            _module.Subscription = subscriptionDetails;
            _service.Subscription = subscriptionDetails;

            var result = customerController.NewRegistration(viewModel) as RedirectToRouteResult;

            //assert
            if (result != null)
            {
                Assert.AreEqual("SignIn", result.RouteValues["action"]);
                Assert.IsNotNull(result);
            }
        }
    }
}
