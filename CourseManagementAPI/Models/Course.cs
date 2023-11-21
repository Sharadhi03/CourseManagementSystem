namespace CourseManagementAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int MinimumMarks { get; set; }
        public int MaximumMarks { get; set; }
    }
}

