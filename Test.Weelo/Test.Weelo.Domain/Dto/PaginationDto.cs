using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Weelo.Domain.Dto
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;

        public int QuantityToShow { get; set; } = 10;

        public double TotalPages { get; set; }

        public double TotalData { get; set; }
    }
}
