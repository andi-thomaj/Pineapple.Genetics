using System.Data;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.EntityFramework
{
    public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
    {
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(databaseOptions.Value.ConnectionString);
    }
}
