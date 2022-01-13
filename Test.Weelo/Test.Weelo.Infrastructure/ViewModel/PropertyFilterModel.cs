using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;

namespace Test.Weelo.Infrastructure.ViewModel
{
    public class PropertyFilterModel
    {
        public List<PropertyEntity> Properties { get; set;}

        public PaginationModel Pagination { get; set; }


    }
}
