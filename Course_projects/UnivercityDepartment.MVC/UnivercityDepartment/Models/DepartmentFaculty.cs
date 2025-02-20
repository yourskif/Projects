namespace UnivercityDepartment.Models
{
    public class DepartmentFaculty
    {
        public int DepartmentId { get; set; }
        public int FacultyId { get; set; }

        // Навігаційні властивості для зв'язку з відповідними таблицями
        public Department Department { get; set; }
        public Faculty Faculty { get; set; }
    }
}
