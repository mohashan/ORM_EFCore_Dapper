using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

public class NHibernateSessionFactory
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
            {
                var connectionString = "Server=.;Database=PublisherDb;Trusted_Connection=True;TrustServerCertificate=True;";
                var configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorMap>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BookMap>())
                    .BuildConfiguration();
                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
}