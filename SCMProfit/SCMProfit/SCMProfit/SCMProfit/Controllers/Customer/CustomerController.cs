using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using SCMProfit.LanguageClasses;
using SCMProfit.Models;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Controllers.Customer
{
    public class CustomerController : BaseController
    {
        private readonly NewRegistrationViewModel _newRegistrasionViewModel;
        private readonly IRepository<SCMProfitCore.Model.CustomerModule.Customer> _customerRepository;
        private readonly IRepository<CustomerLoginDetails> _customerLoginDetailsRepository;
        private readonly IRepository<CustomerSubscriptionDetails> _customerSubscriptionRepository;
        private readonly IRepository<Partner> _partnerRepository;
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<Service> _serviceRepository;
        private readonly List<Module> _listOfModules;
        private readonly List<Service> _listOfServices;
        private readonly List<CustomerSubscriptionDetails> _listOfSubscription;

        public CustomerController(IRepository<SCMProfitCore.Model.CustomerModule.Customer> _custRepository, IRepository<CustomerLoginDetails> _loginRepository, IRepository<CustomerSubscriptionDetails> _subscriptionRepository, IRepository<Partner> _partnerRepo, IRepository<Module> _moduleRepo, IRepository<Service> _serviceRepo)
        {
            _newRegistrasionViewModel = new NewRegistrationViewModel();
            _customerRepository = _custRepository;
            _customerLoginDetailsRepository = _loginRepository;
            _customerSubscriptionRepository = _subscriptionRepository;
            _moduleRepository = _moduleRepo;
            _serviceRepository = _serviceRepo;
            _partnerRepository = _partnerRepo;
            _listOfModules = new List<Module>();
            _listOfServices = new List<Service>();
            _listOfSubscription = new List<CustomerSubscriptionDetails>();
        }

        public ActionResult NewRegistration(Guid? partnerId)
        {
            Session["partnerId"] = partnerId;
            List<Module> modules = _moduleRepository.Get().ToList();
            List<Service> services = _serviceRepository.Get().ToList();
            _newRegistrasionViewModel.ModuleList = modules;
            _newRegistrasionViewModel.ServiceList = services;
            return View(_newRegistrasionViewModel);
        }

        [HttpPost]
        public ActionResult NewRegistration(NewRegistrationViewModel viewModel)
        {
            if (viewModel != null && this.IsCaptchaValid("Captcha is not valid"))
            {
                Partner partner = _partnerRepository.GetById(new Guid(Session["partnerId"].ToString()));
                CustomerLoginDetails loginDetails = new CustomerLoginDetails
                {
                    UserName = viewModel.Customer.LoginDetails.UserName,
                    Password = viewModel.Customer.LoginDetails.Password
                };

                CustomerAddress address = new CustomerAddress
                {
                    AddressLine1 = viewModel.Customer.CustomerAddress.AddressLine1,
                    AddressLine2 = viewModel.Customer.CustomerAddress.AddressLine2,
                    City = viewModel.Customer.CustomerAddress.City,
                    State = viewModel.Customer.CustomerAddress.State,
                    ZipCode = viewModel.Customer.CustomerAddress.ZipCode,
                    Country = viewModel.Customer.CustomerAddress.Country
                };

                foreach (var moduleList in viewModel.ModuleList)
                {
                    if (moduleList.IsSelected)
                    {
                        _listOfModules.Add(_moduleRepository.GetByName(moduleList.ModuleName));
                    }
                }

                foreach (var serviceList in viewModel.ServiceList)
                {
                    if (serviceList.IsSelected)
                    {
                        _listOfServices.Add(_serviceRepository.GetByName(serviceList.ServiceName));
                    }
                }

                CustomerSubscriptionDetails subscriptionDetails = new CustomerSubscriptionDetails
                {
                    NumberOfNamedUsers = viewModel.CustomerSubscriptionDetail.NumberOfNamedUsers,
                    Subscription = viewModel.CustomerSubscriptionDetail.Subscription,
                    Modules = _listOfModules,
                    Services = _listOfServices
                };

                _listOfSubscription.Add(subscriptionDetails);

                var customerDetails = new SCMProfitCore.Model.CustomerModule.Customer
                {
                    CompanyName = viewModel.Customer.CompanyName,
                    FirstName = viewModel.Customer.FirstName,
                    LastName = viewModel.Customer.LastName,
                    PrimaryContact = viewModel.Customer.PrimaryContact,
                    Currency = viewModel.Customer.Currency,
                    ShortName = viewModel.Customer.ShortName,
                    Email = viewModel.Customer.Email,
                    WebsiteUrl = viewModel.Customer.WebsiteUrl,
                    Role = viewModel.Customer.Role,
                    Partner = partner,
                    LoginDetails = loginDetails,
                    CustomerAddress = address,
                    Subscriptions = _listOfSubscription
                };

                _customerRepository.Add(customerDetails);

                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult TenantProfile()
        {
            if (Session["customerLoginId"] != null)
            {
                Guid customerId = Guid.Parse(Session["customerId"].ToString());
                _newRegistrasionViewModel.Customer = _customerRepository.GetById(customerId);
                return View(_newRegistrasionViewModel);
            }
            return RedirectToAction("SignIn", "Login");
        }

        [Authorize(Roles = "user")]
        public ActionResult WelcomeKit()
        {
            if (Session["customerLoginId"] != null)
            {
                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }

        [Authorize(Roles = "user")]
        public ActionResult Announcement()
        {
            if (Session["customerLoginId"] != null)
            {
                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }

        public ActionResult ChangeLanguage(string lang)
        {
            SiteLanguage.SetLanguage(lang);
            return RedirectToAction("NewRegistration");
        }
    }
}
