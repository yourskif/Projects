using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace UnivercityDepartment.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ValidateNever]
        public Department Department { get; set; }

        [Required]
        public int FacultyId { get; set; }

        [ValidateNever]
        public Faculty Faculty { get; set; }
    }
}


