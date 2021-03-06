﻿using System;
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
            Students.Add(new Student() { StudentID = 101, FullName = "Name 1" });
            Students.Add(new Student() { StudentID = 102, FullName = "Name 2" });
            Students.Add(new Student() { StudentID = 103, FullName = "Name 3" });
            Students.Add(new Student() { StudentID = 104, FullName = "Name 4" });
            Students.Add(new Student() { StudentID = 105, FullName = "Name 5" });
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public Student GetStudent(int index)
        {
            return Students[index];
        }
        public void Remove(Student student)
        {
            Students.Remove(student);
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
        public static void Main_generic_ollections(string[] args)
        {
            GenericCollections c = new GenericCollections();
            c.Display();
            c.Add(new Student() { StudentID = 309, FullName = "Anita" });
            c.Remove(c.GetStudent(3));
            c.Display();
            Console.ReadKey();
        }
    }
}
