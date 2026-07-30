using FirebirdSql.EntityFrameworkCore.Firebird;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using FlightPal.Models;

namespace FlightPal.Data
{
    public class DatabaseConnection: IDatabaseConnection
    {
        private string _connectionString;

        public DatabaseConnection(DBOptions dBOptions)
        {
            _connectionString = dBOptions.ConnectionString;

        }

        public Task<T> ExecuteTransactionAsync<T>(Func<FbConnection, Task> operation)
        {
            throw new NotImplementedException();
        }

        public async Task<FbConnection> GetConnectionAsync()
        {
            FbConnection connection = null;
            try
            {
                connection = new FbConnection(_connectionString);
                await connection.OpenAsync();
     
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la conexión a la base de datos: {ex.Message}");
            }
            return connection;
        }


    }
}
