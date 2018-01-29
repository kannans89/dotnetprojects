using FluentNHibernate.Mapping;
using SCMProfitCore.Model.CustomerModule;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.MappingClass
{
    public class ModuleMap : ClassMap<Module>
    {
        public ModuleMap()
        {
            Id(m => m.ModuleId);
            Map(m => m.ModuleName);
        }
    }
}
