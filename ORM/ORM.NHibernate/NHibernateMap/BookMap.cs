using FluentNHibernate.Mapping;
using ORM.Model;

public class BookMap : ClassMap<Book>
{
    public BookMap()
    {
        Table("Books");
        Id(x => x.Id).GeneratedBy.Identity();
        Map(x => x.Price);
        Map(x => x.Description);
        Map(x => x.AuthorId);
    }
}