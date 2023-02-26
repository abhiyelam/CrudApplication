using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CrudApplication.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Phone { get; set; }

       
         
        [Required]
        [MaxLength(40)]
        public string? City { get; set; }

        [Required]
        public double Marks { get; set; }
    }
}
