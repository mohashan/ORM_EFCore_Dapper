using System.Text.Json.Serialization;

namespace ORM.Model
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; } 

    }

    
}