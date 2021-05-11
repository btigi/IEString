using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace IEString.Database
{
    public class DataAccess : IDataAccess, IDisposable
    {
        private readonly SQLiteConnection Connection;

        public DataAccess(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
            Connection.Open();
        }

        public async Task<string> GetString(string game)
        {
            var sql = @"select stringText from StringData where game = @game and trim(stringtext) != '' order by random() limit 1";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@game", game);
            var st = (string)await cmd.ExecuteScalarAsync();
            return st;
        }

        public async Task<string> GetString(string game, int strref)
        {
            var sql = @"select stringText from StringData where game = @game and strref = @strref";
            using var cmd = new SQLiteCommand(sql, Connection);
            cmd.Parameters.AddWithValue("@game", game);
            cmd.Parameters.AddWithValue("@strref", strref);
            var st = (string)await cmd.ExecuteScalarAsync();
            return st;
        }

        public async Task<string> GetString()
        {
            var sql = @"select stringText from StringData where trim(stringtext) != '' order by random() limit 1";
            using var cmd = new SQLiteCommand(sql, Connection);
            var st = (string)await cmd.ExecuteScalarAsync();
            return st;
        }

        public async Task<List<string>> GetGames()
        {
            var result = new List<string>();
            var sql = @"select distinct game from StringData where game != '' order by game";
            using var cmd = new SQLiteCommand(sql, Connection);
            using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }
            reader.Close();
            return result;
        }

        public void Dispose()
        {
            Connection?.Close();
            Connection.Dispose();
        }
    }
}