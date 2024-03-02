using Npgsql;
using System.Data;

namespace RibbonBotDAL.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters, CommandType cmdType = CommandType.Text, string connectionId = "Default");
        Task SaveData<T>(string sql, T parameters, CommandType cmdType = CommandType.Text, string connectionId = "Default");

        NpgsqlConnection GetConnection(string connectionId = "Default");

        Task DeleteData<T>(string sql, T parameters, CommandType cmdType = CommandType.Text,
            string connectionId = "Default");
    }
}
