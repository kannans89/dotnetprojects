using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SCMProfitCore.Model.MasterModule;
using SCMProfitCore.ResourcesFiles;

namespace SCMProfitCore.Model.CustomerModule
{
    public class CustomerSubscriptionDetails
    {
        public virtual Guid SubscriptionId { get; set; }
        public virtual CustomerSubscriptionType Subscription { get; set; }
        public virtual int NumberOfNamedUsers { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Service> Services { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        public CustomerSubscriptionDetails()
        {
            Modules = new List<Module>();
            Services = new List<Service>();
        }

        public CustomerSubscriptionDetails(Guid id, CustomerSubscriptionType subscription,int numberOfUsers)
            : this()
        {
            SubscriptionId = id;
            Subscription = subscription;
            NumberOfNamedUsers = numberOfUsers;
        }

        public static CustomerSubscriptionDetails Create(Guid id, CustomerSubscriptionType subscription, int numberOfUsers)
        {
            return new CustomerSubscriptionDetails(id, subscription, numberOfUsers);
        }
    }
}
