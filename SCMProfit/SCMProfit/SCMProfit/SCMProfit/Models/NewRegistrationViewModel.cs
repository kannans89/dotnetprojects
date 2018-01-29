using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfit.Models
{
    public class NewRegistrationViewModel
    {
        public Customer Customer { set; get; }
        public Module Module { get; set; }
        public Service Service { get; set; }
        public List<Customer> CustomerList { get; set; }
        public CustomerLoginDetails CustomerLoginDetail { get; set; }
        public CustomerSubscriptionDetails CustomerSubscriptionDetail { get; set; }
        public List<CustomerSubscriptionDetails> SubscriptionList { get; set; }
        public List<Module> ModuleList { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<String> Modules { get; set; }
        public List<String> Services { get; set; }

        public NewRegistrationViewModel()
        {
            Modules = new List<string>();
            Services = new List<string>();
            Module = new Module();
            Service = new Service();
            Customer = new Customer();
            CustomerLoginDetail = new CustomerLoginDetails();
            CustomerSubscriptionDetail = new CustomerSubscriptionDetails();
            CustomerList = new List<Customer>();
            ModuleList = new List<Module>();
            ServiceList = new List<Service>();
        }
    }
}