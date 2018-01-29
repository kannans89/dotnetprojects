using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.MappingClass;
using TaskManagementSystemLibrary.Model;
using NHibernate.Linq;

namespace TaskManagementSystemLibrary.TaskMangementSystemRepository
{
    public class UserRepository : NHibernateHelper, IRepository<User>
    {
        public UserRepository()
        {
            var cfg = NHibernateHelper.InitializeSessionFactory()
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>());
            NHibernateHelper.OpenSession(cfg);
        }

        public IQueryable<User> Get()
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Query<User>();
            }
        }

        public User GetById(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Get<User>(id);
            }
        }

        public User GetByName(string userName)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var user = _session.QueryOver<User>().Where(m => m.FirstName == userName).SingleOrDefault();
                return user;
            }
        }

        public void Delete(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var user = _session.Get<User>(id);
                _session.Delete(user);
                transaction.Commit();
            }
        }

        public void Update(User user, int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var userById = _session.Get<User>(id);
                userById.FirstName = user.FirstName;
                userById.LastName = user.LastName;
                userById.MobileNumber = user.MobileNumber;
                userById.Email = user.Email;
                userById.UserName = user.UserName;
                userById.Password = user.Password;
                _session.Update(userById);
                transaction.Commit();
            }
        }

        public void Add(User user)
        {
            var transaction = _session.BeginTransaction();
                _session.Save(user);
                transaction.Commit();
        }

        public IQueryable<User> Search(Func<User, bool> predicate, int? userId)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var userList = _session.CreateCriteria<User>().List<User>().ToList();
                transaction.Commit();
                return userList.Where(predicate).AsQueryable();
            }
        }
    }
}
