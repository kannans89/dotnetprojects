using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfit.Models
{
    public class LoginViewModel
    {
        public List<CustomerLoginDetails> Customers { get; set; }
        public Customer Customer { get; set; }
        public CustomerLoginDetails CustomerLoginDetails { get; set; }
        public CustomerSubscriptionDetails CustomerSubscriptionDetails { get; set; }

        public LoginViewModel()
        {
            CustomerSubscriptionDetails=new CustomerSubscriptionDetails();
            CustomerLoginDetails=new CustomerLoginDetails();
            Customers=new List<CustomerLoginDetails>();
        }
    }
}