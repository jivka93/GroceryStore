using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string AddressText { get; set; }

        public int UserId { get; set; }

        public virtual User User {get; set;}
    }
}
