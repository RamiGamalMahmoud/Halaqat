using Halaqat.Data;
using Halaqat.Shared;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Halaqat.Features.Settings
{
    internal class DatabaseOperations(SqlConnectionFactory sqlConnectionFactory)
    {
        public async Task Backup()
        {
            string query = @"
                BACKUP DATABASE [halaqat]
                TO DISK = 'halaqat.bak'
                WITH INIT";

            using (SqlConnection connection = sqlConnectionFactory.CreateSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await connection.CloseAsync();
            }
        }

        public async Task<Result> Restore()
        {
            string query = @"
                USE master;  

                -- Set the database to SINGLE_USER mode  
                ALTER DATABASE halaqat SET SINGLE_USER WITH ROLLBACK IMMEDIATE;  

                -- Restore the database from the backup  
                RESTORE DATABASE halaqat   
                FROM DISK = 'halaqat.bak'   
                WITH REPLACE;  

                -- Set the database back to MULTI_USER mode  
                ALTER DATABASE halaqat SET MULTI_USER;  

                ";

            using (SqlConnection connection = sqlConnectionFactory.CreateSqlConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                await connection.OpenAsync();
                try
                {
                    await command.ExecuteNonQueryAsync();
                    return Result.Success;
                }
                catch (System.Exception)
                {
                    return new Result();
                }
            }
        }
    }
}
