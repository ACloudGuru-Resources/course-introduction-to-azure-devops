using Microsoft.EntityFrameworkCore.Design;

namespace Miniboard.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MiniboardContext>
    {
        public MiniboardContext CreateDbContext(string[] args)
        {
            var connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Miniboard";

            var factory = new ContextFactory(connectionString);
            return factory.CreateContext();
        }
    }
}
