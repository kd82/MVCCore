using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MvcCoreApplication.Entities
{
    public class MvcCoreApplicationDbContext :IdentityDbContext<User>
    {

        public MvcCoreApplicationDbContext(DbContextOptions options):base(options)
        {
           
        }
        public DbSet<Restaurant> restaurants { get; set; }
    }
}
