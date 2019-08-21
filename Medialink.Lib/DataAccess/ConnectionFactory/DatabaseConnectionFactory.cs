using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Medialink.Lib.Infrastructure.ConnectionFactory
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly IConfiguration _config;

        public DatabaseConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("MyConnectionString"));
        }
    }
}
