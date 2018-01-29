using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class CustomerLoginDetailsRepository : NHibernateHelper, IRepository<CustomerLoginDetails>
    {
        public CustomerLoginDetailsRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerLoginMap>());
            OpenSession(cfg);
        }

        public IQueryable<CustomerLoginDetails> Get()
        {
            return _session.CreateCriteria<CustomerLoginDetails>()
                               .List<CustomerLoginDetails>()
                               .AsQueryable();
        }

        public CustomerLoginDetails GetById(Guid? id)
        {
            return _session.Get<CustomerLoginDetails>(id);
        }

        public CustomerLoginDetails GetByName(string userName)
        {
            return _session.QueryOver<CustomerLoginDetails>()
                               .Where(m => m.UserName == userName)
                               .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            using (var tx = _session.BeginTransaction())
            {
                var loginDetails = _session.Get<CustomerLoginDetails>(id);
                _session.Delete(loginDetails);
                tx.Commit();
            }
        }

        public void Update(CustomerLoginDetails updateLoginDetails)
        {
            using (var tx = _session.BeginTransaction())
            {
                var oldloginDetails = _session.CreateCriteria<CustomerLoginDetails>()
                                      .List<CustomerLoginDetails>()
                                      .Where(m => m.LoginId == updateLoginDetails.LoginId)
                                      .SingleOrDefault(); ;
                if (oldloginDetails != null)
                {
                    oldloginDetails.UserName = updateLoginDetails.UserName;
                    oldloginDetails.Password = updateLoginDetails.Password;
                    _session.SaveOrUpdate(oldloginDetails);
                }
                tx.Commit();
            }
        }

        public void Add(CustomerLoginDetails customerLogin)
        {
            CustomerLoginDetails.Create(customerLogin.LoginId,customerLogin.UserName,customerLogin.Password);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(customerLogin);
                tx.Commit();
            }
        }

        public IQueryable<CustomerLoginDetails> Search(Func<CustomerLoginDetails, bool> predicate)
        {
            var customerLoginDetails = _session.CreateCriteria<CustomerLoginDetails>()
                                          .List<CustomerLoginDetails>();
            return customerLoginDetails.Where(predicate).AsQueryable();
        }

        public CustomerLoginDetails IsValidCustomer(string userName, string password)
        {
            return _session.CreateCriteria<CustomerLoginDetails>()
                                  .List<CustomerLoginDetails>()
                                  .Where(m => m.UserName == userName).SingleOrDefault();
        }
    }
}
