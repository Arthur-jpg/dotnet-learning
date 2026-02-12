using System.ComponentModel.DataAnnotations.Schema;
namespace MeuPrimeiroMvc.Models

{
    public class SerialNumber
    {
        public int Id {get; set;}

        public string Name {get; set;} = null!;

        // para conectar
        // criamos uma propriedade para guardar o Item Id
        public int? ItemId {get; set;}
        // o ponto de interrogação é para dizer que o ItemId pode ser nulo, ou seja, um SerialNumber pode não estar associado a um Item no inicio
        [ForeignKey("ItemId")]
        public Item? Item {get; set;} = null!;
    }
    
}