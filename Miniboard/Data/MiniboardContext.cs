using Microsoft.EntityFrameworkCore;

namespace Miniboard.Data
{
    public class MiniboardContext : DbContext
    {
        public MiniboardContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<BoardMessage> BoardMessages { get; set; }
    }
}
