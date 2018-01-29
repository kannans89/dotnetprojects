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
    public class PartnerRepositoryTest
    {
        private readonly IRepository<Partner> _partnerRepository;

        public PartnerRepositoryTest()
        {
            _partnerRepository = new PartnerRepository();
        }

        [TestMethod]
        public void ShouldAddMethodAddData()
        {
            var intialCount = _partnerRepository.Get().ToList().Count;

            Partner partner = new Partner
            {
                PartnerName = "Aurionpro"
            };

            _partnerRepository.Add(partner);

            var afterCount = _partnerRepository.Get().ToList().Count;
           
            Assert.IsTrue(intialCount < afterCount);
        }
    }
}
