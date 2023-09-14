using API_Portfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Portfolio.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Projects.Any(p => p.Name == "Example"))
            {
                 

                var projects = new List<PortfolioProject>
                {
                    new PortfolioProject
                    {
                        Name = "Example",
                        Date = new DateTime(2023, 5, 12, 0, 0, 0),
                        Description =  "Example",
                        Months = 9,
                        ImageURL = "Images/first.png",
                        Stack = "Razor Pages"
                        


                    }
                 
                    
                };

                _dbContext.Projects.AddRange(projects);

                
            }


        }
    }
}
