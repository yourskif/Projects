using UnivercityDepartment.Models;

namespace UnivercityDepartment.ViewModels
{
    public class AdminViewModel
    {
        public List<Faculty> Faculties { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
