using System.ComponentModel.DataAnnotations;

namespace Test.Weelo.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
