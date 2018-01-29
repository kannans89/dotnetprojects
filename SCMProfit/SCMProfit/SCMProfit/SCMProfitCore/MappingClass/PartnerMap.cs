using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.MappingClass
{
    public class PartnerMap : ClassMap<Partner>
    {
        public PartnerMap()
        {
            Id(m => m.PartnerId);
            Map(m => m.PartnerName);
        }
    }
}
