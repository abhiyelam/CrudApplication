
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    [Table("tblEmp")]
    public class Employee1
    {
        [Required]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        
        [Display(Name="Emloyee name")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public  string? Email { get; set; }
        [Required]
        [MaxLength(10)]
        [DataType(DataType.Password)]
        public string? Createpassword { get; set;}
        [Required]
        [MaxLength(10)]
        public string? Mobile { get; set;}
        [Required]
        [Range(18,50)]
        public int Age { get; set;}
        [Required]
        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
        // public dynamic Password { get; internal set; }
    }
    
}
