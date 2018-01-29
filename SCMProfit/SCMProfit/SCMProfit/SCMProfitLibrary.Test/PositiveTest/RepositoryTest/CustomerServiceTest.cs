using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.ControllerServices;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class CustomerServiceTest
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly CustomerService _customerService; 

        public CustomerServiceTest()
        {
            _customerService=new CustomerService();
            _customerRepository = new CustomerDetailsRepository();
        }

        [TestMethod]
        public void ShouldCreateEmailTemplateFromFileCreateBody()
        {
            Customer customer = _customerRepository.GetById(new Guid("52FC0894-776D-49F7-A29C-A70A00FEB7D7"));

            var file=_customerService.CreateEmailTemplateFromFile(customer);

            Assert.IsNotNull(file);
        }


        [TestMethod]
        public void ShouldApproveMethodSendGmail()
        {
            Customer customer = _customerRepository.GetById(new Guid("52FC0894-776D-49F7-A29C-A70A00FEB7D7"));

            var isSendGmail=_customerService.Approve(customer.CustomerId);

            Assert.IsTrue(isSendGmail);
        }
    }
}
