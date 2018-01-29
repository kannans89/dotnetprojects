using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.Model.CustomerModule
{
    public class SubscriptionService
    {
        public virtual Guid Id { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<CustomerSubscriptionDetails> Subscriptions { get; set; }

        public SubscriptionService()
        {
            Services = new List<Service>();
            Subscriptions = new List<CustomerSubscriptionDetails>();
        }

    }
}
