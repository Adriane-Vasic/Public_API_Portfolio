using API_Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Portfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=YourDatabaseName;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }


       public DbSet<PortfolioProject> Projects { get; set; }
    }

}
