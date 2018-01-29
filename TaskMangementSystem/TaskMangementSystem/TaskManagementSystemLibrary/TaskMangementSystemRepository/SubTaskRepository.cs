using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;
using NHibernate.Linq;
using TaskManagementSystemLibrary.MappingClass;

namespace TaskManagementSystemLibrary.TaskMangementSystemRepository
{
    public class SubTaskRepository : NHibernateHelper, IRepository<SubTask>
    {
        public SubTaskRepository()
        {
            var cfg = NHibernateHelper.InitializeSessionFactory()
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SubTaskMap>());
            NHibernateHelper.OpenSession(cfg);
        }


        public IQueryable<SubTask> Get()
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Query<SubTask>();
            }
        }

        public SubTask GetById(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Get<SubTask>(id);
            }
        }

        public SubTask GetByName(string name)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var subTask = _session.QueryOver<SubTask>().Where(m => m.Name == name).SingleOrDefault();
                return subTask;
            }
        }

        public void Delete(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var subTask = _session.Get<SubTask>(id);
                _session.Delete(subTask);
                transaction.Commit();
            }
        }

        public void Update(SubTask subTask,int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var subTaskById = _session.Get<SubTask>(id);
                subTaskById.Name = subTask.Name;
                subTaskById.StartTime = subTask.StartTime;
                subTaskById.EndTime = subTask.EndTime;
                _session.Update(subTaskById);
                transaction.Commit();
            }
        }

        public void Add(SubTask subTask)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(subTask);
                transaction.Commit();
            }
        }

        public IQueryable<SubTask> Search(Func<SubTask, bool> predicate, int? userId)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var subTaskList = _session.CreateCriteria<SubTask>().List<SubTask>().ToList();
                transaction.Commit();
                return subTaskList.Where(predicate).AsQueryable();
            }
        }
    }
}
