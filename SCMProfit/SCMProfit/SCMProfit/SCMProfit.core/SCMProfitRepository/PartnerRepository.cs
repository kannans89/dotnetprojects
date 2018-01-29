using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.MasterModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class PartnerRepository : NHibernateHelper, IRepository<Partner>
    {
        public PartnerRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<PartnerMap>());
            OpenSession(cfg);
        }

        public IQueryable<Partner> Get()
        {
            return _session.CreateCriteria<Partner>().List<Partner>().AsQueryable();
        }

        public Partner GetById(Guid? id)
        {
            return _session.Get<Partner>(id);
        }

        public Partner GetByName(string userName)
        {
            return _session.QueryOver<Partner>()
                                .Where(m => m.PartnerName == userName)
                                .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Partner user)
        {
            throw new NotImplementedException();
        }

        public void Add(Partner partner)
        {
            Partner.Create(partner.PartnerId,partner.PartnerName);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(partner);
                tx.Commit();
            }
        }

        public IQueryable<Partner> Search(Func<Partner, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Partner IsValidCustomer(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
