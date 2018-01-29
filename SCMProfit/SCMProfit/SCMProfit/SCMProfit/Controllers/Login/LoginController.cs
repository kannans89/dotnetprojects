using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SCMProfit.LanguageClasses;
using SCMProfit.Models;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.ResourcesFiles;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Controllers.Login
{
    public class LoginController : BaseController
    {
        private readonly IRepository<CustomerLoginDetails> _customerLoginRepository;
        private readonly IRepository<SCMProfitCore.Model.CustomerModule.Customer> _customerRepository;
        private readonly LoginViewModel _loginViewModel;
        private readonly IRepository<CustomerSubscriptionDetails> _customerSubscriptionRepository;

        public LoginController(IRepository<CustomerLoginDetails> customerLoginRepo, IRepository<SCMProfitCore.Model.CustomerModule.Customer> customerRepo, IRepository<CustomerSubscriptionDetails> customerSubscriptionRepo, LoginViewModel loginViewModel)
        {
            _customerLoginRepository = customerLoginRepo;
            _customerRepository = customerRepo;
            _customerSubscriptionRepository = customerSubscriptionRepo;
            _loginViewModel =loginViewModel;
        }

        public ActionResult SignIn()
        {
            return View(_loginViewModel);
        }

        [HttpPost]
        public ActionResult SignIn(LoginViewModel loginViewModel)
        {

            CustomerLoginDetails customerLoginDetails = _customerLoginRepository.IsValidCustomer(loginViewModel.CustomerLoginDetails.UserName, loginViewModel.CustomerLoginDetails.Password);
            if (customerLoginDetails != null)
            {
                Session["customerLoginId"] = customerLoginDetails.LoginId;
                var customer =(_customerRepository.Search(x => x.LoginDetails.LoginId == customerLoginDetails.LoginId))
                                                                                                    .SingleOrDefault();

                Session["customerId"] = customer.CustomerId;
                FormsAuthentication.SetAuthCookie(customer.Email, true);
                if (CheckUser(customer))
                {
                    if (customer.IsApproved == 1)
                    {
                        CreateCookie(_loginViewModel.CustomerLoginDetails.RememberMe,
                            _loginViewModel.CustomerLoginDetails.LoginId);
                        TempData["message"] = Resource.LoginSuccessfully;
                        return RedirectToAction("TenantProfile", "Customer");
                    }
                    else
                    {
                        TempData["message"] = Resource.ApprovedMessage;
                        return View(_loginViewModel);
                    }
                }
                else
                {
                    CreateCookie(_loginViewModel.CustomerLoginDetails.RememberMe,
                            _loginViewModel.CustomerLoginDetails.LoginId);
                    return RedirectToAction("NewRequest", "Admin");
                }

            }
            TempData["message"] = Resource.LoginUnsuccessfull;
            return View();
        }

        public bool CheckUser(SCMProfitCore.Model.CustomerModule.Customer customer)
        {
            if (customer.Role == "user")
            {
                TempData["message"] = Resource.LoginSuccessfully;
                return true;
            }
            else
                return false;
        }

        public void CreateCookie(bool rememberMe, Guid loginId)
        {
            if (rememberMe)
            {
                HttpCookie cultureCookie = new HttpCookie("loginCookie");
                cultureCookie.Expires = DateTime.Now.AddDays(7);
                cultureCookie.Value = loginId.ToString();
                Response.Cookies.Add(cultureCookie);
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            if (Request.Cookies["loginCookie"] != null)
            {
                var loginCookie = new HttpCookie("loginCookie");
                loginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(loginCookie);
            }
            TempData["message"] = "Logout successfully";
            return RedirectToAction("SignIn", "Login");
        }

        public ActionResult ChangeLanguage(string lang)
        {
            SiteLanguage.SetLanguage(lang);
            return RedirectToAction("SignIn", "Login");
        }

    }
}
