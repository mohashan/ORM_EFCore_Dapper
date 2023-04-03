using System.ComponentModel.DataAnnotations;

namespace ORM.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}