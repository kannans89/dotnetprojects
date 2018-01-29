using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NHibernate.Type;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService()
        {
            _customerRepository =new CustomerDetailsRepository();
        }

        public void CustomerApprovedService(Guid? customerid)
        {
            Customer customer = _customerRepository.GetById(customerid);
            customer.IsApproved = 1;
            _customerRepository.Update(customer);
            EmailService.EmailService.SendConfirmationMessageByEmail(customer, CreateBody(customer));
        }

        public void CustomerRejectService(Guid? customerid)
        {
            Customer customer = _customerRepository.GetById(customerid);
            customer.IsApproved = 0;
            _customerRepository.Update(customer);
            string message = "Your Account has been blocked by admin of user= " + customer.FirstName + " " + customer.LastName;
            EmailService.EmailService.SendConfirmationMessageByEmail(customer, message);
        }

        public string CreateBody(Customer customer)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"D:/AKHILESH/SWABHAV/Techlabs/SCMProfit/SCMProfit/Views/Customer/TemplateHTMLPage.cshtml", Encoding.UTF8))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{fn}", customer.FirstName);
            body = body.Replace("{ln}", customer.LastName);
            body = body.Replace("{un}", customer.LoginDetails.UserName);
            body = body.Replace("{up}", customer.LoginDetails.Password);
            return body;

        }

    }
}
