using System;
using System.Linq;
using SCMProfitCore.MappingClass;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfitCore.SCMProfitRepository
{
    public class CustomerDetailsRepository : NHibernateHelper, IRepository<Customer>
    {
        public CustomerDetailsRepository()
        {
            var cfg = GetConfiguration().Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>());
            OpenSession(cfg);
        }

        public IQueryable<Customer> Get()
        {
            var customer = _session.CreateCriteria<Customer>()
                .List<Customer>()
                .AsQueryable();

            return customer;
        }

        public Customer GetById(Guid? id)
        {
            var customer = _session.Get<Customer>(id);
            return customer;
        }

        public Customer GetByName(string companyName)
        {
            return _session.QueryOver<Customer>()
                               .Where(m => m.ShortName == companyName)
                               .SingleOrDefault();
        }

        public void Delete(Guid? id)
        {
            using (var tx = _session.BeginTransaction())
            {
                var customerCompany = _session.Get<Customer>(id);
                _session.Delete(customerCompany);
                tx.Commit();
            }
        }

        public void Update(Customer updateCustomerCompany)
        {
            using (var tx = _session.BeginTransaction())
            {
                var oldCustomerCompany = _session.CreateCriteria<Customer>()
                                      .List<Customer>()
                                      .Where(m => m.CustomerId == updateCustomerCompany.CustomerId)
                                      .SingleOrDefault(); ;
                if (oldCustomerCompany != null)
                {
                    oldCustomerCompany.CompanyName = updateCustomerCompany.CompanyName;
                    oldCustomerCompany.CustomerAddress = updateCustomerCompany.CustomerAddress;
                    oldCustomerCompany.PrimaryContact = updateCustomerCompany.PrimaryContact;
                    oldCustomerCompany.Currency = updateCustomerCompany.Currency;
                    oldCustomerCompany.ShortName = updateCustomerCompany.ShortName;
                    oldCustomerCompany.Email = updateCustomerCompany.Email;
                    _session.SaveOrUpdate(oldCustomerCompany);
                }
                tx.Commit();
            }
        }

        public void Add(Customer customer)
        {
            var customerDetails = Customer
            .Create(customer.CustomerId, customer.CompanyName, customer.PrimaryContact, customer.Currency, customer.ShortName, customer.Email, customer.FirstName, customer.LastName, customer.WebsiteUrl, customer.Subscriptions.AsQueryable().ToList(), customer.LoginDetails, customer.Partner, customer.CustomerAddress, customer.Role);
            using (var tx = _session.BeginTransaction())
            {
                _session.SaveOrUpdate(customerDetails.CustomerAddress);
                _session.SaveOrUpdate(customerDetails.LoginDetails);
                foreach (var subscription in customerDetails.Subscriptions)
                {
                    _session.SaveOrUpdate(subscription);
                }
                _session.SaveOrUpdate(customerDetails);

                tx.Commit();
            }
        }

        public IQueryable<Customer> Search(Func<Customer, bool> predicate)
        {
            var customerCompany = _session.CreateCriteria<Customer>()
                                          .List<Customer>();
            return customerCompany.Where(predicate).AsQueryable();
        }

        public Customer IsValidCustomer(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
