using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Pineapple.Genetics.infrastructure.EntityFramework
{
    public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
    {
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(databaseOptions.Value.ConnectionString);
    }
}
