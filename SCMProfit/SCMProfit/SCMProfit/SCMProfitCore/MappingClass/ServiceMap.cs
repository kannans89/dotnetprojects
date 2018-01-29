using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.MappingClass
{
    public class ServiceMap : ClassMap<Service>
    {
        public ServiceMap()
        {
            Id(m => m.ServiceId);
            Map(m => m.ServiceName);
        }
    }
}
