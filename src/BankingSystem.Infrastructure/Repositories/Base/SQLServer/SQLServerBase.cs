namespace BankingSystem.Infrastructure.Repositories.Base.SQLServer;
public class SqlServerBase<T> where T : class
{
    public required string ConnectionString;
    public SqlServerBase(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public async Task<TResult> ExecuteSPOneResultAsync<TResult>(string nameStoreProcedure, object parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            IEnumerable<TResult> result = await conn.QueryAsync<TResult>(nameStoreProcedure, parameters,
            commandType: CommandType.StoredProcedure, commandTimeout: 120);
            conn.Close();
            return result.SingleOrDefault();
        }
    }

    public async Task<TResult> ExecuteQueryAsync<TResult>(string sql, object parameters)
    {
        IEnumerable<TResult> result = Enumerable.Empty<TResult>();
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            result = await conn.QueryAsync<TResult>(sql, parameters,
                commandType: CommandType.Text, commandTimeout: 120);
            conn.Close();
        }

        return result.SingleOrDefault();
    }

    public async Task<IEnumerable<TResult>> ExecuteResult<TResult>(string sql, object parameters)
    {
        IEnumerable<TResult> result = Enumerable.Empty<TResult>();
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            result = await conn.QueryAsync<TResult>(sql, parameters,
                commandType: CommandType.Text, commandTimeout: 120);
            conn.Close();
        }
        return result;
    }

    public async Task<IEnumerable<T>> ExecuteOneResultAsync(string nameStoreProcedure, object parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            IEnumerable<T> result = await conn.QueryAsync<T>(nameStoreProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return result;
        }
    }


    public async Task<bool> SingleInsert(string sql, object parameters)
    {
        bool isSuccessful;

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            isSuccessful = await conn.ExecuteScalarAsync<bool>(sql, parameters);
        }

        return isSuccessful;
    }


    public async Task<int> SingleUpDate(string sql, object parameters)
    {
        int affectedRows;
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            affectedRows = await conn.ExecuteAsync(sql, parameters, commandTimeout: 120);
            conn.Close();
        }
        return affectedRows;
    }

    public async Task<T> ExecuteSingleAsync(string sql, object sqlParameters)
    {
        T sqlResponse = default;

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            sqlResponse = (await connection.QueryAsync<T>(sql, param: sqlParameters, commandTimeout: 120)).FirstOrDefault();
            connection.Close();
        }
        return sqlResponse;
    }
    public async Task<T> ExecuteSingleQueryAsync(string sql, object sqlParameters)
    {
        T entity = default(T);

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            entity = (await connection.QueryAsync<T>(sql, param: sqlParameters, commandTimeout: 120)).FirstOrDefault();
        }
        return entity;
    }

    public async Task<IEnumerable<T>> ExecuteQueryAsync(string sql, object sqlParameters)
    {
        IEnumerable<T> rows = new List<T>();

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            rows = await connection.QueryAsync<T>(sql, sqlParameters, commandTimeout: 120);
            connection.Close();
        }
        return rows;
    }
    public async Task<bool> SingleQueryAsync(string sql, object sqlParameters)
    {
        bool rows = false;
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            IEnumerable<dynamic> results = await connection.QueryAsync(sql, sqlParameters, commandTimeout: 120);
            rows = results.Any();
            connection.Close();
        }
        return rows;
    }
}
