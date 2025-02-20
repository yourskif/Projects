using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnivercityDepartment.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Faculty name is required")]
        [StringLength(100, ErrorMessage = "Faculty name cannot exceed 100 characters")]
        public string FacultyName { get; set; }

        // Колекція відділів
        public ICollection<Department> Departments { get; set; } = new List<Department>();

        // Колекції вчителів і студентів
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

        // Ідентифікатор вибраного відділу
        public int? SelectedDepartmentId { get; set; }
    }
}

