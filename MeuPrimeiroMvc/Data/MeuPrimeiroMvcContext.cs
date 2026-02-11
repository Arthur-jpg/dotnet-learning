using Microsoft.EntityFrameworkCore;
using MeuPrimeiroMvc.Models;

namespace MeuPrimeiroMvc.Data

{
    public class MeuPrimeiroMvcContext : DbContext
    {
        public MeuPrimeiroMvcContext (DbContextOptions<MeuPrimeiroMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }

    // a classe context é a nossa conexão com o banco de dados
    // no java seria equivalente ao EntityManager
}