using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class CustomerSubscriptionDetailsRepository : NHibernateHelper, IRepository<CustomerSubscriptionDetails>
    {
        public CustomerSubscriptionDetailsRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerSubscriptionMap>());
            OpenSession(cfg);
        }

        public IQueryable<CustomerSubscriptionDetails> Get()
        {
            return _session.CreateCriteria<CustomerSubscriptionDetails>()
                               .List<CustomerSubscriptionDetails>()
                               .AsQueryable();
        }

        public CustomerSubscriptionDetails GetById(Guid? id)
        {
            return _session.Get<CustomerSubscriptionDetails>(id);
        }

        public CustomerSubscriptionDetails GetByName(string subscriptionType)
        {
            return _session.QueryOver<CustomerSubscriptionDetails>()
                               .Where(m => m.Subscription == (CustomerSubscriptionType)Enum.Parse(typeof(CustomerSubscriptionType), subscriptionType))
                               .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            using (var tx = _session.BeginTransaction())
            {
                var customerCompany = _session.Get<CustomerSubscriptionDetails>(id);
                _session.Delete(customerCompany);
                tx.Commit();
            }
        }

        public void Update(CustomerSubscriptionDetails updatesubscriptionDetails)
        {
            using (var tx = _session.BeginTransaction())
            {
                var oldsubscriptionDetails = _session.CreateCriteria<CustomerSubscriptionDetails>()
                                      .List<CustomerSubscriptionDetails>()
                                      .Where(m => m.SubscriptionId == updatesubscriptionDetails.SubscriptionId)
                                      .SingleOrDefault(); ;
                if (oldsubscriptionDetails != null)
                {
                    oldsubscriptionDetails.Subscription = updatesubscriptionDetails.Subscription;
                    oldsubscriptionDetails.Modules = updatesubscriptionDetails.Modules;
                    oldsubscriptionDetails.Services = updatesubscriptionDetails.Services;
                    oldsubscriptionDetails.NumberOfNamedUsers = updatesubscriptionDetails.NumberOfNamedUsers;
                    _session.SaveOrUpdate(oldsubscriptionDetails);
                }
                tx.Commit();
            }
        }

        public void Add(CustomerSubscriptionDetails subscriptionDetails)
        {
           CustomerSubscriptionDetails.Create(subscriptionDetails.SubscriptionId,subscriptionDetails.Subscription,subscriptionDetails.NumberOfNamedUsers);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(subscriptionDetails);
                tx.Commit();
            }
        }

        public IQueryable<CustomerSubscriptionDetails> Search(Func<CustomerSubscriptionDetails, bool> predicate)
        {
            var customerSubscription = _session.CreateCriteria<CustomerSubscriptionDetails>()
                                          .List<CustomerSubscriptionDetails>();
            return customerSubscription.Where(predicate).AsQueryable();
        }

        public CustomerSubscriptionDetails IsValidCustomer(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
