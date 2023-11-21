using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using CourseManagementAPI.Models;
using CourseManagement.Data.Entities;
using CourseManagement.Data.Repository;

namespace CourseManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentRepository StudentRepository { get; set; }

        public StudentController()
        {
            this.StudentRepository = new StudentRepository();
        }
        [HttpGet]
        public List<TblStudent> GetAllStudents()
        {
            return this.StudentRepository.GetAllStudents();
        }
        [HttpPost]
        public void AddStudent(Student student)
        {
            TblStudent tblstudent = new TblStudent();
            tblstudent.StudentId = 1;
            tblstudent.Name = student.Name;
            tblstudent.Age = student.Age;
            tblstudent.Gender = student.Gender;
            tblstudent.CourseId = student.CourseId;
            this.StudentRepository.AddStudent(tblstudent);
        }
        [HttpDelete]
        public void DeleteStudent(int studentId)
        {
            this.StudentRepository.DeleteStudent(studentId);
        }
        [HttpGet("{studentId:int}")]
        public TblStudent GetStudent(int studentId, int courseId)
        {
            return StudentRepository.GetStudent(studentId);
        }
    }
}
