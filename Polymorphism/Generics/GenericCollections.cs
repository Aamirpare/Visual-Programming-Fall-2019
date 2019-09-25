using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Generics
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
    }
    public class GenericCollections
    {
        List<Student> Students = new List<Student>();
        public GenericCollections()
        {
            Students.Add(new Student() { StudentID = 100, FullName = "Ahmed" });
            Students.Add(new Student() { StudentID = 100, FullName = "Ahmed" });
            Students.Add(new Student() { StudentID = 100, FullName = "Ahmed" });
            Students.Add(new Student() { StudentID = 100, FullName = "Ahmed" });
            Students.Add(new Student() { StudentID = 100, FullName = "Ahmed" });
        }


        public void Add(Student student)
        {
            Students.Add(student);
        }
        public void Display()
        {
            foreach (var student in Students)
            {
                Console.WriteLine("ID:  " + student.StudentID);
                Console.WriteLine("FullName:  " + student.FullName);
            }
        }

    }
    public class GenericCollectionsDemo
    {
        public static void Main(string[] args)
        {
            GenericCollections c = new GenericCollections();
            c.Display();
            c.Add(new Student() { StudentID = 309, FullName = "Anita" });
            c.Display();
            Console.ReadKey();
        }
    }
}
