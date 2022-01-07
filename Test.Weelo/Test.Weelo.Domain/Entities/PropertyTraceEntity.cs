using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Weelo.Domain.Entities
{
    [Table("PropertyTrace")]
    public class PropertyTraceEntity
    {
        [Key]
        public int IdPropertyTrace { get; set; }

        public DateTime DateSale { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Tax { get; set; }

        [ForeignKey("IdProperty")]
        public PropertyEntity Property { get; set; }

        public int IdProperty { get; set; }

    }
}
