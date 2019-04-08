using System.Data.Entity;
using Database.Models;

namespace Database
{
    public class AstronomerDbContext : DbContext
    {
        public AstronomerDbContext() : base(nameof(AstronomerDbContext))
        {
        }

        public DbSet<Astronomer> Astronomers { get; set; }
        public DbSet<HeavenlyBody> HeavenlyBodies { get; set; }
    }
}