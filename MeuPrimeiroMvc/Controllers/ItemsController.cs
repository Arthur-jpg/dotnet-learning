using MeuPrimeiroMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuPrimeiroMvc.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item() { Name="keyboard"};
            // não vai precisar passar o id que o programa já passa
            return View(item);
        }
    }
}