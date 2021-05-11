using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEString.Database
{
    public interface IDataAccess
    {
        Task<string> GetString(string game);
        Task<string> GetString(string game, int strref);
        Task<string> GetString();
        Task<List<string>> GetGames();
    }
}