/*
    Author      : Aamir Shabbir Pare
    Description : Entity Framework Database First Workflow BSSE 6A
    Date        : Oct 23, 2019, @ 1600 - 1730 Hrs
    Location    : Room # G05, Block AB02
                  Department Computer Science
                  COMSATS University
                  Check Shehzad Islamabad
    Comment     : Working with databases - Persistense 
                  For this demo you need to generate a  entity data model
                  based on existing database.
                  In my case, i created a database TestDB and Table Student 
                  in SQL Server using SQL Server Management Studio
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Polymorphism.DatabaseFirst
{
    public class DatabaseFirstDemo
    {
        public static void Main(string[] args)
        {
            //Create a databse context 
            var dbContext = new TestDBEntities();
            
            //create new student object
            var newStudent = new Student()
            {
                FullName = "Marshal Missel",
                Email = "marshar@gmail.com"
            };
            //Add to the in-memory students collection
            dbContext.Students.Add(newStudent);

            //var s = dbContext.Students.Find(1);
            //s.Email = "jhon.kansas@gmail.com";

            //var s = dbContext.Students.Find(2);
            //dbContext.Students.Remove(s);

            //Save changes to the database
            dbContext.SaveChanges();
            
            Console.ReadKey();
        }
    }
}
