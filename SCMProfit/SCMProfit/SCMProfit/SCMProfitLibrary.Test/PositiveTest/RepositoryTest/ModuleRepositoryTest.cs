using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Test.PositiveTest.RepositoryTest
{
    [TestClass]
    public class ModuleRepositoryTest
    {
        private readonly IRepository<Module> _moduleRepository;

        public ModuleRepositoryTest()
        {
            _moduleRepository=new ModuleRepository();
        }

        [TestMethod]
        public void ShouldAddMethodAddData()
        {
            var intialCount = _moduleRepository.Get().ToList().Count;

            Module module = new Module
            {
                ModuleName = "Air frieght"
            };

            _moduleRepository.Add(module);

            var afterCount = _moduleRepository.Get().ToList().Count;

            Assert.IsTrue(intialCount < afterCount);
        }
    }
}
