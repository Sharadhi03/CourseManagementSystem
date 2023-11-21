using System.ComponentModel.DataAnnotations;

namespace CourseManagementAPI.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [MaxLength(15, ErrorMessage = "Name should be within 15 characters.")]
        public string Name { get; set; }
        [Range(18, 30, ErrorMessage = "Student is not eligible.")]
        public int Age { get; set; }
        public string Gender { get; set; }
        public List<Course> Courses { get; set; }
        public int? CourseId { get; internal set; }
    }
}
