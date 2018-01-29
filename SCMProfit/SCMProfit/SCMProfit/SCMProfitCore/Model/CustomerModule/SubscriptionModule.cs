using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.Model.CustomerModule
{
    public class SubscriptionModule
    {
        public virtual Guid Id { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<CustomerSubscriptionDetails> Subscriptions { get; set; }

        public SubscriptionModule()
        {
            Modules = new List<Module>();
            Subscriptions = new List<CustomerSubscriptionDetails>();
        }
    }
}
