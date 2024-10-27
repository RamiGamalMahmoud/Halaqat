using Halaqat.Shared.Common;
using Microsoft.Data.SqlClient;

namespace Halaqat.Data
{
    public class SqlConnectionFactory(ConnectionStringFactory connectionStringFactory)
    {
        public SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(connectionStringFactory.GetConnectionStringWithNotDatabase());
        }
    }
}
