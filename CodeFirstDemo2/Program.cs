using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo2
{
    //Model class for Student Table
    public class Student
    {
        public Student()
        {
            //Courses = new HashSet<Course>();
        }
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
    public class HperMediaContext : DbContext
    {
        public HperMediaContext() : base("HyperMediaContext") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
    class Program
    {
        public static HperMediaContext DbContext { get; set; } = new HperMediaContext();
        public static void AddSingleStudent()
        {
            //Add a student
            var student = new Student()
            {
                FullName = "Mullana Fazal",
                Email = "fazal@gmail.com"
            };
            DbContext.Students.Add(student);

            //Save in-memory data to the database
            DbContext.SaveChanges();
        }
        public static void AddMultipleStudents()
        {
            //add multiple students
            var students = new List<Student>()
            {
                new Student() { FullName = "Farzana", Email = "farzana@gmail.com" },
                new Student() { FullName = "Kajol", Email = "kajol@gmail.com" },
            };
            DbContext.Students.AddRange(students);

            //Save in-memory data to the database
            DbContext.SaveChanges();
        }
        public static void AddMultipleCourses()
        {
            //Add multiple courses
            var courses = new List<Course>()
            {
                new Course(){ Title = "Visual Programming", Code="CSC444", Credits = 3},
                new Course(){ Title = "System Programming", Code="CSC441", Credits = 3},
                new Course(){ Title = "Web Programming", Code="CSC442", Credits = 3},

            };
            DbContext.Courses.AddRange(courses);

            //Save in-memory data to the database
            DbContext.SaveChanges();

        }
        public static void AssignAllCourses()
        {
            //Assign all courses to all students
            DbContext.Students.ToList().ForEach(s => { s.Courses = DbContext.Courses.ToList(); });

            //Save in-memory data to the database
            DbContext.SaveChanges();
        }
        public static void DisplayStudents()
        {
            //Display all students
            foreach (var s in DbContext.Students)
            {
                Console.WriteLine("Full Name : " + s.FullName);
                Console.WriteLine("Email : " + s.Email);
            }
        }
        public static void DisplayAllocations()
        {
            //Display Student with courses assinged
            var students = from student in DbContext.Students
                           //where student.FullName.Contains("Farza")
                           select student;

            //foreach (var s in DbContext.Students.ToList())
            foreach (var s in students.ToList())
            {
                Console.WriteLine("Student : " + s.FullName);
                Console.WriteLine("".PadLeft(50, '-'));
                var courses = from course in s.Courses
                              where course.Title.Contains("System")
                              select course;
                foreach (var c in courses)
                {
                    Console.WriteLine("Tile :" + c.Title);
                    Console.WriteLine("Code :" + c.Code);
                }
                Console.WriteLine("");
            }

        }

        public static string[] Names => new string[] 
        { 
            "Mango", "Peach", "Pears", "Orange",
            "Mango", "Peach", "Pears", "Orange",
            "Mango", "Peach", 
        };

        static void Main(string[] args)
        {
            //AddSingleStudent();
            //DisplayStudents();
            //AddMultipleStudents();
            //DisplayStudents();
            //AddMultipleCourses();
            //AssignAllCourses();
            //DisplayAllocations();

            var fruits = from n in Names
                         join m in Names
                         on n equals m
                         //where n == "Mango"
                         select n;
            var fruits2 = Names.Select(x => x)
                          .Where(x => x.Contains("Mango"));

            var joined = Names.Join(Names, x => x, y => y, (x, y) => new { x, y })
                         .Select(n => n.x);

            foreach (var n in joined)
            {
                Console.WriteLine( n);
            }

            Console.ReadLine();
        }
    }
}
