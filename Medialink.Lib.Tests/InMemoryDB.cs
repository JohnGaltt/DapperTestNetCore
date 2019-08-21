using Medialink.Lib.DataAccess.Models;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.Lib.Tests
{
    public class InMemoryDatabase
    {
        private readonly OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(":memory:", SqliteOrmLiteDialectProvider.Instance);

        public IDbConnection OpenConnection() => this.dbFactory.OpenDbConnection();

        public void Insert<T>(T item)
        {
            using (var db = this.OpenConnection())
            {
                db.CreateTableIfNotExists<T>();
                db.Insert(item);
            }
        }
    }
}
