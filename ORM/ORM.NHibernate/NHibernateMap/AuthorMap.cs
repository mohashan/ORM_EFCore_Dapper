using FluentNHibernate.Mapping;
using static NHibernateSessionFactory;

public class AuthorMap : ClassMap<Author>
{
    public AuthorMap()
    {
        Table("Authors");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Name);
    }
}
