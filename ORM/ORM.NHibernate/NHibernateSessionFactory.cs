using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

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


    public class Person
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }

    public class Author
    {
        public virtual int Id { get; protected set; }

        public virtual string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

    }

    public class Book
    {
        public virtual int Id { get; protected set; }

        public virtual string Title { get; set; }
        public virtual string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Author Author { get; set; }

        [ForeignKey("Author")]
        public virtual int AuthorId { get; set; }
        public virtual int Price { get; set; }
    }
}