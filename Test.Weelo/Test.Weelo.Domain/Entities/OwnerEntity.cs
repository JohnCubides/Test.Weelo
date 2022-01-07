using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Weelo.Domain.Entities
{
    [Table("Owner")]
    public class OwnerEntity
    {
        [Key]
        public int IdOwner { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Photho { get; set; }

        public DateTime Birthday { get; set; }
       
    }
}
