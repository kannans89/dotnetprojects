using System;
using System.IO;
using System.Text;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfitCore.ControllerServices
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepo)
        {
            _customerRepository =customerRepo;
        }

        public bool Approve(Guid? customerid)
        {
            Customer customer = _customerRepository.GetById(customerid);
            customer.IsApproved = 1;
            _customerRepository.Update(customer);
            EmailService.EmailService.SendConfirmationMessageByEmail(customer, CreateEmailTemplateFromFile(customer));

            return true;
        }

        public void Reject(Guid? customerid)
        {
            Customer customer = _customerRepository.GetById(customerid);
            customer.IsApproved = 0;
            _customerRepository.Update(customer);
            string message = "Your Account has been blocked by admin of user= " + customer.FirstName + " " + customer.LastName;
            EmailService.EmailService.SendConfirmationMessageByEmail(customer, message);
        }

        public string CreateEmailTemplateFromFile(Customer customer)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"Templates/TemplateHTMLPage.cshtml", Encoding.UTF8))
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
