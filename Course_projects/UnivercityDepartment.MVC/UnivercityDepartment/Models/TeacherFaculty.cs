using System;

namespace UnivercityDepartment.Models
{
    public class TeacherFaculty
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } // Навігаційна властивість

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; } // Навігаційна властивість
    }
}
