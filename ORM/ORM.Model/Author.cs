namespace ORM.Model
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; } 

    }

    
}