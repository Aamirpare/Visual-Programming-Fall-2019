using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new HperMediaContext();
            //var s = new Student() {
            //  FullName = "Ajab Khabn",
            //  Email = "ajab.khan@gamil.com"
            //};

            //var s = new Student()
            //{
            //    FullName = "Sara Khan",
            //    Email = "sara.khan@gamil.com"
            //};

            //db.Students.Add(s);

            //var courses = new List<Course>()
            //{
            //    new Course(){ Title = "Visual Programming", Code="CSC444", Credits = 3},
            //    new Course(){ Title = "System Programming", Code="CSC441", Credits = 3},
            //    new Course(){ Title = "Web Programming", Code="CSC442", Credits = 3},

            //};

            //db.Courses.AddRange(courses);

            var courses = db.Courses.ToList();
            var students = db.Students;
            foreach (var s in students)
            {
                s.Courses = courses;
            }

            db.SaveChanges();

            //var s = db.Students.ToList();

            Console.WriteLine("Record added to the database....");
            Console.ReadKey();
        }
    }
}
