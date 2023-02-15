using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace PlanningAndAssessmentLib.DataAccess;

public class SqlDataAccess : IDataAccess
{
    private readonly IConfiguration config;

    public SqlDataAccess(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionString)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        var rows = await connection.QueryAsync<T>(storedProcedure, parameters);

        return rows.ToList();
    }

    public Task SaveData<T>(string sql, T parameters, string connectionString)
    {
        using IDbConnection connection = new MySqlConnection(connectionString);

        return connection.ExecuteAsync(sql, parameters);
    }
}
