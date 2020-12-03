using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Phones")]
    public class Phones
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Phone]
        public int Number { get; set; }
        public IEnumerable<PersonNumbers> PersonNumbers { get; set; }
    }
}
