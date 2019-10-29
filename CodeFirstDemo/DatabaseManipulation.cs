using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstDemo
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        public ICollection<Student> Students { get; set; }
    }

    public class HperMediaContext : DbContext
    {
        public HperMediaContext() : base("HyperMediaContext")
        {

        }
        public DbSet<Student> Students {set; get;}
        public DbSet<Course> Courses { get; set; }
    }
}
