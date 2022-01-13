
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Weelo.Domain.CustomValidations;

namespace Test.Weelo.Domain.Dto.PropertyDto
{
    public class FilterPropertyDto
    {
        public string Name { get;set; }

        [GreaterThanPrice("MinPrice", ErrorMessage = "Max Price is lower than Min Price")]
        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }

        public string CodeInternal { get;set;}

        public int MinYear { get; set; }

        [GreaterThanYear("MinYear", ErrorMessage = "Max Year is lower than Min Year")]
        public int MaxYear { get; set; }

        public int IdOwner { get; set; }

    }
}
