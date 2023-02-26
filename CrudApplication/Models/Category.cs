using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int CId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
