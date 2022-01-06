using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Test.Weelo.Persistence
{
    public interface IApplicationDbContext
    {

        Task<int> SaveChangesAsync();
    }
}
