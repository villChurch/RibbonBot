﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;

namespace RibbonBotDAL.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {

        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, CommandType cmdType, string connectionId = "Default")
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(sql, parameters, commandType: cmdType);
        }

        public async Task SaveData<T>(string sql, T parameters, CommandType cmdType, string connectionId = "Default")
        {
            using var connection = new NpgsqlConnection(_configuration.GetConnectionString(connectionId));

            await connection.ExecuteAsync(sql, parameters, commandType: cmdType);
        }
    }
}
