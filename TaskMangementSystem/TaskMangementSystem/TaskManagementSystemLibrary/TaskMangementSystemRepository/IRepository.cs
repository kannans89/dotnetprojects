using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemLibrary.TaskMangementSystemRepository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(int? id);
        T GetByName(String userName);
        void Delete(int? id);
        void Update(T user,int? id);
        void Add(T user);
        IQueryable<T> Search(Func<T, bool> predicate, int? userId);
    }
}
