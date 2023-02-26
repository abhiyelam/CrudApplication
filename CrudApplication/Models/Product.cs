using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string PName { get; set; }

        
        [Required]
        public int Price { get; set; }
        
        [Required]
        public string Company { get; set; }
       
        [Required]

        public int CId { get; set; }
    }
}
