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
    public class MainTaskRepository : NHibernateHelper, IRepository<MainTask>
    {
        public MainTaskRepository()
        {
            var cfg = NHibernateHelper.InitializeSessionFactory()
                                      .Mappings(m=>m.FluentMappings.AddFromAssemblyOf<MainTaskMap>());
            NHibernateHelper.OpenSession(cfg);
        }

        public IQueryable<MainTask> Get()
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Query<MainTask>();
            }
        }

        public MainTask GetById(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                return _session.Get<MainTask>(id);
            }
        }

        public MainTask GetByName(string name)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var mainTask = _session.QueryOver<MainTask>().Where(m => m.Name == name).SingleOrDefault();
                return mainTask;
            }
        }

        public void Delete(int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var mainTask = _session.Get<MainTask>(id);
                _session.Delete(mainTask);
                transaction.Commit();
            }
        }

        public void Update(MainTask mainTask,int? id)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var mainTaskById = _session.Get<MainTask>(id);
                mainTaskById.Name = mainTask.Name;
                mainTaskById.Date= mainTask.Date;
                mainTaskById.StartTime = mainTask.StartTime;
                mainTaskById.EndTime = mainTask.EndTime;
                mainTaskById.Priority = mainTask.Priority;
                _session.Update(mainTaskById);
                transaction.Commit();
            }
        }

        public void Add(MainTask mainTask)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(mainTask);
                transaction.Commit();
            }
        }

        public IQueryable<MainTask> Search(Func<MainTask, bool> predicate, int? userId)
        {
            using (var transaction = _session.BeginTransaction())
            {
                var mainTaskList = _session.CreateCriteria<MainTask>().List<MainTask>().ToList();
                transaction.Commit();
                return mainTaskList.Where(predicate).AsQueryable();
            }
        }
    }
}
