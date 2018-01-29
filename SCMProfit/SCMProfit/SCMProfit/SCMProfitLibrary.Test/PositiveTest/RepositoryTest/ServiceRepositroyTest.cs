using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class ServiceRepositroyTest
    {
        private readonly IRepository<Service> _serviceRepository;

        public ServiceRepositroyTest()
        {
            _serviceRepository=new ServicesRepository();
        }

        [TestMethod]
        public void ShouldAddMethodAddMethod()
        {
            var intialCount = _serviceRepository.Get().ToList().Count;

            Service module = new Service
            {
               ServiceName = "No Support"
            };

            _serviceRepository.Add(module);

            var afterCount = _serviceRepository.Get().ToList().Count;

            Assert.IsTrue(intialCount < afterCount);
        }

        //[TestMethod]
        //public void Test1()
        //{
        //    var x = 6.2%10;

        //    Assert.IsNotNull(x);
        //}
    }
}
