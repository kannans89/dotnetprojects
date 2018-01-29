using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfit.Models
{
    public class PartnerViewModel
    {
        public List<Partner> Partners { get; set; }

        public PartnerViewModel()
        {
            Partners=new List<Partner>();
        }
    }
}