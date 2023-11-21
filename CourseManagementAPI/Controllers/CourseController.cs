using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseManagementAPI.Models;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private static List<Course> courselist = new List<Course>()
        {
            new Course
            {
                CourseId=114,
                Name="Computer Science",
                Duration=4,
                MinimumMarks=35,
                MaximumMarks=100
            },
            new Course
            {
               CourseId=234,
               Name="Charted Accountancy",
               Duration=3,
               MinimumMarks=200,
               MaximumMarks=400
            },
        };
        [HttpGet]
        public List<Course> GetAllCourses()
        {
            return courselist;
        }
        
        [HttpPost]
        public void AddCourse(Course course)
        {
            courselist.Add(course);
        }
        [HttpDelete]
        public void DeleteCourse(int courId)
        {
            var coursetobeDeleted = courselist.Where(c => c.CourseId == courId).FirstOrDefault();
            courselist.Remove(coursetobeDeleted);
        }
        [HttpGet("{courId:int}")]
        public Course GetCourseById(int courId)
        {
            var courseBy = courselist.Where(c => c.CourseId == courId).FirstOrDefault();
            return courseBy;
        }
    }
}
