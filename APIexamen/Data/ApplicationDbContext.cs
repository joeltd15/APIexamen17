using APIexamen.Models;
using Microsoft.EntityFrameworkCore;

namespace APIexamen.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Peaje> Peajes { get; set; }
    }
}
