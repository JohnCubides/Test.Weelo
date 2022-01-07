using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Test.Weelo.Domain.Entities
{
    [Table("Property")]
    public class PropertyEntity
    {
        [Key]
        public int IdProperty { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

        public string CodeInternal { get; set; }

        public int Year { get; set; }

        [ForeignKey("IdOwner")]
        public OwnerEntity Owner { get; set; }
        public int IdOwner { get; set; }

        public List<PropertyTraceEntity> PropertyTraces { get; set; }

        public List<PropertyImageEntity> PropertyImages { get; set; }

    }
}
