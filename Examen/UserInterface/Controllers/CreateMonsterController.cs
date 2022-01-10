using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class CreateMonsterController : Controller
    {
        private readonly HttpClient client = new ();
        private readonly Uri getRandomMonsterUri 
            = new("https://localhost:5005/Monster/GenerateMonster");

        [HttpPost]
        public async Task<IActionResult> CreateMonster(CharacterViewModel characterViewModel)
        {
            if (!ModelState.IsValid) return View();
            var monster = await client.GetFromJsonAsync<MonsterViewModel>(getRandomMonsterUri);
            var game = new GameViewModel(monster, characterViewModel);
            return View("~/Views/CreateMonster/ShowMonster.cshtml",game);
        } 
    }
}