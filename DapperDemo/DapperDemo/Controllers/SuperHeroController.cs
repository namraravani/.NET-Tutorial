using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IConfiguration _Config;
        public SuperHeroController(IConfiguration config)
        {
            _Config = config;
        }

        [HttpGet]

        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroAsync()
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            IEnumerable<SuperHero> heroes = await SelectAllHeroes(connection);
            return Ok(heroes);
        }

        private static async Task<IEnumerable<SuperHero>> SelectAllHeroes(SqlConnection connection)
        {
            return await connection.QueryAsync<SuperHero>("Select * from SuperHero");
        }

        [HttpGet("{HeroId}")]

        public async Task<ActionResult<SuperHero>> GetHeroAsync(int HeroId)
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            var hero = await connection.QueryAsync<SuperHero>("Select * from SuperHero where id = @Id",new {Id= HeroId});
            return Ok(hero);
        }

        [HttpPost]

        public async Task<ActionResult<SuperHero>> InsertHeroAsync(SuperHero Hero)
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            var hero = await connection.ExecuteAsync("Insert into SuperHero(full_name,first_name,last_name,place) values (@full_name,@first_name,@last_name,@place)",Hero);
            return Ok(await SelectAllHeroes(connection));
        }

        [HttpPut]

        public async Task<ActionResult<SuperHero>> UpdateHeroAsync(SuperHero Hero)
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            var hero = await connection.ExecuteAsync("update SuperHero set full_name = @full_name, first_name = @first_name,last_name = @last_name,place=@place where id = @id", Hero);
            return Ok(await SelectAllHeroes(connection));
        }

        [HttpDelete("{HeroId}")]
        public async Task<ActionResult<SuperHero>> DeleteHeroAsync(int HeroId)
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            var hero = await connection.ExecuteAsync("Delete from SuperHero where id = @id", new {id = HeroId });
            return Ok(await SelectAllHeroes(connection));
        }

        [HttpGet("StoredProcedures/{Place}")]

        public async Task<IEnumerable<SuperHero>> GetHeroesByPlace(string Place)
        {
            using var connection = new SqlConnection(_Config.GetConnectionString("DeafultConnection"));
            {
                await connection.OpenAsync();
                var heroes = await connection.QueryAsync<SuperHero>(
                    "fetchheroesbyplaces",
                    new {place = @Place},
                    commandType : CommandType.StoredProcedure
                    );

                return heroes;
            }
        }
    }   
}
