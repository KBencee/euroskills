using euroskills2018.Models;
using Microsoft.EntityFrameworkCore;

namespace euroskills2018.Data
{
    public class VersenyzoDbContext : DbContext
    {
        public VersenyzoDbContext(DbContextOptions<VersenyzoDbContext> options) : base(options)
        {

        }
        public DbSet<Orszag> Orszagok {  get; set; }
        public DbSet<Szakma> Szakmak { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }
    }
}
