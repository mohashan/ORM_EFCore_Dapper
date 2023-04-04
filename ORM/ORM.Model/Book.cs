using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ORM.Model
{
    public class Book:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual Author Author { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public int Price { get; set; }
    }
}