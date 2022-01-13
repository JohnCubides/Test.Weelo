using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Test.Weelo.Domain.Dto;
using Test.Weelo.Domain.Dto.PropertyDto;
using Test.Weelo.Domain.Entities;
using Test.Weelo.Persistence;
using Test.Weelo.Service.Helpers;

namespace Test.Weelo.Service.Features.PropertyFeatures.Queries
{
    public class GetAllPropertyFiltersQuery : IRequest<PropertyFiltersResponseDto>
    {
        public FilterPropertyDto Filters { get; set; }

        public PaginationDto Pager { get; set; }

        public class GetAllPropertyFiltersQueryHandler : IRequestHandler<GetAllPropertyFiltersQuery, PropertyFiltersResponseDto>
        {
            private readonly IApplicationDbContext _context;

            public GetAllPropertyFiltersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<PropertyFiltersResponseDto> Handle(GetAllPropertyFiltersQuery request, CancellationToken cancellationToken)
            {

                return await ListPager(request);


            }

            private async Task<PropertyFiltersResponseDto> ListPager(GetAllPropertyFiltersQuery request)
            {
                FilterPropertyDto filters = request.Filters;
                PaginationDto pager = request.Pager;
                IQueryable<PropertyEntity> query = Filter(filters);

                if (pager.QuantityToShow == 0)
                    pager = new PaginationDto();

                if (pager.Page == 0)
                    pager.Page = 1;

                
                pager.TotalData = query.Count();
                pager.TotalPages = Math.Ceiling(pager.TotalData / pager.QuantityToShow);
                pager.Page = pager.Page <= pager.TotalPages ? pager.Page : (int)pager.TotalPages;


                return new PropertyFiltersResponseDto()
                {
                    Properties = await query.Page(pager).ToListAsync(),
                    Pager = pager
                };
            }

            public IQueryable<PropertyEntity> AddFilter(IQueryable<PropertyEntity> old, IQueryable<PropertyEntity> additional) {

                if (old.Count() == 0 && additional.Count() > 0)
                    return additional;
                else if (old.Count() > 0)
                    return old.Union(additional);

                return Enumerable.Empty<PropertyEntity>().AsQueryable();
            }

            public IQueryable<PropertyEntity> Filter(FilterPropertyDto filter)
            {
                
                var properties = _context.Property.Include(prop => prop.Owner).Include(prop => prop.PropertyImages).Include(prop => prop.PropertyTraces).AsQueryable();
                int addFilter = 0;

                IQueryable<PropertyEntity> queryable = Enumerable.Empty<PropertyEntity>().AsQueryable();

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    addFilter++;
                    IQueryable<PropertyEntity> names = properties.Where(prop => !string.IsNullOrEmpty(prop.Name) && prop.Name.ToUpper().Contains(filter.Name.ToUpper()));
                    queryable = AddFilter(queryable, names);
                }

                if (!string.IsNullOrEmpty(filter.CodeInternal))
                {
                    addFilter++;
                    IQueryable<PropertyEntity> codeInternal = properties.Where(prop => !string.IsNullOrEmpty(prop.CodeInternal) && prop.CodeInternal.ToUpper().Contains(filter.CodeInternal.ToUpper()));
                    queryable = AddFilter(queryable, codeInternal);
                }

                if (filter.IdOwner > 0)
                {
                    addFilter++;
                    IQueryable<PropertyEntity> owners = properties.Where(prop => prop.IdOwner.Equals(filter.IdOwner));
                    queryable = AddFilter(queryable, owners);
                }

                if (filter.MaxPrice > 0)
                { 
                    addFilter++;
                    IQueryable<PropertyEntity>  price = properties.Where(prop => prop.Price >= filter.MinPrice).Where(prop => prop.Price <= filter.MaxPrice);
                    queryable = AddFilter(queryable, price);
                }

                if (filter.MaxYear > 0)
                {
                    addFilter++;
                    IQueryable<PropertyEntity>  year = properties.Where(prop => prop.Year >= filter.MinYear).Where(prop => prop.Year <= filter.MaxYear);
                    queryable = AddFilter(queryable, year);
                }

                

                if (addFilter == 0)
                    queryable = properties;

                return queryable;
            }

        }
    }
}
