using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfcRepositories
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Mario\\RiderProjects\\DNPAssigment1\\Server\\EfcRepositories\\app.db");

            return new AppContext(optionsBuilder.Options);
        }
    }
}