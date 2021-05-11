using IEString.Database;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IEString.Controllers
{
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IDataAccess DataAccess;

        public InfoController(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        [HttpGet]
        [Route("/")]
        [Route("random")]
        public async Task<string> GetRandom()
        {
            var result = await DataAccess.GetString();
            return result;
        }

        [HttpGet]
        [Route("/games")]
        public async Task<List<string>> GetGames()
        {
            var result = await DataAccess.GetGames();
            return result;
        }

        [HttpGet]
        [Route("{game}/random")]
        public async Task<string> GetRandomByGame(string game)
        {
            var result = await DataAccess.GetString(game);
            return result;
        }

        [HttpGet]
        [Route("{game}/{strref}")]
        public async Task<string> GetSpecific(string game, int strref)
        {
            var result = await DataAccess.GetString(game, strref);
            return result;
        }
    }
}