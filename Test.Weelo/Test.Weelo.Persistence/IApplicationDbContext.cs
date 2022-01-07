using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Test.Weelo.Domain.Entities;

namespace Test.Weelo.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<OwnerEntity> Owners { get; set; }
        DbSet<PropertyEntity> Property { get; set; }
        DbSet<PropertyImageEntity> PropertyImage { get; set; }
        DbSet<PropertyTraceEntity> PropertyTrace { get; set; }

        Task<int> SaveChangesAsync();
    }
}
