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
            //this.Adresses = new HashSet<Address>();
            //this.BankCards = new HashSet<BankCard>();
            //this.Orders = new HashSet<Order>();
        }

        [Key]
        public virtual int Id { get; set; }

        [Required]
        [MinLength(Constants.UserNameMinLength)]
        [MaxLength(Constants.UserNameMaxLength)]
        [Index(IsUnique = true)]
        public virtual string Username { get; set; }

        [Required]
        public virtual string Password { get; set; }

        [Required]
        [MinLength(Constants.PhoneNumberMinLength)]
        [MaxLength(Constants.PhoneNumberMaxLength)]
        [Column("Phone number")]
        public virtual string PhoneNumber { get; set; }

        [MaxLength(Constants.NameMaxLength)]
        [Column("First name")]
        public virtual string FirstName { get; set; }

        [MaxLength(Constants.NameMaxLength)]
        [Column("Last name")]
        public virtual string LastName { get; set; }


        public virtual ICollection<Address> Adresses { get; set; }
        public virtual ICollection<BankCard> BankCards { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
