using Microsoft.AspNetCore.Mvc;
using UserInterface.Models;

namespace UserInterface.Controllers
{
    public class CharacterController : Controller
    {
        [HttpGet] 
        public IActionResult CharacterCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CharacterCreate(CharacterViewModel characterViewModel)
        {
            return ModelState.IsValid ? View("~/Views/CreateMonster/CreateMonster.cshtml", characterViewModel) : View();
        }
    }
}