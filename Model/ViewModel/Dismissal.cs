using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel
{
    public class Dismissal
    {
        [Display(Name = "Date of employment")]
        [Required(ErrorMessage = "Date can't be empty")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Employee can't be empty")]
        public int EmployeeId { get; set; }
        [Display(Name = "Employee")]

        [Required(ErrorMessage = "Employee can't be empty")]
        public Employee? Employee { get; set; }

        [Required(ErrorMessage = "Department can't be empty")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department can't be empty")]
        public Department? Department { get; set; }
    }
}
