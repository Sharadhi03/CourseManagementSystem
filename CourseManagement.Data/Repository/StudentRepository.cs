using CourseManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Data.Repository
{
    public class StudentRepository
    {
        SmsContext SmsDbContext { get; set; }
        public StudentRepository()
        {
            this.SmsDbContext = new SmsContext();
        }
        public List<TblStudent> GetAllStudents()
        {
            return this.SmsDbContext.TblStudents.ToList();
        }
        public void AddStudent(TblStudent student)
        {
            this.SmsDbContext.TblStudents.Add(student);
            this.SmsDbContext.SaveChanges();
        }
        public void DeleteStudent(int studentId)
        {
            var studentNeedsTobeDeleted = this.SmsDbContext.TblStudents.Where(s => s.StudentId == studentId).FirstOrDefault();
            if (studentNeedsTobeDeleted != null)
            {
                this.SmsDbContext.Remove(studentNeedsTobeDeleted);
                this.SmsDbContext.SaveChanges();
            }
        }
        public TblStudent GetStudent(int studentId)
        {
            var a = this.SmsDbContext.TblStudents.Where(s => s.StudentId == studentId).FirstOrDefault();
            return a;
        }
    }
}
