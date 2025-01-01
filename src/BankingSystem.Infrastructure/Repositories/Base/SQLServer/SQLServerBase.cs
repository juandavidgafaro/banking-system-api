namespace BankingSystem.Infrastructure.Repositories.Base.SQLServer;
public class SqlServerBase<T> where T : class
{
    public required string ConnectionString;
    public SqlServerBase(string connectionString)
    {
        ConnectionString = connectionString;
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
    public async Task<T> SingleInsert<T>(string sql, object parameters)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            var insertedEntity = await conn.QuerySingleAsync<T>(sql, parameters);
            return insertedEntity;
        }
    }

    public async Task<int> SingleUpdate(string sql, object parameters)
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

    public async Task<int> SingleUpdate(string sql)
    {
        int affectedRows;
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            affectedRows = await conn.ExecuteAsync(sql, commandTimeout: 120);
            conn.Close();
        }
        return affectedRows;
    }

    public async Task<IEnumerable<TResult>> ExecuteResult<TResult>(string sql, object parameters)
    {
        IEnumerable<TResult> result = Enumerable.Empty<TResult>();
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            try
            {
                conn.Open();
                result = await conn.QueryAsync<TResult>(sql, parameters,
                    commandType: CommandType.Text, commandTimeout: 120);
                conn.Close();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        return result;
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
}
