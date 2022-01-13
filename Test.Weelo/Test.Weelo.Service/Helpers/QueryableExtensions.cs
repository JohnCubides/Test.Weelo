using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Weelo.Domain.Dto;

namespace Test.Weelo.Service.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, PaginationDto pagination)
        {
            return pagination.Page == 0
                ? queryable
                : queryable.Skip((pagination.Page - 1) * pagination.QuantityToShow).Take(pagination.QuantityToShow);
        }
    }
}
