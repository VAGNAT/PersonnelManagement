using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        [StringLength(100)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name can't be empty")]
        [StringLength(100)]
        public string? LastName { get; set; }

        [NotMapped]
        public string Presentation => $"{LastName} {FirstName}";

        [Required(ErrorMessage = "Date of birth can't be empty")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}