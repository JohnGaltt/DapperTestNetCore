using Dapper;
using Medialink.Lib.DataAccess.Models;
using Medialink.Lib.Infrastructure.ConnectionFactory;
using System.Threading.Tasks;

namespace Medialink.Lib.Infrastructure.Repositories
{
    public class ImportantObjectRepository : IImportantObjectRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public ImportantObjectRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public void Insert(int sum)
        {
           _databaseConnectionFactory
                .GetConnection()
                .ExecuteAsync("INSERT INTO ImportantObject VALUES(" + sum + ")");
        }
    }
}
