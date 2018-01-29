using System;
using Microsoft.Build.Framework;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.Model.MasterModule
{
    public class Module
    {
        public virtual Guid ModuleId { get; set; }
        public virtual string ModuleName { get; set; }
        public virtual bool IsSelected { get; set; }

        [Required]
        public virtual CustomerSubscriptionDetails Subscription { get; set; }

        public Module()
        {
        }

        public Module(Guid guid, string name)
            : this()
        {
            ModuleId = guid;
            ModuleName = name;

        }

        public static Module Create(Guid guid, string name)
        {
            return new Module(guid, name);
        }

       
    }
}
