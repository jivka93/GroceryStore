using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Client
    {
        public Client()
        {
            this.Adresses = new HashSet<Address>();
            this.BankCards = new HashSet<BankCard>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Address> Adresses { get; set; }
        public ICollection<BankCard> BankCards { get; set; }
    }
}
