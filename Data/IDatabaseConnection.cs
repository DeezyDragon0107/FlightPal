using FirebirdSql.Data.FirebirdClient;

namespace FlightPal.Data
{
    public interface IDatabaseConnection
    {
        public Task<FbConnection> GetConnectionAsync();
        public Task<T> ExecuteTransactionAsync<T>(Func<FbConnection, Task> operation);

    }
}
