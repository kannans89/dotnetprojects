using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace SCMProfitCore.SCMProfitRepository
{
    public class NHibernateHelper
    {
        protected ISession _session;
        protected ISessionFactory _sessionFactory;

        protected FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("DevelopmentDB"))
                                                                                 .ShowSql())
                   .ExposeConfiguration(cfg => new SchemaUpdate(cfg)
                   .Execute(true, true));
        }
        protected void OpenSession(FluentConfiguration cfg)
        {
            _sessionFactory = cfg.BuildSessionFactory();
            _session = _sessionFactory.OpenSession();
        }
    }
}
