using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name="Employee Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Mobile { get; set; }

        [Required]
        [MaxLength(40)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(40)]
        public string? City { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public double Salary { get; set; }
        
        public int IsActive { get; set; }
        //[Key]
       // [ScaffoldColumn(false)]
        public int DeptId { get; set; }
        [NotMapped]
       [Required]
        public string? DeptName { get; set; }
    }
}
