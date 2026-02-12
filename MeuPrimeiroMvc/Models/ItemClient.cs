

using System.ComponentModel.DataAnnotations.Schema;

namespace MeuPrimeiroMvc.Models
{
    public class ItemClient
    {
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }


    }
    
}