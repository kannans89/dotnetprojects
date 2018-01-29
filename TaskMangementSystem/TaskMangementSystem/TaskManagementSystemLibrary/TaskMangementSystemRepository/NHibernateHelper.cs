using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemLibrary.Model;

namespace TaskManagementSystemLibrary.TaskMangementSystemRepository
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        protected static ISession _session;

        public static void OpenSession(FluentConfiguration cfg)
        {
            _sessionFactory = cfg.BuildSessionFactory();
            _session= _sessionFactory.OpenSession();
        }

        public static FluentConfiguration InitializeSessionFactory()
        {
            return Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012
                                      .ConnectionString(c => c.FromConnectionStringWithKey("DevelopmentDB")).ShowSql())
                                      .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                                      .Execute(false,true));
        }
    }

}
