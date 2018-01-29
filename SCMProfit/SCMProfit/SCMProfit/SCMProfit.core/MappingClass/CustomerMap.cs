using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.MappingClass
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(m => m.CustomerId);
            Map(m => m.CompanyName);
            Map(m => m.FirstName);
            Map(m => m.LastName);
         
            Map(m => m.PrimaryContact);
            Map(m => m.Currency);
            Map(m => m.ShortName).Not.Nullable();
            Map(m => m.Email);
            Map(m => m.Role);
            Map(m => m.WebsiteUrl);
            Map(m => m.IsApproved);
            HasManyToMany<CustomerSubscriptionDetails>(m => m.Subscriptions).Cascade.All();
                //.Table("CustomerSubscription")
                //.ParentKeyColumn("CustomerID")
                //.ChildKeyColumn("SubscriptionID")
                //.AsSet()
                //.Not.LazyLoad();


            //HasOne(m => m.CustomerAddress).ForeignKey("Address_Id");
            //HasOne(m => m.LoginDetails).ForeignKey("Login_Id");
            //HasOne(m => m.Partner).ForeignKey("Partner_Id");

            References(m => m.CustomerAddress);
            References(m => m.LoginDetails);
            References(m => m.Partner);
        }
    }
}
