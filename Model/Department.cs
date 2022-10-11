using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(100)]
        public string? Name { get; set; }

        public int? GroupDepartmentId { get; set; }
        public Department? GroupDepartment { get; set; }
    }
}
