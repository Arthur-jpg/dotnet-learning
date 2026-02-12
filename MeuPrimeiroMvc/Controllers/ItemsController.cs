using MeuPrimeiroMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MeuPrimeiroMvc.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        // public IActionResult Edit(int id)
        // {
        //     return Content("Id = " + id);
        // }

        // agora se formos na url /items/edit/5, o resultado será Id = 5
        // estamos no controller de items e edit 
        // ele só vai mostrar o content porque não criamos uma view para essa action, mas se criarmos uma view para ela, ele vai mostrar a view normalmente, e o id não vai aparecer mais, a não ser que a gente passe ele para a view.


        // aq vamos fazer o incio do crud
        private readonly MeuPrimeiroMvcContext _context;
        public ItemsController(MeuPrimeiroMvcContext context)
        {
            _context = context;
        }
        // é recomendado, quando usando dados do DB, usar async
        public async Task<IActionResult> Index()
        {
            // pega os dados e só passa pra view depois que tiver concluido
            var item = await _context.Items.Include(i => i.SerialNumber)
            .Include(i => i.Category).Include(i => i.ItemClients).ThenInclude(ic => ic.Client).ToListAsync();

            return View(item);
        }
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, CategoryId")] Item item)
        {
            if(ModelState.IsValid)
            {
                _context.Items.Add(item);
                // adding input to the database
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        //para direcionar a gente para a página com o item a ser editado
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name", item?.CategoryId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, CategoryId")] Item item)
        {
            if(ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // pegar o item do db
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }
    }
}