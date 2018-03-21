using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        [InverseProperty("Product")]
        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
