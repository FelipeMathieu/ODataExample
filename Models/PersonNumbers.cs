using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("PersonNumber")]
    public class PersonNumbers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        public int PhoneId { get; set; }
        public People Person { get; set; }
        public Phones Phone { get; set; }
    }
}
