using System.ComponentModel.DataAnnotations;

namespace Model.ViewModel.Reports
{
    public class ParameterReportEmployeesInDepartment
    {
        private DateTime _dateEnd;

        [Display(Name = "Date from")]
        [Required(ErrorMessage = "Date start can't be empty")]
        public DateTime DateStart { get; set; }

        [Display(Name = "Date to")]
        [Required(ErrorMessage = "Date end can't be empty")]
        public DateTime DateEnd { get => _dateEnd; set => _dateEnd = new DateTime(value.Year, value.Month, value.Day, 23, 59, 59); }

        [Required(ErrorMessage = "Department can't be empty")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department can't be empty")]
        public Department? Department { get; set; }
    }
}
