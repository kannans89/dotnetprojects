using System;
using System.Linq;

namespace SCMProfitCore.SCMProfitRepository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(Guid? id);
        T GetByName(string userName);
        void Delete(Guid? id);
        void Update(T user);
        void Add(T user);
        IQueryable<T> Search(Func<T, bool> predicate);
        T IsValidCustomer(String userName, String password);
    }
}
