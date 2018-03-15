using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int InventoryId { get; set; }

        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
