using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Weelo.Domain.Entities
{
    [Table("PropertyImage")]
    public class PropertyImageEntity
    {
        [Key]
        public int IdPropertyImage { get; set; }

        [ForeignKey("IdProperty")]
        public PropertyEntity Property { get; set; }
        [Required]
        public int IdProperty { get; set; }

        public bool Enabled { get; set; }
    }
}
