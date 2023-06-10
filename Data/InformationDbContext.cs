using Microsoft.EntityFrameworkCore;
using Inventory.Models;

namespace Inventory.Data
{
    public class InformationDbContext : DbContext
    {
        public InformationDbContext(DbContextOptions<InformationDbContext> options)
            : base(options) 
        { 
        }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Login_Sign> Login_Signs { get; set; }

    }
}
