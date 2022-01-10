using System.Threading.Tasks;
using Database.Repository.MonsterRepository;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonsterController : ControllerBase
    {
        private readonly MonsterRepository monsterRepository;
        public MonsterController(MonsterRepository monsterRepository)
        {
            this.monsterRepository = monsterRepository;
        }
        
        [HttpGet]
        [Route("GenerateMonster")]
        public async Task<JsonResult> GenerateMonster()
        {
            var monster = await monsterRepository.GetRandomMonsterAsync();
            return new JsonResult(monster);
        }
    }
}