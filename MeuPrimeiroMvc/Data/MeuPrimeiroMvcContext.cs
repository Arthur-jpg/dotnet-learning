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

        // sobrescrevendo um método para popular o banco de dados com um item
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id=5, Name="Microphone", Price=100.0, SerialNumberId=10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id=10, Name="MIC150", ItemId=5 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Electronics" },
                new Category { Id=2, Name="Books" }
            );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    // a classe context é a nossa conexão com o banco de dados
    // no java seria equivalente ao EntityManager
}