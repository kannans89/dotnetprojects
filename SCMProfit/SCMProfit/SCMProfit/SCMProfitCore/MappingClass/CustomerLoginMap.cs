using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.MappingClass
{
    public class CustomerLoginMap : ClassMap<CustomerLoginDetails>
    {
        public CustomerLoginMap()
        {
            Id(m => m.LoginId);
            Map(m => m.UserName);
            Map(m => m.Password);

            //References(m => m.Customer);
        }
    }
}
