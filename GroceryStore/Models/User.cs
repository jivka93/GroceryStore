using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        public User()
        {
            this.Adresses = new HashSet<Address>();
            //this.BankCards = new HashSet<BankCard>();
            //this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        [Column("Phone number")]
        public string PhoneNumber { get; set; }

        [MaxLength(20)]
        [Column("First name")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Column("Last name")]
        public string LastName { get; set; }


        public virtual ICollection<Address> Adresses { get; set; }
        //public virtual ICollection<BankCard> BankCards { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
