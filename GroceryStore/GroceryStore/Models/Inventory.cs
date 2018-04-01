using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Inventory
    {
        [Key]
        [Required]
        [Index(IsUnique = true)]
        public int ProductId { get; set; }


        [Column("Quantity In Stock")]
        public int QuantityInStock { get; set; }

        public virtual Product Product { get; set; }
    }
}
