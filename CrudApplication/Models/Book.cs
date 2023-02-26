using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    [Table("tblbook")]
    public class Book
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        public string? Name { get; set; }
        [Required]

        public double Price { get; set; } 

    }
}
