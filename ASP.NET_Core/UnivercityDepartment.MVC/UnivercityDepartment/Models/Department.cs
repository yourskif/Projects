using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnivercityDepartment.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, ErrorMessage = "Department name cannot exceed 100 characters")]
        public string? DepartmentName { get; set; } // Nullable, або можна додати конструктор для ініціалізації

        // Зв'язок із факультетом
        [Required(ErrorMessage = "Faculty is required")]
        public int FacultyId { get; set; }

        [ValidateNever] // Уникаємо валідації навігаційної властивості
        public Faculty Faculty { get; set; }

        // Колекції вчителів і студентів
        [ValidateNever]
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        [ValidateNever]
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}




