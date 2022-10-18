using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace ClientDBMS.Services
{
    public class SessionFactory
    {
        public SessionFactory(AppConfiguration config)
        {
            var connectionString = config.GetConnectionString();
            _session = ConfigureSession(connectionString).OpenSession();    
        }

        public NHibernate.ISession _session;
        private ISessionFactory _sessionFactory;

        private ISessionFactory ConfigureSession(string connectionString) => _sessionFactory ??
            Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString
                (connectionString))
            .Mappings(m =>
            {
                m.FluentMappings.AddFromAssembly(typeof(ClientMapping).Assembly);
            })
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();

    }
}
