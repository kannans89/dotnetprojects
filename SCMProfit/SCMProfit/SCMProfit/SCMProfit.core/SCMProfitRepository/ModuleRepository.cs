using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class ModuleRepository : NHibernateHelper, IRepository<Module>
    {
        public ModuleRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModuleMap>());
            OpenSession(cfg);
        }

        public IQueryable<Module> Get()
        {
            return _session.CreateCriteria<Module>().List<Module>().AsQueryable();
        }

        public Module GetById(Guid? id)
        {
            return _session.Get<Module>(id);
        }

        public Module GetByName(string moduleName)
        {
            return _session.QueryOver<Module>()
                              .Where(m => m.ModuleName == moduleName)
                              .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Module user)
        {
            throw new NotImplementedException();
        }

        public void Add(Module module)
        {
            Partner.Create(module.ModuleId,module.ModuleName);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(module);
                tx.Commit();
            }
        }

        public IQueryable<Module> Search(Func<Module, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Module IsValidCustomer(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
