using Common;
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
            this.BankCards = new HashSet<BankCard>();
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.UserNameMinLength)]
        [MaxLength(Constants.UserNameMaxLength)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(Constants.PhoneNumberMinLength)]
        [MaxLength(Constants.PhoneNumberMaxLength)]
        [Column("Phone number")]
        public string PhoneNumber { get; set; }

        [MaxLength(Constants.NameMaxLength)]
        [Column("First name")]
        public string FirstName { get; set; }

        [MaxLength(Constants.NameMaxLength)]
        [Column("Last name")]
        public string LastName { get; set; }


        public virtual ICollection<Address> Adresses { get; set; }
        public virtual ICollection<BankCard> BankCards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
