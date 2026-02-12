namespace MeuPrimeiroMvc.Models
{
    public class Item
    {
        public int Id {get; set;}
        public string Name {get; set;} = null!;

        public double Price {get; set;}

        public int? SerialNumberId {get; set;}
        // não precisamos especificar o ForeingKey proque é o mesmo princípio do banco de dados
        // 1 para 1 você só precisa ter a foreing key em uma das tabelas
        public SerialNumber? SerialNumber {get; set;} = null!;
    }
    
}
// /items/overview
// então vamos precisar de um items controller e de uma action overview