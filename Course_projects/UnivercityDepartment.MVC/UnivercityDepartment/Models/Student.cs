using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnivercityDepartment.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "Middle Name cannot exceed 50 characters")]
        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; }

        [StringLength(20, ErrorMessage = "Group cannot exceed 20 characters")]
        public string Group { get; set; }

        public int FacultyId { get; set; }
        [ValidateNever]
        public Faculty Faculty { get; set; }

        public int DepartmentId { get; set; }
        [ValidateNever]
        public Department Department { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName} {MiddleName}".Trim();
    }
}



