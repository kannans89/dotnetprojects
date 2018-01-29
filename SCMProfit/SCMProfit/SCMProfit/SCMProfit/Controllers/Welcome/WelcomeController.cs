using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCMProfit.Models;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.SCMProfitRepository;

namespace SCMProfit.Controllers.Welcome
{
    public class WelcomeController : Controller
    {
        private readonly IRepository<Partner> _partneRepository;
        private readonly PartnerViewModel _partnerViewModel;
        public WelcomeController(IRepository<Partner> partneRepo, PartnerViewModel partnerViewModel)
        {
            _partneRepository = partneRepo;
            _partnerViewModel = partnerViewModel;
        }

        public ActionResult Welcome()
        {
            _partnerViewModel.Partners = _partneRepository.Get().ToList();
            return PartialView(_partnerViewModel);
        }

    }
}
