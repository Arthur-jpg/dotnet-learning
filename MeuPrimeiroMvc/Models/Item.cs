using System.ComponentModel.DataAnnotations.Schema;

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


        // a foreing key tem que estar em item pelo mesmo motivo que no bd em um relacionamento 1 para N a foreing key tem que estar na tabela do lado N
        public int? CategoryId {get; set;}
        [ForeignKey("CategoryId")]
        public Category? Category {get; set;} = null!;
    }
    
}
// /items/overview
// então vamos precisar de um items controller e de uma action overview