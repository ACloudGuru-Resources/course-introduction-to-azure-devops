using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Miniboard.Data
{
    public class ContextFactory : IContextFactory
    {
        private readonly string _connectionString;

        public ContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration["SqlDatabase.ConnectionString"];
        }

        public ContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MiniboardContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<MiniboardContext>()
                .UseSqlServer(_connectionString, 
                options => options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null));

            return new MiniboardContext(builder.Options);
        }
    }
}
