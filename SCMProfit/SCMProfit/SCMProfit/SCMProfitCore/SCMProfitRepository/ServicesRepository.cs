using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class ServicesRepository : NHibernateHelper, IRepository<Service>
    {
        public ServicesRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServiceMap>());
            OpenSession(cfg);
        }

        public IQueryable<Service> Get()
        {
            return _session.CreateCriteria<Service>().List<Service>().AsQueryable();
        }

        public Service GetById(Guid? id)
        {
            return _session.Get<Service>(id);
        }

        public Service GetByName(string serviceName)
        {
            return _session.QueryOver<Service>()
                                .Where(m => m.ServiceName == serviceName)
                                .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Service user)
        {
            throw new NotImplementedException();
        }

        public void Add(Service service)
        {
            Service.Create(service.ServiceId, service.ServiceName);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(service);
                tx.Commit();
            }
        }

        public IQueryable<Service> Search(Func<Service, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Service IsValidCustomer(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
