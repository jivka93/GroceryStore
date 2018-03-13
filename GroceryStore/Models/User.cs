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
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        //[Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }

        public virtual ICollection<Address> Adresses { get; set; }
        //public virtual ICollection<BankCard> BankCards { get; set; }
    }
}
