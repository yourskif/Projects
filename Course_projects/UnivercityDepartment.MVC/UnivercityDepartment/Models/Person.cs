using System;
using System.ComponentModel.DataAnnotations;

namespace UnivercityDepartment.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
