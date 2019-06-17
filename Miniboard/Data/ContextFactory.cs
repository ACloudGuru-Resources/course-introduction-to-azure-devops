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
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (configuration["SqlDatabase.ConnectionString"] == null)
            {
                throw new InvalidOperationException("Provided configuration does not contain a connectionstring");
            }

            _connectionString = configuration["SqlDatabase.ConnectionString"];
        }

        public ContextFactory(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
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
