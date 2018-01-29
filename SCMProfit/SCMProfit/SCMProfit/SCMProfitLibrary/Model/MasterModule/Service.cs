using System;
using Microsoft.Build.Framework;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.Model.MasterModule
{
    public class Service
    {
        public virtual Guid ServiceId { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual bool IsSelected { get; set; }

        [Required]
        public virtual CustomerSubscriptionDetails Subscription { get; set; }

        public Service()
        {
        }

        public Service(Guid guid, string name)
            : this()
        {
            ServiceId = guid;
            ServiceName = name;

        }

        public static Service Create(Guid guid, string name)
        {
            return new Service(guid, name);
        }
    }
}
