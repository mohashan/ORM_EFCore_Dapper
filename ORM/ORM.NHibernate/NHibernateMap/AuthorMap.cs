using FluentNHibernate.Mapping;
using ORM.Model;

public class AuthorMap : ClassMap<Author>
{
    public AuthorMap()
    {
        Table("Authors");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Name);
    }
}
