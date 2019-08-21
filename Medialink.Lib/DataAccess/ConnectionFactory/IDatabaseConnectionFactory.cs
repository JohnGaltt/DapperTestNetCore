using System.Data;

namespace Medialink.Lib.Infrastructure.ConnectionFactory
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
