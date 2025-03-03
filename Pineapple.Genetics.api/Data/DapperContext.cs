using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using Pineapple.Genetics.api.Helpers.Options;

namespace Pineapple.Genetics.api.Data
{
    public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
    {
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(databaseOptions.Value.ConnectionString);
    }
}
