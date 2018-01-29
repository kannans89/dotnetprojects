using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMProfitCore.SCMProfitRepository;
using SCMProfit.Models;
using SCMProfitCore.ControllerServices;
using SCMProfitCore.EmailService;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfit.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IRepository<SCMProfitCore.Model.CustomerModule.Customer> _customerRepository;
        private readonly NewRegistrationViewModel _newRegistrasionViewModel;
        private readonly IRepository<CustomerLoginDetails> _customerLoginDetailsRepository;
        private readonly IRepository<CustomerSubscriptionDetails> _customerSubscriptionRepository;
        private readonly CustomerService _customerService;

        public AdminController(IRepository<SCMProfitCore.Model.CustomerModule.Customer> customerRepo, IRepository<CustomerLoginDetails> customerLoginDetailsRepo, IRepository<CustomerSubscriptionDetails> customerSubscriptionRepo, NewRegistrationViewModel newRegistrasionViewModel)
        {
            _customerRepository = customerRepo;
            _customerLoginDetailsRepository = customerLoginDetailsRepo;
            _customerSubscriptionRepository = customerSubscriptionRepo;
            _newRegistrasionViewModel = newRegistrasionViewModel;
            _customerService = new CustomerService(customerRepo);
        }

        [Authorize(Roles = "admin")]
        public ActionResult NewRequest()
        {
            if (Session["customerLoginId"] != null)
            {
                Guid customerId = Guid.Parse(Session["customerId"].ToString());

                _newRegistrasionViewModel.Customer = _customerRepository.GetById(customerId);

                var customerList = _customerRepository.Get().Where(m => m.Role == "user").ToList();

                _newRegistrasionViewModel.CustomerList = customerList;
                return View(_newRegistrasionViewModel);
            }
            return RedirectToAction("SignIn", "Login");
        }

        public ActionResult TenantManagement()
        {
            return View();
        }

        public ActionResult IdAdmin()
        {
            return View();
        }

        public ActionResult Announcements()
        {
            return View();
        }

        public ActionResult CustomerApproved(Guid? customerid)
        {
            //TODO:change buss
            _customerService.Approve(customerid);
            return RedirectToAction("NewRequest");
        }

        public ActionResult CustomerReject(Guid? customerid)
        {
            _customerService.Reject(customerid);
            TempData["message"] = "User Blocked";
            return RedirectToAction("NewRequest");
        }

        public ActionResult CustomerAlreadyApproved(Guid customerid)
        {
            TempData["message"] = "User Already approved !!!";
            return RedirectToAction("NewRequest");
        }

        public ActionResult CustomerAlreadyReject(Guid customerid)
        {
            TempData["message"] = "User Already rejected !!!";
            return RedirectToAction("NewRequest");
        }

        public ActionResult SearchCustomer(string searchBy, string searchdata)
        {
            if (searchBy == "Partner")
            {

            }
            if (searchBy == "Customer")
            {
            }
            if (searchBy == "Service Type")
            {
            }
            if (searchBy == "Module")
            {
            }
            if (searchBy == "Service")
            {
            }
            if (searchBy == "Enabled")
            {
            }
            if (searchBy == "Disabled")
            {
            }
            //{
            //    int id = Convert.ToInt32(search);
            //    cvm.Contacts = _contactRepository.Search((x => x.Id == id)).ToList();
            //    ViewBag.search = "id";

            //}
            //else
            //{
            //    cvm.Contacts = _contactRepository.Search((x => x.FirstName == search)).ToList();
            //    ViewBag.search = "name";

            //}
            //// return Content("hie");
            //return Json(cvm.Contacts, JsonRequestBehavior.AllowGet);
            return Json(_newRegistrasionViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
