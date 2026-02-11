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

        public IActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }

        // agora se formos na url /items/edit/5, o resultado será Id = 5
        // estamos no controller de items e edit 
        // ele só vai mostrar o content porque não criamos uma view para essa action, mas se criarmos uma view para ela, ele vai mostrar a view normalmente, e o id não vai aparecer mais, a não ser que a gente passe ele para a view.
    }
}