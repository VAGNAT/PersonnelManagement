using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class PersonnelMovements
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date can't be empty")]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; }

        [Required(ErrorMessage = "Employee can't be empty")]
        public int EmployeeId { get; set; }
        
        [Required(ErrorMessage = "Employee can't be empty")]
        public Employee? Employee { get; set; }

        [Required(ErrorMessage = "Department can't be empty")]
        public int? DepartmentId { get; set; }

        [Required(ErrorMessage = "Department can't be empty")]
        public Department? Department { get; set; }        
    }
}
