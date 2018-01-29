using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.MappingClass
{
    public class CustomerSubscriptionMap : ClassMap<CustomerSubscriptionDetails>
    {
        public CustomerSubscriptionMap()
        {
            Id(m => m.SubscriptionId);
            Map(m => m.Subscription);
            Map(m => m.NumberOfNamedUsers);
            HasManyToMany<Module>(m => m.Modules).Cascade.All();
               //.Table("SubscriptionModule")
               //.ParentKeyColumn("SubscriptionID")
               //.ChildKeyColumn("ModuleId")
               //.AsSet()
               //.Not.LazyLoad();
            HasManyToMany<Service>(m => m.Services).Cascade.All();
               //.Table("SubscriptionService")
               //.ParentKeyColumn("SubscriptionID")
               //.ChildKeyColumn("ServiceId")
               //.AsSet()
               //.Not.LazyLoad();
            //References(m => m.Customer);
        }
    }
}
