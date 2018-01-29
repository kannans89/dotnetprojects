using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.MappingClass
{
    public class CustomerAddressMap : ClassMap<CustomerAddress>
    {
        public CustomerAddressMap()
        {
            Id(m => m.AddressId);
            Map(m => m.AddressLine1);
            Map(m => m.AddressLine2);
            Map(m => m.City);
            Map(m => m.State);
            Map(m => m.ZipCode);
            Map(m => m.Country);

        }
    }
}
