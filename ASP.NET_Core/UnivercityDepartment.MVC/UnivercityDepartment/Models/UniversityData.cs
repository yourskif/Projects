namespace UnivercityDepartment.Models
{
    public class UnivercityData
    {
        public List<Faculty> Faculties { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }
        public List<Teacher> Teachers { get; set; }

        //public IEnumerable<object> Faculties { get; internal set; }
    }
}
