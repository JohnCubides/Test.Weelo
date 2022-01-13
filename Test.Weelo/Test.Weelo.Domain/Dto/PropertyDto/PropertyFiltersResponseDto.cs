using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;

namespace Test.Weelo.Domain.Dto.PropertyDto
{
    public class PropertyFiltersResponseDto
    {
        public List<PropertyEntity> Properties { get; set; }

        public PaginationDto Pager { get; set; }

    }
}
