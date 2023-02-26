using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace CrudApplication.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [ScaffoldColumn(false)]
        public int DeptId { get; set; }
        
        [Required]
        public string? DeptName { get; set; }
    }
}
