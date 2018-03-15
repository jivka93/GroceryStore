using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BankCard
    {
        [Required]
        [MaxLength(16)]
        [MinLength(16)]
        public string Number { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
